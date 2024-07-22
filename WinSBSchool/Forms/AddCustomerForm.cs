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
    public partial class AddCustomerForm : Form
    {
        #region "Private Fields"
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        Student _Student; 
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        vwBankBranch _vwBankBranch;
        #endregion "Private Fields"

        #region "Constructor"
        public AddCustomerForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AddCustomerForm initialization", TAG));

        }
        public AddCustomerForm(Student _student, string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _Student = db.Students.Where(s => s.Id == _student.Id).First();

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AddCustomerForm initialization", TAG));

        }
        #endregion "Constructor"


        #region "Private Methods"

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
        private void AddNewCustomerForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblbankdetails.Text = string.Empty;

                string _CustomerNo = Utils.NextSeries(LastCycleId());
                txtCustomerNo.Text = _CustomerNo;
                txtCustomerNo.Enabled = true;

                InitializeControls();

                AutoCompleteStringCollection acsc_no = new AutoCompleteStringCollection();
                acsc_no.AddRange(this.AutoComplete_CustomerNo());
                txtCustomerNo.AutoCompleteCustomSource = acsc_no;
                txtCustomerNo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtCustomerNo.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsc_name = new AutoCompleteStringCollection();
                acsc_name.AddRange(this.AutoComplete_CustomerName());
                txtName.AutoCompleteCustomSource = acsc_name;
                txtName.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtName.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsc_address = new AutoCompleteStringCollection();
                acsc_address.AddRange(this.AutoComplete_CustomerAddress());
                txtAddress.AutoCompleteCustomSource = acsc_address;
                txtAddress.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAddress.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsc_phone = new AutoCompleteStringCollection();
                acsc_phone.AddRange(this.AutoComplete_CustomerPhone());
                txtPhone.AutoCompleteCustomSource = acsc_phone;
                txtPhone.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtPhone.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsc_email = new AutoCompleteStringCollection();
                acsc_email.AddRange(this.AutoComplete_CustomerEmail());
                txtEmail.AutoCompleteCustomSource = acsc_email;
                txtEmail.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtEmail.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsc_bankbranch = new AutoCompleteStringCollection();
                acsc_bankbranch.AddRange(this.AutoComplete_CustomerBankBranch());
                txtBankSortCode.AutoCompleteCustomSource = acsc_bankbranch;
                txtBankSortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtBankSortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_CustomerNo()
        {
            try
            {
                var _query = from cs in db.Customers
                             where cs.IsDeleted == false && cs.CustomerNo != null
                             select cs.CustomerNo;
                return _query.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_CustomerName()
        {
            try
            {
                var _query = from cs in db.Customers
                             where cs.IsDeleted == false && cs.CustomerName != null
                             select cs.CustomerName;
                return _query.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_CustomerAddress()
        {
            try
            {
                var _query = from cs in db.Customers
                             where cs.IsDeleted == false && cs.Address != null
                             select cs.Address;
                return _query.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_CustomerPhone()
        {
            try
            {
                var _query = from cs in db.Customers
                             where cs.IsDeleted == false && cs.Telephone != null
                             select cs.Telephone;
                return _query.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_CustomerEmail()
        {
            try
            {
                var _query = from cs in db.Customers
                             where cs.IsDeleted == false && cs.Email != null
                             select cs.Email;
                return _query.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_CustomerBankBranch()
        {
            try
            {
                var branchcodesquery = from bk in db.vwBankBranches
                                       select bk.BankSortCode;
                return branchcodesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        public string LastCycleId()
        {
            try
            {
                var cn = (from c in db.Customers
                          orderby c.Id descending
                          select c).FirstOrDefault();
                if (cn == null)
                    return "0";
                return cn.CustomerNo.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "0";
            }
        }
        public void InitializeControls()
        {
            if (_Student != null)
            {
                try
                {
                    if (_Student.StudentSurName != null && _Student.StudentOtherNames != null && _Student.AdminNo != null)
                    {
                        txtName.Text = _Student.AdminNo.Trim() + "  -  " + _Student.StudentOtherNames.Trim() + "  " + _Student.StudentSurName.Trim();
                    }
                    if (_Student.Phone != null)
                    {
                        txtPhone.Text = _Student.Phone.Trim();
                    }
                    if (_Student.Email != null)
                    {
                        txtEmail.Text = _Student.Email.Trim();
                    }
                    if (_Student.StudentAddress != null)
                    {
                        txtAddress.Text = _Student.StudentAddress.Trim();
                    }

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsCustomerValid())
            {
                try
                {
                    Customer customer = new Customer();
                    if (!string.IsNullOrEmpty(txtCustomerNo.Text))
                    {
                        customer.CustomerNo = txtCustomerNo.Text;
                    }
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        customer.CustomerName = Utils.ConvertFirstLetterToUpper(txtName.Text);
                        customer.BillToName = customer.CustomerName;
                    }
                    if (!string.IsNullOrEmpty(txtAddress.Text))
                    {
                        customer.Address = txtAddress.Text;
                        customer.BillToAddress = customer.Address;
                    }
                    if (!string.IsNullOrEmpty(txtPhone.Text))
                    {
                        customer.Telephone = txtPhone.Text;
                        customer.BillToTelephone = customer.Telephone;
                    }
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        customer.Email = txtEmail.Text;
                        customer.BillToEmail = customer.Email;
                    }
                    int banksortcode;
                    if (!string.IsNullOrEmpty(txtBankSortCode.Text) && int.TryParse(txtBankSortCode.Text, out banksortcode))
                    {
                        customer.Branch = int.Parse(txtBankSortCode.Text);
                    }
                    if (_Student != null)
                    {
                        customer.StudentId = _Student.Id;
                    }
                    customer.DateofCreation = DateTime.Now;
                    customer.Status = "A";
                    customer.IsDeleted = false;


                    if (db.Customers.Any(c => c.CustomerName == customer.CustomerName))
                    {
                        MessageBox.Show("Customer Name Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (db.Customers.Any(c => c.CustomerNo == customer.CustomerNo))
                    {
                        MessageBox.Show("Customer No Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (!db.Customers.Any(c => c.CustomerName == customer.CustomerName))
                    {
                        db.Customers.AddObject(customer);
                        db.SaveChanges();

                        if (_Student != null)
                        {
                            int cnt = db.Customers.Count(c => c.StudentId == _Student.Id);
                            if (cnt == 0) // recod does not exist
                            {
                                //to add the customer and retrive customer id
                                _Student.CustomerId = customer.Id;
                                db.SaveChanges();  // to save the updated _Student
                            }
                        }

                        if (this.Owner is EditStudentForm)
                        {
                            EditStudentForm f = (EditStudentForm)this.Owner;
                            MessageBox.Show("Customer Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            f.RefreshGrid();
                            this.Close();
                        }
                        else if (this.Owner is CustomersForm)
                        {
                            CustomersForm cf = (CustomersForm)this.Owner;
                            MessageBox.Show("Customer Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cf.RefreshGrid();
                            this.Close();
                        }
                        else if (this.Owner is SearchCustomersSimpleForm)
                        {
                            SearchCustomersSimpleForm cf = (SearchCustomersSimpleForm)this.Owner;
                            MessageBox.Show("Customer Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            cf.ApplyFilter();
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
        private bool IsCustomerValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtName, "Name Cannot be null!");
                return false;
            }
            return noerror;
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

        #endregion "Private Methods"

        private void txtCustomerNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtCustomerNo_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBankSortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
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


    }
}
