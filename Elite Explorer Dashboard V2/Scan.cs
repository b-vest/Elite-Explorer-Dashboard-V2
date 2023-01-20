using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Elite_Explorer_Dashboard_V2
{
    internal class Scan
    {
        EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

        public void process(string line)
        {

            ScanObjectBodyDetailed? edObject = JsonSerializer.Deserialize<ScanObjectBodyDetailed>(line);
            if (edObject != null)
            {
                if(edObject.BodyName != null) {
                    if (mainform.usedBodies.ContainsKey(edObject.BodyName) == false)
                    {
                        if (edObject.StarType != null)
                        {
                            parseStar(edObject);
                        }
                        if (edObject.PlanetClass != null)
                        {
                            parseStellarBody(edObject);
                        }
                    }
                }
            }
        }
        public void parseStellarBody(ScanObjectBodyDetailed bodyData)
        {
            var useGravity = bodyData.SurfaceGravity / 10;
            var useTemp = Convert.ToInt32(bodyData.SurfaceTemperature);
            double tempInCelsius = useTemp - 273.15;
            int newRow = mainform.dataGridViewBodies.Rows.Add(
                bodyData.BodyName,
                bodyData.Landable,
                bodyData.PlanetClass,
                "",
                useGravity.ToString("#.##"),
                useTemp + "K (" + tempInCelsius.ToString("#.##") + "C)",
               string.Format("{0:N}", bodyData.Radius),
                0,
                0,
                bodyData.DistanceFromArrivalLS,
                "",
                "",
                "",
                "",
                "",
                "",
                bodyData.BodyID
                );
            //Process Landable Colors
            if (bodyData.Landable == true)
            {
                mainform.dataGridViewBodies[1, newRow].Style.BackColor = Color.Green;
                mainform.dataGridViewBodies[1, newRow].Style.ForeColor = Color.White;

            }
            else
            {
                mainform.dataGridViewBodies[12, newRow].Style.BackColor = Color.Yellow;
                mainform.dataGridViewBodies[13, newRow].Style.BackColor = Color.Yellow;
                mainform.dataGridViewBodies[14, newRow].Style.BackColor = Color.Yellow;
                mainform.dataGridViewBodies[15, newRow].Style.BackColor = Color.Yellow;

            }
            mainform.dataGridViewBodies[10, newRow].Style.BackColor = Color.Green;

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
            mainform.dataGridViewBodies[4, newRow].Style.BackColor = gravityColor;
            mainform.dataGridViewBodies[4, newRow].Style.ForeColor = gravityFore;
            if (bodyData.Materials != null)
            {
                processMaterialScan(bodyData, newRow);
            }
            if (bodyData.AtmosphereComposition != null)
            {
                processAtmosphere(bodyData, newRow);
            }

            //Add Items to OM Tab Grid
            string bodyParents = processParents(bodyData);

            mainform.dataGridViewOM.Rows.Add(
                bodyData.BodyName,
                bodyData.BodyID,
                bodyParents,
                string.Format("{0:N0}", bodyData.DistanceFromArrivalLS),
                bodyData.MassEM,
                string.Format("{0:N0}", bodyData.Radius),
                string.Format("{0:N0}", bodyData.SemiMajorAxis),
                bodyData.Eccentricity,
                bodyData.OrbitalInclination,
                bodyData.Periapsis,
                string.Format("{0:N0}", bodyData.OrbitalPeriod),
                bodyData.AscendingNode,
                bodyData.MeanAnomaly
            );


            if (bodyData.BodyName != null){
                mainform.usedBodies.Add(bodyData.BodyName, newRow);
            }
        }

        public string processParents(ScanObjectBodyDetailed parentsData)
        {
            string useParents = "";
            if (mainform.usedParents.ContainsKey(parentsData.BodyName) == false)
            {
                if (parentsData != null)
                {
                    if (parentsData.Parents != null)
                    {
                        foreach (var item in parentsData.Parents)
                        {
                            if (item.Star > 0 && useParents.Contains("Star:" + item.Star + " ") == false)
                            {
                                useParents += "Star:" + item.Star + " ";
                            }
                            if (item.Planet > 0 && useParents.Contains("Planet:" + item.Planet + " ") == false)
                            {
                                useParents += "Planet:" + item.Planet + " ";

                            }
                            if (item.Null > 0 && useParents.Contains("Null:" + item.Null + " ") == false)
                            {
                                useParents += "Null:" + item.Null + " ";

                            }

                        }
                        
                        return useParents;
                    }
                    return "NoParents";
                }
                return "NoParentData";
            }
            return "AlreadyProcessed";
        }

        public void processAtmosphere(ScanObjectBodyDetailed atmosphereData, int newRow)
        {
            string printAtmosphere = "";
            string leadingZero = "";
            if (atmosphereData != null)
            {
                if (atmosphereData.AtmosphereComposition != null)
                {
                    foreach (var item in atmosphereData.AtmosphereComposition)
                    {
                        //7
                        if (item.Percent < 1)
                        {
                            leadingZero = "0";
                        }
                        printAtmosphere += item.Name + "_" + leadingZero + "" + item.Percent.ToString("#.##") + "% ";
                    }
                }
            }
            DataGridViewRow row = mainform.dataGridViewBodies.Rows[newRow];
            row.MinimumHeight = 50;

            mainform.dataGridViewBodies[3, newRow].Value += printAtmosphere;
        }
        public void processMaterialScan(ScanObjectBodyDetailed materialData, int newRow)
        {
            string printMats = "";
            string leadingZero = "";
            if (mainform != null)
            {
                if (materialData != null)
                {
                    if (materialData.Materials != null)
                    {
                        foreach (var item in materialData.Materials)
                        {
                            //7
                            if (item != null)
                            {
                                if (item.Name != null)
                                {
                                    if (mainform.materialCount.ContainsKey(item.Name) == false)
                                    {
                                        mainform.materialCount.Add(item.Name, 0);

                                    }
                                    if (mainform.materialCount[item.Name] < 10)
                                    {
                                        if (item.Percent < 1)
                                        {
                                            leadingZero = "0";
                                        }
                                        printMats += item.Name + "_" + leadingZero + "" + item.Percent.ToString("#.##") + "%_" + "(" + mainform.materialCount[item.Name] + ") ";
                                    }
                                }
                            }
                        }
                        DataGridViewRow row = mainform.dataGridViewBodies.Rows[newRow];
                        row.MinimumHeight = 50;

                        mainform.dataGridViewBodies[7, newRow].Value = printMats;
                    }
                }
            }
        }

        public void parseStar(ScanObjectBodyDetailed bodyData)
        {
            if(mainform != null) {
                if (bodyData != null)
                {
                    if (bodyData.BodyName != null)
                    {
                        var useTemp = Convert.ToInt32(bodyData.SurfaceTemperature);
                        double tempInCelsius = useTemp - 273.15;
                        int newRow = mainform.dataGridStars.Rows.Add(bodyData.BodyName, bodyData.StarType, bodyData.Luminosity,
                            string.Format("{0:N0}", bodyData.Age_MY),
                            string.Format("{0:N0}", bodyData.Radius),
                             bodyData.StellarMass,
                            string.Format("{0:N0}", useTemp) + "K (" + tempInCelsius.ToString("#.##") + "C)",
                            bodyData.DistanceFromArrivalLS,
                            bodyData.BodyID
                          );
                        mainform.usedBodies.Add(bodyData.BodyName, newRow);
                    }
                }
            }
        }
    }

}
