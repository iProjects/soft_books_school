﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using WinSBSchool;

namespace WinSBSchool
{
    partial class AboutBoxForm : Form
    {
        public AboutBoxForm()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", app_assembly_info.AssemblyTitle);
            this.labelProductName.Text = app_assembly_info.AssemblyProduct;
            this.labelVersion.Text = String.Format("Version {0}", app_assembly_info.AssemblyVersion);
            this.labelCopyright.Text = app_assembly_info.AssemblyCopyright;
            this.labelCompanyName.Text = app_assembly_info.AssemblyCompany;
            this.textBoxDescription.Text = app_assembly_info.AssemblyDescription;
        }
        
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void AboutBoxForm_Load(object sender, EventArgs e)
        {

        }

    }
}
