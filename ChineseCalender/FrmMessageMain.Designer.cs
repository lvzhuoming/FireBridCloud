namespace ChineseCalender
{
    partial class FrmMessageMain
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
            this.btnShowAndDisappearMessages = new System.Windows.Forms.Button();
            this.btnMouseShowMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnShowAndDisappearMessages
            // 
            this.btnShowAndDisappearMessages.Location = new System.Drawing.Point(53, 43);
            this.btnShowAndDisappearMessages.Name = "btnShowAndDisappearMessages";
            this.btnShowAndDisappearMessages.Size = new System.Drawing.Size(94, 23);
            this.btnShowAndDisappearMessages.TabIndex = 1;
            this.btnShowAndDisappearMessages.Text = "右下角慢慢弹出";
            this.btnShowAndDisappearMessages.UseVisualStyleBackColor = true;
            this.btnShowAndDisappearMessages.Click += new System.EventHandler(this.btnShowAndDisappearMessages_Click);
            // 
            // btnMouseShowMessage
            // 
            this.btnMouseShowMessage.Location = new System.Drawing.Point(53, 95);
            this.btnMouseShowMessage.Name = "btnMouseShowMessage";
            this.btnMouseShowMessage.Size = new System.Drawing.Size(75, 23);
            this.btnMouseShowMessage.TabIndex = 2;
            this.btnMouseShowMessage.Text = "慢慢变淡";
            this.btnMouseShowMessage.UseVisualStyleBackColor = true;
            this.btnMouseShowMessage.Click += new System.EventHandler(this.btnMouseShowMessage_Click);
            // 
            // FrmMessageMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.btnMouseShowMessage);
            this.Controls.Add(this.btnShowAndDisappearMessages);
            this.Name = "FrmMessageMain";
            this.Text = "FrmMessageMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShowAndDisappearMessages;
        private System.Windows.Forms.Button btnMouseShowMessage;
    }
}