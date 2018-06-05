using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeatTheMoneyFundByBandStock
{
    public partial class FrmValueInvestment : Form
    {
        public FrmValueInvestment()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InintCombox();
            ShowView(this.comboBox1.SelectedValue.ToString());
        }

        private void InintCombox()
        {
            DataTable dtStock =
                SqliteDBUtility.DbHelperSQLite.Query("select distinct stockNo,stockName  from YearEarn order by Year")
                    .Tables[0];
            comboBox1.DataSource = dtStock;
            comboBox1.DisplayMember = "StockName";
            comboBox1.ValueMember = "StockNo";
        }

        private void ShowView(string stockNo)
        {
            DataTable dtYearEarn = SqliteDBUtility.DbHelperSQLite.Query(string.Format("select * from YearEarn where stockno='{0}'order by Year", stockNo)).Tables[0];
            dataGridViewYearEarn.DataSource = dtYearEarn;
            DataTable dtBuyRecord = SqliteDBUtility.DbHelperSQLite.Query(string.Format("select * from BuyStockRecord where stockno='{0}'", stockNo)).Tables[0];
            dtBuyRecord.Columns.Add("HoldDay", typeof(int));
            dtBuyRecord.Columns.Add("WorthPrice", typeof(double));
            dtBuyRecord.Columns.Add("TimeValue", typeof(double));
            DateTime nowDate = DateTime.Now;
            for (int i = 0; i < dtBuyRecord.Rows.Count; i++)
            {
                double worthPrice = 0.0;
                double earnPrice = 0.0;
                DateTime buyDate = DateTime.Parse(dtBuyRecord.Rows[i]["BuyDate"].ToString());
                //获取购买时的年份
                int buyYear = buyDate.Year;
                //获取当前时间的年份
                int nowYear = nowDate.Year;
                int cursorHoldYear = buyYear;
                int noDataYear = 0;
                for (int j = 0; j < nowYear - buyYear; j++)
                {
                    if (cursorHoldYear == nowYear) break;
                    DataTable dtHoldYearEarn =
                        SqliteDBUtility.DbHelperSQLite.Query(string.Format("select * from YearEarn where Year='{0}' and stockno='{1}'",
                            cursorHoldYear,stockNo)).Tables[0];
                    if (dtHoldYearEarn == null || dtHoldYearEarn.Rows.Count < 1)
                    {
                        noDataYear++;
                        continue;
                    }
                    earnPrice = earnPrice + (double)dtHoldYearEarn.Rows[0]["Earn"] / 2;
                    cursorHoldYear++;
                }
                //获取当年年份
                double yearEarn = (double)dtYearEarn.Rows[dtYearEarn.Rows.Count - 1]["Earn"];
                int thisYearHoldDays = 0;
                if (buyYear != nowYear)
                    thisYearHoldDays = nowDate.DayOfYear;
                else
                    thisYearHoldDays = (nowDate - buyDate).Days;
                earnPrice = earnPrice + yearEarn / 2 / 365 * thisYearHoldDays + yearEarn * noDataYear / 2;
                int holdDate = (nowDate - buyDate).Days;
                dtBuyRecord.Rows[i]["HoldDay"] = holdDate;

                worthPrice = ((double)dtBuyRecord.Rows[i]["BuyPrice"] + earnPrice) * 1.02;
                dtBuyRecord.Rows[i]["WorthPrice"] = Math.Round(worthPrice, 2, MidpointRounding.AwayFromZero);
                dtBuyRecord.Rows[i]["TimeValue"] = Math.Round(earnPrice, 2, MidpointRounding.AwayFromZero);
            }
            dataGridViewBuyStockRecord.DataSource = dtBuyRecord;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowView(this.comboBox1.SelectedValue.ToString());
        }

        private void btnAddYearnEarn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStcokNo.Text) ||
                string.IsNullOrEmpty(txtStockName.Text) ||
                string.IsNullOrEmpty(txtEarn.Text) ||
                string.IsNullOrEmpty(txtYear.Text))
                return;
            string strAddSql =
                string.Format("insert into YearEarn (StockNo,StockName,Year,Earn,Profit) values " +
                              "('{0}','{1}','{2}','{3}','{4}')",txtStcokNo.Text,txtStockName.Text,txtYear.Text,txtEarn.Text,txtProfit.Text);

            SqliteDBUtility.DbHelperSQLite.ExecuteSql(strAddSql);
            string nowStock = this.comboBox1.SelectedValue.ToString();
            InintCombox();
            this.comboBox1.SelectedValue = nowStock;
            ShowView(nowStock);
            //DataTable dtYearEarn = SqliteDBUtility.DbHelperSQLite.Query(string.Format("select * from YearEarn where stockno='{0}'order by Year", stockNo)).Tables[0];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var row = dataGridViewYearEarn.CurrentRow;
            //if (row == null) return;
            string id = row.Cells[0].Value.ToString();
            string strDeleteSql =
            string.Format("delete from YearEarn where ID='{0}'",id);
            SqliteDBUtility.DbHelperSQLite.ExecuteSql(strDeleteSql);
            ShowView(this.comboBox1.SelectedValue.ToString());
        }

        private void btnDeleteBuyStockRecord_Click(object sender, EventArgs e)
        {
            var row = dataGridViewBuyStockRecord.CurrentRow;
            //if (row == null) return;
            string id = row.Cells[0].Value.ToString();
            string strDeleteSql =
            string.Format("delete from BuyStockRecord where ID='{0}'", id);
            SqliteDBUtility.DbHelperSQLite.ExecuteSql(strDeleteSql);
            ShowView(this.comboBox1.SelectedValue.ToString());
        }

        private void btnAddBuyStockRecord_Click(object sender, EventArgs e)
        {
            DateTime dt = dateTimePicker1.Value;
            string date = dt.ToString("yyyy-MM-dd");
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text)||
                string.IsNullOrEmpty(date))
                return;
            string strAddSql =
                string.Format("insert into BuyStockRecord (StockNo,StockName,BuyPrice,BuyAmount,BuyDate) values " +
                              "('{0}','{1}','{2}','{3}','{4}')", textBox1.Text, textBox2.Text, textBox3.Text,
                    textBox4.Text, date);

            SqliteDBUtility.DbHelperSQLite.ExecuteSql(strAddSql);
            ShowView(this.comboBox1.SelectedValue.ToString());
        }

        private void btnProfitAnlayist_Click(object sender, EventArgs e)
        {
           
            DataTable dt=dataGridViewYearEarn.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
                return;
            string companyName = dt.Rows[0][2].ToString();
            ArrayList xTitle = new ArrayList();
            ArrayList[] chartData = new ArrayList[1];
            chartData[0] = new ArrayList();
            foreach (DataRow dr in dt.Rows)
            {
                if (string.Compare(dr["Profit"].ToString(), string.Empty,true)==0)
                {
                    continue;
                }
                xTitle.Add(dr["Year"]);
                chartData[0].Add(dr["Profit"]);
            }


            FrmChart frm = new FrmChart();
            frm.companyName = companyName;
            frm.chartData = chartData;
            frm.xTitle = xTitle;
            frm.ShowDialog();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            string stockName = this.comboBox1.Text;
            string stockNo = this.comboBox1.SelectedValue.ToString();
            //初始化一些文本框
            txtStcokNo.Text = stockNo;
            txtStockName.Text = stockName;
            textBox1.Text = stockNo;
            textBox2.Text = stockName;
        }
    }
}
