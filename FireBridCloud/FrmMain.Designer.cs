namespace FireBridCloud
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_HoldStock = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtHoldAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnStockBw = new DevComponents.DotNetBar.ButtonX();
            this.label4 = new System.Windows.Forms.Label();
            this.txtRemainAsset = new System.Windows.Forms.TextBox();
            this.txtHoldAsset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.statusStripForMain = new System.Windows.Forms.StatusStrip();
            this.tsOnline = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssCYB = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSZ = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssSH = new System.Windows.Forms.ToolStripStatusLabel();
            this.MenuStripForHoldStock = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemModify = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.策略ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuItemKLineChart = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSetAsset = new DevComponents.DotNetBar.ButtonX();
            this.btnDbSet = new DevComponents.DotNetBar.ButtonX();
            this.txtAsset = new System.Windows.Forms.TextBox();
            this.txtHoldRef = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSetHoldRate = new DevComponents.DotNetBar.ButtonX();
            this.txtAssetRef = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWave = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnValueInvest = new DevComponents.DotNetBar.ButtonX();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnExpectStock = new DevComponents.DotNetBar.ButtonX();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chartlet1 = new FanG.Chartlet();
            this.btnNotice = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoldStock)).BeginInit();
            this.panel2.SuspendLayout();
            this.statusStripForMain.SuspendLayout();
            this.MenuStripForHoldStock.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_HoldStock);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 259);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "持仓";
            // 
            // dgv_HoldStock
            // 
            this.dgv_HoldStock.AllowUserToAddRows = false;
            this.dgv_HoldStock.AllowUserToDeleteRows = false;
            this.dgv_HoldStock.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_HoldStock.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv_HoldStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_HoldStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_HoldStock.Location = new System.Drawing.Point(3, 57);
            this.dgv_HoldStock.Name = "dgv_HoldStock";
            this.dgv_HoldStock.ReadOnly = true;
            this.dgv_HoldStock.RowTemplate.Height = 23;
            this.dgv_HoldStock.Size = new System.Drawing.Size(735, 199);
            this.dgv_HoldStock.TabIndex = 9;
            this.dgv_HoldStock.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_HoldStock_CellDoubleClick);
            this.dgv_HoldStock.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_HoldStock_CellMouseDown);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNotice);
            this.panel2.Controls.Add(this.txtHoldAdd);
            this.panel2.Controls.Add(this.btnStockBw);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtRemainAsset);
            this.panel2.Controls.Add(this.txtHoldAsset);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(735, 40);
            this.panel2.TabIndex = 18;
            // 
            // txtHoldAdd
            // 
            this.txtHoldAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.txtHoldAdd.Location = new System.Drawing.Point(5, 10);
            this.txtHoldAdd.Name = "txtHoldAdd";
            this.txtHoldAdd.Size = new System.Drawing.Size(75, 23);
            this.txtHoldAdd.TabIndex = 10;
            this.txtHoldAdd.Text = "新增";
            this.txtHoldAdd.Click += new System.EventHandler(this.txtHoldAdd_Click);
            // 
            // btnStockBw
            // 
            this.btnStockBw.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStockBw.Location = new System.Drawing.Point(375, 9);
            this.btnStockBw.Name = "btnStockBw";
            this.btnStockBw.Size = new System.Drawing.Size(95, 23);
            this.btnStockBw.TabIndex = 17;
            this.btnStockBw.Text = "断开后台线程";
            this.btnStockBw.Click += new System.EventHandler(this.btnStockBw_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "市值";
            // 
            // txtRemainAsset
            // 
            this.txtRemainAsset.Font = new System.Drawing.Font("宋体", 12F);
            this.txtRemainAsset.Location = new System.Drawing.Point(282, 8);
            this.txtRemainAsset.Name = "txtRemainAsset";
            this.txtRemainAsset.ReadOnly = true;
            this.txtRemainAsset.Size = new System.Drawing.Size(76, 26);
            this.txtRemainAsset.TabIndex = 14;
            this.txtRemainAsset.Text = "0";
            // 
            // txtHoldAsset
            // 
            this.txtHoldAsset.Font = new System.Drawing.Font("宋体", 12F);
            this.txtHoldAsset.Location = new System.Drawing.Point(132, 8);
            this.txtHoldAsset.Name = "txtHoldAsset";
            this.txtHoldAsset.ReadOnly = true;
            this.txtHoldAsset.Size = new System.Drawing.Size(76, 26);
            this.txtHoldAsset.TabIndex = 12;
            this.txtHoldAsset.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(223, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "可用额度";
            // 
            // statusStripForMain
            // 
            this.statusStripForMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOnline,
            this.tssCYB,
            this.tssSZ,
            this.tssSH});
            this.statusStripForMain.Location = new System.Drawing.Point(0, 361);
            this.statusStripForMain.Name = "statusStripForMain";
            this.statusStripForMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.statusStripForMain.Size = new System.Drawing.Size(755, 22);
            this.statusStripForMain.TabIndex = 16;
            this.statusStripForMain.Text = "statusStrip1";
            // 
            // tsOnline
            // 
            this.tsOnline.ForeColor = System.Drawing.Color.Red;
            this.tsOnline.Name = "tsOnline";
            this.tsOnline.Size = new System.Drawing.Size(44, 17);
            this.tsOnline.Text = "offline";
            // 
            // tssCYB
            // 
            this.tssCYB.Name = "tssCYB";
            this.tssCYB.Size = new System.Drawing.Size(100, 17);
            this.tssCYB.Text = "创业板 0.00 0.00";
            this.tssCYB.Click += new System.EventHandler(this.tssCYB_Click);
            // 
            // tssSZ
            // 
            this.tssSZ.Name = "tssSZ";
            this.tssSZ.Size = new System.Drawing.Size(88, 17);
            this.tssSZ.Text = "深证 0.00 0.00";
            this.tssSZ.Click += new System.EventHandler(this.tssSZ_Click);
            // 
            // tssSH
            // 
            this.tssSH.Name = "tssSH";
            this.tssSH.Size = new System.Drawing.Size(96, 17);
            this.tssSH.Text = "上证  0.00  0.00";
            this.tssSH.Click += new System.EventHandler(this.tssSH_Click);
            // 
            // MenuStripForHoldStock
            // 
            this.MenuStripForHoldStock.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemModify,
            this.MenuItemDelete,
            this.策略ToolStripMenuItem,
            this.MenuItemKLineChart});
            this.MenuStripForHoldStock.Name = "contextMenuStrip1";
            this.MenuStripForHoldStock.Size = new System.Drawing.Size(109, 92);
            // 
            // menuItemModify
            // 
            this.menuItemModify.Name = "menuItemModify";
            this.menuItemModify.Size = new System.Drawing.Size(108, 22);
            this.menuItemModify.Text = "修改";
            this.menuItemModify.Click += new System.EventHandler(this.ModifyHoldStock);
            // 
            // MenuItemDelete
            // 
            this.MenuItemDelete.Name = "MenuItemDelete";
            this.MenuItemDelete.Size = new System.Drawing.Size(108, 22);
            this.MenuItemDelete.Text = "删除";
            this.MenuItemDelete.Click += new System.EventHandler(this.DeletHoldStockItem_Click);
            // 
            // 策略ToolStripMenuItem
            // 
            this.策略ToolStripMenuItem.Name = "策略ToolStripMenuItem";
            this.策略ToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.策略ToolStripMenuItem.Text = "策略";
            this.策略ToolStripMenuItem.Click += new System.EventHandler(this.ShowStrategy);
            // 
            // MenuItemKLineChart
            // 
            this.MenuItemKLineChart.Name = "MenuItemKLineChart";
            this.MenuItemKLineChart.Size = new System.Drawing.Size(108, 22);
            this.MenuItemKLineChart.Text = "K线图";
            this.MenuItemKLineChart.Click += new System.EventHandler(this.MenuItemKLineChart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "资产";
            // 
            // btnSetAsset
            // 
            this.btnSetAsset.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetAsset.Location = new System.Drawing.Point(339, 10);
            this.btnSetAsset.Name = "btnSetAsset";
            this.btnSetAsset.Size = new System.Drawing.Size(75, 23);
            this.btnSetAsset.TabIndex = 5;
            this.btnSetAsset.Text = "设置";
            this.btnSetAsset.Click += new System.EventHandler(this.btnSetAsset_Click);
            // 
            // btnDbSet
            // 
            this.btnDbSet.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDbSet.Location = new System.Drawing.Point(420, 9);
            this.btnDbSet.Name = "btnDbSet";
            this.btnDbSet.Size = new System.Drawing.Size(124, 23);
            this.btnDbSet.TabIndex = 3;
            this.btnDbSet.Text = "设置数据库路径";
            this.btnDbSet.Click += new System.EventHandler(this.btnDbSet_Click);
            // 
            // txtAsset
            // 
            this.txtAsset.Font = new System.Drawing.Font("宋体", 12F);
            this.txtAsset.Location = new System.Drawing.Point(264, 9);
            this.txtAsset.Name = "txtAsset";
            this.txtAsset.ReadOnly = true;
            this.txtAsset.Size = new System.Drawing.Size(69, 26);
            this.txtAsset.TabIndex = 6;
            this.txtAsset.Text = "0.00";
            // 
            // txtHoldRef
            // 
            this.txtHoldRef.Font = new System.Drawing.Font("宋体", 12F);
            this.txtHoldRef.Location = new System.Drawing.Point(62, 10);
            this.txtHoldRef.Name = "txtHoldRef";
            this.txtHoldRef.ReadOnly = true;
            this.txtHoldRef.Size = new System.Drawing.Size(76, 26);
            this.txtHoldRef.TabIndex = 2;
            this.txtHoldRef.Text = "%0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "资产参考";
            // 
            // btnSetHoldRate
            // 
            this.btnSetHoldRate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSetHoldRate.Location = new System.Drawing.Point(141, 11);
            this.btnSetHoldRate.Name = "btnSetHoldRate";
            this.btnSetHoldRate.Size = new System.Drawing.Size(75, 23);
            this.btnSetHoldRate.TabIndex = 1;
            this.btnSetHoldRate.Text = "设置";
            this.btnSetHoldRate.Click += new System.EventHandler(this.btnSetHoldRate_Click);
            // 
            // txtAssetRef
            // 
            this.txtAssetRef.Font = new System.Drawing.Font("宋体", 12F);
            this.txtAssetRef.Location = new System.Drawing.Point(62, 50);
            this.txtAssetRef.Name = "txtAssetRef";
            this.txtAssetRef.ReadOnly = true;
            this.txtAssetRef.Size = new System.Drawing.Size(76, 26);
            this.txtAssetRef.TabIndex = 8;
            this.txtAssetRef.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "持仓参考";
            // 
            // btnWave
            // 
            this.btnWave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnWave.Location = new System.Drawing.Point(144, 52);
            this.btnWave.Name = "btnWave";
            this.btnWave.Size = new System.Drawing.Size(75, 23);
            this.btnWave.TabIndex = 10;
            this.btnWave.Text = "波动性分析";
            this.btnWave.Click += new System.EventHandler(this.btnWave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonX1);
            this.panel1.Controls.Add(this.btnValueInvest);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btnExpectStock);
            this.panel1.Controls.Add(this.btnWave);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtAssetRef);
            this.panel1.Controls.Add(this.btnSetHoldRate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtHoldRef);
            this.panel1.Controls.Add(this.txtAsset);
            this.panel1.Controls.Add(this.btnDbSet);
            this.panel1.Controls.Add(this.btnSetAsset);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(741, 92);
            this.panel1.TabIndex = 10;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.Location = new System.Drawing.Point(420, 53);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(106, 23);
            this.buttonX1.TabIndex = 14;
            this.buttonX1.Text = "穷举获取股票代码";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnValueInvest
            // 
            this.btnValueInvest.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnValueInvest.Location = new System.Drawing.Point(327, 53);
            this.btnValueInvest.Name = "btnValueInvest";
            this.btnValueInvest.Size = new System.Drawing.Size(75, 23);
            this.btnValueInvest.TabIndex = 13;
            this.btnValueInvest.Text = "价值投资";
            this.btnValueInvest.Click += new System.EventHandler(this.btnValueInvest_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(585, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(156, 92);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "日盈利";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 25F);
            this.label6.Location = new System.Drawing.Point(24, 30);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 34);
            this.label6.TabIndex = 0;
            this.label6.Text = "0";
            // 
            // btnExpectStock
            // 
            this.btnExpectStock.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExpectStock.Location = new System.Drawing.Point(231, 52);
            this.btnExpectStock.Name = "btnExpectStock";
            this.btnExpectStock.Size = new System.Drawing.Size(75, 23);
            this.btnExpectStock.TabIndex = 11;
            this.btnExpectStock.Text = "候选池";
            this.btnExpectStock.Click += new System.EventHandler(this.btnExpectStock_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 383);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(747, 357);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartlet1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(747, 357);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chartlet1
            // 
            this.chartlet1.Alpha3D = ((byte)(255));
            this.chartlet1.AppearanceStyle = FanG.Chartlet.AppearanceStyles.Pie_2D_Breeze_NoCrystal_NoGlow_NoBorder;
            this.chartlet1.AutoBarWidth = true;
            this.chartlet1.Background.Highlight = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(238)))));
            this.chartlet1.Background.Lowlight = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.chartlet1.Background.Paper = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.chartlet1.BaseLineX = -0.830213D;
            this.chartlet1.ChartTitle.BackColor = System.Drawing.Color.White;
            this.chartlet1.ChartTitle.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.ChartTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.chartlet1.ChartTitle.OffsetY = 0;
            this.chartlet1.ChartTitle.Show = true;
            this.chartlet1.ChartTitle.Text = "Please bind a data source with BindChartData()!";
            this.chartlet1.ChartType = FanG.Chartlet.ChartTypes.Pie;
            this.chartlet1.ClientClick = "";
            this.chartlet1.ClientMouseMove = "";
            this.chartlet1.ClientMouseOut = "";
            this.chartlet1.ClientMouseOver = "";
            this.chartlet1.ClientUseMap = "";
            this.chartlet1.Colorful = true;
            this.chartlet1.ColorGuider.BackColor = System.Drawing.Color.White;
            this.chartlet1.ColorGuider.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.ColorGuider.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.ColorGuider.Show = true;
            this.chartlet1.CopyrightText = "Provided by Chartlet.cn";
            this.chartlet1.Crystal.Contraction = 1;
            this.chartlet1.Crystal.CoverFull = true;
            this.chartlet1.Crystal.Direction = FanG.Chartlet.Direction.TopBottom;
            this.chartlet1.Crystal.Enable = false;
            this.chartlet1.Depth3D = 10;
            this.chartlet1.Dimension = FanG.Chartlet.ChartDimensions.Chart2D;
            this.chartlet1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartlet1.Fill.Color1 = System.Drawing.Color.Empty;
            this.chartlet1.Fill.Color2 = System.Drawing.Color.Empty;
            this.chartlet1.Fill.Color3 = System.Drawing.Color.Empty;
            this.chartlet1.Fill.ColorStyle = FanG.Chartlet.ColorStyles.Breeze;
            this.chartlet1.Fill.ShiftStep = 0;
            this.chartlet1.Fill.TextureEnable = false;
            this.chartlet1.Fill.TextureStyle = System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal;
            this.chartlet1.GroupSize = 0;
            this.chartlet1.ImageBorder = 0;
            this.chartlet1.ImageFolder = "Chartlet";
            this.chartlet1.ImageStyle = "";
            this.chartlet1.InflateBottom = 0;
            this.chartlet1.InflateLeft = 0;
            this.chartlet1.InflateRight = 0;
            this.chartlet1.InflateTop = 0;
            this.chartlet1.LineConnectionRadius = 10;
            this.chartlet1.LineConnectionType = FanG.Chartlet.LineConnectionTypes.Round;
            this.chartlet1.Location = new System.Drawing.Point(3, 3);
            this.chartlet1.MaxValueY = 0D;
            this.chartlet1.MinValueY = 0D;
            this.chartlet1.Name = "chartlet1";
            this.chartlet1.OutputFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
            this.chartlet1.RootPath = "C:\\\\";
            this.chartlet1.RoundRadius = 2;
            this.chartlet1.RoundRectangle = false;
            this.chartlet1.Shadow.Alpha = ((byte)(192));
            this.chartlet1.Shadow.Angle = 60F;
            this.chartlet1.Shadow.Color = System.Drawing.Color.Black;
            this.chartlet1.Shadow.Distance = 0;
            this.chartlet1.Shadow.Enable = false;
            this.chartlet1.Shadow.Hollow = false;
            this.chartlet1.Shadow.Radius = 3;
            this.chartlet1.ShowCopyright = false;
            this.chartlet1.ShowErrorInfo = true;
            this.chartlet1.Size = new System.Drawing.Size(741, 351);
            this.chartlet1.SpecLine.Color = System.Drawing.Color.Black;
            this.chartlet1.SpecLine.EnableTexture = false;
            this.chartlet1.SpecLine.HighLimit = 0;
            this.chartlet1.SpecLine.LowLimit = 0;
            this.chartlet1.SpecLine.Show = false;
            this.chartlet1.SpecLine.TextureStyle = System.Drawing.Drawing2D.HatchStyle.LargeGrid;
            this.chartlet1.SpecLine.Width = 1;
            this.chartlet1.Stroke.Color1 = System.Drawing.Color.White;
            this.chartlet1.Stroke.Color2 = System.Drawing.Color.Empty;
            this.chartlet1.Stroke.Color3 = System.Drawing.Color.Empty;
            this.chartlet1.Stroke.ColorStyle = FanG.Chartlet.ColorStyles.None;
            this.chartlet1.Stroke.ShiftStep = 0;
            this.chartlet1.Stroke.TextureEnable = false;
            this.chartlet1.Stroke.TextureStyle = System.Drawing.Drawing2D.HatchStyle.DarkUpwardDiagonal;
            this.chartlet1.Stroke.Width = 0;
            this.chartlet1.TabIndex = 11;
            this.chartlet1.Tips.BackColor = System.Drawing.Color.White;
            this.chartlet1.Tips.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.Tips.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.Tips.Show = true;
            this.chartlet1.Trend.End = new System.DateTime(2017, 11, 10, 17, 12, 16, 0);
            this.chartlet1.Trend.EndString = "2017-11-10 17:12:16";
            this.chartlet1.Trend.Start = new System.DateTime(2017, 11, 10, 17, 12, 16, 0);
            this.chartlet1.Trend.StartString = "2017-11-10 17:12:16";
            this.chartlet1.Trend.TimeSpan = FanG.Chartlet.TimeSpanTypes.Hour;
            this.chartlet1.Trend.ValueFormat = "hh:mm";
            this.chartlet1.XLabels.BackColor = System.Drawing.Color.White;
            this.chartlet1.XLabels.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.XLabels.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.XLabels.LabelCount = 5;
            this.chartlet1.XLabels.RotateAngle = 30F;
            this.chartlet1.XLabels.SampleSize = 1;
            this.chartlet1.XLabels.Show = true;
            this.chartlet1.XLabels.UnitFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.XLabels.UnitText = "XLabelsUnit";
            this.chartlet1.XLabels.ValueFormat = "0.0";
            this.chartlet1.YLabels.BackColor = System.Drawing.Color.White;
            this.chartlet1.YLabels.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.YLabels.ForeColor = System.Drawing.Color.Black;
            this.chartlet1.YLabels.LabelCount = 5;
            this.chartlet1.YLabels.Show = true;
            this.chartlet1.YLabels.UnitFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.chartlet1.YLabels.UnitText = "YLabelsUnit";
            this.chartlet1.YLabels.ValueFormat = "0.0";
            // 
            // btnNotice
            // 
            this.btnNotice.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNotice.Location = new System.Drawing.Point(627, 10);
            this.btnNotice.Name = "btnNotice";
            this.btnNotice.Size = new System.Drawing.Size(95, 23);
            this.btnNotice.TabIndex = 18;
            this.btnNotice.Text = "日历提醒";
            this.btnNotice.Click += new System.EventHandler(this.btnNotice_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 383);
            this.Controls.Add(this.statusStripForMain);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "火鸟云";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_HoldStock)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.statusStripForMain.ResumeLayout(false);
            this.statusStripForMain.PerformLayout();
            this.MenuStripForHoldStock.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.ButtonX txtHoldAdd;
        private System.Windows.Forms.TextBox txtHoldAsset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRemainAsset;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.StatusStrip statusStripForMain;
        private System.Windows.Forms.ToolStripStatusLabel tsOnline;
        private System.Windows.Forms.ContextMenuStrip MenuStripForHoldStock;
        private System.Windows.Forms.ToolStripMenuItem MenuItemDelete;
        private DevComponents.DotNetBar.ButtonX btnStockBw;
        private System.Windows.Forms.ToolStripMenuItem menuItemModify;
        private System.Windows.Forms.ToolStripMenuItem 策略ToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.ButtonX btnSetAsset;
        private DevComponents.DotNetBar.ButtonX btnDbSet;
        private System.Windows.Forms.TextBox txtAsset;
        private System.Windows.Forms.TextBox txtHoldRef;
        private System.Windows.Forms.Label label3;
        private DevComponents.DotNetBar.ButtonX btnSetHoldRate;
        private System.Windows.Forms.TextBox txtAssetRef;
        private System.Windows.Forms.Label label1;
        private DevComponents.DotNetBar.ButtonX btnWave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel tssCYB;
        private System.Windows.Forms.ToolStripStatusLabel tssSZ;
        private System.Windows.Forms.ToolStripStatusLabel tssSH;
        private DevComponents.DotNetBar.ButtonX btnExpectStock;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem MenuItemKLineChart;
        private DevComponents.DotNetBar.ButtonX btnValueInvest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_HoldStock;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private FanG.Chartlet chartlet1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnNotice;

    }
}

