﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class AccountsForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname; 
        IQueryable<Account> _Accounts;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public AccountsForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            TAG = this.GetType().Name;

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname = notificationmessageEventname;

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
            user = UserName;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AccountsForm initialization", TAG));

        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.WriteToErrorLogFile_and_EventViewer(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }

        private void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            Log.WriteToErrorLogFile_and_EventViewer(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }
        private void AccountsForm_Load(object sender, EventArgs e)
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
                colAccountType.Width = 130;
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

                _Accounts = from ac in db.Accounts
                            where ac.Closed == false
                            select ac;
                bindingSourceAccounts.DataSource = _Accounts.ToList();
                groupBox2.Text = bindingSourceAccounts.Count.ToString();

                dataGridViewAccounts.AutoGenerateColumns = false;
                dataGridViewAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewAccounts.DataSource = bindingSourceAccounts;

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
                var custidsquery = (from ac in db.Customers
                                    select ac.Id).Distinct();
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddAccountForm aaf = new AddAccountForm(user, connection, _notificationmessageEventname) { Owner = this };
            aaf.ShowDialog();
        }

        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewAccounts.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.Account account = (DAL.Account)bindingSourceAccounts.Current;
                    int customerid = account.CustomerId;
                    EditAccountForm eaf = new EditAccountForm(account, customerid, connection) { Owner = this };
                    eaf.Text = account.AccountNo + " - " + account.AccountName.ToString().ToUpper();
                    eaf.ShowDialog();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void RefreshGrid()
        {
            try
            {
                if (chkClosed.Checked)
                {
                    bindingSourceAccounts.DataSource = null;
                    var _Accountsquery = from ac in db.Accounts
                                         select ac;
                    bindingSourceAccounts.DataSource = _Accountsquery.ToList();
                    groupBox2.Text = bindingSourceAccounts.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewAccounts.Rows)
                    {
                        dataGridViewAccounts.Rows[dataGridViewAccounts.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewAccounts.Rows.Count - 1;
                        bindingSourceAccounts.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceAccounts.DataSource = null;
                    var _Accountsquery = from ac in db.Accounts
                                         where ac.Closed == false
                                         select ac;
                    bindingSourceAccounts.DataSource = _Accountsquery.ToList();
                    groupBox2.Text = bindingSourceAccounts.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewAccounts.Rows)
                    {
                        dataGridViewAccounts.Rows[dataGridViewAccounts.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewAccounts.Rows.Count - 1;
                        bindingSourceAccounts.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewAccounts.SelectedRows.Count != 0)
                {
                    DAL.Account account = (DAL.Account)bindingSourceAccounts.Current;
                    EditAccountForm eaf = new EditAccountForm(account, connection) { Owner = this };
                    eaf.DisableControls();
                    eaf.Text = account.AccountName.ToString().ToUpper();
                    eaf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
                groupBox2.Text = bindingSourceAccounts.Count.ToString();
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
                _account = null;
                int _AccId = int.Parse(txtAccountId.Text);
                string _AccNo = txtAccountNo.Text;
                string _AccName = txtAccountName.Text;
                int _CustId = int.Parse(txtCustomerId.Text);
                _account = from ac in db.Accounts
                           where ac.Id == _AccId
                           where ac.AccountNo.StartsWith(_AccNo)
                           where ac.AccountName.StartsWith(_AccName)
                           join cs in db.Customers on ac.Id equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed== false
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
                           join cs in db.Customers on ac.Id equals cs.Id
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
                           join cs in db.Customers on ac.Id equals cs.Id
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
                           join cs in db.Customers on ac.Id equals cs.Id
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
                           join cs in db.Customers on ac.Id equals cs.Id
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
                           join cs in db.Customers on ac.Id equals cs.Id
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
                           join cs in db.Customers on ac.Id equals cs.Id
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
                           join cs in db.Customers on ac.Id equals cs.Id
                           where cs.Id == _CustId
                           where ac.Closed == false
                           select ac;
                return _account;
            } 
            return _account;
        }
        private void btnRemoveFilter_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkClosed.Checked)
                {
                    bindingSourceAccounts.DataSource = null;
                    var _Accountsquery = from ac in db.Accounts
                                         select ac;
                    bindingSourceAccounts.DataSource = _Accountsquery.ToList();
                    groupBox2.Text = bindingSourceAccounts.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewAccounts.Rows)
                    {
                        dataGridViewAccounts.Rows[dataGridViewAccounts.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewAccounts.Rows.Count - 1;
                        bindingSourceAccounts.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceAccounts.DataSource = null;
                    var _Accountsquery = from ac in db.Accounts
                                         where ac.Closed == false
                                         select ac;
                    bindingSourceAccounts.DataSource = _Accountsquery.ToList();
                    groupBox2.Text = bindingSourceAccounts.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewAccounts.Rows)
                    {
                        dataGridViewAccounts.Rows[dataGridViewAccounts.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewAccounts.Rows.Count - 1;
                        bindingSourceAccounts.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnCloseAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewAccounts.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.Account account = (DAL.Account)bindingSourceAccounts.Current;
                    if (account.BookBalance != 0)
                    {
                        MessageBox.Show("Account Balance must be 0", "SB School",  MessageBoxButtons.OK,  MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (DialogResult.Yes == MessageBox.Show("Are you sure you want to Close Account\n" + account.AccountName.Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            account.Closed = true;
                            rep.UpdateAccount(account);
                            RefreshGrid();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
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

        private void btnAdvancedSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountForm saf = new SearchAccountForm(connection) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountForm.AccountSelectHandler(saf_OnAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void saf_OnAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetAccountNos(e._Account);
        }
        private void SetAccountNos(Account _Account)
        {
            if (_Account != null)
            {
                bindingSourceAccounts.DataSource = _Account;
                groupBox2.Text = bindingSourceAccounts.Count.ToString();
            }

        }

        private void chkClosed_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkClosed.Checked)
                {
                    bindingSourceAccounts.DataSource = null;
                    var _Accountsquery = from ac in db.Accounts
                                         select ac;
                    bindingSourceAccounts.DataSource = _Accountsquery.ToList();
                    groupBox2.Text = bindingSourceAccounts.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewAccounts.Rows)
                    {
                        dataGridViewAccounts.Rows[dataGridViewAccounts.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewAccounts.Rows.Count - 1;
                        bindingSourceAccounts.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceAccounts.DataSource = null;
                    var _Accountsquery = from ac in db.Accounts
                                         where ac.Closed == false
                                         select ac;
                    bindingSourceAccounts.DataSource = _Accountsquery.ToList();
                    groupBox2.Text = bindingSourceAccounts.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewAccounts.Rows)
                    {
                        dataGridViewAccounts.Rows[dataGridViewAccounts.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewAccounts.Rows.Count - 1;
                        bindingSourceAccounts.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewAccounts_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewAccounts.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.Account account = (DAL.Account)bindingSourceAccounts.Current;
                    int customerid = account.CustomerId;
                    EditAccountForm eaf = new EditAccountForm(account, customerid, connection) { Owner = this };
                    eaf.Text = account.AccountNo + " - " + account.AccountName.ToString().ToUpper();
                    eaf.ShowDialog();

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }





    }
}