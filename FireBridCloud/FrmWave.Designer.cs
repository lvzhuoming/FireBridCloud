namespace FireBridCloud
{
    partial class FrmWave
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.txt_filePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.btn_Run = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.myPlot = new NPlot.Windows.PlotSurface2D();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(241, 14);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFile.TabIndex = 0;
            this.btnSelectFile.Text = "选择文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // txt_filePath
            // 
            this.txt_filePath.Location = new System.Drawing.Point(86, 14);
            this.txt_filePath.Name = "txt_filePath";
            this.txt_filePath.Size = new System.Drawing.Size(149, 21);
            this.txt_filePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "追溯天数";
            // 
            // txtDays
            // 
            this.txtDays.Location = new System.Drawing.Point(86, 54);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(115, 21);
            this.txtDays.TabIndex = 4;
            this.txtDays.Text = "100";
            // 
            // btn_Run
            // 
            this.btn_Run.Location = new System.Drawing.Point(207, 52);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(75, 23);
            this.btn_Run.TabIndex = 5;
            this.btn_Run.Text = "run";
            this.btn_Run.UseVisualStyleBackColor = true;
            this.btn_Run.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "结果";
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(86, 93);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(115, 21);
            this.txtResult.TabIndex = 7;
            // 
            // myPlot
            // 
            this.myPlot.AutoScaleAutoGeneratedAxes = false;
            this.myPlot.AutoScaleTitle = false;
            this.myPlot.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.myPlot.DateTimeToolTip = false;
            this.myPlot.Legend = null;
            this.myPlot.LegendZOrder = -1;
            this.myPlot.Location = new System.Drawing.Point(0, 131);
            this.myPlot.Name = "myPlot";
            this.myPlot.RightMenu = null;
            this.myPlot.ShowCoordinates = true;
            this.myPlot.Size = new System.Drawing.Size(1110, 446);
            this.myPlot.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.myPlot.TabIndex = 8;
            this.myPlot.Text = "plotSurface2D1";
            this.myPlot.Title = "";
            this.myPlot.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.myPlot.XAxis1 = null;
            this.myPlot.XAxis2 = null;
            this.myPlot.YAxis1 = null;
            this.myPlot.YAxis2 = null;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1130, 243);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1130, 306);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "放大";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chart2
            // 
            chartArea3.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea3);
            this.chart2.Location = new System.Drawing.Point(14, 166);
            this.chart2.Name = "chart2";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series3.Name = "Series1";
            series3.YValuesPerPoint = 4;
            this.chart2.Series.Add(series3);
            this.chart2.Size = new System.Drawing.Size(1096, 300);
            this.chart2.TabIndex = 12;
            this.chart2.Text = "chart2";
            this.chart2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart2_MouseMove);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(702, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 13;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FrmWave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1246, 620);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myPlot);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Run);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_filePath);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.chart2);
            this.Name = "FrmWave";
            this.Text = "FrmWave";
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox txt_filePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.Button btn_Run;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        public NPlot.Windows.PlotSurface2D myPlot;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button3;
    }
}