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
    public partial class AddBranchesForm : Form
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
        public AddBranchesForm(Bank bank, string Conn)
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
        private void AddBranchesForm_Load(object sender, EventArgs e)
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

                string _BranchCode = Utils.NextSeries(NextBranchCode());
                txtBranchCode.Text = _BranchCode;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string NextBranchCode()
        {
            try
            {
                var cn = (from c in db.BankBranches
                          where c.Bank.BankCode == _bank.BankCode
                          orderby c.BranchCode descending
                          select c).FirstOrDefault();
                if (cn == null)
                    return "0";
                return cn.BranchCode.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "0";
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (is_Validate())
            {
                try
                {
                    double bankcode = double.Parse(txtBankCode.Text);
                    double branchcode = double.Parse(txtBranchCode.Text);
                    string banksortcode = txtBankCode.Text + txtBranchCode.Text;

                    BankBranch _BankBranch = new BankBranch();
                    if (banksortcode != null)
                    {
                        _BankBranch.BankSortCode = banksortcode.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtBranchCode.Text))
                    {
                        _BankBranch.BranchCode = txtBranchCode.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBankCode.Text))
                    {
                        _BankBranch.BankCode = txtBankCode.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBranchName.Text))
                    {
                        _BankBranch.BranchName = Utils.ConvertFirstLetterToUpper(txtBranchName.Text.Trim());
                    }

                    if (db.BankBranches.Any(c => c.BankCode == _BankBranch.BankCode && c.BranchCode == _BankBranch.BranchCode))
                    {
                        MessageBox.Show("Bank Branch Code Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.BankBranches.Any(c => c.BankCode == _BankBranch.BankCode && c.BranchCode == _BankBranch.BranchCode))
                    {
                        db.BankBranches.AddObject(_BankBranch);
                        db.SaveChanges();

                        BanksForm banks = (BanksForm)this.Owner;
                        banks.RefreshBranchGrid();
                        this.Close();
                    } 
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
