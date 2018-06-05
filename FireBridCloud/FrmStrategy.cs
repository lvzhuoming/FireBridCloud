using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using Model;

namespace FireBridCloud
{
    public partial class FrmStrategy : Form
    {
        public string StockName=string.Empty;
        public string StockNo = string.Empty;
        public double Price = 0.00;
        private double genreratePrecent = 0.95;
        public FrmStrategy()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btngenrerate_Click(object sender, EventArgs e)
        {
           
            if (!double.TryParse(txtPrecent.Text, out genreratePrecent))
                MessageBox.Show("百分比不对");
            genreratePrecent = 1 - genreratePrecent/100;

            if (string.IsNullOrEmpty(StockName) || string.IsNullOrEmpty(StockNo) || string.IsNullOrEmpty(txtBasePoint.Text.Trim()) || string.IsNullOrEmpty(txtBaseAmount.Text.Trim()))
                return;
            double basePoint = Convert.ToDouble(txtBasePoint.Text);
            double baseAmount = Convert.ToDouble(txtBaseAmount.Text);
            double lowPoint = basePoint * Math.Pow(genreratePrecent, 5);
            dgvStrategy.Rows.Clear();
            for(int i=0;i<10;i++)
            {
                DataGridViewRow dgvr = new DataGridViewRow();
                DataGridViewTextBoxCell cellStockNo = new DataGridViewTextBoxCell();
                cellStockNo.Value = StockNo;
                dgvr.Cells.Add(cellStockNo);
                DataGridViewTextBoxCell cellStockName = new DataGridViewTextBoxCell();
                cellStockName.Value = StockName;
                dgvr.Cells.Add(cellStockName);
                DataGridViewTextBoxCell cellPrice = new DataGridViewTextBoxCell();
                cellPrice.Value = Math.Round(lowPoint * Math.Pow(1 / genreratePrecent, i + 1), 2, MidpointRounding.AwayFromZero);
                dgvr.Cells.Add(cellPrice);
                DataGridViewTextBoxCell cellAmount = new DataGridViewTextBoxCell();
                cellAmount.Value = baseAmount;
                dgvr.Cells.Add(cellAmount);
                DataGridViewCheckBoxCell cellHolgFlag = new DataGridViewCheckBoxCell();
                cellHolgFlag.Value = false;
                dgvr.Cells.Add(cellHolgFlag);
                DataGridViewCheckBoxCell cellBaseFlag = new DataGridViewCheckBoxCell();
                cellBaseFlag.Value = false;
                dgvr.Cells.Add(cellBaseFlag);
                dgvStrategy.Rows.Add(dgvr);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //先删除数据库中的记录再保存
            Strategy.Delete(StockNo);
            foreach (DataGridViewRow dgvr in dgvStrategy.Rows)
            {
                MStrategy model = new MStrategy();
                model.StockNo = StockNo;
                model.StockName = StockName;
                model.Price = double.Parse(dgvr.Cells["colStockPrice"].Value.ToString());
                model.Amount = int.Parse(dgvr.Cells["colAmount"].Value.ToString());
                model.HoldFlag = bool.Parse(dgvr.Cells["colHoldFlag"].Value.ToString());
                   //var abc= ((DataGridViewCheckBoxCell)dgvr.Cells["colHoldFlag"]).Value;
                model.BasePoint = bool.Parse(dgvr.Cells["colBaseFlag"].Value.ToString());
                Strategy.Add(model);
            }
            MessageBox.Show("保存成功");
        }

        private void FrmStrategy_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// 清空策略
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtClear_Click(object sender, EventArgs e)
        {
            Strategy.Delete(StockNo);
            btngenrerate.Enabled = true;
            txtBaseAmount.Enabled = true;
            txtBasePoint.Enabled = true;
            LoadData();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            dgvStrategy.Rows.Clear();
            if (!string.IsNullOrEmpty(StockNo))
            {
                DataTable dt = Strategy.GetList(string.Format(" StockNo='{0}'", StockNo)).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    if (bool.Parse(dr["BasePoint"].ToString()))
                    {
                        btngenrerate.Enabled = false;
                        txtBaseAmount.Enabled = false;
                        txtBasePoint.Enabled = false;
                    }
                }
                foreach (DataRow dr in dt.Rows)
                {
                    DataGridViewRow dgvr = new DataGridViewRow();
                    DataGridViewTextBoxCell cellStockNo = new DataGridViewTextBoxCell();
                    cellStockNo.Value = dr["StockNo"];
                    dgvr.Cells.Add(cellStockNo);
                    DataGridViewTextBoxCell cellStockName = new DataGridViewTextBoxCell();
                    cellStockName.Value = dr["StockName"];
                    dgvr.Cells.Add(cellStockName);
                    DataGridViewTextBoxCell cellPrice = new DataGridViewTextBoxCell();
                    cellPrice.Value = dr["Price"];
                    dgvr.Cells.Add(cellPrice);
                    DataGridViewTextBoxCell cellAmount = new DataGridViewTextBoxCell();
                    cellAmount.Value = dr["Amount"]; ;
                    dgvr.Cells.Add(cellAmount);
                    DataGridViewCheckBoxCell cellHolgFlag = new DataGridViewCheckBoxCell();
                    cellHolgFlag.Value = bool.Parse(dr["HoldFlag"].ToString());
                    dgvr.Cells.Add(cellHolgFlag);
                    DataGridViewCheckBoxCell cellBaseFlag = new DataGridViewCheckBoxCell();
                    cellBaseFlag.Value = bool.Parse(dr["BasePoint"].ToString());
                    dgvr.Cells.Add(cellBaseFlag);
                    dgvStrategy.Rows.Add(dgvr);
                }
            }
        }
        /// <summary>
        /// 向下扩展加一条记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBottomAdd_Click(object sender, EventArgs e)
        {
            if (dgvStrategy.Rows.Count < 1)
                return;
            Double addPrice=10000000.00;
            int addAmount = 0;
            foreach (DataGridViewRow dgr in dgvStrategy.Rows)
            {
                double price = double.Parse(dgr.Cells["colStockPrice"].Value.ToString());
                if(addPrice>price)
                {
                    addPrice = price;
                    addAmount = int.Parse(dgr.Cells["colAmount"].Value.ToString());
                }
            }
            addPrice = Math.Round(addPrice * genreratePrecent, 2, MidpointRounding.AwayFromZero);
            DataGridViewRow dgvr = new DataGridViewRow();
            DataGridViewTextBoxCell cellStockNo = new DataGridViewTextBoxCell();
            cellStockNo.Value = StockNo;
            dgvr.Cells.Add(cellStockNo);
            DataGridViewTextBoxCell cellStockName = new DataGridViewTextBoxCell();
            cellStockName.Value = StockName;
            dgvr.Cells.Add(cellStockName);
            DataGridViewTextBoxCell cellPrice = new DataGridViewTextBoxCell();
            cellPrice.Value = addPrice;
            dgvr.Cells.Add(cellPrice);
            DataGridViewTextBoxCell cellAmount = new DataGridViewTextBoxCell();
            cellAmount.Value = addAmount;
            dgvr.Cells.Add(cellAmount);
            DataGridViewCheckBoxCell cellHolgFlag = new DataGridViewCheckBoxCell();
            cellHolgFlag.Value = false;
            dgvr.Cells.Add(cellHolgFlag);
            DataGridViewCheckBoxCell cellBaseFlag = new DataGridViewCheckBoxCell();
            cellBaseFlag.Value = false;
            dgvr.Cells.Add(cellBaseFlag);
            dgvStrategy.Rows.Add(dgvr);
            dgvStrategy.Sort(colStockPrice, ListSortDirection.Ascending);
        }
    }
}
