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
    public partial class AddFeeStructureForm : Form
    {
        SBSchoolDBEntities db;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public AddFeeStructureForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsFeesStructureValid())
            {
                try
                {
                    FeesStructure fs = new FeesStructure();
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        fs.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                    }
                    int years;
                    if (!string.IsNullOrEmpty(txtYear.Text) && int.TryParse(txtYear.Text, out years))
                    {
                        fs.Year = int.Parse(txtYear.Text);
                    }
                    fs.IsDefault = chkIsDefault.Checked;
                    fs.IsDeleted = false;

                    if (db.FeesStructures.Any(o => o.Description == fs.Description && o.Year == fs.Year))
                    {
                        MessageBox.Show("Description " + fs.Description.Trim() + " for Year " + fs.Year + " Exist!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.FeesStructures.Any(o => o.Description == fs.Description && o.Year == fs.Year))
                    {
                        db.FeesStructures.AddObject(fs);
                        db.SaveChanges();

                        FeeStructureForm f = (FeeStructureForm)this.Owner;
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void AddFeeStructureForm_Load(object sender, EventArgs e)
        {
            try
            {
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
        public void DisableChechBox()
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