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
    public partial class EditSubjectForm : Form
    {
        Repository rep;
        DAL.Subject s;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditSubjectForm(DAL.Subject subject, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            s = subject;
        }

        private void buttonClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsSubjectValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        s.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                    }
                    int outof;
                    if (!string.IsNullOrEmpty(txtOutOf.Text) && int.TryParse(txtOutOf.Text, out outof))
                    {
                        s.OutOf = int.Parse(txtOutOf.Text);
                    }
                    int passmark;
                    if (!string.IsNullOrEmpty(txtPassMark.Text) && int.TryParse(txtPassMark.Text, out passmark))
                    {
                        s.PassMark = int.Parse(txtPassMark.Text);
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        s.Status = cboStatus.SelectedValue.ToString();
                    }
                    int rorder;
                    if (!string.IsNullOrEmpty(txtROrder.Text) && int.TryParse(txtROrder.Text, out rorder))
                    {
                        s.ROrder = int.Parse(txtROrder.Text);
                    }
                    if (!string.IsNullOrEmpty(txtRemarks.Text))
                    {
                        s.Remarks = Utils.ConvertFirstLetterToUpper(txtRemarks.Text.ToString().Trim());
                    }
                    int noofrequiredhrs;
                    if (!string.IsNullOrEmpty(txtNoofRequiredHours.Text) && int.TryParse(txtNoofRequiredHours.Text, out noofrequiredhrs))
                    {
                        s.NoOfRequiredHours = int.Parse(txtNoofRequiredHours.Text);
                    }
                    decimal fees;
                    if (!string.IsNullOrEmpty(txtFees.Text) && decimal.TryParse(txtFees.Text, out fees))
                    {
                        s.Fees = decimal.Parse(txtFees.Text);
                    }

                    rep.UpdateSubject(s);


                    SubjectsForm f = (SubjectsForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();


                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        public bool IsSubjectValid()
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

        private void EditSubjectForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                txtShortCode.Enabled = false;

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

                if (!string.IsNullOrEmpty(s.ShortCode))
                {
                    txtShortCode.Text = s.ShortCode.Trim();
                }
                if (!string.IsNullOrEmpty(s.Description))
                {
                    txtDescription.Text = s.Description;
                }
                if (s.OutOf != null)
                {
                    txtOutOf.Text = s.OutOf.ToString();
                }
                if (s.PassMark != null)
                {
                    txtPassMark.Text = s.PassMark.ToString();
                }
                if (s.Status != null)
                {
                    cboStatus.SelectedValue = s.Status;
                }
                if (s.ROrder != null)
                {
                    txtROrder.Text = s.ROrder.ToString();
                }
                if (!string.IsNullOrEmpty(s.Remarks))
                {
                    txtRemarks.Text = s.Remarks.Trim();
                }
                if (s.NoOfRequiredHours != null)
                {
                    txtNoofRequiredHours.Text = s.NoOfRequiredHours.ToString();
                }
                if (s.Fees != null)
                {
                    txtFees.Text = s.Fees.ToString();
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }

        /*public method to diable all controls when form is called by parent from 'View Details' button*/
        public void DisableControls()
        {
            txtShortCode.Enabled = false;
            txtShortCode.Enabled = false;
            txtDescription.Enabled = false;
            txtOutOf.Enabled = false;
            txtPassMark.Enabled = false;
            cboStatus.Enabled = false;
            txtROrder.Enabled = false;
            txtRemarks.Enabled = false;
            txtNoofRequiredHours.Enabled = false;
            txtFees.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;
        }
        private void txtOutOf_KeyDown(object sender, KeyEventArgs e)
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

        private void txtOutOf_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtPassMark_KeyDown(object sender, KeyEventArgs e)
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

        private void txtPassMark_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtROrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtROrder_KeyDown(object sender, KeyEventArgs e)
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

        private void txtNoofRequiredHours_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
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

        private void txtNoofRequiredHours_KeyDown(object sender, KeyEventArgs e)
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        } 
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }




    }
}