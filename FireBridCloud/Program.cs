using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DBUtility;
using Utility;

namespace FireBridCloud
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //看进程是否在运行
            Process[] app = Process.GetProcessesByName("FireBridCloud");
            if (app.Length >1)
            {
                MessageBox.Show("程序已启动！");
                return;
            }

            //if (!ConnetString.AccessExist())
            //{
            //    MessageBox.Show("没有安装Access数据库！");

            //    return;
            //}
            //FrmMain frm = new FrmMain();
            FrmWave frm = new FrmWave();
            //Sunisoft.IrisSkin.SkinEngine skin = new Sunisoft.IrisSkin.SkinEngine((System.ComponentModel.Component)frm);
            //skin.SkinFile = CommonConstString.sskPath; // 指定皮肤文件
            //skin.TitleFont = new System.Drawing.Font("微软雅黑", 10F);// 指定标题栏的Font。
            Application.Run(frm); 

        }
    }
}
