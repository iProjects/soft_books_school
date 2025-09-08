using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;

namespace WinSBSchool.Forms
{
    public partial class TransactionsForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
<<<<<<< Updated upstream
        public TransactionsForm(string s, string  Conn)
=======
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        IQueryable<Transaction> _Transactions;
        DateTime post_date;

        public TransactionsForm(string s, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
>>>>>>> Stashed changes
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);
            user = s;
        }

        private void TransactionsForm_Load(object sender, EventArgs e)
        {
            try
            {
<<<<<<< Updated upstream
            dataGridViewTransactions.AutoGenerateColumns = false;
            dataGridViewTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bindingSourceTransactions.DataSource = rep.GetAllTransactions();
            dataGridViewTransactions.DataSource = bindingSourceTransactions;
=======
                var _accounts = from acc in rep.GetAllAccounts()
                                where acc.IsDeleted == false
                                select acc;
                _accounts = _accounts.ToList();

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
                _ttypes = _ttypes.ToList();

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

                _Transactions = db.Transactions.Where(i => i.IsDeleted == false).OrderByDescending(i => i.Id);

                RefreshGrid();

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished TransactionsForm load", TAG));

>>>>>>> Stashed changes
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

<<<<<<< Updated upstream
=======
        public void RefreshGrid()
        {
            try
            {
                //set the datasource to null
                bindingSourceTransactions.DataSource = null;
                //set the datasource to a method
                //bindingSourceTransactions.DataSource = rep.GetAllTransactions().OrderByDescending(i => i.Id).ToList();
                var filter = CreateFilter(_Transactions);
                // set the filter
                this.bindingSourceTransactions.DataSource = filter;
                string count = bindingSourceTransactions.Count.ToString();
                groupBox2.Text = count;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded [ " + count + " ] Transactions...", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }

>>>>>>> Stashed changes
        private void btnSingleEntryPosting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.PostingSingleEntryForm asf = new Forms.PostingSingleEntryForm(user, connection) { Owner = this };
            asf.ShowDialog();
        }

        private void btnDoubleEntryPosting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.PostingDoubleEntryForm asf = new Forms.PostingDoubleEntryForm(user, connection) { Owner = this };
            asf.ShowDialog();
        }

        private void btnMuiltiEntryPosting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Forms.PostingMuiltiEntryForm asf = new Forms.PostingMuiltiEntryForm(user, connection) { Owner = this };
            asf.ShowDialog();
        }

<<<<<<< Updated upstream

        public void RefreshGrid()
        {
            try
            {
            //set the datasource to null
            bindingSourceTransactions.DataSource = null;
            //set the datasource to a method
            bindingSourceTransactions.DataSource = rep.GetAllTransactions();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
=======
>>>>>>> Stashed changes
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
<<<<<<< Updated upstream
=======

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
            cboaccount.SelectedIndex = -1;
            txttransactionreference.Text = string.Empty;
            dtppostdate.Value = DateTime.Now;
            ApplyFilter();
        }

        private void cboaccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboaccount.SelectedIndex != -1)
            {
                ApplyFilter();
            }
        }

        private void dtppostdate_ValueChanged(object sender, EventArgs e)
        {
            if (dtppostdate.Value != null)
            {
                post_date = dtppostdate.Value;
                ApplyFilter();
            }
        }
        private void txttransactionreference_TextChanged(object sender, EventArgs e)
        {
            if (txttransactionreference.Text != string.Empty)
            {
                ApplyFilter();
            }
        }

        private void txttransactionreference_Validated(object sender, EventArgs e)
        {
            ApplyFilter();
        }
        private void txttransactionreference_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ApplyFilter();
                e.Handled = true;
            }
        }
        // apply the filter
        public void ApplyFilter()
        {
            try
            {
                //set the datasource to null
                bindingSourceTransactions.DataSource = null;
                //set the datasource to a method
                //bindingSourceTransactions.DataSource = rep.GetAllTransactions().OrderByDescending(i => i.Id).ToList();
                var filter = CreateFilter(_Transactions);
                // set the filter
                this.bindingSourceTransactions.DataSource = filter;
                string count = bindingSourceTransactions.Count.ToString();
                groupBox2.Text = count;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("loaded [ " + count + " ] Transactions...", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private IQueryable<Transaction> CreateFilter(IQueryable<Transaction> _transactions)
        { 
            //none
            if (cboaccount.SelectedIndex == -1 && string.IsNullOrEmpty(txttransactionreference.Text) && post_date == null)
            {
                return _transactions;
            }
            //all
            if (cboaccount.SelectedIndex != -1 && !string.IsNullOrEmpty(txttransactionreference.Text) && post_date != null)
            {
                Account _Acc = (Account)cboaccount.SelectedItem;
                string _transactionreference = txttransactionreference.Text;
                DateTime _postdate = (DateTime)post_date;
                _transactions = from ts in db.Transactions
                                join ac in db.Accounts on ts.AccountId equals ac.Id
                                where ac.Id == _Acc.Id
                                where ts.TransRef.Contains(_transactionreference)
                                where ts.PostDate == _postdate
                                where ts.IsDeleted == false
                                select ts;
                return _transactions;
            }
            //account
            if (cboaccount.SelectedIndex != -1 && string.IsNullOrEmpty(txttransactionreference.Text) && post_date == null)
            { 
                Account _Acc = (Account)cboaccount.SelectedItem; 
                _transactions = from ts in db.Transactions
                                join ac in db.Accounts on ts.AccountId equals ac.Id
                                where ac.Id == _Acc.Id 
                                where ts.IsDeleted == false
                                select ts;
                return _transactions;
            }
            //transactionreference
            if (cboaccount.SelectedIndex == -1 && !string.IsNullOrEmpty(txttransactionreference.Text) && post_date == null)
            { 
                string _transactionreference = txttransactionreference.Text; 
                _transactions = from ts in db.Transactions 
                                where ts.TransRef.Contains(_transactionreference) 
                                where ts.IsDeleted == false
                                select ts;
                return _transactions;
            }
            //postdate
            if (cboaccount.SelectedIndex == -1 && !string.IsNullOrEmpty(txttransactionreference.Text) && post_date != null)
            { 
                DateTime _postdate = (DateTime)post_date;
                _transactions = from ts in db.Transactions  
                                where ts.PostDate == _postdate
                                where ts.IsDeleted == false
                                select ts;
                return _transactions;
            }
            //account and transactionreference
            if (cboaccount.SelectedIndex != -1 && !string.IsNullOrEmpty(txttransactionreference.Text) && post_date == null)
            { 
                Account _Acc = (Account)cboaccount.SelectedItem;
                string _transactionreference = txttransactionreference.Text; 
                _transactions = from ts in db.Transactions
                                join ac in db.Accounts on ts.AccountId equals ac.Id
                                where ac.Id == _Acc.Id
                                where ts.TransRef.Contains(_transactionreference) 
                                where ts.IsDeleted == false
                                select ts;
                return _transactions;
            }
            //account and postdate
            if (cboaccount.SelectedIndex != -1 && string.IsNullOrEmpty(txttransactionreference.Text) && post_date != null)
            { 
                Account _Acc = (Account)cboaccount.SelectedItem; 
                DateTime _postdate = (DateTime)post_date;
                _transactions = from ts in db.Transactions
                                join ac in db.Accounts on ts.AccountId equals ac.Id
                                where ac.Id == _Acc.Id 
                                where ts.PostDate == _postdate
                                where ts.IsDeleted == false
                                select ts;
                return _transactions;
            }
            //transactionreference and postdate
            if (cboaccount.SelectedIndex == -1 && !string.IsNullOrEmpty(txttransactionreference.Text) && post_date != null)
            { 
                string _transactionreference = txttransactionreference.Text;
                DateTime _postdate = (DateTime)post_date;
                _transactions = from ts in db.Transactions 
                                where ts.TransRef.Contains(_transactionreference)
                                where ts.PostDate == _postdate
                                where ts.IsDeleted == false
                                select ts;
                return _transactions;
            }
            return _transactions;
        }




>>>>>>> Stashed changes
    }
}
