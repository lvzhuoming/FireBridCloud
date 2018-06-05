namespace FireBridCloud
{
    partial class FrmSetAsset
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tx = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPersonalAsset = new System.Windows.Forms.TextBox();
            this.txtCreditAsset = new System.Windows.Forms.TextBox();
            this.dtpupdateDate = new System.Windows.Forms.DateTimePicker();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "个人资产";
            // 
            // tx
            // 
            this.tx.AutoSize = true;
            this.tx.Location = new System.Drawing.Point(24, 54);
            this.tx.Name = "tx";
            this.tx.Size = new System.Drawing.Size(53, 12);
            this.tx.TabIndex = 1;
            this.tx.Text = "信用资产";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "更新日期";
            // 
            // txtPersonalAsset
            // 
            this.txtPersonalAsset.Location = new System.Drawing.Point(82, 14);
            this.txtPersonalAsset.Name = "txtPersonalAsset";
            this.txtPersonalAsset.Size = new System.Drawing.Size(111, 21);
            this.txtPersonalAsset.TabIndex = 4;
            // 
            // txtCreditAsset
            // 
            this.txtCreditAsset.Location = new System.Drawing.Point(82, 50);
            this.txtCreditAsset.Name = "txtCreditAsset";
            this.txtCreditAsset.Size = new System.Drawing.Size(111, 21);
            this.txtCreditAsset.TabIndex = 5;
            // 
            // dtpupdateDate
            // 
            this.dtpupdateDate.Location = new System.Drawing.Point(82, 87);
            this.dtpupdateDate.Name = "dtpupdateDate";
            this.dtpupdateDate.Size = new System.Drawing.Size(110, 21);
            this.dtpupdateDate.TabIndex = 7;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(14, 125);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 8;
            this.btnCommit.Text = "提交";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(117, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmSetAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 160);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.dtpupdateDate);
            this.Controls.Add(this.txtCreditAsset);
            this.Controls.Add(this.txtPersonalAsset);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tx);
            this.Controls.Add(this.label1);
            this.Name = "FrmSetAsset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "资产配置 ";
            this.Load += new System.EventHandler(this.FrmSetHoldingRate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tx;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPersonalAsset;
        private System.Windows.Forms.TextBox txtCreditAsset;
        private System.Windows.Forms.DateTimePicker dtpupdateDate;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnCancel;
    }
}