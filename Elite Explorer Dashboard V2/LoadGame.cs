using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    public class LoadGame
    {
        public void process(string line)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];
            LoadGameObject? edObject = JsonSerializer.Deserialize<LoadGameObject>(line);
            if (edObject != null)
            {
                mainform.runningData.CommanderName = edObject.Commander;
                mainform.dataGridHeader[1, 0].Value = edObject.Commander;
                mainform.dataGridHeader[2, 0].Value = edObject.Ship + " " + edObject.ShipName + " " + edObject.ShipIdent;
                mainform.dataGridHeader[3, 0].Value = String.Format("{0:0.00}", edObject.FuelLevel);
                mainform.dataGridHeader[4, 0].Value = 0;
                mainform.dataGridHeader[6, 0].Value = "Loading.......";
            }

        }
    }
}
