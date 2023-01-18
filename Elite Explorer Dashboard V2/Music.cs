using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class Music
    {
        public void process(EDData eventData)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

            if (eventData.MusicTrack != "NoTrack")
            {
                mainform.dataGridHeader[8, 0].Value = eventData.MusicTrack;
            }

        }
    }
}
