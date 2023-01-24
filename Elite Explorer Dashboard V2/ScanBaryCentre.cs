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
                mainform.bodyDictionary[generatedBodyName].EccentricAnomaly = CalculateEccentricAnomaly(bodyData.SemiMajorAxis, bodyData.Eccentricity, mainform.bodyDictionary[generatedBodyName].MeanAnomalyRadians);
                mainform.bodyDictionary[generatedBodyName].TrueAnomaly = CalculateTrueAnomaly(
                    bodyData.SemiMajorAxis,
                    bodyData.Eccentricity,
                    mainform.bodyDictionary[generatedBodyName].EccentricAnomaly,
                    mainform.bodyDictionary[generatedBodyName].MeanAnomalyRadians
                );

                mainform.bodyDictionary[generatedBodyName].InclinationRadians = (Math.PI / 180) * bodyData.OrbitalInclination;
                mainform.bodyDictionary[generatedBodyName].AscendingNodeRadians = (Math.PI / 180) * bodyData.AscendingNode;
                mainform.bodyDictionary[generatedBodyName].PeriapsisRadians = (Math.PI / 180) * bodyData.Periapsis;

                mainform.bodyDictionary[generatedBodyName].XYZ = ConvertToCartesian(
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
