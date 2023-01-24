using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    public class OrbitMathFunctions
    {
        public static double[] ConvertToCartesian(double a, double e, double i, double raan, double aop, double ta)
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
        public static double CalculateEccentricAnomaly(double a, double e, double M)
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
        public static double CalculateTrueAnomaly(double a, double e, double E, double M)
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
