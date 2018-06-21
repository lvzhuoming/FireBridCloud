using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ChineseCalender
{
    public partial class FrmMessage : Form
    {
        public DataTable Dt = null;

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
                Point pstart = new Point(Screen.PrimaryScreen.WorkingArea.Width - this.Width,
                    Screen.PrimaryScreen.WorkingArea.Height - this.Height);
                Point pEnd = new Point(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                int count = pEnd.Y - pstart.Y;
                //this.PointToClient(p);
                for (int i = 0; i <= this.Height; i++)
                {
                    while (FrmMessageMain.IsRasing)
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
            //DataTable dt = CommonFunction.GetDateRemarkDt(DateTime.Today);
            //dataGridView1.DataSource = 
            foreach (DataRow dr in Dt.Rows)
            {
                DateTime dateTime = (DateTime) dr[1];

                string remark = dr[0].ToString();
                string handleDate = dateTime.ToString("yyyy-MM-dd");


                int index = dataGridView1.Rows.Add(remark, handleDate, "已处理");



                //dataGridView1.Rows[index].Cells["Column2"].ReadOnly = true;
                //dataGridView1["Column2", index].ReadOnly = true;
                string checkIshandle = string.Format("select * from MessageHandle where Remark='{0}' and HandleDate='{1}'", remark, handleDate);
                DataTable dt = SqliteDBUtility.DbHelperSQLite.Query(checkIshandle).Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataGridViewDisableButtonCell button = dataGridView1.Rows[index].Cells[2] as DataGridViewDisableButtonCell;
                    if(button!=null)
                       button.Enabled = false;
                }
                //button.Enabled = false;


                //button.
            }
            dataGridView1.Invalidate();

            //txtRemark.Text = CommonFunction.GetDateRemark(DateTime.Today);
            //txtRemark.Select(txtRemark.TextLength, 0);//光标定位到文本最后
            //txtRemark.ScrollToCaret();//滚动到光标处s
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;
            if (e.ColumnIndex == 2)
            {
                DataGridViewDisableButtonCell button = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewDisableButtonCell;
                if (button.Enabled == false)
                    return;
            }

            if (e.ColumnIndex == 2)
            {
                //可以在此打开新窗口，把参数传递过去 
                //MessageBox.Show(this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                string strRemark = this.dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string strDate = this.dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                strDate = DateTime.Parse(strDate).ToString("yyyy-MM-dd");
                string insertSql = string.Format("insert into MessageHandle (Remark,HandleDate) values ('{0}','{1}')",
                    strRemark, strDate);

                SqliteDBUtility.DbHelperSQLite.ExecuteSql(insertSql);
                DataGridViewDisableButtonCell button = dataGridView1.Rows[e.RowIndex].Cells[2] as DataGridViewDisableButtonCell;
                if (button != null)
                    button.Enabled = false;
                dataGridView1.Invalidate();
            }
        }




    }

    public class DataGridViewDisableButtonCell : DataGridViewButtonCell
    {
        private bool enabledValue;

        public bool Enabled
        {
            get { return enabledValue; }
            set { enabledValue = value; }
        }

        // Override the Clone method so that the Enabled property is copied.
        public override object Clone()
        {
            DataGridViewDisableButtonCell cell =
                (DataGridViewDisableButtonCell) base.Clone();
            cell.Enabled = this.Enabled;
            return cell;
        }

        // By default, enable the button cell.
        public DataGridViewDisableButtonCell()
        {
            this.enabledValue = true;
        }

        protected override void Paint(Graphics graphics,
            Rectangle clipBounds, Rectangle cellBounds, int rowIndex,
            DataGridViewElementStates elementState, object value,
            object formattedValue, string errorText,
            DataGridViewCellStyle cellStyle,
            DataGridViewAdvancedBorderStyle advancedBorderStyle,
            DataGridViewPaintParts paintParts)
        {
            // The button cell is disabled, so paint the border,  
            // background, and disabled button for the cell.
            if (!this.enabledValue)
            {
                // Draw the cell background, if specified.
                if ((paintParts & DataGridViewPaintParts.Background) ==
                    DataGridViewPaintParts.Background)
                {
                    SolidBrush cellBackground =
                        new SolidBrush(cellStyle.BackColor);
                    graphics.FillRectangle(cellBackground, cellBounds);
                    cellBackground.Dispose();
                }

                // Draw the cell borders, if specified.
                if ((paintParts & DataGridViewPaintParts.Border) ==
                    DataGridViewPaintParts.Border)
                {
                    PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                        advancedBorderStyle);
                }

                // Calculate the area in which to draw the button.
                Rectangle buttonArea = cellBounds;
                Rectangle buttonAdjustment =
                    this.BorderWidths(advancedBorderStyle);
                buttonArea.X += buttonAdjustment.X;
                buttonArea.Y += buttonAdjustment.Y;
                buttonArea.Height -= buttonAdjustment.Height;
                buttonArea.Width -= buttonAdjustment.Width;

                // Draw the disabled button.                
                ButtonRenderer.DrawButton(graphics, buttonArea,
                    PushButtonState.Disabled);

                // Draw the disabled button text. 
                if (this.FormattedValue is String)
                {
                    TextRenderer.DrawText(graphics,
                        (string) this.FormattedValue,
                        this.DataGridView.Font,
                        buttonArea, SystemColors.GrayText);
                }
            }
            else
            {
                // The button cell is enabled, so let the base class 
                // handle the painting.
                base.Paint(graphics, clipBounds, cellBounds, rowIndex,
                    elementState, value, formattedValue, errorText,
                    cellStyle, advancedBorderStyle, paintParts);
            }
        }
    }
    public class DataGridViewDisableButtonColumn : DataGridViewButtonColumn
    {
        public DataGridViewDisableButtonColumn()
        {
            this.CellTemplate = new DataGridViewDisableButtonCell();
        }
    }
}
