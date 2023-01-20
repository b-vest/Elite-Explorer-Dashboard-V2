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
            mainform.dataGridViewOM.Rows.Add(
    "BaryCentre-"+bodyData.BodyID,
    bodyData.BodyID,
    "",
    "",
    "",
    "",
    string.Format("{0:N0}", bodyData.SemiMajorAxis),
    bodyData.Eccentricity,
    bodyData.OrbitalInclination,
    bodyData.Periapsis,
    string.Format("{0:N0}", bodyData.OrbitalPeriod),
    bodyData.AscendingNode,
    bodyData.MeanAnomaly
);
        }
    }
}
