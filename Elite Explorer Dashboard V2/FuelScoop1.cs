using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class FuelScoop1
    {
        EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

        public void processFuelScoop(EDData eventData)
        {
            mainform.runningData.TotalScooped += eventData.Scooped;
            mainform.dataGridHeader[4, 0].Value = String.Format("{0:0.00}", eventData.Scooped) + " (" + String.Format("{0:0.00}", runningData.TotalScooped) + ")";
            mainform.dataGridHeader[3, 0].Value = (int)eventData.Total;
        }
    }
}
