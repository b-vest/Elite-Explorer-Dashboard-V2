using ScottPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void processLineFSDJump(string line, runningDataObject runningData, DataGridView dataGridViewBodies, DataGridView dataGridHeader, TextBox labelBodiesFound, FormsPlot systemCountPlot)
        {
            FSDJumpObject? edObject = JsonSerializer.Deserialize<FSDJumpObject>(line);
            dataGridViewBodies.Rows.Clear();
            runningData.bodyDictionary.Clear();
            runningData.bodyIDToName.Clear();
            runningData.usedBodies.Clear();
            systemCountPlot.Plot.Clear();
            systemCountPlot.Refresh();
            //runningData.bodyCount.Clear();

            labelBodiesFound.Text = "Jump Complete - Waiting for FSS Scan Data -";
            if (edObject != null)
            {
                runningData.CurrentSystem = edObject.StarSystem;
                dataGridHeader[5,0 ].Value = runningData.CurrentSystem;

            }

        }

        public void processLineMaterialCollected(string line, runningDataObject runningData, FormsPlot materilsCollectedPlot)
        {
            Debug.WriteLine(line);
            MaterialCollectedObject? materials = JsonSerializer.Deserialize<MaterialCollectedObject>(line);
            string useMatName = materials.Name;

            if (runningData.materialConversion.ContainsKey(useMatName))
            {
                useMatName = runningData.materialConversion[useMatName];
            }
            if (runningData.collectedMaterialsCount.ContainsKey(useMatName) == false)
            {
                runningData.collectedMaterialsCount.Add(useMatName, 1);
            }
            else
            {
                runningData.collectedMaterialsCount[useMatName] += 1;
            }
            int barCounter = 0;
            double[] barValues = { };
            double[] barPositions = { };
            double highValue = 0;
            List<ScottPlot.Plottable.Bar> bars = new();
            foreach (var material in runningData.collectedMaterialsCount)
            {
                if (material.Value > highValue)
                {
                    highValue = material.Value;
                }
                ScottPlot.Plottable.Bar bar = new ScottPlot.Plottable.Bar()
                {
                    Value = material.Value,
                    Position = barCounter + 1,
                    FillColor = ScottPlot.Palette.Category10.GetColor(barCounter),
                    Label = material.Key,
                    LineWidth = 1
                };
                bars.Add(bar);
                barCounter += 1;
            }
            Debug.WriteLine(barValues);
            materilsCollectedPlot.Plot.Clear();
            materilsCollectedPlot.Plot.AddBarSeries(bars);
            materilsCollectedPlot.Plot.SetAxisLimitsY(0, highValue + 5);
            materilsCollectedPlot.Refresh();
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
            if (edObject != null)
            {
                if (edObject.Body != null)
                {
                    dataGridViewBodies[12, usedBodies[edObject.Body]].Style.BackColor = Color.Green;
                    runningData.CurrentBody = edObject.Body;
                }
            }
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
                            //dataGridViewBodies[8, usedBodies[edObject.BodyName]].Style.BackColor = Color.Green;
                            dataGridViewBodies[8, usedBodies[edObject.BodyName]].Style.ForeColor = Color.LightBlue;
                            dataGridViewBodies[8, usedBodies[edObject.BodyName]].Value = theseSignals;
                        }
                    }
                }

            }

        }
        public void processLineSAAScanComplete(string line, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {

            SAAScanCompleteObject? edObject = JsonSerializer.Deserialize<SAAScanCompleteObject>(line);
            if (edObject != null)
            {
                if (edObject.BodyName != null)
                {
                    if (edObject.BodyName.Contains("Ring") == false && usedBodies.ContainsKey(edObject.BodyName))
                    {
                        dataGridViewBodies[11, usedBodies[edObject.BodyName]].Style.BackColor = Color.Green;
                        dataGridViewBodies[11, usedBodies[edObject.BodyName]].Style.ForeColor = Color.White;
                        dataGridViewBodies[11, usedBodies[edObject.BodyName]].Value = edObject.ProbesUsed;
                    }
                }
            }
        }
        public void processMaterialsLine(EDData? storedMaterials, runningDataObject runningData)
        {
            if(storedMaterials != null) {
                if(storedMaterials.Raw != null) {
                    if (runningData.materialCount != null)
                    {
                        foreach (var item in storedMaterials.Raw)
                        {
                            if (item.Name != null)
                            {
                                if (runningData.materialCount.ContainsKey(item.Name) == false)
                                {
                                    runningData.materialCount.Add(item.Name, item.Count);
                                }
                            }
                        }
                    }
                }
            }
        }
        public void processLineLaunchSRV(runningDataObject runningData, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {
            if (runningData != null)
            {
                if (runningData.CurrentBody != null)
                {
                    dataGridViewBodies[13, usedBodies[runningData.CurrentBody]].Style.BackColor = Color.Green;
                }
            }
         }
        public void processLineLiftoff(runningDataObject runningData, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {
            if (runningData != null)
            {
                if (runningData.CurrentBody != null)
                {
                    if (dataGridViewBodies.Rows.Count > 0)
                    {
                        dataGridViewBodies[15, usedBodies[runningData.CurrentBody]].Style.BackColor = Color.Green;
                    }
                }
            }
        }
        public void processLineDisembark(runningDataObject runningData, Dictionary<string, int> usedBodies, DataGridView dataGridViewBodies)
        {
            if (runningData != null)
            {
                if (runningData.CurrentBody != null)
                {
                    dataGridViewBodies[14, usedBodies[runningData.CurrentBody]].Style.BackColor = Color.Green;
                }
            }
        }
        public void processLineLocation(EDData edObject, runningDataObject runningData, DataGridView datagridViewHeader)
        {
            if (runningData != null)
            {
                runningData.CurrentSystem = edObject.StarSystem;
                if (runningData.CurrentSystem != null)
                {
                    datagridViewHeader[5,0].Value = runningData.CurrentSystem;
                }
            }
        }
    }

}
