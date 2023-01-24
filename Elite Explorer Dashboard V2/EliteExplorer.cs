using ImageMagick;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.NetworkInformation;
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
        public Dictionary<int, string> BodyIDtoName = new Dictionary<int, string>();

        public Dictionary<string,ScanObjectBodyDetailed> bodyDictionary = new Dictionary<string,ScanObjectBodyDetailed>();

        public Dictionary<string, dynamic> CompleteDict = new Dictionary<string, dynamic>();

        public EliteExplorer()
        {
            InitializeComponent();
        }
        private void EliteExplorer_Load_1(object sender, EventArgs e)
        {
            bootstrapProgram();

            BootstrapDataGrids bootstrapObject = new BootstrapDataGrids();
            bootstrapObject.bootstrap(runningData, dataGridHeader, dataGridStars, dataGridViewOM, dataGridViewBodies, dataGridViewCalculatedOM);
            //MinorFunctions minorFunctionsObject = new MinorFunctions();


            timerCheckLog.Enabled = true;
        }



        private void bootstrapProgram()
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

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

            textBoxScreenshotPath.Text = Properties.Settings.Default.ScreenshotDestinationPath;


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

        private void dataGridStars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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