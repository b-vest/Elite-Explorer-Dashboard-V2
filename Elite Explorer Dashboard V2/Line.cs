﻿using ScottPlot.Ticks;
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
        public void process(string line)
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
                    MinorFunctions.processLineFSDJump(line, mainform.runningData, mainform.CompleteDict, mainform.bodyDictionary, mainform.dataGridStars, mainform.dataGridViewBodies, mainform.dataGridStars, mainform.dataGridViewOM, mainform.dataGridViewCalculatedOM);
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
                    thisScan.process(line);
                    //processScan(line);
                    break;
                case "SAASignalsFound":
                    MinorFunctions.processLineSAASignalsFound(line, mainform.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "Materials":
                    InventoryMaterials thisMaterials = new InventoryMaterials();
                    thisMaterials.process(edObject);
                    //processMaterials(edObject);
                    break;
                case "Shutdown":
                    MinorFunctions.processLineShutdown(line, mainform.dataGridHeader);
                    break;
                case "ScanBaryCentre":
                    //processScanBaryCentre(edObject);
                    ScanBaryCentre thisBaryScan = new ScanBaryCentre();
                    thisBaryScan.process(line);
                    break;
                case "FSSAllBodiesFound":
                    AllBodiesFound thisBodiesfound = new AllBodiesFound();
                    thisBodiesfound.process(line);
                    break;
                case "SAAScanComplete":
                    MinorFunctions.processLineSAAScanComplete(line, mainform.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "Touchdown":
                    MinorFunctions.processLineTouchdown(line, mainform.runningData, mainform.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "LaunchSRV":
                    MinorFunctions.processLineLaunchSRV(mainform.runningData, mainform.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "Disembark":
                    MinorFunctions.processLineDisembark(mainform.runningData, mainform.usedBodies, mainform.dataGridViewBodies);
                    break;
                case "Liftoff":
                    MinorFunctions.processLineLiftoff(mainform.runningData, mainform.usedBodies,mainform.dataGridViewBodies);
                    break;
            }
        }

    }
}
