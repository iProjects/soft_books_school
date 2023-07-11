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
    public partial class EditBranchesForm : Form
    {
        #region "Private Fields"
        SBSchoolDBEntities db;
        string connection;
        Repository rep;
        Bank _bank;
        BankBranch _BankBranch;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public EditBranchesForm(Bank bank, BankBranch branch, string Conn)
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

            if (branch == null)
                throw new ArgumentNullException("BankBranch");
            _BankBranch = branch;

        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (is_Validate())
            {
                try
                {
                    string banksortcode = txtBankCode.Text + txtBranchCode.Text;

                    if (!string.IsNullOrEmpty(txtBranchCode.Text))
                    {
                        _BankBranch.BranchCode = txtBranchCode.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBranchName.Text))
                    {
                        _BankBranch.BranchName = Utils.ConvertFirstLetterToUpper(txtBranchName.Text.Trim());
                    }

                    rep.UpdateBranch(_BankBranch);

                    BanksForm b = (BanksForm)this.Owner;
                    b.RefreshBranchGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }

        }
        private bool is_Validate()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtBranchName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBranchName, "Branch Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtBranchCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBranchCode, "Branch Code cannot be null!");
                return false;
            }
            return noerror;
        }
        private void EditBranchesForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (_bank.BankCode != null)
                {
                    txtBankCode.Text = _bank.BankCode.ToString();
                    txtBankCode.Enabled = false;
                }
                if (_bank.BankName != null)
                {
                    txtBankName.Text = _bank.BankName;
                    txtBankName.Enabled = false;
                }
                if (_BankBranch.BranchCode != null)
                {
                    txtBranchCode.Text = _BankBranch.BranchCode.ToString();
                }
                if (_BankBranch.BranchName != null)
                {
                    txtBranchName.Text = _BankBranch.BranchName;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "Private Methods"

        private void txtBranchCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtBranchCode_KeyDown(object sender, KeyEventArgs e)
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
