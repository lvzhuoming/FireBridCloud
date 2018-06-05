using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Business;
using Model;

namespace FireBridCloud
{
    public partial class FrmSetHoldingRate : Form
    {
        //持仓参考的委托
        public delegate void HoldRef();
        public HoldRef SetHoldRef = null;
        private double highestPrice = 0;
        private double lowestPrice = 0;
        private double nowPrice = 0;
        private DateTime date = System.DateTime.Now;

        public FrmSetHoldingRate()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            CheckData();
            if (!GetData())
                return;
            M_HoldRule mhr = new M_HoldRule();
            mhr.HightPrice = highestPrice;
            mhr.LowPrice = lowestPrice;
            mhr.NowPrice = nowPrice;
            mhr.UpdateTime = date;
            HoldRule.Add(mhr);
            if (SetHoldRef != null)
                SetHoldRef();
            this.Close();
        }

        private void CheckData()
        {
            if (string.IsNullOrEmpty(txtSZhighest.Text))
            {
                MessageBox.Show("上证最高价不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtSZlowest.Text))
            {
                MessageBox.Show("上证最低价不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtSZnow.Text))
            {
                MessageBox.Show("上证当前价不能为空！");
                return;
            }
        }

        private bool  GetData()
        {
            try
            {
                highestPrice = Convert.ToDouble(txtSZhighest.Text);
                lowestPrice = Convert.ToDouble(txtSZlowest.Text);
                nowPrice = Convert.ToDouble(txtSZnow.Text);
                return true;
            }
            catch(Exception exception)
            {
                MessageBox.Show("数据有误！");
                return false;
            }
        }

        private void FrmSetHoldingRate_Load(object sender, EventArgs e)
        {
            M_HoldRule mhr = new M_HoldRule();
            DataTable dt=HoldRule.GetList("1=1 order by UpdateTime desc").Tables[0];
            if (dt.Rows.Count > 0)
                mhr = HoldRule.DataRowToModel(dt.Rows[0]);
            txtSZlowest.Text = mhr.LowPrice.ToString();
            txtSZhighest.Text = mhr.HightPrice.ToString();
            txtSZnow.Text = mhr.NowPrice.ToString();
            dtpSZupdateDate.Value = mhr.UpdateTime;
        }
    }
}
