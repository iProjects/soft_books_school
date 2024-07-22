using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.ComponentModel;
using System.Collections.Generic;


namespace WinSBSchool.Forms
{
    public partial class TransactionsForm : Form
    {
        Repository rep;
        string user;
        string connection;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public TransactionsForm(string s, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished TransactionsForm initialization", TAG));

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

        private void TransactionsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _accounts = from acc in rep.GetAllAccounts()
                                where acc.IsDeleted == false
                                select acc;

                cboaccount.DataSource = _accounts;
                cboaccount.ValueMember = "Id";
                cboaccount.DisplayMember = "AccountName";
                cboaccount.SelectedIndex = -1;

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
                colCboxStatementFlag.DisplayIndex = 9;
                colCboxStatementFlag.MinimumWidth = 5;
                colCboxStatementFlag.FlatStyle = FlatStyle.Flat;
                colCboxStatementFlag.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStatementFlag.ReadOnly = true;
                if (!this.dataGridViewTransactions.Columns.Contains("cbStatementFlag"))
                {
                    dataGridViewTransactions.Columns.Add(colCboxStatementFlag);
                }

                dataGridViewTransactions.AutoGenerateColumns = false;
                dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewTransactions.DataSource = bindingSourceTransactions;

                RefreshGrid();

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished TransactionsForm load", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        public void RefreshGrid()
        {
            try
            {
                //set the datasource to null
                bindingSourceTransactions.DataSource = null;
                //set the datasource to a method
                bindingSourceTransactions.DataSource = rep.GetAllTransactions().OrderByDescending(i => i.Id).ToList();
                string count = bindingSourceTransactions.Count.ToString();
                groupBox2.Text = count;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded [ " + count + " ] Transactions...", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }

        private void btnSingleEntryPosting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.PostingSingleEntryForm asf = new Forms.PostingSingleEntryForm(user, connection, _notificationmessageEventname) { Owner = this };
            asf.ShowDialog();
        }

        private void btnDoubleEntryPosting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.PostingDoubleEntryForm asf = new Forms.PostingDoubleEntryForm(user, connection, _notificationmessageEventname) { Owner = this };
            asf.ShowDialog();
        }

        private void btnMuiltiEntryPosting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.PostingMuiltiEntryForm asf = new Forms.PostingMuiltiEntryForm(user, connection, _notificationmessageEventname) { Owner = this };
            asf.ShowDialog();
        }
         
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void dataGridViewTransactions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = false;
            }
            catch (Exception ex)
            {
                Log.Write_To_Log_File_temp_dir(ex);
            }
        }

        private void btnviewdetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.Transaction txn = (DAL.Transaction)bindingSourceTransactions.Current;
                    Reports.Views.Screen.ViewTransactionDetailsForm vtd = new Reports.Views.Screen.ViewTransactionDetailsForm(txn, user, connection, _notificationmessageEventname);
                    vtd.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void btnrefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshGrid();
        }

        private void dataGridViewTransactions_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewTransactions.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.Transaction txn = (DAL.Transaction)bindingSourceTransactions.Current;
                    Reports.Views.Screen.ViewTransactionDetailsForm vtd = new Reports.Views.Screen.ViewTransactionDetailsForm(txn, user, connection, _notificationmessageEventname);
                    vtd.ShowDialog();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }

        private void btnclearfilter_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void cboaccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txttransactionreference_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtppostdate_ValueChanged(object sender, EventArgs e)
        {

        }





    }
}
