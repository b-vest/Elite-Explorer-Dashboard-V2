using System.Diagnostics;

namespace Elite_Explorer_Dashboard_V2
{
    public partial class EliteExplorer : Form
    {
        RunningDataObject runningData = new RunningDataObject();
        public EliteExplorer()
        {
            Debug.WriteLine("Initalize");
            InitializeComponent();
        }
        private void EliteExplorer_Load_1(object sender, EventArgs e)
        {
            readSettings();
            runningData.CurrentLogFile = findLatestLogfile();
            listBoxDebugOutput.Items.Add(runningData.CurrentLogFile);
            timerCheckLog.Tag = runningData.CurrentLogFile;
            timerCheckLog.Enabled = true;
        }



        private void readSettings()
        {
            listBoxDebugOutput.Items.Add(Properties.Settings.Default.LogPath.Contains("\\"));
            if (Properties.Settings.Default.LogPath.Contains("\\") == false)
            {
                textBoxLogFilePath.Text = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\Frontier Developments\\Elite Dangerous\\";
                Properties.Settings.Default.LogPath = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\Frontier Developments\\Elite Dangerous\\";
                listBoxActiveLogPath.Items.Add(Properties.Settings.Default.LogPath);
            }
            else
            {
                listBoxActiveLogPath.Items.Add(Properties.Settings.Default.LogPath);
            }
            timerCheckLog.Tag = "NULL";
        }

        public string findLatestLogfile()
        {
            string directoryPath = Properties.Settings.Default.LogPath;
            var directoryInfo = new DirectoryInfo(directoryPath);
            FileInfo[] files = directoryInfo.GetFiles("Journal*log");
            string thisLogFile = files[files.Length - 1].FullName;
            return thisLogFile;
        }

        private void readLogFile()
        {
            timerCheckLog.Enabled = false;
            DateTime currentDateTime = DateTime.Now;
            listBoxDebugOutput.Items.Add(currentDateTime);
            string runningLogFile = timerCheckLog.Tag.ToString();
            listBoxDebugOutput.Items.Add(runningLogFile);

            var fs = new FileStream(runningLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var sr = new StreamReader(fs);
            string line = String.Empty;
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                listBoxDebugOutput.Items.Add(line);
            }


                timerCheckLog.Enabled = true;
            return;
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timerCheckLog_Tick(object sender, EventArgs e)
        {
            readLogFile();
        }
    }
}