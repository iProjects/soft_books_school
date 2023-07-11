using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;


namespace WinSBSchool.Forms
{
    public partial class EditAccountForm : Form
    {

        Repository rep;
        Account a;
        SBSchoolDBEntities db;
        int _CustomerId;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditAccountForm(Account account, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
            a = account;
        }

        public EditAccountForm(Account account, int CustomerId, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
            a = account;
            _CustomerId = CustomerId;
            this.txtCustomerID.Text = _CustomerId.ToString();

        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsAccountValid())
            {
                try
                {

                    if (cboAccountTypes.SelectedIndex != -1)
                    {
                        a.AccountTypeId = int.Parse(cboAccountTypes.SelectedValue.ToString());
                    }
                    if (cboCOA.SelectedIndex != -1)
                    {
                        a.COAId = int.Parse(cboCOA.SelectedValue.ToString());
                    }

                    rep.UpdateAccount(a);

                    AccountsForm f = (AccountsForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }

        }
        public bool IsAccountValid()
        {
            bool noerror = true;
            if (cboAccountTypes.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboAccountTypes, "Select Account Type!");
                return false;
            }
            if (cboCOA.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCOA, "Select a Chart of Accounts!");
                return false;
            }
            return noerror;
        }
        private string NextAccountNo()
        {
            try
            {
                var cn = (from c in db.Accounts
                          orderby c.Id descending
                          select c).FirstOrDefault();
                if (cn == null)
                    return "0";
                return cn.AccountNo.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "0";
            }
        }
        private void InitializeControls()
        {
            try
            {
                if (a.CustomerId != null)
                {
                    txtCustomerID.Text = a.CustomerId.ToString();
                }
                if (a.AccountName != null)
                {
                    txtAccountName.Text = a.AccountName.ToString();
                }
                if (a.AccountNo != null)
                {
                    txtAccountNo.Text = a.AccountNo;
                }
                if (a.AccountNo == null)
                {
                    string _AccountNo = Utils.NextSeries(NextAccountNo());
                    txtAccountNo.Text = _AccountNo;
                }
                if (a.AccountTypeId != null)
                {
                    cboAccountTypes.SelectedValue = a.AccountTypeId;
                }
                if (a.COAId != null)
                {
                    cboCOA.SelectedValue = a.COAId;
                }
                if (a.BankBranch != null)
                {
                    txtBankSortCode.Text = a.BankBranch.ToString();
                }
                if (a.SchoolBranch != null)
                {
                    cboSchoolBranch.SelectedValue = a.SchoolBranch;
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
            txtCustomerID.Enabled = false;
            txtAccountNo.Enabled = false;
            txtAccountName.Enabled = false;
            //cboAccountTypes.Enabled = false;
            //cboCOA.Enabled = false;
            txtBankSortCode.Enabled = false;
            cboSchoolBranch.Enabled = false;
            btnSearchCustomerId.Enabled = false;
            btnSearchBankSortCode.Enabled = false;
            //btnUpdate.Enabled = false;
            //btnUpdate.Visible = false;
            //btnClose.Location = btnUpdate.Location;

        }
        private void EditAccountForm_Load(object sender, EventArgs e)
        {
            try
            {
                var defaultschool = (from pc in db.Schools
                                     where pc.DefaultSchool == true
                                     orderby pc.SchoolName ascending
                                     select pc).FirstOrDefault();                

                List<School> schools = rep.GetAllSchools();
                cboSchoolBranch.DataSource = schools;
                cboSchoolBranch.ValueMember = "Id";
                cboSchoolBranch.DisplayMember = "SchoolName";
                cboSchoolBranch.SelectedIndex = -1;

                var accttyps = from pc in db.AccountTypes
                               select pc;
                List<AccountType> accounttypes = accttyps.ToList();
                bindingSourceAccountTypes.DataSource = accounttypes;
                cboAccountTypes.DataSource = bindingSourceAccountTypes;
                cboAccountTypes.ValueMember = "Id";
                cboAccountTypes.DisplayMember = "Description";
                cboAccountTypes.SelectedIndex = -1;

                var COAsquery = from pc in db.COAs
                                orderby pc.ShortCode
                                select pc;
                List<COA> COAs = COAsquery.ToList();
                cboCOA.DataSource = COAs;
                cboCOA.ValueMember = "Id";
                cboCOA.DisplayMember = "Description";
                cboCOA.SelectedIndex = -1;

                InitializeControls();

                DisableControls();

                AutoCompleteStringCollection acscBnkSrtCd = new AutoCompleteStringCollection();
                acscBnkSrtCd.AddRange(this.AutoComplete_BankSortCodes());
                txtBankSortCode.AutoCompleteCustomSource = acscBnkSrtCd;
                txtBankSortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtBankSortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_BankSortCodes()
        {
            try
            {
                var bankcodesquery = from bk in db.vwBankBranches
                                     select bk.BankSortCode;
                return bankcodesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void btnSearchCustomerId_Click(object sender, EventArgs e)
        {
            SearchCustomerForm scf = new SearchCustomerForm(connection) { Owner = this };
            scf.OnCustomerListSelected += new SearchCustomerForm.CustomerSelectHandler(scf_OnCustomerListSelected);
            scf.ShowDialog();
        }
        private void scf_OnCustomerListSelected(object sender, CustomerSelectEventArgs e)
        {
            SetAccountNos(e._Customer);
        }
        private void SetAccountNos(Customer _customer)
        {
            if (_customer != null)
            {
                txtCustomerID.Text = _customer.Id.ToString();
            }

        }
        private void btnSearchBankSortCode_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBanksSimpleForm saf = new Forms.SearchBanksSimpleForm(connection) { Owner = this };
                saf.OnBankListSelected += new SearchBanksSimpleForm.BankSelectHandler(saf_OnSetBankSortCodeListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnSetBankSortCodeListSelected(object sender, BankSelectEventArgs e)
        {
            SetBankSortCode(e._BankSortCode);
        }
        private void SetBankSortCode(vwBankBranch _vwBankBranch)
        {
            if (_vwBankBranch != null)
            {
                txtBankSortCode.Text = _vwBankBranch.BankSortCode.Trim();
            }

        }
        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBankSortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtBankSortCode_KeyDown(object sender, KeyEventArgs e)
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