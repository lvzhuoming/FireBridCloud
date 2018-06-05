namespace FireBridCloud
{
    partial class FrmStockChart
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNow = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabDay = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabWeek = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabMonth = new System.Windows.Forms.TabPage();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tabNow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabDay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabWeek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNow);
            this.tabControl1.Controls.Add(this.tabDay);
            this.tabControl1.Controls.Add(this.tabWeek);
            this.tabControl1.Controls.Add(this.tabMonth);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(544, 342);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabNow
            // 
            this.tabNow.Controls.Add(this.pictureBox1);
            this.tabNow.Location = new System.Drawing.Point(4, 22);
            this.tabNow.Name = "tabNow";
            this.tabNow.Padding = new System.Windows.Forms.Padding(3);
            this.tabNow.Size = new System.Drawing.Size(536, 316);
            this.tabNow.TabIndex = 0;
            this.tabNow.Text = "分时";
            this.tabNow.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(530, 310);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabDay
            // 
            this.tabDay.Controls.Add(this.pictureBox2);
            this.tabDay.Location = new System.Drawing.Point(4, 22);
            this.tabDay.Name = "tabDay";
            this.tabDay.Padding = new System.Windows.Forms.Padding(3);
            this.tabDay.Size = new System.Drawing.Size(536, 316);
            this.tabDay.TabIndex = 1;
            this.tabDay.Text = "日K";
            this.tabDay.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(3, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(530, 310);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // tabWeek
            // 
            this.tabWeek.Controls.Add(this.pictureBox3);
            this.tabWeek.Location = new System.Drawing.Point(4, 22);
            this.tabWeek.Name = "tabWeek";
            this.tabWeek.Size = new System.Drawing.Size(536, 316);
            this.tabWeek.TabIndex = 2;
            this.tabWeek.Text = "周K";
            this.tabWeek.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(536, 316);
            this.pictureBox3.TabIndex = 1;
            this.pictureBox3.TabStop = false;
            // 
            // tabMonth
            // 
            this.tabMonth.Controls.Add(this.pictureBox4);
            this.tabMonth.Location = new System.Drawing.Point(4, 22);
            this.tabMonth.Name = "tabMonth";
            this.tabMonth.Size = new System.Drawing.Size(536, 316);
            this.tabMonth.TabIndex = 3;
            this.tabMonth.Text = "月K";
            this.tabMonth.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox4.Location = new System.Drawing.Point(0, 0);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(536, 316);
            this.pictureBox4.TabIndex = 1;
            this.pictureBox4.TabStop = false;
            // 
            // FrmStockChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 342);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmStockChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图表";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmStockChart_FormClosing);
            this.Load += new System.EventHandler(this.FrmStockChart_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabNow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabDay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabWeek.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabMonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNow;
        private System.Windows.Forms.TabPage tabDay;
        private System.Windows.Forms.TabPage tabWeek;
        private System.Windows.Forms.TabPage tabMonth;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
    }
}