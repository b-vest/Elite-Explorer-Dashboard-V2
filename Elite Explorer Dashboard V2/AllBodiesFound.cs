using ScottPlot.Palettes;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Elite_Explorer_Dashboard_V2
{
    public class AllBodiesFound
    {
        EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];
        public void process(string line)
        {
            FSSAllBodiesFound? edObject = JsonSerializer.Deserialize<FSSAllBodiesFound>(line);

            if (edObject != null)
            {
                mainform.labelBodiesFound.Text = "All " + edObject.Count + " Bodies in " + edObject.SystemName + " have been scanned.";
            }
            if (mainform.dataGridViewBodies.Rows != null && mainform.dataGridViewBodies.Rows.Count != 0)
            {
                mainform.dataGridViewBodies.Sort(mainform.dataGridViewBodies.Columns["BID"], ListSortDirection.Ascending);
                mainform.dataGridViewOM.Sort(mainform.dataGridViewOM.Columns["OMBID"], ListSortDirection.Ascending);

                calculateChildren();

                processDistances();

                updateGrid();

            }
        }

        public void updateGrid()
        {
            foreach (var body in mainform.bodyDictionary)
            {
                ScanObjectBodyDetailed bodyInfo = body.Value;
                int checkInt = 0;
                bool isInt = int.TryParse(body.Key, out checkInt);
                if (isInt == false && bodyInfo.BodyName.Contains("Belt Cluster") == false && bodyInfo.BodyName.Contains("System Center") == false)
                {
                    string useNeighbor = bodyInfo.NeighborName + " (" + string.Format("{0:N6}", bodyInfo.NeighborLS) + ")";
                    mainform.richTextBoxDebug.AppendText(useNeighbor + Environment.NewLine + Environment.NewLine);
                    mainform.dataGridViewBodies[17, mainform.usedBodies[bodyInfo.BodyName]].Value = useNeighbor;

                    if(bodyInfo.NeighborLS >= 1)
                    {
                        mainform.dataGridViewBodies[17, mainform.usedBodies[bodyInfo.BodyName]].Style.BackColor = Color.Green;
                        mainform.dataGridViewBodies[17, mainform.usedBodies[bodyInfo.BodyName]].Style.ForeColor = Color.White;
                    }
                    if (bodyInfo.NeighborLS < 1 && bodyInfo.NeighborLS >=0.01)
                    {
                        mainform.dataGridViewBodies[17, mainform.usedBodies[bodyInfo.BodyName]].Style.BackColor = Color.Orange;
                        mainform.dataGridViewBodies[17, mainform.usedBodies[bodyInfo.BodyName]].Style.ForeColor = Color.White;
                    }
                    if (bodyInfo.NeighborLS < 0.01)
                    {
                        mainform.dataGridViewBodies[17, mainform.usedBodies[bodyInfo.BodyName]].Style.BackColor = Color.Red;
                        mainform.dataGridViewBodies[17, mainform.usedBodies[bodyInfo.BodyName]].Style.ForeColor = Color.White;
                    }
                }
            }
        }
        public void calculateChildren()
        {
            if (mainform.bodyDictionary.ContainsKey("-99") == false)
            {
                string generatedBodyname = "System Center";
                int generatedBodyID = -99;

                mainform.bodyDictionary.Add(generatedBodyID.ToString(), new ScanObjectBodyDetailed());

                mainform.bodyDictionary.Add(generatedBodyname, new ScanObjectBodyDetailed());

                mainform.bodyDictionary[generatedBodyID.ToString()].BodyID = generatedBodyID;
                mainform.bodyDictionary[generatedBodyID.ToString()].BodyName = generatedBodyname;
                mainform.bodyDictionary[generatedBodyname].BodyName = generatedBodyname;
                mainform.bodyDictionary[generatedBodyname].BodyID = generatedBodyID;

                mainform.bodyDictionary[generatedBodyname].SemiMajorAxis = 0;
                mainform.bodyDictionary[generatedBodyname].Eccentricity = 0;
                mainform.bodyDictionary[generatedBodyname].OrbitalInclination = 0;
                mainform.bodyDictionary[generatedBodyname].Periapsis = 0;
                mainform.bodyDictionary[generatedBodyname].OrbitalPeriod = 0;
                mainform.bodyDictionary[generatedBodyname].AscendingNode = 0;
                mainform.bodyDictionary[generatedBodyname].MeanAnomaly = 0;
                mainform.bodyDictionary[generatedBodyname].DistanceToParentMeters = 0;
                mainform.bodyDictionary[generatedBodyname].FoundParent = 0;
                mainform.bodyDictionary[generatedBodyname].Children = new List<int>();
                mainform.bodyDictionary[generatedBodyname].XYZ = new double[3];
                mainform.bodyDictionary[generatedBodyname].XYZ[0] = 0;
                mainform.bodyDictionary[generatedBodyname].XYZ[1] = 0;
                mainform.bodyDictionary[generatedBodyname].XYZ[1] = 0;

            }
            foreach (var body in mainform.bodyDictionary)
            {
                ScanObjectBodyDetailed bodyInfo = body.Value;
                mainform.richTextBoxDebug.AppendText(JsonSerializer.Serialize(bodyInfo.BodyID, new JsonSerializerOptions { WriteIndented = true }) + Environment.NewLine + Environment.NewLine);
                mainform.richTextBoxDebug.ScrollToCaret();
                if (bodyInfo.BodyName != null)
                {
                    int checkInt = 0;
                    bool isInt = int.TryParse(body.Key, out checkInt);
                    if (isInt == false && bodyInfo.BodyName.Contains("Belt Cluster") == false)
                    {
                        mainform.richTextBoxDebug.AppendText(bodyInfo.BodyName + Environment.NewLine);
                        int? useParent = bodyInfo.FoundParent;
                        if (mainform.bodyDictionary.ContainsKey(useParent.ToString()) == false)
                        {
                            useParent = -99;


                        }

                        string parentName = mainform.bodyDictionary[useParent.ToString()].BodyName;

                        //mainform.bodyDictionary[parentName].Children.Add(bodyInfo.BodyID);

                        mainform.richTextBoxDebug.AppendText(parentName + " " + useParent + Environment.NewLine);
                        mainform.richTextBoxDebug.ScrollToCaret();

                        Debug.WriteLine(parentName);
                        if (mainform.bodyDictionary[parentName] != null)
                        {
                            mainform.bodyDictionary[parentName].Children.Add(bodyInfo.BodyID);
                        }

                    }
                }
            }
        }

        public void processDistances()
        {
            double speedOfLight = 299792458; // speed of light in meters per second


            mainform.richTextBoxDebug.AppendText("Calculating Distances" + Environment.NewLine);
            mainform.richTextBoxDebug.ScrollToCaret();
            foreach (var body in mainform.bodyDictionary)
            {
                ScanObjectBodyDetailed bodyInfo = body.Value;

                int checkInt = 0;
                bool isInt = int.TryParse(body.Key, out checkInt);
                if (isInt == false && bodyInfo.BodyName.Contains("Belt Cluster") == false)
                {
                    mainform.richTextBoxDebug.AppendText(bodyInfo.BodyName + Environment.NewLine);
                    foreach (var i in bodyInfo.Children)
                    {
                        if (i != bodyInfo.BodyID)
                        {
                            mainform.richTextBoxDebug.AppendText("\t" + i.ToString() + Environment.NewLine);
                            var childName = mainform.bodyDictionary[i.ToString()].BodyName;

                            foreach (var j in bodyInfo.Children)
                            {
                                if(i != j)
                                {
                                    if (j != bodyInfo.BodyID)
                                    {
                                        var childName2 = mainform.bodyDictionary[j.ToString()].BodyName;

                                            Debug.WriteLine(childName + " " + childName2);
                                            double distance = Math.Sqrt(Math.Pow(mainform.bodyDictionary[childName].XYZ[0] - mainform.bodyDictionary[childName2].XYZ[0], 2) + Math.Pow(mainform.bodyDictionary[childName].XYZ[1] - mainform.bodyDictionary[childName2].XYZ[1], 2) + Math.Pow(mainform.bodyDictionary[childName].XYZ[2] - mainform.bodyDictionary[childName2].XYZ[2], 2));
                                            double lightSeconds = distance / speedOfLight;

                                            mainform.richTextBoxDebug.AppendText("\t\tCalculating " + childName + " To " + childName2 + " " + lightSeconds + Environment.NewLine);
                                            if (mainform.bodyDictionary[childName].NeighborMeters == null || mainform.bodyDictionary[childName].NeighborMeters > lightSeconds)
                                            {
                                                mainform.bodyDictionary[childName].NeighborMeters = distance;
                                                mainform.bodyDictionary[childName].NeighborLS = lightSeconds;
                                                mainform.bodyDictionary[childName].NeighborName = childName2;

                                            }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            mainform.richTextBoxDebug.AppendText(JsonSerializer.Serialize(mainform.bodyDictionary, new JsonSerializerOptions { WriteIndented = true }) + Environment.NewLine + Environment.NewLine);

        }
    }
}
       