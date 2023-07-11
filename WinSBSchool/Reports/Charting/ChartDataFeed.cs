using System; 
using System.Collections.Generic;
using System.ComponentModel; 
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using System.Xml;
using CommonLib;
using DAL; 

namespace WinSBSchool.Forms.Charting
{
    public partial class ChartDataFeed : Form
    {
        DataGrid dataPointGrid = null;
        DataTable dtDataPoints = null;

        public ChartDataFeed()
        {
            InitializeComponent();
        }

        private void cboChartSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnGrid.Controls.Clear();
            if (cboChartSeries.SelectedIndex > 0)
            {
                dataPointGrid = new DataGrid();
                dtDataPoints = new DataTable();
                int intSeries = cboChartSeries.SelectedIndex;
                for (int i = 0; i < intSeries; i++)
                {
                    DataColumn column = new DataColumn() { ColumnName = "Series:" + (i + 1), DataType = typeof(int) };
                    dtDataPoints.Columns.Add(column);
                }
                dataPointGrid.DataSource = dtDataPoints;
                dataPointGrid.Width = pnGrid.Width;
                dataPointGrid.Height = pnGrid.Height;
                pnGrid.Controls.Add(dataPointGrid);
            }
        }

        private void ChartDataFeed_Load(object sender, EventArgs e)
        { 
            cboChartSeries.SelectedIndex = 0;
            this.pnGrid.Controls.Add(dataPointGrid);
        }

        private void cmdOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Owner != null)
                {
                    Charting charting = this.Owner as Charting;
                    charting.grid = this.dataPointGrid;
                    this.Owner.Activate();
                    this.Close();
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
