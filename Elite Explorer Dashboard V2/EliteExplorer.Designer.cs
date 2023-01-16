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
            this.dataGridHeader = new System.Windows.Forms.DataGridView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDashboard = new System.Windows.Forms.TabPage();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxLogFilePath = new System.Windows.Forms.TextBox();
            this.listBoxDebugOutput = new System.Windows.Forms.ListBox();
            this.listBoxActiveLogPath = new System.Windows.Forms.ListBox();
            this.timerCheckLog = new System.Windows.Forms.Timer(this.components);
            this.ColumnEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCommanderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnShipRegistration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFuelLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFuelScooped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCurrentSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTargetSystem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnJumps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCruiseMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabDashboard.SuspendLayout();
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
            this.dataGridHeader.Size = new System.Drawing.Size(1738, 74);
            this.dataGridHeader.TabIndex = 0;
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
            this.tabControl1.Size = new System.Drawing.Size(1758, 929);
            this.tabControl1.TabIndex = 1;
            // 
            // tabDashboard
            // 
            this.tabDashboard.BackColor = System.Drawing.Color.Black;
            this.tabDashboard.Controls.Add(this.dataGridHeader);
            this.tabDashboard.Location = new System.Drawing.Point(4, 29);
            this.tabDashboard.Name = "tabDashboard";
            this.tabDashboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabDashboard.Size = new System.Drawing.Size(1750, 896);
            this.tabDashboard.TabIndex = 0;
            this.tabDashboard.Text = "Dashboard";
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.label1);
            this.tabSettings.Controls.Add(this.textBoxLogFilePath);
            this.tabSettings.Location = new System.Drawing.Point(4, 29);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabSettings.Size = new System.Drawing.Size(1750, 896);
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
            // listBoxDebugOutput
            // 
            this.listBoxDebugOutput.FormattingEnabled = true;
            this.listBoxDebugOutput.ItemHeight = 20;
            this.listBoxDebugOutput.Location = new System.Drawing.Point(16, 1060);
            this.listBoxDebugOutput.Name = "listBoxDebugOutput";
            this.listBoxDebugOutput.Size = new System.Drawing.Size(1750, 224);
            this.listBoxDebugOutput.TabIndex = 2;
            // 
            // listBoxActiveLogPath
            // 
            this.listBoxActiveLogPath.FormattingEnabled = true;
            this.listBoxActiveLogPath.ItemHeight = 20;
            this.listBoxActiveLogPath.Location = new System.Drawing.Point(12, 953);
            this.listBoxActiveLogPath.Name = "listBoxActiveLogPath";
            this.listBoxActiveLogPath.Size = new System.Drawing.Size(1754, 84);
            this.listBoxActiveLogPath.TabIndex = 3;
            // 
            // timerCheckLog
            // 
            this.timerCheckLog.Interval = 1000;
            this.timerCheckLog.Tick += new System.EventHandler(this.timerCheckLog_Tick);
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
            this.ColumnShipRegistration.MinimumWidth = 6;
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
            this.ColumnFuelScooped.HeaderText = "Scooped";
            this.ColumnFuelScooped.MinimumWidth = 6;
            this.ColumnFuelScooped.Name = "ColumnFuelScooped";
            this.ColumnFuelScooped.ReadOnly = true;
            this.ColumnFuelScooped.Width = 97;
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
            // EliteExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(1782, 1344);
            this.Controls.Add(this.listBoxActiveLogPath);
            this.Controls.Add(this.listBoxDebugOutput);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Name = "EliteExplorer";
            this.Text = "Elite Explorer Dashboard V2";
            this.Load += new System.EventHandler(this.EliteExplorer_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridHeader)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabDashboard.ResumeLayout(false);
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridHeader;
        private TabControl tabControl1;
        private TabPage tabSettings;
        private Label label1;
        private TextBox textBoxLogFilePath;
        private System.Windows.Forms.Timer timerCheckLog;
        public TabPage tabDashboard;
        public ListBox listBoxDebugOutput;
        public ListBox listBoxActiveLogPath;
        private DataGridViewTextBoxColumn ColumnEvent;
        private DataGridViewTextBoxColumn ColumnCommanderName;
        private DataGridViewTextBoxColumn ColumnShipRegistration;
        private DataGridViewTextBoxColumn ColumnFuelLevel;
        private DataGridViewTextBoxColumn ColumnFuelScooped;
        private DataGridViewTextBoxColumn ColumnCurrentSystem;
        private DataGridViewTextBoxColumn ColumnTargetSystem;
        private DataGridViewTextBoxColumn ColumnJumps;
        private DataGridViewTextBoxColumn ColumnCruiseMode;
    }
}