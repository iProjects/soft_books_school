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
    public partial class EditFeeStructureForm : Form
    {
        SBSchoolDBEntities db;
        string connection;
        Repository rep;
        FeesStructure _FeesStructure;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditFeeStructureForm(FeesStructure _fs, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            _FeesStructure = _fs;

        }
        public bool IsFeesStructureValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtYear.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtYear, "Year cannot be null!");
                return false;
            }
            int years;
            if (!int.TryParse(txtYear.Text, out years))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtYear, "Year must be integer!");
                return false;
            }
            return noerror;
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsFeesStructureValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _FeesStructure.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                    }
                    int years;
                    if (!string.IsNullOrEmpty(txtYear.Text) && int.TryParse(txtYear.Text, out years))
                    {
                        _FeesStructure.Year = int.Parse(txtYear.Text);
                    }
                    _FeesStructure.IsDefault = chkIsDefault.Checked;

                    rep.UpdateFeesStructure(_FeesStructure);

                    FeeStructureForm f = (FeeStructureForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void EditFeeStructureForm_Load(object sender, EventArgs e)
        {
            try
            {
            InitializeControls();

            AutoCompleteStringCollection acsccls = new AutoCompleteStringCollection();
                acsccls.AddRange(this.AutoComplete_Description());
                txtDescription.AutoCompleteCustomSource = acsccls;
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
        private string[] AutoComplete_Description()
        {
            try
            {
                var descriptionquery = from cs in db.FeesStructures
                                       where cs.IsDeleted == false 
                                       select cs.Description;
                return descriptionquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        public void InitializeControls()
        {
            try
            {
                if (_FeesStructure.Description != null)
                {
                    txtDescription.Text = _FeesStructure.Description.ToString().Trim();
                }
                if (_FeesStructure.Year != null)
                {
                    txtYear.Text = _FeesStructure.Year.ToString();
                }
                if (_FeesStructure.IsDefault != null)
                {
                    chkIsDefault.Checked = _FeesStructure.IsDefault;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void DisableCheckBox()
        {
            this.chkIsDefault.Enabled = false;
        }
        public void SetCheckBox()
        {
            this.chkIsDefault.Checked = true;
        }
        private void txtYear_KeyDown(object sender, KeyEventArgs e)
        {
            // Initialize the flag to false.
            nonNumberEntered = false;

            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                }
            }
            //If shift key was pressed, it'st not a number.
            if (Control.ModifierKeys == Keys.Shift)
            {
                nonNumberEntered = true;
            }
        }

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
    }
}
