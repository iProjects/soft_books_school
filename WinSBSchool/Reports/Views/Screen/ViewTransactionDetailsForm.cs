using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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

namespace WinSBSchool.Reports.Views.Screen
{
    public partial class ViewTransactionDetailsForm : Form
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
        DAL.Transaction txn;

        public ViewTransactionDetailsForm(DAL.Transaction _txn, string _user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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
            txn = _txn;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished ViewTransactionDetailsForm initialization", TAG));

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

        private void ViewTransactionDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _TransactionTypesquery = from ttype in rep.GetAllTransactionTypes()
                                             select ttype;
                List<TransactionType> transactiontypes = _TransactionTypesquery.ToList();

                cboTransactionType.DataSource = transactiontypes;
                cboTransactionType.ValueMember = "Id";
                cboTransactionType.DisplayMember = "Description";

                var _Accountsquery = from acc in db.Accounts
                                     select acc;
                List<Account> _Accounts = _Accountsquery.ToList();

                cboAccount.DataSource = _Accounts;
                cboAccount.ValueMember = "Id";
                cboAccount.DisplayMember = "AccountName";

                var statementflag = new BindingList<KeyValuePair<string, string>>();
                statementflag.Add(new KeyValuePair<string, string>("C", "Credit"));
                statementflag.Add(new KeyValuePair<string, string>("D", "Debit"));
                cboStatementFlag.DataSource = statementflag;
                cboStatementFlag.ValueMember = "Key";
                cboStatementFlag.DisplayMember = "Value"; 
                
                initialize_controls();

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished ViewTransactionDetailsForm load", TAG));
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void initialize_controls()
        {
            try
            {
                txtId.Text = txn.Id.ToString();
                cboTransactionType.SelectedValue = txn.TransactionTypeId;
                cboAccount.SelectedValue = txn.AccountId;
                var account = rep.GetAccount(txn.AccountId);
                lblAccountDetails.Text = "No [" + account.AccountNo + " ], Balance [ " + account.BookBalance + " ]";
                txtAmount.Text = txn.Amount.ToString();
                dtpPostDate.Value = txn.PostDate;
                dtpRecordDate.Value = txn.RecordDate;
                dtpValueDate.Value = txn.ValueDate ?? DateTime.Today;
                txtNarrative.Text = txn.Narrative;
                cboStatementFlag.SelectedValue = txn.StatementFlag;
                txtUserName.Text = txn.UserName;
                txtTransRef.Text = txn.TransRef;
                var txn_type = rep.GetTransactionType(txn.TransactionTypeId);
                this.Text = "Type [ " + txn_type.Description + " ], Account [ " + account.AccountName + " ]";
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

        private void btnPrevious_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var curr_txn = txn;
            var curr_txn_id = curr_txn.Id;
            int previous_id = curr_txn_id - 1;
            var previous_txn = rep.GetTransaction(previous_id);
            if (previous_txn != null)
            {
                txn = previous_txn;
                initialize_controls();
            }
            else
            {

            }
        }

        private void btnNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var curr_txn = txn;
            var curr_txn_id = curr_txn.Id;
            int next_id = curr_txn_id + 1;
            var next_txn = rep.GetTransaction(next_id);
            if (next_txn != null)
            {
                txn = next_txn;
                initialize_controls();
            }
            else
            {

            }
        }





    }
}
