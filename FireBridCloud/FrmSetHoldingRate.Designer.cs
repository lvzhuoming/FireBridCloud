namespace FireBridCloud
{
    partial class FrmSetHoldingRate
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSZhighest = new System.Windows.Forms.TextBox();
            this.txtSZlowest = new System.Windows.Forms.TextBox();
            this.txtSZnow = new System.Windows.Forms.TextBox();
            this.dtpSZupdateDate = new System.Windows.Forms.DateTimePicker();
            this.btnCommit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "上证最高价";
            // 
            // tx
            // 
            this.tx.AutoSize = true;
            this.tx.Location = new System.Drawing.Point(12, 54);
            this.tx.Name = "tx";
            this.tx.Size = new System.Drawing.Size(65, 12);
            this.tx.TabIndex = 1;
            this.tx.Text = "上证最低价";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "上证当前价";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "更新日期";
            // 
            // txtSZhighest
            // 
            this.txtSZhighest.Location = new System.Drawing.Point(82, 14);
            this.txtSZhighest.Name = "txtSZhighest";
            this.txtSZhighest.Size = new System.Drawing.Size(111, 21);
            this.txtSZhighest.TabIndex = 4;
            // 
            // txtSZlowest
            // 
            this.txtSZlowest.Location = new System.Drawing.Point(82, 50);
            this.txtSZlowest.Name = "txtSZlowest";
            this.txtSZlowest.Size = new System.Drawing.Size(111, 21);
            this.txtSZlowest.TabIndex = 5;
            // 
            // txtSZnow
            // 
            this.txtSZnow.Location = new System.Drawing.Point(82, 85);
            this.txtSZnow.Name = "txtSZnow";
            this.txtSZnow.Size = new System.Drawing.Size(111, 21);
            this.txtSZnow.TabIndex = 6;
            // 
            // dtpSZupdateDate
            // 
            this.dtpSZupdateDate.Location = new System.Drawing.Point(82, 118);
            this.dtpSZupdateDate.Name = "dtpSZupdateDate";
            this.dtpSZupdateDate.Size = new System.Drawing.Size(110, 21);
            this.dtpSZupdateDate.TabIndex = 7;
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(14, 151);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 8;
            this.btnCommit.Text = "提交";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(117, 151);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmSetHoldingRate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(204, 180);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.dtpSZupdateDate);
            this.Controls.Add(this.txtSZnow);
            this.Controls.Add(this.txtSZlowest);
            this.Controls.Add(this.txtSZhighest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tx);
            this.Controls.Add(this.label1);
            this.Name = "FrmSetHoldingRate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "持仓配置 ";
            this.Load += new System.EventHandler(this.FrmSetHoldingRate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tx;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSZhighest;
        private System.Windows.Forms.TextBox txtSZlowest;
        private System.Windows.Forms.TextBox txtSZnow;
        private System.Windows.Forms.DateTimePicker dtpSZupdateDate;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Button btnCancel;
    }
}