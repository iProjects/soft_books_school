using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DAL;
using CommonLib;
using System.Linq;
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class TransactionTypesListForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public TransactionTypesListForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished TransactionTypesListForm initialization", TAG));

        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.Write_To_Log_File_temp_dir(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }

        private void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            Log.Write_To_Log_File_temp_dir(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddTransactionTypeForm attf = new AddTransactionTypeForm(connection) { Owner = this };
            attf.ShowDialog();
        }


        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void TransactionTypesListForm_Load(object sender, EventArgs e)
        {
            try
            {

                var debitcredit = new BindingList<KeyValuePair<string, string>>();
                debitcredit.Add(new KeyValuePair<string, string>("D", "Debit"));
                debitcredit.Add(new KeyValuePair<string, string>("C", "Credit"));
                DataGridViewComboBoxColumn colCboxDebitCredit = new DataGridViewComboBoxColumn();
                colCboxDebitCredit.HeaderText = "Debit/Credit";
                colCboxDebitCredit.Name = "cbDebitCredit";
                colCboxDebitCredit.DataSource = debitcredit;
                // The display member is the name column in the column datasource  
                colCboxDebitCredit.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxDebitCredit.DataPropertyName = "DebitCredit";
                // The value member is the primary key of the parent table  
                colCboxDebitCredit.ValueMember = "Key";
                colCboxDebitCredit.MaxDropDownItems = 10;
                colCboxDebitCredit.Width = 100;
                colCboxDebitCredit.DisplayIndex = 8;
                colCboxDebitCredit.MinimumWidth = 5;
                colCboxDebitCredit.FlatStyle = FlatStyle.Flat;
                colCboxDebitCredit.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxDebitCredit.ReadOnly = true;
                //colCboxDebitCredit.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewTransactionTypes.Columns.Contains("cbDebitCredit"))
                {
                    dataGridViewTransactionTypes.Columns.Add(colCboxDebitCredit);
                }

                var _TxnTypeView = new BindingList<KeyValuePair<string, string>>();
                _TxnTypeView.Add(new KeyValuePair<string, string>("S", "Single Entry"));
                _TxnTypeView.Add(new KeyValuePair<string, string>("D", "Double Entry"));
                _TxnTypeView.Add(new KeyValuePair<string, string>("M", "Muilti Entry"));
                DataGridViewComboBoxColumn colCboxTxnTypeView = new DataGridViewComboBoxColumn();
                colCboxTxnTypeView.HeaderText = "Txn Type View";
                colCboxTxnTypeView.Name = "cbTxnTypeView";
                colCboxTxnTypeView.DataSource = _TxnTypeView;
                // The display member is the name column in the column datasource  
                colCboxTxnTypeView.DisplayMember = "Value";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxTxnTypeView.DataPropertyName = "TxnTypeView";
                // The value member is the primary key of the parent table  
                colCboxTxnTypeView.ValueMember = "Key";
                colCboxTxnTypeView.MaxDropDownItems = 10;
                colCboxTxnTypeView.Width = 100;
                colCboxTxnTypeView.DisplayIndex = 8;
                colCboxTxnTypeView.MinimumWidth = 5;
                colCboxTxnTypeView.FlatStyle = FlatStyle.Flat;
                colCboxTxnTypeView.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxTxnTypeView.ReadOnly = true;
                colCboxTxnTypeView.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewTransactionTypes.Columns.Contains("cbTxnTypeView"))
                {
                    dataGridViewTransactionTypes.Columns.Add(colCboxTxnTypeView);
                }

                dataGridViewTransactionTypes.AutoGenerateColumns = false;
                this.dataGridViewTransactionTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                bindingSourceTransactionTypes.DataSource = rep.GetAllTransactionTypes();
                dataGridViewTransactionTypes.DataSource = bindingSourceTransactionTypes;
                groupBox2.Text = bindingSourceTransactionTypes.Count.ToString();
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
                bindingSourceTransactionTypes.DataSource = null;
                //set the datasource to a method
                bindingSourceTransactionTypes.DataSource = rep.GetAllTransactionTypes();
                groupBox2.Text = bindingSourceTransactionTypes.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }


        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewTransactionTypes.SelectedRows.Count != 0)
                {
                    DAL.TransactionType txntype = (DAL.TransactionType)bindingSourceTransactionTypes.Current;
                    Forms.EditTransactionTypeForm ettf = new Forms.EditTransactionTypeForm(txntype, user, connection, _notificationmessageEventname) { Owner = this };
                    ettf.Text = txntype.Description.ToUpper().Trim();
                    ettf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }



        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewTransactionTypes.SelectedRows.Count != 0)
                {

                    DAL.TransactionType t = (DAL.TransactionType)bindingSourceTransactionTypes.Current;

                    //first check if there are any transactions associated with this transaction type.
                    var txns = from txn in db.Transactions
                               join txntype in db.TransactionTypes on txn.TransactionTypeId equals txntype.Id
                               where txntype.Id == t.Id
                               select txn;
                    var count = txns.ToList().Count();
                    if (count > 0)
                    {
                        Utils.ShowError(new Exception("There are [ " + count + " ] Transactions associated with this Transaction Type."));
                        return;
                    }

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete TransactionType\n" + t.Description.ToString().Trim().ToUpper(), "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteTransactionType(t);
                        RefreshGrid();

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
                if (dataGridViewTransactionTypes.SelectedRows.Count != 0)
                {
                    DAL.TransactionType txntype = (DAL.TransactionType)bindingSourceTransactionTypes.Current;
                    Forms.EditTransactionTypeForm ettf = new Forms.EditTransactionTypeForm(txntype, user, connection, _notificationmessageEventname) { Owner = this };
                    ettf.DisableControls();
                    ettf.Text = txntype.Description.ToUpper().Trim();
                    ettf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewTransactionTypes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewTransactionTypes.SelectedRows.Count != 0)
                {
                    DAL.TransactionType txntype = (DAL.TransactionType)bindingSourceTransactionTypes.Current;
                    Forms.EditTransactionTypeForm ettf = new Forms.EditTransactionTypeForm(txntype, user, connection, _notificationmessageEventname) { Owner = this };
                    ettf.Text = txntype.Description.ToUpper().Trim();
                    ettf.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void dataGridViewTransactionTypes_DataError(object sender, DataGridViewDataErrorEventArgs e)
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



    }
}



