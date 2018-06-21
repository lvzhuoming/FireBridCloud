using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using BeatTheMoneyFundByBandStock;
using DBUtility;
using Business;
using ChineseCalender;
using FanG;
using Model;
using NPOI.SS.UserModel;
using Utility;

namespace FireBridCloud
{
    /// <summary>
    /// 主界面
    /// </summary>
    public partial class FrmMain : DevComponents.DotNetBar.Office2007Form
    {
        #region 变量
        /// <summary>
        /// 持仓参考值
        /// </summary>
        private double d_holdrate;
        /// <summary>
        /// 信用资产加本人资产的值
        /// </summary>
        private double d_Asset;
        /// <summary>
        /// 持仓信息表
        /// </summary>
        private DataTable dt_holdstock = null;
        /// <summary>
        /// 右下角托盘
        /// </summary>
        private NotifyIcon notify = new NotifyIcon();
        /// <summary>
        /// 右下角托盘菜单
        /// </summary>
        private ContextMenuStrip menuStripForNotify = new ContextMenuStrip();
        /// <summary>
        /// 必须退出标记
        /// </summary>
        private bool mustExit = false;
        #endregion

        public FrmMain()
        {
            InitializeComponent();
            BwMain.SetInternetStaus = SetInternet;
            BwMain.SetHoldStockInfo = UpdateHoldStockInfo;
            BwMain.UpateMarket =UpdateMarketInfo;
            BwMain.OnStart();
        }

        #region 事件 
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!mustExit)
            {
                // 取消关闭窗体
                e.Cancel = true;
                // 将窗体变为最小化
                this.WindowState = FormWindowState.Minimized;
            }
        }
        /// <summary>
        /// 持仓参考设置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetHoldRate_Click(object sender, EventArgs e)
        {
            FrmSetHoldingRate frmSet = new FrmSetHoldingRate();
            frmSet.SetHoldRef += GetHoldRef;
            frmSet.ShowDialog();
        }
        /// <summary>
        /// 数据库路径设置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDbSet_Click(object sender, EventArgs e)
        {
            FileDialog filedialog = new OpenFileDialog();
            filedialog.InitialDirectory = System.Environment.CurrentDirectory;
            filedialog.Filter = "mdb文件|*.mdb";
            filedialog.ShowDialog();
            if (File.Exists(filedialog.FileName))
            {
                DBUtility.DbHelperOleDb.connectionString = filedialog.FileName;
                //修改XML数据库配置的值
                XmlHelper.Initial(CommonConstString.STR_ConfigPath);
                XmlHelper.Replace(CommonConstString.STR_ConfigNode, filedialog.FileName);
                XmlHelper.Save();
            }
            GetAssetRef();
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            SetNotify();
            SetNotifyMenuStrip();
            GetHoldRef();
            GetAsset();
            GetAssetRef();
            GetStockHold();

            //设置DataGridView隔行变色
            dgv_HoldStock.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv_HoldStock.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            dgv_HoldStock.DataSource = dt_holdstock;
            //提示上下买入卖出价格用距离
            SetTip();
            SetChart(dt_holdstock);


            BwRemarkRemind.ShowRiseForm = ChineseCalender.CommonFunction.ShowRiseMethod;
            BwRemarkRemind.fatherForm = this;
            BwRemarkRemind.OnStart();
        }
        /// <summary>
        /// 根据表格的数据设置图形
        /// </summary>
        /// <param name="dt"></param>
        private void SetChart(DataTable dt)
        {
            ArrayList xTitle = new ArrayList();
            ArrayList[] chartData = new ArrayList[1];
            chartData[0] = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                xTitle.Add(dr["StockName"].ToString());
                double price, holdAmount;
                double.TryParse(dr["Price"].ToString(), out price);
                double.TryParse(dr["HoldAmount"].ToString(), out holdAmount);
                chartData[0].Add(price*holdAmount);
            }
            //this.chartlet1.AppearanceStyle = (FanG.Chartlet.AppearanceStyles)System.Enum.Parse(typeof(FanG.Chartlet.AppearanceStyles), styleimg, true);
            this.chartlet1.AppearanceStyle = Chartlet.AppearanceStyles.Pie_2D_Aurora_NoCrystal_NoGlow_NoBorder ;
            //this.chartlet1.AppearanceStyle = Chartlet.AppearanceStyles.Pie_3D_StarryNight_NoCrystal_NoGlow_NoBorder;
            this.chartlet1.ChartTitle.Text = string.Empty;
            //this.chartlet1.ChartTitle.Text = string.Format("{0}历年净利润", companyName);
            //this.chartlet1.XLabels.UnitText = "年份";
            //this.chartlet1.YLabels.UnitText = "净利润";
            //this.chartlet1.BaseLineX = 0;
            this.chartlet1.InitializeData(chartData, xTitle, null);
        }

        /// <summary>
        /// 资产设置按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetAsset_Click(object sender, EventArgs e)
        {
            FrmSetAsset frmSet = new FrmSetAsset();
            frmSet.SetAsset += GetAsset;
            frmSet.ShowDialog();
            GetAssetRef();
        }
        /// <summary>
        /// 增加持仓股票信息按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtHoldAdd_Click(object sender, EventArgs e)
        {
            FrmStockHoldAdd frmHoldAdd = new FrmStockHoldAdd();
            frmHoldAdd.SetHold += GetStockHold;
            frmHoldAdd.ShowDialog(); 
            dgv_HoldStock.DataSource = dt_holdstock;
        }
        /// <summary>
        /// 右下角托盘退出程序按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Exit(object sender, EventArgs e)
        {
            mustExit = true;
            Close();
            notify.Visible = false;
        }
        /// <summary>
        /// 窗体大小变动事件，用于托盘
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
                notify.Visible = true;
            }
            this.chartlet1.Refresh();
            //else
            //{
            //    notify.Visible = false;
            //}
        }
        /// <summary>
        /// 右下角托盘双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notify_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Visible = true;
                WindowState = FormWindowState.Normal;
            }
            else
            {
                Visible = false;
                WindowState = FormWindowState.Minimized ;
            }
        }
        /// <summary>
        /// datagridview右击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_HoldStock_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (dgv_HoldStock.Rows[e.RowIndex].Selected == false)
                    {
                        dgv_HoldStock.ClearSelection();
                        dgv_HoldStock.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (dgv_HoldStock.SelectedRows.Count == 1)
                    {
                        dgv_HoldStock.CurrentCell = dgv_HoldStock.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    MenuStripForHoldStock.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        /// <summary>
        /// 查看分时图，K线图功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_HoldStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_HoldStock.CurrentRow == null) return;
            string stockNo = dgv_HoldStock.CurrentRow.Cells["StockNo"].Value.ToString();
            FrmStockChart frm = new FrmStockChart(stockNo);
            frm.ShowDialog();
        }

        /// <summary>
        /// 删除持仓股票
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeletHoldStockItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgv_HoldStock.CurrentRow.Cells["ID"].Value.ToString());
            HoldStock.Delete(id);
            GetStockHold();
        }
        /// <summary>
        /// 停止后台操作按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStockBw_Click(object sender, EventArgs e)
        {
            if (btnStockBw.Text == "断开后台线程")
            {
                btnStockBw.Text = "打开后台线程";
                BwMain.Onstop();
                SetInternet("offline");
            }
            else
            {
                btnStockBw.Text = "断开后台线程";
                BwMain.OnStart();
            }


        }
        /// <summary>
        /// 波动性分析按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWave_Click(object sender, EventArgs e)
        {
            FrmWave frm = new FrmWave();
            frm.ShowDialog();
        }
        /// <summary>
        /// 股票持仓信息修改事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ModifyHoldStock(object sender, EventArgs e)
        {
            FrmStockHoldAdd frmHoldAdd = new FrmStockHoldAdd();
            frmHoldAdd.AddFlag = false;
            frmHoldAdd.modifyId = Convert.ToInt32(dgv_HoldStock.SelectedRows[0].Cells["ID"].Value.ToString());
            frmHoldAdd.SetHold += GetStockHold;
            frmHoldAdd.ShowDialog();
            dgv_HoldStock.DataSource = dt_holdstock;
        }

        /// <summary>
        /// 展示策略模型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowStrategy(object sender, EventArgs e)
        {
            string stockNo = dgv_HoldStock.SelectedRows[0].Cells["StockNo"].Value.ToString();
            string stockName = dgv_HoldStock.SelectedRows[0].Cells["StockName"].Value.ToString();
            //this.WindowState = FormWindowState.Minimized;//最小化
            FrmStrategy frm = new FrmStrategy();
            frm.StockNo = stockNo;
            frm.StockName = stockName;
            frm.ShowDialog();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 获取持仓参考的值
        /// </summary>
        private void GetHoldRef()
        {
            M_HoldRule mhr = new M_HoldRule();
            DataTable dt = HoldRule.GetList("1=1 order by UpdateTime desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                mhr = HoldRule.DataRowToModel(dt.Rows[0]);
                //公式：参考持仓比率=（1-（现值-最低值）/(最高值-最低值））*%100;
                double holdRef = (1 - (mhr.NowPrice - mhr.LowPrice)/(mhr.HightPrice - mhr.LowPrice))*100;
                d_holdrate = holdRef/100;
                string strHoldRef = Math.Round(holdRef, 2) + "%";
                txtHoldRef.Text = strHoldRef;
            }
        }
        /// <summary>
        /// 获取资产值
        /// </summary>
        private void GetAsset()
        {
            M_Asset mas = new M_Asset();
            DataTable dt = Asset.GetList("1=1 order by UpdateTime desc").Tables[0];
            if (dt.Rows.Count > 0)
            {
                mas = Asset.DataRowToModel(dt.Rows[0]);
                d_Asset = (mas.Personal + mas.Credit);
                txtAsset.Text = (mas.Personal + mas.Credit).ToString();
            }
        }
        /// <summary>
        /// 获取持仓资产参考
        /// </summary>
        private void GetAssetRef()
        {
            txtAssetRef.Text = Math.Round((d_Asset*d_holdrate), 2).ToString();
        }
        /// <summary>
        /// 获取持仓信息
        /// </summary>
        private void GetStockHold()
        {
            dt_holdstock = HoldStock.GetList("").Tables[0];
            double sumHoldAmount = 0;
            if (dt_holdstock != null && dt_holdstock.Rows.Count > 0)
            {

                for (int i = 0; i < dt_holdstock.Rows.Count; i++)
                {
                    double holdAmount = Convert.ToDouble(dt_holdstock.Rows[i]["HoldAmount"].ToString());
                    double price = Convert.ToDouble(dt_holdstock.Rows[i]["Price"].ToString());
                    sumHoldAmount += holdAmount*price;
                }
            }
            txtHoldAsset.Text = Math.Round(sumHoldAmount, 2).ToString();
            txtRemainAsset.Text = (Convert.ToDouble(txtAssetRef.Text) - Convert.ToDouble(txtHoldAsset.Text)).ToString();
            SetTip();
        }
        /// <summary>
        /// 更新股票价格信息
        /// </summary>
        private void UpdateHoldStockInfo()
        {
            try
            {
                DataTable dt = HoldStock.GetList("").Tables[0];
                List<string> listStockNo = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    listStockNo.Add(dr["StockNo"].ToString());
                }
                List<M_UrlStock> listUrlStock = CommonFunction.GetNowStockInfoList(listStockNo);
                RefreshHoldData(listUrlStock);
                Invoke(new MethodInvoker(delegate()
                {
                    GetStockHold();
                    AddRiseColumn();
                    UpdatePrice(listUrlStock);
                    UpdateDailyEarn();
                }));
            }
            catch
            {
                return;
            }
        }
        /// <summary>
        /// 更新显示日涨跌数据
        /// </summary>
        private void UpdateDailyEarn()
        {
            //显示是涨跌数据
            double dayRise = 0;
            foreach (DataGridViewRow dr in dgv_HoldStock.Rows)
            {
                if (!dgv_HoldStock.Columns.Contains("colRise")) break;
                dayRise += int.Parse(dr.Cells["HoldAmount"].Value.ToString()) * double.Parse(dr.Cells["colRise"].Value.ToString());
            }
            if (dayRise > 0) label6.ForeColor = Color.Red;
            else label6.ForeColor = Color.Green;
            label6.Text = dayRise.ToString();
        }
        /// <summary>
        /// 后台更新网络连接状态
        /// </summary>
        /// <param name="strStaus"></param>
        private void SetInternet(string strStaus)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                if (strStaus == "offline")
                    tsOnline.ForeColor = Color.Red;
                else
                    tsOnline.ForeColor = Color.Green;
            }));
            tsOnline.Text = strStaus;

        }
        /// <summary>
        /// 更新大盘指数信息;
        /// </summary>
        private void UpdateMarketInfo()
        {
            List<string> listStockNo = new List<string>() { CommonConstString.ShangHang, CommonConstString.ShenZhen, CommonConstString.ChuangYeBan };
            //string urlinfo=CommonFunction.GetUrlStockContent(listStockNo);
            List<M_UrlStock> listStock= CommonFunction.GetNowStockInfoList(listStockNo);
            if (listStock.Count == 3)
            {
                double shRate =
                    Math.Round((listStock[0].Price - listStock[0].YesterDayPrice)/listStock[0].YesterDayPrice*100, 2,
                        MidpointRounding.AwayFromZero);
                tssSH.Text = string.Format("{0} {1} %{2}", listStock[0].StockName, listStock[0].Price, shRate);
                double szRate =
                    Math.Round((listStock[1].Price - listStock[1].YesterDayPrice)/listStock[1].YesterDayPrice*100, 2,
                        MidpointRounding.AwayFromZero);
                tssSZ.Text = string.Format("{0} {1} %{2}", listStock[1].StockName, listStock[1].Price, szRate);
                double cybRate =
                    Math.Round((listStock[2].Price - listStock[2].YesterDayPrice)/listStock[2].YesterDayPrice*100, 2,
                        MidpointRounding.AwayFromZero);
                tssCYB.Text = string.Format("{0} {1} %{2}", listStock[2].StockName, listStock[2].Price, cybRate);
                this.Invoke(new MethodInvoker(delegate()
                {
                    if (shRate > 0)
                        tssSH.ForeColor = Color.Red;
                    else
                        tssSH.ForeColor = Color.Green;
                    if (szRate > 0)
                        tssSZ.ForeColor = Color.Red;
                    else
                        tssSZ.ForeColor = Color.Green;
                    if (cybRate > 0)
                        tssCYB.ForeColor = Color.Red;
                    else
                        tssCYB.ForeColor = Color.Green;
                }));

            }
        }
        /// <summary>
        /// 把从网络上获取的股票价格信息更新到后台数据库
        /// </summary>
        /// <param name="listUrlStock"></param>
        private void RefreshHoldData(List<M_UrlStock> listUrlStock)
        {
            foreach (M_UrlStock stock in listUrlStock)
            {
                M_HoldStock mHoldStock = null;
                string stockNo = stock.StockNo;
                string strWhere = string.Format("{0}='{1}'", "StockNo", stockNo);
                DataTable dt = HoldStock.GetList(1, strWhere, "StockNo").Tables[0];
                if (dt.Rows.Count != 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    mHoldStock = HoldStock.GetModel(id);
                    mHoldStock.Price = stock.Price;
                    mHoldStock.UpdateTime = stock.UpdateTime;
                    HoldStock.Update(mHoldStock);
                }
            }
        }
        /// <summary>
        /// 设置右下角托盘
        /// </summary>
        private void SetNotify()
        {
            notify.Visible = true;
            notify.Text = "FireBridClould";
            Bitmap bmp = new Bitmap(CommonConstString.imagePath + "FireBridCloud.jpg");
            IntPtr hIcon = bmp.GetHicon();
            Icon icon = Icon.FromHandle(hIcon);
            notify.Icon = icon;
            notify.MouseDoubleClick += new MouseEventHandler(notify_MouseDoubleClick);
            notify.ContextMenuStrip = menuStripForNotify;
        }
        /// <summary>
        /// 设置右下角托盘菜单
        /// </summary>
        private void SetNotifyMenuStrip()
        {
            ToolStripMenuItem item = new ToolStripMenuItem();
            item.Name = "notifyMenuStrip";
            item.Size = new Size(100, 22);
            item.Text = "退出";
            item.Click += new System.EventHandler(Exit);
            menuStripForNotify.Items.Add(item);
        }
        /// <summary>
        ///提示上下买入卖出价格用距离
        /// </summary>
        private void SetTip()
        {
            foreach (DataGridViewRow dgvr in dgv_HoldStock.Rows)
            {
                string tipText = string.Empty;
                string stockNo = dgvr.Cells["StockNo"].Value.ToString();
                double salePrice = CommonFunction.GetHoldStockSalePrice(stockNo);
                double saleNearPrecent = Math.Round((salePrice / (Convert.ToDouble(dgvr.Cells["Price"].Value.ToString())) - 1) * 100, 2, MidpointRounding.AwayFromZero);
                double buyPrice = CommonFunction.GetHoldStockBuyPrice(stockNo);
                double buyNearPrecent = Math.Round((buyPrice / (Convert.ToDouble(dgvr.Cells["Price"].Value.ToString())) - 1) * 100, 2, MidpointRounding.AwayFromZero);
                tipText = "SaleTip：" + (char)13 + salePrice + " %" + saleNearPrecent;
                tipText += (char)13 + "BuyTip:" + (char)13 + buyPrice + " %" + buyNearPrecent;
                foreach (DataGridViewCell cell in dgvr.Cells)
                {
                    cell.ToolTipText = tipText;
                }
            }
        }
        #endregion

        private void tssSH_Click(object sender, EventArgs e)
        {
            FrmStockChart frm = new FrmStockChart(CommonConstString.ShangHang);
            frm.ShowDialog();
        }

        private void tssSZ_Click(object sender, EventArgs e)
        {
            FrmStockChart frm = new FrmStockChart(CommonConstString.ShenZhen);
            frm.ShowDialog();
        }

        private void tssCYB_Click(object sender, EventArgs e)
        {
            FrmStockChart frm = new FrmStockChart(CommonConstString.ChuangYeBan);
            frm.ShowDialog();
        }

        private void btnExpectStock_Click(object sender, EventArgs e)
        {
            FrmStockExpect frm = new FrmStockExpect();
            frm.Show();
        }
        /// <summary>
        /// 更新DataGridView显示的股价
        /// </summary>
        /// <param name="listUrlStock"></param>
        private void UpdatePrice(List<M_UrlStock> listUrlStock)
        {
            CommonFunction.ShowDataGridViewMarket(listUrlStock, dgv_HoldStock, "StockNo", "Price", "UpdateTime",
                "colRise", "colRiseRate", dt_holdstock);
        }
        /// <summary>
        /// 增加涨跌列
        /// </summary>
        private void AddRiseColumn()
        {
            DataGridViewColumn dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "colRise";
            dgvc.HeaderText = "涨跌";
            if (!dgv_HoldStock.Columns.Contains(dgv_HoldStock.Columns["colRise"]))
            {
                dgv_HoldStock.Columns.Insert(dgv_HoldStock.Columns["Price"].Index + 1, dgvc);
            }
            dgvc = new DataGridViewTextBoxColumn();
            dgvc.Name = "colRiseRate";
            dgvc.HeaderText = "涨跌率";
            if (!dgv_HoldStock.Columns.Contains(dgv_HoldStock.Columns["colRiseRate"]))
            {
                dgv_HoldStock.Columns.Insert(dgv_HoldStock.Columns["colRise"].Index + 1, dgvc);
            }
        }

        //private void btnSetAsset_Paint(object sender, PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    Graphics g = e.Graphics;
        //    g.DrawEllipse(Pens.Red, 10, 10, 10, 10);
        //    //g.Dispose();
        //}

        private void MenuItemKLineChart_Click(object sender, EventArgs e)
        {

            string stockNo=dgv_HoldStock.SelectedRows[0].Cells["StockNo"].Value.ToString();
            string stockName = dgv_HoldStock.SelectedRows[0].Cells["StockName"].Value.ToString();
            DataTable dt = CommonFunction.GetStockHistoryInfo(stockNo);
            FrmKLine frm = new FrmKLine();
            frm.kLineControl1.dtMain = dt;
            frm.kLineControl1.stockNo = stockNo;
            frm.kLineControl1.stockName = stockName;
            frm.kLineControl1.Init();
            frm.ShowDialog();

        }

        private void btnValueInvest_Click(object sender, EventArgs e)
        {
            FrmValueInvestment frm = new FrmValueInvestment();
            frm.Show();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            int InitNo = 600000;
            List<M_UrlStock> listStock = new List<M_UrlStock>();
            while (InitNo <610000)
            {
                M_UrlStock stock = CommonFunction.GetNowStockInfo(InitNo.ToString());
                if (stock != null&&!string.IsNullOrEmpty(stock.StockName))
                    listStock.Add(stock);
                InitNo++;
            }
            InitNo = 0;
            while (InitNo < 10000)
            {
                M_UrlStock stock = CommonFunction.GetNowStockInfo(string.Format("00{0}", InitNo.ToString()));
                if (stock != null && !string.IsNullOrEmpty(stock.StockName))
                    listStock.Add(stock);
                InitNo++;
            }
            InitNo = 300000;
            while (InitNo < 310000)
            {
                M_UrlStock stock = CommonFunction.GetNowStockInfo(InitNo.ToString());
                if (stock != null && !string.IsNullOrEmpty(stock.StockName))
                    listStock.Add(stock);
                InitNo++;
            }
            //MessageBox.Show("共找到上证股票数" + listStock.Count + "只");
            SqliteDBUtility.DbHelperSQLite.ExecuteSql("delete from StockInfo");
            foreach (var item in listStock)
            {
                string insertSql = string.Format("insert into StockInfo (StockNo,StockName) values ('{0}','{1}')",
                    item.StockNo, item.StockName);
                SqliteDBUtility.DbHelperSQLite.ExecuteSql(insertSql);
            }


        }

        private void btnNotice_Click(object sender, EventArgs e)
        {
            Calender frm = new Calender();
            frm.Show( );
        }

    }
}
