using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class FSDTarget
    {
        public void process(EDData eventData)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

            if (eventData == null) return;
            if (eventData.RemainingJumpsInRoute == 0)
            {
                eventData.RemainingJumpsInRoute = 1;
            }
            mainform.dataGridHeader[6, 0].Value = eventData.Name + " (" + eventData.StarClass + ")";
            mainform.dataGridHeader[7, 0].Value = eventData.RemainingJumpsInRoute;

        }
    }
}
