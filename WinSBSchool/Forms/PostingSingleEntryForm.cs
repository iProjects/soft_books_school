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
    public partial class PostingSingleEntryForm : Form
    {
        Repository rep;
        string user;
        string connection;
        SBSchoolDBEntities db;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        string receiptNo;
        Account _account;

        public PostingSingleEntryForm(string s, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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
            user = s;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PostingSingleEntryForm initialization", TAG));

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
        private void PostingSingleEntryForm_Load(object sender, EventArgs e)
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

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PostingSingleEntryForm load", TAG));

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

                    Transaction t = new Transaction();
                    if (cboTransactionType.SelectedIndex != -1)
                    {
                        t.TransactionTypeId = int.Parse(cboTransactionType.SelectedValue.ToString());
                    }
                    int accountid;
                    if (!string.IsNullOrEmpty(txtAccountId.Text) && int.TryParse(txtAccountId.Text, out  accountid))
                    {
                        t.AccountId = int.Parse(txtAccountId.Text);
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

                    rep.SaveTransaction(t);

                    MessageBox.Show("Post Successfull!");

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
            if (string.IsNullOrEmpty(txtAccountId.Text))
            {
                errorProvider.SetError(txtAccountId, "Account Id cannot be null!");
                noerror = false;
            }
            int accountid;
            if (!int.TryParse(txtAccountId.Text, out accountid))
            {
                errorProvider.SetError(txtAccountId, "Account id must be integer!");
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
            txtAccountId_TextChanged(sender, e);
        }
        private void SetAccountNos(Account _Account)
        {
            if (_Account != null)
            {
                txtAccountId.Text = _Account.Id.ToString();
                _account = _Account;
            }

        }

        private void txtAccountId_TextChanged(object sender, EventArgs e)
        {
            if (_account != null)
            {
                lblaccountdetails.Text = "Name [ " + _account.AccountName + " ], No [ " + _account.AccountNo + " ] Book Balance [ " + _account.BookBalance + " ]";
            }
        }


    }
}
