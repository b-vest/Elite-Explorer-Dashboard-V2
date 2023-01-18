using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class FSDJump
    {
        EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];
        public void process(string line)
        {
            mainform.dataGridStars.Rows.Clear();
            mainform.dataGridViewBodies.Rows.Clear();

        }
    }
}
