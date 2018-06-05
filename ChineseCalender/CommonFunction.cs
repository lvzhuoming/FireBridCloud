using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChineseCalender
{
    public class CommonFunction
    {
        public static string GetDateRemark(DateTime dt)
        {
            string remark = string.Empty;

            int month = dt.Month;
            int day = dt.Day;

            string sql = String.Format("select Remark from MonthDayRemark where Month={0} and Day={1}", month, day);
            DataTable dtRemark = SqliteDBUtility.DbHelperSQLite.Query(sql).Tables[0];
            if (dtRemark != null && dtRemark.Rows.Count > 0)
            {
                remark = dtRemark.Rows[0][0].ToString();
            }
            return remark;
        }

        public static void RasingForm(string remark)
        {
            FrmMessage ms = new FrmMessage();//要弹出的消息框  

            foreach (Form frm in System.Windows.Forms.Application.OpenForms)
            {
                if (frm is FrmMessage)
                {
                    //frm.Activate();
                    //frm.WindowState = FormWindowState.Normal;
                    return;
                }
            }
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - ms.Width, Screen.PrimaryScreen.WorkingArea.Height);
            ms.PointToClient(p);
            ms.Location = p;
            ms.Show();
            ms.txtRemark.Text  = remark;

            //Thread thread = new Thread(t =>
            //{
                for (int i = 0; i < ms.Height; i++)
                {
                    ms.Location = new Point(p.X, p.Y - i);
                    System.Threading.Thread.Sleep(10);
                }

                //Application.Run();
            //});
            //thread.Start();
        }

    }
}
