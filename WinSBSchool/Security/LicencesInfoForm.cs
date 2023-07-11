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

namespace WinSBSchool
{
    public partial class LicencesInfoForm : Form
    {
        string connection;
        List<SBSystem> sbsys;

        public LicencesInfoForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            sbsys = new List<SBSystem>();
        }
        private void btnRequestLicense_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SQLHelper.SaveXML(sbsys, "sbschoollicense");
        }

        private void LicencesInfoForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
