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
        public void process(string line, runningDataObject runningData, DataGridView dataGridBodies, TextBox labelBodiesFound)
        {
            FSSAllBodiesFound? edObject = JsonSerializer.Deserialize<FSSAllBodiesFound>(line);

            if (edObject != null)
            {
                labelBodiesFound.Text = "All " + edObject.Count + " Bodies in " + edObject.SystemName + " have been scanned.";
            }
            if (dataGridBodies.Rows != null && dataGridBodies.Rows.Count != 0)
            {
                dataGridBodies.Sort(dataGridBodies.Columns["BID"], ListSortDirection.Ascending);

                runningData = calculateChildren(runningData);

                runningData = processDistances(runningData);

                updateGrid(runningData, dataGridBodies);

            }
        }

        public void updateGrid(runningDataObject runningData, DataGridView dataGridBodies)
        {
            foreach (var body in runningData.bodyDictionary)
            {
                ScanObjectBodyDetailed bodyInfo = body.Value;
                int checkInt = 0;
                bool isInt = int.TryParse(body.Key, out checkInt);
                if (isInt == false && bodyInfo.BodyName.Contains("Belt Cluster") == false && bodyInfo.BodyName.Contains("System Center") == false)
                {
                    string useNeighbor = bodyInfo.NeighborName + " (" + string.Format("{0:N6}", bodyInfo.NeighborLS) + ")";
                    dataGridBodies[17, runningData.usedBodies[bodyInfo.BodyName]].Value = useNeighbor;

                    if(bodyInfo.NeighborLS >= 1)
                    {
                        dataGridBodies[17, runningData.usedBodies[bodyInfo.BodyName]].Style.BackColor = Color.Green;
                        dataGridBodies[17, runningData.usedBodies[bodyInfo.BodyName]].Style.ForeColor = Color.White;
                    }
                    if (bodyInfo.NeighborLS < 1 && bodyInfo.NeighborLS >=0.01)
                    {
                        dataGridBodies[17, runningData.usedBodies[bodyInfo.BodyName]].Style.BackColor = Color.Orange;
                        dataGridBodies[17, runningData.usedBodies[bodyInfo.BodyName]].Style.ForeColor = Color.White;
                    }
                    if (bodyInfo.NeighborLS < 0.01)
                    {
                        dataGridBodies[17, runningData.usedBodies[bodyInfo.BodyName]].Style.BackColor = Color.Red;
                        dataGridBodies[17, runningData.usedBodies[bodyInfo.BodyName]].Style.ForeColor = Color.White;
                    }
                }
            }
        }
        public runningDataObject calculateChildren(runningDataObject runningData)
        {
            if (runningData.bodyDictionary.ContainsKey("-99") == false)
            {
                string generatedBodyname = "System Center";
                int generatedBodyID = -99;

                runningData.bodyIDToName[generatedBodyID] = generatedBodyname;

                runningData.bodyDictionary.Add(generatedBodyID.ToString(), new ScanObjectBodyDetailed());

                runningData.bodyDictionary.Add(generatedBodyname, new ScanObjectBodyDetailed());



                runningData.bodyDictionary[generatedBodyID.ToString()].BodyID = generatedBodyID;
                runningData.bodyDictionary[generatedBodyID.ToString()].BodyName = generatedBodyname;
                runningData.bodyDictionary[generatedBodyname].BodyName = generatedBodyname;
                runningData.bodyDictionary[generatedBodyname].BodyID = generatedBodyID;

                runningData.bodyDictionary[generatedBodyname].SemiMajorAxis = 0;
                runningData.bodyDictionary[generatedBodyname].Eccentricity = 0;
                runningData.bodyDictionary[generatedBodyname].OrbitalInclination = 0;
                runningData.bodyDictionary[generatedBodyname].Periapsis = 0;
                runningData.bodyDictionary[generatedBodyname].OrbitalPeriod = 0;
                runningData.bodyDictionary[generatedBodyname].AscendingNode = 0;
                runningData.bodyDictionary[generatedBodyname].MeanAnomaly = 0;
                runningData.bodyDictionary[generatedBodyname].DistanceToParentMeters = 0;
                runningData.bodyDictionary[generatedBodyname].FoundParent = 0;
                runningData.bodyDictionary[generatedBodyname].Children = new List<int>();
                runningData.bodyDictionary[generatedBodyname].XYZ = new double[3];
                runningData.bodyDictionary[generatedBodyname].XYZ[0] = 0;
                runningData.bodyDictionary[generatedBodyname].XYZ[1] = 0;
                runningData.bodyDictionary[generatedBodyname].XYZ[1] = 0;

            }
           

            foreach (var body in runningData.bodyDictionary)
            {
                ScanObjectBodyDetailed bodyInfo = body.Value;
            
                if (bodyInfo.BodyName != null)
                {
                    Debug.WriteLine(bodyInfo.BodyID + " "+bodyInfo.BodyName+Environment.NewLine);
                    int checkInt = 0;
                    bool isInt = int.TryParse(body.Key, out checkInt);
                    if (isInt == false && bodyInfo.BodyName.Contains("Belt Cluster") == false)
                    {
                        int? useParent = bodyInfo.FoundParent;
                        if (runningData.bodyDictionary.ContainsKey(useParent.ToString()) == false)
                        {
                            useParent = -99;
                        }
                        string parentName = runningData.bodyIDToName[useParent];
                        if (runningData.bodyDictionary[parentName] != null)
                        {
                            runningData.bodyDictionary[parentName].Children.Add(bodyInfo.BodyID);
                        }

                    }
                }
            }
            return runningData;
        }

        public runningDataObject processDistances(runningDataObject runningData)
        {
            double speedOfLight = 299792458; // speed of light in meters per second

            foreach (var body in runningData.bodyDictionary)
            {
                ScanObjectBodyDetailed bodyInfo = body.Value;

                int checkInt = 0;
                bool isInt = int.TryParse(body.Key, out checkInt);
                if (isInt == false && bodyInfo.BodyName.Contains("Belt Cluster") == false)
                {
                    foreach (var i in bodyInfo.Children)
                    {
                        if (i != bodyInfo.BodyID)
                        {
                            var childName = runningData.bodyIDToName[i];

                            foreach (var j in bodyInfo.Children)
                            {
                                if(i != j)
                                {
                                    if (j != bodyInfo.BodyID)
                                    {
                                        var childName2 = runningData.bodyIDToName[j];

                                            double distance = Math.Sqrt(Math.Pow(runningData.bodyDictionary[childName].XYZ[0] - runningData.bodyDictionary[childName2].XYZ[0], 2) 
                                                + Math.Pow(runningData.bodyDictionary[childName].XYZ[1] - runningData.bodyDictionary[childName2].XYZ[1], 2) 
                                                + Math.Pow(runningData.bodyDictionary[childName].XYZ[2] - runningData.bodyDictionary[childName2].XYZ[2], 2));
                                            double lightSeconds = distance / speedOfLight;

                                            if (runningData.bodyDictionary[childName].NeighborMeters == null || runningData.bodyDictionary[childName].NeighborMeters > lightSeconds)
                                            {
                                                runningData.bodyDictionary[childName].NeighborMeters = distance;
                                                runningData.bodyDictionary[childName].NeighborLS = lightSeconds;
                                                runningData.bodyDictionary[childName].NeighborName = childName2;

                                            }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return runningData;
        }
        
    }
}
       