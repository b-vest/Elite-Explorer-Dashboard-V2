using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class Liftoff
    {
        public void process()
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

            mainform.dataGridViewBodies[15, mainform.usedBodies[mainform.runningData.CurrentBody]].Style.BackColor = Color.Green;
        }
    }
}
