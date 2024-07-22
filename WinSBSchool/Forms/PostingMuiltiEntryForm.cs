using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class PostingMuiltiEntryForm : Form
    {
        //create an observable collection
        BindingList<Transaction> observableTransactions;
        Repository rep;
        SBSchoolDBEntities db;
        string user;
        string connection;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        string receiptNo;
        Account _account;

        public PostingMuiltiEntryForm(string s, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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
            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
            user = s;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PostingMuiltiEntryForm initialization", TAG));

            observableTransactions = new BindingList<Transaction>();

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
        private void PostingMuiltiEntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblaccountdetails.Text = string.Empty;

                var _TransactionTypesquery = from ttype in rep.GetAllTransactionTypes()
                                             where ttype.IsDeleted == false
                                             select ttype;
                List<TransactionType> transactiontypes = _TransactionTypesquery.ToList();

                cboTransactionType.DataSource = transactiontypes;
                cboTransactionType.ValueMember = "Id";
                cboTransactionType.DisplayMember = "Description";

                dataGridViewTransactions.AutoGenerateColumns = false;
                dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceTransactions.DataSource = observableTransactions;
                dataGridViewTransactions.DataSource = bindingSourceTransactions;

                DataGridViewComboBoxColumn colTransactionType = new DataGridViewComboBoxColumn();
                colTransactionType.HeaderText = "Transaction Type";
                colTransactionType.Name = "cbTransactionType";
                colTransactionType.DataSource = transactiontypes;
                colTransactionType.DisplayMember = "Description";
                colTransactionType.DataPropertyName = "TransactionTypeId";
                colTransactionType.ValueMember = "Id";
                colTransactionType.MaxDropDownItems = 10;
                colTransactionType.DisplayIndex = 0;
                colTransactionType.MinimumWidth = 5;
                colTransactionType.Width = 100;
                colTransactionType.FlatStyle = FlatStyle.Flat;
                colTransactionType.DefaultCellStyle.NullValue = "--- Select ---";
                colTransactionType.ReadOnly = true;

                if (!this.dataGridViewTransactions.Columns.Contains("cbTransactionType"))
                {
                    dataGridViewTransactions.Columns.Add(colTransactionType);
                }

                var _Accountsquery = from acc in db.Accounts
                                     where acc.IsDeleted == false && acc.Closed == false
                                     select acc;
                List<Account> _Accounts = _Accountsquery.ToList();

                DataGridViewComboBoxColumn colAccount = new DataGridViewComboBoxColumn();
                colAccount.HeaderText = "Account";
                colAccount.Name = "cbAccount";
                colAccount.DataSource = _Accounts;
                colAccount.DisplayMember = "AccountName";
                colAccount.DataPropertyName = "AccountId";
                colAccount.ValueMember = "Id";
                colAccount.MaxDropDownItems = 10;
                colAccount.DisplayIndex = 1;
                colAccount.MinimumWidth = 5;
                colAccount.Width = 100;
                colAccount.ReadOnly = true;
                colAccount.FlatStyle = FlatStyle.Flat;
                colAccount.DefaultCellStyle.NullValue = "--- Select ---";
                if (!this.dataGridViewTransactions.Columns.Contains("cbAccount"))
                {
                    dataGridViewTransactions.Columns.Add(colAccount);
                }

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PostingMuiltiEntryForm load", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnPostTransaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                rep.PostTransactions(observableTransactions.ToList());

                MessageBox.Show("Post Successful!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (this.Owner is TransactionsForm)
                {
                    TransactionsForm f = (TransactionsForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnAddTransaction_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            if (IsTransactionValid())
            {
                try
                {
                    //Build up transactions 
                    string RawSalt = Utils.create_random_salt();
                    //string HashSalt = HashHelper.CreateRandomSalt();
                    //int foundS1 = HashSalt.IndexOf("==");
                    //int foundS2 = HashSalt.IndexOf("+");
                    //int foundS3 = HashSalt.IndexOf("/");
                    //if (foundS1 > 0)
                    //{
                    //    HashSalt = HashSalt.Remove(foundS1);
                    //}
                    //if (foundS2 > 0)
                    //{
                    //    HashSalt = HashSalt.Remove(foundS2);
                    //}
                    //if (foundS3 > 0)
                    //{
                    //    HashSalt = HashSalt.Remove(foundS3);
                    //}
                    //string SaltedHash = RawSalt.Insert(RawSalt.Length, HashSalt);
                    string _transRef = RawSalt;
                    int no_of_characters_in_transaction_reference_no = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NO_OF_CHARACTERS_IN_TRANSACTION_REFERENCE_NO"]);
                    _transRef = _transRef.ToUpper().Substring(0, no_of_characters_in_transaction_reference_no);
                    receiptNo = _transRef;

                    Transaction t = new Transaction();
                    int accountid;
                    if (!string.IsNullOrEmpty(txtAccountID.Text) && int.TryParse(txtAccountID.Text, out accountid))
                    {
                        t.AccountId = int.Parse(txtAccountID.Text);
                    }
                    if (cboTransactionType.SelectedIndex != -1)
                    {
                        t.TransactionTypeId = int.Parse(cboTransactionType.SelectedValue.ToString());
                    }
                    decimal amount;
                    if (!string.IsNullOrEmpty(txtAmount.Text) && decimal.TryParse(txtAmount.Text, out amount))
                    {
                        t.Amount = decimal.Parse(txtAmount.Text);
                    }
                    t.PostDate = dpPostDate.Value;
                    t.RecordDate = dpPostDate.Value;
                    t.ValueDate = dpValueDate.Value;
                    t.TransRef = _transRef;
                    if (!string.IsNullOrEmpty(txtNarrative.Text))
                    {
                        t.Narrative = txtNarrative.Text;
                    }
                    if (!string.IsNullOrEmpty(user))
                    {
                        t.UserName = user;
                    }
                    var txn_type = rep.GetTransactionType(t.TransactionTypeId);
                    if (txn_type != null)
                    {
                        t.StatementFlag = txn_type.StatementFlag;
                    }
                    else
                    {
                        t.StatementFlag = "C";
                    }
                    t.Authorizer = "SYSTEM";

                    observableTransactions.Add(t);

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public bool IsTransactionValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtAccountID.Text))
            {
                errorProvider.SetError(txtAccountID, "Account id cannot be null!");
                noerror = false;
            }
            int accountid;
            if (!int.TryParse(txtAccountID.Text, out accountid))
            {
                errorProvider.SetError(txtAccountID, "Account id must be integer!");
                noerror = false;
            }
            if (cboTransactionType.SelectedIndex == -1)
            {
                errorProvider.SetError(cboTransactionType, "Select Transaction Type!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                errorProvider.SetError(txtAmount, "Amount cannot be null!");
                noerror = false;
            }
            decimal amt;
            if (!decimal.TryParse(txtAmount.Text, out amt))
            {
                errorProvider.SetError(txtAmount, "Amount must be decimal!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtNarrative.Text))
            {
                errorProvider.SetError(txtNarrative, "Narrative cannot be null!");
                noerror = false;
            }
            return noerror;

        }

        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count != 0)
            {
                try
                {
                    Transaction t = (Transaction)bindingSourceTransactions.Current;

                    observableTransactions.Remove(t);
                    RefreshGrid();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void RefreshGrid()
        {
            //set the datasource to null
            bindingSourceTransactions.DataSource = null;
            //set the datasource to a method
            bindingSourceTransactions.DataSource = observableTransactions;

        }

        private void btnSearchbyAccount_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountForm saf = new Forms.SearchAccountForm(connection) { Owner = this };
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
            txtAccountID_TextChanged(sender, e);
        }
        private void SetAccountNos(Account _Account)
        {
            if (_Account != null)
            {
                txtAccountID.Text = _Account.Id.ToString();
                _account = _Account;
            }

        }

        private void txtAccountID_TextChanged(object sender, EventArgs e)
        {
            if (_account != null)
            {
                lblaccountdetails.Text = "Name [ " + _account.AccountName + " ], No [ " + _account.AccountNo + " ] Book Balance [ " + _account.BookBalance + " ]";
            }
        }


    }
}
