using System.Drawing;

namespace FireBridCloud
{
    partial class CommonDataGridView
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_HoldStock = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoldStock)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_HoldStock
            // 
            this.dgv_HoldStock.AllowUserToAddRows = false;
            this.dgv_HoldStock.AllowUserToDeleteRows = false;
            this.dgv_HoldStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_HoldStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_HoldStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HoldStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_HoldStock.Location = new System.Drawing.Point(0, 0);
            this.dgv_HoldStock.Name = "dgv_HoldStock";
            this.dgv_HoldStock.ReadOnly = true;
            this.dgv_HoldStock.RowTemplate.Height = 23;
            this.dgv_HoldStock.Size = new System.Drawing.Size(441, 150);
            this.dgv_HoldStock.TabIndex = 10;
            // 
            // CommonDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgv_HoldStock);
            this.Name = "CommonDataGridView";
            this.Size = new System.Drawing.Size(441, 150);
            //设置DataGridView隔行变色
            dgv_HoldStock.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv_HoldStock.RowsDefaultCellStyle.BackColor = Color.LightYellow;
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoldStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_HoldStock;

    }
}
