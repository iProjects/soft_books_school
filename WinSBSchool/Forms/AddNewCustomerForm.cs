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
    public partial class AddNewCustomerForm : Form
    {
        
        #region "Private Fields"
        SBSchoolDBEntities db;
        Repository rep;
        string connection;
        Student _Student;
        School _School;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public AddNewCustomerForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }
        public AddNewCustomerForm(Student _student, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (_student == null)
                throw new ArgumentNullException("Student");

            _Student = db.Students.Where(s => s.Id == _student.Id).First();
            
        }
        public AddNewCustomerForm(School _school, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (_school == null)
                throw new ArgumentNullException("School");

            _School = db.Schools.Where(s => s.Id == _school.Id).First();

         
        }
        #endregion "Constructor"


        #region "Private Methods"
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
                    DAL.Customer customer = new DAL.Customer();
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        customer.CustomerName = Utils.ConvertFirstLetterToUpper(txtName.Text);
                    }
                    if (!string.IsNullOrEmpty(txtCustomerNo.Text))
                    {
                        customer.CustomerNo = txtCustomerNo.Text.Trim();
                    }                    
                    if (!string.IsNullOrEmpty(txtAddress.Text))
                    {
                        customer.Address = txtAddress.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtPhone.Text))
                    {
                        customer.Telephone = txtPhone.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        customer.Email = txtEmail.Text.Trim();
                    }
                    int banksortcode;
                    if (!string.IsNullOrEmpty(txtBankSortCode.Text) && int.TryParse(txtBankSortCode.Text, out banksortcode))
                    {
                        customer.Branch = int.Parse(txtBankSortCode.Text);
                    }
                    if (!string.IsNullOrEmpty(txtBillToName.Text))
                    {
                        customer.BillToName = txtBillToName.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBilllToAddress.Text))
                    {
                        customer.BillToAddress = txtBilllToAddress.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBillToTelephone.Text))
                    {
                        customer.BillToTelephone = txtBillToTelephone.Text.Trim();
                    }
                    if (!string.IsNullOrEmpty(txtBillToEmail.Text))
                    {
                        customer.BillToEmail = txtBillToEmail.Text.Trim();
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        customer.Status = cboStatus.SelectedValue.ToString();
                    }
                    customer.DateofCreation = DateTime.Now;
                    customer.IsDeleted = false;

                    if (!db.Customers.Any(c => c.CustomerName == customer.CustomerName))
                    {
                        db.Customers.AddObject(customer);
                        db.SaveChanges();
                    } 
                    if (_Student != null && _Student.CustomerId == null)
                    {
                        customer.StudentId = _Student. Id;
                        db.SaveChanges();

                        _Student.CustomerId = customer. Id;
                        rep.UpdateStudentCustomer(_Student);
                    }
                    if (_School != null)
                    {
                        _School.GLCustomerId = customer.Id;
                        rep.UpdateSchoolCustomer(_School);
                    } 

                    if (this.Owner is EditStudentForm)
                    {
                        EditStudentForm f = (EditStudentForm)this.Owner;
                        MessageBox.Show("Customer Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        f.CloseForm(sender,e);
                        this.Close();
                    }
                    else if (this.Owner is EditSchoolForm)
                    {
                        EditSchoolForm f = (EditSchoolForm)this.Owner;
                        MessageBox.Show("Customer Created Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        f.CloseForm(sender, e);
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
        private void AddNewCustomerForm_Load(object sender, EventArgs e)
        {
            try
            {
                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value";

                string _CustomerNo = Utils.NextSeries(NextCustomerNo());
                txtCustomerNo.Text = _CustomerNo;

                InitializeStudentControls();

                InitializeSchoolControls();

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
                                     where bk.IsDeleted==false
                                     select bk.CustomerName;
                return customernamesquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
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
        private void InitializeStudentControls()
        {
            if (_Student != null)
            {
                try
                {
                    if (_Student.StudentSurName != null && _Student.StudentOtherNames != null && _Student.AdminNo != null)
                    {
                        txtName.Text = _Student.AdminNo.Trim() + "  -  " + Utils.ConvertFirstLetterToUpper(_Student.StudentOtherNames) + "  " + Utils.ConvertFirstLetterToUpper(_Student.StudentSurName); 
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
                    if (_Student.FatherName != null)
                    {
                        txtBillToName.Text = _Student.FatherName.Trim();
                    }
                    if (_Student.FatherCellPhone != null)
                    {
                        txtBillToTelephone.Text = _Student.FatherCellPhone.Trim() + " , " + _Student.FatherOfficePhone.Trim();
                    }
                    if (_Student.FatherEmail != null)
                    {
                        txtBillToEmail.Text = _Student.FatherEmail.Trim();
                    }
                    if (_Student.StudentAddress != null)
                    {
                        txtBilllToAddress.Text = _Student.StudentAddress.Trim();
                    }
                    if (_Student.MotherName != null)
                    {
                        txtBillToName.Text += " , " + _Student.MotherName.Trim();
                    }
                    if (_Student.MotherCellPhone != null)
                    {
                        txtBillToTelephone.Text += " , " + _Student.MotherCellPhone.Trim() + " , " + _Student.MotherOfficePhone.Trim();
                    }
                    if (_Student.MotherEmail != null)
                    {
                        txtBillToEmail.Text += " , " + _Student.MotherEmail.Trim();
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void InitializeSchoolControls()
        {
            if (_School != null)
            {
                try
                {
                    if (_School.SchoolIndex != null && _School.SchoolName != null  )
                    {
                        txtName.Text = Utils.ConvertFirstLetterToUpper(_School.SchoolIndex) + "  -  " + Utils.ConvertFirstLetterToUpper(_School.SchoolName);
                    }
                    if (_School.Cellphone != null && _School.Telephone != null)
                    {
                        txtPhone.Text = _School.Cellphone.Trim() + " , " + _School.Telephone.Trim();
                    }
                    if (_School.Email != null)
                    {
                        txtEmail.Text = _School.Email.Trim();
                    }
                    if (_School.Address1 != null && _School.Address2 != null)
                    {
                        txtAddress.Text = Utils.ConvertFirstLetterToUpper(_School.Address1.Trim()) + ", " + Utils.ConvertFirstLetterToUpper(_School.Address2.Trim());
                    }
                    if (_School.SchoolIndex != null && _School.SchoolName != null  )
                    {
                        txtBillToName.Text = Utils.ConvertFirstLetterToUpper(_School.SchoolIndex) + "  -  " + Utils.ConvertFirstLetterToUpper(_School.SchoolName);
                    }
                    if (_School.Cellphone != null && _School.Telephone != null)
                    {
                        txtBillToTelephone.Text = _School.Cellphone.Trim() + " , " + _School.Telephone.Trim();
                    }
                    if (_School.Email != null)
                    {
                        txtBillToEmail.Text = _School.Email.Trim();
                    }
                    if (_School.Address1 != null && _School.Address2 != null)
                    {
                        txtBilllToAddress.Text = Utils.ConvertFirstLetterToUpper(_School.Address1.Trim()) + ", " + Utils.ConvertFirstLetterToUpper(_School.Address2.Trim());
                    } 
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        #endregion "Private Methods"

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

        private void txtCustomerNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
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

        private void txtBillToTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtBillToTelephone_KeyDown(object sender, KeyEventArgs e)
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
