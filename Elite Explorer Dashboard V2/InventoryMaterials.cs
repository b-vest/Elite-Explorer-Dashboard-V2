using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class InventoryMaterials
    {
        public void process(EDData? storedMaterials)
        {
            EliteExplorer mainform = (EliteExplorer)Application.OpenForms[0];

            foreach (var item in storedMaterials.Raw)
            {
                Debug.WriteLine(item.Name);
                if (mainform.materialCount.ContainsKey(item.Name) == false)
                {
                    mainform.materialCount.Add(item.Name, item.Count);
                }

            }
        }
    }
}
