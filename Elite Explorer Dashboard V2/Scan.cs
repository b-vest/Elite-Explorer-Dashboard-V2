using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.DirectoryServices;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Elite_Explorer_Dashboard_V2
{
    internal class Scan
    {
        public runningDataObject process(string line, runningDataObject runningData, DataGridView dataGridHeader, DataGridView dataGridStars, DataGridView dataGridBodies)
        {

            ScanObjectBodyDetailed? edObject = JsonSerializer.Deserialize<ScanObjectBodyDetailed>(line);

            double speedOfLight = 299792458; // speed of light in meters per second

            if(runningData.bodyIDToName.ContainsKey(edObject.BodyID) == false)
            {
                runningData.bodyIDToName.Add(edObject.BodyID, edObject.BodyName);
                runningData.bodyDictionary.Add(edObject.BodyName.ToString(), new ScanObjectBodyDetailed());
                runningData.bodyDictionary[edObject.BodyName.ToString()] = edObject;

                if (edObject.SemiMajorAxis == null)
                {
                    runningData.bodyDictionary[edObject.BodyName].SemiMajorAxis = 0;
                    runningData.bodyDictionary[edObject.BodyName].Eccentricity = 0;
                    runningData.bodyDictionary[edObject.BodyName].OrbitalInclination = 0;
                    runningData.bodyDictionary[edObject.BodyName].Periapsis = 0;
                    runningData.bodyDictionary[edObject.BodyName].OrbitalPeriod = 0;
                    runningData.bodyDictionary[edObject.BodyName].AscendingNode = 0;
                    runningData.bodyDictionary[edObject.BodyName].MeanAnomaly = 0;
                    runningData.bodyDictionary[edObject.BodyName].DistanceToParentMeters = 0;
                    runningData.bodyDictionary[edObject.BodyName].FoundParent = 0;
                }
                runningData.bodyDictionary[edObject.BodyName].FoundParent = processParents(edObject, runningData);

                runningData.bodyDictionary[edObject.BodyName.ToString()].MeanAnomalyRadians = (Math.PI / 180) * edObject.MeanAnomaly;
                runningData.bodyDictionary[edObject.BodyName.ToString()].EccentricAnomaly = OrbitMathFunctions.CalculateEccentricAnomaly(edObject.SemiMajorAxis, edObject.Eccentricity, runningData.bodyDictionary[edObject.BodyName.ToString()].MeanAnomalyRadians);
                runningData.bodyDictionary[edObject.BodyName.ToString()].TrueAnomaly = OrbitMathFunctions.CalculateTrueAnomaly(
                    edObject.SemiMajorAxis,
                    edObject.Eccentricity,
                    runningData.bodyDictionary[edObject.BodyName].EccentricAnomaly,
                    runningData.bodyDictionary[edObject.BodyName].MeanAnomalyRadians
                );

                runningData.bodyDictionary[edObject.BodyName.ToString()].InclinationRadians = (Math.PI / 180) * edObject.OrbitalInclination;
                runningData.bodyDictionary[edObject.BodyName.ToString()].AscendingNodeRadians = (Math.PI / 180) * edObject.AscendingNode;
                runningData.bodyDictionary[edObject.BodyName.ToString()].PeriapsisRadians = (Math.PI / 180) * edObject.Periapsis;

                runningData.bodyDictionary[edObject.BodyName.ToString()].XYZ = OrbitMathFunctions.ConvertToCartesian(
                    edObject.SemiMajorAxis,
                    edObject.Eccentricity,
                    runningData.bodyDictionary[edObject.BodyName].InclinationRadians,
                    runningData.bodyDictionary[edObject.BodyName].AscendingNodeRadians,
                    runningData.bodyDictionary[edObject.BodyName].PeriapsisRadians,
                    runningData.bodyDictionary[edObject.BodyName].TrueAnomaly
                );
                runningData.bodyDictionary[edObject.BodyName].DistanceToParentMeters = Math.Sqrt(Math.Pow(runningData.bodyDictionary[edObject.BodyName.ToString()].XYZ[0] - 0, 2) + Math.Pow(runningData.bodyDictionary[edObject.BodyName.ToString()].XYZ[1] - 0, 2) + Math.Pow(runningData.bodyDictionary[edObject.BodyName.ToString()].XYZ[2] - 0, 2));
                runningData.bodyDictionary[edObject.BodyName].DistancetoParentsLS = runningData.bodyDictionary[edObject.BodyName].DistanceToParentMeters / speedOfLight;
                runningData.bodyDictionary[edObject.BodyName].Children = new List<int>();
                if (edObject.StarType != null)
                {
                    parseStar(edObject, runningData, dataGridStars, dataGridBodies);
                }
                if (edObject.PlanetClass != null)
                {
                    parseStellarBody(edObject, runningData, dataGridBodies);
                }
            }
            return runningData;
        }



        public void parseStellarBody(ScanObjectBodyDetailed bodyData, runningDataObject runningData, DataGridView dataGridBodies)
        {
            string useBodyClass = bodyData.PlanetClass;

            if(runningData.bodyConversion.ContainsKey(useBodyClass))
            {
                useBodyClass = runningData.bodyConversion[useBodyClass];
            }
            var useGravity = bodyData.SurfaceGravity / 10;
            var useTemp = Convert.ToInt32(bodyData.SurfaceTemperature);
            double useRadius = bodyData.Radius / 1000000;
            double distanceMM = runningData.bodyDictionary[bodyData.BodyName].DistanceToParentMeters / 1000000;
            int newRow = dataGridBodies.Rows.Add(
                bodyData.BodyName,
                bodyData.Landable,
                useBodyClass,
                "",
                useGravity.ToString("#.##"),
                useTemp + "K",
               string.Format("{0:N}", useRadius) + " Mm",
                0,
                0,
                string.Format("{0:N3}", bodyData.DistanceFromArrivalLS),
                "",
                "",
                "",
                "",
                "",
                "",
                bodyData.BodyID,
                "",
                string.Format("{0:N1}", distanceMM) + "(Mm) " + string.Format("{0:N4}", runningData.bodyDictionary[bodyData.BodyName].DistancetoParentsLS) + "(Ls)"
        );
            if(runningData.bodyDictionary[bodyData.BodyName].DistancetoParentsLS < 1)
            {
                dataGridBodies[18, newRow].Style.ForeColor = Color.White;

            }
            runningData.bodyDictionary[bodyData.BodyName].GridRow = newRow;
            //Process Landable Colors
            if (bodyData.Landable == true)
            {
                dataGridBodies[1, newRow].Style.BackColor = Color.Green;
                dataGridBodies[1, newRow].Style.ForeColor = Color.White;

            }
            else
            {
                dataGridBodies[12, newRow].Style.BackColor = Color.Yellow;
                dataGridBodies[13, newRow].Style.BackColor = Color.Yellow;
                dataGridBodies[14, newRow].Style.BackColor = Color.Yellow;
                dataGridBodies[15, newRow].Style.BackColor = Color.Yellow;

            }
            dataGridBodies[10, newRow].Style.BackColor = Color.Green;

            var gravityColor = Color.Red;
            var gravityFore = Color.Black;

            if (useGravity <= 10 && useGravity > 6)
            {
                gravityColor = Color.Orange;

            }
            if (useGravity <= 6 && useGravity > 4)
            {
                gravityColor = Color.Yellow;
            }
            if (useGravity <= 4 && useGravity > 2)
            {
                gravityColor = Color.DarkGreen;
            }
            if (useGravity <= 2 && useGravity > 1)
            {
                gravityColor = Color.Green;
            }
            if (useGravity <= 1)
            {
                gravityColor = Color.LightGreen;
            }
            dataGridBodies[4, newRow].Style.BackColor = gravityColor;
            dataGridBodies[4, newRow].Style.ForeColor = gravityFore;
            if (bodyData.Materials != null)
            {
                processMaterialScan(bodyData, newRow, runningData, dataGridBodies);
            }
            if (bodyData.AtmosphereComposition != null)
            {
                processAtmosphere(bodyData, newRow, dataGridBodies, runningData);
            }
           

            if (bodyData.BodyName != null){
                runningData.usedBodies.Add(bodyData.BodyName, newRow);
            }
        }

        public int? processParents(ScanObjectBodyDetailed parentsData, runningDataObject runningData)
        {
            int? useParent = 0;
            if (runningData.usedParents.ContainsKey(parentsData.BodyName) == false)
            {
                if (parentsData != null)
                {
                    if (parentsData.Parents != null)
                    {

                        if (parentsData.Parents[0].Planet != null)
                        {
                            useParent = parentsData.Parents[0].Planet;
                        }
                        if (parentsData.Parents[0].Null != null)
                        {
                            useParent = parentsData.Parents[0].Null;
                        }
                        if (parentsData.Parents[0].Star != null)
                        {
                            useParent = parentsData.Parents[0].Star;
                        }
                        return useParent;



                        //return "MaybeBarycentre";
                    }

                    return useParent;
                }
                return useParent;
            }
            return useParent;
        }

        public void processAtmosphere(ScanObjectBodyDetailed atmosphereData, int newRow, DataGridView dataGridBodies, runningDataObject runningData)
        {
            string printAtmosphere = "";
            string leadingZero = "";

            if (atmosphereData != null)
            {
                if (atmosphereData.AtmosphereComposition != null)
                {
                    foreach (var item in atmosphereData.AtmosphereComposition)
                    {
                        string useName = item.Name;
                        if (runningData.atmosphereConversion.ContainsKey(item.Name)){
                            useName = runningData.atmosphereConversion[item.Name];
                        }
                        //7
                        if (item.Percent < 1)
                        {
                            leadingZero = "0";
                        }
                        printAtmosphere += useName + "_" + leadingZero + "" + item.Percent.ToString("#.##") + "% ";
                    }
                }
            }
            DataGridViewRow row = dataGridBodies.Rows[newRow];
            row.MinimumHeight = 50;

            dataGridBodies[3, newRow].Value += printAtmosphere;
            if (atmosphereData.Landable == true)
            {
                dataGridBodies[3, newRow].Style.BackColor = Color.Green;
                dataGridBodies[3, newRow].Style.ForeColor = Color.White;


            }
        }
        public void processMaterialScan(ScanObjectBodyDetailed materialData, int newRow, runningDataObject runningData, DataGridView dataGridBodies)
        {
            string printMats = "";
            string leadingZero = "";
            if (runningData != null)
            {
                if (materialData != null)
                {
                    if (materialData.Materials != null)
                    {
                        foreach (var item in materialData.Materials)
                        {
                            string useItem = item.Name;
                            if (runningData.materialConversion.ContainsKey(item.Name))
                            {
                                useItem = runningData.materialConversion[item.Name];
                            }

                            //7
                            if (item != null)
                            {
                                if (item.Name != null)
                                {
                                    if (runningData.materialCount.ContainsKey(item.Name) == false)
                                    {
                                        runningData.materialCount.Add(item.Name, 0);

                                    }
                                    if (runningData.materialCount[item.Name] < 10)
                                    {
                                        if (item.Percent < 1)
                                        {
                                            leadingZero = "0";
                                        }
                                        string useName = item.Name;
                                        printMats += useItem + "_" + leadingZero + "" + item.Percent.ToString("#.##") + "%_" + "(" + runningData.materialCount[item.Name] + ") ";
                                    }
                                }
                            }
                        }
                        DataGridViewRow row = dataGridBodies.Rows[newRow];
                        row.MinimumHeight = 50;

                        dataGridBodies[7, newRow].Value = printMats;
                    }
                }
            }
        }

        public void parseStar(ScanObjectBodyDetailed bodyData, runningDataObject runningData, DataGridView dataGridStars, DataGridView dataGridBodies)
        {
            if(runningData != null) {
                if (bodyData != null)
                {
                    if (bodyData.BodyName != null)
                    {
                        var useTemp = Convert.ToInt32(bodyData.SurfaceTemperature);
                        double useRadius = bodyData.Radius / 1000000;

                        int newStarRow = dataGridStars.Rows.Add(bodyData.BodyName, bodyData.StarType, bodyData.Luminosity,
                            string.Format("{0:N0}", bodyData.Age_MY),
                            string.Format("{0:N0}", bodyData.Radius),
                             bodyData.StellarMass,
                            string.Format("{0:N0}", useTemp) + "K",
                            bodyData.DistanceFromArrivalLS,
                            bodyData.BodyID
                          );
                        useTemp = Convert.ToInt32(bodyData.SurfaceTemperature);


                        //Add identifier to bodies table
                        string primaryString = "Secondary";
                        if(bodyData.DistanceFromArrivalLS == 0)
                        {
                            primaryString = "Primary";
                        }
                        int newBodyRow = dataGridBodies.Rows.Add(
                        bodyData.BodyName,
                        "NA",
                        "Star",
                        "-",
                        bodyData.StellarMass.ToString("#.##"),
                        useTemp + "K",
                        string.Format("{0:N}", useRadius)+" Mm",
                        "-",
                        "-",
                        bodyData.DistanceFromArrivalLS,
                        "-",
                        "-",
                        "-",
                        "-",
                        "-",
                        "-",
                        bodyData.BodyID
                       );

                        runningData.usedBodies.Add(bodyData.BodyName, newStarRow);
                        runningData.bodyDictionary[bodyData.BodyName].GridRow = newStarRow;

                    }
                }
            }
        }
    }

}
