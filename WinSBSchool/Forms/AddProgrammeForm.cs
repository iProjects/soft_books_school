using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace WinSBSchool.Forms
{
    public partial class AddProgrammeForm : Form
    {
        Repository rep;
        string connection;
        SBSchoolDBEntities db;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public AddProgrammeForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (ISProgrammeValid())
            {
                try
                {
                    Programme p = new Programme();
                    if (!string.IsNullOrEmpty(txtShortCode.Text))
                    {
                        p.Id = Utils.ConvertFirstLetterToUpper(txtShortCode.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        p.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                    }
                    int hrs;
                    if (!string.IsNullOrEmpty(txtHours.Text) && int.TryParse(txtHours.Text, out hrs))
                    {
                        p.Hours = int.Parse(txtHours.Text.Trim());
                    }
                    decimal fees;
                    if (!string.IsNullOrEmpty(txtFees.Text) && decimal.TryParse(txtFees.Text, out fees))
                    {
                        p.Fees = decimal.Parse(txtFees.Text.Trim());
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        p.Status = cboStatus.SelectedValue.ToString();
                    }
                    p.IsDefault = chkIsDefaultProgramme.Checked;
                    p.IsDeleted = false;


                    if (db.Programmes.Any(i => i.Id == p.Id && i.IsDeleted==false))
                    {
                        MessageBox.Show("Short Code Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Programmes.Any(i => i.Id == p.Id && i.IsDeleted == false))
                    {
                        db.Programmes.AddObject(p);
                        db.SaveChanges();

                        ProgrammesForm f = (ProgrammesForm)this.Owner;
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
        private bool ISProgrammeValid()
        {
            bool noeeror = true;
            if (string.IsNullOrEmpty(txtShortCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtShortCode, "Short Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description Cannot be null!");
                return false;
            }
            if (cboStatus.SelectedIndex ==-1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboStatus, "Select Status!");
                return false;
            }
            return noeeror;
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void txtHours_KeyDown(object sender, KeyEventArgs e)
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

        private void txtHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtFees_KeyDown(object sender, KeyEventArgs e)
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
        private void txtFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void AddProgrammeForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                AutoCompleteStringCollection acscshtcd = new AutoCompleteStringCollection();
                acscshtcd.AddRange(this.AutoComplete_ShortCode());
                txtShortCode.AutoCompleteCustomSource = acscshtcd;
                txtShortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtShortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscdescrp = new AutoCompleteStringCollection();
                acscdescrp.AddRange(this.AutoComplete_Description());
                txtDescription.AutoCompleteCustomSource = acscdescrp;
                txtDescription.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtDescription.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                var _programmesquery = (from pr in db.Programmes
                                        where pr.IsDefault == true
                                        select pr).FirstOrDefault();
                Programme programme = _programmesquery;
                if (programme == null)
                {
                    chkIsDefaultProgramme.Checked = true;
                }
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
                var accountsquery = from bk in db.Programmes
                                    where bk.IsDeleted == false
                                    select bk.Id;
                return accountsquery.ToArray();
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
                var accountsquery = from bk in db.Programmes
                                    where bk.IsDeleted == false
                                    select bk.Description;
                return accountsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        public void DisableChechBox()
        {
            this.chkIsDefaultProgramme.Enabled = false;
        }






    }
}