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

            if (mainform.CompleteDict.ContainsKey(generatedBodyName) == false)
            {
                mainform.CompleteDict.Add(generatedBodyName, new Dictionary<string, dynamic>());
                mainform.CompleteDict[generatedBodyName]["SemiMajorAxis"] = bodyData.SemiMajorAxis;
                mainform.CompleteDict[generatedBodyName]["Eccentricity"] = bodyData.Eccentricity;
                mainform.CompleteDict[generatedBodyName]["OrbitalInclination"] = bodyData.OrbitalInclination;
                mainform.CompleteDict[generatedBodyName]["Periapsis"] = bodyData.Periapsis;
                mainform.CompleteDict[generatedBodyName]["AscendingNode"] = bodyData.AscendingNode;
                mainform.CompleteDict[generatedBodyName]["MeanAnomaly"] = bodyData.MeanAnomaly;

                mainform.CompleteDict[generatedBodyName]["MARadians"] = (Math.PI / 180) * bodyData.MeanAnomaly;
                mainform.CompleteDict[generatedBodyName]["EA"] = CalculateEccentricAnomaly(bodyData.SemiMajorAxis, bodyData.Eccentricity, mainform.CompleteDict[generatedBodyName]["MARadians"]);
                mainform.CompleteDict[generatedBodyName]["TA"] = CalculateTrueAnomaly(bodyData.SemiMajorAxis, bodyData.Eccentricity, mainform.CompleteDict[generatedBodyName]["EA"], mainform.CompleteDict[generatedBodyName]["MARadians"]);
                mainform.CompleteDict[generatedBodyName]["inclinationRadians"] = (Math.PI / 180) * bodyData.OrbitalInclination;
                mainform.CompleteDict[generatedBodyName]["raanRadians"] = (Math.PI / 180) * bodyData.AscendingNode;
                mainform.CompleteDict[generatedBodyName]["aopRadians"] = (Math.PI / 180) * bodyData.Periapsis;

                double speedOfLight = 299792458; // speed of light in meters per second
                double[] xyz = ConvertToCartesian(bodyData.SemiMajorAxis, bodyData.Eccentricity, mainform.CompleteDict[generatedBodyName]["inclinationRadians"], mainform.CompleteDict[generatedBodyName]["raanRadians"], mainform.CompleteDict[generatedBodyName]["aopRadians"], mainform.CompleteDict[generatedBodyName]["TA"]);
                mainform.CompleteDict[generatedBodyName]["x"] = xyz[0];
                mainform.CompleteDict[generatedBodyName]["y"] = xyz[1];
                mainform.CompleteDict[generatedBodyName]["z"] = xyz[2];
                mainform.CompleteDict[generatedBodyName]["distanceParentMeters"] = Math.Sqrt(Math.Pow(xyz[0] - 0, 2) + Math.Pow(xyz[1] - 0, 2) + Math.Pow(xyz[2] - 0, 2));
                mainform.CompleteDict[generatedBodyName]["distanceParentLS"] = mainform.CompleteDict[generatedBodyName]["distanceParentMeters"] / speedOfLight;

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
