namespace ChineseCalender
{
    partial class Calender
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calender));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMonthInfo = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAbout});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(749, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiAbout
            // 
            this.tsmiAbout.Name = "tsmiAbout";
            this.tsmiAbout.Size = new System.Drawing.Size(44, 21);
            this.tsmiAbout.Text = "关于";
            this.tsmiAbout.Click += new System.EventHandler(this.tsmiAbout_Click);
            // 
            // panelMonthInfo
            // 
            this.panelMonthInfo.BackColor = System.Drawing.Color.White;
            this.panelMonthInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMonthInfo.Location = new System.Drawing.Point(0, 25);
            this.panelMonthInfo.Name = "panelMonthInfo";
            this.panelMonthInfo.Size = new System.Drawing.Size(749, 469);
            this.panelMonthInfo.TabIndex = 1;
            this.panelMonthInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMonthInfo_Paint);
            this.panelMonthInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMonthInfo_MouseClick);
            this.panelMonthInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.panelMonthInfo_MouseDoubleClick);
            // 
            // Calender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 494);
            this.Controls.Add(this.panelMonthInfo);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Calender";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "万年历";
            this.Load += new System.EventHandler(this.Calender_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAbout;
        private System.Windows.Forms.Panel panelMonthInfo;
    }
}