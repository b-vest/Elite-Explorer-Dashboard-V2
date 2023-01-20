using System;
using System.Collections.Generic;
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
            if (edObject == null)
            {
                return;
            }
            if (edObject.@event == null)
            {
                return;
            }
            mainform.listBoxDebugOutput.Items.Add(edObject.@event);
            if (edObject.BodyName == null && edObject.Body != null)
            {
                edObject.BodyName = edObject.Body;
            }
            mainform.dataGridHeader[0, 0].Value = edObject.@event;

            switch (edObject.@event)
            {

                case "Music":
                    Music thisMusic = new Music();
                    thisMusic.process(edObject);
                    //processMusic(edObject);
                    break;
                case "Screenshot":
                    //processScreenshot(line);
                    Screenshot thisScreenshot = new Screenshot();
                    thisScreenshot.process(line);
                    break;
                case "FSDTarget":
                    FSDTarget thisFSDTarget = new FSDTarget();
                    thisFSDTarget.process(edObject);
                    //processFSDTarget(edObject);
                    break;
                case "FSDJump":
                    FSDJump thisFSDJump = new FSDJump();
                    thisFSDJump.process(line);
                    //processFSDJump(line);
                    break;
                case "FuelScoop":
                    FuelScoop thisFuelScoop = new FuelScoop();
                    thisFuelScoop.process(edObject);
                    //processFuelScoop(edObject);
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
                    SAASignalsFound theseSignals = new SAASignalsFound();
                    theseSignals.process(line);
                    //processSAASignalsFound(line);
                    break;
                case "Materials":
                    InventoryMaterials thisMaterials = new InventoryMaterials();
                    thisMaterials.process(edObject);
                    //processMaterials(edObject);
                    break;
                case "Shutdown":
                    Shutdown thisShutdown = new Shutdown();
                    thisShutdown.process(line);
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
                    //processSAAScanComplete(line);
                    SAAScanComplete thisSAAScan = new SAAScanComplete();
                    thisSAAScan.processSAAScanComplete(line);
                    break;
            }
        }

    }
}
