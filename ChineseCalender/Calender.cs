/* =======================================================================
* 【本类功能概述】
* 
* 作者：EricHu       时间：2012/8/5 10:25:31
* 文件名：Calender
* CLR版本：4.0.30319.269
*
* 修改者：           时间：              
* 修改说明：
* ========================================================================
*/
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;


namespace ChineseCalender
{
    public partial class Calender : Form
    {

        private DateTime dtNow = DateTime.Now;   //初始化当天日期
        private int daysOfMonth = 30;     //初始化每月天数
        private int weekOfFirstDay = 1;   //初始化某月第一天的星期
        private int selectYear;     //初始化选择年份
        private int selectMonth;   //初始化选择月份
        private DateTime dtInfo = DateTime.Now;    //初始化日期信息
        private string[,] dateArray = new string[7, 6];   //记录日期信息
        Panel panelDateInfo = null;
        private bool flag = true; //标记是否重绘panel

        public Calender()
        {
            InitializeComponent();
            DrawControls();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Calender_Load(object sender, EventArgs e)
        {
            Control.ControlCollection controls = panelMonthInfo.Controls;
            foreach (Control control in controls)
            {
                if (control.GetType() == typeof (Panel))
                {
                    panelDateInfo = control as Panel;
                }
            }
            BwRemarkRemind.ShowRiseForm = CommonFunction.ShowRiseMethod;
            BwRemarkRemind.fatherForm = this;
            BwRemarkRemind.OnStart();

        }

        #region 绘制控件
        //绘制控件
        private void DrawControls()
        {
            var btnToday = new Button();
            btnToday.Location = new System.Drawing.Point(300, 15);
            btnToday.Name = "btnToday";
            btnToday.Size = new System.Drawing.Size(80, 21);
            btnToday.TabIndex = 0;
            btnToday.Text = "跳转到今天";
            btnToday.UseVisualStyleBackColor = true;
            btnToday.Click += new System.EventHandler(this.btnToday_Click);

            var lblYear = new Label();
            lblYear.Name = "lblYear";
            lblYear.Text = "年份";
            lblYear.Location = new Point(91, 19);
            lblYear.Size = new Size(29, 20);
            lblYear.BackColor = Color.Transparent;

            var lblMonth = new Label();
            lblMonth.Name = "lblMonth";
            lblMonth.Text = "月份";
            lblMonth.Location = new Point(190, 19);
            lblMonth.Size = new Size(29, 20);
            lblMonth.BackColor = Color.Transparent;

            var cmbSelectYear = new ComboBox();
            cmbSelectYear.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectYear.FormattingEnabled = true;
            cmbSelectYear.Location = new Point(120, 15);
            cmbSelectYear.Name = "cmbSelectYear";
            cmbSelectYear.AutoSize = false;
            cmbSelectYear.Size = new Size(50, 20);
            cmbSelectYear.TabIndex = 0;
            cmbSelectYear.SelectionChangeCommitted += new EventHandler(cmbSelectYear_SelectionChangeCommitted);

            var cmbSelectMonth = new ComboBox();
            cmbSelectMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectMonth.FormattingEnabled = true;
            cmbSelectMonth.Location = new Point(220, 15);
            cmbSelectMonth.Name = "cmbSelectYear";
            cmbSelectMonth.AutoSize = false;
            cmbSelectMonth.Size = new Size(50, 20);
            cmbSelectMonth.TabIndex = 0;
            cmbSelectMonth.SelectionChangeCommitted += new EventHandler(cmbSelectMonth_SelectionChangeCommitted);

            var panelDateInfo = new Panel();
            panelDateInfo.BackColor = Color.White;
            panelDateInfo.Location = new Point(575, 45);
            panelDateInfo.Size = new Size(165, 390);
            panelDateInfo.Paint += new PaintEventHandler(panelDateInfo_Paint);

            var lblShowTime = new Label();
            lblShowTime.Location = new Point(600, 470);
            lblShowTime.BackColor = Color.Transparent;
            lblShowTime.AutoSize = true;
            lblShowTime.Name = "lblShowTime";

            var label1 = new Label();
            label1.AutoSize = false;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            label1.Location = new System.Drawing.Point(252, 449);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(176, 13);
            label1.TabIndex = 0;
            label1.Text = "飞鸿踏雪泥 www.zhuoyuegzs.com";
            label1.BackColor = Color.Transparent;
            label1.TextAlign = ContentAlignment.MiddleCenter;
            label1.Width = 400;
            label1.Click += new EventHandler(label1_Click);

            for (int i = 1949; i <= 2049; i++)
            {
                cmbSelectYear.Items.Add(i);
                if (i == dtNow.Year)
                {
                    cmbSelectYear.SelectedItem = i;
                    selectYear = i;
                }
            }
            for (int i = 1; i <= 12; i++)
            {
                cmbSelectMonth.Items.Add(i);
                if (i == dtNow.Month)
                {
                    cmbSelectMonth.SelectedItem = i;
                    selectMonth = i;
                }
            }
            panelMonthInfo.Controls.Add(btnToday);
            panelMonthInfo.Controls.Add(lblMonth);
            panelMonthInfo.Controls.Add(lblYear);
            panelMonthInfo.Controls.Add(cmbSelectYear);
            panelMonthInfo.Controls.Add(cmbSelectMonth);
            panelMonthInfo.Controls.Add(panelDateInfo);
            panelMonthInfo.Controls.Add(lblShowTime);
            panelMonthInfo.Controls.Add(label1);
        }


        #endregion

        //主窗体绘制月历
        private void panelMonthInfo_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            var pen1 = new Pen(Color.Blue, 2);
            var pen = new Pen(Color.FromArgb(255, 235, 211), 1);

            var tb = new TextureBrush(global::ChineseCalender.Properties.Resources.wnlbg, WrapMode.TileFlipXY);
            g.FillRectangle(tb, 0, 0, 750, 475);
            g.FillRectangle(new SolidBrush(Color.White), 5, 40, 740, 400);

            SolidBrush sb = new SolidBrush(Color.FromArgb(50, 255, 247, 241));
            g.FillRectangle(sb, 10, 45, 560, 30);

            //画横线
            g.DrawLine(pen, 10, 45, 570, 45);
            g.DrawLine(pen, 10, 75, 570, 75);
            for (int i = 1; i < 7; i++)
            {
                g.DrawLine(pen, 10, 75+60*i, 570, 75+60*i);
            }


            //画竖线
            for (int i = 0; i < 8; i++)
            {
                g.DrawLine(pen, 10+80*i, 45, 10+80*i, 435);
            }


            var solidBrushWeekday = new SolidBrush(Color.Gray);
            var solidBrushWeekend = new SolidBrush(Color.Chocolate);
            g.DrawString("日", new Font("微软雅黑", 12), solidBrushWeekend, 35, 50);
            g.DrawString("一", new Font("微软雅黑", 12), solidBrushWeekday, 115, 50);
            g.DrawString("二", new Font("微软雅黑", 12), solidBrushWeekday, 195, 50);
            g.DrawString("三", new Font("微软雅黑", 12), solidBrushWeekday, 275, 50);
            g.DrawString("四", new Font("微软雅黑", 12), solidBrushWeekday, 355, 50);
            g.DrawString("五", new Font("微软雅黑", 12), solidBrushWeekday, 435, 50);
            g.DrawString("六", new Font("微软雅黑", 12), solidBrushWeekend, 515, 50);

            if (flag)
            {
                GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, dtNow.Year, dtNow.Month);
                DrawDateNum(weekOfFirstDay, daysOfMonth, dtNow.Year, dtNow.Month);
                //DrawDateInfo(dtNow);
            }
        }

        private void panelDateInfo_Paint(object sender, PaintEventArgs e)
        {
            ChineseCalendar cc = new ChineseCalendar(dtInfo);
            string dateString = cc.DateString; //阳历
            string chineseDateString = cc.ChineseDateString; //农历
            string dateHoliday = cc.DateHoliday; //阳历节日
            string chineseTwentyFourDay = cc.ChineseTwentyFourDay; //农历节日
            string constellation = cc.Constellation; //星座
            string weekDayString = cc.WeekDayStr; //星期
            string ganZhiDateString = cc.GanZhiDateString;
            string animalString = cc.AnimalString;
            string chineseConstellation = cc.ChineseConstellation;

            string remark = cc.Remark;

            if (panelDateInfo != null)
            {
                Graphics g = panelDateInfo.CreateGraphics();
                if (dateString != null)
                    g.DrawString(dateString + " " + weekDayString, new Font("", 9), new SolidBrush(Color.Gray), 7, 10);
                g.DrawString(dtInfo.Day.ToString(CultureInfo.InvariantCulture), new Font("", 45, FontStyle.Bold),
                             new SolidBrush(Color.Gainsboro), 50, 30);
                var family = new FontFamily("宋体");
                g.DrawString(chineseDateString.Substring(7, chineseDateString.Length - 7), new Font(family, 10),
                             new SolidBrush(Color.Goldenrod), 50, 100);
                //g.DrawString(constellation, new Font(family, 9), new SolidBrush(Color.Goldenrod), 60, 120);
                g.DrawString(ganZhiDateString.Substring(0, 3) + " 【" + animalString + "年】", new Font(family, 10),
                             new SolidBrush(Color.Goldenrod), 30, 120);
                g.DrawString(ganZhiDateString.Substring(3, ganZhiDateString.Length - 3), new Font(family, 10),
                             new SolidBrush(Color.Goldenrod), 40, 140);
                g.DrawString(constellation + "   " + chineseConstellation, new Font(family, 10),
                             new SolidBrush(Color.Goldenrod), 30, 160);
                //g.DrawString(chineseConstellation, new Font(family, 10), new SolidBrush(Color.Goldenrod), 50, 180);

                g.DrawString(chineseTwentyFourDay, new Font(family, 10), new SolidBrush(Color.Goldenrod), 40, 200);

                g.DrawString(remark, new Font(family, 10), new SolidBrush(Color.Goldenrod), 10, 220);
            }
        }

        private void cmbSelectMonth_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectMonth = sender as ComboBox;
            selectMonth = (int)cmbSelectMonth.SelectedItem;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
        }

        private void cmbSelectYear_SelectionChangeCommitted(object sender, EventArgs e)
        {
            flag = false;
            var cmbSelectYear = sender as ComboBox;
            selectYear = (int)cmbSelectYear.SelectedItem;
            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, selectYear, selectMonth);
            DrawDateNum(weekOfFirstDay, daysOfMonth, selectYear, selectMonth);
        }

        private void panelMonthInfo_MouseClick(object sender, MouseEventArgs e)
        {

            //MessageBox.Show(e.X + "\n" + e.Y);
            if (e.Button == MouseButtons.Left)
            {


                if (e.X < 10 || e.X > 575)
                {
                    return;
                }
                if (e.Y < 75 || e.Y > 435)
                {
                    return;
                }
                int x = (e.X - 10) / 80;
                int y = (e.Y - 75) / 60;
                if (dateArray[x, y] == null)
                {
                    return;
                }
                DateTime dtSelect = DateTime.Parse(dateArray[x, y]);
                dtInfo = dtSelect;
                // DrawDateInfo(dtSelect);
            }
            panelDateInfo.Refresh();
        }

        private void panelMonthInfo_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrmRemark frm = new FrmRemark(dtInfo);
            frm.ShowDialog();
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            flag = false;

            panelMonthInfo.Refresh();
            GetWeekInfo(ref weekOfFirstDay, ref daysOfMonth, dtNow.Year, dtNow.Month);
            DrawDateNum(weekOfFirstDay, daysOfMonth, dtNow.Year, dtNow.Month);
            dtInfo = dtNow;
            panelDateInfo.Refresh();
        }

        void label1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("www.zhuoyuegzs.com");
        }
        //绘制月历日期
        private void DrawDateNum(int firstDayofWeek, int endMonthDay, int year, int month)
        {
            DateTime dtNow = DateTime.Parse(DateTime.Now.ToShortDateString());

            var font = new Font("", 14);
            var solidBrushWeekdays = new SolidBrush(Color.Gray);
            var solidBrushWeekend = new SolidBrush(Color.Chocolate);
            var solidBrushHoliday = new SolidBrush(Color.BurlyWood);
            Graphics g = panelMonthInfo.CreateGraphics();
            int num = 1;

            for (int j = 0; j < 6; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (j == 0 && i < firstDayofWeek) //定义当月第一天的星期的位置
                    {
                        continue;
                    }
                    else
                    {
                        if (num > endMonthDay) //定义当月最后一天的位置
                        {
                            break;
                        }
                        string cMonth = null;
                        string cDay = null;
                        string cHoliday = null;
                        string ccHoliday = null;

                        if (i > 0 && i < 6)
                        {
                            DateTime dt = DateTime.Parse(year + "-" + month + "-" + num);
                            TimeSpan ts = dt - dtNow;
                            dateArray[i, j] = dt.ToShortDateString();

                            if (ts.Days == 0)
                            {
                                g.DrawEllipse(new Pen(Color.Chocolate, 3), (15 + 80 * i), (85 + 60 * j), 30, 15);
                            }

                            cMonth = ChineseDate.GetMonth(dt);
                            cDay = ChineseDate.GetDay(dt);
                            cHoliday = ChineseDate.GetHoliday(dt);
                            ccHoliday = ChineseDate.GetChinaHoliday(dt);
                            
                            if (cHoliday != null)
                            {
                                //绘阳历节日
                                g.DrawString(cHoliday.Length > 3 ? cHoliday.Substring(0, 3) : cHoliday, new Font("", 9),
                                             solidBrushHoliday, (40 + 80 * i), (90 + 60 * j));
                            }
                            //绘农历
                            if (ccHoliday != "")
                            {
                                g.DrawString(ccHoliday, new Font("", 10), solidBrushWeekdays, (25 + 80 * i),
                                                                         (115 + 60 * j));
                            }
                            else
                            {
                                g.DrawString(cDay == "初一" ? cMonth : cDay, new Font("", 10), solidBrushWeekdays, (25 + 80 * i),
                                                                         (115 + 60 * j));
                            }
                            

                            //绘日期
                            g.DrawString(num.ToString(CultureInfo.InvariantCulture), font, solidBrushWeekdays,
                                         (15 + 80 * i), (80 + 60 * j));

                        }
                        else
                        {
                            var dt = DateTime.Parse(year + "-" + month + "-" + num);
                            var ts = dt - dtNow;
                            dateArray[i, j] = dt.ToShortDateString();
                            if (ts.Days == 0)
                            {
                                g.DrawEllipse(new Pen(Color.Chocolate, 3), (15 + 80 * i), (85 + 60 * j), 30, 15);
                            }

                            cMonth = ChineseDate.GetMonth(dt);
                            cDay = ChineseDate.GetDay(dt);
                            cHoliday = ChineseDate.GetHoliday(dt);
                            ccHoliday = ChineseDate.GetChinaHoliday(dt);

                            if (cHoliday != null)
                            {
                                //绘阳历节日
                                g.DrawString(cHoliday.Length > 3 ? cHoliday.Substring(0, 3) : cHoliday, new Font("", 9),
                                             solidBrushHoliday, (40 + 80 * i), (90 + 60 * j));
                            }
                            //绘农历
                            if (ccHoliday!="")
                            {
                                g.DrawString(ccHoliday, new Font("", 10), solidBrushWeekend, (25 + 80 * i),
                                         (115 + 60 * j));
                            }
                            else
                            {
                                g.DrawString(cDay == "初一" ? cMonth : cDay, new Font("", 10), solidBrushWeekend, (25 + 80 * i),
                                         (115 + 60 * j));
                            }

                            //绘日期
                            g.DrawString(num.ToString(CultureInfo.InvariantCulture), font, solidBrushWeekend,
                                         (15 + 80 * i), (80 + 60 * j));
                        }

                        num++;

                    }

                }
            }
        }

        //获取某月首日星期及某月天数
        private void GetWeekInfo(ref int weekOfFirstDay, ref int daysOfMonth, int year = 1900, int month = 2, int day = 1)
        {
            DateTime dt =
                DateTime.Parse(year.ToString(CultureInfo.InvariantCulture) + "-" +
                               month.ToString(CultureInfo.InvariantCulture) + "-" +
                               day.ToString(CultureInfo.InvariantCulture));
            weekOfFirstDay = (int)dt.DayOfWeek;
            daysOfMonth = (int)DateTime.DaysInMonth(year, month);
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {
            AboutBox about=new AboutBox();
            about.ShowDialog();
        }

    }
}
