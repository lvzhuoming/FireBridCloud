namespace FireBridCloud
{
    partial class FrmStockExpect
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtStockNo = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.numExpectPrice = new System.Windows.Forms.NumericUpDown();
            this.commonDataGridView1 = new FireBridCloud.CommonDataGridView();
            this.MenuStripForExpectStock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuItemToTop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_LowPriceLowVol = new System.Windows.Forms.Button();
            this.btnSaveExpectPrice = new System.Windows.Forms.Button();
            this.styleManager1 = new DevComponents.DotNetBar.StyleManager(this.components);
            this.btnBeTop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numExpectPrice)).BeginInit();
            this.MenuStripForExpectStock.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "代码";
            // 
            // txtStockNo
            // 
            this.txtStockNo.Location = new System.Drawing.Point(59, 13);
            this.txtStockNo.Name = "txtStockNo";
            this.txtStockNo.Size = new System.Drawing.Size(100, 21);
            this.txtStockNo.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(165, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(63, 46);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "添加 ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "候选价";
            // 
            // numExpectPrice
            // 
            this.numExpectPrice.DecimalPlaces = 2;
            this.numExpectPrice.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numExpectPrice.Location = new System.Drawing.Point(59, 45);
            this.numExpectPrice.Name = "numExpectPrice";
            this.numExpectPrice.Size = new System.Drawing.Size(100, 21);
            this.numExpectPrice.TabIndex = 6;
            // 
            // commonDataGridView1
            // 
            this.commonDataGridView1.Location = new System.Drawing.Point(-3, 75);
            this.commonDataGridView1.Name = "commonDataGridView1";
            this.commonDataGridView1.Size = new System.Drawing.Size(516, 302);
            this.commonDataGridView1.TabIndex = 0;
            // 
            // MenuStripForExpectStock
            // 
            this.MenuStripForExpectStock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItemToTop,
            this.MenuItemDelete});
            this.MenuStripForExpectStock.Name = "contextMenuStrip1";
            this.MenuStripForExpectStock.Size = new System.Drawing.Size(101, 48);
            // 
            // MenuItemToTop
            // 
            this.MenuItemToTop.Name = "MenuItemToTop";
            this.MenuItemToTop.Size = new System.Drawing.Size(100, 22);
            this.MenuItemToTop.Text = "置顶";
            this.MenuItemToTop.Click += new System.EventHandler(this.MenuItemToTop_Click);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.Size = new System.Drawing.Size(100, 22);
            this.MenuItemDelete.Text = "删除";
            this.MenuItemDelete.Click += new System.EventHandler(this.MenuItemDelete_Click);
            // 
            // btn_LowPriceLowVol
            // 
            this.btn_LowPriceLowVol.Location = new System.Drawing.Point(435, 13);
            this.btn_LowPriceLowVol.Name = "btn_LowPriceLowVol";
            this.btn_LowPriceLowVol.Size = new System.Drawing.Size(63, 46);
            this.btn_LowPriceLowVol.TabIndex = 7;
            this.btn_LowPriceLowVol.Text = "地量地价";
            this.btn_LowPriceLowVol.UseVisualStyleBackColor = true;
            this.btn_LowPriceLowVol.Click += new System.EventHandler(this.btn_LowPriceLowVol_Click);
            // 
            // btnSaveExpectPrice
            // 
            this.btnSaveExpectPrice.Location = new System.Drawing.Point(234, 13);
            this.btnSaveExpectPrice.Name = "btnSaveExpectPrice";
            this.btnSaveExpectPrice.Size = new System.Drawing.Size(63, 46);
            this.btnSaveExpectPrice.TabIndex = 8;
            this.btnSaveExpectPrice.Text = "保存期望价格";
            this.btnSaveExpectPrice.UseVisualStyleBackColor = true;
            this.btnSaveExpectPrice.Click += new System.EventHandler(this.btnSaveExpectPrice_Click);
            // 
            // styleManager1
            // 
            this.styleManager1.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2010Blue;
            this.styleManager1.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.White, System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(163)))), ((int)(((byte)(26))))));
            // 
            // btnBeTop
            // 
            this.btnBeTop.Location = new System.Drawing.Point(303, 13);
            this.btnBeTop.Name = "btnBeTop";
            this.btnBeTop.Size = new System.Drawing.Size(63, 46);
            this.btnBeTop.TabIndex = 9;
            this.btnBeTop.Text = "桌面顶端";
            this.btnBeTop.UseVisualStyleBackColor = true;
            this.btnBeTop.Click += new System.EventHandler(this.btnBeTop_Click);
            // 
            // FrmStockExpect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 397);
            this.Controls.Add(this.btnBeTop);
            this.Controls.Add(this.btnSaveExpectPrice);
            this.Controls.Add(this.btn_LowPriceLowVol);
            this.Controls.Add(this.numExpectPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtStockNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.commonDataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmStockExpect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "候选池";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStockExpect_FormClosing);
            this.Load += new System.EventHandler(this.FrmStockExpect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numExpectPrice)).EndInit();
            this.MenuStripForExpectStock.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CommonDataGridView commonDataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtStockNo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numExpectPrice;
        private System.Windows.Forms.ContextMenuStrip MenuStripForExpectStock;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private System.Windows.Forms.Button btn_LowPriceLowVol;
        private System.Windows.Forms.ToolStripMenuItem MenuItemToTop;
        private System.Windows.Forms.Button btnSaveExpectPrice;
        private DevComponents.DotNetBar.StyleManager styleManager1;
        private System.Windows.Forms.Button btnBeTop;
    }
}