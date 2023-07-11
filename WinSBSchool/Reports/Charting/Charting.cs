using System; 
using System.Collections.Generic;
using System.ComponentModel; 
using System.Data;
using System.Drawing; 
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms.Charting
{
    public partial class Charting : Form
    {
        public DataGrid grid = null;
        bool enable3D = true;
        //Default constructor
        public Charting()
        {
            InitializeComponent();
        } 

        //Feed data points linklabel event
        private void lnklblFeedChartData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChartDataFeed child = new ChartDataFeed();
            child.ShowDialog(this);
        }
        //Load system knowcolors list to the combo
        private void LoadColors(ComboBox cboControl)
        {
            var systemColors = Enum.GetNames(typeof(KnownColor));
            foreach (string color in systemColors)
            {
                cboControl.Items.Add(color);
            }
            cboControl.SelectedIndex = cboControl.SelectedIndex <= 0 ? 1 : cboControl.SelectedIndex;
        }
        //Load chart types list to the combo
        private void LoadChartTypes(ComboBox cboControl)
        {
            var chartTypes = Enum.GetNames(typeof(SeriesChartType));
            foreach (string type in chartTypes)
            {
                cboControl.Items.Add(type);
            }
            cboControl.SelectedIndex = cboControl.SelectedIndex <= 0 ? (int)SeriesChartType.Column : cboControl.SelectedIndex;
        }
        //Change window(form) color
        private void cboWindowsColors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboWindowsColors.Text))
            {
                this.BackColor = Color.FromName(cboWindowsColors.Text);
            }
        }
        //change chart area color
        private void cboChartBackColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboChartBackColor.Text))
            {
                this.pnChart.BackColor = Color.FromName(cboChartBackColor.Text);
                pnChart.Controls.Clear();
                pnChart.Controls.Add(GetChart());
            }
        }
        //form load
        private void Charting_Load(object sender, EventArgs e)
        {
            try
            {
                LoadColors(cboWindowsColors);
                LoadColors(cboChartBackColor);
                LoadChartTypes(cboChartTypes);
                pnChart.Controls.Add(GetChart());
                var chartImgFormats = Enum.GetNames(typeof(ChartImageFormat));
                string filter = string.Empty;
                foreach (string format in chartImgFormats)
                {

                    filter += format + "(*." + format + ")|*." + format + "|";
                }
                filter += "All files (*.*)|*.*";
                saveFileDialog.Filter = filter;
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
        //When chart activated from the modal window
        private void Charting_Activated(object sender, EventArgs e)
        {
            pnChart.Controls.Clear();
            pnChart.Controls.Add(GetChart());
        }
        //Enable/Disable chart 3D
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            pnChart.Controls.Clear();
            enable3D = checkBox1.Checked;
            pnChart.Controls.Add(GetChart());
        }
        //GEt the chart
        private Chart GetChart()
        {
            Chart chart = null;
            if (grid == null)
            {
                pnChartRelControls.Visible = false;
                return chart;
            }
            try
            {
                pnChart.Controls.Clear();
                pnChartRelControls.Visible = true;
                WindowsCharting charting = new WindowsCharting();
                DataTable dt = null;
                if (grid != null)
                {
                    dt = grid.DataSource as DataTable;
                }
                chart = charting.GenerateChart(dt, pnChart.Width, pnChart.Height, cboChartBackColor.Text, cboChartTypes.SelectedIndex);
                chart.ChartAreas[0].Area3DStyle.Enable3D = enable3D;
                pnChartRelControls.Visible = true;
                //return chart;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                //do nothing
            }
            return chart;
        }
        //Set Chart Types
        private void cboChartTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnChart.Controls.Add(GetChart());
        }
        //Save the chart to the local machine
        private void cmdSave_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            string path = saveFileDialog.FileName;
            if (saveFileDialog.CheckPathExists && !string.IsNullOrEmpty(path))
            {
                Chart chart = GetChart();
                chart.SaveImage(path, ChartImageFormat.Jpeg);
                pnChart.Controls.Add(chart);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}