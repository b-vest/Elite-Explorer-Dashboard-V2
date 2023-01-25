using ScottPlot.Ticks;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    public class Line
    {
        public void process(string line, runningDataObject runningData, OrbitMathFunctions orbitMath, DataGridView dataGridHeader, DataGridView dataGridStars, DataGridView dataGridBodies, TextBox labelBodiesFound)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

            EDData? edObject = JsonSerializer.Deserialize<EDData>(line);
            MinorFunctions MinorFunctions = new MinorFunctions();

            if (edObject == null)
            {
                return;
            }
            if (edObject.@event == null)
            {
                return;
            }
            if (edObject.BodyName == null && edObject.Body != null)
            {
                edObject.BodyName = edObject.Body;
            }
            mainform.dataGridHeader[0, 0].Value = edObject.@event;



            switch (edObject.@event)
            {

                case "Music":
                    MinorFunctions.processLineMusic(edObject, mainform.dataGridHeader);
                    //processMusic(edObject);
                    break;
                case "Screenshot":
                    //processScreenshot(line);
                    Screenshot thisScreenshot = new Screenshot();
                    thisScreenshot.process(line);
                    break;
                case "FSDTarget":
                    MinorFunctions.processLineFSDTarget(edObject, mainform.dataGridHeader);
                    //processFSDTarget(edObject);
                    break;
                case "FSDJump":
                    MinorFunctions.processLineFSDJump(line, runningData, dataGridBodies, dataGridStars);
                    break;
                case "FuelScoop":
                    MinorFunctions.processLineFuelScoop(edObject, mainform.runningData, mainform.dataGridHeader);
                    break;
                case "LoadGame":
                    LoadGame thisLoadGame = new LoadGame();
                    thisLoadGame.process(line);
                    //processLoadGame(line);
                    break;
                case "Scan":
                    Scan thisScan = new Scan();
                    runningDataObject runingData =  thisScan.process(line, runningData, dataGridHeader, dataGridStars, dataGridBodies);
                    //processScan(line);
                    break;
                case "SAASignalsFound":
                    MinorFunctions.processLineSAASignalsFound(line, runningData.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "Materials":
                    MinorFunctions.processMaterialsLine(edObject, runningData);
                    break;
                case "Shutdown":
                    MinorFunctions.processLineShutdown(line, mainform.dataGridHeader);
                    break;
                case "ScanBaryCentre":
                    //processScanBaryCentre(edObject);
                    ScanBaryCentre thisBaryScan = new ScanBaryCentre();
                    thisBaryScan.process(line, runningData, dataGridBodies);
                    break;
                case "FSSAllBodiesFound":
                    AllBodiesFound thisBodiesfound = new AllBodiesFound();
                    thisBodiesfound.process(line, runningData, dataGridBodies, labelBodiesFound);
                    break;
                case "SAAScanComplete":
                    MinorFunctions.processLineSAAScanComplete(line, runningData.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "Touchdown":
                    MinorFunctions.processLineTouchdown(line, mainform.runningData, runningData.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "LaunchSRV":
                    MinorFunctions.processLineLaunchSRV(mainform.runningData, runningData.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "Disembark":
                    MinorFunctions.processLineDisembark(mainform.runningData, runningData.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "Liftoff":
                    MinorFunctions.processLineLiftoff(mainform.runningData, runningData.usedBodies,mainform.dataGridViewBodies);
                    break;
            }
        }

    }
}
