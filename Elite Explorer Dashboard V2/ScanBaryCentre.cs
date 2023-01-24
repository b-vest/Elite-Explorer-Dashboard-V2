using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class ScanBaryCentre
    {
        EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];
        public void process(string line)
        {
            ScanObjectBodyDetailed? bodyData = JsonSerializer.Deserialize<ScanObjectBodyDetailed>(line);

            string generatedBodyName = "BaryCentre-" + bodyData.BodyID;
            double speedOfLight = 299792458; // speed of light in meters per second

            if (mainform.bodyDictionary.ContainsKey(generatedBodyName) == false)
            {
                mainform.bodyDictionary.Add(bodyData.BodyID.ToString(), new ScanObjectBodyDetailed());

                mainform.bodyDictionary[generatedBodyName] = bodyData;
                mainform.bodyDictionary[generatedBodyName].BodyName = generatedBodyName;
                mainform.bodyDictionary[bodyData.BodyID.ToString()].BodyName = generatedBodyName;
                mainform.bodyDictionary[generatedBodyName].MeanAnomalyRadians = (Math.PI / 180) * bodyData.MeanAnomaly;
                mainform.bodyDictionary[generatedBodyName].EccentricAnomaly = OrbitMathFunctions.CalculateEccentricAnomaly(bodyData.SemiMajorAxis, bodyData.Eccentricity, mainform.bodyDictionary[generatedBodyName].MeanAnomalyRadians);
                mainform.bodyDictionary[generatedBodyName].TrueAnomaly = OrbitMathFunctions.CalculateTrueAnomaly(
                    bodyData.SemiMajorAxis,
                    bodyData.Eccentricity,
                    mainform.bodyDictionary[generatedBodyName].EccentricAnomaly,
                    mainform.bodyDictionary[generatedBodyName].MeanAnomalyRadians
                );

                mainform.bodyDictionary[generatedBodyName].InclinationRadians = (Math.PI / 180) * bodyData.OrbitalInclination;
                mainform.bodyDictionary[generatedBodyName].AscendingNodeRadians = (Math.PI / 180) * bodyData.AscendingNode;
                mainform.bodyDictionary[generatedBodyName].PeriapsisRadians = (Math.PI / 180) * bodyData.Periapsis;

                mainform.bodyDictionary[generatedBodyName].XYZ = OrbitMathFunctions.ConvertToCartesian(
                    bodyData.SemiMajorAxis,
                    bodyData.Eccentricity,
                    mainform.bodyDictionary[generatedBodyName].InclinationRadians,
                    mainform.bodyDictionary[generatedBodyName].AscendingNodeRadians,
                    mainform.bodyDictionary[generatedBodyName].PeriapsisRadians,
                    mainform.bodyDictionary[generatedBodyName].TrueAnomaly
                );
                mainform.bodyDictionary[generatedBodyName].DistanceToParentMeters = Math.Sqrt(Math.Pow(mainform.bodyDictionary[generatedBodyName].XYZ[0] - 0, 2) + Math.Pow(mainform.bodyDictionary[generatedBodyName].XYZ[1] - 0, 2) + Math.Pow(mainform.bodyDictionary[generatedBodyName].XYZ[2] - 0, 2));
                mainform.bodyDictionary[generatedBodyName].DistancetoParentsLS = mainform.bodyDictionary[generatedBodyName].DistanceToParentMeters / speedOfLight;
                mainform.bodyDictionary[generatedBodyName].Children = new List<int>();
                mainform.bodyDictionary[generatedBodyName].FoundParent = -99;

                int newBaryRow = mainform.dataGridViewBodies.Rows.Add(
                generatedBodyName,
                "BaryCentre",
                "BaryCentre",
                "--",
                "--",
                "--",
                "--",
                "--",
                "--",
                "--",
                "--",
                "--",
                "--",
                "--",
                "--",
                "--",
                bodyData.BodyID,
                ""
                );
                mainform.richTextBoxDebug.AppendText("BaryCentre New Row: "+ newBaryRow + Environment.NewLine);

                mainform.bodyDictionary[generatedBodyName].GridRow = newBaryRow;

            }
        }
    


}
}
