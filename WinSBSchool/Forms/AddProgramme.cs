using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class AddProgramme : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;

        public AddProgramme(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (ISProgrammeValid())
            {
                try
                {
                    Programme programme = new Programme();
                    programme.Id = Utils.ConvertFirstLetterToUpper(txtProgrammeId.Text);
                    programme.Description =Utils.ConvertFirstLetterToUpper( txtDescription.Text);
                    programme.IsDeleted = false;

                    if (!db.Programmes.Any(i => i.Id == programme.Id))
                    {
                        db.Programmes.AddObject(programme);
                        db.SaveChanges();
                    }

                    ProgrammesForm f = (ProgrammesForm)this.Owner;
                    f.RefreshGrid();
                    this.Close(); 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex); 
                }
            }
        }
        private bool  ISProgrammeValid()
        {
            bool noeeror = true;
            if (string.IsNullOrEmpty(txtProgrammeId.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtProgrammeId, "Short Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description Cannot be null!");
                return false;
            }
            return noeeror;
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        } 
        private void AddProgramme_Load(object sender, EventArgs e)
        {
            try
            {
                var _programmesquery = (from pr in db.Programmes
                                       where pr.IsDefault == true
                                       select pr).FirstOrDefault();
                 Programme programme = _programmesquery; 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex); 
            }
        }
    }
}
