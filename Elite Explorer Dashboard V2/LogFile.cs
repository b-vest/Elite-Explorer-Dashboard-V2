using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class LogFile
    {
        EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

        public string findLatest()
        {
            string directoryPath = Properties.Settings.Default.LogPath;
            var directoryInfo = new DirectoryInfo(directoryPath);
            FileInfo[] files = directoryInfo.GetFiles("Journal*log");
            string thisLogFile = files[files.Length - 1].FullName;
            return thisLogFile;
        }

        public void read()
        {
            int thisLineCount = 0;
            mainform.timerCheckLog.Enabled = false;
            mainform.runningData.CurrentLogFile = findLatest();
            if (mainform.runningData.CurrentLogFile == null)
            {
                return;
            }
            var fs = new FileStream(mainform.runningData.CurrentLogFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var sr = new StreamReader(fs);
            string? line = String.Empty;
            while ((line = sr.ReadLine()) != null)
            {

                ++thisLineCount;
                if (thisLineCount > mainform.runningData.CurrentLogLineNumber)
                {
                    DateTime currentDateTime = DateTime.Now;
                    //processLine(line);

                    Line thisLine = new Line();
                    thisLine.process(line);
                }
            }
            mainform.runningData.CurrentLogLineNumber = thisLineCount;
            mainform.timerCheckLog.Enabled = true;
            return;
        }
    }
}
