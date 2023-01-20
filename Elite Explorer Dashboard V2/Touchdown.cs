using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class Touchdown
    {
        public void process(string line)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];
            TouchdownObject? edObject = JsonSerializer.Deserialize<TouchdownObject>(line);
            mainform.dataGridViewBodies[12, mainform.usedBodies[edObject.Body]].Style.BackColor = Color.Green;
            mainform.runningData.CurrentBody = edObject.Body;
        }
    }
}
