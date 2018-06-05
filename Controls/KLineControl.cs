using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace KLineControl
{
    public partial class KLineControl : UserControl
    {
        public DataTable dtMain = null;
        public string stockNo = string.Empty;
        public string stockName = string.Empty;


        private bool isTest = true;
        private List<StockInfo> listStockInfo = new List<StockInfo>();
        //private System.Windows.Forms.Label[] listLable = null;
        private double MaxPrice = 0.0;
        private double MinPrice = 10000.0;
        private int grapHeight = 0;
        private Dictionary<Label, StockInfo> dicStockInfo = new Dictionary<Label, StockInfo>();
        private int LabelWidth = 4;
        private int oldIndex = 0;
        private int newIndex = 0;
        private int skipCount = 0;
        private Label maxPriceLable = null;
        private Label minPriceLable = null;
        private Label activeLable = null;
        internal class StockInfo
        {
           //Date	Open	High	Low	Close	Volume	Adj Close
            public DateTime Date { get; set; }
            public double Open { get; set; }
            public double High { get; set; }
            public double  Low { get; set; }
            public double Close { get; set; }
            public int Volume { get; set; }
            public double AdjClsoe { get; set; }
            public bool IsMouseEntry { get; set; }
            public Label CurrentLable { get; set; }
            //上一天股价信息
            public Label PreLabel { get; set; }
            //下一天股价信息
            public Label NextLabel { get; set; }
        }
        private void MouseWheel1(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //MessageBox.Show(panel2.PointToClient(MousePosition).X +"," +this.PointToClient(MousePosition).Y );
            Point mousePoint = panel2.PointToClient(MousePosition);
            if (mousePoint.X < 0 || mousePoint.X > panel2.Width || mousePoint.Y < 0 || mousePoint.Y > panel2.Height)
                return;
            oldIndex = mousePoint.X/LabelWidth;
            if (e.Delta > 0)
            {
                LabelWidth++;
                newIndex = mousePoint.X/LabelWidth;
                FillThePanel(dtMain, this.panel2);
            }
            else if(LabelWidth>1)
            {
                LabelWidth--;
                newIndex = mousePoint.X / LabelWidth;
                FillThePanel(dtMain, this.panel2);
            }
        }
        private void Lable_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Label label = sender as Label;
            if ( dicStockInfo[label].IsMouseEntry)
            {
                Pen pen2 = new Pen(Color.Orange, 1);
                g.DrawLine(pen2, (int)(LabelWidth * 0.8) / 2, 0, (int)(LabelWidth * 0.8) / 2, grapHeight);
            }
            else
            {
                g.Clear(panel2.BackColor);
            }
            int rectHighStart = 0;
            int rectHeight = 0;
            Color color = new Color();
            if (label == null) return;
            if (dicStockInfo[label] == null) return;
            StockInfo stockInfo = dicStockInfo[label];
            double higherPrice , lowerPice ;
            if (stockInfo.Open > stockInfo.Close)
            {
                color = Color.Green;
                higherPrice = stockInfo.Open;
                lowerPice = stockInfo.Close;                 
            }
            else
            {
                color = Color.Red;
                higherPrice = stockInfo.Close;
                lowerPice = stockInfo.Open;
            }
            //设定最低价在最低位,最高价在最高位
            //即每一1元的高度为
            double unitHeight=grapHeight/(MaxPrice - MinPrice);


            rectHeight = (int) ((higherPrice - lowerPice)*unitHeight);
            //rectHighStart = (int) (grapHeight - ((MaxPrice - (MaxPrice - higherPrice))/(MaxPrice)*grapHeight));   
            rectHighStart=grapHeight-(int)((higherPrice-MinPrice)*unitHeight);
            int lineHigt, lineLow;
            Rectangle r = new Rectangle(0, rectHighStart, (int)(LabelWidth * 0.8), rectHeight);
            lineHigt = grapHeight - (int)((stockInfo.High - MinPrice) * unitHeight);
            lineLow = grapHeight - (int)((stockInfo.Low - MinPrice) * unitHeight); ;  
            Brush brush = new SolidBrush(color);//填充的颜色
            Pen pen = new Pen(color);
            g.FillRectangle(brush, r);
            g.DrawLine(pen, r.Width / 2, lineHigt, r.Width / 2, lineLow);
            if (label == maxPriceLable)
            {
                panelUp.Refresh();
                Graphics gtest = panelUp.CreateGraphics();
                gtest.DrawString(dicStockInfo[maxPriceLable].High.ToString(), this.Font, new SolidBrush(Color.Black), label.Location.X, 3);
            }

            if (label == minPriceLable)
            {
                panelDown.Refresh();
                Graphics gtest = panelDown.CreateGraphics();
                gtest.DrawString(dicStockInfo[minPriceLable].Low.ToString(), this.Font, new SolidBrush(Color.Black), label.Location.X, 3);
            }
            //label.Refresh();
        }
        private void Label_MouseEnter(object sender, EventArgs e)
        {
            if(activeLable!=null)
            {
                dicStockInfo[activeLable].IsMouseEntry = false;
                activeLable.Refresh();
            }
            Label label = (Label )sender ;
            activeLable = label;
            RefreshLabelData(label);
            dicStockInfo[label].IsMouseEntry = true;
            label.Focus();
            label.Refresh();
        }
        private void Label_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            if (!dicStockInfo.ContainsKey(label)) return;
            dicStockInfo[label].IsMouseEntry = false;
            label.Refresh();
        }
        private void FillThePanel(DataTable dt,Panel panel)
        {
            try
            {
                if (dt == null) return;
                //List<StockInfo> listStockInfo = new List<StockInfo>();
                listStockInfo.Clear();
                //清除Panel里的所有数据重绘
                panel.Controls.Clear();

                DataRow[] drArr = dt.Select("Volume>0 ");//查询
                dt = null;
                dt = drArr.CopyToDataTable();
                dt.DefaultView.Sort = " Date asc ";
                dt = dt.DefaultView.ToTable();
                //只绘panel能放得下的最近的数据
                //最多能绘的个数
                int maxcount = panel2.Width / LabelWidth;
                //跳过的数目
                skipCount = skipCount + (oldIndex - newIndex);
                int countShip = 0;
                int countDraw = 1;
                MaxPrice = 0.0;
                MinPrice = 10000.0;
                this.SuspendLayout();
                dicStockInfo.Clear();
                //listLable = new Label[listStockInfo.Count];
                int x = 0, y = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //if (countDraw >= maxcount) break;
                    //Date	Open	High	Low	Close	Volume	Adj Close
                    StockInfo stockInfo = new StockInfo();
                    DateTime date;
                    double open = 0.0, high = 0.0, low = 0.0, close = 0.0, adjClose = 0.0;
                    int volume = 0;
                    if (DateTime.TryParse(dt.Rows[i]["Date"].ToString(), out date))
                        stockInfo.Date = date;
                    if (double.TryParse(dt.Rows[i]["Open"].ToString(), out open))
                        stockInfo.Open = Math.Round(open, 2, MidpointRounding.AwayFromZero);
                    if (double.TryParse(dt.Rows[i]["High"].ToString(), out high))
                        stockInfo.High = Math.Round(high, 2, MidpointRounding.AwayFromZero);
                    if (double.TryParse(dt.Rows[i]["Low"].ToString(), out low))
                        stockInfo.Low = Math.Round(low, 2, MidpointRounding.AwayFromZero);
                    if (double.TryParse(dt.Rows[i]["Close"].ToString(), out close))
                        stockInfo.Close = Math.Round(close, 2, MidpointRounding.AwayFromZero);
                    if (double.TryParse(dt.Rows[i]["Adj Close"].ToString(), out adjClose))
                        stockInfo.AdjClsoe = Math.Round(adjClose, 2, MidpointRounding.AwayFromZero);
                    if (int.TryParse(dt.Rows[i]["Volume"].ToString(), out volume))
                        stockInfo.Volume = volume;
                    listStockInfo.Add(stockInfo);
                    int listStockInfoIndex = listStockInfo.IndexOf(stockInfo);
                    //countDraw++;
                    x += LabelWidth;
                    Label label = new Label();
                    label.Location = new System.Drawing.Point(panel.Width-50-(dt.Rows.Count*LabelWidth)+x, y);
                    label.Name = "label" + i.ToString();
                    label.Size = new System.Drawing.Size(LabelWidth, grapHeight);
                    label.TabIndex = i;
                    label.Paint += Lable_Paint;
                    label.MouseEnter += Label_MouseEnter;
                    label.MouseLeave += Label_MouseLeave;
                    label.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.MouseWheel1);
                    GetMinAndMaxPrice(stockInfo, label);

                    listStockInfo[listStockInfoIndex].CurrentLable = label;
                    if (listStockInfoIndex - 1 >= 0)
                    {
                        listStockInfo[listStockInfoIndex].PreLabel = listStockInfo[listStockInfoIndex - 1].CurrentLable;
                    }

                    dicStockInfo.Add(label, listStockInfo[listStockInfoIndex]);
                    PanelAddLable(label);

                }
                for (int i = 0; i < listStockInfo.Count; i++)
                {
                    if (i + 1 < listStockInfo.Count) ;
                    listStockInfo[i].NextLabel = listStockInfo[i + 1].CurrentLable;
                }
                this.ResumeLayout(false);
                this.PerformLayout();
            }
            catch (Exception ex )
            {
                
                
            }

        }
        /// <summary>
        /// 获取图面上最小价格和最大价格
        /// </summary>
        /// <param name="stockInfo"></param>
        /// <param name="label"></param>
        private void GetMinAndMaxPrice(StockInfo stockInfo,Label label)
        {
            if (stockInfo.Low < MinPrice && label.Location.X > 0 - LabelWidth && label.Location.X<panel2.Width)
            {
                MinPrice = stockInfo.Low;
                minPriceLable = label;
            }
            if (stockInfo.High > MaxPrice && label.Location.X > 0 - LabelWidth && label.Location.X < panel2.Width)
            {
                MaxPrice = stockInfo.High;
                maxPriceLable = label;
            }
        }
        /// <summary>
        /// 添加在界面可见的控件
        /// </summary>
        /// <param name="label"></param>
        private void PanelAddLable(Label label)
        {
            if (label.Location.X > 0 - LabelWidth && label.Location.X < panel2.Width)
                panel2.Controls.Add(label);
        }
        //将左边没显示的图形显示出来
        private void btnChartToLeft_Click(object sender, EventArgs e)
        {
            MaxPrice = 0.0;
            MinPrice = 100000;
            if (dicStockInfo.Keys.First().Location.X > 0) return;
            panel2.SuspendLayout();
            panel2.Controls.Clear();
            foreach (KeyValuePair<Label, StockInfo> key in dicStockInfo)
            {
                //偏移距离
                int offset = (panel2.Width/8);
                key.Key.Location = new Point(key.Key.Location.X + offset, key.Key.Location.Y);
                GetMinAndMaxPrice(key.Value,key.Key);
                PanelAddLable(key.Key);
                panel2.ResumeLayout();
            }
        }
        /// <summary>
        /// 将右边没有显示的图形显示出来
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCharttoRight_Click(object sender, EventArgs e)
        {
            MaxPrice = 0.0;
            MinPrice = 100000;
            if (dicStockInfo.Keys.Last().Location.X < panel2.Width) return;
            panel2.SuspendLayout();
            panel2.Controls.Clear();
            foreach (KeyValuePair<Label, StockInfo> key in dicStockInfo)
            {
                //偏移距离
                int offset =- (panel2.Width / 8);
                key.Key.Location = new Point(key.Key.Location.X + offset, key.Key.Location.Y);
                GetMinAndMaxPrice(key.Value, key.Key);
                PanelAddLable(key.Key);
            }
            panel2.ResumeLayout();

        }
        public KLineControl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            //grapHeight = int.Parse(Math.Floor(panel2.Height*0.4).ToString());
            grapHeight = panel2.Height;
            //最多能绘的个数
            int maxcount = panel2.Width / LabelWidth;
            skipCount = dtMain.Rows.Count - maxcount;
            FillThePanel(dtMain, this.panel2);
        }

        private void KLineControl_Load(object sender, EventArgs e)
        {
            labelStockNo.Text= string.Format("股票代码:{0}", stockNo);
            labelStockName.Text = string.Format("股票名称:{0}", stockName);
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData==Keys.Left)
            {
                dicStockInfo[activeLable].IsMouseEntry = false;
                activeLable.Refresh();
                activeLable = dicStockInfo[activeLable].PreLabel;
                RefreshLabelData(activeLable);
                dicStockInfo[activeLable].IsMouseEntry = true;
                activeLable.Refresh();
            }
            else if (e.KeyData == Keys.Right)
            {
                dicStockInfo[activeLable].IsMouseEntry = false;
                activeLable.Refresh();
                activeLable = dicStockInfo[activeLable].NextLabel;
                RefreshLabelData(activeLable);
                dicStockInfo[activeLable].IsMouseEntry = true;
                activeLable.Refresh();
            }
        }

        private void RefreshLabelData(Label label)
        {
            this.label1.Text = string.Format("收盘:{0}", dicStockInfo[label].AdjClsoe);
            this.label2.Text = string.Format("日期:{0}", dicStockInfo[label].Date.ToShortDateString());
            this.label3.Text = string.Format("开盘:{0}", dicStockInfo[label].Open);
            this.label4.Text = string.Format("最高:{0}", dicStockInfo[label].High);
            this.label5.Text = string.Format("最低:{0}", dicStockInfo[label].Low);
            this.label6.Text = string.Format("天量:{0}", dicStockInfo[label].Volume);
            int index = listStockInfo.IndexOf(dicStockInfo[label]);
            if (index == 0)
                this.label7.Text = string.Format("涨幅:{0}", "");
            else
                this.label7.Text = string.Format("涨幅:{0}%", Math.Round((dicStockInfo[label].AdjClsoe - listStockInfo[index - 1].AdjClsoe) / listStockInfo[index - 1].AdjClsoe * 100, 2, MidpointRounding.AwayFromZero));
        }
        
    }
}
