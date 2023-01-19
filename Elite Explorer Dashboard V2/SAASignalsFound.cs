using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class SAASignalsFound
    {
        public void process(string line)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

            ScanObjectBodyDetailed? edObject = JsonSerializer.Deserialize<ScanObjectBodyDetailed>(line);
            if(edObject != null) {
                if(mainform.usedBodies != null && edObject.BodyName != null) {
                    if (edObject.Signals != null && mainform.usedBodies.ContainsKey(edObject.BodyName) == true)
                    {
                        if (edObject.BodyName.Contains("Ring") == false)
                        {
                            string theseSignals = "";
                            foreach (var item in edObject.Signals)
                            {
                                theseSignals += item.Type_Localised + "-(" + item.Count + ")";
                            }
                            mainform.dataGridViewBodies[8, mainform.usedBodies[edObject.BodyName]].Style.BackColor = Color.Green;
                            mainform.dataGridViewBodies[8, mainform.usedBodies[edObject.BodyName]].Style.ForeColor = Color.White;
                            mainform.dataGridViewBodies[8, mainform.usedBodies[edObject.BodyName]].Value = theseSignals;
                        }
                    }
                }

            }
        }
    }
}
