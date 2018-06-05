using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Business;
using Model;

namespace FireBridCloud
{
    public partial class FrmStockHoldAdd : Form
    {
        private M_HoldStock m_HoldStock=new M_HoldStock();
        public bool AddFlag = true;
        /// <summary>
        /// 要修改的持股作息Id
        /// </summary>
        public int modifyId = 0;

        public delegate void del_SetHold();
        public del_SetHold SetHold = null;
        public FrmStockHoldAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            GetData();
            if (AddFlag)
                HoldStock.Add(m_HoldStock);
            else
                HoldStock.Update(m_HoldStock);
            if (SetHold != null)
                SetHold();
            this.Close();
        }

        private void GetData()
        {
            m_HoldStock.StockName = txtStockName.Text;
            m_HoldStock.StockNo = txtStockNo.Text;
            m_HoldStock.HoldAmount = Convert.ToInt32(txtHoldAmount.Text);
            m_HoldStock.Price = Convert.ToDouble(txtPrice.Text);
            m_HoldStock.UpdateTime = dtpupdateDate.Value;
            if(!AddFlag)
                m_HoldStock.ID =modifyId;
    
        }

        private void FrmStockHoldAdd_Load(object sender, EventArgs e)
        {
            if (!AddFlag)
            {
                M_HoldStock m_holdStock = HoldStock.GetModel(modifyId);
                this.txtHoldAmount.Text = m_holdStock.HoldAmount.ToString();
                this.txtStockNo.Text = m_holdStock.StockNo;
                this.txtPrice.Text = m_holdStock.Price.ToString();
                this.txtStockName.Text = m_holdStock.StockName;
                this.dtpupdateDate.Value = DateTime.Now;
            }
        }
    }
}
