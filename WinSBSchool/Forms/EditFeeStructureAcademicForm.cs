using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class EditFeeStructureAcademicForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname; 
        FeeStructureAcademic _FeeStructureAcademic;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditFeeStructureAcademicForm(FeeStructureAcademic _fsa, string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished EditFeeStructureAcademicForm initialization", TAG));
 
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

        private void EditFeeStructureOthersForm_Load(object sender, EventArgs e)
        {
            try
            {
                lblAccountDetails.Text = string.Empty;

                var _FeeStructurequery = from fs in db.FeesStructures
                                         select fs;
                List<FeesStructure> _FeesStructures = _FeeStructurequery.ToList();
                cboFeeStructure.DataSource = _FeesStructures;
                cboFeeStructure.ValueMember = "Id";
                cboFeeStructure.DisplayMember = "Description";
                cboFeeStructure.SelectedIndex = -1;

                var _SchoolClassquery = from sc in db.SchoolClasses
                                        select sc;
                List<SchoolClass> _SchoolClasses = _SchoolClassquery.ToList();
                cboClass.DataSource = _SchoolClasses;
                cboClass.ValueMember = "Id";
                cboClass.DisplayMember = "ClassName";
                cboClass.SelectedIndex = -1;

                var _amountPeriods = new BindingList<KeyValuePair<string, string>>();
                _amountPeriods.Add(new KeyValuePair<string, string>("S", "Per Semester"));
                _amountPeriods.Add(new KeyValuePair<string, string>("Y", "Per Academic Year"));
                _amountPeriods.Add(new KeyValuePair<string, string>("D", "Once on Admission"));
                _amountPeriods.Add(new KeyValuePair<string, string>("P", "Once on Application"));
                _amountPeriods.Add(new KeyValuePair<string, string>("R", "Once on Admission(Refundable)"));
                cboAmountPeriod.DataSource = _amountPeriods;
                cboAmountPeriod.ValueMember = "Key";
                cboAmountPeriod.DisplayMember = "Value";
                cboAmountPeriod.SelectedIndex = -1;

                AutoCompleteStringCollection acsaccid = new AutoCompleteStringCollection();
                acsaccid.AddRange(this.AutoComplete_AccountIds());
                txtAccountId.AutoCompleteCustomSource = acsaccid;
                txtAccountId.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountId.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                InitializeControls();

                AutoCompleteStringCollection acsccls = new AutoCompleteStringCollection();
                acsccls.AddRange(this.AutoComplete_Description());
                txtDescription.AutoCompleteCustomSource = acsccls;
                txtDescription.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtDescription.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_Description()
        {
            try
            {
                var descriptionquery = from cs in db.FeeStructureAcademics
                                       where cs.IsDeleted == false
                                       select cs.Description;
                return descriptionquery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_AccountIds()
        {
            try
            {
                var accidsquery = (from ac in db.Accounts
                                   where ac.Closed == false
                                   select ac.Id).Distinct();
                int[] intarray = accidsquery.ToArray();
                List<string> items = new List<string>();
                for (int i = 0; i < accidsquery.Count(); i++)
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
        private void InitializeControls()
        {
            try
            {
                if (_FeeStructureAcademic.FeeStructureId != null)
                {
                    cboFeeStructure.SelectedValue = _FeeStructureAcademic.FeeStructureId;
                }
                if (_FeeStructureAcademic.SchoolClassId != null)
                {
                    cboClass.SelectedValue = _FeeStructureAcademic.SchoolClassId;
                }
                if (_FeeStructureAcademic.Term != null)
                {
                    txtTerm.Text = _FeeStructureAcademic.Term.ToString();
                }
                if (_FeeStructureAcademic.AccountId != null)
                {
                    txtAccountId.Text = _FeeStructureAcademic.AccountId.ToString();
                }
                if (_FeeStructureAcademic.Description != null)
                {
                    txtDescription.Text = _FeeStructureAcademic.Description.ToString().Trim();
                }
                if (_FeeStructureAcademic.Amount != null)
                {
                    txtAmount.Text = _FeeStructureAcademic.Amount.ToString();
                }
                if (_FeeStructureAcademic.AmountPeriod != null)
                {
                    cboAmountPeriod.SelectedValue = _FeeStructureAcademic.AmountPeriod;
                }

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }

        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            if (IsFeeStructureAcademicValid())
            {
                try
                {
                    if (cboFeeStructure.SelectedIndex != -1)
                    {
                        _FeeStructureAcademic.FeeStructureId = int.Parse(cboFeeStructure.SelectedValue.ToString());
                    }
                    if (cboClass.SelectedIndex != -1)
                    {
                        _FeeStructureAcademic.SchoolClassId = int.Parse(cboClass.SelectedValue.ToString());
                    }
                    int term;
                    if (!string.IsNullOrEmpty(txtTerm.Text) && int.TryParse(txtTerm.Text, out term))
                    {
                        _FeeStructureAcademic.Term = int.Parse(txtTerm.Text);
                    }
                    int acc;
                    if (!string.IsNullOrEmpty(txtAccountId.Text) && int.TryParse(txtAccountId.Text, out acc))
                    {
                        _FeeStructureAcademic.AccountId = int.Parse(txtAccountId.Text);
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        _FeeStructureAcademic.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                    }
                    decimal amount;
                    if (!string.IsNullOrEmpty(txtDescription.Text) && decimal.TryParse(txtAmount.Text, out amount))
                    {
                        _FeeStructureAcademic.Amount = decimal.Parse(txtAmount.Text);
                    }
                    if (cboAmountPeriod.SelectedIndex != -1)
                    {
                        _FeeStructureAcademic.AmountPeriod = cboAmountPeriod.SelectedValue.ToString();
                    }

                    rep.UpdateFeeStructureAcademic(_FeeStructureAcademic);

                    FeeStructureForm f = (FeeStructureForm)this.Owner;
                    f.RefreshGridAcademics();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public bool IsFeeStructureAcademicValid()
        {
            bool noerror = true;
            if (cboFeeStructure.SelectedIndex == -1)
            { 
                errorProvider.SetError(cboFeeStructure, "Select Fee Structure!");
                noerror = false;
            }
            if (cboClass.SelectedIndex == -1)
            { 
                errorProvider.SetError(cboClass, "Select Class!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtTerm.Text))
            { 
                errorProvider.SetError(txtTerm, "Term cannot be null!");
                noerror = false;
            }
            int term;
            if (!int.TryParse(txtTerm.Text, out term))
            { 
                errorProvider.SetError(txtTerm, "Term must be integer!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtAccountId.Text))
            { 
                errorProvider.SetError(txtAccountId, "Account Id cannot be null!");
                noerror = false;
            }
            int acc;
            if (!int.TryParse(txtAccountId.Text, out acc))
            { 
                errorProvider.SetError(txtAccountId, "Account Id must be integer!");
                noerror = false;
            }
            Account account = rep.GetAccount(acc);
            if (null == account)
            { 
                errorProvider.SetError(txtAccountId, "Error retrieving the Account!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider.Clear();
                errorProvider.SetError(txtDescription, "Description cannot be null!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtAmount.Text))
            { 
                errorProvider.SetError(txtAmount, "Amount cannot be null!");
                noerror = false;
            }
            decimal amount;
            if (!decimal.TryParse(txtAmount.Text, out amount))
            { 
                errorProvider.SetError(txtAmount, "Amount must be decimal!");
                noerror = false;
            }
            if (cboAmountPeriod.SelectedIndex == -1)
            { 
                errorProvider.SetError(cboAmountPeriod, "Select Amount Period!");
                noerror = false;
            }
            return noerror;
        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnSearchAccount_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountsSimpleForm saf = new SearchAccountsSimpleForm(user, connection, _notificationmessageEventname) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountsSimpleForm.AccountSelectHandler(saf_OnAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetAccountId(e._Account);
        }
        private void SetAccountId(Account _Account)
        {
            if (_Account != null)
            {
                txtAccountId.Text = _Account.Id.ToString(); 
            }
        }
        private void txtTerm_KeyDown(object sender, KeyEventArgs e)
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

        private void txtTerm_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtAccountID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtAccountID_KeyDown(object sender, KeyEventArgs e)
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

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
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
        private void txtAccountId_Leave(object sender, EventArgs e)
        {
            try
            {
                lblAccountDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtAccountId.Text))
                {
                    int _accountid = int.Parse(txtAccountId.Text.Trim());
                    var _accountnamequery = (from ac in db.Accounts
                                             where ac.Id == _accountid
                                             select ac).FirstOrDefault();
                    if (_accountnamequery != null)
                    {
                        lblAccountDetails.Text = "Name: " + _accountnamequery.AccountName.Trim() + "     No: " + _accountnamequery.AccountNo.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAccountId_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblAccountDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtAccountId.Text))
                {
                    int _accountid = int.Parse(txtAccountId.Text.Trim());
                    var _accountnamequery = (from ac in db.Accounts
                                             where ac.Id == _accountid
                                             select ac).FirstOrDefault();
                    if (_accountnamequery != null)
                    {
                        lblAccountDetails.Text = "Name: " + _accountnamequery.AccountName.Trim() + "     No: " + _accountnamequery.AccountNo.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAccountId_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblAccountDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtAccountId.Text))
                {
                    int _accountid = int.Parse(txtAccountId.Text.Trim());
                    var _accountnamequery = (from ac in db.Accounts
                                             where ac.Id == _accountid
                                             select ac).FirstOrDefault();
                    if (_accountnamequery != null)
                    {
                        lblAccountDetails.Text = "Name: " + _accountnamequery.AccountName.Trim() + "     No: " + _accountnamequery.AccountNo.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAccountId_Validated(object sender, EventArgs e)
        {
            try
            {
                lblAccountDetails.Text = string.Empty;
                if (!string.IsNullOrEmpty(txtAccountId.Text))
                {
                    int _accountid = int.Parse(txtAccountId.Text.Trim());
                    var _accountnamequery = (from ac in db.Accounts
                                             where ac.Id == _accountid
                                             select ac).FirstOrDefault();
                    if (_accountnamequery != null)
                    {
                        lblAccountDetails.Text = "Name: " + _accountnamequery.AccountName.Trim() + "     No: " + _accountnamequery.AccountNo.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }



















    }
}
