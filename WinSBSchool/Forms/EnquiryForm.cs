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
    public partial class EnquiryForm : Form
    {
        Repository rep;
        Account _Account;
        BindingList<Transaction> observableTransactions;
        string connection;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        string user;

        public EnquiryForm(string s, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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
            user = s;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished EnquiryForm initialization", TAG));

        }
        public EnquiryForm(string s, string Conn, Account acc, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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
            user = s;

            if (acc == null)
                throw new ArgumentNullException("Account");
            _Account = acc;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished EnquiryForm initialization", TAG));

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

        private void EnquiryForm_Load(object sender, EventArgs e)
        {
            try
            {
                observableTransactions = new BindingList<Transaction>();

                bindingSourceTransactions.DataSource = observableTransactions;
                dataGridViewTransactions.AutoGenerateColumns = false;
                dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewTransactions.DataSource = bindingSourceTransactions;

                List<Student> students = rep.GetAllStudents();
                this.cboAdmissionNumber.DataSource = students;
                this.cboAdmissionNumber.DisplayMember = "AdminNo";
                this.cboAdmissionNumber.ValueMember = "Id";
                this.cboAdmissionNumber.SelectedIndex = -1;
                //Autocomplete for cboAdmissionNumber
                string[] strstudents = students.Select(san => san.AdminNo).ToArray();
                AutoCompleteStringCollection sanacsc = new AutoCompleteStringCollection();
                sanacsc.AddRange(strstudents);
                this.cboAdmissionNumber.AutoCompleteCustomSource = sanacsc;

                List<Account> accounts = rep.GetAllAccounts();
                this.cboAccountNumber.DataSource = accounts;
                this.cboAccountNumber.DisplayMember = "AccountNo";
                this.cboAccountNumber.ValueMember = "AccountID";
                this.cboAccountNumber.SelectedIndex = -1;
                //Autocomplete for cboAccountNumber
                string[] straccounts = accounts.Select(acn => acn.AccountNo.ToString()).ToArray();
                AutoCompleteStringCollection anacsc = new AutoCompleteStringCollection();
                anacsc.AddRange(straccounts);
                this.cboAccountNumber.AutoCompleteCustomSource = anacsc;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished EnquiryForm load", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }

        private void btnSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                //bindingSourceTransactions.DataSource = null;
                DateTime startdate = dateTimePickerStartDate.Value;
                DateTime enddate = dateTimePickerEndDate.Value;
                int account;
                //= Convert.ToInt32(txtAccountNo.Text)
                if (int.TryParse(Convert.ToString(cboAccountNumber.SelectedValue), out account))
                {
                    //dataGridView1.DataSource = rep.GetTransactions(account, startdate, enddate);  
                    List<Transaction> transactions = rep.GetTransactions(account, startdate, enddate);
                    bindingSourceTransactions.DataSource = transactions;
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
                SearchAccountForm saf = new SearchAccountForm(connection);
                saf.ShowDialog();
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






    }
}