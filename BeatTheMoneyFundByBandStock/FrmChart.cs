using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FanG;

namespace BeatTheMoneyFundByBandStock
{
    public partial class FrmChart : Form
    {
        public string companyName = "XXX上市公司";
        public DataTable dt = null;
        public ArrayList xTitle = null;
        public ArrayList[] chartData = new ArrayList[1];
        public FrmChart()
        {
            InitializeComponent();
        }

        private void FrmChart_Load(object sender, EventArgs e)
        {
            //ArrayList XTitle = new ArrayList();
            //XTitle.Add("2010");
            //XTitle.Add("2011");
            //XTitle.Add("2012");
            //XTitle.Add("2013");
            //XTitle.Add("2014");
            //XTitle.Add("2015");
            //XTitle.Add("2016");
            //XTitle.Add("2017");
            //XTitle.Add("2018");
            //图表数据（1组）
            //Chart Data
            //ArrayList[] ChartData = new ArrayList[1];

            //ChartData[0] = new ArrayList();
            //ChartData[0].Add(90);
            //ChartData[0].Add(80);
            //ChartData[0].Add(70);
            //ChartData[0].Add(60);
            //ChartData[0].Add(50);
            //ChartData[0].Add(20);
            //ChartData[0].Add(20);
            //ChartData[0].Add(10);
            //string styleimg = "Pie_3D_Aurora_NoCrystal_NoGlow_NoBorder";
            //this.chartlet1.AppearanceStyle = (FanG.Chartlet.AppearanceStyles)System.Enum.Parse(typeof(FanG.Chartlet.AppearanceStyles), styleimg, true);
            //this.chartlet1.AppearanceStyle = Chartlet.AppearanceStyles.Pie_2D_Aurora_FlatCrystal_NoGlow_NoBorder;
            this.chartlet1.ChartTitle.Text = string.Format("{0}历年净利润",companyName);
            this.chartlet1.XLabels.UnitText = "年份";
            this.chartlet1.YLabels.UnitText = "净利润";
            this.chartlet1.BaseLineX = 0;
            this.chartlet1.InitializeData(chartData, xTitle, null);
        }

        private void FrmChart_Resize(object sender, EventArgs e)
        {
            this.chartlet1.Refresh();
        }
    }
}
