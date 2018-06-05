namespace FireBridCloud
{
    partial class FrmStrategy
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
            this.dgvStrategy = new System.Windows.Forms.DataGridView();
            this.colStockNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colStockPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoldFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colBaseFlag = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBasePoint = new System.Windows.Forms.TextBox();
            this.txtBaseAmount = new System.Windows.Forms.TextBox();
            this.btngenrerate = new System.Windows.Forms.Button();
            this.txtClear = new System.Windows.Forms.Button();
            this.btnBottomAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecent = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategy)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStrategy
            // 
            this.dgvStrategy.AllowUserToAddRows = false;
            this.dgvStrategy.AllowUserToDeleteRows = false;
            this.dgvStrategy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStrategy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStockNo,
            this.colStockName,
            this.colStockPrice,
            this.colAmount,
            this.colHoldFlag,
            this.colBaseFlag});
            this.dgvStrategy.Location = new System.Drawing.Point(1, 41);
            this.dgvStrategy.Name = "dgvStrategy";
            this.dgvStrategy.RowTemplate.Height = 23;
            this.dgvStrategy.Size = new System.Drawing.Size(658, 269);
            this.dgvStrategy.TabIndex = 0;
            // 
            // colStockNo
            // 
            this.colStockNo.HeaderText = "代码";
            this.colStockNo.Name = "colStockNo";
            this.colStockNo.ReadOnly = true;
            // 
            // colStockName
            // 
            this.colStockName.HeaderText = "名称";
            this.colStockName.Name = "colStockName";
            this.colStockName.ReadOnly = true;
            // 
            // colStockPrice
            // 
            this.colStockPrice.HeaderText = "价格";
            this.colStockPrice.Name = "colStockPrice";
            // 
            // colAmount
            // 
            this.colAmount.HeaderText = "数量";
            this.colAmount.Name = "colAmount";
            // 
            // colHoldFlag
            // 
            this.colHoldFlag.HeaderText = "持有标记";
            this.colHoldFlag.Name = "colHoldFlag";
            // 
            // colBaseFlag
            // 
            this.colBaseFlag.FalseValue = "false";
            this.colBaseFlag.HeaderText = "基点标记";
            this.colBaseFlag.Name = "colBaseFlag";
            this.colBaseFlag.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colBaseFlag.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colBaseFlag.TrueValue = "true";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(129, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(377, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "基点";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "基点数";
            // 
            // txtBasePoint
            // 
            this.txtBasePoint.Location = new System.Drawing.Point(47, 9);
            this.txtBasePoint.Name = "txtBasePoint";
            this.txtBasePoint.Size = new System.Drawing.Size(100, 21);
            this.txtBasePoint.TabIndex = 5;
            // 
            // txtBaseAmount
            // 
            this.txtBaseAmount.Location = new System.Drawing.Point(210, 8);
            this.txtBaseAmount.Name = "txtBaseAmount";
            this.txtBaseAmount.Size = new System.Drawing.Size(105, 21);
            this.txtBaseAmount.TabIndex = 6;
            // 
            // btngenrerate
            // 
            this.btngenrerate.Location = new System.Drawing.Point(402, 7);
            this.btngenrerate.Name = "btngenrerate";
            this.btngenrerate.Size = new System.Drawing.Size(75, 23);
            this.btngenrerate.TabIndex = 7;
            this.btngenrerate.Text = "展开";
            this.btngenrerate.UseVisualStyleBackColor = true;
            this.btngenrerate.Click += new System.EventHandler(this.btngenrerate_Click);
            // 
            // txtClear
            // 
            this.txtClear.Location = new System.Drawing.Point(493, 7);
            this.txtClear.Name = "txtClear";
            this.txtClear.Size = new System.Drawing.Size(75, 23);
            this.txtClear.TabIndex = 8;
            this.txtClear.Text = "清空";
            this.txtClear.UseVisualStyleBackColor = true;
            this.txtClear.Click += new System.EventHandler(this.txtClear_Click);
            // 
            // btnBottomAdd
            // 
            this.btnBottomAdd.Location = new System.Drawing.Point(584, 7);
            this.btnBottomAdd.Name = "btnBottomAdd";
            this.btnBottomAdd.Size = new System.Drawing.Size(75, 23);
            this.btnBottomAdd.TabIndex = 9;
            this.btnBottomAdd.Text = "向下加";
            this.btnBottomAdd.UseVisualStyleBackColor = true;
            this.btnBottomAdd.Click += new System.EventHandler(this.btnBottomAdd_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "幅度";
            // 
            // txtPrecent
            // 
            this.txtPrecent.Location = new System.Drawing.Point(351, 8);
            this.txtPrecent.Name = "txtPrecent";
            this.txtPrecent.Size = new System.Drawing.Size(27, 21);
            this.txtPrecent.TabIndex = 11;
            this.txtPrecent.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(384, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "%";
            // 
            // FrmStrategy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 356);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPrecent);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBottomAdd);
            this.Controls.Add(this.txtClear);
            this.Controls.Add(this.btngenrerate);
            this.Controls.Add(this.txtBaseAmount);
            this.Controls.Add(this.txtBasePoint);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvStrategy);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStrategy";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "策略";
            this.Load += new System.EventHandler(this.FrmStrategy_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStrategy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStrategy;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBasePoint;
        private System.Windows.Forms.TextBox txtBaseAmount;
        private System.Windows.Forms.Button btngenrerate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStockPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAmount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colHoldFlag;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colBaseFlag;
        private System.Windows.Forms.Button txtClear;
        private System.Windows.Forms.Button btnBottomAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPrecent;
        private System.Windows.Forms.Label label4;
    }
}