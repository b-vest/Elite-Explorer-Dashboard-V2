using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elite_Explorer_Dashboard_V2
{
    public class AllBodiesFound
    {
         EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];
        public void process(string line)
        {
            FSSAllBodiesFound? edObject = JsonSerializer.Deserialize<FSSAllBodiesFound>(line);
            mainform.labelBodiesFound.Text = "All " + edObject.Count + " Bodies in " + edObject.SystemName + " have been scanned.";
            if (mainform.dataGridViewBodies.Rows != null && mainform.dataGridViewBodies.Rows.Count != 0)
            {
                mainform.dataGridViewBodies.Sort(mainform.dataGridViewBodies.Columns["BID"], ListSortDirection.Ascending);
                mainform.dataGridViewOM.Sort(mainform.dataGridViewOM.Columns["OMBID"], ListSortDirection.Ascending);
                processOrbitalElements();

            }
        }

        public void processOrbitalElements()
        {
            mainform.listBoxOrbitalElementsMath.Items.Add("Start Processing Orbital Elements");
            foreach (DataGridViewRow row in mainform.dataGridViewOM.Rows)
            {
                double[] xyzPrevious = {0,0,0,};
                mainform.listBoxOrbitalElementsMath.Items.Add(row.Cells["OMBID"].Value);
                mainform.listBoxOrbitalElementsMath.Items.Add(row.Cells["OMBodyName"].Value+" Orbits "+row.Cells["Parents"].Value);

                double MARadians = (Math.PI / 180) * Convert.ToDouble(row.Cells["MeanAnomaly"].Value);

                double EA = CalculateEccentricAnomaly(Convert.ToDouble(row.Cells["SemiMajorAxis"].Value), Convert.ToDouble(row.Cells["Eccentricity"].Value), MARadians);
                mainform.listBoxOrbitalElementsMath.Items.Add("Eccentric Anomaly: "+EA);

                double TA = CalculateTrueAnomaly(Convert.ToDouble(row.Cells["SemiMajorAxis"].Value), Convert.ToDouble(row.Cells["Eccentricity"].Value), EA, MARadians);
                mainform.listBoxOrbitalElementsMath.Items.Add("True Anomaly: " + TA);

                double inclinationRadians = (Math.PI / 180) * Convert.ToDouble(row.Cells["OrbitalInclination"].Value);
                double raanRadians = (Math.PI / 180) * Convert.ToDouble(row.Cells["AscendingNode"].Value);
                double aopRadians = (Math.PI / 180) * Convert.ToDouble(row.Cells["Periapsis"].Value);

                double[] xyz = ConvertToCartesian(Convert.ToDouble(row.Cells["SemiMajorAxis"].Value), Convert.ToDouble(row.Cells["Eccentricity"].Value), inclinationRadians, raanRadians, aopRadians, TA);
                mainform.listBoxOrbitalElementsMath.Items.Add("X,Y,Z: " + xyz[0] + ", " + xyz[1] + ", " + xyz[2]);

                //Calculate to 0,0,0

                double distance = Math.Sqrt(Math.Pow(xyz[0] - 0, 2) + Math.Pow(xyz[1] - 0, 2) + Math.Pow(xyz[2] - 0, 2));
                double speedOfLight = 299792.458; // speed of light in kilometers per second
                double lightSeconds = distance / speedOfLight;
                mainform.listBoxOrbitalElementsMath.Items.Add("Distance to 0,0,0: " + distance+ " LS: "+lightSeconds);


                if (xyzPrevious[0] >0)
                {
                    //Calculate Distance between nearest ID

                }

                xyzPrevious = xyz;

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
