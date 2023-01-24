using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class MinorFunctions
    {
        public void processLineMusic(EDData eventData, DataGridView dataGridHeader)
        {

            if (eventData.MusicTrack != "NoTrack")
            {
                dataGridHeader[8, 0].Value = eventData.MusicTrack;
            }

        }
        public void updateLocationCell(EDData eventData, DataGridView dataGridHeader)
        {
            dataGridHeader[5, 0].Value = eventData.StarSystem;
        }

        public void processLineFSDTarget(EDData eventData, DataGridView dataGridHeader)
        {
            if (eventData == null) return;
            if (eventData.RemainingJumpsInRoute == 0)
            {
                eventData.RemainingJumpsInRoute = 1;
            }
            dataGridHeader[6, 0].Value = eventData.Name + " (" + eventData.StarClass + ")";
            dataGridHeader[7, 0].Value = eventData.RemainingJumpsInRoute;

        }
        public void processLineFSDJump(string line, runningDataObject runningData, Dictionary<string, dynamic> CompleteDict, Dictionary<string, ScanObjectBodyDetailed> bodyDictionary, DataGridView dataGrodStars, DataGridView dataGridViewBodies, DataGridView dataGridStars, DataGridView dataGridViewOM, DataGridView dataGridViewCalculatedOM)
        {
            FSDJumpObject? edObject = JsonSerializer.Deserialize<FSDJumpObject>(line);
            dataGridStars.Rows.Clear();
            dataGridViewBodies.Rows.Clear();
            dataGridViewOM.Rows.Clear();
            dataGridViewCalculatedOM.Rows.Clear();
            CompleteDict.Clear();
            bodyDictionary.Clear();
            runningData.CurrentSystem = edObject.StarSystem;
        }
        public void processLineFuelScoop(EDData eventData, runningDataObject runningData, DataGridView dataGridHeader)
        {
            runningData.TotalScooped += eventData.Scooped;
            dataGridHeader[4, 0].Value = String.Format("{0:0.00}", eventData.Scooped) + " (" + String.Format("{0:0.00}", runningData.TotalScooped) + ")";
            dataGridHeader[3, 0].Value = (int)eventData.Total;
        }
        public void processLineTouchdown(string line, runningDataObject runningData, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {
            TouchdownObject? edObject = JsonSerializer.Deserialize<TouchdownObject>(line);
            dataGridViewBodies[12, usedBodies[edObject.Body]].Style.BackColor = Color.Green;
            runningData.CurrentBody = edObject.Body;
        }
        public void processLineShutdown(string line, DataGridView dataGridHeader)
        {
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
        public void processLineSAASignalsFound(string line, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {

            ScanObjectBodyDetailed? edObject = JsonSerializer.Deserialize<ScanObjectBodyDetailed>(line);
            if (edObject != null)
            {
                if (usedBodies != null && edObject.BodyName != null)
                {
                    if (edObject.Signals != null && usedBodies.ContainsKey(edObject.BodyName) == true)
                    {
                        if (edObject.BodyName.Contains("Ring") == false)
                        {
                            string theseSignals = "";
                            foreach (var item in edObject.Signals)
                            {
                                theseSignals += item.Type_Localised + "-(" + item.Count + ")";
                            }
                            dataGridViewBodies[8, usedBodies[edObject.BodyName]].Style.BackColor = Color.Green;
                            dataGridViewBodies[8, usedBodies[edObject.BodyName]].Style.ForeColor = Color.White;
                            dataGridViewBodies[8, usedBodies[edObject.BodyName]].Value = theseSignals;
                        }
                    }
                }

            }

        }
        public void processLineSAAScanComplete(string line, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {

            SAAScanCompleteObject? edObject = JsonSerializer.Deserialize<SAAScanCompleteObject>(line);
            if (edObject.BodyName.Contains("Ring") == false && usedBodies.ContainsKey(edObject.BodyName))
            {
                dataGridViewBodies[11, usedBodies[edObject.BodyName]].Style.BackColor = Color.Green;
                dataGridViewBodies[11, usedBodies[edObject.BodyName]].Style.ForeColor = Color.White;
                dataGridViewBodies[11, usedBodies[edObject.BodyName]].Value = edObject.ProbesUsed;
            }
        }
        public void processLineLaunchSRV(runningDataObject runningData, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {
            dataGridViewBodies[13, usedBodies[runningData.CurrentBody]].Style.BackColor = Color.Green;
        }
        public void processLineLiftoff(runningDataObject runningData, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {
            if (dataGridViewBodies.Rows.Count > 0)
            {
                dataGridViewBodies[15, usedBodies[runningData.CurrentBody]].Style.BackColor = Color.Green;
            }
        }
        public void processLineDisembark(runningDataObject runningData, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {
            dataGridViewBodies[14, usedBodies[runningData.CurrentBody]].Style.BackColor = Color.Green;
        }
    }

}
