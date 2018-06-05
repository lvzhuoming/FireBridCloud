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
        private DateTime Dt = new DateTime();
        private int Month = 0;
        private int Day = 0;
        public FrmRemark(DateTime dt)
        {
            InitializeComponent();
            this.Dt = dt;
        }

        private void FrmRemark_Load(object sender, EventArgs e)
        {
            Month = Dt.Month;
            Day = Dt.Day;
            this.Text = string.Format("{0}月{1}日",Dt.Month,Dt.Day);
            txtRemark.Text = CommonFunction.GetDateRemark(Dt);
        }

        private void FrmRemark_FormClosing(object sender, FormClosingEventArgs e)
        {
            string sql = String.Format("select * from MonthDayRemark where Month={0} and Day={1}", Month, Day);
            string remark = txtRemark.Text;

            if (SqliteDBUtility.DbHelperSQLite.Exists(sql))
            {
                //MessageBox.Show("exist");
                sql = string.Format("update MonthDayRemark set Remark='{0}' where Month={1} and Day={2}", remark, Month,Day);
                SqliteDBUtility.DbHelperSQLite.ExecuteSql(sql);

            }
            else
            {
                sql = string.Format("insert into  MonthDayRemark (Month,Day,Remark) values ({0},{1},'{2}')",  Month, Day,remark);

                SqliteDBUtility.DbHelperSQLite.ExecuteSql(sql);
                //MessageBox.Show("do not exist");
            }
        }


    }
}
