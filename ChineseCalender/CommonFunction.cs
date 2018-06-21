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

        /// <summary>
        /// 获取备注的dataTable
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static DataTable GetDateRemarkDt(DateTime date)
        {
            //DataTable  dt = null;

            int month = date.Month;
            int day = date.Day;

            string sql = String.Format("select Remark from MonthDayRemark where Month={0} and Day={1}", month, day);
            DataTable dtRemark = SqliteDBUtility.DbHelperSQLite.Query(sql).Tables[0];
            //if (dtRemark != null && dtRemark.Rows.Count > 0)
            //{
            //    remark = dtRemark.Rows[0][0].ToString();
            //}
            return dtRemark;
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
            //ms.txtRemark.Text  = remark;

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

        /// <summary>
        /// 弹出通知框的方法
        /// </summary>
        /// <param name="fatherFrm"></param>
        public static void ShowRiseMethod(Form fatherFrm)
        {
            try
            {
                fatherFrm.Invoke(new MethodInvoker(delegate()
                {
                    //bool isShowForm = false;
                    DateTime dt = DateTime.Now.AddDays(-1);
                    //string remark = string.Empty;
                    DataTable tableAll = null;
                    //向前走6步
                    for (int i = 0; i < 2; i++)
                    {
                        DataTable table = CommonFunction.GetDateRemarkDt(dt.AddDays(i));
                        if (table != null && table.Rows.Count > 0)
                        {
                            if (!table.Columns.Contains("Date"))
                            {
                                table.Columns.Add("Date", typeof(DateTime));
                            }
                            foreach (DataRow dr in table.Rows)
                            {
                                dr["Date"] = dt.AddDays(i);
                            }
                            if (tableAll == null)
                                tableAll = table.Copy();
                            else
                                tableAll.Merge(table.Copy());
                            //isShowForm = true;
                            //break;
                        }
                        //string value = CommonFunction.GetDateRemark(dt.AddDays(i));
                        //if (!string.IsNullOrEmpty(value))
                        //    remark += value + "\r\n";
                    }
                    if (tableAll != null && tableAll.Rows.Count > 0)
                    //if (!string.IsNullOrEmpty(remark))
                    {
                        if (!CommonFunction.IsShowNotice(tableAll))
                            return;

                        foreach (Form frm in System.Windows.Forms.Application.OpenForms)
                        {
                            if (frm is FrmMessage)
                            {
                                return;
                            }
                        }
                        FrmMessage ms = new FrmMessage();//要弹出的消息框  
                        ms.Dt = tableAll;
                        ms.Show();
                        //Point pStart = new Point(Screen.PrimaryScreen.WorkingArea.Width - ms.Width, Screen.PrimaryScreen.WorkingArea.Height);
                        //ms.PointToClient(pStart);
                        //ms.txtRemark.Text = remark;
                        Thread thread = new Thread(t =>
                        {
                            try
                            {
                                foreach (Form frm in System.Windows.Forms.Application.OpenForms)
                                {
                                    if (frm is FrmMessage)
                                    {
                                        Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - frm.Width, Screen.PrimaryScreen.WorkingArea.Height);
                                        frm.PointToClient(p);
                                        frm.Location = new Point(p.X, p.Y);
                                        for (int i = 0; i < frm.Height; i++)
                                        {
                                            if (System.Windows.Forms.Control.MousePosition.X > frm.Location.X && System.Windows.Forms.Control.MousePosition.Y > frm.Location.Y)
                                            {
                                                frm.Location = new Point(p.X, p.Y - frm.Height);
                                                break;
                                            }
                                            try
                                            {
                                                //frm.Location = p;
                                                frm.Location = new Point(p.X, p.Y - i);
                                                System.Threading.Thread.Sleep(10);
                                            }
                                            catch (Exception ex)
                                            {

                                            }

                                        }
                                    }
                                }
                            }
                            catch (Exception)
                            {

                                return;
                            }


                        });
                        thread.Start();

                    }
                }));
            }
            catch (Exception)
            {
                return;
            }


        }

        /// <summary>
        /// 是否弹出通知框
        /// </summary>
        /// <param name="dtAll"></param>
        /// <returns></returns>
        public static bool IsShowNotice(DataTable dtAll)
        {
            int count = 0;
            foreach (DataRow dr in dtAll.Rows)
            {
                DateTime dateTime = (DateTime)dr[1];

                string remark = dr[0].ToString();
                string handleDate = dateTime.ToString("yyyy-MM-dd");


                //int index = dataGridView1.Rows.Add(remark, handleDate, "已处理");



                //dataGridView1.Rows[index].Cells["Column2"].ReadOnly = true;
                //dataGridView1["Column2", index].ReadOnly = true;
                string checkIshandle = string.Format("select * from MessageHandle where Remark='{0}' and HandleDate='{1}'", remark, handleDate);
                DataTable dt = SqliteDBUtility.DbHelperSQLite.Query(checkIshandle).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    count++;
                }
                //button.Enabled = false;


                //button.
            }
            if (count == dtAll.Rows.Count)
                return false;
            return true;
        }
    }
}
