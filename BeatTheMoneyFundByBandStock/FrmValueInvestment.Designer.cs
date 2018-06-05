namespace BeatTheMoneyFundByBandStock
{
    partial class FrmValueInvestment
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewYearEarn = new System.Windows.Forms.DataGridView();
            this.dataGridViewBuyStockRecord = new System.Windows.Forms.DataGridView();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnAddYearnEarn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStcokNo = new System.Windows.Forms.TextBox();
            this.txtStockName = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.txtEarn = new System.Windows.Forms.TextBox();
            this.btnDeleteBuyStockRecord = new System.Windows.Forms.Button();
            this.btnAddBuyStockRecord = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnProfitAnlayist = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtProfit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYearEarn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuyStockRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewYearEarn
            // 
            this.dataGridViewYearEarn.AllowUserToAddRows = false;
            this.dataGridViewYearEarn.AllowUserToDeleteRows = false;
            this.dataGridViewYearEarn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewYearEarn.Location = new System.Drawing.Point(13, 35);
            this.dataGridViewYearEarn.Name = "dataGridViewYearEarn";
            this.dataGridViewYearEarn.ReadOnly = true;
            this.dataGridViewYearEarn.RowTemplate.Height = 23;
            this.dataGridViewYearEarn.Size = new System.Drawing.Size(839, 347);
            this.dataGridViewYearEarn.TabIndex = 0;
            // 
            // dataGridViewBuyStockRecord
            // 
            this.dataGridViewBuyStockRecord.AllowUserToAddRows = false;
            this.dataGridViewBuyStockRecord.AllowUserToDeleteRows = false;
            this.dataGridViewBuyStockRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBuyStockRecord.Location = new System.Drawing.Point(13, 391);
            this.dataGridViewBuyStockRecord.Name = "dataGridViewBuyStockRecord";
            this.dataGridViewBuyStockRecord.ReadOnly = true;
            this.dataGridViewBuyStockRecord.RowTemplate.Height = 23;
            this.dataGridViewBuyStockRecord.Size = new System.Drawing.Size(929, 150);
            this.dataGridViewBuyStockRecord.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(13, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // btnAddYearnEarn
            // 
            this.btnAddYearnEarn.Location = new System.Drawing.Point(872, 298);
            this.btnAddYearnEarn.Name = "btnAddYearnEarn";
            this.btnAddYearnEarn.Size = new System.Drawing.Size(75, 23);
            this.btnAddYearnEarn.TabIndex = 3;
            this.btnAddYearnEarn.Text = "添加";
            this.btnAddYearnEarn.UseVisualStyleBackColor = true;
            this.btnAddYearnEarn.Click += new System.EventHandler(this.btnAddYearnEarn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(979, 298);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(888, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Year";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(888, 231);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Earn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(858, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "StockName";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(870, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "StockNo";
            // 
            // txtStcokNo
            // 
            this.txtStcokNo.Location = new System.Drawing.Point(930, 111);
            this.txtStcokNo.Name = "txtStcokNo";
            this.txtStcokNo.Size = new System.Drawing.Size(135, 21);
            this.txtStcokNo.TabIndex = 9;
            // 
            // txtStockName
            // 
            this.txtStockName.Location = new System.Drawing.Point(930, 155);
            this.txtStockName.Name = "txtStockName";
            this.txtStockName.Size = new System.Drawing.Size(135, 21);
            this.txtStockName.TabIndex = 10;
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(930, 191);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(135, 21);
            this.txtYear.TabIndex = 11;
            // 
            // txtEarn
            // 
            this.txtEarn.Location = new System.Drawing.Point(930, 228);
            this.txtEarn.Name = "txtEarn";
            this.txtEarn.Size = new System.Drawing.Size(135, 21);
            this.txtEarn.TabIndex = 12;
            // 
            // btnDeleteBuyStockRecord
            // 
            this.btnDeleteBuyStockRecord.Location = new System.Drawing.Point(974, 553);
            this.btnDeleteBuyStockRecord.Name = "btnDeleteBuyStockRecord";
            this.btnDeleteBuyStockRecord.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteBuyStockRecord.TabIndex = 14;
            this.btnDeleteBuyStockRecord.Text = "删除";
            this.btnDeleteBuyStockRecord.UseVisualStyleBackColor = true;
            this.btnDeleteBuyStockRecord.Click += new System.EventHandler(this.btnDeleteBuyStockRecord_Click);
            // 
            // btnAddBuyStockRecord
            // 
            this.btnAddBuyStockRecord.Location = new System.Drawing.Point(867, 553);
            this.btnAddBuyStockRecord.Name = "btnAddBuyStockRecord";
            this.btnAddBuyStockRecord.Size = new System.Drawing.Size(75, 23);
            this.btnAddBuyStockRecord.TabIndex = 13;
            this.btnAddBuyStockRecord.Text = "添加";
            this.btnAddBuyStockRecord.UseVisualStyleBackColor = true;
            this.btnAddBuyStockRecord.Click += new System.EventHandler(this.btnAddBuyStockRecord_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(144, 558);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 15;
            this.label5.Text = "StockNo";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(269, 558);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "StockName";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(424, 558);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "BuyPrice";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(563, 558);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "BuyAmount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(706, 558);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "BuyDate";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 594);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 21);
            this.textBox1.TabIndex = 20;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(245, 594);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(135, 21);
            this.textBox2.TabIndex = 21;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(386, 594);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(135, 21);
            this.textBox3.TabIndex = 22;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(527, 594);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(135, 21);
            this.textBox4.TabIndex = 23;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(680, 594);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(123, 21);
            this.dateTimePicker1.TabIndex = 25;
            // 
            // btnProfitAnlayist
            // 
            this.btnProfitAnlayist.Location = new System.Drawing.Point(930, 35);
            this.btnProfitAnlayist.Name = "btnProfitAnlayist";
            this.btnProfitAnlayist.Size = new System.Drawing.Size(75, 23);
            this.btnProfitAnlayist.TabIndex = 26;
            this.btnProfitAnlayist.Text = "利润分析";
            this.btnProfitAnlayist.UseVisualStyleBackColor = true;
            this.btnProfitAnlayist.Click += new System.EventHandler(this.btnProfitAnlayist_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(876, 263);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 27;
            this.label10.Text = "Profit";
            // 
            // txtProfit
            // 
            this.txtProfit.Location = new System.Drawing.Point(930, 260);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.Size = new System.Drawing.Size(135, 21);
            this.txtProfit.TabIndex = 28;
            // 
            // FrmValueInvestment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 627);
            this.Controls.Add(this.txtProfit);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnProfitAnlayist);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnDeleteBuyStockRecord);
            this.Controls.Add(this.btnAddBuyStockRecord);
            this.Controls.Add(this.txtEarn);
            this.Controls.Add(this.txtYear);
            this.Controls.Add(this.txtStockName);
            this.Controls.Add(this.txtStcokNo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAddYearnEarn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dataGridViewBuyStockRecord);
            this.Controls.Add(this.dataGridViewYearEarn);
            this.Name = "FrmValueInvestment";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "论如何通过银行股战胜货币基金";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewYearEarn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBuyStockRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewYearEarn;
        private System.Windows.Forms.DataGridView dataGridViewBuyStockRecord;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnAddYearnEarn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStcokNo;
        private System.Windows.Forms.TextBox txtStockName;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.TextBox txtEarn;
        private System.Windows.Forms.Button btnDeleteBuyStockRecord;
        private System.Windows.Forms.Button btnAddBuyStockRecord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btnProfitAnlayist;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtProfit;
    }
}

