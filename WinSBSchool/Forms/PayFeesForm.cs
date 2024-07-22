using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
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
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class PayFeesForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        string receiptNo;
        School school = null;
        Student _Student = null;
        SchoolClass _class = null;
        Account DrAccountBeforePosting;
        Account CrAccountBeforePosting;
        Account DrAccountAfterPosting;
        Account CrAccountAfterPosting;
        Transaction DebitTransaction;
        Transaction CreditTransaction;
        private StreamReader streamToPrint;
        private Font printFont;

        public PayFeesForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            school = rep.GetDefaultSchool();

            if (school == null)
                throw new ArgumentNullException("school is invalid");

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PayFeesForm initialization", TAG));

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
        private void PayFeesForm_Load(object sender, EventArgs e)
        {
            try
            {
                List<TransactionType> transactiontypes = rep.GetAllTransactionTypes();
                cboTransactionType.DataSource = transactiontypes;
                cboTransactionType.ValueMember = "Id";
                cboTransactionType.DisplayMember = "Description";
                int transactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                cboTransactionType.SelectedValue = transactionTypeId;

                //payment            
                var _paymentmodes = new BindingList<KeyValuePair<string, string>>();
                _paymentmodes.Add(new KeyValuePair<string, string>("C", "Cash"));
                _paymentmodes.Add(new KeyValuePair<string, string>("M", "Mpesa"));
                _paymentmodes.Add(new KeyValuePair<string, string>("Q", "Cheque"));
                _paymentmodes.Add(new KeyValuePair<string, string>("B", "Bank Slip"));
                cboModeofPayment.DataSource = _paymentmodes;
                cboModeofPayment.ValueMember = "Key";
                cboModeofPayment.DisplayMember = "Value";

                groupBoxCheque.Visible = false;
                groupBoxMpesa.Visible = false;
                groupBoxBankSlip.Visible = false;

                AutoCompleteStringCollection acscchqBnkSrtCd = new AutoCompleteStringCollection();
                acscchqBnkSrtCd.AddRange(this.AutoComplete_chqBankSortCodes());
                txtcqBankSortCode.AutoCompleteCustomSource = acscchqBnkSrtCd;
                txtcqBankSortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtcqBankSortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acscbsBnkSrtCd = new AutoCompleteStringCollection();
                acscbsBnkSrtCd.AddRange(this.AutoComplete_bsBankSortCodes());
                txtbsBankSortCode.AutoCompleteCustomSource = acscbsBnkSrtCd;
                txtbsBankSortCode.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtbsBankSortCode.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsctrm = new AutoCompleteStringCollection();
                acsctrm.AddRange(this.AutoComplete_AccountIds());
                txtAccountId.AutoCompleteCustomSource = acsctrm;
                txtAccountId.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountId.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                lblAccountDetails.Text = string.Empty;
                lblChequeBankSortCodeDetails.Text = string.Empty;
                lblSlipBankSortCodeDetails.Text = string.Empty;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PayFeesForm load", TAG));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_chqBankSortCodes()
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
        private string[] AutoComplete_bsBankSortCodes()
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
        private string[] AutoComplete_AccountIds()
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
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnPost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (IsTransactionValid())
            {
                try
                {
                    string _Narrative = null;
                    //Build up transactions 
                    string RawSalt = Utils.create_random_salt();
                    //string HashSalt = HashHelper.CreateRandomSalt();
                    //int foundS1 = HashSalt.IndexOf("==");
                    //int foundS2 = HashSalt.IndexOf("+");
                    //int foundS3 = HashSalt.IndexOf("/");
                    //if (foundS1 > 0)
                    //{
                    //    HashSalt = HashSalt.Remove(foundS1);
                    //}
                    //if (foundS2 > 0)
                    //{
                    //    HashSalt = HashSalt.Remove(foundS2);
                    //}
                    //if (foundS3 > 0)
                    //{
                    //    HashSalt = HashSalt.Remove(foundS3);
                    //}
                    //string SaltedHash = RawSalt.Insert(RawSalt.Length, HashSalt);
                    string _transRef = RawSalt;
                    int no_of_characters_in_transaction_reference_no = int.Parse(System.Configuration.ConfigurationManager.AppSettings["NO_OF_CHARACTERS_IN_TRANSACTION_REFERENCE_NO"]);
                    _transRef = _transRef.ToUpper().Substring(0, no_of_characters_in_transaction_reference_no);
                    receiptNo = _transRef;

                    switch (cboModeofPayment.SelectedValue.ToString())
                    {
                        case "C":
                            _Narrative = "Cash Payment";

                            List<Transaction> lstcashtxn = new List<Transaction>();

                            //main transaction
                            Transaction debittxnCash = new Transaction();
                            debittxnCash.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int accschCash = rep.GetCustomerAccountByAccountType("Tuition", school.GLCustomerId);  //_School Account
                            if (accschCash == -1) accschCash = int.Parse(rep.SettingLookup("SUSPCR"));
                            debittxnCash.AccountId = accschCash;
                            debittxnCash.Amount = decimal.Parse(txtAmount.Text) * -1;

                            var _debittxnCash_Accountquery = (from da in db.Accounts
                                                              where da.Id == debittxnCash.AccountId
                                                              select da).FirstOrDefault();
                            DrAccountAfterPosting = _debittxnCash_Accountquery;

                            debittxnCash.Narrative = _Narrative;
                            debittxnCash.UserName = user;
                            debittxnCash.Authorizer = "SYSTEM";
                            debittxnCash.StatementFlag = "D";
                            debittxnCash.PostDate = DateTime.Today;
                            debittxnCash.ValueDate = DateTime.Today;
                            debittxnCash.RecordDate = DateTime.Today;
                            debittxnCash.TransRef = _transRef;
                            debittxnCash.IsDeleted = false;

                            DebitTransaction = debittxnCash;

                            lstcashtxn.Add(debittxnCash);

                            //Contra transaction
                            Transaction credittxnCash = new Transaction();
                            credittxnCash.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int cshaccnt;
                            if (!string.IsNullOrEmpty(txtAccountId.Text) && int.TryParse(txtAccountId.Text, out cshaccnt))
                            {
                                credittxnCash.AccountId = int.Parse(txtAccountId.Text);
                            }
                            credittxnCash.Amount = decimal.Parse(txtAmount.Text);

                            var _credittxnCash_Accountquery = (from ca in db.Accounts
                                                               where ca.Id == credittxnCash.AccountId
                                                               select ca).FirstOrDefault();
                            CrAccountAfterPosting = _credittxnCash_Accountquery;

                            credittxnCash.Narrative = _Narrative;
                            credittxnCash.UserName = user;
                            credittxnCash.Authorizer = "SYSTEM";
                            credittxnCash.StatementFlag = "C";
                            credittxnCash.PostDate = DateTime.Today;
                            credittxnCash.ValueDate = DateTime.Today;
                            credittxnCash.RecordDate = DateTime.Today;
                            credittxnCash.TransRef = _transRef;
                            credittxnCash.IsDeleted = false;

                            CreditTransaction = credittxnCash;

                            lstcashtxn.Add(credittxnCash);

                            rep.PostTransactions(lstcashtxn);

                            MessageBox.Show("Fees Payment Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnPrintReceipt_Click(sender, e);

                            this.Close();
                            break;
                        case "M":
                            _Narrative = "Mpesa Payment =  Receipt No: " + " [ " + txtMpesaReceiptNo.Text + " ] " + " Name: " + " [ " + txtMpesaSenderName.Text + " ] " + " Phone Number: " + " [ " + txtMpesaPhoneNumber.Text + " ]";

                            List<Transaction> lstMpesatxn = new List<Transaction>();

                            //main transaction
                            Transaction debittxnMpesa = new Transaction();
                            debittxnMpesa.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int accschMpesa = rep.GetCustomerAccountByAccountType("Tuition", school.GLCustomerId);  //_School Account
                            if (accschMpesa == -1) accschMpesa = int.Parse(rep.SettingLookup("SUSPCR"));
                            debittxnMpesa.AccountId = accschMpesa;
                            debittxnMpesa.Amount = decimal.Parse(txtAmount.Text) * -1;

                            var _debittxnMpesa_Accountquery = (from da in db.Accounts
                                                               where da.Id == debittxnMpesa.AccountId
                                                               select da).FirstOrDefault();
                            DrAccountAfterPosting = _debittxnMpesa_Accountquery;

                            debittxnMpesa.Narrative = _Narrative;
                            debittxnMpesa.UserName = user;
                            debittxnMpesa.Authorizer = "SYSTEM";
                            debittxnMpesa.StatementFlag = "D";
                            debittxnMpesa.PostDate = DateTime.Today;
                            debittxnMpesa.ValueDate = DateTime.Today;
                            debittxnMpesa.RecordDate = DateTime.Today;
                            debittxnMpesa.TransRef = _transRef;
                            debittxnMpesa.IsDeleted = false;

                            DebitTransaction = debittxnMpesa;

                            lstMpesatxn.Add(debittxnMpesa);

                            //Contra transaction
                            Transaction credittxnMpesa = new Transaction();
                            credittxnMpesa.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int mpsaccnt;
                            if (!string.IsNullOrEmpty(txtAccountId.Text) && int.TryParse(txtAccountId.Text, out mpsaccnt))
                            {
                                credittxnMpesa.AccountId = int.Parse(txtAccountId.Text);
                            }
                            credittxnMpesa.Amount = decimal.Parse(txtAmount.Text);

                            var _credittxnMpesa_Accountquery = (from ca in db.Accounts
                                                                where ca.Id == credittxnMpesa.AccountId
                                                                select ca).FirstOrDefault();
                            CrAccountAfterPosting = _credittxnMpesa_Accountquery;

                            credittxnMpesa.Narrative = _Narrative;
                            credittxnMpesa.UserName = user;
                            credittxnMpesa.Authorizer = "SYSTEM";
                            credittxnMpesa.StatementFlag = "C";
                            credittxnMpesa.PostDate = DateTime.Today;
                            credittxnMpesa.ValueDate = DateTime.Today;
                            credittxnMpesa.RecordDate = DateTime.Today;
                            credittxnMpesa.TransRef = _transRef;
                            credittxnMpesa.IsDeleted = false;

                            CreditTransaction = credittxnMpesa;

                            lstMpesatxn.Add(credittxnMpesa);

                            rep.PostTransactions(lstMpesatxn);

                            MessageBox.Show("Fees Payment Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnPrintReceipt_Click(sender, e);

                            this.Close();
                            break;
                        case "B":
                            _Narrative = "Bank Slip Payment - Slip No : [ " + txtBankSlipNo.Text + " ]   Bank Sort Code :  [ " + txtbsBankSortCode.Text + " ] ";

                            List<Transaction> lstBankSliptxn = new List<Transaction>();

                            //main transaction
                            Transaction debittxnBankSlip = new Transaction();
                            debittxnBankSlip.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int accschBankSlip = rep.GetCustomerAccountByAccountType("Tuition", school.GLCustomerId);  //_School Account
                            if (accschBankSlip == -1) accschBankSlip = int.Parse(rep.SettingLookup("SUSPCR"));
                            debittxnBankSlip.AccountId = accschBankSlip;
                            debittxnBankSlip.Amount = decimal.Parse(txtAmount.Text) * -1;

                            var _debittxnBankSlip_Accountquery = (from da in db.Accounts
                                                                  where da.Id == debittxnBankSlip.AccountId
                                                                  select da).FirstOrDefault();
                            DrAccountAfterPosting = _debittxnBankSlip_Accountquery;

                            debittxnBankSlip.Narrative = _Narrative;
                            debittxnBankSlip.UserName = user;
                            debittxnBankSlip.Authorizer = "SYSTEM";
                            debittxnBankSlip.StatementFlag = "D";
                            debittxnBankSlip.PostDate = DateTime.Today;
                            debittxnBankSlip.ValueDate = DateTime.Today;
                            debittxnBankSlip.RecordDate = DateTime.Today;
                            debittxnBankSlip.TransRef = _transRef;
                            debittxnBankSlip.IsDeleted = false;

                            DebitTransaction = debittxnBankSlip;

                            lstBankSliptxn.Add(debittxnBankSlip);

                            //Contra transaction
                            Transaction credittxnBankSlip = new Transaction();
                            credittxnBankSlip.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int bnkslpaccnt;
                            if (!string.IsNullOrEmpty(txtAccountId.Text) && int.TryParse(txtAccountId.Text, out bnkslpaccnt))
                            {
                                credittxnBankSlip.AccountId = int.Parse(txtAccountId.Text);
                            }
                            credittxnBankSlip.Amount = decimal.Parse(txtAmount.Text);

                            var _credittxnBankSlip_Accountquery = (from ca in db.Accounts
                                                                   where ca.Id == credittxnBankSlip.AccountId
                                                                   select ca).FirstOrDefault();
                            CrAccountAfterPosting = _credittxnBankSlip_Accountquery;

                            credittxnBankSlip.Narrative = _Narrative;
                            credittxnBankSlip.UserName = user;
                            credittxnBankSlip.Authorizer = "SYSTEM";
                            credittxnBankSlip.StatementFlag = "C";
                            credittxnBankSlip.PostDate = DateTime.Today;
                            credittxnBankSlip.ValueDate = DateTime.Today;
                            credittxnBankSlip.RecordDate = DateTime.Today;
                            credittxnBankSlip.TransRef = _transRef;
                            credittxnBankSlip.IsDeleted = false;

                            CreditTransaction = credittxnBankSlip;

                            lstBankSliptxn.Add(credittxnBankSlip);

                            rep.PostTransactions(lstBankSliptxn);

                            MessageBox.Show("Fees Payment Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnPrintReceipt_Click(sender, e);

                            this.Close();
                            break;
                        case "Q":
                            _Narrative = "Cheque Payment =  Cheque No: [ " + txtChequeNo.Text + " ]  Bank Sort Code:  [ " + txtcqBankSortCode.Text + " ] ";

                            List<Transaction> lstChequetxn = new List<Transaction>();

                            //main transaction
                            Transaction debittxnCheque = new Transaction();
                            debittxnCheque.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int accschCheque = rep.GetCustomerAccountByAccountType("Tuition", school.GLCustomerId);  //_School Account
                            if (accschCheque == -1) accschCheque = int.Parse(rep.SettingLookup("SUSPCR"));
                            debittxnCheque.AccountId = accschCheque;
                            debittxnCheque.Amount = decimal.Parse(txtAmount.Text) * -1;

                            var _debittxnCheque_Accountquery = (from da in db.Accounts
                                                                where da.Id == debittxnCheque.AccountId
                                                                select da).FirstOrDefault();
                            DrAccountAfterPosting = _debittxnCheque_Accountquery;

                            debittxnCheque.Narrative = _Narrative;
                            debittxnCheque.UserName = user;
                            debittxnCheque.Authorizer = "SYSTEM";
                            debittxnCheque.StatementFlag = "D";
                            debittxnCheque.PostDate = DateTime.Today;
                            debittxnCheque.ValueDate = DateTime.Today;
                            debittxnCheque.RecordDate = DateTime.Today;
                            debittxnCheque.TransRef = _transRef;
                            debittxnCheque.IsDeleted = false;

                            DebitTransaction = debittxnCheque;

                            lstChequetxn.Add(debittxnCheque);

                            //Contra transaction
                            Transaction credittxnCheque = new Transaction();
                            credittxnCheque.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                            int chqaccnt;
                            if (!string.IsNullOrEmpty(txtAccountId.Text) && int.TryParse(txtAccountId.Text, out chqaccnt))
                            {
                                credittxnCheque.AccountId = int.Parse(txtAccountId.Text);
                            }
                            credittxnCheque.Amount = decimal.Parse(txtAmount.Text);

                            var _credittxnCheque_Accountquery = (from ca in db.Accounts
                                                                 where ca.Id == credittxnCheque.AccountId
                                                                 select ca).FirstOrDefault();
                            CrAccountAfterPosting = _credittxnCheque_Accountquery;

                            credittxnCheque.Narrative = _Narrative;
                            credittxnCheque.UserName = user;
                            credittxnCheque.Authorizer = "SYSTEM";
                            credittxnCheque.StatementFlag = "C";
                            credittxnCheque.PostDate = DateTime.Today;
                            credittxnCheque.ValueDate = DateTime.Today;
                            credittxnCheque.RecordDate = DateTime.Today;
                            credittxnCheque.TransRef = _transRef;
                            credittxnCheque.IsDeleted = false;

                            CreditTransaction = credittxnCheque;

                            lstChequetxn.Add(credittxnCheque);

                            rep.PostTransactions(lstChequetxn);

                            MessageBox.Show("Fees Payment Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnPrintReceipt_Click(sender, e);

                            this.Close();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private bool IsTransactionValid()
        {
            bool noerror = true;
            if (cboTransactionType.SelectedIndex == -1)
            {
                errorProvider.SetError(cboTransactionType, "Select Transaction Type!");
                noerror = false;
            }
            if (cboModeofPayment.SelectedIndex == -1)
            {
                errorProvider.SetError(cboModeofPayment, "Select Mode of Payment!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtAccountId.Text))
            {
                errorProvider.SetError(txtAccountId, "Account Id cannot be null!");
                noerror = false;
            }
            int _accountid;
            if (!int.TryParse(txtAccountId.Text, out _accountid))
            {
                errorProvider.SetError(txtAccountId, "Account Id must be integer!");
                noerror = false;
            }
            var AccountBeforePosting = rep.GetAccount(_accountid);
            if (null == AccountBeforePosting)
            {
                errorProvider.SetError(txtAccountId, "Error retrieving the account!");
                noerror = false;
            }
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                errorProvider.SetError(txtAmount, "Amount cannot be null!");
                noerror = false;
            }
            decimal _amount;
            if (!decimal.TryParse(txtAmount.Text, out _amount))
            {
                errorProvider.SetError(txtAmount, "Amount must be decimal!");
                noerror = false;
            }
            if (cboModeofPayment.SelectedIndex != -1)
            {
                KeyValuePair<string, string> _selectedmodeofpayment
    = (KeyValuePair<string, string>)cboModeofPayment.SelectedItem;

                switch (_selectedmodeofpayment.Key)
                {
                    case "C":
                        if (string.IsNullOrEmpty(txtAmount.Text))
                        {
                            errorProvider.SetError(txtAmount, "Amount cannot be null!");
                            noerror = false;
                        }
                        break;
                    case "M":
                        if (string.IsNullOrEmpty(txtMpesaReceiptNo.Text))
                        {
                            errorProvider.SetError(txtMpesaReceiptNo, "Mpesa Receipt No cannot be null!");
                            noerror = false;
                        }
                        if (string.IsNullOrEmpty(txtMpesaAmountPaid.Text))
                        {
                            errorProvider.SetError(txtMpesaAmountPaid, "Amount cannot be null!");
                            noerror = false;
                        }
                        if (string.IsNullOrEmpty(txtMpesaSenderName.Text))
                        {
                            errorProvider.SetError(txtMpesaSenderName, "Mpesa Sender Name cannot be null!");
                            noerror = false;
                        }
                        if (string.IsNullOrEmpty(txtMpesaPhoneNumber.Text))
                        {
                            errorProvider.SetError(txtMpesaPhoneNumber, "Mpesa Phone Number cannot be null!");
                            noerror = false;
                        }
                        break;
                    case "B":
                        if (string.IsNullOrEmpty(txtBankSlipNo.Text))
                        {
                            errorProvider.SetError(txtBankSlipNo, "Bank Slip Number cannot be null!");
                            noerror = false;
                        }
                        if (string.IsNullOrEmpty(txtbsBankSortCode.Text))
                        {
                            errorProvider.SetError(txtbsBankSortCode, "Bank Sort Code cannot be null!");
                            noerror = false;
                        }
                        if (!string.IsNullOrEmpty(txtbsBankSortCode.Text))
                        {
                            string _banksortcode = txtbsBankSortCode.Text.Trim();
                            var _branchquery = (from bb in rep.GetBankBranchList()
                                                where bb.BankSortCode == _banksortcode
                                                select bb).FirstOrDefault();
                            BankBranch _branch = _branchquery;
                            if (_branch == null)
                            {
                                errorProvider.SetError(txtbsBankSortCode, "Bank Sort Code does not exist!");
                                noerror = false;
                            }
                        }
                        break;
                    case "Q":
                        if (string.IsNullOrEmpty(txtChequeNo.Text))
                        {
                            errorProvider.SetError(txtChequeNo, "Cheque Number cannot be null!");
                            noerror = false;
                        }
                        if (string.IsNullOrEmpty(txtcqBankSortCode.Text))
                        {
                            errorProvider.SetError(txtcqBankSortCode, "Bank Sort Code cannot be null!");
                            noerror = false;
                        }
                        if (!string.IsNullOrEmpty(txtcqBankSortCode.Text))
                        {
                            string _banksortcode = txtcqBankSortCode.Text.Trim();
                            var _branchquery = (from bb in rep.GetBankBranchList()
                                                where bb.BankSortCode == _banksortcode
                                                select bb).FirstOrDefault();
                            BankBranch _branch = _branchquery;
                            if (_branch == null)
                            {
                                errorProvider.SetError(txtcqBankSortCode, "Bank Sort Code does not exist!");
                                noerror = false;
                            }
                        }
                        break;
                }
            }
            return noerror;
        }
        private bool IsPrintTransactionValid()
        {
            bool noerror = true;
            if (school == null)
            {
                MessageBox.Show("School cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerror = false;
            }
            if (DrAccountAfterPosting == null)
            {
                MessageBox.Show("Debit Account cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerror = false;
            }
            if (CrAccountAfterPosting == null)
            {
                MessageBox.Show("Credit Account cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerror = false;
            }
            if (DebitTransaction == null)
            {
                MessageBox.Show("Debit Transaction cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerror = false;
            }
            if (CreditTransaction == null)
            {
                MessageBox.Show("Credit Transaction cannot be null!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noerror = false;
            }
            return noerror;
        }
        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsPrintTransactionValid())
                {

                    int txntypeid = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                    var txnquery = (from tx in db.TransactionTypes
                                    where tx.Id == txntypeid
                                    select tx).FirstOrDefault();
                    TransactionType TType = txnquery;

                    string Template = TType.ReceiptLayout;

                    if (TType.PrintReceipt == true)
                    {
                        if (TType.PrintReceiptPrompt == true)
                        {
                            if (DialogResult.Yes == MessageBox.Show("Do you want to print", "Print Receipt", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                            {

                                PrintReciept(Template, GetPrintObject());
                            }
                        }
                        else
                        {
                            PrintReciept(Template, GetPrintObject());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private object[] GetPrintObject()
        {
            try
            {
                PrintFields pf = new PrintFields();
                List<PrintField> lpf = pf.GetFieldList();
                List<object> po = new List<object>();
                foreach (var item in lpf)
                {
                    object io = GetItemObject(item);
                    po.Add(io);
                }
                return po.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private object GetItemObject(PrintField item)
        {
            try
            {
                if (CrAccountAfterPosting != null)
                {
                    var _student_query = from st in db.Students
                                         join acc in db.Accounts on st.GLAccountId equals acc.Id
                                         join cst in db.Customers on st.CustomerId equals cst.Id
                                         where st.GLAccountId == CrAccountAfterPosting.Id
                                         select st;
                    _Student = _student_query.FirstOrDefault();
                }

                if (_Student != null)
                {
                    var _classquery = from sc in db.SchoolClasses
                                      join cs in db.ClassStreams on sc.Id equals cs.ClassId
                                      join st in db.Students on cs.Id equals st.ClassStreamId
                                      where st.Id == _Student.Id
                                      select sc;
                    _class = _classquery.FirstOrDefault();
                }

                switch (item.Id)
                {
                    case 0:
                        return DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss ttt");
                    case 1:
                        if (school != null)
                        {
                            return school.SchoolName;
                        }
                        break;
                    case 2:
                        if (school != null)
                        {
                            return school.Address1 + " " + school.Address2;
                        }
                        break;
                    case 3:
                        return receiptNo;
                    case 4:
                        return DrAccountAfterPosting.AccountName;
                    case 5:
                        return CrAccountAfterPosting.AccountName;
                    case 6:
                        return DebitTransaction.Narrative;
                    case 7:
                        return CreditTransaction.Narrative;
                    case 8:
                        return CreditTransaction.Amount;
                    case 9:
                        if (_Student != null)
                        {
                            return _Student.StudentSurName + "  " + _Student.StudentOtherNames;
                        }
                        break;
                    case 10:
                        if (_Student != null)
                        {
                            return _Student.AdminNo;
                        }
                        break;
                    case 11:
                        if (_class != null)
                        {
                            return _class.ClassName;
                        }
                        break;
                    default:
                        return "Unknown Field";
                }
                return "";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void PrintReciept(string ReceiptLayout, object[] PostObject)
        {
            try
            {
                string output = string.Format(ReceiptLayout, PostObject);
                PrintDocument p = new PrintDocument();
                p.PrintPage += delegate(object sender1, PrintPageEventArgs e1)
                {
                    e1.Graphics.DrawString(output,
                        new Font("Arial", 12),
                        new SolidBrush(Color.Black),
                        new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));

                };

                try
                {
                    p.Print();
                }
                catch (Exception ex)
                {
                    throw new Exception("Exception Occured While Printing", ex);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        // The PrintPage event is raised for each page to be printed. 
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            try
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float topMargin = ev.MarginBounds.Top;
                string line = null;

                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height /
                   printFont.GetHeight(ev.Graphics);

                // Print each line of the file. 
                while (count < linesPerPage &&
                   ((line = streamToPrint.ReadLine()) != null))
                {
                    yPos = topMargin + (count *
                       printFont.GetHeight(ev.Graphics));
                    ev.Graphics.DrawString(line, printFont, Brushes.Black,
                       leftMargin, yPos, new StringFormat());
                    count++;
                }

                // If more lines exist, print another page. 
                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
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
        private void cboModeofPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboModeofPayment.SelectedValue.ToString())
            {
                case "Q":
                    groupBoxCheque.Visible = true;
                    groupBoxCheque.Location = groupBoxCheque.Location;
                    groupBoxBankSlip.Visible = false;
                    groupBoxMpesa.Visible = false;
                    break;
                case "M":
                    groupBoxMpesa.Visible = true;
                    groupBoxMpesa.Location = groupBoxCheque.Location;
                    groupBoxCheque.Visible = false;
                    groupBoxBankSlip.Visible = false;
                    break;
                case "B":
                    groupBoxBankSlip.Visible = true;
                    groupBoxBankSlip.Location = groupBoxCheque.Location;
                    groupBoxCheque.Visible = false;
                    groupBoxMpesa.Visible = false;
                    break;
                case "C":
                    groupBoxCheque.Visible = false;
                    groupBoxMpesa.Visible = false;
                    groupBoxBankSlip.Visible = false;
                    break;
            }
        }
        private void btnSearchchequeBank_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBanksSimpleForm saf = new Forms.SearchBanksSimpleForm(connection) { Owner = this };
                saf.OnBankListSelected += new SearchBanksSimpleForm.BankSelectHandler(saf_OnBankChequeListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnBankChequeListSelected(object sender, BankSelectEventArgs e)
        {
            SetChequeBankSortCode(e._BankSortCode);
        }
        private void SetChequeBankSortCode(vwBankBranch _vwBankBranch)
        {
            if (_vwBankBranch != null)
            {
                txtcqBankSortCode.Text = _vwBankBranch.BankSortCode.ToString();
                lblChequeBankSortCodeDetails.Text = _vwBankBranch.BankName.Trim() + " - " + _vwBankBranch.BranchName.Trim();
            }

        }
        private void btnSearchslipBank_Click(object sender, EventArgs e)
        {
            try
            {
                SearchBanksSimpleForm saf = new Forms.SearchBanksSimpleForm(connection) { Owner = this };
                saf.OnBankListSelected += new SearchBanksSimpleForm.BankSelectHandler(saf_OnBankSlipListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnBankSlipListSelected(object sender, BankSelectEventArgs e)
        {
            SetBankSlipSortCode(e._BankSortCode);
        }
        private void SetBankSlipSortCode(vwBankBranch _vwBankBranch)
        {
            if (_vwBankBranch != null)
            {
                txtbsBankSortCode.Text = _vwBankBranch.BankSortCode.Trim();
                lblSlipBankSortCodeDetails.Text = _vwBankBranch.BankName.Trim() + " - " + _vwBankBranch.BranchName.Trim();
            }
        }
        private void txtbsBankSortCode_KeyDown(object sender, KeyEventArgs e)
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
        private void txtbsBankSortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (nonNumberEntered == true)
                {
                    if (e.KeyChar == 13)
                    {
                    }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtcqBankSortCode_KeyDown(object sender, KeyEventArgs e)
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
        private void txtcqBankSortCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (nonNumberEntered == true)
                {
                    if (e.KeyChar == 13)
                    {
                    }
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtbsBankSortCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblSlipBankSortCodeDetails.Text = string.Empty;
                string _banksortcode = txtbsBankSortCode.Text.Trim();
                var bankbranchnamequery = (from vw in db.vwBankBranches
                                           where vw.BankSortCode == _banksortcode
                                           select vw).FirstOrDefault();
                if (bankbranchnamequery != null)
                {
                    lblSlipBankSortCodeDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtcqBankSortCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblChequeBankSortCodeDetails.Text = string.Empty;
                string _banksortcode = txtcqBankSortCode.Text.Trim();
                var bankbranchnamequery = (from vw in db.vwBankBranches
                                           where vw.BankSortCode == _banksortcode
                                           select vw).FirstOrDefault();
                if (bankbranchnamequery != null)
                {
                    lblChequeBankSortCodeDetails.Text = bankbranchnamequery.BankBranchName.Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAccountId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }
        private void txtAccountId_KeyDown(object sender, KeyEventArgs e)
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
        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (nonNumberEntered == true)
                {
                    if (e.KeyChar == 13)
                    {
                    }
                    e.Handled = true;
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
                int _accountid = 0;
                if (int.TryParse(txtAccountId.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
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
                int _accountid = 0;
                if (int.TryParse(txtAccountId.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
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
                int _accountid = 0;
                if (int.TryParse(txtAccountId.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAccountId_Leave(object sender, EventArgs e)
        {
            try
            {
                lblAccountDetails.Text = string.Empty;
                int _accountid = 0;
                if (int.TryParse(txtAccountId.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSMSGateWay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                ReceivedSmsMessagesForm rsmf = new ReceivedSmsMessagesForm(user, connection) { Owner = this };
                rsmf.OnReceivedSmsMessagesSelected += new ReceivedSmsMessagesForm.ReceivedSmsMessagesSelectHandler(rsmf_OnReceivedSmsMessagesSelected);
                rsmf.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void rsmf_OnReceivedSmsMessagesSelected(object sender, ReceivedSmsMessagesSelectEventArgs e)
        {
            try
            {
                SetMpesaPaymentDetails(e.Amount, e.Name, e.PhoneNumber, e.ReferenceNumber);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetMpesaPaymentDetails(decimal Amount, string Name, string PhoneNumber, string ReferenceNumber)
        {
            try
            {
                decimal _amount;
                string _amt = Amount.ToString();
                if (decimal.TryParse(_amt, out _amount))
                {
                    txtMpesaAmountPaid.Text = _amount.ToString();
                }
                if (ReferenceNumber != null)
                {
                    txtMpesaReceiptNo.Text = ReferenceNumber;
                }
                if (Name != null)
                {
                    txtMpesaSenderName.Text = Name;
                }
                if (PhoneNumber != null)
                {
                    txtMpesaPhoneNumber.Text = PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtMpesaAmountPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmount.Text = txtMpesaAmountPaid.Text;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtMpesaAmountPaid.Text = txtAmount.Text;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtAmount_Validated(object sender, EventArgs e)
        {
            try
            {
                txtMpesaAmountPaid.Text = txtAmount.Text;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtMpesaAmountPaid_Validated(object sender, EventArgs e)
        {
            try
            {
                txtAmount.Text = txtMpesaAmountPaid.Text;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void cboTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTransactionType.SelectedItem != null)
            {
                TransactionType TType = (TransactionType)cboTransactionType.SelectedItem;
                if (TType.UseDefaultAmount ?? false)
                    txtAmount.Text = TType.DefaultAmount.ToString();

            }
        }

























    }
}