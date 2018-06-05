using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FireBridCloud
{
    public partial class FrmEquation : Form
    {
        public FrmEquation()
        {
            InitializeComponent();
            DataTable dt = CommonFunction.GetStockHistoryInfo("300043");
            dt.DefaultView.Sort = " Date asc";
            dt = dt.DefaultView.ToTable();
            testData = String.Empty;
            int i = 0;
            foreach(DataRow dr in dt.Rows)
            {
                i++;
                testData += string.Format("{0},{1};",i,Convert.ToInt16(Convert.ToDouble(dr["Adj Close"].ToString())*10).ToString());
            }
            testData = testData.Substring(0, testData.Length - 1);
        }

        private string testData = "151,41;153,46;156,53;158,57;162,66;164,73;168,81;173,94;177,102;181,116;186,125;192,138;196,150;203,162;207,172;217,187;223,198;232,208;237,215;245,224;248,230;254,237;258,240;264,245;273,249;276,250;283,252;287,254;318,254;339,250;347,247;359,242;366,237;378,232;385,227;406,212;420,201;429,190;437,180;446,168;458,146;467,127;473,107;474,100;476,85;478,75;480,57;487,34;487,33";

        /// <summary>
        /// 解析实测数据。
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private List<Point> ParseTestData(string data)
        {
            List<Point> points = new List<Point>();
            foreach (var pointString in data.Split(';'))
            {
                string[] items = pointString.Split(',');
                points.Add(new Point(int.Parse(items[0]), int.Parse(items[1])));
            }
            return points;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //绘制实测数据
            var points = ParseTestData(testData);
            foreach (var pt in points)
            {
                e.Graphics.DrawEllipse(Pens.Red, pt.X - 2, pt.Y - 2, 5, 5);
            }

            //抛物线拟合
            var fittingPoints = ParaCurveFitting(points);

            //绘制拟合后的抛物线
            e.Graphics.DrawLines(Pens.Blue, fittingPoints.ToArray());
        }

        /// <summary>
        /// 抛物线拟合。
        /// </summary>
        /// <param name="points">实测数据。</param>
        /// <returns>拟合数据。</returns>
        private List<Point> ParaCurveFitting(List<Point> points)
        {
            if (points.Count < 2) return points;

            //构造线性方程组
            //a + bx + cx^2 = f(x)
            int n = points.Count;
            double sx = (double)points.Sum(c => c.X);
            double sx2 = (double)points.Sum(c => Math.Pow(c.X, 2));
            double sx3 = (double)points.Sum(c => Math.Pow(c.X, 3));
            double sx4 = (double)points.Sum(c => Math.Pow(c.X, 4));
            double sy = (double)points.Sum(c => c.Y);
            //double sxy = (double)points.Sum(c => c.X * c.Y);
            double sxy = 0;
            foreach (Point c in points)
            {
                sxy += c.X*c.Y;
            }

            double sx2y = (double)points.Sum(c => Math.Pow(c.X, 2) * c.Y);

            //高斯消去法求解方程组
            var result = Gauss(new double[,] { { n, sx, sx2, sy }, { sx, sx2, sx3, sxy }, { sx2, sx3, sx4, sx2y } });

            //拟合后的抛物线数据
            List<Point> fittingPoints = new List<Point>();
            if (result != null && result.Length >= 2)
            {
                double a = result[0];
                double b = result[1];
                double c = result[2];

                foreach (var pt in points)
                {
                    fittingPoints.Add(new Point(pt.X, (int)(a + b * pt.X + c * pt.X * pt.X)));
                }
            }
            return fittingPoints;
        }

        /// <summary>
        /// 高斯消去法求线性方程组的解。
        /// </summary>
        /// <param name="matrix">增广系数矩阵。</param>
        /// <returns>方程组的解（从低次到高次）。如果无解，则返回空引用；如果有无穷解，则返回空数组。</returns>
        /// <exception cref="ArgumentNullException">如果matrix为空引用，则抛出该异常。</exception>
        static double[] Gauss(double[,] matrix)
        {
            if (matrix == null) throw new ArgumentNullException("matrix");

            //无解
            int cols = matrix.GetLength(1);
            if (cols <= 1) return null;

            //有无穷解
            int rows = matrix.GetLength(0);
            if (rows < cols - 1) return new double[] { };

            //转换为行阶梯
            for (int i = 0; i < rows - 1; i++)
            {
                //选取主元（提高计算精度）
                GaussPivoting(matrix, i, rows, cols);

                //消去一列
                for (int k = i + 1; k < rows; k++)
                {
                    if (matrix[k, i] != 0)
                    {
                        double t = matrix[i, i] / matrix[k, i];
                        for (int j = i; j < cols - 1; j++)
                        {
                            matrix[k, j] = matrix[i, j] - matrix[k, j] * t;
                        }
                        matrix[k, cols - 1] = matrix[i, cols - 1] - matrix[k, cols - 1] * t;
                    }
                }
            }

            //检查秩，判断是否有唯一解
            int rank1 = 0, rank2 = 0;
            for (int i = 0; i < rows; i++)
            {
                bool isZeroRow = true;
                for (int j = i; j < cols - 1; j++)
                {
                    if (matrix[i, j] != 0)
                    {
                        isZeroRow = false;
                        break;
                    }
                }
                if (!isZeroRow) rank1++;
                if (!isZeroRow || matrix[i, cols - 1] != 0) rank2++;
            }

            //如果矩阵的秩小于增广矩阵的秩，则无解
            if (rank1 < rank2) return null;

            //如果矩阵的秩小于方程组的数量，则有无穷解
            if (rank1 < cols - 1) return new double[] { };

            //从底往上依次求解
            double[] result = new double[cols - 1];
            for (int i = rows - 1; i >= 0; i--)
            {
                double y = matrix[i, cols - 1];
                for (int j = i + 1; j < cols - 1; j++)
                {
                    y -= matrix[i, j] * result[j];
                }
                result[i] = matrix[i, i] != 0 ? Math.Round(y / matrix[i, i], 3) : 0;
            }

            return result;
        }

        /// <summary>
        /// 选主元。
        /// </summary>
        /// <param name="matrix">增广系数矩阵。</param>
        /// <param name="i">当前行。</param>
        static void GaussPivoting(double[,] matrix, int i, int rows, int cols)
        {
            //选主元
            int pivotRow = i;
            for (int k = i + 1; k < rows; k++)
            {
                if (Math.Abs(matrix[k, i]) > Math.Abs(matrix[pivotRow, i]))
                    pivotRow = k;
            }

            //交换行
            if (pivotRow != i)
            {
                double tmp = 0;
                for (int j = 0; j < cols; j++)
                {
                    tmp = matrix[i, j];
                    matrix[i, j] = matrix[pivotRow, j];
                    matrix[pivotRow, j] = tmp;
                }
            }

            //除以主元，当前主元变为1
            double pivot = matrix[i, i];
            if (pivot != 0)
            {
                for (int j = i; j < cols; j++)
                    matrix[i, j] /= pivot;
            }
        }
    }
}
