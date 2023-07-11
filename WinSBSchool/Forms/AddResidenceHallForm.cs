using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class AddResidenceHallForm : Form
    {
        string connection;
        SBSchoolDBEntities db;

        public AddResidenceHallForm(string Conn)
        { 
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            db = new SBSchoolDBEntities(connection);
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsResidenceHallValid())
            {
                try
                {
                    DAL.ResidenceHall _residenceHall = new ResidenceHall();
                    if (!string.IsNullOrEmpty(txtHallName.Text))
                    {
                        _residenceHall.HallName = Utils.ConvertFirstLetterToUpper(txtHallName.Text);
                    }
                    if (!string.IsNullOrEmpty(txtLocation.Text))
                    {
                        _residenceHall.Location = Utils.ConvertFirstLetterToUpper(txtLocation.Text.Trim());
                    }

                    if (!db.ResidenceHalls.Any(o => o.HallName == _residenceHall.HallName))
                    {
                        db.ResidenceHalls.AddObject(_residenceHall);
                        db.SaveChanges();
                    }
                   

                    ResidenceHallsForm f = (ResidenceHallsForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsResidenceHallValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtHallName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtHallName, "Hall Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtLocation.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtLocation, "Location cannot be null!");
                return false;
            }
            return noerror;
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
