namespace FireBridCloud
{
    partial class FrmKLine
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
            this.kLineControl1 = new KLineControl.KLineControl();
            this.SuspendLayout();
            // 
            // kLineControl1
            // 
            this.kLineControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kLineControl1.Location = new System.Drawing.Point(0, 0);
            this.kLineControl1.Name = "kLineControl1";
            this.kLineControl1.Size = new System.Drawing.Size(1093, 558);
            this.kLineControl1.TabIndex = 0;
            // 
            // FrmKLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 558);
            this.Controls.Add(this.kLineControl1);
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "FrmKLine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "自制K线图";
            this.ResumeLayout(false);

        }

        #endregion

        public KLineControl.KLineControl kLineControl1;



    }
}