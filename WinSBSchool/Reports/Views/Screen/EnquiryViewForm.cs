using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DAL;
using System.Linq;
using WinSBSchool.Forms;
using WinSBSchool.Reports.ViewModelBuilders;
using WinSBSchool.Reports.ViewModels;
using CommonLib;
using System.Threading;
using System.ComponentModel;

namespace WinSBSchool.Reports.Views.Screen
{
    public partial class EnquiryViewForm : Form
    {
        string connection;
        Account _Account;
        Repository rep;
        SBSchoolDBEntities db;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public EnquiryViewForm(string _user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            db = new DAL.SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            user = _user;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished EnquiryViewForm initialization", TAG));

        }
        public EnquiryViewForm(Account acc, string _user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            db = new DAL.SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (acc == null)
                throw new ArgumentNullException("Account");
            _Account = acc;
            txtAccountId.Text = _Account.Id.ToString();

            user = _user;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished EnquiryViewForm initialization", TAG));

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

        private void EnquiryViewForm_Load(object sender, EventArgs e)
        {
            try
            {
                DateTime v = DateTime.Today;
                this.dateTimePickerEndDate.Value = DateTime.Today;
                this.dateTimePickerStartDate.Value = DateTime.Today.AddMonths(-3);

                groupBoxAccountId.Visible = false;
                groupBoxTransRef.Visible = false;
                //btnSearch.Enabled = false;
                //btnPrint.Enabled = false;
                radioButtonAccountId.Checked = true;

                if (!string.IsNullOrEmpty(txtAccountId.Text))
                {
                    btnSearch.Enabled = true;
                    btnPrint.Enabled = true;
                    Account AccountPosting = rep.GetAccount(int.Parse(txtAccountId.Text));
                    if (AccountPosting != null)
                    {
                        lblAccountInfo.Text = "Name :[  " + _Account.AccountName + "  ]  No :[  " + _Account.AccountNo + "  ]   Book Balance :[  " + _Account.BookBalance.ToString("C2") + "  ]";
                    }
                }
                var _accounts = from acc in rep.GetAllAccounts()
                                where acc.IsDeleted == false
                                select acc;
                bindingSourceaccounts.DataSource = _accounts.ToList();
                DataGridViewComboBoxColumn colCboxaccounts = new DataGridViewComboBoxColumn();
                colCboxaccounts.HeaderText = "Account";
                colCboxaccounts.Name = "cbAccounts";
                colCboxaccounts.DataSource = bindingSourceaccounts;
                // The display member is the name column in the column datasource  
                colCboxaccounts.DisplayMember = "AccountName";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxaccounts.DataPropertyName = "AccountId";
                // The value member is the primary key of the parent table  
                colCboxaccounts.ValueMember = "Id";
                colCboxaccounts.MaxDropDownItems = 10;
                colCboxaccounts.Width = 120;
                colCboxaccounts.DisplayIndex = 1;
                colCboxaccounts.MinimumWidth = 5;
                colCboxaccounts.FlatStyle = FlatStyle.Flat;
                colCboxaccounts.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxaccounts.ReadOnly = true;
                if (!this.dataGridViewTransactions.Columns.Contains("cbAccounts"))
                {
                    dataGridViewTransactions.Columns.Add(colCboxaccounts);
                }

                var _ttypes = from ttype in rep.GetAllTransactionTypes()
                              where ttype.IsDeleted == false
                              select ttype;
                bindingSourcetransactiontypes.DataSource = _ttypes.ToList();
                DataGridViewComboBoxColumn colCboxtransactiontypes = new DataGridViewComboBoxColumn();
                colCboxtransactiontypes.HeaderText = "Transaction Type";
                colCboxtransactiontypes.Name = "cbtransactiontypes";
                colCboxtransactiontypes.DataSource = bindingSourcetransactiontypes;
                // The display member is the name column in the column datasource  
                colCboxtransactiontypes.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxtransactiontypes.DataPropertyName = "TransactionTypeId";
                // The value member is the primary key of the parent table  
                colCboxtransactiontypes.ValueMember = "Id";
                colCboxtransactiontypes.MaxDropDownItems = 10;
                colCboxtransactiontypes.Width = 120;
                colCboxtransactiontypes.DisplayIndex = 2;
                colCboxtransactiontypes.MinimumWidth = 5;
                colCboxtransactiontypes.FlatStyle = FlatStyle.Flat;
                colCboxtransactiontypes.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxtransactiontypes.ReadOnly = true;
                if (!this.dataGridViewTransactions.Columns.Contains("cbtransactiontypes"))
                {
                    dataGridViewTransactions.Columns.Add(colCboxtransactiontypes);
                }

                var statementflags = new BindingList<KeyValuePair<string, string>>();
                statementflags.Add(new KeyValuePair<string, string>("C", "Credit"));
                statementflags.Add(new KeyValuePair<string, string>("D", "Debit"));
                DataGridViewComboBoxColumn colCboxStatementFlag = new DataGridViewComboBoxColumn();
                colCboxStatementFlag.HeaderText = "Statement Flag";
                colCboxStatementFlag.Name = "cbStatementFlag";
                colCboxStatementFlag.DataSource = statementflags;
                // The display member is the name column in the column datasource  
                colCboxStatementFlag.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxStatementFlag.DataPropertyName = "StatementFlag";
                // The value member is the primary key of the parent table  
                colCboxStatementFlag.ValueMember = "Key";
                colCboxStatementFlag.MaxDropDownItems = 10;
                colCboxStatementFlag.Width = 70;
                colCboxStatementFlag.DisplayIndex = 5;
                colCboxStatementFlag.MinimumWidth = 5;
                colCboxStatementFlag.FlatStyle = FlatStyle.Flat;
                colCboxStatementFlag.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatementFlag.ReadOnly = true;
                if (!this.dataGridViewTransactions.Columns.Contains("cbStatementFlag"))
                {
                    dataGridViewTransactions.Columns.Add(colCboxStatementFlag);
                }

                this.dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewTransactions.AutoGenerateColumns = false;
                dataGridViewTransactions.DataSource = bindingSourceTransactions;

                AutoCompleteStringCollection acsaccid = new AutoCompleteStringCollection();
                acsaccid.AddRange(this.AutoComplete_AccountIds());
                txtAccountId.AutoCompleteCustomSource = acsaccid;
                txtAccountId.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountId.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acstransref = new AutoCompleteStringCollection();
                acstransref.AddRange(this.AutoComplete_TransactionReferences());
                txtTransRef.AutoCompleteCustomSource = acstransref;
                txtTransRef.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtTransRef.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished EnquiryViewForm load", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            try
            {
                bindingSourceTransactions.DataSource = null;
                foreach (Control ctrl in groupBoxSearchCriteria.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)ctrl).Checked)
                        {
                            switch (((RadioButton)ctrl).Name)
                            {
                                case "radioButtonTransactionReference":
                                    List<Transaction> lst_txns = new List<Transaction>();
                                    if (string.IsNullOrEmpty(txtTransRef.Text))
                                    {
                                        var _transactionsquery = from ts in db.Transactions
                                                                 orderby ts.Id descending
                                                                 select ts;
                                        lst_txns = _transactionsquery.ToList();
                                    }
                                    else
                                    {
                                        string _Transref = txtTransRef.Text.Trim();
                                        var _transactionsquery = from ts in db.Transactions
                                                                 where ts.TransRef == _Transref
                                                                 orderby ts.Id descending
                                                                 select ts;
                                        lst_txns = _transactionsquery.ToList();
                                    }

                                    List<StatementTransaction> lstTransactions = new List<StatementTransaction>();
                                    decimal runningBal = 0;
                                    foreach (Transaction t in lst_txns)
                                    {
                                        StatementTransaction tx = new StatementTransaction();
                                        tx.Id = t.Id;
                                        tx.TransactionTypeId = t.TransactionTypeId;
                                        tx.AccountId = t.AccountId;
                                        tx.Amount = t.Amount;
                                        tx.PostDate = t.PostDate;
                                        tx.RecordDate = t.RecordDate;
                                        tx.ValueDate = t.ValueDate;
                                        tx.Narrative = t.Narrative;
                                        tx.StatementFlag = t.StatementFlag;
                                        tx.Authorizer = t.Authorizer;
                                        tx.UserId = t.UserName;
                                        tx.TransRef = t.TransRef;
                                        tx.IsDeleted = t.IsDeleted;

                                        //Compute running balance
                                        runningBal += t.Amount;
                                        tx.Balance = runningBal;

                                        lstTransactions.Add(tx);
                                    }

                                    bindingSourceTransactions.DataSource = lstTransactions;
                                    groupBox2.Text = "TRANSACTIONS  LIST   [  " + bindingSourceTransactions.Count.ToString() + "  ]";
                                    break;
                                case "radioButtonAccountId":
                                    Account AccountPosting = new Account();
                                    List<Transaction> _lst_txns = new List<Transaction>();
                                    if (string.IsNullOrEmpty(txtAccountId.Text))
                                    {
                                        var _transactionsquery = from ts in db.Transactions
                                                                 orderby ts.Id descending
                                                                 select ts;
                                        _lst_txns = _transactionsquery.ToList();
                                    }
                                    else
                                    {
                                        int accid = int.Parse(txtAccountId.Text);
                                        AccountPosting = rep.GetAccount(accid);

                                        var _transactionsquery = from ts in db.Transactions
                                                                 where ts.AccountId == accid
                                                                 orderby ts.Id descending
                                                                 select ts;
                                        _lst_txns = _transactionsquery.ToList();
                                    }

                                    if (AccountPosting == null)
                                    {
                                        errorProvider.Clear();
                                        errorProvider.SetError(txtAccountId, "Error Retrieving the Account!");
                                    }

                                    List<StatementTransaction> _lstTransactions = new List<StatementTransaction>();
                                    decimal _runningBal = 0;
                                    foreach (Transaction t in _lst_txns)
                                    {
                                        StatementTransaction tx = new StatementTransaction();
                                        tx.Id = t.Id;
                                        tx.TransactionTypeId = t.TransactionTypeId;
                                        tx.AccountId = t.AccountId;
                                        tx.Amount = t.Amount;
                                        tx.PostDate = t.PostDate;
                                        tx.RecordDate = t.RecordDate;
                                        tx.ValueDate = t.ValueDate;
                                        tx.Narrative = t.Narrative;
                                        tx.StatementFlag = t.StatementFlag;
                                        tx.Authorizer = t.Authorizer;
                                        tx.UserId = t.UserName;
                                        tx.TransRef = t.TransRef;
                                        tx.IsDeleted = t.IsDeleted;

                                        //Compute running balance
                                        _runningBal += t.Amount;
                                        tx.Balance = _runningBal;

                                        _lstTransactions.Add(tx);
                                    }

                                    bindingSourceTransactions.DataSource = _lstTransactions;
                                    groupBox2.Text = "TRANSACTIONS  LIST   [  " + bindingSourceTransactions.Count.ToString() + "  ]";

                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSearchAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                SearchAccountsSimpleForm saf = new SearchAccountsSimpleForm(user, connection, _notificationmessageEventname) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountsSimpleForm.AccountSelectHandler(saf_OnAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            try
            {
                SetAccountId(e._Account);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetAccountId(Account _Account)
        {
            try
            {
                if (_Account != null)
                {
                    txtAccountId.Text = _Account.Id.ToString();
                    lblAccountInfo.Text = "Name :[  " + _Account.AccountName + "  ]  No :[  " + _Account.AccountNo + "  ]   Book Balance :[  " + _Account.BookBalance.ToString("C2") + "  ]";
                }
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
        private string[] AutoComplete_TransactionReferences()
        {
            try
            {
                var transrefquery = from ts in db.Transactions
                                    orderby ts.PostDate ascending
                                    select ts.TransRef;
                return transrefquery.ToArray();
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
        private void btnPrint_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                int _AccountId;
                DateTime _startdate = dateTimePickerStartDate.Value;
                DateTime _enddate = dateTimePickerEndDate.Value;

                if (int.TryParse(txtAccountId.Text, out _AccountId))
                {
                    //Viewer.PDFViewer _viewer = new Viewer.PDFViewer(_AccountId, _startdate, _enddate, user, connection);
                    //_viewer.WindowState = FormWindowState.Normal;
                    //_viewer.StartPosition = FormStartPosition.CenterScreen;
                    //_viewer.Show();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAccountId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
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
        private void txtAccountId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctrl in groupBoxSearchCriteria.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)ctrl).Checked)
                        {
                            switch (((RadioButton)ctrl).Name)
                            {
                                case "radioButtonAccountId":
                                    if (string.IsNullOrEmpty(txtAccountId.Text))
                                    {
                                        //btnSearch.Enabled = false;
                                        //btnPrint.Enabled = false;
                                    }
                                    else
                                    {
                                        lblAccountInfo.Text = string.Empty;
                                        int _accountid = 0;
                                        if (int.TryParse(txtAccountId.Text.Trim(), out _accountid))
                                        {
                                            var _accountqueryquery = (from ac in db.Accounts
                                                                      where ac.Id == _accountid
                                                                      select ac).FirstOrDefault();
                                            if (_accountqueryquery != null)
                                            {
                                                lblAccountInfo.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                                            }
                                        }

                                        btnSearch.Enabled = true;
                                        btnPrint.Enabled = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void radioButtonAccountId_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctrl in groupBoxSearchCriteria.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)ctrl).Checked)
                        {
                            switch (((RadioButton)ctrl).Name)
                            {
                                case "radioButtonAccountId":
                                    groupBoxAccountId.Visible = true;
                                    break;
                                default:
                                    groupBoxAccountId.Visible = false;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void radioButtonTransactionReference_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctrl in groupBoxSearchCriteria.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)ctrl).Checked)
                        {
                            switch (((RadioButton)ctrl).Name)
                            {

                                case "radioButtonTransactionReference":
                                    groupBoxTransRef.Visible = true;
                                    groupBoxTransRef.Location = groupBoxAccountId.Location;
                                    break;
                                default:
                                    groupBoxTransRef.Visible = false;
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtTransRef_TextChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (Control ctrl in groupBoxSearchCriteria.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton))
                    {
                        if (((RadioButton)ctrl).Checked)
                        {
                            switch (((RadioButton)ctrl).Name)
                            {
                                case "radioButtonTransactionReference":
                                    if (string.IsNullOrEmpty(txtTransRef.Text))
                                    {
                                        //btnSearch.Enabled = false;
                                        //btnPrint.Enabled = false;
                                    }
                                    else
                                    {
                                        btnSearch.Enabled = true;
                                        btnPrint.Enabled = true;
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdvancedSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void btntransactions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loading TransactionsForm", TAG));
                TransactionsForm tf = new TransactionsForm(user, connection, _notificationmessageEventname);
                tf.Show();
            }
            catch (Exception ex)
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewTransactions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void dataGridViewTransactions_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count != 0)
            {
                try
                {
                    StatementTransaction stxn = (StatementTransaction)bindingSourceTransactions.Current;
                    Transaction txn = new Transaction()
                    {
                        AccountId = stxn.AccountId,
                        Amount = stxn.Amount,
                        Id = stxn.Id,
                        IsDeleted = stxn.IsDeleted,
                        Narrative = stxn.Narrative,
                        PostDate = stxn.PostDate,
                        RecordDate = stxn.RecordDate,
                        Authorizer = stxn.Authorizer,
                        StatementFlag = stxn.StatementFlag,
                        TransactionTypeId = stxn.TransactionTypeId,
                        TransRef = stxn.TransRef,
                        UserName = stxn.UserId,
                        ValueDate = stxn.ValueDate
                    };

                    Reports.Views.Screen.ViewTransactionDetailsForm vtd = new Reports.Views.Screen.ViewTransactionDetailsForm(txn, user, connection, _notificationmessageEventname);
                    vtd.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }










    }
}