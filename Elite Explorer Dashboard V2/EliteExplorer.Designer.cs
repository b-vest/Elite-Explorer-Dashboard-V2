namespace Elite_Explorer_Dashboard_V2
{
    partial class EliteExplorer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridHeader = new System.Windows.Forms.DataGridView();
            this.ColumnEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCommanderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShipRegistration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFuelLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFuelScooped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCurrentSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTargetSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCruiseMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.labelScreenshotSystem = new System.Windows.Forms.Label();
            this.labelScreenshotTimestamp = new System.Windows.Forms.Label();
            this.labelStaticScreenshotText = new System.Windows.Forms.Label();
            this.pictureBoxConverted = new System.Windows.Forms.PictureBox();
            this.listBoxDebugOutput = new System.Windows.Forms.ListBox();
            this.dataGridViewBodies = new System.Windows.Forms.DataGridView();
            this.BodyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Landable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BpdyClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Atmosphere = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gravity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodyRadius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sigs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BodyDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FSC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SRV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridStars = new System.Windows.Forms.DataGridView();
            this.StarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AgeMY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Radius = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TempK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Distance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLogFilePath = new System.Windows.Forms.TextBox();
            this.timerCheckLog = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConverted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBodies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStars)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridHeader
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dataGridHeader.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridHeader.BackgroundColor = System.Drawing.Color.Black;
            this.dataGridHeader.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridHeader.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHeader.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnEvent,
            this.ColumnCommanderName,
            this.ColumnShipRegistration,
            this.ColumnFuelLevel,
            this.ColumnFuelScooped,
            this.ColumnCurrentSystem,
            this.ColumnTargetSystem,
            this.ColumnJumps,
            this.ColumnCruiseMode});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridHeader.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridHeader.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridHeader.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dataGridHeader.Location = new System.Drawing.Point(6, 6);
            this.dataGridHeader.Name = "dataGridHeader";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridHeader.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridHeader.RowHeadersVisible = false;
            this.dataGridHeader.RowHeadersWidth = 51;
            this.dataGridHeader.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Black;
            this.dataGridHeader.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.dataGridHeader.RowTemplate.Height = 29;
            this.dataGridHeader.Size = new System.Drawing.Size(1980, 106);
            this.dataGridHeader.TabIndex = 0;
            // 
            // ColumnEvent
            // 
            this.ColumnEvent.HeaderText = "Event";
            this.ColumnEvent.MinimumWidth = 6;
            this.ColumnEvent.Name = "ColumnEvent";
            this.ColumnEvent.ReadOnly = true;
            this.ColumnEvent.Width = 200;
            // 
            // ColumnCommanderName
            // 
            this.ColumnCommanderName.HeaderText = "Commander";
            this.ColumnCommanderName.MinimumWidth = 6;
            this.ColumnCommanderName.Name = "ColumnCommanderName";
            this.ColumnCommanderName.ReadOnly = true;
            this.ColumnCommanderName.Width = 120;
            // 
            // ColumnShipRegistration
            // 
            this.ColumnShipRegistration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnShipRegistration.HeaderText = "Ship Registration";
            this.ColumnShipRegistration.MinimumWidth = 300;
            this.ColumnShipRegistration.Name = "ColumnShipRegistration";
            this.ColumnShipRegistration.ReadOnly = true;
            // 
            // ColumnFuelLevel
            // 
            this.ColumnFuelLevel.HeaderText = "Fuel";
            this.ColumnFuelLevel.MinimumWidth = 6;
            this.ColumnFuelLevel.Name = "ColumnFuelLevel";
            this.ColumnFuelLevel.ReadOnly = true;
            this.ColumnFuelLevel.Width = 125;
            // 
            // ColumnFuelScooped
            // 
            this.ColumnFuelScooped.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnFuelScooped.HeaderText = "Fuel Scooped";
            this.ColumnFuelScooped.MinimumWidth = 6;
            this.ColumnFuelScooped.Name = "ColumnFuelScooped";
            this.ColumnFuelScooped.ReadOnly = true;
            this.ColumnFuelScooped.Width = 126;
            // 
            // ColumnCurrentSystem
            // 
            this.ColumnCurrentSystem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCurrentSystem.HeaderText = "Current System";
            this.ColumnCurrentSystem.MinimumWidth = 6;
            this.ColumnCurrentSystem.Name = "ColumnCurrentSystem";
            this.ColumnCurrentSystem.ReadOnly = true;
            // 
            // ColumnTargetSystem
            // 
            this.ColumnTargetSystem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTargetSystem.HeaderText = "Target System";
            this.ColumnTargetSystem.MinimumWidth = 6;
            this.ColumnTargetSystem.Name = "ColumnTargetSystem";
            this.ColumnTargetSystem.ReadOnly = true;
            // 
            // ColumnJumps
            // 
            this.ColumnJumps.HeaderText = "Jumps";
            this.ColumnJumps.MinimumWidth = 6;
            this.ColumnJumps.Name = "ColumnJumps";
            this.ColumnJumps.ReadOnly = true;
            this.ColumnJumps.Width = 150;
            // 
            // ColumnCruiseMode
            // 
            this.ColumnCruiseMode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCruiseMode.HeaderText = "Cruise Mode";
            this.ColumnCruiseMode.MinimumWidth = 6;
            this.ColumnCruiseMode.Name = "ColumnCruiseMode";
            this.ColumnCruiseMode.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDashboard);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2006, 1743);
            this.tabControl1.TabIndex = 1;
            // 
            // tabDashboard
            // 
            this.tabDashboard.BackColor = System.Drawing.Color.Black;
            this.tabDashboard.Controls.Add(this.labelScreenshotSystem);
            this.tabDashboard.Controls.Add(this.labelScreenshotTimestamp);
            this.tabDashboard.Controls.Add(this.labelStaticScreenshotText);
            this.tabDashboard.Controls.Add(this.pictureBoxConverted);
            this.tabDashboard.Controls.Add(this.listBoxDebugOutput);
            this.tabDashboard.Controls.Add(this.dataGridViewBodies);
            this.tabDashboard.Controls.Add(this.dataGridStars);
            this.tabDashboard.Controls.Add(this.dataGridHeader);
            this.tabDashboard.Location = new System.Drawing.Point(4, 29);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(1998, 1710);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "Dashboard";
            // 
            // labelScreenshotSystem
            // 
            this.labelScreenshotSystem.AutoSize = true;
            this.labelScreenshotSystem.Location = new System.Drawing.Point(1201, 134);
            this.labelScreenshotSystem.Name = "labelScreenshotSystem";
            this.labelScreenshotSystem.Size = new System.Drawing.Size(56, 20);
            this.labelScreenshotSystem.TabIndex = 6;
            this.labelScreenshotSystem.Text = "System";
            // 
            // labelScreenshotTimestamp
            // 
            this.labelScreenshotTimestamp.AutoSize = true;
            this.labelScreenshotTimestamp.Location = new System.Drawing.Point(1201, 166);
            this.labelScreenshotTimestamp.Name = "labelScreenshotTimestamp";
            this.labelScreenshotTimestamp.Size = new System.Drawing.Size(83, 20);
            this.labelScreenshotTimestamp.TabIndex = 5;
            this.labelScreenshotTimestamp.Text = "Timestamp";
            this.labelScreenshotTimestamp.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // labelStaticScreenshotText
            // 
            this.labelStaticScreenshotText.AutoSize = true;
            this.labelStaticScreenshotText.Location = new System.Drawing.Point(1201, 104);
            this.labelStaticScreenshotText.Name = "labelStaticScreenshotText";
            this.labelStaticScreenshotText.Size = new System.Drawing.Size(124, 20);
            this.labelStaticScreenshotText.TabIndex = 4;
            this.labelStaticScreenshotText.Text = "Latest Screenshot";
            this.labelStaticScreenshotText.Click += new System.EventHandler(this.label2_Click);
            // 
            // pictureBoxConverted
            // 
            this.pictureBoxConverted.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxConverted.Location = new System.Drawing.Point(1410, 88);
            this.pictureBoxConverted.Name = "pictureBoxConverted";
            this.pictureBoxConverted.Size = new System.Drawing.Size(576, 324);
            this.pictureBoxConverted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxConverted.TabIndex = 3;
            this.pictureBoxConverted.TabStop = false;
            // 
            // listBoxDebugOutput
            // 
            this.listBoxDebugOutput.FormattingEnabled = true;
            this.listBoxDebugOutput.ItemHeight = 20;
            this.listBoxDebugOutput.Location = new System.Drawing.Point(6, 1660);
            this.listBoxDebugOutput.Name = "listBoxDebugOutput";
            this.listBoxDebugOutput.Size = new System.Drawing.Size(1750, 44);
            this.listBoxDebugOutput.TabIndex = 2;
            // 
            // dataGridViewBodies
            // 
            this.dataGridViewBodies.AllowUserToAddRows = false;
            this.dataGridViewBodies.AllowUserToDeleteRows = false;
            this.dataGridViewBodies.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBodies.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridViewBodies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewBodies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBodies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BodyName,
            this.Landable,
            this.BpdyClass,
            this.Atmosphere,
            this.Gravity,
            this.dataGridViewTextBoxColumn1,
            this.BodyRadius,
            this.Mat,
            this.Sigs,
            this.BodyDistance,
            this.FSC,
            this.DSC,
            this.LND,
            this.SRV,
            this.FF,
            this.LO,
            this.BID});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBodies.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewBodies.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridViewBodies.Location = new System.Drawing.Point(6, 418);
            this.dataGridViewBodies.Name = "dataGridViewBodies";
            this.dataGridViewBodies.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridViewBodies.RowHeadersVisible = false;
            this.dataGridViewBodies.RowHeadersWidth = 51;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewBodies.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewBodies.RowTemplate.Height = 29;
            this.dataGridViewBodies.Size = new System.Drawing.Size(1989, 1218);
            this.dataGridViewBodies.TabIndex = 2;
            // 
            // BodyName
            // 
            this.BodyName.Frozen = true;
            this.BodyName.HeaderText = "Body Name";
            this.BodyName.MinimumWidth = 200;
            this.BodyName.Name = "BodyName";
            this.BodyName.Width = 220;
            // 
            // Landable
            // 
            this.Landable.Frozen = true;
            this.Landable.HeaderText = "Land?";
            this.Landable.MinimumWidth = 6;
            this.Landable.Name = "Landable";
            this.Landable.Width = 110;
            // 
            // BpdyClass
            // 
            this.BpdyClass.Frozen = true;
            this.BpdyClass.HeaderText = "Body Class";
            this.BpdyClass.MinimumWidth = 6;
            this.BpdyClass.Name = "BpdyClass";
            this.BpdyClass.Width = 240;
            // 
            // Atmosphere
            // 
            this.Atmosphere.Frozen = true;
            this.Atmosphere.HeaderText = "Atmosphere";
            this.Atmosphere.MinimumWidth = 6;
            this.Atmosphere.Name = "Atmosphere";
            this.Atmosphere.Width = 180;
            // 
            // Gravity
            // 
            this.Gravity.Frozen = true;
            this.Gravity.HeaderText = "Gravity";
            this.Gravity.MinimumWidth = 6;
            this.Gravity.Name = "Gravity";
            this.Gravity.Width = 90;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Frozen = true;
            this.dataGridViewTextBoxColumn1.HeaderText = "TempK";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // BodyRadius
            // 
            this.BodyRadius.Frozen = true;
            this.BodyRadius.HeaderText = "Radius";
            this.BodyRadius.MinimumWidth = 6;
            this.BodyRadius.Name = "BodyRadius";
            this.BodyRadius.Width = 125;
            // 
            // Mat
            // 
            this.Mat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Mat.DefaultCellStyle = dataGridViewCellStyle5;
            this.Mat.Frozen = true;
            this.Mat.HeaderText = "Mat";
            this.Mat.MinimumWidth = 6;
            this.Mat.Name = "Mat";
            this.Mat.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Mat.Width = 200;
            // 
            // Sigs
            // 
            this.Sigs.HeaderText = "Sigs";
            this.Sigs.MinimumWidth = 6;
            this.Sigs.Name = "Sigs";
            this.Sigs.Width = 50;
            // 
            // BodyDistance
            // 
            this.BodyDistance.HeaderText = "Distance";
            this.BodyDistance.MinimumWidth = 6;
            this.BodyDistance.Name = "BodyDistance";
            this.BodyDistance.Width = 125;
            // 
            // FSC
            // 
            this.FSC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FSC.HeaderText = "FSC";
            this.FSC.MinimumWidth = 6;
            this.FSC.Name = "FSC";
            this.FSC.Width = 45;
            // 
            // DSC
            // 
            this.DSC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.DSC.HeaderText = "DSC";
            this.DSC.MinimumWidth = 6;
            this.DSC.Name = "DSC";
            this.DSC.Width = 45;
            // 
            // LND
            // 
            this.LND.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LND.HeaderText = "LND";
            this.LND.MinimumWidth = 6;
            this.LND.Name = "LND";
            this.LND.Width = 45;
            // 
            // SRV
            // 
            this.SRV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.SRV.HeaderText = "SRV";
            this.SRV.MinimumWidth = 6;
            this.SRV.Name = "SRV";
            this.SRV.Width = 45;
            // 
            // FF
            // 
            this.FF.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FF.HeaderText = "FF";
            this.FF.MinimumWidth = 6;
            this.FF.Name = "FF";
            this.FF.Width = 40;
            // 
            // LO
            // 
            this.LO.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.LO.HeaderText = "LO";
            this.LO.MinimumWidth = 6;
            this.LO.Name = "LO";
            this.LO.Width = 40;
            // 
            // BID
            // 
            this.BID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.BID.HeaderText = "BID";
            this.BID.MinimumWidth = 6;
            this.BID.Name = "BID";
            this.BID.Width = 45;
            // 
            // dataGridStars
            // 
            this.dataGridStars.AllowUserToAddRows = false;
            this.dataGridStars.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridStars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridStars.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StarName,
            this.Type,
            this.Lum,
            this.AgeMY,
            this.Radius,
            this.Mass,
            this.TempK,
            this.Distance,
            this.ID});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridStars.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridStars.Location = new System.Drawing.Point(6, 118);
            this.dataGridStars.Name = "dataGridStars";
            this.dataGridStars.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridStars.RowHeadersVisible = false;
            this.dataGridStars.RowHeadersWidth = 51;
            this.dataGridStars.RowTemplate.Height = 29;
            this.dataGridStars.Size = new System.Drawing.Size(1179, 186);
            this.dataGridStars.TabIndex = 1;
            // 
            // StarName
            // 
            this.StarName.HeaderText = "Star Name";
            this.StarName.MinimumWidth = 240;
            this.StarName.Name = "StarName";
            this.StarName.ReadOnly = true;
            this.StarName.Width = 240;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.MinimumWidth = 80;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            this.Type.Width = 80;
            // 
            // Lum
            // 
            this.Lum.HeaderText = "Lum";
            this.Lum.MinimumWidth = 78;
            this.Lum.Name = "Lum";
            this.Lum.ReadOnly = true;
            this.Lum.Width = 78;
            // 
            // AgeMY
            // 
            this.AgeMY.HeaderText = "AgeMY";
            this.AgeMY.MinimumWidth = 150;
            this.AgeMY.Name = "AgeMY";
            this.AgeMY.ReadOnly = true;
            this.AgeMY.Width = 150;
            // 
            // Radius
            // 
            this.Radius.HeaderText = "Radius";
            this.Radius.MinimumWidth = 6;
            this.Radius.Name = "Radius";
            this.Radius.ReadOnly = true;
            this.Radius.Width = 125;
            // 
            // Mass
            // 
            this.Mass.HeaderText = "Mass";
            this.Mass.MinimumWidth = 78;
            this.Mass.Name = "Mass";
            this.Mass.ReadOnly = true;
            this.Mass.Width = 78;
            // 
            // TempK
            // 
            this.TempK.HeaderText = "TempK";
            this.TempK.MinimumWidth = 150;
            this.TempK.Name = "TempK";
            this.TempK.ReadOnly = true;
            this.TempK.Width = 200;
            // 
            // Distance
            // 
            this.Distance.HeaderText = "Distance";
            this.Distance.MinimumWidth = 150;
            this.Distance.Name = "Distance";
            this.Distance.ReadOnly = true;
            this.Distance.Width = 150;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 50;
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.textBoxLogFilePath);
            this.tabSettings.Location = new System.Drawing.Point(4, 29);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1998, 1710);
            this.tabSettings.TabIndex = 1;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(66, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elite Dangerous Log File Path";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBoxLogFilePath
            // 
            this.textBoxLogFilePath.Location = new System.Drawing.Point(64, 108);
            this.textBoxLogFilePath.Name = "textBoxLogFilePath";
            this.textBoxLogFilePath.Size = new System.Drawing.Size(665, 27);
            this.textBoxLogFilePath.TabIndex = 0;
            // 
            // timerCheckLog
            // 
            this.timerCheckLog.Interval = 1000;
            this.timerCheckLog.Tick += new System.EventHandler(this.timerCheckLog_Tick);
            // 
            // EliteExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(2030, 1767);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Name = "EliteExplorer";
            this.Text = "Elite Explorer Dashboard V2";
            this.Load += new System.EventHandler(this.EliteExplorer_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDashboard.ResumeLayout(false);
            this.tabDashboard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxConverted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBodies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridStars)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private TabControl tabControl1;
        private TabPage tabSettings;
        private Label label1;
        private TextBox textBoxLogFilePath;
        private System.Windows.Forms.Timer timerCheckLog;
        public TabPage tabDashboard;
        public ListBox listBoxDebugOutput;
        private DataGridViewTextBoxColumn ColumnEvent;
        private DataGridViewTextBoxColumn ColumnCommanderName;
        private DataGridViewTextBoxColumn ColumnShipRegistration;
        private DataGridViewTextBoxColumn ColumnFuelLevel;
        private DataGridViewTextBoxColumn ColumnFuelScooped;
        private DataGridViewTextBoxColumn ColumnCurrentSystem;
        private DataGridViewTextBoxColumn ColumnTargetSystem;
        private DataGridViewTextBoxColumn ColumnJumps;
        private DataGridViewTextBoxColumn ColumnCruiseMode;
        private DataGridViewTextBoxColumn StarName;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Lum;
        private DataGridViewTextBoxColumn AgeMY;
        private DataGridViewTextBoxColumn Radius;
        private DataGridViewTextBoxColumn Mass;
        private DataGridViewTextBoxColumn TempK;
        private DataGridViewTextBoxColumn Distance;
        private DataGridViewTextBoxColumn ID;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn BodyName;
        private DataGridViewTextBoxColumn Landable;
        private DataGridViewTextBoxColumn BpdyClass;
        private DataGridViewTextBoxColumn Atmosphere;
        private DataGridViewTextBoxColumn Gravity;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn BodyRadius;
        private DataGridViewTextBoxColumn Mat;
        private DataGridViewTextBoxColumn Sigs;
        private DataGridViewTextBoxColumn BodyDistance;
        private DataGridViewTextBoxColumn FSC;
        private DataGridViewTextBoxColumn DSC;
        private DataGridViewTextBoxColumn LND;
        private DataGridViewTextBoxColumn SRV;
        private DataGridViewTextBoxColumn FF;
        private DataGridViewTextBoxColumn LO;
        private DataGridViewTextBoxColumn BID;
        public PictureBox pictureBoxConverted;
        public Label labelStaticScreenshotText;
        public Label labelScreenshotTimestamp;
        public Label labelScreenshotSystem;
        public DataGridView dataGridHeader;
        public DataGridView dataGridStars;
        public DataGridView dataGridViewBodies;
    }
}