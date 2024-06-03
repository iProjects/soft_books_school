using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using CommonLib;
using DAL;
using WinSBSchool.Post;
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class PostScreen : Form
    {
        // Create constants to use in the form.
        private const int controlWidth = 300;
        private const int charPerLine = 30;
        private const int lineHeight = 19;
        // Create class variables to use during the form.
        private const int controlCount = 0;
        private Point controlLocation = new Point(10, 50);
        SBSchoolDBEntities db;
        private UserModel LoggedInUser;
        private string user;
        string connection;
        TransactionType ttype;
        IQueryable<TransactionType> AuthorizedTransactions;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public PostScreen(UserModel User, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            if (User == null)
                throw new ArgumentNullException("User");
            LoggedInUser = User;

            user = LoggedInUser.UserName;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PostScreen initialization", TAG));

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

        private void PostScreen_Load(object sender, EventArgs e)
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
                colCboxDebitCredit.DisplayIndex = 3;
                colCboxDebitCredit.MinimumWidth = 5;
                colCboxDebitCredit.FlatStyle = FlatStyle.Flat;
                colCboxDebitCredit.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxDebitCredit.ReadOnly = true;
                //colCboxDebitCredit.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewTransactionTypes.Columns.Contains("cbDebitCredit"))
                {
                    dataGridViewTransactionTypes.Columns.Add(colCboxDebitCredit);
                }

                var _TxnTypeViews = new BindingList<KeyValuePair<string, string>>();
                _TxnTypeViews.Add(new KeyValuePair<string, string>("S", "Single Entry"));
                _TxnTypeViews.Add(new KeyValuePair<string, string>("D", "Double Entry"));
                _TxnTypeViews.Add(new KeyValuePair<string, string>("M", "Muilti Entry"));
                DataGridViewComboBoxColumn colTxnTypeView = new DataGridViewComboBoxColumn();
                colTxnTypeView.HeaderText = "View_Type";
                colTxnTypeView.Name = "cbTxnTypeView";
                colTxnTypeView.DataSource = _TxnTypeViews;
                colTxnTypeView.DisplayMember = "Value";
                colTxnTypeView.DataPropertyName = "TxnTypeView";
                colTxnTypeView.ValueMember = "Key";
                colTxnTypeView.MaxDropDownItems = 10;
                colTxnTypeView.DisplayIndex = 2;
                colTxnTypeView.MinimumWidth = 5;
                colTxnTypeView.Width = 100;
                colTxnTypeView.FlatStyle = FlatStyle.Flat;
                colTxnTypeView.DefaultCellStyle.NullValue = "--- Select ---";
                colTxnTypeView.ReadOnly = true;
                colTxnTypeView.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewTransactionTypes.Columns.Contains("cbTxnTypeView"))
                {
                    dataGridViewTransactionTypes.Columns.Add(colTxnTypeView);
                }


                dataGridViewTransactionTypes.AutoGenerateColumns = false;
                this.dataGridViewTransactionTypes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                RefreshGrid();

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PostScreen load", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_TxnType()
        {
            try
            {
                var tt = AuthorizedTransactions.Select(i => i.Description);
                return tt.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void RefreshGrid()
        {
            try
            {
                //retrieve transaction types according to _User authorization
                //i.e. from crtxn in db.tt where _User.TransactionAuthorizations.Contains(crtxn.uthorizationcode) 
                AuthorizedTransactions = from t in db.TransactionTypes
                                         join ta in db.TransactionsAuthorizations
                                         on t.Id equals ta.TransactionTypeId
                                         where ta.UserRoleId == LoggedInUser.RoleId
                                         select t;

                bindingSourceTransactionTypes.DataSource = AuthorizedTransactions;
                dataGridViewTransactionTypes.DataSource = bindingSourceTransactionTypes;
                groupBox2.Text = bindingSourceTransactionTypes.Count.ToString();

                if (bindingSourceTransactionTypes.Count < 1)
                {
                    groupBox2.Text = "Kindly Authorize Transaction Types for this user.";
                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile_and_EventViewer(ex);
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
            }
        }
        private void btnRetrieve_Click(object sender, EventArgs e)
        {
            try
            {
                //Get the transaction type selected
                if (dataGridViewTransactionTypes.SelectedRows.Count != 0)
                {
                    ttype = (TransactionType)bindingSourceTransactionTypes.Current;

                    if (ttype == null)
                        throw new ArgumentNullException("Transaction Type");

                    //show the screen according to the transaction type

                    if (ttype.TxnTypeView == "S") //single entry post
                    {
                        Control usercontrol = new UserControlSinglePost(ttype, user, connection, _notificationmessageEventname);//_User control for single posting
                        usercontrol.Dock = DockStyle.Fill;
                        panelControls.Controls.Clear();
                        panelControls.Controls.Add(usercontrol);
                    }
                    else if (ttype.TxnTypeView == "D")//Double entry post
                    {
                        Control usercontrol = new UserControlDoublePost(ttype, user, connection, _notificationmessageEventname);//_User control for double posting
                        usercontrol.Dock = DockStyle.Fill;
                        panelControls.Controls.Clear();
                        panelControls.Controls.Add(usercontrol);
                    }
                    else if (ttype.TxnTypeView == "M")//Multi entry post
                    {
                        Control usercontrol = new UserControlMultiPost(ttype, user, connection, _notificationmessageEventname);//_User control for multiple posting
                        usercontrol.Dock = DockStyle.Fill;
                        panelControls.Controls.Clear();
                        panelControls.Controls.Add(usercontrol);
                    }
                    else
                    {
                        throw new Exception("Transaction view unknown " + ttype.TxnTypeView);
                    }
                }
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
        private void dataGridViewTransactionTypes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnRetrieve_Click(sender, null);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnrefresh_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dataGridViewTransactionTypes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Log.WriteToErrorLogFile_and_EventViewer(ex);
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
            }
        }


    }
}
