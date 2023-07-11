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
    public partial class AddBanksForm : Form
    {
        #region "Private Fields"
        SBSchoolDBEntities db;
        string connection;
        Repository rep;
        string user;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public AddBanksForm(string Conn, string _user)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            user = _user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (is_validate())
            {
                try
                {
                    Bank _Bank = new Bank();
                    if (!string.IsNullOrEmpty(txtBankCode.Text))
                    {
                        _Bank.BankCode = txtBankCode.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBankName.Text))
                    {
                        _Bank.BankName = Utils.ConvertFirstLetterToUpper(txtBankName.Text.Trim());
                    }

                    if (db.Banks.Any(c => c.BankCode == _Bank.BankCode))
                    {
                        MessageBox.Show("Bank Code Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Banks.Any(c => c.BankCode == _Bank.BankCode))
                    {
                        db.Banks.AddObject(_Bank);
                        db.SaveChanges();

                        BanksForm b = (BanksForm)this.Owner;
                        b.RefreshBankGrid();
                        this.Close();
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool is_validate()
        {
            bool no_error = true;
            if (string.IsNullOrEmpty(txtBankName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBankName, "Bank Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtBankCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBankCode, "Bank Code cannot be null!");
                return false;
            }
            return no_error;
        }
        private void AddBanksForm_Load(object sender, EventArgs e)
        {
            try
            {
                string _BankCode = Utils.NextSeries(NextBankCode());
                txtBankCode.Text = _BankCode;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string NextBankCode()
        {
            try
            {
                var cn = (from c in db.Banks
                          orderby c.BankCode descending
                          select c).FirstOrDefault();
                if (cn == null)
                    return "0";
                return cn.BankCode.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "0";
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
        private void txtBankCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (nonNumberEntered == true)
                {
                    if (e.KeyChar == 13)
                    {

                    }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        #endregion "Private Methods"
    }
}