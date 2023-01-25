using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class LogFile
    {

        public string findLatest()
        {
            string directoryPath = Properties.Settings.Default.LogPath;
            var directoryInfo = new DirectoryInfo(directoryPath);
            FileInfo[] files = directoryInfo.GetFiles("Journal*log");
            string thisLogFile = files[files.Length - 1].FullName;
            return thisLogFile;
        }

        public void read(runningDataObject runningData, DataGridView dataGridHeader, DataGridView dataGridStars, DataGridView dataGridBodies, TextBox labelBodiesFound)
        {
            int thisLineCount = 0;
            runningData.CurrentLogFile = findLatest();
            if (runningData.CurrentLogFile == null)
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
                    //processLine(line);

                    Line thisLine = new Line();
                    thisLine.process(line, runningData, dataGridHeader, dataGridStars, dataGridBodies, labelBodiesFound);
                }
            }
            runningData.CurrentLogLineNumber = thisLineCount;
            return;
        }
    }
}
