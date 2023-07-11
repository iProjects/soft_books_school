using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Globalization;

namespace WinSBSchool.Forms
{
    public partial class AddDisciplinaryCategoriesForm : Form
    {
        string connection;
        SBSchoolDBEntities db;

        public AddDisciplinaryCategoriesForm( string Conn)
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
            if (IsDisciplinaryCategoryValid())
            {
                try
                {
                    DAL.DisciplinaryCategory disciplinarycategory = new DisciplinaryCategory();

                    if (!string.IsNullOrEmpty(txtShortCode.Text))
                    {
                        disciplinarycategory.ShortCode = Utils.ConvertFirstLetterToUpper(txtShortCode.Text );
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        disciplinarycategory.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text); 
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        disciplinarycategory.Status = cboStatus.SelectedValue.ToString();
                    }
                    disciplinarycategory.IsDeleted = false;

                    if (db.DisciplinaryCategories.Any(i => i.ShortCode == disciplinarycategory.ShortCode))
                    {
                        MessageBox.Show("Disciplinary Category " + disciplinarycategory.ShortCode + " Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.DisciplinaryCategories.Any(i => i.ShortCode == disciplinarycategory.ShortCode))
                    {
                        db.DisciplinaryCategories.AddObject(disciplinarycategory);
                        db.SaveChanges();

                        DisciplinaryCategoriesForm f = (DisciplinaryCategoriesForm)this.Owner;
                        f.RefreshGrid();
                        this.Close();
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsDisciplinaryCategoryValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtShortCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtShortCode, "Short Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (cboStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboStatus, "Select Status!");
                return false;
            }
            return noerror;
        } 
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void AddDisciplinaryCategoriesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

    }
}
