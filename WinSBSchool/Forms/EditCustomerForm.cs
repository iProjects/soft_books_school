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

namespace WinSBSchool.Forms
{
    public partial class EditCustomerForm : Form
    {
        SBSchoolDBEntities db;
        Customer customer;
        string connection;
        Student student;
        Repository rep;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditCustomerForm(Customer _customer, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (_customer == null)
                throw new ArgumentNullException("_customer");
            customer = _customer;
        }
        public EditCustomerForm(Student _student, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (_student == null)
                throw new ArgumentNullException("_student");

            student = db.Students.Where(s => s.Id == _student.Id && s.IsDeleted ==false).First();
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsCustomerValid())
            {
                try
                {
                    if (!string.IsNullOrEmpty(txtName.Text.ToString()))
                    {
                        customer.CustomerName = Utils.ConvertFirstLetterToUpper(txtName.Text.ToString());
                    }
                    if (!string.IsNullOrEmpty(txtCustomerNo.Text))
                    {
                        customer.CustomerNo = txtCustomerNo.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtAddress.Text.ToString()))
                    {
                        customer.Address = Utils.ConvertFirstLetterToUpper(txtAddress.Text);
                    }
                    if (!string.IsNullOrEmpty(txtPhone.Text.ToString()))
                    {
                        customer.Telephone = txtPhone.Text;
                    }
                    if (!string.IsNullOrEmpty(txtEmail.Text.ToString()))
                    {
                        customer.Email = txtEmail.Text.ToLower();
                    }
                    int banksortcode;
                    if (!string.IsNullOrEmpty(txtBankSortCode.Text) && int.TryParse(txtBankSortCode.Text, out banksortcode))
                    {
                        customer.Branch = int.Parse(txtBankSortCode.Text);
                    }
                    if (!string.IsNullOrEmpty(txtBillToName.Text.ToString()))
                    {
                        customer.BillToName = Utils.ConvertFirstLetterToUpper(txtBillToName.Text);
                    }
                    if (!string.IsNullOrEmpty(txtBilllToAddress.Text.ToString()))
                    {
                        customer.BillToAddress = Utils.ConvertFirstLetterToUpper(txtBilllToAddress.Text);
                    }
                    if (!string.IsNullOrEmpty(txtBillToTelephone.Text.ToString()))
                    {
                        customer.BillToTelephone = txtBillToTelephone.Text;
                    }
                    if (!string.IsNullOrEmpty(txtBillToEmail.Text.ToString()))
                    {
                        customer.BillToEmail = txtBillToEmail.Text.ToLower();
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        customer.Status = cboStatus.SelectedValue.ToString();
                    }
                     
                    rep.UpdateCustomer(customer);

                    if (student != null)
                    {
                        customer.StudentId = student.Id;

                        int cnt = db.Customers.Count(c => c.StudentId == student.Id);

                        if (cnt == 0) // record does not exist
                        {

                            //add the customer and retrive customer id
                            student.CustomerId = customer.Id;
                            db.SaveChanges();  //save the updated Student
                        }
                    }
                    if (this.Owner is EditStudentForm)
                    {
                        EditStudentForm f = (EditStudentForm)this.Owner;
                        f.RefreshGrid();
                        this.Close();
                    }
                    else if (this.Owner is CustomersForm)
                    {
                        CustomersForm cf = (CustomersForm)this.Owner;
                        cf.RefreshGrid();
                        this.Close();
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
            if (string.IsNullOrEmpty(txtCustomerNo.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCustomerNo, "No Cannot be null!");
                return false;
            }
            if (cboStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboStatus, "Select Status!");
                return false;
            }
            return noerror;
        }
        private string NextCustomerNo()
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
        private void EditCustomerForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                InitializeControls();

                AutoCompleteStringCollection acscbnksrtcd = new AutoCompleteStringCollection();
                acscbnksrtcd.AddRange(this.AutoComplete_BankSortCodes());
                txtBankSortCode.AutoCompleteCustomSource = acscbnksrtcd;
                txtBankSortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtBankSortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsccstmrn = new AutoCompleteStringCollection();
                acsccstmrn.AddRange(this.AutoComplete_CustomerNo());
                txtCustomerNo.AutoCompleteCustomSource = acsccstmrn;
                txtCustomerNo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtCustomerNo.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsccstmrnm = new AutoCompleteStringCollection();
                acsccstmrnm.AddRange(this.AutoComplete_Name());
                txtName.AutoCompleteCustomSource = acsccstmrnm;
                txtName.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtName.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
        private string[] AutoComplete_CustomerNo()
        {
            try
            {
                var customernamesquery = from bk in db.Customers
                                         where bk.IsDeleted == false
                                         select bk.CustomerNo;
                return customernamesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Name()
        {
            try
            {
                var customernamesquery = from bk in db.Customers
                                         where bk.IsDeleted == false
                                         select bk.CustomerName;
                return customernamesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void InitializeControls()
        {
            try
            {
                if (customer.CustomerNo != null)
                {
                    txtCustomerNo.Text = customer.CustomerNo.Trim();
                }
                if (customer.CustomerNo == null)
                {
                    string _CustomerNo = Utils.NextSeries(NextCustomerNo());
                    txtCustomerNo.Text = _CustomerNo;
                }
                if (customer.CustomerName != null)
                {
                    txtName.Text = customer.CustomerName.Trim();
                }
                if (customer.Address != null)
                {
                    txtAddress.Text = customer.Address.Trim();
                }
                if (customer.Telephone != null)
                {
                    txtPhone.Text = customer.Telephone.Trim();
                }
                if (customer.Email != null)
                {
                    txtEmail.Text = customer.Email.Trim();
                }
                if (customer.Branch != null)
                {
                    txtBankSortCode.Text = customer.Branch.ToString();
                }
                if (customer.BillToName != null)
                {
                    txtBillToName.Text = customer.BillToName.Trim();
                }
                if (customer.BillToAddress != null)
                {
                    txtBilllToAddress.Text = customer.BillToAddress.Trim();
                }
                if (customer.BillToTelephone != null)
                {
                    txtBillToTelephone.Text = customer.BillToTelephone.Trim();
                }
                if (customer.BillToEmail != null)
                {
                    txtBillToEmail.Text = customer.BillToEmail.Trim();
                }
                if (customer.Status != null)
                {
                    cboStatus.SelectedValue = customer.Status.Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void DisableControls()
        {
            try
            {
                txtCustomerNo.Enabled = false;
                txtName.Enabled = false;
                txtAddress.Enabled = false;
                txtPhone.Enabled = false;
                txtEmail.Enabled = false;
                txtBankSortCode.Enabled = false;
                btnSearchBankSortCode.Enabled = false;
                txtBillToName.Enabled = false;
                txtBilllToAddress.Enabled = false;
                txtBillToTelephone.Enabled = false;
                txtBillToEmail.Enabled = false;
                cboStatus.Enabled = false;
                btnUpdate.Enabled = false;
                btnUpdate.Visible = false;
                btnClose.Location = btnUpdate.Location;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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



    }
}