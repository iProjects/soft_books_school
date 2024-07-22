using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Threading;


namespace WinSBSchool.Forms
{
    public partial class AddAccountForm : Form
    {

        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        int _CustomerId;
        Student _Student; 
        int _Parent;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        Customer _customer;
        vwBankBranch _vwBankBranch;

        #region "Constructor"
        public AddAccountForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AddAccountForm initialization", TAG));

        }
        public AddAccountForm(int Parent, string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            if (Parent == null)
                throw new ArgumentNullException("Parent");
            _Parent = Parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AddAccountForm initialization", TAG));

        }
        public AddAccountForm(int CustomerId, Student _s, string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            if (_s == null)
                throw new ArgumentNullException("Student");
            _Student = _s;

            int _stdFeesCOAId = int.Parse(rep.SettingLookup("STUDFEESCOAID"));
            var coaParentquery = (from coa in db.COAs
                                  where coa.Id == _stdFeesCOAId
                                  select coa).FirstOrDefault();
            COA _Coa = coaParentquery;

            int Parent = _Coa.Id;
            if (Parent == null)
                throw new ArgumentNullException("Parent");
            _Parent = Parent;

            int cstid;
            if (int.TryParse(CustomerId.ToString(), out cstid))
            {
                _CustomerId = CustomerId;
                this.txtCustomerID.Text = _CustomerId.ToString();
            }

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AddAccountForm initialization", TAG));

        }
        #endregion "Constructor"

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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void AddAccountForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblcustomerdetails.Text = string.Empty;
                lblbankdetails.Text = string.Empty;
                txtAccountNo.Enabled = true;

                var defaultschool = (from pc in db.Schools
                                     where pc.DefaultSchool == true
                                     orderby pc.SchoolName ascending
                                     select pc).FirstOrDefault();
                School scl = defaultschool;
                List<School> schools = rep.GetAllSchools();
                bindingSourceAccSchool.DataSource = schools;

                cboSchoolBranch.DataSource = bindingSourceAccSchool;
                cboSchoolBranch.ValueMember = "Id";
                cboSchoolBranch.DisplayMember = "SchoolName";
                cboSchoolBranch.SelectedValue = scl.Id;

                var passflags = new BindingList<KeyValuePair<string, string>>();
                passflags.Add(new KeyValuePair<string, string>("0", "Ok"));
                passflags.Add(new KeyValuePair<string, string>("1", "Debit posting prohibited"));
                passflags.Add(new KeyValuePair<string, string>("2", "Credit Posting prohibited"));
                passflags.Add(new KeyValuePair<string, string>("3", "All postings prohibited"));
                passflags.Add(new KeyValuePair<string, string>("4", "Cannot Overdraw"));

                cbopassflags.DataSource = passflags;
                cbopassflags.ValueMember = "Key";
                cbopassflags.DisplayMember = "Value";

                var accttyps = from pc in db.AccountTypes
                               select pc;
                bindingSourceAccountTypes.DataSource = accttyps.ToList();

                cboAccountTypes.DataSource = bindingSourceAccountTypes;
                cboAccountTypes.ValueMember = "Id";
                cboAccountTypes.DisplayMember = "Description";

                var COAsquery = from pc in db.COAs
                                orderby pc.ShortCode
                                select pc;
                List<COA> COAs = COAsquery.ToList();

                cboCOA.DataSource = COAs;
                cboCOA.ValueMember = "Id";
                cboCOA.DisplayMember = "Description";
                //cboCOA.SelectedIndex = -1;

                var COAquery = (from coa in db.COAs
                                where coa.Id == _Parent
                                select coa).FirstOrDefault();
                COA _Coa = COAquery;
                if (_Coa != null)
                {
                    cboCOA.SelectedValue = _Coa.Id;
                }

                string _AccountNo = Utils.NextSeries(NextAccountNo());
                txtAccountNo.Text = _AccountNo;

                if (_Student != null)
                {
                    SetUpForStudentAccount();
                }

                AutoCompleteStringCollection acsaccid = new AutoCompleteStringCollection();
                acsaccid.AddRange(this.AutoComplete_CustomerIds());
                txtCustomerID.AutoCompleteCustomSource = acsaccid;
                txtCustomerID.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtCustomerID.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscBnkSrtCd = new AutoCompleteStringCollection();
                acscBnkSrtCd.AddRange(this.AutoComplete_BankSortCodes());
                txtBankSortCode.AutoCompleteCustomSource = acscBnkSrtCd;
                txtBankSortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtBankSortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscnm = new AutoCompleteStringCollection();
                acscnm.AddRange(this.AutoComplete_AccountName());
                txtAccountName.AutoCompleteCustomSource = acscnm;
                txtAccountName.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountName.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscactn = new AutoCompleteStringCollection();
                acscactn.AddRange(this.AutoComplete_AccountNo());
                txtAccountNo.AutoCompleteCustomSource = acscactn;
                txtAccountNo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountNo.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                if (_CustomerId != null)
                {
                    var customer_query = (from ct in db.Customers
                                          where ct.Id.Equals(_CustomerId)
                                          select ct).FirstOrDefault();
                    Customer _customer = customer_query;
                    if (_customer != null)
                    {
                        txtBankSortCode.Text = _customer.Branch.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_AccountName()
        {
            try
            {
                var accountsquery = from bk in db.Accounts
                                    where bk.Closed == false
                                    where bk.IsDeleted == false
                                    select bk.AccountName;
                return accountsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_AccountNo()
        {
            try
            {
                var accountsquery = from bk in db.Accounts
                                    where bk.Closed == false
                                    where bk.IsDeleted == false
                                    select bk.AccountNo;
                return accountsquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_BankSortCodes()
        {
            try
            {
                var bankcodesquery = from bk in db.vwBankBranches
                                     select bk.BankSortCode;
                return bankcodesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_CustomerIds()
        {
            try
            {
                var custidsquery = (from ac in db.Accounts
                                    where ac.IsDeleted == false
                                    select ac.CustomerId).Distinct();
                int[] intarray = custidsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < custidsquery.Count(); i++)
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
        private void SetUpForStudentAccount()
        {
            if (_Student != null)
            {
                try
                {
                    txtAccountName.Text = _Student.AdminNo.Trim() + "  -  " + Utils.ConvertFirstLetterToUpper(_Student.StudentOtherNames) + "  " + Utils.ConvertFirstLetterToUpper(_Student.StudentSurName);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private string NextAccountNo()
        {
            try
            {
                var cn = (from c in db.Accounts
                          orderby c.Id descending
                          select c).FirstOrDefault();
                if (cn == null)
                    return "0";
                return cn.AccountNo.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "0";
            }
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            if (IsAccountValid())
            {
                try
                {
                    DAL.Account _Account = new DAL.Account();
                    if (!string.IsNullOrEmpty(txtCustomerID.Text))
                    {
                        _Account.CustomerId = int.Parse(txtCustomerID.Text.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtAccountName.Text))
                    {
                        _Account.AccountName = Utils.ConvertFirstLetterToUpper(txtAccountName.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtAccountNo.Text))
                    {
                        _Account.AccountNo = Utils.ConvertFirstLetterToUpper(txtAccountNo.Text);
                    }
                    if (cboAccountTypes.SelectedIndex != -1)
                    {
                        _Account.AccountTypeId = int.Parse(cboAccountTypes.SelectedValue.ToString());
                    }
                    if (_Parent != null)
                    {
                        _Account.COAId = _Parent;
                    }
                    if (cboCOA.SelectedIndex != -1)
                    {
                        _Account.COAId = int.Parse(cboCOA.SelectedValue.ToString());
                    }
                    int banksortcode;
                    if (!string.IsNullOrEmpty(txtBankSortCode.Text) && int.TryParse(txtBankSortCode.Text, out banksortcode))
                    {
                        _Account.BankBranch = int.Parse(txtBankSortCode.Text);
                    }
                    if (cboSchoolBranch.SelectedIndex != -1)
                    {
                        _Account.SchoolBranch = int.Parse(cboSchoolBranch.SelectedValue.ToString());
                    }
                    _Account.BookBalance = 0;
                    _Account.ClearedBalance = 0;
                    _Account.Limit = 0;
                    _Account.AccruedInt = 0;
                    _Account.AccruedInt = 0;
                    _Account.Bal30 = 0;
                    _Account.Bal60 = 0;
                    _Account.Bal90 = 0;
                    _Account.BalOver90 = 0;
                    _Account.IntRate30 = 0;
                    _Account.IntRate60 = 0;
                    _Account.IntRate90 = 0;
                    _Account.IntRateOver90 = 0;
                    _Account.PassFlag = "1";
                    _Account.Closed = false;
                    _Account.IsDeleted = false;

                    if (db.Accounts.Any(c => c.AccountName == _Account.AccountName))
                    {
                        MessageBox.Show("Account Name " + _Account.AccountName + " Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (db.Accounts.Any(c => c.AccountNo == _Account.AccountNo))
                    {
                        MessageBox.Show("Account Number " + _Account.AccountNo + " Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!db.Accounts.Any(c => c.AccountName == _Account.AccountName && c.AccountNo == _Account.AccountNo))
                    {
                        db.Accounts.AddObject(_Account);
                        db.SaveChanges();


                        if (_Student != null && _Student.GLAccountId == null)
                        {
                            _Student.GLAccountId = _Account.Id;
                            rep.UpdateStudentGLAccount(_Student);
                        }

                        if (this.Owner is AccountsForm)
                        {
                            AccountsForm f = (AccountsForm)this.Owner;
                            MessageBox.Show("Account Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            f.RefreshGrid();
                            this.Close();
                        }
                        if (this.Owner is COAForm)
                        {
                            COAForm f = (COAForm)this.Owner;
                            MessageBox.Show("Account Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            f.RefreshGrid();
                            this.Close();
                        }
                        else if (this.Owner is EditStudentForm)
                        {
                            EditStudentForm mf = (EditStudentForm)this.Owner;
                            MessageBox.Show("Account Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mf.RefreshGrid();
                            mf.CloseForm(sender, e);
                            this.Close();
                        }
                        else if (this.Owner is SearchAccountsSimpleForm)
                        {
                            SearchAccountsSimpleForm mf = (SearchAccountsSimpleForm)this.Owner;
                            MessageBox.Show("Account Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mf.ApplyFilter();
                            this.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public bool IsAccountValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                errorProvider.SetError(txtCustomerID, "Owner cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtAccountName.Text))
            {
                errorProvider.SetError(txtAccountName, "Account Name cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtAccountNo.Text))
            {
                errorProvider.SetError(txtAccountNo, "Account No cannot be null!");
                noerror = false;
            }
            if (cboAccountTypes.SelectedIndex == -1)
            {
                errorProvider.SetError(cboAccountTypes, "Select Account Type!");
                noerror = false;
            }
            if (cboCOA.SelectedIndex == -1)
            {
                errorProvider.SetError(cboCOA, "Select Chart of Accounts!");
                noerror = false;
            }
            return noerror;
        }
        private void btnSearchCustomerId_Click(object sender, EventArgs e)
        {
            try
            {
                SearchCustomersSimpleForm scf = new SearchCustomersSimpleForm(user, connection, _notificationmessageEventname) { Owner = this };
                scf.OnCustomerListSelected += new SearchCustomersSimpleForm.CustomerSelectHandler(scf_OnCustomerListSelected);
                scf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void scf_OnCustomerListSelected(object sender, CustomerSelectEventArgs e)
        {
            SetAccountNos(e._Customer);
            txtCustomerID_TextChanged(sender, e);
        }
        private void SetAccountNos(Customer customer)
        {
            if (customer != null)
            {
                txtCustomerID.Text = customer.Id.ToString();
                _customer = customer;
            }

        }
        private void btnSearchBankSortCode_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBanksSimpleForm saf = new Forms.SearchBanksSimpleForm(connection) { Owner = this };
                saf.OnBankListSelected += new SearchBanksSimpleForm.BankSelectHandler(saf_OnSetBankSortCodeListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnSetBankSortCodeListSelected(object sender, BankSelectEventArgs e)
        {
            SetBankSortCode(e._BankSortCode);
            txtBankSortCode_TextChanged(sender, e);
        }
        private void SetBankSortCode(vwBankBranch vwBankBranch)
        {
            if (vwBankBranch != null)
            {
                txtBankSortCode.Text = vwBankBranch.BankSortCode.Trim();
                _vwBankBranch = vwBankBranch;
            }

        }

        private void txtCustomerID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtCustomerID_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBankSortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtBankSortCode_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBankSortCode_TextChanged(object sender, EventArgs e)
        {
            if (_vwBankBranch != null)
            {
                lblbankdetails.Text = "Bank Name [ " + _vwBankBranch.BankName + " ], Branch Name [ " + _vwBankBranch.BranchName + " ]";
            }
            if (!string.IsNullOrEmpty(txtBankSortCode.Text))
            {
                string banksortcode = txtBankSortCode.Text;
                var query = from bsc in db.vwBankBranches
                            where bsc.BankSortCode.StartsWith(banksortcode)
                            select bsc;
                vwBankBranch bb = query.FirstOrDefault();
                if (bb != null)
                {
                    lblbankdetails.Text = "Bank Name [ " + bb.BankName + " ], Branch Name [ " + bb.BranchName + " ]";
                }
            }
        }

        private void txtCustomerID_TextChanged(object sender, EventArgs e)
        {
            if (_customer != null)
            {
                lblcustomerdetails.Text = "Name [ " + _customer.CustomerName + " ], No [ " + _customer.CustomerNo + " ]";
            }
            if (!string.IsNullOrEmpty(txtCustomerID.Text))
            {
                string CustomerID = txtCustomerID.Text;
                int cid = int.Parse(CustomerID);
                var query = from ct in db.Customers
                            where ct.Id.Equals(cid)
                            select ct;
                Customer cst = query.FirstOrDefault();
                if (cst != null)
                {
                    lblcustomerdetails.Text = "Name [ " + cst.CustomerName + " ], No [ " + cst.CustomerNo + " ]";
                }
            }
        }

        private void cboCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                COA _selected_coa = (COA)cboCOA.SelectedItem;
                var coa_query = from coa in db.COAs
                                where coa.Id == _selected_coa.Id
                                select coa;
                COA _Coa = coa_query.FirstOrDefault();
                if (_Coa != null)
                {
                    txtAccountName.Text = _Coa.Description;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }




    }
}