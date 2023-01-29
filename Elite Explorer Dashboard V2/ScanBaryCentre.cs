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
        public void process(string line, runningDataObject runningData, DataGridView dataGridBodies)
        {
            ScanObjectBodyDetailed? bodyData = JsonSerializer.Deserialize<ScanObjectBodyDetailed>(line);

            string generatedBodyName = "BaryCentre-" + bodyData.BodyID;
            double speedOfLight = 299792458; // speed of light in meters per second

            if (runningData.bodyDictionary.ContainsKey(generatedBodyName) == false)
            {
                runningData.bodyDictionary.Add(bodyData.BodyID.ToString(), new ScanObjectBodyDetailed());

                runningData.bodyDictionary[generatedBodyName] = bodyData;
                runningData.bodyDictionary[generatedBodyName].BodyName = generatedBodyName;

                runningData.bodyIDToName[bodyData.BodyID] = generatedBodyName;
                runningData.bodyDictionary[generatedBodyName].MeanAnomalyRadians = (Math.PI / 180) * bodyData.MeanAnomaly;
                runningData.bodyDictionary[generatedBodyName].EccentricAnomaly = OrbitMathFunctions.CalculateEccentricAnomaly(bodyData.SemiMajorAxis, bodyData.Eccentricity, runningData.bodyDictionary[generatedBodyName].MeanAnomalyRadians);
                runningData.bodyDictionary[generatedBodyName].TrueAnomaly = OrbitMathFunctions.CalculateTrueAnomaly(
                    bodyData.SemiMajorAxis,
                    bodyData.Eccentricity,
                    runningData.bodyDictionary[generatedBodyName].EccentricAnomaly,
                    runningData.bodyDictionary[generatedBodyName].MeanAnomalyRadians
                );

                runningData.bodyDictionary[generatedBodyName].InclinationRadians = (Math.PI / 180) * bodyData.OrbitalInclination;
                runningData.bodyDictionary[generatedBodyName].AscendingNodeRadians = (Math.PI / 180) * bodyData.AscendingNode;
                runningData.bodyDictionary[generatedBodyName].PeriapsisRadians = (Math.PI / 180) * bodyData.Periapsis;

                runningData.bodyDictionary[generatedBodyName].XYZ = OrbitMathFunctions.ConvertToCartesian(
                    bodyData.SemiMajorAxis,
                    bodyData.Eccentricity,
                    runningData.bodyDictionary[generatedBodyName].InclinationRadians,
                    runningData.bodyDictionary[generatedBodyName].AscendingNodeRadians,
                    runningData.bodyDictionary[generatedBodyName].PeriapsisRadians,
                    runningData.bodyDictionary[generatedBodyName].TrueAnomaly
                );
                runningData.bodyDictionary[generatedBodyName].DistanceToParentMeters = Math.Sqrt(Math.Pow(runningData.bodyDictionary[generatedBodyName].XYZ[0] - 0, 2) 
                    + Math.Pow(runningData.bodyDictionary[generatedBodyName].XYZ[1] - 0, 2) 
                    + Math.Pow(runningData.bodyDictionary[generatedBodyName].XYZ[2] - 0, 2));
                runningData.bodyDictionary[generatedBodyName].DistancetoParentsLS = runningData.bodyDictionary[generatedBodyName].DistanceToParentMeters / speedOfLight;
                runningData.bodyDictionary[generatedBodyName].Children = new List<int>();
                runningData.bodyDictionary[generatedBodyName].FoundParent = -99;

                int newBaryRow = dataGridBodies.Rows.Add(
                generatedBodyName,
                "NA",
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
                runningData.bodyDictionary[generatedBodyName].GridRow = newBaryRow;

            }
        }
    


}
}
