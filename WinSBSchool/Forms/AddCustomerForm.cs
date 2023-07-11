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
    public partial class AddCustomerForm : Form
    {   
        #region "Private Fields" 
        Student _Student;
        SBSchoolDBEntities db;
        string connection;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        #endregion "Private Fields"

        #region "Constructor"
        public AddCustomerForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
        }
        public AddCustomerForm(Student _student, string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            _Student = db.Students.Where(s => s.Id == _student.Id).First();
            
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
                    Customer customer = new Customer();
                    if (!string.IsNullOrEmpty(txtCustomerNo.Text))
                    {
                        customer.CustomerNo = txtCustomerNo.Text;
                    }
                    if (!string.IsNullOrEmpty(txtName.Text))
                    {
                        customer.CustomerName = Utils.ConvertFirstLetterToUpper(txtName.Text);
                    }
                    if (!string.IsNullOrEmpty(txtAddress.Text))
                    {
                        customer.Address = txtAddress.Text;
                    }
                    if (!string.IsNullOrEmpty(txtPhone.Text))
                    {
                        customer.Telephone = txtPhone.Text;
                    }
                    if (!string.IsNullOrEmpty(txtEmail.Text))
                    {
                        customer.Email = txtEmail.Text;
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
                    customer.IsDeleted = false;

                    if (db.Customers.Any(c => c.CustomerName == customer.CustomerName))
                    {
                        MessageBox.Show("Customer Name Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Customers.Any(c => c.CustomerName == customer.CustomerName))
                    {
                        db.Customers.AddObject(customer);
                        db.SaveChanges();


                        int cnt = db.Customers.Count(c => c.StudentId == _Student.Id);
                        if (cnt == 0) // recod does not exist
                        {
                            //to add the customer and retrive customer id
                            _Student.CustomerId = customer.Id;
                            db.SaveChanges();  // to save the updated _Student
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
        private void AddNewCustomerForm_Load(object sender, EventArgs e)
        {
            try
            { 
                
                string _CustomerNo =  Utils.NextSeries(LastCycleId()) ;
                txtCustomerNo.Text = _CustomerNo;

                InitializeControls();

                AutoCompleteStringCollection cnosccls = new AutoCompleteStringCollection();
                cnosccls.AddRange(this.AutoComplete_CustomerNo());
                txtCustomerNo.AutoCompleteCustomSource = cnosccls;
                txtCustomerNo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtCustomerNo.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection cnsccls = new AutoCompleteStringCollection();
                cnsccls.AddRange(this.AutoComplete_CustomerName());
                txtName.AutoCompleteCustomSource = cnsccls;
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
        private string[] AutoComplete_CustomerNo()
        {
            try
            {
                var descriptionquery = from cs in db.Customers
                                       where cs.IsDeleted == false
                                       select cs.CustomerNo;
                return descriptionquery.ToArray();
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
                var descriptionquery = from cs in db.Customers
                                       where cs.IsDeleted == false
                                       select cs.CustomerName;
                return descriptionquery.ToArray();
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


    }
}
