using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class Shutdown
    {
        public void process(string line)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

            mainform.dataGridHeader[0, 0].Value = "Shutdown";
            mainform.dataGridHeader[1, 0].Value = "Shutdown";
            mainform.dataGridHeader[2, 0].Value = "Shutdown";
            mainform.dataGridHeader[3, 0].Value = "Shutdown";
            mainform.dataGridHeader[4, 0].Value = "Shutdown";
            mainform.dataGridHeader[5, 0].Value = "Shutdown";
            mainform.dataGridHeader[6, 0].Value = "Shutdown";
            mainform.dataGridHeader[7, 0].Value = "Shutdown";
            mainform.dataGridHeader[8, 0].Value = "Shutdown";
        }
    }
}
