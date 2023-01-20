using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class FSDJump
    {
        EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];
        public void process(string line)
        {
            FSDJumpObject? edObject = JsonSerializer.Deserialize<FSDJumpObject>(line);

            mainform.dataGridStars.Rows.Clear();
            mainform.dataGridViewBodies.Rows.Clear();
            mainform.dataGridViewOM.Rows.Clear();

            mainform.runningData.CurrentSystem = edObject.StarSystem;
            mainform.labelBodiesFound.Text = "We have entered new system " + edObject.StarSystem + " waiting for updates from the FSS.";
            mainform.listBoxOrbitalElementsMath.Items.Clear();  

        }
    }
}
