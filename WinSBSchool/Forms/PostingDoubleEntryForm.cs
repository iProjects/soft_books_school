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
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class PostingDoubleEntryForm : Form
    {
        //create an observable collection
        List<Transaction> observableTransactions;
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        string receiptNo;
        Account _draccount;
        Account _craccount;

        public PostingDoubleEntryForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            observableTransactions = new List<Transaction>();

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PostingDoubleEntryForm initialization", TAG));

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
        private void PostingDoubleEntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblcreditaccountdetails.Text = string.Empty;
                lbldebitaccountdetails.Text = string.Empty;

                var _TransactionTypesquery = from ttype in rep.GetAllTransactionTypes()
                                             where ttype.IsDeleted == false
                                             select ttype;
                List<TransactionType> transactiontypes = _TransactionTypesquery.ToList();

                cboTransactionType.DataSource = transactiontypes;
                cboTransactionType.ValueMember = "Id";
                cboTransactionType.DisplayMember = "Description";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PostingDoubleEntryForm load", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnPost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                errorProvider.Clear();

                if (IsTransactionValid())
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

                    //Credit transaction
                    Transaction ct = new Transaction();
                    if (cboTransactionType.SelectedIndex != -1)
                    {
                        ct.TransactionTypeId = int.Parse(cboTransactionType.SelectedValue.ToString());
                    }
                    int Caccountid;
                    if (!string.IsNullOrEmpty(txtCAccountId.Text) && int.TryParse(txtCAccountId.Text, out Caccountid))
                    {
                        ct.Id = int.Parse(txtCAccountId.Text);
                    }
                    decimal _amount;
                    if (!string.IsNullOrEmpty(txtAmount.Text) && decimal.TryParse(txtAmount.Text, out _amount))
                    {
                        ct.Amount = decimal.Parse(txtAmount.Text);
                    }
                    ct.PostDate = dpPostDate.Value;
                    ct.RecordDate = dpPostDate.Value;
                    ct.ValueDate = dpValueDate.Value;
                    if (!string.IsNullOrEmpty(txtCrNarrative.Text))
                    {
                        ct.Narrative = txtCrNarrative.Text;
                    }
                    if (!string.IsNullOrEmpty(user))
                    {
                        ct.UserName = user;
                    }
                    ct.Authorizer = "SYSTEM";
                    ct.StatementFlag = "C";
                    ct.TransRef = _transRef;

                    observableTransactions.Add(ct);

                    //Debit transaction
                    Transaction dt = new Transaction();
                    if (cboTransactionType.SelectedIndex != -1)
                    {
                        dt.TransactionTypeId = int.Parse(cboTransactionType.SelectedValue.ToString());
                    }
                    int Daccountid;
                    if (!string.IsNullOrEmpty(txtDAccountId.Text) && int.TryParse(txtCAccountId.Text, out Daccountid))
                    {
                        dt.AccountId = int.Parse(txtDAccountId.Text);
                    }
                    decimal amount;
                    if (!string.IsNullOrEmpty(txtAmount.Text) && decimal.TryParse(txtAmount.Text, out amount))
                    {
                        dt.Amount = decimal.Parse(txtAmount.Text) * -1;
                    }
                    dt.PostDate = dpPostDate.Value;
                    dt.RecordDate = dpPostDate.Value;
                    dt.ValueDate = dpValueDate.Value;
                    if (!string.IsNullOrEmpty(txtDrNarrative.Text))
                    {
                        dt.Narrative = txtDrNarrative.Text;
                    }
                    if (!string.IsNullOrEmpty(user))
                    {
                        dt.UserName = user;
                    }
                    dt.Authorizer = "SYSTEM";
                    dt.StatementFlag = "D";
                    dt.TransRef = _transRef;

                    observableTransactions.Add(dt);

                    rep.PostTransactions(observableTransactions.ToList());

                    MessageBox.Show("Post Successfull!", "SB School");

                    if (this.Owner is TransactionsForm)
                    {
                        TransactionsForm f = (TransactionsForm)this.Owner;
                        f.RefreshGrid();
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public bool IsTransactionValid()
        {
            bool noerror = true;

            if (cboTransactionType.SelectedIndex == -1)
            {
                errorProvider.SetError(cboTransactionType, "Select Transaction Type!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtCAccountId.Text))
            {
                errorProvider.SetError(txtCAccountId, "Credit Account id cannot be null!");
                noerror = false;
            }
            int Caccountid;
            if (!int.TryParse(txtCAccountId.Text, out Caccountid))
            {
                errorProvider.SetError(txtCAccountId, "Credit Account id must be integer!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtDAccountId.Text))
            {
                errorProvider.SetError(txtDAccountId, "Debit Account id cannot be null!");
                noerror = false;
            }
            int Daccountid;
            if (!int.TryParse(txtDAccountId.Text, out Daccountid))
            {
                errorProvider.SetError(txtDAccountId, "Debit Account id must be integer!");
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
            if (string.IsNullOrEmpty(txtDrNarrative.Text))
            {
                errorProvider.SetError(txtDrNarrative, "Debit Narrative cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtCrNarrative.Text))
            {
                errorProvider.SetError(txtCrNarrative, "Credit Narrative cannot be null!");
                noerror = false;
            }
            return noerror;

        }
        private void btnSearchCAccount_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountForm saf = new Forms.SearchAccountForm(connection) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountForm.AccountSelectHandler(saf_OnCAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnCAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetCAccountNos(e._Account);
            txtCAccountId_TextChanged(sender, e);
        }
        private void SetCAccountNos(Account _Account)
        {
            if (_Account != null)
            {
                txtCAccountId.Text = _Account.Id.ToString();
                _craccount = _Account;
            }

        }

        private void btnSearchbyDAccount_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountForm saf = new Forms.SearchAccountForm(connection) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountForm.AccountSelectHandler(saf_OnDAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnDAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetDAccountNos(e._Account);
            txtDAccountId_TextChanged(sender, e);
        }
        private void SetDAccountNos(Account _Account)
        {
            if (_Account != null)
            {
                txtDAccountId.Text = _Account.Id.ToString();
                _draccount = _Account;
            }
        }

        private void txtCAccountId_TextChanged(object sender, EventArgs e)
        {
            if (_craccount != null)
            {
                lblcreditaccountdetails.Text = "Name [ " + _craccount.AccountName + " ], No [ " + _craccount.AccountNo + " ] Book Balance [ " + _craccount.BookBalance + " ]";
            }
        }

        private void txtDAccountId_TextChanged(object sender, EventArgs e)
        {
            if (_draccount != null)
            {
                lbldebitaccountdetails.Text = "Name [ " + _draccount.AccountName + " ], No [ " + _draccount.AccountNo + " ] Book Balance [ " + _draccount.BookBalance + " ]";
            }
        }




    }
}
