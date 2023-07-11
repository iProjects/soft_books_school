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
    public partial class SearchAccountsSimpleForm : Form
    {
        SBSchoolDBEntities db;
        string connection;
        IQueryable<Account> _Accounts;
        //delegate
        public delegate void AccountSelectHandler(object sender, AccountSelectEventArgs e);
        //event
        public event AccountSelectHandler OnAccountListSelected;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public SearchAccountsSimpleForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (dataGridViewAccounts.SelectedRows.Count != 0)
            {

                try
                {
                    Account selectedAccount = (Account)bindingSourceAccounts.Current;
                    OnAccountListSelected(this, new AccountSelectEventArgs(selectedAccount));

                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void SearchAccountsSimpleForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _AccountTypesquery = from dc in db.AccountTypes
                                         select dc;
                List<AccountType> _AccountTypes = _AccountTypesquery.ToList();
                DataGridViewComboBoxColumn colAccountType = new DataGridViewComboBoxColumn();
                colAccountType.HeaderText = "Account Type";
                colAccountType.Name = "cbAccountType";
                colAccountType.DataSource = _AccountTypes;
                colAccountType.DisplayMember = "Description";
                colAccountType.DataPropertyName = "AccountTypeId";
                colAccountType.ValueMember = "Id";
                colAccountType.MaxDropDownItems = 10;
                colAccountType.DisplayIndex = 3;
                colAccountType.MinimumWidth = 5;
                colAccountType.Width = 100;
                colAccountType.FlatStyle = FlatStyle.Flat;
                colAccountType.DefaultCellStyle.NullValue = "--- Select ---";
                colAccountType.ReadOnly = true; 
                if (!this.dataGridViewAccounts.Columns.Contains("cbAccountType"))
                {
                    dataGridViewAccounts.Columns.Add(colAccountType);
                }

                var _COAsquery = from coa in db.COAs
                                 select coa;
                List<COA> _COAs = _COAsquery.ToList();
                DataGridViewComboBoxColumn colCOA = new DataGridViewComboBoxColumn();
                colCOA.HeaderText = "COA";
                colCOA.Name = "cbCOA";
                colCOA.DataSource = _COAs;
                colCOA.DisplayMember = "Description";
                colCOA.DataPropertyName = "COAId";
                colCOA.ValueMember = "Id";
                colCOA.MaxDropDownItems = 10;
                colCOA.DisplayIndex = 4;
                colCOA.MinimumWidth = 5;
                colCOA.Width = 100;
                colCOA.FlatStyle = FlatStyle.Flat;
                colCOA.DefaultCellStyle.NullValue = "--- Select ---";
                colCOA.ReadOnly = true; 
                if (!this.dataGridViewAccounts.Columns.Contains("cbCOA"))
                {
                    dataGridViewAccounts.Columns.Add(colCOA);
                }

                var _Customersquery = from dc in db.Customers
                                      select dc;
                List<Customer> _Customers = _Customersquery.ToList();
                DataGridViewComboBoxColumn colCustomer = new DataGridViewComboBoxColumn();
                colCustomer.HeaderText = "Customer";
                colCustomer.Name = "cbCustomer";
                colCustomer.DataSource = _Customers;
                colCustomer.DisplayMember = "CustomerName";
                colCustomer.DataPropertyName = "CustomerId";
                colCustomer.ValueMember = "Id";
                colCustomer.MaxDropDownItems = 10;
                colCustomer.DisplayIndex = 2;
                colCustomer.MinimumWidth = 5;
                colCustomer.Width = 100;
                colCustomer.FlatStyle = FlatStyle.Flat;
                colCustomer.DefaultCellStyle.NullValue = "--- Select ---";
                colCustomer.ReadOnly = true; 
                if (!this.dataGridViewAccounts.Columns.Contains("cbCustomer"))
                {
                    //dataGridViewAccounts.Columns.Add(colCustomer);
                }

                dataGridViewAccounts.AutoGenerateColumns = false;
                this.dataGridViewAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewAccounts.DataSource = bindingSourceAccounts;

                _Accounts = db.Accounts.Where(i => i.Closed == false);

                AutoCompleteStringCollection acsaccid = new AutoCompleteStringCollection();
                acsaccid.AddRange(this.AutoComplete_AccountIds());
                txtAccountId.AutoCompleteCustomSource = acsaccid;
                txtAccountId.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountId.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscaccno = new AutoCompleteStringCollection();
                acscaccno.AddRange(this.AutoComplete_AccountNos());
                txtAccountNo.AutoCompleteCustomSource = acscaccno;
                txtAccountNo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountNo.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscaccName = new AutoCompleteStringCollection();
                acscaccName.AddRange(this.AutoComplete_AccNames());
                txtAccountName.AutoCompleteCustomSource = acscaccName;
                txtAccountName.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountName.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsccustId = new AutoCompleteStringCollection();
                acsccustId.AddRange(this.AutoComplete_CustomerIds());
                txtCustomerId.AutoCompleteCustomSource = acsccustId;
                txtCustomerId.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtCustomerId.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_AccountIds()
        {
            try
            {
                var accidsquery = (from ac in db.Accounts
                                   where ac.Closed == false
                                   select ac.Id).Distinct();
                int[] intarray = accidsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < accidsquery.Count(); i++)
                {
                    string strName = intarray[i].ToString();
                    items.Add(strName);
                }
                return items.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_AccountNos()
        {
            try
            {
                var accnosquery = from ac in db.Accounts
                                  where ac.Closed == false
                                  select ac.AccountNo;
                return accnosquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_AccNames()
        {
            try
            {
                var accnamequery = from ac in db.Accounts
                                   where ac.Closed == false
                                   select ac.AccountName;
                return accnamequery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_CustomerIds()
        {
            try
            {
                var custidsquery = (from ac in db.Accounts
                                    select ac.CustomerId).Distinct();
                int[] intarray = custidsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < custidsquery.Count(); i++)
                {
                    string strName = intarray[i].ToString();
                    items.Add(strName);
                }
                return items.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        // apply the filter
        private void ApplyFilter()
        {
            try
            {
                var filter = CreateFilter(_Accounts);
                // set the filter
                this.bindingSourceAccounts.DataSource = filter;
                groupBox1.Text = bindingSourceAccounts.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private IQueryable<Account> CreateFilter(IQueryable<Account> _account)
        {
            //none
            if (string.IsNullOrEmpty(txtAccountId.Text)
                && string.IsNullOrEmpty(txtAccountNo.Text) && string.IsNullOrEmpty(txtAccountName.Text) && string.IsNullOrEmpty(txtCustomerId.Text))
            {
                return _account;
            }
            //all
            if (!string.IsNullOrEmpty(txtAccountId.Text)
                && !string.IsNullOrEmpty(txtAccountNo.Text) && !string.IsNullOrEmpty(txtAccountName.Text) && !string.IsNullOrEmpty(txtCustomerId.Text))
            {
                int _AccId = int.Parse(txtAccountId.Text);
                string _AccNo = txtAccountNo.Text;
                string _AccName = txtAccountName.Text;
                int _CustId = int.Parse(txtCustomerId.Text);
                _account = from ac in db.Accounts
                           where ac.Id == _AccId
                           where ac.AccountNo.StartsWith(_AccNo)
                           where ac.AccountName.StartsWith(_AccName)
                           join cs in db.Customers on ac.CustomerId equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountid
            if (!string.IsNullOrEmpty(txtAccountId.Text)
                && string.IsNullOrEmpty(txtAccountNo.Text) && string.IsNullOrEmpty(txtAccountName.Text) && string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                int _AccId = int.Parse(txtAccountId.Text);
                _account = from ac in db.Accounts
                           where ac.Id == _AccId
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountno
            if (string.IsNullOrEmpty(txtAccountId.Text)
                 && !string.IsNullOrEmpty(txtAccountNo.Text) && string.IsNullOrEmpty(txtAccountName.Text) && string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                string _AccNo = txtAccountNo.Text;
                _account = from ac in db.Accounts
                           where ac.AccountNo.StartsWith(_AccNo)
                           where ac.Closed == false
                           select ac;
                return _account;
            }            
            //accountname
            if (string.IsNullOrEmpty(txtAccountId.Text)
                 && string.IsNullOrEmpty(txtAccountNo.Text) && !string.IsNullOrEmpty(txtAccountName.Text) && string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                string _AccName = txtAccountName.Text;
                _account = from ac in db.Accounts
                           where ac.AccountName.StartsWith(_AccName)
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //customerid
            if (string.IsNullOrEmpty(txtAccountId.Text)
                 && string.IsNullOrEmpty(txtAccountNo.Text) && string.IsNullOrEmpty(txtAccountName.Text) && !string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                int _CustId = int.Parse(txtCustomerId.Text);
                _account = from ac in db.Accounts
                           join cs in db.Customers on ac.CustomerId equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountid and accountno
            if (!string.IsNullOrEmpty(txtAccountId.Text)
                && !string.IsNullOrEmpty(txtAccountNo.Text) && string.IsNullOrEmpty(txtAccountName.Text) && string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                int _AccId = int.Parse(txtAccountId.Text);
                string _AccNo = txtAccountNo.Text;
                _account = from ac in db.Accounts
                           where ac.Id == _AccId
                           where ac.AccountNo.StartsWith(_AccNo)
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountid and accountname
            if (!string.IsNullOrEmpty(txtAccountId.Text)
                 && string.IsNullOrEmpty(txtAccountNo.Text) && !string.IsNullOrEmpty(txtAccountName.Text) && string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                int _AccId = int.Parse(txtAccountId.Text);
                string _AccName = txtAccountName.Text;
                _account = from ac in db.Accounts
                           where ac.Id == _AccId
                           where ac.AccountName.StartsWith(_AccName)
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountid and customerid
            if (!string.IsNullOrEmpty(txtAccountId.Text)
                 && string.IsNullOrEmpty(txtAccountNo.Text) && string.IsNullOrEmpty(txtAccountName.Text) && !string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                int _AccId = int.Parse(txtAccountId.Text);
                int _CustId = int.Parse(txtCustomerId.Text);
                _account = from ac in db.Accounts
                           where ac.Id == _AccId
                           join cs in db.Customers on ac.CustomerId equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountno and accountname
            if (string.IsNullOrEmpty(txtAccountId.Text)
                 && !string.IsNullOrEmpty(txtAccountNo.Text) && !string.IsNullOrEmpty(txtAccountName.Text) && string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                string _AccNo = txtAccountNo.Text;
                string _AccName = txtAccountName.Text;
                _account = from ac in db.Accounts
                           where ac.AccountNo.StartsWith(_AccNo)
                           where ac.AccountName.StartsWith(_AccName)
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountno and customerid
            if (string.IsNullOrEmpty(txtAccountId.Text)
                && !string.IsNullOrEmpty(txtAccountNo.Text) && string.IsNullOrEmpty(txtAccountName.Text) && !string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                string _AccNo = txtAccountNo.Text;
                int _CustId = int.Parse(txtCustomerId.Text);
                _account = from ac in db.Accounts
                           where ac.AccountNo.StartsWith(_AccNo)
                           join cs in db.Customers on ac.CustomerId equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountname and customerid
            if (string.IsNullOrEmpty(txtAccountId.Text)
                && string.IsNullOrEmpty(txtAccountNo.Text) && !string.IsNullOrEmpty(txtAccountName.Text) && !string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                string _AccName = txtAccountName.Text;
                int _CustId = int.Parse(txtCustomerId.Text);
                _account = from ac in db.Accounts
                           where ac.AccountName.StartsWith(_AccName)
                           join cs in db.Customers on ac.CustomerId equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountid and accountno and accountname 
            if (!string.IsNullOrEmpty(txtAccountId.Text)
                 && !string.IsNullOrEmpty(txtAccountNo.Text) && !string.IsNullOrEmpty(txtAccountName.Text) && string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                int _AccId = int.Parse(txtAccountId.Text);
                string _AccNo = txtAccountNo.Text;
                string _AccName = txtAccountName.Text;
                _account = from ac in db.Accounts
                           where ac.Id == _AccId
                           where ac.AccountNo.StartsWith(_AccNo)
                           where ac.AccountName.StartsWith(_AccName)
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountid and accountno and customerid
            if (!string.IsNullOrEmpty(txtAccountId.Text)
                 && !string.IsNullOrEmpty(txtAccountNo.Text) && string.IsNullOrEmpty(txtAccountName.Text) && !string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                int _AccId = int.Parse(txtAccountId.Text);
                string _AccNo = txtAccountNo.Text;
                int _CustId = int.Parse(txtCustomerId.Text);
                _account = from ac in db.Accounts
                           where ac.Id == _AccId
                           where ac.AccountNo.StartsWith(_AccNo)
                           join cs in db.Customers on ac.CustomerId equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed == false
                           select ac;
                return _account;
            }
            //accountid and accountname and customerid
            if (!string.IsNullOrEmpty(txtAccountId.Text)
                 && string.IsNullOrEmpty(txtAccountNo.Text) && !string.IsNullOrEmpty(txtAccountName.Text) && !string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                int _AccId = int.Parse(txtAccountId.Text);
                string _AccName = txtAccountName.Text;
                int _CustId = int.Parse(txtCustomerId.Text);
                _account = from ac in db.Accounts
                           where ac.Id == _AccId
                           where ac.AccountName.StartsWith(_AccName)
                           join cs in db.Customers on ac.CustomerId equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed == false
                           select ac;
                return _account;
            } 
            //accountno and accountname and customerid
            if (string.IsNullOrEmpty(txtAccountId.Text)
                && !string.IsNullOrEmpty(txtAccountNo.Text) && !string.IsNullOrEmpty(txtAccountName.Text) && !string.IsNullOrEmpty(txtCustomerId.Text))
            {
                _account = null;
                string _AccNo = txtAccountNo.Text;
                string _AccName = txtAccountName.Text;
                int _CustId = int.Parse(txtCustomerId.Text);
                _account = from ac in db.Accounts
                           where ac.AccountNo.StartsWith(_AccNo)
                           where ac.AccountName.StartsWith(_AccName)
                           join cs in db.Customers on ac.CustomerId equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed == false
                           select ac;
                return _account;
            } 
            return _account;
        }
        private void txtAccountNo_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtAccountNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtAccountName_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txtAccountName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        private void txtAccountId_Validated(object sender, EventArgs e)
        {
            if (nonNumberEntered == true)
            {
                ApplyFilter();
            }
        }
        private void txtAccountId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {
                    ApplyFilter();
                }
                e.Handled = true;
            }
        }
        private void txtAccountId_KeyDown(object sender, KeyEventArgs e)
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
        private void txtCustomerId_Validated(object sender, EventArgs e)
        {
            if (nonNumberEntered == true)
            {
                ApplyFilter();
            }
        }
        private void txtCustomerId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                if (e.KeyChar == 13)
                {
                    ApplyFilter();
                }
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtCustomerId_KeyDown(object sender, KeyEventArgs e)
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
        private void dataGridViewAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAccounts.SelectedRows.Count != 0)
            {

                try
                {
                    Account selectedAccount = (Account)bindingSourceAccounts.Current;
                    OnAccountListSelected(this, new AccountSelectEventArgs(selectedAccount));

                    this.Close();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void dataGridViewAccounts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }



    }
}