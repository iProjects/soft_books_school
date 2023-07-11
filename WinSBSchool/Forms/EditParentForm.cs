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

namespace WinSBSchool.Forms
{
    public partial class EditParentForm : Form
    {
        Repository rep;
        DAL.Parent p;
        string connection;

        public EditParentForm(DAL.Parent parent, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            p = parent;
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();

            if (IsParentValid())
            {
                try
                { 
                    if (!string.IsNullOrEmpty(txtParentName.Text))
                    {
                        p.Name =Utils.ConvertFirstLetterToUpper( txtParentName.Text.Trim());
                    }
                    if (cboGender.SelectedIndex != -1)
                    {
                        p.Gender = cboGender.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtPhoneNumber.Text))
                    {
                        p.CellPhoneNo = txtPhoneNumber.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        p.Email = txtEmail.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtOccupation.Text))
                    {
                        p.Occupation = Utils.ConvertFirstLetterToUpper(txtOccupation.Text.Trim());
                    }
                    if (cboMaritalStatus.SelectedIndex != -1)
                    {
                        p.Maritalstatus = cboMaritalStatus.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtRelationShip.Text))
                    {
                        p.Relationship = txtRelationShip.Text.Trim();
                    }

                    rep.UpdateParent(p);

                    if (this.Owner is ParentsForm)
                    {
                        ParentsForm f = (ParentsForm)this.Owner;
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

        public bool IsParentValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(txtParentName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtParentName, "Name cannot be null!");
                return false;
            } 
            return noerror; 
        }

        private void EditParentForm_Load(object sender, EventArgs e)
        {
            //Gender Combox
            var gender = new BindingList<KeyValuePair<string, string>>();
            gender.Add(new KeyValuePair<string, string>("M", "Male"));
            gender.Add(new KeyValuePair<string, string>("F", "Female"));
            cboGender.DataSource = gender;
            cboGender.ValueMember = "Key";
            cboGender.DisplayMember = "Value";
            cboGender.SelectedIndex = -1;

            //Marital Combox
            var marital = new BindingList<KeyValuePair<string, string>>();
            marital.Add(new KeyValuePair<string, string>("M", "Married"));
            marital.Add(new KeyValuePair<string, string>("S", "Single"));
            marital.Add(new KeyValuePair<string, string>("D", "Divorced"));
            cboMaritalStatus.DataSource = marital;
            cboMaritalStatus.ValueMember = "Key";
            cboMaritalStatus.DisplayMember = "Value";
            cboMaritalStatus.SelectedIndex = -1;

            InitializeControls();
        }


        private void InitializeControls()
        {

            try
            {
                if (p.Name != null)
                {
                    txtParentName.Text = p.Name.Trim();
                }
                if (p.Gender != null)
                {
                   cboGender.SelectedValue  = p.Gender;
                }
                if (p.CellPhoneNo != null)
                {
                  txtPhoneNumber.Text   = p.CellPhoneNo.Trim();
                }
                if (p.Email != null)
                {
                 txtEmail.Text   = p.Email .Trim();
                }
                if (p.Occupation != null)
                {
                  txtOccupation.Text   = p.Occupation.Trim();
                }
                if (p.Maritalstatus != null)
                {
                  cboMaritalStatus.SelectedValue   = p.Maritalstatus.Trim();
                }
                if (p.Relationship != null)
                {
                 txtRelationShip.Text   = p.Relationship .Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }




    }
}
