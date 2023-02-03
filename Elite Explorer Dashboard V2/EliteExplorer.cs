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
        BootstrapDataGrids bootstrapObject = new BootstrapDataGrids();

        //new OrbitMathFunctions orbitMath = new OrbitMathFunctions();
        LogFile thisLogFile = new LogFile();


        public EliteExplorer()
        {
            InitializeComponent();
        }
        private void EliteExplorer_Load_1(object sender, EventArgs e)
        {
            bootstrapProgram();

            bootstrapObject.bootstrap(runningData, dataGridHeader, dataGridViewBodies);
            timerCheckLog.Enabled = true;
            

        }

        private void bootstrapProgram()
        {
            if (Properties.Settings.Default.LogPath.Contains("\\") == false)
            {
                Properties.Settings.Default.LogPath = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\Frontier Developments\\Elite Dangerous\\";
            }
            else
            {
            }
            //Load periodic table for name conversion
            runningData = bootstrapObject.buildConversionTables(runningData);
            timerCheckLog.Tag = runningData.CurrentLogFile;
            runningData.CurrentLogLineNumber = 0;
            textBoxScreenshotPath.Text = Properties.Settings.Default.ScreenshotDestinationPath;
            systemCountPlot.Plot.XAxis.Label("Body Count This Session");
            systemCountPlot.Plot.Style(grid: Color.White);
            systemCountPlot.Plot.Style(dataBackground: Color.LightGray);

            starCountPlot.Plot.XAxis.Label("Star Count This Session");
            starCountPlot.Plot.Style(grid: Color.White);
            starCountPlot.Plot.Style(dataBackground: Color.LightGray);


            materialsCollectedPlot.Plot.XAxis.Label("Materials Collected This Session");
            materialsCollectedPlot.Plot.Style(grid: Color.White);
            materialsCollectedPlot.Plot.Style(dataBackground: Color.LightGray);

        }

        private void timerCheckLog_Tick(object sender, EventArgs e)
        {
            timerCheckLog.Enabled = false;
            thisLogFile.read(runningData, dataGridHeader, dataGridViewBodies, labelBodiesFound, systemCountPlot, starCountPlot, materialsCollectedPlot);
            timerCheckLog.Enabled = true;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click_2(object sender, EventArgs e)
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
                runningData.usedBodies[row.Cells["BodyName"].Value.ToString()] = rowCounter;
                ++rowCounter;
            }

        }

        private void dataGridStars_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonViewOrbits_Click(object sender, EventArgs e)
        {

        }

        private void buttonViewOrbits_Click_1(object sender, EventArgs e)
        {

        }

        private void textBoxScreenshotPath_TextChanged(object sender, EventArgs e)
        {

        }

        private void formsPlot1_Load(object sender, EventArgs e)
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