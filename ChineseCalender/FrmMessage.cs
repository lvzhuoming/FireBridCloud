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
    public partial class FrmMessage : Form
    {
        public FrmMessage()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void btnShowAndDisappearMessages_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(t =>
            {

                timer1.Enabled = false;
                Point pstart= new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width, Screen.PrimaryScreen.WorkingArea.Height-this.Height);
                Point pEnd = new Point(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                int count = pEnd.Y - pstart.Y;
                //this.PointToClient(p);
                for (int i = 0; i <= this.Height; i++)
                {
                    while(FrmMessageMain.IsRasing)
                    {
                        
                    }
                    Point p = new Point(this.Location.X, this.Location.Y + 1); //弹出框向下移动消失  
                    this.PointToScreen(p); //即时转换成屏幕坐标                        


                    this.Location = p; // new Point(this.Location.X, this.Location.Y + 1);  

                    System.Threading.Thread.Sleep(10); //线程睡眠时间调的越小向下消失的速度越快。  

                }

                this.Close();

                this.Dispose();
            });
            thread.Start();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (FrmMessageMain.IsRasing)
                return;
            Thread thread = new Thread(t =>
            {
                timer3.Enabled = false; //停止timer2计时器，  
                if (this.Opacity > 0 && this.Opacity <= 1) //开始执行弹出窗渐渐透明  
                {
                    this.Opacity = this.Opacity - 0.1; //透明频度  
                }
                if (System.Windows.Forms.Control.MousePosition.X >= this.Location.X &&
                    System.Windows.Forms.Control.MousePosition.Y >= this.Location.Y)
                    //每次都判断鼠标是否是在弹出窗上，使用鼠标在屏幕上的坐标跟弹出窗体的屏幕坐标做比较。  
                {
                    timer3.Enabled = true; //如果鼠标在弹出窗上的时候，timer2开始工作  
                    timer2.Enabled = false; //timer1停止工作。  
                }
                if (this.Opacity == 0) //当透明度==0的时候，关闭弹出窗以释放资源。  
                {
                    this.Close();

                    this.Dispose();

                }
            });
            thread.Start();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(t =>
            {
                timer2.Enabled = false; //timer1停止工作  
                this.Opacity = 1; //弹出窗透明度设置为1，完全不透明  
                if (System.Windows.Forms.Control.MousePosition.X < this.Location.X &&
                    System.Windows.Forms.Control.MousePosition.Y < this.Location.Y) //如下  
                {
                    timer2.Enabled = true;
                    timer3.Enabled = false;
                }
            });
            thread.Start();
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            //txtRemark.Text = CommonFunction.GetDateRemark(DateTime.Today);
            txtRemark.Select(txtRemark.TextLength, 0);//光标定位到文本最后
            txtRemark.ScrollToCaret();//滚动到光标处s
        }




    }
}
