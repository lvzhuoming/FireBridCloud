using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using Business;
using Model;

namespace FireBridCloud
{
    public partial class FrmStockExpect : Form
    {
        private DataGridView myDgv = null;
        private Dictionary<int, double> dicExpectPrice = new Dictionary<int, double>();
        public FrmStockExpect()
        {
            InitializeComponent();
            myDgv = commonDataGridView1.dgv_HoldStock;
            commonDataGridView1.dgv_HoldStock.CellMouseDown += dgv_ExpectStock_CellMouseDown;
            commonDataGridView1.dgv_HoldStock.CellDoubleClick += dgv_HoldStock_CellDoubleClick;
            
        }
        /// <summary>
        /// 候选池信息表
        /// </summary>
        private DataTable dt_expectStock = null;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string stockNo = txtStockNo.Text.Trim();
            M_UrlStock urlStock=CommonFunction.GetNowStockInfo(stockNo);
            if (ExpectStock.Exists(stockNo))
            {
                MessageBox.Show("此股票已存在！");
                return;
            }
            if (urlStock == null||string.IsNullOrEmpty(urlStock.StockNo)) return;
            M_ExpectStock expectStock = new M_ExpectStock();
            expectStock.StockNo = urlStock.StockNo;
            expectStock.StockName = urlStock.StockName;
            expectStock.Price = urlStock.Price;
            expectStock.ExpectPrice = double.Parse(numExpectPrice.Value.ToString());
            expectStock.UpdateTime = urlStock.UpdateTime;
            ExpectStock.Add(expectStock);
        }

        private void FrmStockExpect_Load(object sender, EventArgs e)
        {
            commonDataGridView1.dgv_HoldStock.DataSource = ExpectStock.GetList(" 1=1 order by OrderIndex").Tables[0];
            myDgv.ReadOnly = false;
            for (int i = 0; i < myDgv.ColumnCount; i++)
            {
                if (myDgv.Columns[i].Name != "ExpectPrice")
                {
                    myDgv.Columns[i].ReadOnly = true;
                }
            }
            myDgv.CellValueChanged += ChangeExpectPrice;
            BwExpectStock.SetHoldStockInfo = UpdateHoldStockInfo;
            BwExpectStock.OnStart();
        }

        /// <summary>
        /// 期望值改变后事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeExpectPrice(object sender,DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0&&myDgv.Columns[e.ColumnIndex].Name=="ExpectPrice")
            {
                int id = int.Parse(myDgv.Rows[e.RowIndex].Cells["ID"].Value.ToString());
                double expectPrice = double.Parse(myDgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                if (dicExpectPrice.ContainsKey(id))
                    dicExpectPrice[id] = expectPrice;
                else
                    dicExpectPrice.Add(id, expectPrice);
            }
        }
        /// <summary>
        /// 更新股票价格信息
        /// </summary>
        private void UpdateHoldStockInfo()
        {
            try
            {
                DataTable dt = GetStockHold();
                List<string> listStockNo = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    listStockNo.Add(dr["StockNo"].ToString());
                }
                List<M_UrlStock> listUrlStock = CommonFunction.GetNowStockInfoList(listStockNo);
                RefreshExpectData(listUrlStock);
                Invoke(new MethodInvoker(delegate()
                {
                    dt_expectStock=GetStockHold();
                    AddRiseColumn();
                    UpdatePrice(listUrlStock);
                }));
            }
            catch (Exception)
            {   
              return;
            }
        }
        /// <summary>
        /// 把从网络上获取的股票价格信息更新到后台数据库
        /// </summary>
        /// <param name="listUrlStock"></param>
        private void RefreshExpectData(List<M_UrlStock> listUrlStock)
        {
            foreach (M_UrlStock stock in listUrlStock)
            {
                M_ExpectStock mExpectStock = null;
                string stockNo = stock.StockNo;
                string strWhere = string.Format("{0}='{1}'", "StockNo", stockNo);
                DataTable dt = ExpectStock.GetList(1, strWhere, "StockNo").Tables[0];
                if (dt.Rows.Count != 0)
                {
                    int id = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                    mExpectStock = ExpectStock.GetModel(id);
                    mExpectStock.Price = stock.Price;
                    mExpectStock.UpdateTime = stock.UpdateTime;
                    ExpectStock.Update(mExpectStock);
                }
            }
        }
       
        /// <summary>
        /// 获取持仓信息
        /// </summary>
        private DataTable GetStockHold()
        {
             return  ExpectStock.GetList(" 1=1 order by OrderIndex").Tables[0];
        }
        /// <summary>
        /// 窗体关闭前停止线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStockExpect_FormClosing(object sender, FormClosingEventArgs e)
        {
            BwExpectStock.Onstop();
        }

        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(commonDataGridView1.dgv_HoldStock.CurrentRow.Cells["ID"].Value.ToString());
            ExpectStock.Delete(id);
            dt_expectStock=GetStockHold();
        }
        /// <summary>
        /// datagridview右击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_ExpectStock_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    //若行已是选中状态就不再进行设置
                    if (commonDataGridView1.dgv_HoldStock.Rows[e.RowIndex].Selected == false)
                    {
                        commonDataGridView1.dgv_HoldStock.ClearSelection();
                        commonDataGridView1.dgv_HoldStock.Rows[e.RowIndex].Selected = true;
                    }
                    //只选中一行时设置活动单元格
                    if (commonDataGridView1.dgv_HoldStock.SelectedRows.Count == 1)
                    {
                        commonDataGridView1.dgv_HoldStock.CurrentCell = commonDataGridView1.dgv_HoldStock.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //弹出操作菜单
                    MenuStripForExpectStock.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }
        /// <summary>
        /// 更新DataGridView价格
        /// </summary>
        /// <param name="listUrlStock"></param>
        private void UpdatePrice(List<M_UrlStock> listUrlStock)
        {
            CommonFunction.ShowDataGridViewMarket(listUrlStock, commonDataGridView1.dgv_HoldStock, "StockNo", "Price",
                "UpdateTime", "colRise", "colRiseRate", dt_expectStock);
            DataGridView dgv_HoldStock = commonDataGridView1.dgv_HoldStock;
            if (dgv_HoldStock.Rows.Count == dt_expectStock.Rows.Count)
            {
                for (int i = 0; i < dgv_HoldStock.Rows.Count; i++)
                {
                    //如果股价低于期望值，则改变期望值的颜色
                    double nowPrice = double.Parse(dgv_HoldStock.Rows[i].Cells["Price"].Value.ToString());
                    double expectPrice = double.Parse(dgv_HoldStock.Rows[i].Cells["ExpectPrice"].Value.ToString());
                    if (nowPrice <= expectPrice&&expectPrice>0)
                    {
                        dgv_HoldStock.Rows[i].Cells["ExpectPrice"].Style.ForeColor = Color.Purple;
                        dgv_HoldStock.Rows[i].Cells["ExpectPrice"].Style.BackColor = Color.Orange;
                    }
                    else
                    {
                        dgv_HoldStock.Rows[i].Cells["ExpectPrice"].Style.ForeColor = dgv_HoldStock.Rows[i].Cells["StockNo"].Style.ForeColor;
                        dgv_HoldStock.Rows[i].Cells["ExpectPrice"].Style.BackColor = dgv_HoldStock.Rows[i].Cells["StockNo"].Style.BackColor;
                    }

                }
            }
        }
        /// <summary>
        /// 增加涨跌列
        /// </summary>
        private void AddRiseColumn()
        {
            DataGridViewColumn dgvcRise = new DataGridViewTextBoxColumn();
            dgvcRise.Name = "colRise";
            dgvcRise.HeaderText = "涨跌";
            dgvcRise.ReadOnly = true;
            DataGridView dgv_HoldStock = commonDataGridView1.dgv_HoldStock;
            if (!dgv_HoldStock.Columns.Contains(dgv_HoldStock.Columns["colRise"]))
            {
                dgv_HoldStock.Columns.Insert(dgv_HoldStock.Columns["Price"].Index + 1, dgvcRise);
            }
            DataGridViewColumn dgvcRiseRate = new DataGridViewTextBoxColumn();
            dgvcRiseRate.Name = "colRiseRate";
            dgvcRiseRate.HeaderText = "涨跌率";
            dgvcRiseRate.ReadOnly = true;
            if (!dgv_HoldStock.Columns.Contains(dgv_HoldStock.Columns["colRiseRate"]))
            {
                dgv_HoldStock.Columns.Insert(dgv_HoldStock.Columns["colRise"].Index + 1, dgvcRiseRate);
            }
        }

        /// <summary>
        /// 查看分时图，K线图功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_HoldStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (commonDataGridView1.dgv_HoldStock.CurrentRow == null) return;
            string stockNo = commonDataGridView1.dgv_HoldStock.CurrentRow.Cells["StockNo"].Value.ToString();
            FrmStockChart frm = new FrmStockChart(stockNo);
            frm.ShowDialog();
        }
        /// <summary>
        /// 地量地价分析法按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LowPriceLowVol_Click(object sender, EventArgs e)
        {
            DataTable dt=CommonFunction.GetStockHistoryInfo("601555");
            dt.DefaultView.Sort = "Date asc";
            List<string> listDate = new List<string>();
            //100天地量
            int n = 100;
            int count = 0;
            int vol = 0;//成交量
            int volMin = int.MaxValue;//最小成交量
            if (dt.Rows.Count < 100) return;
            for (int i = 100; i < dt.Rows.Count; i++)
            {
                vol = int.Parse(dt.Rows[i]["Volume"].ToString());
                if (vol == 0) continue;
                bool isLowest = true;
                for (int j = i; j < i-100; j--)
                {
                    int volCompare = int.Parse(dt.Rows[j]["Volume"].ToString());
                    if (int.Parse(dt.Rows[j]["Volume"].ToString()) < vol)
                    {
                        isLowest = false;
                        break;
                    }
                }
                if (isLowest)
                    listDate.Add(dt.Rows[i]["Date"].ToString());
            }

        }

        /// <summary>
        /// 置顶操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemToTop_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(commonDataGridView1.dgv_HoldStock.CurrentRow.Cells["ID"].Value.ToString());
            M_ExpectStock model = ExpectStock.GetModel(id);
            model.OrderIndex = 1;
            DataTable dt = ExpectStock.GetList("1=1 order by OrderIndex").Tables[0];
            int i = 1;
            foreach (DataRow dr in dt.Rows)
            {
                i++;
                M_ExpectStock modelUpdate = ExpectStock.DataRowToModel(dr);
                if (!modelUpdate.StockName.Equals(model.StockName, StringComparison.CurrentCultureIgnoreCase))
                {
                    modelUpdate.OrderIndex = i;
                    ExpectStock.Update(modelUpdate);
                }

            }
            ExpectStock.Update(model);
            dt_expectStock = GetStockHold();
            commonDataGridView1.dgv_HoldStock.DataSource = dt_expectStock;
            //ExpectStock.Delete(id);
            //dt_expectStock = GetStockHold();
        }

        private void btnSaveExpectPrice_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<int, double> keyvalue in dicExpectPrice)
            {
                M_ExpectStock saveExpect = ExpectStock.GetModel(keyvalue.Key);
                saveExpect.ExpectPrice = keyvalue.Value;
                ExpectStock.Update(saveExpect);
            }
            //MessageBox.Show("保存成功");
            dicExpectPrice.Clear();
        }

        private void btnBeTop_Click(object sender, EventArgs e)
        {
            string top = "桌面顶端";
            string notTop = "非桌面顶端";
            if (btnBeTop.Text == top)
            {
                this.TopMost = true;
                btnBeTop.Text = notTop;
            }
            else
            {
                this.TopMost = false;
                btnBeTop.Text = top;
            }
        }
    }
}
