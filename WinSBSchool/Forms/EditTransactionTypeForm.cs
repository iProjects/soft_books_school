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
    public partial class EditTransactionTypeForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        TransactionType txn;
        string connection;
        List<object> PrintObject;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        public EditTransactionTypeForm(TransactionType txntype, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            txn = txntype;

            PrintObject = new List<object>();
        }

        private void EditTransactionTypeForm_Load(object sender, EventArgs e)
        {
            try
            {
                var debitcredit = new BindingList<KeyValuePair<string, string>>();
                debitcredit.Add(new KeyValuePair<string, string>("D", "Debit"));
                debitcredit.Add(new KeyValuePair<string, string>("C", "Credit"));
                cboDebitCredit.DataSource = debitcredit;
                cboDebitCredit.ValueMember = "Key";
                cboDebitCredit.DisplayMember = "Value";
                cboDebitCredit.SelectedIndex = -1;

                var _TxnTypeView = new BindingList<KeyValuePair<string, string>>();
                _TxnTypeView.Add(new KeyValuePair<string, string>("S", "Single Entry"));
                _TxnTypeView.Add(new KeyValuePair<string, string>("D", "Double Entry"));
                _TxnTypeView.Add(new KeyValuePair<string, string>("M", "Muilti Entry"));
                cboTxnView.DataSource = _TxnTypeView;
                cboTxnView.ValueMember = "Key";
                cboTxnView.DisplayMember = "Value";
                cboTxnView.SelectedIndex = -1;

                var _CreditAccountFieldView = new BindingList<KeyValuePair<string, string>>();
                _CreditAccountFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _CreditAccountFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _CreditAccountFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboCreditAccountField.DataSource = _CreditAccountFieldView;
                cboCreditAccountField.ValueMember = "Key";
                cboCreditAccountField.DisplayMember = "Value";
                cboCreditAccountField.SelectedIndex = -1;

                var _CreditNarrativeFieldView = new BindingList<KeyValuePair<string, string>>();
                _CreditNarrativeFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _CreditNarrativeFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _CreditNarrativeFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboCreditNarrativeField.DataSource = _CreditNarrativeFieldView;
                cboCreditNarrativeField.ValueMember = "Key";
                cboCreditNarrativeField.DisplayMember = "Value";
                cboCreditNarrativeField.SelectedIndex = -1;

                var _DebitAccountFieldView = new BindingList<KeyValuePair<string, string>>();
                _DebitAccountFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _DebitAccountFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _DebitAccountFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboDebitAccountField.DataSource = _DebitAccountFieldView;
                cboDebitAccountField.ValueMember = "Key";
                cboDebitAccountField.DisplayMember = "Value";
                cboDebitAccountField.SelectedIndex = -1;

                var _DebitNarrativeFieldView = new BindingList<KeyValuePair<string, string>>();
                _DebitNarrativeFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _DebitNarrativeFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _DebitNarrativeFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboDebitNarrativeField.DataSource = _DebitNarrativeFieldView;
                cboDebitNarrativeField.ValueMember = "Key";
                cboDebitNarrativeField.DisplayMember = "Value";
                cboDebitNarrativeField.SelectedIndex = -1;

                var _AmountFieldView = new BindingList<KeyValuePair<string, string>>();
                _AmountFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _AmountFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _AmountFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboAmountField.DataSource = _AmountFieldView;
                cboAmountField.ValueMember = "Key";
                cboAmountField.DisplayMember = "Value";
                cboAmountField.SelectedIndex = -1;

                var _MethodofPaymentFieldView = new BindingList<KeyValuePair<string, string>>();
                _MethodofPaymentFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _MethodofPaymentFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _MethodofPaymentFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboMethodofPaymentField.DataSource = _MethodofPaymentFieldView;
                cboMethodofPaymentField.ValueMember = "Key";
                cboMethodofPaymentField.DisplayMember = "Value";
                cboMethodofPaymentField.SelectedIndex = -1;

                var _ValueDateFieldView = new BindingList<KeyValuePair<string, string>>();
                _ValueDateFieldView.Add(new KeyValuePair<string, string>("V", "Visible"));
                _ValueDateFieldView.Add(new KeyValuePair<string, string>("D", "Disabled"));
                _ValueDateFieldView.Add(new KeyValuePair<string, string>("X", "Not Visible"));
                cboValueDateField.DataSource = _ValueDateFieldView;
                cboValueDateField.ValueMember = "Key";
                cboValueDateField.DisplayMember = "Value";
                cboValueDateField.SelectedIndex = -1;

                var _NarrativeFlag = new BindingList<KeyValuePair<string, string>>();
                _NarrativeFlag.Add(new KeyValuePair<string, string>("S", "Screen"));
                _NarrativeFlag.Add(new KeyValuePair<string, string>("E", "Extendend"));
                cboNarrativeFlag.DataSource = _NarrativeFlag;
                cboNarrativeFlag.ValueMember = "Key";
                cboNarrativeFlag.DisplayMember = "Value"; 

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

                InitializeControls();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
        private void InitializeControls()
        {

            try
            {
                if (txn.ShortCode != null)
                {
                    txtShortCode.Text = txn.ShortCode;
                }
                if (txn.Description != null)
                {
                    txtDescription.Text = txn.Description;
                }
                if (txn.DebitCredit != null)
                {
                    cboDebitCredit.SelectedValue = txn.DebitCredit.Trim();
                }
                if (txn.DefaultDebitNarrative != null)
                {
                    txtDefaultDebitNarrative.Text = txn.DefaultDebitNarrative;
                }
                if (txn.DefaultCreditNarrative != null)
                {
                    txtDefaultCreditNarrative.Text = txn.DefaultCreditNarrative;
                }
                if (txn.TxnTypeView != null)
                {
                    cboTxnView.SelectedValue = txn.TxnTypeView;
                }
                if (txn.CommissionType != null)
                {
                    txtCommissionType.Text = txn.CommissionType;
                }
                if (txn.FlatRate != null)
                {
                    txtFlatRate.Text = txn.FlatRate.ToString();
                }
                if (txn.PercentageRate != null)
                {
                    txtPercentage.Text = txn.PercentageRate.ToString();
                }
                if (txn.DialogFlag != null)
                {
                    txtDialogFlag.Text = txn.DialogFlag;
                }
                if (txn.NarrativeFlag != null)
                {
                    cboNarrativeFlag.SelectedValue = txn.NarrativeFlag;
                }
                #region "Defaults"
                if (txn.UseDefaultAmount != null)
                {
                    chkUseDefaultAmount.Checked = txn.UseDefaultAmount.Value;
                }
                if (txn.DefaultAmount != null)
                {
                    txtDefaultAmount.Text = txn.DefaultAmount.ToString();
                }
                if (txn.UseDefaultCreditAccount != null)
                {
                    chkUseDefaultCreditAccount.Checked = txn.UseDefaultCreditAccount.Value;
                }
                if (txn.DefaultCreditAccount != null)
                {
                    txtDefaultCreditAccount.Text = txn.DefaultCreditAccount.ToString();
                }
                if (txn.UseDefaultDebitAccount != null)
                {
                    chkUseDefaultDebitAccount.Checked = txn.UseDefaultDebitAccount.Value;
                }
                if (txn.DefaultDebitAccount != null)
                {
                    txtDefaultDebitAccount.Text = txn.DefaultDebitAccount.ToString();
                }
                if (txn.UseDefaultCreditNarrative != null)
                {
                    chkUseDefaultCreditNarrative.Checked = txn.UseDefaultCreditNarrative.Value;
                }
                if (txn.DefaultCreditNarrative != null)
                {
                    txtDefaultCreditNarrative.Text = txn.DefaultCreditNarrative.ToString();
                }
                if (txn.UseDefaultDebitNarrative != null)
                {
                    chkUseDefaultDebitNarrative.Checked = txn.UseDefaultDebitNarrative.Value;
                }
                if (txn.DefaultDebitNarrative != null)
                {
                    txtDefaultDebitNarrative.Text = txn.DefaultDebitNarrative.ToString();
                }
                #endregion "Defaults"
                #region "Views"
                if (txn.ScreenViewCreditAccountField != null)
                {
                    cboCreditAccountField.SelectedValue = txn.ScreenViewCreditAccountField;
                }
                if (txn.ScreenViewCreditNarrativeField != null)
                {
                    cboCreditNarrativeField.SelectedValue = txn.ScreenViewCreditNarrativeField;
                }
                if (txn.ScreenViewDebitAccountField != null)
                {
                    cboDebitAccountField.SelectedValue = txn.ScreenViewDebitAccountField;
                }
                if (txn.ScreenViewDebitNarrativeField != null)
                {
                    cboDebitNarrativeField.SelectedValue = txn.ScreenViewDebitNarrativeField;
                }
                if (txn.ScreenViewAmountField != null)
                {
                    cboAmountField.SelectedValue = txn.ScreenViewAmountField;
                }
                if (txn.ScreenViewModeofPaymentField != null)
                {
                    cboMethodofPaymentField.SelectedValue = txn.ScreenViewModeofPaymentField;
                }
                if (txn.ScreenViewValueDateField != null)
                {
                    cboValueDateField.SelectedValue = txn.ScreenViewValueDateField;
                }
                #endregion "Views"
                #region "Receipts"
                if (txn.PrintReceipt != null)
                {
                    chkPrintReceipts.Checked = txn.PrintReceipt.Value;
                }
                if (txn.ReceiptLayout != null)
                {
                    txtReceiptLayout.Text = txn.ReceiptLayout.ToString();
                }
                if (txn.PrintReceiptPrompt != null)
                {
                    chkPrintReceiptPrompt.Checked = txn.PrintReceiptPrompt.Value;
                }
                #endregion "Receipts"
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public bool IsTransactionTypeValid()
        {
            bool noerror = true;
            if (string.IsNullOrEmpty(txtShortCode.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtShortCode, "Short Code cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDescription, "Description cannot be null!");
                return false;
            }
            if (cboDebitCredit.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboDebitCredit, "Select Debit/Credit!");
                return false;
            }
            if (cboTxnView.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboTxnView, "Select Transaction Type View!");
                return false;
            }
            int _craccid;
            if (!string.IsNullOrEmpty(txtDefaultCreditAccount.Text) && int.TryParse(txtDefaultCreditAccount.Text, out _craccid))
            {
                Account _craccount = rep.GetAccount(_craccid);
                if (_craccount == null)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtDefaultCreditAccount, "Error Retrieving Account!");
                    return false;
                }
            }
            int _draccid;
            if (!string.IsNullOrEmpty(txtDefaultDebitAccount.Text) && int.TryParse(txtDefaultDebitAccount.Text, out _draccid))
            {
                Account _draccount = rep.GetAccount(_draccid);
                if (_draccount == null)
                {
                    errorProvider1.Clear();
                    errorProvider1.SetError(txtDefaultDebitAccount, "Error Retrieving Account!");
                    return false;
                }
            }
            return noerror;
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsTransactionTypeValid())
            {
                try
                {
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

                    rep.UpdateTransactionType(txn);

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
        /*public method to diable all controls when form is called by parent from 'View Details' button*/
        public void DisableControls()
        {

            #region "Txn Info"
            txtShortCode.Enabled = false;
            txtDescription.Enabled = false;
            cboDebitCredit.Enabled = false;
            cboTxnView.Enabled = false;
            txtCommissionType.Enabled = false;
            txtFlatRate.Enabled = false;
            txtPercentage.Enabled = false;
            txtDialogFlag.Enabled = false;
            cboNarrativeFlag.Enabled = false;
            #endregion "Txn Info"
            #region "Defaults"
            chkUseDefaultAmount.Enabled = false;
            txtDefaultAmount.Enabled = false;
            chkUseDefaultCreditAccount.Enabled = false;
            txtDefaultCreditAccount.Enabled = false;
            chkUseDefaultDebitAccount.Enabled = false;
            txtDefaultDebitAccount.Enabled = false;
            chkUseDefaultCreditNarrative.Enabled = false;
            txtDefaultCreditNarrative.Enabled = false;
            chkUseDefaultDebitNarrative.Enabled = false;
            txtDefaultDebitNarrative.Enabled = false;
            btnSearchDefaultCrAcc.Enabled = false;
            btnSearchDefaultDrAcc.Enabled = false;
            #endregion "Defaults"
            #region "Views"            
            cboValueDateField.Enabled = false;
            cboCreditAccountField.Enabled = false;
            cboCreditNarrativeField.Enabled = false; 
            cboDebitAccountField.Enabled = false; 
            cboDebitNarrativeField.Enabled = false;
            cboAmountField.Enabled = false;
            cboMethodofPaymentField.Enabled = false;
            cboValueDateField.Enabled = false;
            #endregion "Views"
            #region "Receipts"
            chkPrintReceipts.Enabled = false;
            txtReceiptLayout.Enabled = false;
            chkPrintReceiptPrompt.Enabled = false;
            txtText.Enabled = false;
            btnAddField.Enabled = false;
            btnAddNewLine.Enabled = false;
            btnText.Enabled = false;
            btnClear.Enabled = false;
            #endregion "Receipts"
            btnSave.Enabled = false;
            btnSave.Visible = false;
            btnClose.Location = btnSave.Location;
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnSearchDefaultCrAcc_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountsSimpleForm saf = new Forms.SearchAccountsSimpleForm(connection) { Owner = this };
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
                SearchAccountsSimpleForm saf = new Forms.SearchAccountsSimpleForm(connection) { Owner = this };
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
        private void f_OnReceiptItemListSelected(object sender, ReceiptItemEventArgs e)
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

    }
}
