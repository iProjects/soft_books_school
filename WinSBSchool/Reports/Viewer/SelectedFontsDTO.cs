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
    public class SelectedFontsDTO
    {
        public string DocLocation { get; set; }
        public string FontFamily { get; set; }
        public string FontSizeInPoints { get; set; }
        public string FontStyle { get; set; }
        public string FontColor { get; set; }
        

    }
}
