using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
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
        EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

        public void process(string line)
        {

            ScanObjectBodyDetailed? edObject = JsonSerializer.Deserialize<ScanObjectBodyDetailed>(line);



            double speedOfLight = 299792458; // speed of light in meters per second

            if (mainform.CompleteDict.ContainsKey(edObject.BodyName.ToString()) == false)
            {
                mainform.CompleteDict.Add(edObject.BodyName, new Dictionary<string, dynamic>());

                mainform.CompleteDict[edObject.BodyName]["x"] = 0;
                mainform.CompleteDict[edObject.BodyName]["y"] = 0;
                mainform.CompleteDict[edObject.BodyName]["z"] = 0;

                mainform.CompleteDict[edObject.BodyName]["BodyName"] = edObject.BodyName;
                mainform.CompleteDict[edObject.BodyName]["BodyID"] = edObject.BodyID;
                mainform.CompleteDict[edObject.BodyName]["Parents"] = "";
                mainform.CompleteDict[edObject.BodyName]["DistanceFromArrivalLS"] = edObject.DistanceFromArrivalLS;
                mainform.CompleteDict[edObject.BodyName]["MassEM"] = edObject.MassEM;
                mainform.CompleteDict[edObject.BodyName]["Radius"] = edObject.Radius;
                if (edObject.SemiMajorAxis == null)
                {
                    mainform.CompleteDict[edObject.BodyName]["SemiMajorAxis"] = 0;
                    mainform.CompleteDict[edObject.BodyName]["Eccentricity"] = 0;
                    mainform.CompleteDict[edObject.BodyName]["OrbitalInclination"] = 0;
                    mainform.CompleteDict[edObject.BodyName]["Periapsis"] = 0;
                    mainform.CompleteDict[edObject.BodyName]["OrbitalPeriod"] = 0;
                    mainform.CompleteDict[edObject.BodyName]["AscendingNode"] = 0;
                    mainform.CompleteDict[edObject.BodyName]["MeanAnomaly"] = 0;
                    mainform.CompleteDict[edObject.BodyName]["distanceParentMeters"] = 0;
                }
                else
                {
                    mainform.CompleteDict[edObject.BodyName]["SemiMajorAxis"] = edObject.SemiMajorAxis;
                    mainform.CompleteDict[edObject.BodyName]["Eccentricity"] = edObject.Eccentricity;
                    mainform.CompleteDict[edObject.BodyName]["OrbitalInclination"] = edObject.OrbitalInclination;
                    mainform.CompleteDict[edObject.BodyName]["Periapsis"] = edObject.Periapsis;
                    mainform.CompleteDict[edObject.BodyName]["OrbitalPeriod"] = edObject.OrbitalPeriod;
                    mainform.CompleteDict[edObject.BodyName]["AscendingNode"] = edObject.AscendingNode;
                    mainform.CompleteDict[edObject.BodyName]["MeanAnomaly"] = edObject.MeanAnomaly;

                    mainform.CompleteDict[edObject.BodyName]["MARadians"] = (Math.PI / 180) * edObject.MeanAnomaly;
                    mainform.CompleteDict[edObject.BodyName]["EA"] = CalculateEccentricAnomaly(edObject.SemiMajorAxis, edObject.Eccentricity, mainform.CompleteDict[edObject.BodyName]["MARadians"]);
                    mainform.CompleteDict[edObject.BodyName]["TA"] = CalculateTrueAnomaly(edObject.SemiMajorAxis, edObject.Eccentricity, mainform.CompleteDict[edObject.BodyName]["EA"], mainform.CompleteDict[edObject.BodyName]["MARadians"]);
                    mainform.CompleteDict[edObject.BodyName]["inclinationRadians"] = (Math.PI / 180) * edObject.OrbitalInclination;
                    mainform.CompleteDict[edObject.BodyName]["raanRadians"] = (Math.PI / 180) * edObject.AscendingNode;
                    mainform.CompleteDict[edObject.BodyName]["aopRadians"] = (Math.PI / 180) * edObject.Periapsis;

                    double[] xyz = ConvertToCartesian(edObject.SemiMajorAxis, edObject.Eccentricity, mainform.CompleteDict[edObject.BodyName]["inclinationRadians"], mainform.CompleteDict[edObject.BodyName]["raanRadians"], mainform.CompleteDict[edObject.BodyName]["aopRadians"], mainform.CompleteDict[edObject.BodyName]["TA"]);
                    mainform.CompleteDict[edObject.BodyName]["x"] = xyz[0];
                    mainform.CompleteDict[edObject.BodyName]["y"] = xyz[1];
                    mainform.CompleteDict[edObject.BodyName]["z"] = xyz[2];
                    mainform.CompleteDict[edObject.BodyName]["distanceParentMeters"] = Math.Sqrt(Math.Pow(xyz[0] - 0, 2) + Math.Pow(xyz[1] - 0, 2) + Math.Pow(xyz[2] - 0, 2));
                    mainform.CompleteDict[edObject.BodyName]["distanceParentLS"] = mainform.CompleteDict[edObject.BodyName]["distanceParentMeters"] / speedOfLight;

                    mainform.CompleteDict[edObject.BodyName]["Parent"] = processParents(edObject);

                }

                mainform.richTextBoxDebug.AppendText(JsonSerializer.Serialize(mainform.CompleteDict[edObject.BodyName])+Environment.NewLine+Environment.NewLine);
                mainform.richTextBoxDebug.ScrollToCaret();
            }
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
            string useBodyClass = bodyData.PlanetClass;
            if(useBodyClass == "High metal content body") { useBodyClass = "HMC"; }
            if (useBodyClass == "Rocky body") { useBodyClass = "RB"; }
            if (useBodyClass == "Sudarsky class III gas giant") { useBodyClass = "SIIIGG"; }
            if (useBodyClass == "Gas giant with water based life") { useBodyClass = "GGWBL"; }
            if (useBodyClass == "Icy body") { useBodyClass = "IB"; }



            var useGravity = bodyData.SurfaceGravity / 10;
            var useTemp = Convert.ToInt32(bodyData.SurfaceTemperature);
            double tempInCelsius = useTemp - 273.15;
            int newRow = mainform.dataGridViewBodies.Rows.Add(
                bodyData.BodyName,
                bodyData.Landable,
                useBodyClass,
                "",
                useGravity.ToString("#.##"),
                useTemp + "K (" + tempInCelsius.ToString("#.##") + "C)",
               string.Format("{0:N}", bodyData.Radius),
                0,
                0,
                string.Format("{0:N3}", bodyData.DistanceFromArrivalLS)+" ("+string.Format("{0:N4}",mainform.CompleteDict[bodyData.BodyName]["distanceParentLS"])+")",
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
            string useParent = "";
            if (mainform.usedParents.ContainsKey(parentsData.BodyName) == false)
            {
                if (parentsData != null)
                {
                    if (parentsData.Parents != null)
                    {
                        mainform.richTextBoxDebug.AppendText(JsonSerializer.Serialize(parentsData.Parents) + Environment.NewLine + Environment.NewLine);
                        mainform.richTextBoxDebug.ScrollToCaret();
                        if (parentsData.Parents[0].Star != null)
                        {
                            useParent = parentsData.Parents[0].Star.ToString();
                        }else if (parentsData.Parents[0].Planet != null)
                        {
                            useParent = parentsData.Parents[0].Planet.ToString();

                        }
                        else if (parentsData.Parents[0].Null != null)
                        {
                            useParent = parentsData.Parents[0].Null.ToString();

                        }
                        mainform.richTextBoxDebug.AppendText(useParent+ Environment.NewLine+Environment.NewLine);
                        return useParent;
                    }

                    
                    //return "MaybeBarycentre";
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
                            if (item.Name == "zirconium") { item.Name = "Zr"; }
                            if (item.Name == "arsenic") { item.Name = "As"; }
                            if (item.Name == "technetium") { item.Name = "Tc"; }


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
                                        string useName = item.Name;
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
                        int newStarRow = mainform.dataGridStars.Rows.Add(bodyData.BodyName, bodyData.StarType, bodyData.Luminosity,
                            string.Format("{0:N0}", bodyData.Age_MY),
                            string.Format("{0:N0}", bodyData.Radius),
                             bodyData.StellarMass,
                            string.Format("{0:N0}", useTemp) + "K (" + tempInCelsius.ToString("#.##") + "C)",
                            bodyData.DistanceFromArrivalLS,
                            bodyData.BodyID
                          );
                        useTemp = Convert.ToInt32(bodyData.SurfaceTemperature);

                        //Add identifier to bodies table
                        tempInCelsius = useTemp - 273.15;
                        string primaryString = "Secondary";
                        if(bodyData.DistanceFromArrivalLS == 0)
                        {
                            primaryString = "Primary";
                        }
                        int newBodyRow = mainform.dataGridViewBodies.Rows.Add(
                        bodyData.BodyName,
                        primaryString+" Star",
                        "-",
                        "-",
                        bodyData.StellarMass.ToString("#.##"),
                        useTemp + "K (" + tempInCelsius.ToString("#.##") + "C)",
                        string.Format("{0:N}", bodyData.Radius),
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


                        //Add to OM tables
                        if (bodyData.DistanceFromArrivalLS > 0)
                        {
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
                        }
                        else
                        {
                            mainform.dataGridViewOM.Rows.Add(
                            bodyData.BodyName,
                            bodyData.BodyID,
                            "Primary Star",
                            string.Format("{0:N0}", bodyData.DistanceFromArrivalLS),
                            bodyData.StellarMass,
                            string.Format("{0:N0}", bodyData.Radius),
                            "-",
                            "-",
                            "-",
                            "-",
                            "-",
                            "-",
                            "-"
                            );
                        }


                        mainform.usedBodies.Add(bodyData.BodyName, newStarRow);
                    }
                }
            }
        }
        static double[] ConvertToCartesian(double a, double e, double i, double raan, double aop, double ta)
        {
            double[] xyz = new double[3];

            // Calculate r
            double r = a * (1 - e * e) / (1 + e * Math.Cos(ta));

            // Calculate x, y, z
            xyz[0] = r * (Math.Cos(raan) * Math.Cos(aop + ta) - Math.Sin(raan) * Math.Sin(aop + ta) * Math.Cos(i));
            xyz[1] = r * (Math.Sin(raan) * Math.Cos(aop + ta) + Math.Cos(raan) * Math.Sin(aop + ta) * Math.Cos(i));
            xyz[2] = r * Math.Sin(aop + ta) * Math.Sin(i);

            return xyz;
        }
        static double CalculateEccentricAnomaly(double a, double e, double M)
        {
            double E = M;
            double tolerance = 1e-8;
            double maxIterations = 100;

            for (int i = 0; i < maxIterations; i++)
            {
                double error = E - e * Math.Sin(E) - M;
                if (Math.Abs(error) < tolerance)
                {
                    break;
                }
                E = E - error / (1 - e * Math.Cos(E));
            }

            return E;
        }
        static double CalculateTrueAnomaly(double a, double e, double E, double M)
        {
            double ta = 0.0;
            if (e < 1) // elliptical orbit
            {
                ta = 2 * Math.Atan(Math.Sqrt((1 + e) / (1 - e)) * Math.Tan(E / 2));
            }
            else if (e == 1) // parabolic orbit
            {
                ta = 2 * Math.Atan(Math.Tan(E / 2));
            }
            else // hyperbolic orbit
            {
                ta = 2 * Math.Atan(Math.Sqrt((e + 1) / (e - 1)) * Math.Tanh(E / 2));
            }
            return ta;
        }
    }

}
