using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace WinSBSchool.Reports.Viewer
{
    public partial class SelectFontsForm : Form
    {

        //delegate
        public delegate void ReportFontSettingstHandler(object sender, ReportFontSettingsEventArgs e);
        //event
        public event ReportFontSettingstHandler OnReportFontSettingstHandler;

        public List<SelectedFontsDTO> SelectedFontsList;

        public SelectFontsForm()
        {
            InitializeComponent();
            SelectedFontsList = new List<SelectedFontsDTO>();
        }

        private void btnHeaderFont_Click(object sender, EventArgs e)
        {
            // Allow the users to select colors.
            // The default is false.
            fontDialog1.ShowColor = true;
            // Allow users to select effects.
            // The default is true.
            fontDialog1.ShowApply = true;
            // Show the Apply button on the dialog box.
            // The default is false.
            fontDialog1.ShowEffects = true;
            // Show the Help button.
            // The default is false.
            fontDialog1.ShowHelp = true;
            fontDialog1.FontMustExist = true;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.SizeInPoints, fontDialog1.Font.Style);
                Color clr = fontDialog1.Color;
                if (clr != null)

                    txtHeaderFont.Text = selectedFont.FontFamily.ToString() + "   ;   " + selectedFont.SizeInPoints.ToString() + "  ;   " + selectedFont.Style.ToString() + "   ;   " +     clr.Name;
                SelectedFontsDTO sf = new SelectedFontsDTO()
                {
                 DocLocation="HF",
                 FontFamily = selectedFont.FontFamily.ToString(),
                 FontSizeInPoints = selectedFont.SizeInPoints.ToString(),
                 FontStyle = selectedFont.Style.ToString(),
                 FontColor = clr.Name.ToString()
                };
                SelectedFontsList.Add(sf);


            }
        }
        private void btnBodyFont_Click(object sender, EventArgs e)
        {
            // Allow the users to select colors.
            // The default is false.
            fontDialog1.ShowColor = true;
            // Allow users to select effects.
            // The default is true.
            fontDialog1.ShowApply = true;
            // Show the Apply button on the dialog box.
            // The default is false.
            fontDialog1.ShowEffects = true;
            // Show the Help button.
            // The default is false.
            fontDialog1.ShowHelp = true;
            fontDialog1.FontMustExist = true;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.SizeInPoints, fontDialog1.Font.Style);
                Color clr = fontDialog1.Color;
                if (clr != null)

                    txtBodyFont.Text = selectedFont.FontFamily.ToString() + "   ;   " + selectedFont.SizeInPoints.ToString() + "  ;   " + selectedFont.Style.ToString() + "   ;    " + clr.Name;

                SelectedFontsDTO sf = new SelectedFontsDTO()
                {
                    DocLocation = "BF",
                    FontFamily = selectedFont.FontFamily.ToString(),
                    FontSizeInPoints = selectedFont.SizeInPoints.ToString(),
                    FontStyle = selectedFont.Style.ToString(),
                    FontColor = clr.Name.ToString()
                };
                SelectedFontsList.Add(sf);
            }
        }
        private void btnFooterFont_Click(object sender, EventArgs e)
        {
            // Allow the users to select colors.
            // The default is false.
            fontDialog1.ShowColor = true;
            // Allow users to select effects.
            // The default is true.
            fontDialog1.ShowApply = true;
            // Show the Apply button on the dialog box.
            // The default is false.
            fontDialog1.ShowEffects = true;
            // Show the Help button.
            // The default is false.
            fontDialog1.ShowHelp = true;
            fontDialog1.FontMustExist = true;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.SizeInPoints, fontDialog1.Font.Style);
                Color clr = fontDialog1.Color;
                if (clr != null)

                    txtFooterFont.Text = selectedFont.FontFamily.ToString() + "   ;   " + selectedFont.SizeInPoints.ToString() + "  ;   " + selectedFont.Style.ToString() + "   ;    " + clr.Name;
                SelectedFontsDTO sf = new SelectedFontsDTO()
                {
                    DocLocation = "FF",
                    FontFamily = selectedFont.FontFamily.ToString(),
                    FontSizeInPoints = selectedFont.SizeInPoints.ToString(),
                    FontStyle = selectedFont.Style.ToString(),
                    FontColor = clr.Name.ToString()
                };
                SelectedFontsList.Add(sf);
            }
        }
        private void btnTableHeaderFont_Click(object sender, EventArgs e)
        {
            // Allow the users to select colors.
            // The default is false.
            fontDialog1.ShowColor = true;
            // Allow users to select effects.
            // The default is true.
            fontDialog1.ShowApply = true;
            // Show the Apply button on the dialog box.
            // The default is false.
            fontDialog1.ShowEffects = true;
            // Show the Help button.
            // The default is false.
            fontDialog1.ShowHelp = true;
            fontDialog1.FontMustExist = true;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.SizeInPoints, fontDialog1.Font.Style);
                Color clr = fontDialog1.Color;
                if (clr != null)

                    txtTableHeaderFont.Text = selectedFont.FontFamily.ToString() + "   ;   " + selectedFont.SizeInPoints.ToString() + "  ;   " + selectedFont.Style.ToString() + "   ;    " + clr.Name;
                SelectedFontsDTO sf = new SelectedFontsDTO()
                {
                    DocLocation = "THF",
                    FontFamily = selectedFont.FontFamily.ToString(),
                    FontSizeInPoints = selectedFont.SizeInPoints.ToString(),
                    FontStyle = selectedFont.Style.ToString(),
                    FontColor = clr.Name.ToString()
                };
                SelectedFontsList.Add(sf);
            }
        }
        private void btnTableBodyFont_Click(object sender, EventArgs e)
        {
            // Allow the users to select colors.
            // The default is false.
            fontDialog1.ShowColor = true;
            // Allow users to select effects.
            // The default is true.
            fontDialog1.ShowApply = true;
            // Show the Apply button on the dialog box.
            // The default is false.
            fontDialog1.ShowEffects = true;
            // Show the Help button.
            // The default is false.
            fontDialog1.ShowHelp = true;
            fontDialog1.FontMustExist = true;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                Font selectedFont = new Font(fontDialog1.Font.FontFamily, fontDialog1.Font.SizeInPoints, fontDialog1.Font.Style);
                Color clr = fontDialog1.Color;
                if (clr != null)

                    txtTableBodyFont.Text = selectedFont.FontFamily.ToString() + "   ;   " + selectedFont.SizeInPoints.ToString() + "  ;   " + selectedFont.Style.ToString() + "   ;    " + clr.Name;
                SelectedFontsDTO sf = new SelectedFontsDTO()
                {
                    DocLocation = "TBF",
                    FontFamily = selectedFont.FontFamily.ToString(),
                    FontSizeInPoints = selectedFont.SizeInPoints.ToString(),
                    FontStyle = selectedFont.Style.ToString(),
                    FontColor = clr.Name.ToString()
                };
                SelectedFontsList.Add(sf);
            }
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if(SelectedFontsList !=null)
                
   OnReportFontSettingstHandler(this, new ReportFontSettingsEventArgs(SelectedFontsList));

                if (this.Owner is WinSBSchool.Reports.Viewer.PDFViewer)
                {
                    WinSBSchool.Reports.Viewer.PDFViewer f = (WinSBSchool.Reports.Viewer.PDFViewer)this.Owner;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
            }
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }


    public class ReportFontSettingsEventArgs : System.EventArgs
    {
        // add local member variables to hold text
       private  List<SelectedFontsDTO> _SelectedFonts;

        // class constructor
        public ReportFontSettingsEventArgs(List<SelectedFontsDTO> selectedfontsdto)
        {
            this._SelectedFonts = selectedfontsdto; 
        } 

        // Properties - Viewable by each listener
        public List<SelectedFontsDTO> _SelectedFontsDTO
        {
            get
            {
                return _SelectedFonts;
            } 
        }
         
    }


}
        