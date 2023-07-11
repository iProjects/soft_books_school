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
    public partial class EditDisciplinaryCategoriesForm : Form
    {
        string connection;
        SBSchoolDBEntities db;
        Repository rep;
        DAL.DisciplinaryCategory disciplinarycategory;

        public EditDisciplinaryCategoriesForm(DAL.DisciplinaryCategory _disciplinarycategory, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            disciplinarycategory = _disciplinarycategory;
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsDisciplinaryCategoryValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtShortCode.Text))
                    {
                        disciplinarycategory.ShortCode = Utils.ConvertFirstLetterToUpper(txtShortCode.Text);
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        disciplinarycategory.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text);
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        disciplinarycategory.Status = cboStatus.SelectedValue.ToString();
                    }

                    rep.UpdateDisciplineCategory(disciplinarycategory);

                    DisciplinaryCategoriesForm f = (DisciplinaryCategoriesForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
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
        private void EditDisciplinaryCategoriesForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                InitializeControls();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls()
        {
            try
            {

                if (disciplinarycategory.ShortCode != null)
                {
                    txtShortCode.Text = disciplinarycategory.ShortCode.Trim();
                }
                if (disciplinarycategory.Description != null)
                {
                    txtDescription.Text = disciplinarycategory.Description.Trim();
                }
                if (disciplinarycategory.Status != null)
                {
                    cboStatus.SelectedValue = disciplinarycategory.Status.Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }




    }
}