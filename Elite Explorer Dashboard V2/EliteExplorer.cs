using ImageMagick;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Windows.Forms;


namespace Elite_Explorer_Dashboard_V2
{

    public partial class EliteExplorer : Form
    {
        public runningDataObject runningData = new runningDataObject();
        public Dictionary<string, int> usedBodies = new Dictionary<string, int>();
        public Dictionary<string, int> materialCount = new Dictionary<string, int>();
        public Dictionary<string, int> usedParents = new Dictionary<string, int>();

        public Dictionary<string, dynamic> CompleteDict = new Dictionary<string, dynamic>();
        public Dictionary<string, string> PeriodicTable = new Dictionary<string, string>();

        public EliteExplorer()
        {
            InitializeComponent();
        }
        private void EliteExplorer_Load_1(object sender, EventArgs e)
        {
            bootstrapProgram();
            timerCheckLog.Enabled = true;
        }



        private void bootstrapProgram()
        {
            listBoxDebugOutput.Items.Add(Properties.Settings.Default.LogPath.Contains("\\"));
            if (Properties.Settings.Default.LogPath.Contains("\\") == false)
            {
                //textBoxLogFilePath.Text = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\Frontier Developments\\Elite Dangerous\\";
                Properties.Settings.Default.LogPath = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\Frontier Developments\\Elite Dangerous\\";
            }
            else
            {
            }

            //Load periodic table for name conversion

            timerCheckLog.Tag = runningData.CurrentLogFile;
            runningData.CurrentLogLineNumber = 0;

            //Load Fonts into running Data
            runningData.hugeFont = new Font("Consolas", 10);
            runningData.largeFont = new Font("Consolas", 9);
            runningData.mediumFont = new Font("Consolas", 8);
            runningData.smallFont = new Font("Consolas", 7);

            //Setup Data Grids Add DoubleBuffered
            dataGridHeader.DoubleBuffered(true);
            dataGridViewBodies.DoubleBuffered(true);
            dataGridViewOM.DoubleBuffered(true);

            dataGridHeader.RowHeadersVisible = false;
            dataGridHeader.EnableHeadersVisualStyles = false;
            dataGridHeader.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;

            dataGridHeader.ColumnHeadersDefaultCellStyle.Font = runningData.largeFont;
            dataGridHeader.DefaultCellStyle.Font = runningData.mediumFont;

            dataGridStars.RowHeadersVisible = false;
            dataGridStars.EnableHeadersVisualStyles = false;
            dataGridStars.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridStars.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;
            dataGridStars.ColumnHeadersDefaultCellStyle.Font = runningData.largeFont;
            dataGridStars.DefaultCellStyle.Font = runningData.mediumFont;

            dataGridViewOM.RowHeadersVisible = false;
            dataGridViewOM.EnableHeadersVisualStyles = false;
            dataGridViewOM.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridViewOM.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;
            dataGridViewOM.ColumnHeadersDefaultCellStyle.Font = runningData.largeFont;
            dataGridViewOM.DefaultCellStyle.Font = runningData.mediumFont;
            dataGridViewOM.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewCalculatedOM.RowHeadersVisible = false;
            dataGridViewCalculatedOM.EnableHeadersVisualStyles = false;
            dataGridViewCalculatedOM.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridViewCalculatedOM.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;
            dataGridViewCalculatedOM.ColumnHeadersDefaultCellStyle.Font = runningData.largeFont;
            dataGridViewCalculatedOM.DefaultCellStyle.Font = runningData.mediumFont;
            dataGridViewCalculatedOM.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridViewBodies.RowHeadersVisible = false;
            dataGridViewBodies.EnableHeadersVisualStyles = false;
            dataGridViewBodies.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridViewBodies.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;
            dataGridViewBodies.ColumnHeadersDefaultCellStyle.Font = runningData.largeFont;
            dataGridViewBodies.DefaultCellStyle.Font = runningData.mediumFont;
            dataGridViewBodies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewBodies.Columns[7].DefaultCellStyle.Font = new Font("Consolas", 8, FontStyle.Regular);

            textBoxScreenshotPath.Text = Properties.Settings.Default.ScreenshotDestinationPath;

        }

        public void processLocation(EDData eventData)
        {
            dataGridHeader[5, 0].Value = eventData.StarSystem;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timerCheckLog_Tick(object sender, EventArgs e)
        {
            LogFile thisLogFile = new LogFile();
            thisLogFile.read();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        public void buttonProcessOM_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewBodies_Sorted(object sender, EventArgs e)
        {
            int rowCounter = 0;
            foreach (DataGridViewRow row in dataGridViewBodies.Rows)
            {
                Debug.WriteLine(row.Cells["BodyName"].Value);
                usedBodies[row.Cells["BodyName"].Value.ToString()] = rowCounter;
                ++rowCounter;
            }

        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo? pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}