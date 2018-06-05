using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using Utility;

namespace FireBridCloud
{
    public partial class FrmStockChart : Form
    {
        private readonly string stockNoWithHead = string.Empty;
        private BackgroundWorker bw = new BackgroundWorker();
        private System.Timers.Timer timer = new System.Timers.Timer(10000);  
        public FrmStockChart(string stockNo)
        {
            InitializeComponent();
            stockNoWithHead = CommonFunction.AddStockNoHead(stockNo);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshImage();
            //PictureBox box = null;
            //string tabText = tabControl1.SelectedTab.Text;
            //WebClient client = new WebClient();
            //string imageType = string.Empty;
            //switch (tabText)
            //{
            //    case "分时":
            //        imageType = "min";
            //        box = pictureBox1;
            //        break;
            //    case "日K":
            //        imageType = "daily";
            //        box = pictureBox2;
            //        break;
            //    case "周K":
            //        imageType = "weekly";
            //        box = pictureBox3;
            //        break;
            //    case "月K":
            //        imageType = "monthly";
            //        box = pictureBox4;
            //        break;
            //}
            //string URLAddress = string.Format(@"http://image.sinajs.cn/newchart/{0}/n/{1}.gif",imageType,stockNoWithHead);
            //string receivePath = CommonConstString.stockImagePath;
            //string fileFullName = receivePath + System.IO.Path.GetFileName(URLAddress);
            //client.DownloadFile(URLAddress, fileFullName);
            //box.ImageLocation = fileFullName;
        }

        private void RefreshImage()
        {
            PictureBox box = null;
            string tabText = tabControl1.SelectedTab.Text;
            WebClient client = new WebClient();
            string imageType = string.Empty;
            switch (tabText)
            {
                case "分时":
                    imageType = "min";
                    box = pictureBox1;
                    break;
                case "日K":
                    imageType = "daily";
                    box = pictureBox2;
                    break;
                case "周K":
                    imageType = "weekly";
                    box = pictureBox3;
                    break;
                case "月K":
                    imageType = "monthly";
                    box = pictureBox4;
                    break;
            }
            string URLAddress = string.Format(@"http://image.sinajs.cn/newchart/{0}/n/{1}.gif", imageType, stockNoWithHead);
            string receivePath = CommonConstString.stockImagePath;
            string fileFullName = receivePath + System.IO.Path.GetFileName(URLAddress);
            client.DownloadFile(URLAddress, fileFullName);
            box.ImageLocation = fileFullName;
        }

        private void FrmStockChart_Load(object sender, EventArgs e)
        {
            //tabControl1_SelectedIndexChanged(null, null);
            RefreshImage();
            OnStart();
        }

        private void OnStart()
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);
            timer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            timer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
        }

        private void Onstop()
        {
            timer.Enabled = false;
        }
        private  void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StartWork();
        }

        private void StartWork()
        {
            // 申明后台对象
            if (bw.IsBusy)
                return;
            bw.DoWork += new DoWorkEventHandler(DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);
            bw.RunWorkerAsync();
        }

        private  void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Invoke(new MethodInvoker(RefreshImage));
            }
            catch (Exception ex)
            {
                
            }

        }


        private void CompletedWork(object sender, RunWorkerCompletedEventArgs e)
        {
            // 申明后台对象
            bw.DoWork -= new DoWorkEventHandler(DoWork);
            bw.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(CompletedWork);
        }

        private void FrmStockChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Enabled = false;
        }

       
    }
}
