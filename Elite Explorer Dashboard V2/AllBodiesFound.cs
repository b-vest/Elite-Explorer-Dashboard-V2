using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            }
        }
    }
}
