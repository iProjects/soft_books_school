using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class EditBanksForm : Form
    {
        #region "Private Fields"
        SBSchoolDBEntities db;
        string connection;
        Repository rep;
        Bank _bank;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public EditBanksForm(Bank bank, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (bank == null)
                throw new ArgumentNullException("Bank");
            _bank = bank;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void EditBanksForm_Load(object sender, EventArgs e)
        {
            try
            {
                txtBankCode.Enabled = false;
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
                if (_bank.BankName != null)
                {
                    txtBankName.Text = _bank.BankName;
                }
                if (_bank.BankCode != null)
                {
                    txtBankCode.Text = _bank.BankCode;
                } 
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            { 
                if (!string.IsNullOrEmpty(txtBankName.Text))
                {
                    _bank.BankName = Utils.ConvertFirstLetterToUpper(txtBankName.Text.Trim());
                }

                rep.UpdateBank(_bank);

                BanksForm b = (BanksForm)this.Owner;
                b.RefreshBankGrid();
                this.Close();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"

        private void txtBankCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtBankCode_KeyDown(object sender, KeyEventArgs e)
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


    }
}
