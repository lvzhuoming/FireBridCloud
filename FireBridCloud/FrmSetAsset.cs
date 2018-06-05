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
    public partial class FrmSetAsset : Form
    {
        //持仓参考的委托
        public delegate void de_Asset();
        public de_Asset SetAsset = null;
        private double personalAsset = 0;
        private double creditAsset = 0;
        private DateTime date = System.DateTime.Now;

        public FrmSetAsset()
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
            M_Asset mas = new M_Asset();
            mas.Personal = personalAsset;
            mas.Credit = creditAsset;
            mas.UpdateTime = date;
            Asset.Add(mas);
            if (SetAsset != null)
                SetAsset();
            this.Close();
        }

        private void CheckData()
        {
            if (string.IsNullOrEmpty(txtPersonalAsset.Text))
            {
                MessageBox.Show("个人资产不能为空！");
                return;
            }
            if (string.IsNullOrEmpty(txtCreditAsset.Text))
            {
                MessageBox.Show("信用资产不能为空！");
                return;
            }
        }

        private bool  GetData()
        {
            try
            {
                personalAsset = Convert.ToDouble(txtPersonalAsset.Text);
                creditAsset = Convert.ToDouble(txtCreditAsset.Text);
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
            M_Asset mas = new M_Asset();
            DataTable dt=Asset.GetList("1=1 order by UpdateTime desc").Tables[0];
            if (dt.Rows.Count > 0)
                mas = Asset.DataRowToModel(dt.Rows[0]);
            txtCreditAsset.Text = mas.Credit.ToString();
            txtPersonalAsset.Text = mas.Personal.ToString();
            dtpupdateDate.Value = mas.UpdateTime;
        }
    }
}
