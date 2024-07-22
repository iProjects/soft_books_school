using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;
using WinSBSchool.Forms;

namespace WinSBSchool.Forms
{
    public partial class AddTransactionTypeForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        List<object> PrintObject;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public AddTransactionTypeForm(string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            PrintObject = new List<object>();
        }

        private void AddTransactionTypeForm_Load(object sender, EventArgs e)
        {
            try
            {
                var debitcredit = new BindingList<KeyValuePair<string, string>>();
                debitcredit.Add(new KeyValuePair<string, string>("D", "Debit"));
                debitcredit.Add(new KeyValuePair<string, string>("C", "Credit"));
                cboDebitCredit.DataSource = debitcredit;
                cboDebitCredit.ValueMember = "Key";
                cboDebitCredit.DisplayMember = "Value";

                var _TxnTypeView = new BindingList<KeyValuePair<string, string>>();
                _TxnTypeView.Add(new KeyValuePair<string, string>("S", "Single Entry"));
                _TxnTypeView.Add(new KeyValuePair<string, string>("D", "Double Entry"));
                _TxnTypeView.Add(new KeyValuePair<string, string>("M", "Muilti Entry"));
                cboTxnView.DataSource = _TxnTypeView;
                cboTxnView.ValueMember = "Key";
                cboTxnView.DisplayMember = "Value";

                var _CreditAccountFieldView = new BindingList<KeyValuePair<string, string>>();
                _CreditAccountFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _CreditAccountFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _CreditAccountFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboCreditAccountField.DataSource = _CreditAccountFieldView;
                cboCreditAccountField.ValueMember = "Key";
                cboCreditAccountField.DisplayMember = "Value";

                var _CreditNarrativeFieldView = new BindingList<KeyValuePair<string, string>>();
                _CreditNarrativeFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _CreditNarrativeFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _CreditNarrativeFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboCreditNarrativeField.DataSource = _CreditNarrativeFieldView;
                cboCreditNarrativeField.ValueMember = "Key";
                cboCreditNarrativeField.DisplayMember = "Value";

                var _DebitAccountFieldView = new BindingList<KeyValuePair<string, string>>();
                _DebitAccountFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _DebitAccountFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _DebitAccountFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboDebitAccountField.DataSource = _DebitAccountFieldView;
                cboDebitAccountField.ValueMember = "Key";
                cboDebitAccountField.DisplayMember = "Value";

                var _DebitNarrativeFieldView = new BindingList<KeyValuePair<string, string>>();
                _DebitNarrativeFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _DebitNarrativeFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _DebitNarrativeFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboDebitNarrativeField.DataSource = _DebitNarrativeFieldView;
                cboDebitNarrativeField.ValueMember = "Key";
                cboDebitNarrativeField.DisplayMember = "Value";

                var _AmountFieldView = new BindingList<KeyValuePair<string, string>>();
                _AmountFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _AmountFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _AmountFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboAmountField.DataSource = _AmountFieldView;
                cboAmountField.ValueMember = "Key";
                cboAmountField.DisplayMember = "Value";

                var _MethodofPaymentFieldView = new BindingList<KeyValuePair<string, string>>();
                _MethodofPaymentFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _MethodofPaymentFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _MethodofPaymentFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboMethodofPaymentField.DataSource = _MethodofPaymentFieldView;
                cboMethodofPaymentField.ValueMember = "Key";
                cboMethodofPaymentField.DisplayMember = "Value";

                var _ValueDateFieldView = new BindingList<KeyValuePair<string, string>>();
                _ValueDateFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _ValueDateFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _ValueDateFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboValueDateField.DataSource = _ValueDateFieldView;
                cboValueDateField.ValueMember = "Key";
                cboValueDateField.DisplayMember = "Value";

                var _NarrativeFlag = new BindingList<KeyValuePair<string, string>>();
                _NarrativeFlag.Add(new KeyValuePair<string, string>("S", "Screen"));
                _NarrativeFlag.Add(new KeyValuePair<string, string>("E", "Extendend"));
                cboNarrativeFlag.DataSource = _NarrativeFlag;
                cboNarrativeFlag.ValueMember = "Key";
                cboNarrativeFlag.DisplayMember = "Value";

                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("I", "Inactive"));
                cbostatus.DataSource = status;
                cbostatus.ValueMember = "Key";
                cbostatus.DisplayMember = "Value";

                var statementflag = new BindingList<KeyValuePair<string, string>>();
                statementflag.Add(new KeyValuePair<string, string>("C", "Credit"));
                statementflag.Add(new KeyValuePair<string, string>("D", "Debit"));
                cbostatementflag.DataSource = statementflag;
                cbostatementflag.ValueMember = "Key";
                cbostatementflag.DisplayMember = "Value"; 
                
                AutoCompleteStringCollection acscyr = new AutoCompleteStringCollection();
                acscyr.AddRange(this.AutoComplete_DrAccountIds());
                txtDefaultDebitAccount.AutoCompleteCustomSource = acscyr;
                txtDefaultDebitAccount.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtDefaultDebitAccount.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsctrm = new AutoCompleteStringCollection();
                acsctrm.AddRange(this.AutoComplete_CrAccountIds());
                txtDefaultCreditAccount.AutoCompleteCustomSource = acsctrm;
                txtDefaultCreditAccount.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtDefaultCreditAccount.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                txtDefaultAmount.Enabled = false;
                txtDefaultCreditAccount.Enabled = false;
                txtDefaultDebitAccount.Enabled = false;
                txtDefaultCreditNarrative.Enabled = false;
                txtDefaultDebitNarrative.Enabled = false;

                AutoCompleteStringCollection acscsshrtcd = new AutoCompleteStringCollection();
                acscsshrtcd.AddRange(this.AutoComplete_ShortCode());
                txtShortCode.AutoCompleteCustomSource = acscsshrtcd;
                txtShortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtShortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscdscrptn = new AutoCompleteStringCollection();
                acscdscrptn.AddRange(this.AutoComplete_Description());
                txtDescription.AutoCompleteCustomSource = acscdscrptn;
                txtDescription.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtDescription.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                txtCommissionType.Text = "2";
                txtDialogFlag.Text = "1"; 
                txtvaluedays.Text = "0";
                chkPrintReceipts.Checked = true;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_ShortCode()
        {
            try
            {
                var shortcodequery = from bk in db.AccountTypes
                                     where bk.Status == "A"
                                     where bk.IsDeleted == false
                                     select bk.ShortCode;
                return shortcodequery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_Description()
        {
            try
            {
                var shortcodequery = from bk in db.TransactionTypes
                                     where bk.Status == "A"
                                     where bk.IsDeleted == false
                                     select bk.Description;
                return shortcodequery.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string[] AutoComplete_DrAccountIds()
        {
            try
            {
                var accidsquery = (from ac in db.Accounts
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
        private string[] AutoComplete_CrAccountIds()
        {
            try
            {
                var accidsquery = (from ac in db.Accounts
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider.Clear();
            if (IsTransactionTypeValid())
            {
                try
                {
                    TransactionType txn = new TransactionType();

                    #region "Txn Info"
                    if (!string.IsNullOrEmpty(txtShortCode.Text))
                    {
                        txn.ShortCode = Utils.ConvertFirstLetterToUpper(txtShortCode.Text.Trim());
                    }
                    if (!string.IsNullOrEmpty(txtDescription.Text))
                    {
                        txn.Description = Utils.ConvertFirstLetterToUpper(txtDescription.Text.Trim());
                    }
                    if (cboDebitCredit.SelectedIndex != -1)
                    {
                        txn.DebitCredit = cboDebitCredit.SelectedValue.ToString();
                    }
                    if (cboTxnView.SelectedIndex != -1)
                    {
                        txn.TxnTypeView = cboTxnView.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtCommissionType.Text))
                    {
                        txn.CommissionType = txtCommissionType.Text.Trim();
                    }
                    decimal flatrate;
                    if (!string.IsNullOrEmpty(txtFlatRate.Text) && decimal.TryParse(txtFlatRate.Text, out flatrate))
                    {
                        txn.FlatRate = decimal.Parse(txtFlatRate.Text);
                    }
                    double percentagerate;
                    if (!string.IsNullOrEmpty(txtPercentage.Text) && double.TryParse(txtPercentage.Text, out percentagerate))
                    {
                        txn.PercentageRate = double.Parse(txtPercentage.Text);
                    }
                    if (!string.IsNullOrEmpty(txtDialogFlag.Text))
                    {
                        txn.DialogFlag = txtDialogFlag.Text;
                    }
                    if (cboNarrativeFlag.SelectedIndex != -1)
                    {
                        txn.NarrativeFlag = cboNarrativeFlag.SelectedValue.ToString();
                    }
                    txn.ForcePost = "1";
                    #endregion "Txn Info"
                    #region "Defaults"
                    txn.UseDefaultAmount = chkUseDefaultAmount.Checked;
                    decimal defaultamount;
                    if (chkUseDefaultAmount.Checked == true && !string.IsNullOrEmpty(txtDefaultAmount.Text) && decimal.TryParse(txtDefaultAmount.Text, out defaultamount))
                    {
                        txn.DefaultAmount = decimal.Parse(txtDefaultAmount.Text);
                    }
                    txn.UseDefaultCreditAccount = chkUseDefaultCreditAccount.Checked;
                    int defaultcreditaccount;
                    if (chkUseDefaultCreditAccount.Checked == true && !string.IsNullOrEmpty(txtDefaultCreditAccount.Text) && int.TryParse(txtDefaultCreditAccount.Text, out defaultcreditaccount))
                    {
                        txn.DefaultCreditAccount = int.Parse(txtDefaultCreditAccount.Text);
                    }
                    txn.UseDefaultDebitAccount = chkUseDefaultDebitAccount.Checked;
                    int defaultdebitaccount;
                    if (chkUseDefaultDebitAccount.Checked == true && !string.IsNullOrEmpty(txtDefaultDebitAccount.Text) && int.TryParse(txtDefaultDebitAccount.Text, out defaultdebitaccount))
                    {
                        txn.DefaultDebitAccount = int.Parse(txtDefaultDebitAccount.Text);
                    }
                    txn.UseDefaultCreditNarrative = chkUseDefaultCreditNarrative.Checked;
                    if (chkUseDefaultCreditNarrative.Checked == true && !string.IsNullOrEmpty(txtDefaultCreditNarrative.Text))
                    {
                        txn.DefaultCreditNarrative = Utils.ConvertFirstLetterToUpper(txtDefaultCreditNarrative.Text);
                    }
                    txn.UseDefaultDebitNarrative = chkUseDefaultDebitNarrative.Checked;
                    if (chkUseDefaultDebitNarrative.Checked == true && !string.IsNullOrEmpty(txtDefaultDebitNarrative.Text))
                    {
                        txn.DefaultDebitNarrative = Utils.ConvertFirstLetterToUpper(txtDefaultDebitNarrative.Text);
                    }
                    #endregion "Defaults"
                    #region "Views"
                    if (cboCreditAccountField.SelectedIndex != -1)
                    {
                        txn.ScreenViewCreditAccountField = cboCreditAccountField.SelectedValue.ToString();
                    }
                    if (cboCreditNarrativeField.SelectedIndex != -1)
                    {
                        txn.ScreenViewCreditNarrativeField = cboCreditNarrativeField.SelectedValue.ToString();
                    }
                    if (cboDebitAccountField.SelectedIndex != -1)
                    {
                        txn.ScreenViewDebitAccountField = cboDebitAccountField.SelectedValue.ToString();
                    }
                    if (cboDebitNarrativeField.SelectedIndex != -1)
                    {
                        txn.ScreenViewDebitNarrativeField = cboDebitNarrativeField.SelectedValue.ToString();
                    }
                    if (cboAmountField.SelectedIndex != -1)
                    {
                        txn.ScreenViewAmountField = cboAmountField.SelectedValue.ToString();
                    }
                    if (cboMethodofPaymentField.SelectedIndex != -1)
                    {
                        txn.ScreenViewModeofPaymentField = cboMethodofPaymentField.SelectedValue.ToString();
                    }
                    if (cboValueDateField.SelectedIndex != -1)
                    {
                        txn.ScreenViewValueDateField = cboValueDateField.SelectedValue.ToString();
                    }
                    #endregion "Views"
                    #region "Receipts"
                    txn.PrintReceipt = chkPrintReceipts.Checked;
                    txn.ReceiptLayout = txtReceiptLayout.Text;
                    txn.PrintReceiptPrompt = chkPrintReceiptPrompt.Checked;
                    #endregion "Receipts"

                    txn.StatementFlag = cbostatementflag.SelectedValue.ToString();
                    txn.ValueDays = int.Parse(txtvaluedays.Text);

                    txn.Status = cbostatus.SelectedValue.ToString();
                    txn.IsDeleted = false;

                    if (!db.TransactionTypes.Any(i => i.ShortCode == txn.ShortCode))
                    {
                        db.TransactionTypes.AddObject(txn);
                        db.SaveChanges();
                    }

                    TransactionTypesListForm f = (TransactionTypesListForm)this.Owner;
                    f.RefreshGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public bool IsTransactionTypeValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtShortCode.Text))
            {
                errorProvider.SetError(txtShortCode, "Short Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (cboDebitCredit.SelectedIndex == -1)
            {
                errorProvider.SetError(cboDebitCredit, "Select Debit/Credit!");
                return false;
            }
            if (cboTxnView.SelectedIndex == -1)
            {
                errorProvider.SetError(cboTxnView, "Select Transaction Type View!");
                return false;
            }
            return noerror;
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnSearchDefaultCrAcc_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountsSimpleForm saf = new Forms.SearchAccountsSimpleForm(user, connection, _notificationmessageEventname) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountsSimpleForm.AccountSelectHandler(saf_OnDefaultCrAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnDefaultCrAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetDefaultCrAccountId(e._Account);
        }
        private void SetDefaultCrAccountId(Account _Account)
        {
            if (_Account != null)
            {
                txtDefaultCreditAccount.Text = _Account.Id.ToString();
            }
        }
        private void btnSearchDefaultDrAcc_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountsSimpleForm saf = new Forms.SearchAccountsSimpleForm(user, connection, _notificationmessageEventname) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountsSimpleForm.AccountSelectHandler(saf_OnDefaultDrAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnDefaultDrAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetDefaultDrAccountId(e._Account);
        }
        private void SetDefaultDrAccountId(Account _Account)
        {
            if (_Account != null)
            {
                txtDefaultDebitAccount.Text = _Account.Id.ToString();
            }
        }
        private void btnAddField_Click(object sender, EventArgs e)
        {
            try
            {
                FormFieldSelector f = new FormFieldSelector();
                f.OnReceiptItemListSelected += new FormFieldSelector.ReceiptItemSelectHandler(f_OnReceiptItemListSelected);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        void f_OnReceiptItemListSelected(object sender, ReceiptItemEventArgs e)
        {
            PrintObject.Add(e._PrintField);
            this.txtReceiptLayout.Text += " {" + e._PrintField.Id + "} ";
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.PrintObject.Clear();
            this.txtReceiptLayout.Text = string.Empty;
        }
        private void btnText_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtText.Text))
                this.txtReceiptLayout.Text += Utils.ConvertFirstLetterToUpper(txtText.Text);
        }
        private void btnAddNewLine_Click(object sender, EventArgs e)
        {
            this.txtReceiptLayout.Text += System.Environment.NewLine;

        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //txtReceiptLayout.Copy();
                Clipboard.SetDataObject(txtReceiptLayout.Text, true);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //txtReceiptLayout.Paste();
                if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
                    txtReceiptLayout.SelectedText = txtReceiptLayout.SelectedText + Clipboard.GetDataObject().GetData(DataFormats.Text).ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtFlatRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtFlatRate_KeyDown(object sender, KeyEventArgs e)
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
        private void txtPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtPercentage_KeyDown(object sender, KeyEventArgs e)
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
        private void txtDefaultAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtDefaultAmount_KeyDown(object sender, KeyEventArgs e)
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
        private void txtDefaultCreditAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtDefaultCreditAccount_KeyDown(object sender, KeyEventArgs e)
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
        private void txtDefaultDebitAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void txtDefaultDebitAccount_KeyDown(object sender, KeyEventArgs e)
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
        private void chkUseDefaultAmount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseDefaultAmount.Checked)
            {
                txtDefaultAmount.Enabled = true;
            }
            else
            {
                txtDefaultAmount.Enabled = false;
            }
        }

        private void chkUseDefaultCreditAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseDefaultCreditAccount.Checked)
            {
                txtDefaultCreditAccount.Enabled = true;
            }
            else
            {
                txtDefaultCreditAccount.Enabled = false;
            }
        }

        private void chkUseDefaultDebitAccount_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseDefaultDebitAccount.Checked)
            {
                txtDefaultDebitAccount.Enabled = true;
            }
            else
            {
                txtDefaultDebitAccount.Enabled = false;
            }
        }

        private void chkUseDefaultCreditNarrative_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseDefaultCreditNarrative.Checked)
            {
                txtDefaultCreditNarrative.Enabled = true;
            }
            else
            {
                txtDefaultCreditNarrative.Enabled = false;
            }
        }

        private void chkUseDefaultDebitNarrative_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseDefaultDebitNarrative.Checked)
            {
                txtDefaultDebitNarrative.Enabled = true;
            }
            else
            {
                txtDefaultDebitNarrative.Enabled = false;
            }
        }

        private void chkPrintReceipts_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrintReceipts.Checked)
            {
                groupBoxReceiptLayout.Enabled = true;

                StringBuilder sb = new StringBuilder();

                Dictionary<int, PrintField> fields = new Dictionary<int, PrintField>();

                fields.Add(0, new PrintField(0, "Date:", new DateTime())); //Date now
                fields.Add(1, new PrintField(1, "School Name:", null)); //School StudentName
                fields.Add(2, new PrintField(2, "School Address:", null)); //School Address
                fields.Add(3, new PrintField(3, "Receipt Number:", null)); //Receipt Number
                fields.Add(4, new PrintField(4, "Debit Account:", null)); //Debit Account
                fields.Add(5, new PrintField(5, "Credit Account:", null)); //Credit Account            
                fields.Add(6, new PrintField(6, "Debit Narrative:", null)); //Debit Narrative
                fields.Add(7, new PrintField(7, "Credit Narrative:", null)); //Credit Narrative
                fields.Add(8, new PrintField(8, "Amount:", null)); //Amount
                fields.Add(9, new PrintField(9, "Student Name:", null)); //StudentId StudentName
                fields.Add(10, new PrintField(10, "Student Admino:", null)); //Admino
                fields.Add(11, new PrintField(11, "Student Class:", null)); //Class

                foreach (var field in fields.Values)
                {
                    string template = Utils.ConvertFirstLetterToUpper(field.Name.ToString()) + " {" + field.Id + "} ";
                    sb.AppendLine(template);
                    //sb.AppendLine(System.Environment.NewLine);           
                }

                txtReceiptLayout.Text = sb.ToString();

            }
            else
            {
                groupBoxReceiptLayout.Enabled = false;
                //txtReceiptLayout.Text = string.Empty;
            }

        }

        private void btndefaultreceiptlayout_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            Dictionary<int, PrintField> fields = new Dictionary<int, PrintField>();

            fields.Add(0, new PrintField(0, "Date:", new DateTime())); //Date now
            fields.Add(1, new PrintField(1, "School Name:", null)); //School StudentName
            fields.Add(2, new PrintField(2, "School Address:", null)); //School Address
            fields.Add(3, new PrintField(3, "Receipt Number:", null)); //Receipt Number
            fields.Add(4, new PrintField(4, "Debit Account:", null)); //Debit Account
            fields.Add(5, new PrintField(5, "Credit Account:", null)); //Credit Account            
            fields.Add(6, new PrintField(6, "Debit Narrative:", null)); //Debit Narrative
            fields.Add(7, new PrintField(7, "Credit Narrative:", null)); //Credit Narrative
            fields.Add(8, new PrintField(8, "Amount:", null)); //Amount
            fields.Add(9, new PrintField(9, "Student Name:", null)); //StudentId StudentName
            fields.Add(10, new PrintField(10, "Student Admino:", null)); //Admino
            fields.Add(11, new PrintField(11, "Student Class:", null)); //Class

            foreach (var field in fields.Values)
            {
                string template = Utils.ConvertFirstLetterToUpper(field.Name.ToString()) + " {" + field.Id + "} ";
                sb.AppendLine(template);
                //sb.AppendLine(System.Environment.NewLine);           
            }

            txtReceiptLayout.Text = sb.ToString();
        }



    }
}
