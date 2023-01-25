﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            runningData.hugeFont = new Font("Consolas", 9);
            runningData.largeFont = new Font("Consolas", 8);
            runningData.mediumFont = new Font("Consolas", 7);
            runningData.smallFont = new Font("Consolas", 6);

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
            dataGridViewBodies.Columns[7].DefaultCellStyle.Font = new Font("Consolas", 8, FontStyle.Regular);

        }
    }
}
