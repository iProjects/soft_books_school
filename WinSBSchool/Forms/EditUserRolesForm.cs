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
    public partial class EditUserRolesForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        DAL.spRole role; 

        public EditUserRolesForm(DAL.spRole _role, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            role = _role;
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        public bool IsRoleValid()
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
            return noerror;
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsRoleValid())
            {
                try
                {
                    role.ShortCode = txtShortCode.Text;
                    role.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text);

                    rep.UpdateRole(role);

                    UserRolesForm r = (UserRolesForm)this.Owner;
                    r.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void EditUserRolesForm_Load(object sender, EventArgs e)
        {
            try
            { 
                InitializeControls();

                AutoCompleteStringCollection acscshrtcd = new AutoCompleteStringCollection();
                acscshrtcd.AddRange(this.AutoComplete_ShortCode());
                txtShortCode.AutoCompleteCustomSource = acscshrtcd;
                txtShortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtShortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscdcsrptn = new AutoCompleteStringCollection();
                acscdcsrptn.AddRange(this.AutoComplete_Description());
                txtDescription.AutoCompleteCustomSource = acscdcsrptn;
                txtDescription.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtDescription.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_ShortCode()
        {
            try
            {
                var shortcodequery = from bk in db.spRoles
                                     where bk.IsDeleted == false
                                     select bk.ShortCode;
                return shortcodequery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Description()
        {
            try
            {
                var descriptionquery = from bk in db.spRoles
                                       where bk.IsDeleted == false
                                       select bk.Description;
                return descriptionquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void InitializeControls()

        {
            try
            {
                if (role.Id != null)
                {
                    txtShortCode.Text = role.ShortCode;
                }
                if (role.Description != null)
                {
                    txtDescription.Text = role.Description;
                }          
               
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
    }
}
