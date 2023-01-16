using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;

namespace Elite_Explorer_Dashboard_V2
{
    public partial class EliteExplorer : Form
    {
        runningDataObject runningData = new runningDataObject();
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
                textBoxLogFilePath.Text = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\Frontier Developments\\Elite Dangerous\\";
                Properties.Settings.Default.LogPath = "C:\\Users\\" + Environment.UserName + "\\Saved Games\\Frontier Developments\\Elite Dangerous\\";
                listBoxActiveLogPath.Items.Add(Properties.Settings.Default.LogPath);
            }
            else
            {
                listBoxActiveLogPath.Items.Add(Properties.Settings.Default.LogPath);
            }
            timerCheckLog.Tag = runningData.CurrentLogFile;
            runningData.CurrentLogLineNumber = 0;

            //Load Fonts into running Data
            runningData.hugeFont = new Font("Consolas", 11);
            runningData.largeFont = new Font("Consolas", 10);
            runningData.mediumFont = new Font("Consolas", 9);
            runningData.smallFont = new Font("Consolas", 8);

            //Setup Data Grids Add DoubleBuffered
            dataGridHeader.DoubleBuffered(true);

            dataGridHeader.RowHeadersVisible = false;
            dataGridHeader.EnableHeadersVisualStyles = false;
            dataGridHeader.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;

            dataGridHeader.ColumnHeadersDefaultCellStyle.Font = runningData.largeFont;
            dataGridHeader.DefaultCellStyle.Font = runningData.mediumFont;



            runningData.CurrentLogFile = findLatestLogfile();
            listBoxDebugOutput.Items.Add(runningData.CurrentLogFile);


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
            int thisLineCount = 0;
            timerCheckLog.Enabled = false;
            if(runningData.CurrentLogFile == null)
            {
                return;
            }
            var fs = new FileStream(runningData.CurrentLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var sr = new StreamReader(fs);
            string? line = String.Empty;
            while ((line = sr.ReadLine()) != null)
            {

                ++thisLineCount;
                if (thisLineCount > runningData.CurrentLogLineNumber)
                {
                    DateTime currentDateTime = DateTime.Now;
                    listBoxDebugOutput.Items.Add(currentDateTime);
                    listBoxDebugOutput.Items.Add(thisLineCount + " " + line);
                    processLine(line);
                }
            }
            runningData.CurrentLogLineNumber = thisLineCount;
            timerCheckLog.Enabled = true;
            return;
        }

        public void processLine(string line)
        {
            EDData? edObject = JsonSerializer.Deserialize<EDData>(line);
            if (edObject == null) {
                return;
            }
            if(edObject.@event == null)
            {
                return;
            }
            listBoxDebugOutput.Items.Add(edObject.@event);
            if (edObject.BodyName == null && edObject.Body != null)
            {
                edObject.BodyName = edObject.Body;
            }
            dataGridHeader[0, 0].Value = edObject.@event;

            switch (edObject.@event)
            {
                case "StartJump":
                    processStartJump(line);
                    break;
                case "Music":
                    processMusic(line);
                    break;
                case "Screenshot":
                    processScreenshot(line);
                    break;
                case "SAAScanComplete":
                    processSAAScanComplete(line);
                    break;
                case "LaunchSRV":
                    processLaunchSRV(line);
                    break;
                case "Disembark":
                    processDisembark(edObject);
                    break;
                case "ReservoirReplenished":
                    processReservoirReplenished(edObject);
                    break;
                case "FSDTarget":
                    processFSDTarget(line);
                    break;
                case "FSDJump":
                    processFSDJump(line);
                    break;
                case "FuelScoop":
                    processFuelScoop(line);
                    break;
                case "LoadGame":
                    processLoadGame(line);
                    break;
                case "FSSDiscoveryScan":
                    processFSSDiscoveryScan(line);
                    break;
                case "Scan":
                    processScan(line);
                    break;
                case "Touchdown":
                    processTouchdown(line);
                    break;
                case "Location":
                    processLocation(edObject);
                    break;
                case "NavRoute":
                    processNavRoute(edObject);
                    break;
                case "ScanBaryCentre":
                    processScanBaryCentre(edObject);
                    break;
                case "FSSAllBodiesFound":
                    processFSSAllBodiesFound(line);
                    break;
                case "FSSBodySignals":
                    processFSSBodySignals(edObject);
                    break;
                case "FSSSignalDiscovered":
                    processFSSSignalDiscovered(edObject);
                    break;
                case "MaterialCollected":
                    processMaterialCollected(edObject);
                    break;
                case "ApproachBody":
                    processApproachBody(edObject);
                    break;
                case "SAASignalsFound":
                    processSAASignalsFound(line);
                    break;
                case "Embark":
                    processEmbark(edObject);
                    break;
                case "LeaveBody":
                    processLeaveBody(edObject);
                    break;
                case "DockSRV":
                    processDockSRV(edObject);
                    break;
                case "SupercruiseExit":
                    processSupercruiseExit(edObject);
                    break;
                case "SupercruiseEntry":
                    processSupercruiseEntry(edObject);
                    break;
                case "Commander":
                    processCommander(edObject);
                    break;
                case "Materials":
                    processMaterials(edObject);
                    break;
                case "CodexEntry":
                    processCodexEntry(edObject);
                    break;
                case "Liftoff":
                    processLiftoff(line);
                    break;
                case "Shutdown":
                    processShutdown(line);
                    break;
                case "Backpack":
                    processBackpack(edObject);
                    break;
                case "HullDamage":
                    processHullDamage(edObject);
                    break;
                case "ApproachSettlement":
                    processApproachSettlement(edObject);
                    break;
                case "Synthesis":
                    processSynthesis(edObject);
                    break;
                case "MultiSellExplorationData":
                    processMultiSellExplorationData(edObject);
                    break;
                case "Docked":
                    processDocked(edObject);
                    break;
                case "DataScanned":
                    processDataScanned(edObject);
                    break;
                case "UseConsumable":
                    processUseConsumable(edObject);
                    break;
                case "SRVDestroyed":
                    processSRVDestroyed(edObject);
                    break;
                case "JetConeBoost":
                    processJetConeBoost(edObject);
                    break;
            }
        }
        public void processShutdown(string line) {
            listBoxDebugOutput.Items.Add("Process Shutdonw");
            listBoxDebugOutput.Items.Add(line);
            dataGridHeader[0, 0].Value = "Shutdown";
            dataGridHeader[1, 0].Value = "Shutdown";
            dataGridHeader[2, 0].Value = "Shutdown";
            dataGridHeader[3, 0].Value = "Shutdown";
            dataGridHeader[4, 0].Value = "Shutdown";
            dataGridHeader[5, 0].Value = "Shutdown";
            dataGridHeader[6, 0].Value = "Shutdown";
            dataGridHeader[7, 0].Value = "Shutdown";
            dataGridHeader[8, 0].Value = "Shutdown";
        }
        public void processStartJump(string line) { }
        public void processScreenshot(string line) { }
        public void processMusic(string line) { }
        public void processSAAScanComplete(string line) { }
        public void processLaunchSRV(string line) { }
        public void processDisembark(EDData eventData) { }
        public void processReservoirReplenished(EDData eventData) { }
        public void processFSDTarget(string line) { }
        public void processFSDJump(string line) { }
        public void processFuelScoop(string line) { }
        public void processLoadGame(string line) {
            LoadGameObject edObject = JsonSerializer.Deserialize<LoadGameObject>(line);
            runningData.CommanderName = edObject.Commander;
            dataGridHeader[1, 0].Value = edObject.Commander;
            dataGridHeader[2, 0].Value = edObject.Ship + " " + edObject.ShipName + " " + edObject.ShipIdent;
            dataGridHeader[3, 0].Value = String.Format("{0:0.00}", edObject.FuelLevel);
            dataGridHeader[4, 0].Value = 0;
            dataGridHeader[6, 0].Value = "Loading.......";


        }
        public void processFSSDiscoveryScan(string line) { }
        public void processScan(string line) { }
        public void processTouchdown(string line) { }
        public void processLocation(EDData eventData) {
            dataGridHeader[5, 0].Value = eventData.StarSystem;
        }
        public void processNavRoute(EDData eventData) { }
        public void processScanBaryCentre(EDData eventData) { }
        public void processFSSAllBodiesFound(string line) { }
        public void processFSSBodySignals(EDData eventData) { }
        public void processFSSSignalDiscovered(EDData eventData) { }
        public void processMaterialCollected(EDData eventData) { }
        public void processApproachBody(EDData eventData) { }
        public void processSAASignalsFound(string line) { }
        public void processEmbark(EDData eventData) { }
        public void processLeaveBody(EDData eventData) { }
        public void processDockSRV(EDData eventData) { }
        public void processSupercruiseExit(EDData eventData) { }
        public void processSupercruiseEntry(EDData eventData) { }
        public void processCommander(EDData eventData) { }
        public void processMaterials(EDData eventData) { }
        public void processCodexEntry(EDData eventData) { }
        public void processLiftoff(string line) { }

        public void processBackpack(EDData eventData) { }
        public void processHullDamage(EDData eventData) { }
        public void processApproachSettlement(EDData eventData) { }
        public void processSynthesis(EDData eventData) { }
        public void processMultiSellExplorationData(EDData eventData) { }
        public void processDocked(EDData eventData) { }
        public void processDataScanned(EDData eventData) { }
        public void processUseConsumable(EDData eventData) { }
        public void processSRVDestroyed(EDData eventData) { }
        public void processJetConeBoost(EDData eventData) { }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timerCheckLog_Tick(object sender, EventArgs e)
        {
            readLogFile();
        }
    }

    public static class ExtensionMethods
    {
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            Type dgvType = dgv.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}