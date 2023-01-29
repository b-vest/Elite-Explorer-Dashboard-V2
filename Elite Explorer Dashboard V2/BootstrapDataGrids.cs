using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elite_Explorer_Dashboard_V2
{
    internal class BootstrapDataGrids
    {
        public void bootstrap(runningDataObject runningData, DataGridView dataGridHeader, DataGridView dataGridStars, DataGridView dataGridViewBodies)
        {
            //Load Fonts into running Data
            runningData.hugeFont = new Font("Lucida Sans", 12);
            runningData.largeFont = new Font("Lucida Sans", 11);
            runningData.mediumFont = new Font("Lucida Sans", 10);
            runningData.smallFont = new Font("Lucida Sans", 9);

            //Setup Data Grids Add DoubleBuffered
            dataGridHeader.DoubleBuffered(true);
            dataGridViewBodies.DoubleBuffered(true);

            dataGridHeader.RowHeadersVisible = false;
            dataGridHeader.EnableHeadersVisualStyles = false;
            dataGridHeader.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;

            dataGridHeader.ColumnHeadersDefaultCellStyle.Font = runningData.largeFont;
            dataGridHeader.DefaultCellStyle.Font = runningData.mediumFont;

            dataGridStars.RowHeadersVisible = false;
            dataGridStars.EnableHeadersVisualStyles = false;
            dataGridStars.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridStars.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;
            dataGridStars.ColumnHeadersDefaultCellStyle.Font = runningData.largeFont;
            dataGridStars.DefaultCellStyle.Font = runningData.mediumFont;

            dataGridViewBodies.RowHeadersVisible = false;
            dataGridViewBodies.EnableHeadersVisualStyles = false;
            dataGridViewBodies.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            dataGridViewBodies.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;
            dataGridViewBodies.ColumnHeadersDefaultCellStyle.Font = runningData.largeFont;
            dataGridViewBodies.DefaultCellStyle.Font = runningData.mediumFont;
            dataGridViewBodies.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewBodies.Columns[7].DefaultCellStyle.Font = new Font("Lucida Sans", 8, FontStyle.Regular);

        }
        public runningDataObject buildConversionTables(runningDataObject runningData)
        {
            //Materials
            runningData.materialConversion.Add("zirconium", "Zr");
            runningData.materialConversion.Add("arsenic", "As");
            runningData.materialConversion.Add("technetium", "Tc");
            runningData.materialConversion.Add("sulphur", "S");
            runningData.materialConversion.Add("polonium", "Po");


            //Atmosphere
            runningData.atmosphereConversion.Add("SulphurDioxide", "S02");
            runningData.atmosphereConversion.Add("Nitrogen", "N");
            runningData.atmosphereConversion.Add("CarbonDioxide", "C02");
            runningData.atmosphereConversion.Add("Methane", "CH4");
            runningData.atmosphereConversion.Add("Argon", "Ar");
            runningData.atmosphereConversion.Add("Ammonia", "NH3");
            runningData.atmosphereConversion.Add("Hydrogen", "H");
            runningData.atmosphereConversion.Add("Helium", "He");
            runningData.atmosphereConversion.Add("Neon", "Ne");



            runningData.bodyConversion.Add("High metal content body", "HMC");
            runningData.bodyConversion.Add("Rocky body", "RB");
            runningData.bodyConversion.Add("Rocky ice body", "RIB");

            runningData.bodyConversion.Add("Sudarsky class I gas giant", "SD1GG");
            runningData.bodyConversion.Add("Sudarsky class II gas giant", "SD2GG");
            runningData.bodyConversion.Add("Sudarsky class III gas giant", "SD3GG");
            runningData.bodyConversion.Add("Gas giant with water based life", "GGWBL");
            runningData.bodyConversion.Add("Icy body", "IB");




            return runningData;
        }
    }
}
