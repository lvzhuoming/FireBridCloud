/************************************************************************************
 * Copyright (c) 2016  All Rights Reserved.
 *命名空间：FireBridCloud
 *文件名：  BackgroundWorker
 *创建人：  吕焯明
 *创建时间：2016-10-25 10:14:00
 *描述
 *=====================================================================
 *修改标记
 *修改时间：2016-10-25 10:14:00
 *修改人： 吕焯明
 *描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using Utility;
namespace FireBridCloud
{
    public class BwMain
    {
        /// <summary>
        /// 断网状态
        /// </summary>
        /// <param name="onLineStaus"></param>
        public delegate void SetInternet(string onLineStaus);
        public static SetInternet SetInternetStaus = null;
        /// <summary>
        /// 持仓股价更新
        /// </summary>
        public delegate void SetHoldStock();
        public static SetHoldStock SetHoldStockInfo = null;
        /// <summary>
        /// 更新大盘指数信息
        /// </summary>
        public delegate void UpateMarketInfo();
        public static UpateMarketInfo UpateMarket= null;

        public static System.Timers.Timer timer = new System.Timers.Timer(3000);   //实例化Timer类，设置间隔时间为10000毫秒；  
        public static BackgroundWorker m_BackgroundWorker = new BackgroundWorker(); // 实例化后台对象;


        public static void OnStart()
        {
            timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer1_Elapsed);
            timer.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；   
            timer.Enabled = true;     //是否执行System.Timers.Timer.Elapsed事件；   
        }

        public static void Onstop()
        {
            timer.Enabled = false;
        }
        private static void Timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            StartWork();
        }
        
        public static void StartWork()
        {
            // 申明后台对象
            if (m_BackgroundWorker.IsBusy)
                return;
             m_BackgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
             m_BackgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CompletedWork);
             m_BackgroundWorker.RunWorkerAsync();
        }
        public static  void DoWork(object sender, DoWorkEventArgs e)
        {
            bool canConnetInternet = false;
            canConnetInternet=InternetHelper.PingIpOrDomainName("www.baidu.com");
            if (canConnetInternet && SetInternetStaus != null)
            {
                SetInternetStaus("Online");
            }
            if (!canConnetInternet && SetInternetStaus != null)
            {
                SetInternetStaus("OffLine");
            }
            if (SetHoldStockInfo != null)
                SetHoldStockInfo();
            if (UpateMarket != null)
                UpateMarket();
            //BackgroundWorker bw = sender as BackgroundWorker;
            ////MainWindow win = e.Argument as MainWindow;
        }



        static  void  CompletedWork(object sender, RunWorkerCompletedEventArgs e)
        {
            // 申明后台对象
            m_BackgroundWorker.DoWork -= new DoWorkEventHandler(DoWork);
            m_BackgroundWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(CompletedWork);
        }
    }
}
