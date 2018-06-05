using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms.VisualStyles;
using NPlot;
using Grid=NPlot.Grid;

//using Grid = System.Windows.Forms.DataVisualization.Charting.Grid;

namespace FireBridCloud
{
    public partial class FrmWave : Form
    {
        private DataTable dt = new DataTable();
        private System.Windows.Forms.DataVisualization.Charting.Chart MyChart = new Chart();
        public FrmWave()
        {
            InitializeComponent();
            //MyChart.Location = new Point(61, 138);
            //this.Controls.Add(MyChart);
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            string strTitle = string.Empty;
            string strFilter = string.Empty;
            strTitle = "请选择Excel文件";
            strFilter = "Excel文件(*.xls)|*.xls";

            //选择Excel文件
            OpenFileDialog dia = new OpenFileDialog();
            dia.Title = strTitle;
            dia.Filter = strFilter;
            dia.Multiselect = false;
            //dia.InitialDirectory = lastSelectPath;
            if (dia.ShowDialog() == DialogResult.OK)
            {
                txt_filePath.Text = dia.FileName;
                //txtPath.Text = strSelectedPath;
            }

            ExcelMakerNPOI maker = new ExcelMakerNPOI();
            if (!ExcelMakerNPOI.OpenExcel(ref maker, txt_filePath.Text))
                return;
            //获取Excel表名
            string[] sheetNames = maker.GetSheetNames();
            if (sheetNames == null) return;
            string sheetName = sheetNames[0];
            //设置当前表
            maker.ActiveSheet(sheetName);
            //表格行列数
            int rowCount = maker.RowNumbers;
            int columnCount = maker.ColumnNumbers;
            //表格数据存储至DataTable中
            dt = maker.ReadExcelToDataTable(1);
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count == 0)
                return;
            int day = Convert.ToInt32(txtDays.Text);
            if (day > dt.Rows.Count)
                day = dt.Rows.Count;
            DataView dv = dt.DefaultView;
            dv.Sort = " 时间 desc";
            DataTable dtTimeDesc = dv.ToTable();
            //拿最高值和开盘值相比
            double high = 0;
            double open = 0;
            double low = 0;
            int useDay = 0;
            //平均天数
            int runRow = 0;
            int totalDay = 0;
            List<int> listDay = new List<int>();
            for (int i = 0; i < dtTimeDesc.Rows.Count; i++)
            {
                if (runRow > day)
                    break;
                high = Convert.ToDouble(dtTimeDesc.Rows[i]["最高"].ToString());
                low = Convert.ToDouble(dtTimeDesc.Rows[i]["最低"].ToString());
                useDay = 0;

                runRow++;
                for (int j = i; j < dtTimeDesc.Rows.Count; j++)
                {
                    useDay++;
                    double highToday = Convert.ToDouble(dtTimeDesc.Rows[j]["最高"].ToString());
                    double lowToday = Convert.ToDouble(dtTimeDesc.Rows[j]["最低"].ToString());
                    if (highToday > high) high = highToday;
                    if (lowToday < low) low = lowToday;
                    if (high / low >= 1.1)
                    {
                        listDay.Add(useDay);
                        totalDay += useDay;
                        break;
                    }
                }


            }

            txtResult.Text = ((double)totalDay/(double)day).ToString("####.##");
            //chart1.Visible = true;
            //chart1.Location = new System.Drawing.Point(86, 150);
            //chart1.Size = new Size(200, 200);
            //this.Controls.Add(MyChart);
            //MyChart.DataSource = dt;
            DataView firstView = dt.DefaultView;
            //chart1.Series.Add("Default");
            chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
            chart1.Series["Series1"].Points.DataBindXY(firstView, "时间", firstView, "最高");
            chart1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            plot();
        }
        /////////各种绘图//////////         
        private void plot()
        {
            CommonFunction.GetStockMapDay("300043", myPlot);
            myPlot.MouseMove += (sender, args) =>
            {
                //label4.Text = myPlot.Cursor.HotSpot.X.ToString();
                var a = ((NPlot.Windows.PlotSurface2D)sender);
                a.DateTimeToolTip = true;
                //label4.Refresh();
                //var b = ;
            };
        }

        private void button2_Click(object sender, EventArgs e)
        {
            changeSize();
        }
        ///放大缩小
        private void changeSize()
        {
            //this.myPlot.XAxis1.IncreaseRange(0.1);
            //this.myPlot.YAxis1.IncreaseRange(0.1); //缩小
            this.myPlot.XAxis1.IncreaseRange(-0.1);
            this.myPlot.YAxis1.IncreaseRange(-0.1); //放大
            this.myPlot.Refresh();
        }
        void chart_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                e.Text = string.Format("{0} {1}", dp.XValue, dp.YValues[0]);
            }
        }

        private void chart2_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                Point mousePoint = new Point(e.X, e.Y);
                chart2.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
                chart2.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);
               
                CalloutAnnotation annotation = new CalloutAnnotation();
                //CalloutAnnotation test2 = new CalloutAnnotation();
                //test2.AllowMoving = true;
                
                annotation.Text = "this is a test";
                annotation.Visible = true;
                //Point formPoint = this.PointToScreen( Control.MousePosition);//鼠标相对于窗体左上角的坐标
                //int x = formPoint.X;
                //int y = formPoint.Y;
                //double xValue = chart2.ChartAreas[0].AxisX.ValueToPixelPosition(e.X);
                //double yValue = chart2.ChartAreas[0].AxisY.ValueToPixelPosition(e.Y);
                //annotation.X = xValue;
                //annotation.Y = yValue;
                //label5.Text = xValue.ToString();
                //label6.Text = yValue.ToString();


                ChartArea ca = chart2.ChartAreas[0];
                Series S = chart2.Series["price"];
                RectangleF rf = InnerPlotPositionClientRectangle(chart2, ca);
                float px = (float)((e.X - rf.X) * S.Points.Count / rf.Width);

                int p0 = (int)px;  // previous point
                //int p1 = p0 + 1;   // next point

                //if (p0 >= 0 && p0 < S.Points.Count)
                //    Console.WriteLine("DataPoint # " + p0 + " has a y-value of " +
                //                       S.Points[p0].YValues[0].ToString("0.00"));

                annotation.AnchorDataPoint = S.Points[p0];


                //你通过比例关系计算点的高度值信息，传给toolTip1即可
                //PointF point = FindNearestDataPoint(e.X, e.Y);
                //annotation.AnchorDataPoint = chart2.Series["price"].Points[(int)point.X - 1];
                //if (!float.IsNaN(e.NewAnchorLocationX))
                //{
                //    // Get the nearest point to the new location
                //    PointF point = FindNearestDataPoint(e.NewAnchorLocationX, e.NewAnchorLocationY);

                //    annotation.AnchorDataPoint = Chart1.Series[0].Points[(int)point.X - 1];
                //    e.NewAnchorLocationX = point.X;
                //    e.NewAnchorLocationY = point.Y;
                //}
                //annotation.AnchorDataPoint = new DataPoint(e.X, e.Y);
                //annotation.X = (mousePoint).X;
                //annotation.Y = (mousePoint).Y;
                //test2.Text = "this is a test2";
                //test2.AnchorX = 30;
                //test2.AnchorY = 25;


                //if (!float.IsNaN(e.NewAnchorLocationX))
                //{
                //    // Get the nearest point to the new location
                //    PointF point = FindNearestDataPoint(e.NewAnchorLocationX, e.NewAnchorLocationY);

                //    annotation.AnchorDataPoint = Chart1.Series[0].Points[(int)point.X - 1];
                //    e.NewAnchorLocationX = point.X;
                //    e.NewAnchorLocationY = point.Y;
                //}


                //test2.AnchorDataPoint = chart2.Series["price"].Points[3]; ;
                chart2.Annotations.Clear();
                chart2.Annotations.Add(annotation);
                //chart2.Annotations.Add(test2);
                chart2.Refresh();
            }
            catch
            {
                return;
            }

        }

        private PointF FindNearestDataPoint(double X, double Y)
        {
            // Get the int portion of the X value
            int curIndex = (int)Math.Round(X);

            // If curIndex is less than 1 curIndex is set to 1
            curIndex = (int)Math.Max(curIndex, 1);

            // If curIndex is greater than 5 curIndex is set to 5 (X Value of max point in series)
            curIndex = (int)Math.Min(curIndex, chart2.Series["price"].Points.Count);

            // Return the point value of the nearest point
            return new PointF(curIndex, (float)chart2.Series["price"].Points[curIndex - 1].YValues[0]);
        }

        RectangleF InnerPlotPositionClientRectangle(Chart chart, ChartArea CA)
        {
            RectangleF IPP = CA.InnerPlotPosition.ToRectangleF();
            RectangleF CArp = ChartAreaClientRectangle(chart, CA);

            float pw = CArp.Width / 100f;
            float ph = CArp.Height / 100f;

            return new RectangleF(CArp.X + pw * IPP.X, CArp.Y + ph * IPP.Y,
                                    pw * IPP.Width, ph * IPP.Height);
        }
        RectangleF ChartAreaClientRectangle(Chart chart, ChartArea CA)
        {
            RectangleF CAR = CA.Position.ToRectangleF();
            float pw = chart.ClientSize.Width / 100f;
            float ph = chart.ClientSize.Height / 100f;
            return new RectangleF(pw * CAR.X, ph * CAR.Y, pw * CAR.Width, ph * CAR.Height);
        }
        private void MsChartMethod()
        {
            DataTable dt = CommonFunction.GetStockHistoryInfo("300043");
            dt.DefaultView.Sort = " Date asc";
            dt = dt.DefaultView.ToTable();
            //Random rnd = new Random();
            // Create Chart Area
            //ChartArea chartArea1 = new ChartArea();
            //System.Windows.Forms.DataVisualization.Charting.Legend legend =
            //new System.Windows.Forms.DataVisualization.Charting.Legend();
            //Series series = new Series();

            //// Add Chart Area to the Chart
            //MyChart.Legends.Add(legend);
            //MyChart.ChartAreas.Add(chartArea1);
            //MyChart.Series.Add(series);


            //chart2.Legends[0].Enabled = false;//不显示图例

            chart2.ChartAreas[0].BackColor = Color.White;//设置背景为白色

            //chart2.ChartAreas[0].Area3DStyle.Enable3D = true;//设置3D效果
            //chart2.ChartAreas[0].Area3DStyle.PointDepth =
            //chart2.ChartAreas[0].Area3DStyle.PointGapDepth = 50;//设置一下深度，看起来舒服点……
            //chart2.ChartAreas[0].Area3DStyle.WallWidth = 0;//设置墙的宽度为0；

            //chart2.ChartAreas[0].AxisY.LabelStyle.Format = "0%";//格式化，为了显示百分号
            //chart2.ChartAreas[0].AxisY.Interval = 0.05;//设置刻度间隔为5%
            //chart2.ChartAreas[0].AxisX.MajorGrid.Enabled =
            //chart2.ChartAreas[0].AxisY.MajorGrid.Enabled = false;//不显示网格线

            //chart2.ChartAreas[0].AxisX.Minimum = 0.5;//设置最小值，为了让第一个柱紧挨坐标轴

            //chart2.Series[0].Label = "#VAL{P}";//设置标签文本 (在设计期通过属性窗口编辑更直观)
            //chart2.Series[0].IsValueShownAsLabel = true;//显示标签

            ////MyChart.Series[0].CustomProperties = "DrawingStyle=Cylinder, PointWidth=1";//设置为圆柱形 (在设计期通过属性窗口编辑更直观)
            //chart2.Series[0].Palette = ChartColorPalette.Pastel;//设置调色板

            //数据
            //MyChart.Series[0].Points.
            //chart2.Series[0].ChartType=SeriesChartType.Line ;
            //chart2.Series[0].Points.DataBind(dt.AsEnumerable(), "Date", "Open", "");


            List<DateTime> listDate = new List<DateTime>();
            //List<double> listClose = new List<double>();
            List<double> listClose = new List<double>();
            foreach (DataRow dr in dt.Rows)
            {
                listDate.Add(DateTime.Parse(dr["Date"].ToString()));
                listClose.Add(double.Parse(dr["Adj Close"].ToString()));
            }

            Series dataTable3Series = new Series("price");

            //dataTable3Series.Points.DataBindXY(listDate.ToArray(),listClose.ToArray());
            //dataTable3Series.XValueType = ChartValueType.DateTime;//设置X轴类型为时间
            //dataTable3Series.ChartType = SeriesChartType.Candlestick ;  //设置Y轴为折线


            chart2.Series.Add(dataTable3Series);//加入你的chart1
            // Set series chart type
            chart2.Series["price"].ChartType = SeriesChartType.Candlestick;

            // Set the style of the open-close marks
            chart2.Series["price"]["OpenCloseStyle"] = "Triangle";

            // Show both open and close marks
            chart2.Series["price"]["ShowOpenClose"] = "Both";

            // Set point width
            chart2.Series["price"]["PointWidth"] = "0.5";

            // Set colors bars
            chart2.Series["price"]["PriceUpColor"] = "Green"; // <<== use text indexer for series
            chart2.Series["price"]["PriceDownColor"] = "Red"; // <<== use text indexer for series
            int n = 0;
            foreach (DataRow dr in dt.Rows)
            {

                // adding date and high
                chart2.Series["price"].Points.AddXY(DateTime.Parse(dr["Date"].ToString()), float.Parse(dr["High"].ToString()));
                // adding low
                chart2.Series["price"].Points[n].YValues[1] = float.Parse(dr["Low"].ToString());
                //adding open
                chart2.Series["price"].Points[n].YValues[2] = float.Parse(dr["Open"].ToString());
                // adding close
                chart2.Series["price"].Points[n].YValues[3] = float.Parse(dr["Close"].ToString());
                n++;
            }



            //chart2.ChartAreas.Clear();



            chart2.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].CursorX.Interval = 0;
            chart2.ChartAreas[0].CursorX.IntervalOffset = 0;
            chart2.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Minutes;
            chart2.ChartAreas[0].AxisX.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = false;

            chart2.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart2.ChartAreas[0].CursorY.IsUserSelectionEnabled = true;
            chart2.ChartAreas[0].CursorY.Interval = 0;
            chart2.ChartAreas[0].CursorY.IntervalOffset = 0;
            chart2.ChartAreas[0].CursorY.IntervalType = DateTimeIntervalType.Minutes;
            chart2.ChartAreas[0].AxisY.ScaleView.Zoomable = true;
            chart2.ChartAreas[0].AxisY.ScrollBar.IsPositionedInside = false;

            chart2.GetToolTipText += new EventHandler<ToolTipEventArgs>(chart_GetToolTipText);
            chart2.Series["price"].IsValueShownAsLabel = true;
            //chart2.Series[0].Points.AddXY("<10", 0.201);
            //chart2.Series[0].Points.AddXY("10~20", 0.395);
            //chart2.Series[0].Points.AddXY("20~30", 0.173);
            //chart2.Series[0].Points.AddXY("30~40", 0.136);
            //chart2.Series[0].Points.AddXY("40~50", 0.059);
            //chart2.Series[0].Points.AddXY("50~60", 0.015);
            //chart2.Series[0].Points.AddXY(">60", 0.022);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmEquation frm = new FrmEquation();
            frm.Show();
        }
    }
}
