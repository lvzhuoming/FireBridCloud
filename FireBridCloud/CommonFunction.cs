/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：FireBridCloud
 *文件名：  CommomFunction
 *创建人：  吕焯明
 *创建时间：2016-12-20 15:48:39
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-12-20 15:48:39
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Business;
using Model;
using NPlot;
using Utility;

namespace FireBridCloud
{
    public class CommonFunction
    {
        /// <summary>
        /// 获取股票最近卖出点
        /// </summary>
        /// <param name="stockNo"></param>
        /// <returns></returns>
        public static double GetHoldStockSalePrice(string stockNo)
        {
            double salePrice =0.00;
            DataTable dt = Strategy.GetList(string.Format(" StockNo='{0}' order by Price", stockNo)).Tables[0];
            bool isReach = false;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (isReach)
                    {
                        salePrice = Math.Round(Convert.ToDouble(dr["Price"].ToString()), 2, MidpointRounding.AwayFromZero);
                       
                        break;
                    }
                    if ((bool) dr["HoldFlag"])
                    {
                        isReach = true;
                    }

                }
            }
            return salePrice;
        }
        /// <summary>
        /// 获取股票最近买入点
        /// </summary>
        /// <param name="stockNo"></param>
        /// <returns></returns>
        public static double GetHoldStockBuyPrice(string stockNo)
        {
            double buyPrice = 0.00;
            double oldPrice = 0.0;
            DataTable dt = Strategy.GetList(string.Format(" StockNo='{0}' order by Price", stockNo)).Tables[0];
            bool isReach = false;
            if (dt.Rows.Count != 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if ((bool)dr["HoldFlag"])
                    {
                        isReach = true;
                    }
                    if (isReach)
                    {
                        buyPrice = oldPrice;
                        //if(oldPrice==0)
                        //    buyPrice = Math.Round(Convert.ToDouble(dr["Price"].ToString())*0.95, 2, MidpointRounding.AwayFromZero);
                        break;
                    }
                    oldPrice = Math.Round(Convert.ToDouble(dr["Price"].ToString()), 2, MidpointRounding.AwayFromZero);
                }
            }
            return buyPrice;
        }

        /// <summary>
        /// 下载新浪服务器的股票信息 单只
        /// </summary>
        /// <param name="stockNo">股票代码</param>
        /// <returns></returns>
        public static M_UrlStock GetNowStockInfo(string stockNo)
        {
            M_UrlStock stockInfo = new M_UrlStock();
            List<string> listStockNo = new List<string>() {stockNo};
             string urlContent =GetUrlStockContent(listStockNo);
            List<M_UrlStock> listUrlStock = new List<M_UrlStock>();
            GetUrlInfo(urlContent, ref listUrlStock);
            if(listUrlStock.Count>0)
                stockInfo=listUrlStock[0];
            return stockInfo;
        }

        /// <summary>
        /// 下载新浪服务器的股票信息 批量
        /// </summary>
        public static List<M_UrlStock> GetNowStockInfoList(List<string> listStockNo)
        {
            //M_UrlStock stockInfo = new M_UrlStock();
            //List<string> listStockNo = new List<string>() { stockNo };
            string urlContent = GetUrlStockContent(listStockNo);
            List<M_UrlStock> listUrlStock = new List<M_UrlStock>();
            GetUrlInfo(urlContent, ref listUrlStock);
            return listUrlStock;
        }
        /// <summary>
        /// 在List中根据股票代码获取网络股票实体
        /// </summary>
        /// <param name="stockNo"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static M_UrlStock Ger_M_UrlStockFromList(string stockNo,List<M_UrlStock> list)
        {
            foreach (M_UrlStock item in list)
            {
                if (item.StockNo == stockNo)
                    return item;
            }
            return null;
        }
        /// <summary>
        /// 获取持仓信息的URL返回字符串
        /// </summary>
        /// <returns></returns>
        public static string GetUrlStockContent(List<string> listStockNo)
        {
            string urlHeald = "http://hq.sinajs.cn/list=";
            string strContent = string.Empty;
            //DataTable dt = HoldStock.GetList("").Tables[0];
            foreach (string str in listStockNo)
            {
                strContent += AddStockNoHead(str) + ",";

            }
            if (strContent != string.Empty)
                strContent = strContent.Substring(0, strContent.Length - 1);
            string strUrl = urlHeald + strContent;
            string urlValue = Utility.InternetHelper.SendRequest(strUrl, Encoding.Default);
            //if (string.IsNullOrEmpty(urlValue))
            return urlValue;
        }
        /// <summary>
        /// 分解Url反回的信息(递归思想）
        /// </summary>
        public static void GetUrlInfo(string strUrlValue, ref List<M_UrlStock> listUrlStock)
        {
            M_UrlStock urlstock = new M_UrlStock();
            int index1 = strUrlValue.IndexOf("=");
            if (index1 == -1) return;
            string stockNo = strUrlValue.Substring(index1 - 6, 6);
            urlstock.StockNo = stockNo;
            string str1 = strUrlValue.Substring(index1 + 2, strUrlValue.Length - index1 - 2);
            int index2 = str1.IndexOf(";");
            if (index2 == -1) return;
            string info = str1.Substring(0, index2 - 1);
            List<string> list = new List<string>(info.Split(','));
            if (list.Count < 30)
                return;
            urlstock.Price = Convert.ToDouble(list[3]);
            //如果当前价为0,当前价为昨天股价
            if(urlstock.Price<=0.0)
                urlstock.Price = Convert.ToDouble(list[2]);
            urlstock.UpdateTime = Convert.ToDateTime(list[30] + " " + list[31]);
            urlstock.YesterDayPrice = Convert.ToDouble(list[2]);
            urlstock.StockName = list[0];
            if(urlstock.Price>0)
                listUrlStock.Add(urlstock);
            //listUrlInfo.Add(info);
            string otherStr = str1.Substring(index2 + 1, str1.Length - index2 - 1);
            GetUrlInfo(otherStr, ref listUrlStock);
        }

        /// <summary>
        /// 为股票代码加sz或sh
        /// </summary>
        /// <param name="stockNo"></param>
        /// <returns></returns>
        public static string AddStockNoHead(string stockNo)
        {
            if (string.IsNullOrEmpty(stockNo))
                return string.Empty;
            string stockNoWithHead = string.Empty;
            string strFistNumber = stockNo.Substring(0, 1);
            if (strFistNumber == 6.ToString() || stockNo == "000001")
            {
                stockNoWithHead = "sh" + stockNo;
            }
            else if (strFistNumber == 3.ToString() || strFistNumber == 0.ToString())
            {
                stockNoWithHead = "sz" + stockNo;
            }
            return stockNoWithHead;
        }
        /// <summary>
        /// 判断股票是sz还是sh 下载历史数据用
        /// </summary>
        /// <param name="stockNo"></param>
        /// <returns></returns>
        public static string JudeStockNoHead(string stockNo)
        {
            if (string.IsNullOrEmpty(stockNo))
                return string.Empty;
            string stockHead = string.Empty;
            string strFistNumber = stockNo.Substring(0, 1);
            if (strFistNumber == 6.ToString() || stockNo == "000001")
            {
                stockHead = "ss";
            }
            else if (strFistNumber == 3.ToString() || strFistNumber == 0.ToString())
            {
                stockHead = "sz";
            }
            return stockHead;
        }
        /// <summary>
        /// 判断股票是sz还是sh 下载历史数据用
        /// </summary>
        /// <param name="stockNo"></param>
        /// <returns></returns>
        public static string JudeShangHai(string stockNo)
        {
            if (string.IsNullOrEmpty(stockNo))
                return string.Empty;
            string stockHead = string.Empty;
            string strFistNumber = stockNo.Substring(0, 1);
            if (strFistNumber == 6.ToString() || stockNo == "000001")
            {
                stockHead = "0";
            }
            else if (strFistNumber == 3.ToString() || strFistNumber == 0.ToString())
            {
                stockHead = "1";
            }
            return stockHead;
        }
        /// <summary>
        /// 获取股票历史数据
        /// </summary>
        /// <param name="stockNo"></param>
        /// <returns></returns>
        public static DataTable GetStockHistoryInfo(string stockNo)
        {
            string receivePath = CommonConstString.stockImagePath;
            string fileFullName = receivePath + stockNo + ".csv";
            DataTable dt = new DataTable();
            File.Delete(fileFullName);
            if(!File.Exists(fileFullName))
            {
                WebClient client = new WebClient();
                //string URLAddress = string.Format(@"http://table.finance.yahoo.com/table.csv?s={0}.{1}", stockNo, JudeStockNoHead(stockNo));            
                string URLAddress =
                    string.Format(@"http://quotes.money.163.com/service/chddata.html?code={0}{1}&start=19900902&end=21201108&fields=TCLOSE;HIGH;LOW;TOPEN;LCLOSE;CHG;PCHG;VOTURNOVER", JudeShangHai(stockNo), stockNo);            
                client.DownloadFile(URLAddress, fileFullName);
            }
            dt = CSVFileHelper.OpenCSV(fileFullName);
            return dt;
        }
        /// <summary>
        /// 利用雅虎接口获取日K线图
        /// </summary>
        /// <param name="stockNo"></param>
        /// <returns></returns>
        public static void GetStockMapDay(string stockNo,NPlot.Windows.PlotSurface2D myPlot)
        {
            DataTable dt = CommonFunction.GetStockHistoryInfo(stockNo);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (int.Parse(dt.Rows[i]["Volume"].ToString()) == 0)
                {
                    dt.Rows.RemoveAt(i);
                    i = 0;
                }
            }
            dt.DefaultView.Sort = " Date asc";
            dt = dt.DefaultView.ToTable();
            dt.Columns.Add("Date2", typeof(DateTime));
            foreach (DataRow dr in dt.Rows)
            {
                dr["Date2"] = DateTime.Parse(dr["Date"].ToString());
            }
            myPlot.Clear();
            List<double> listOpen = new List<double>();
            List<double> listLow = new List<double>();
            List<double> listHigh = new List<double>();
            List<double> listClose = new List<double>();
            ArrayList dates = new ArrayList();
            ArrayList closes = new ArrayList();
            List<string> listText = new List<string>();
            List<int> listCount = new List<int>();
            int n = 0;
            foreach (DataRow dr in dt.Rows)
            {
                n++;
                listCount.Add(n);
                //if (n == 24) break;
                listOpen.Add(double.Parse(dr["Open"].ToString()));
                dates.Add(DateTime.Parse(dr["Date"].ToString()));
                listHigh.Add(double.Parse(dr["High"].ToString()));
                listLow.Add(double.Parse(dr["Low"].ToString()));
                listClose.Add(double.Parse(dr["Adj Close"].ToString()));
                closes.Add(double.Parse(dr["Adj Close"].ToString()));
                listText.Add(Math.Round(double.Parse(dr["Adj Close"].ToString()), 2, MidpointRounding.AwayFromZero).ToString());
            }
            ////////网格//////////
            Grid mygrid = new Grid();
            myPlot.Add(mygrid);
            ///////蜡烛图///////////
            CandlePlot cp = new CandlePlot();
            cp.DataSource = dt;
            cp.AbscissaData = "Date2";
            cp.OpenData = "Open";
            cp.LowData = "Low";
            cp.HighData = "High";
            cp.CloseData = "Adj Close";
            cp.BullishColor = Color.Red;
            cp.BearishColor = Color.Green;
            cp.Centered = false;
            //cp.StickWidth = 3;
            //cp.Color = Color.DarkBlue;
            myPlot.Add(cp);
            LabelPointPlot lp = new LabelPointPlot();
            lp.AbscissaData = dates;
            lp.OrdinateData = listHigh.ToArray();
            lp.TextData = listText.ToArray();
            lp.LabelTextPosition = LabelPointPlot.LabelPositions.Above;
            lp.Marker = new Marker(Marker.MarkerType.None, 10);
            myPlot.Add(lp);
            myPlot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.MouseWheelZoom());
            myPlot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.HorizontalDrag());
            myPlot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.VerticalDrag());
            myPlot.AddInteraction(new NPlot.Windows.PlotSurface2D.Interactions.AxisDrag(true));
            myPlot.Title = string.Format("Stcok {0}", stockNo);
            myPlot.XAxis1.Label = "Date / Time";
            myPlot.YAxis1.Label = "Price [$]";
            //myPlot.AddAxesConstraint(new AxesConstraint.AxisPosition(PlotSurface2D.XAxisPosition.Bottom, 100));
            //////画箭头//////////
            //ArrowItem a = new ArrowItem(new PointD(2016, 10), 0, "Arrow");
            //a.HeadOffset = 0;
            //a.ArrowColor = Color.Red;
            //a.TextColor = Color.Purple;
            //myPlot.Add(a);


            myPlot.Refresh();
        }
        /// <summary>
        /// 更新DataGrid的市场信息
        /// </summary>
        /// <param name="listUrlStock"></param>
        /// <param name="dgv"></param>
        /// <param name="stockNoColName"></param>
        /// <param name="priceColName"></param>
        /// <param name="updateTimeColName"></param>
        /// <param name="riseColName"></param>
        /// <param name="riseRateColName"></param>
        /// <param name="backTable"></param>
        public static void ShowDataGridViewMarket(List<M_UrlStock> listUrlStock,DataGridView dgv, string stockNoColName,string priceColName,string updateTimeColName,string riseColName,string riseRateColName,DataTable backTable )
        {
            if (dgv.Rows.Count == backTable.Rows.Count)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < backTable.Rows.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[stockNoColName].Value.ToString() == backTable.Rows[j]["StockNo"].ToString())
                        {
                            dgv.Rows[i].Cells[priceColName].Value = backTable.Rows[j][priceColName].ToString();
                            dgv.Rows[i].Cells[updateTimeColName].Value =
                                backTable.Rows[j][updateTimeColName].ToString();
                            M_UrlStock stock =
                                CommonFunction.Ger_M_UrlStockFromList(
                                    dgv.Rows[i].Cells[stockNoColName].Value.ToString(),
                                    listUrlStock);
                            decimal riseNum =
                                decimal.Parse(
                                    Math.Round(stock.Price - stock.YesterDayPrice, 2, MidpointRounding.AwayFromZero)
                                        .ToString());
                            decimal riseNumRate =
                                decimal.Parse(
                                    Math.Round((stock.Price - stock.YesterDayPrice) / stock.YesterDayPrice * 100, 2,
                                        MidpointRounding.AwayFromZero)
                                        .ToString());
                            if (Math.Abs(riseNumRate) > 50)
                            {
                                riseNumRate = 0;
                                riseNum = 0;
                            }
                            dgv.Rows[i].Cells[riseColName].Value = riseNum;
                            dgv.Rows[i].Cells[riseRateColName].Value = string.Format("{0}%", riseNumRate);
                            Color color;
                            if (riseNum >= 0)
                            {
                                color = Color.Red;
                            }
                            else
                                color = Color.Green;
                            dgv.Rows[i].Cells[riseColName].Style.ForeColor = color;
                            dgv.Rows[i].Cells[riseRateColName].Style.ForeColor = color;
                            dgv.Rows[i].Cells[priceColName].Style.ForeColor = color;
                        }
                    }
                }
            }
            else
            {
                dgv.DataSource = backTable;
            }
        }

    }
}
