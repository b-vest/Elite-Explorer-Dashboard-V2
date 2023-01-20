using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class SAAScanComplete
    {
        public void processSAAScanComplete(string line)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

            SAAScanCompleteObject? edObject = JsonSerializer.Deserialize<SAAScanCompleteObject>(line);
            if (edObject.BodyName.Contains("Ring") == false && mainform.usedBodies.ContainsKey(edObject.BodyName))
            {
                mainform.dataGridViewBodies[11, mainform.usedBodies[edObject.BodyName]].Style.BackColor = Color.Green;
                mainform.dataGridViewBodies[11, mainform.usedBodies[edObject.BodyName]].Style.ForeColor = Color.White;
                mainform.dataGridViewBodies[11, mainform.usedBodies[edObject.BodyName]].Value = edObject.ProbesUsed;
            }
        }
    }
}
