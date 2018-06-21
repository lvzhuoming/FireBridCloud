using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ChineseCalender
{
    public partial class FrmRemark : Form
    {
        private DateTime Date = new DateTime();
        private int Month = 0;
        private int Day = 0;
        public FrmRemark(DateTime date)
        {
            InitializeComponent();
            this.Date = date;
        }

        private void FrmRemark_Load(object sender, EventArgs e)
        {
            Month = Date.Month;
            Day = Date.Day;
            this.Text = string.Format("{0}月{1}日", Date.Month, Date.Day);
            //txtRemark.Text = CommonFunction.GetDateRemark(Date);

            DataTable dt=CommonFunction.GetDateRemarkDt(Date);
            //dataGridView1.DataSource = 
            foreach (DataRow dr in dt.Rows)
                dataGridView1.Rows.Add(dr[0].ToString());
        }

        private void FrmRemark_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView1.EndEdit();
            string sqlDelete = String.Format("delete from MonthDayRemark where Month={0} and Day={1}", Month, Day);
            SqliteDBUtility.DbHelperSQLite.ExecuteSql(sqlDelete);
            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                string remark = dr.Cells[0].Value.ToString();
                string sql = string.Format("insert into  MonthDayRemark (Month,Day,Remark) values ({0},{1},'{2}')", Month, Day, remark);

                SqliteDBUtility.DbHelperSQLite.ExecuteSql(sql);
            }



            //return;
            //string sql = String.Format("select * from MonthDayRemark where Month={0} and Day={1}", Month, Day);
            //string remark = txtRemark.Text;

            //if (SqliteDBUtility.DbHelperSQLite.Exists(sql))
            //{
            //    //MessageBox.Show("exist");
            //    sql = string.Format("update MonthDayRemark set Remark='{0}' where Month={1} and Day={2}", remark, Month,Day);
            //    SqliteDBUtility.DbHelperSQLite.ExecuteSql(sql);

            //}
            //else
            //{
            //    sql = string.Format("insert into  MonthDayRemark (Month,Day,Remark) values ({0},{1},'{2}')",  Month, Day,remark);

            //    SqliteDBUtility.DbHelperSQLite.ExecuteSql(sql);
            //    //MessageBox.Show("do not exist");
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.dataGridView1.BeginEdit(true);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                this.dataGridView1.Rows.RemoveAt(dataGridView1.SelectedCells[0].RowIndex);
            }
            catch (Exception)
            {
                return;
            }
            
        }

    }
}
