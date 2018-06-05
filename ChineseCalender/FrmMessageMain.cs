using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ChineseCalender
{
    public partial class FrmMessageMain : Form
    {
        //是否正在上升
        public static bool IsRasing = true;
        public FrmMessageMain()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnShowAndDisappearMessages_Click(object sender, EventArgs e)
        {
            RasingForm();
        }

        private void btnMouseShowMessage_Click(object sender, EventArgs e)
        {
            RasingForm();
        }

        private void RasingForm()
        {
            IsRasing = true;
            FrmMessage ms = new FrmMessage();//要弹出的消息框  
            Point p = new Point(Screen.PrimaryScreen.WorkingArea.Width - ms.Width, Screen.PrimaryScreen.WorkingArea.Height);
            ms.PointToClient(p);
            ms.Location = p;
            ms.Show();
            Thread thread = new Thread(t =>
            {
                for (int i = 0; i < ms.Height; i++)
                {
                    ms.Location = new Point(p.X, p.Y - i);
                    System.Threading.Thread.Sleep(10);
                }
                IsRasing = false;
            });
            thread.Start();
        }
    }
}
