namespace FireBridCloud
{
    partial class FrmStockHoldAdd
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.txtStockNo = new System.Windows.Forms.TextBox();
            this.txtStockName = new System.Windows.Forms.TextBox();
            this.txtHoldAmount = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.dtpupdateDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "股票代码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "股票名称";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "持仓股数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "股价";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "更新日期";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(147, 187);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(44, 187);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 10;
            this.btnCommit.Text = "提交";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // txtStockNo
            // 
            this.txtStockNo.Location = new System.Drawing.Point(81, 12);
            this.txtStockNo.Name = "txtStockNo";
            this.txtStockNo.Size = new System.Drawing.Size(155, 21);
            this.txtStockNo.TabIndex = 12;
            // 
            // txtStockName
            // 
            this.txtStockName.Location = new System.Drawing.Point(81, 50);
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(155, 21);
            this.txtStockName.TabIndex = 13;
            // 
            // txtHoldAmount
            // 
            this.txtHoldAmount.Location = new System.Drawing.Point(81, 115);
            this.txtHoldAmount.Name = "txtHoldAmount";
            this.txtHoldAmount.Size = new System.Drawing.Size(155, 21);
            this.txtHoldAmount.TabIndex = 14;
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(81, 82);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(155, 21);
            this.txtPrice.TabIndex = 15;
            // 
            // dtpupdateDate
            // 
            this.dtpupdateDate.Location = new System.Drawing.Point(81, 147);
            this.dtpupdateDate.Name = "dtpupdateDate";
            this.dtpupdateDate.Size = new System.Drawing.Size(155, 21);
            this.dtpupdateDate.TabIndex = 16;
            // 
            // FrmStockHoldAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 221);
            this.Controls.Add(this.dtpupdateDate);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtHoldAmount);
            this.Controls.Add(this.txtStockName);
            this.Controls.Add(this.txtStockNo);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmStockHoldAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "持仓";
            this.Load += new System.EventHandler(this.FrmStockHoldAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.TextBox txtStockNo;
        private System.Windows.Forms.TextBox txtStockName;
        private System.Windows.Forms.TextBox txtHoldAmount;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DateTimePicker dtpupdateDate;
    }
}