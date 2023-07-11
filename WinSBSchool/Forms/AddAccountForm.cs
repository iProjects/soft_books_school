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


namespace WinSBSchool.Forms
{
    public partial class AddAccountForm : Form
    {

        Repository rep;
        int _CustomerId;
        SBSchoolDBEntities db; 
        Student _Student;
        string connection;
        int _Parent;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        #region "Constructor"
        public AddAccountForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

        }
        public AddAccountForm(int Parent, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (Parent == null)
                throw new ArgumentNullException("Parent");
            _Parent = Parent;
        }
        public AddAccountForm(int CustomerId, Student _s, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

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
        }
        #endregion "Constructor"
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void AddAccountForm_Load(object sender, EventArgs e)
        {
            try
            {
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
                cboCOA.SelectedIndex = -1;

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
                                     where bk.Closed==false
                                     where bk.IsDeleted==false
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
                                    where ac.IsDeleted ==false
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

                    if (db.Accounts.Any(c => c.AccountName == _Account.AccountName && c.AccountNo == _Account.AccountNo))
                    {
                        MessageBox.Show("Account Name " +  _Account.AccountName +  " with Number " + _Account.AccountNo + " Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            f.RefreshGrid();
                            this.Close();
                        }
                        if (this.Owner is COAForm)
                        {
                            COAForm f = (COAForm)this.Owner;
                            f.RefreshGrid();
                            this.Close();
                        }
                        else if (this.Owner is EditStudentForm)
                        {
                            EditStudentForm mf = (EditStudentForm)this.Owner;
                            mf.RefreshGrid();
                            MessageBox.Show("Account Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            mf.CloseForm(sender, e);
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
                errorProvider1.Clear();
                errorProvider1.SetError(txtCustomerID, "Owner cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtAccountName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAccountName, "Account Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtAccountNo.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAccountNo, "Account No cannot be null!");
                return false;
            }
            if (cboAccountTypes.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboAccountTypes, "Select Account Type!");
                return false;
            }
            if (cboCOA.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboCOA, "Select a Chart of Accounts!");
                return false;
            }
            return noerror;
        }
        private void btnSearchCustomerId_Click(object sender, EventArgs e)
        {
            try
            {
            SearchCustomersSimpleForm scf = new SearchCustomersSimpleForm(connection) { Owner = this };
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
        }
        private void SetAccountNos(Customer _customer)
        {
            if (_customer != null)
            {
                txtCustomerID.Text = _customer.Id.ToString();
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
        }
        private void SetBankSortCode(vwBankBranch _vwBankBranch)
        {
            if (_vwBankBranch != null)
            {
                txtBankSortCode.Text = _vwBankBranch.BankSortCode.Trim();
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

        
    }
}