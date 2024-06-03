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
using System.Threading;

namespace WinSBSchool.Post
{
    public partial class UserControlSinglePost : UserControl
    {
        private StreamReader streamToPrint;
        private Font printFont;
        TransactionType TType;
        string user;
        string connection;
        List<Transaction> transactions;
        School school;
        string receiptNo;
        SBSchoolDBEntities db;
        Repository rep;
        Account DrAccountBeforePosting;
        Account CrAccountBeforePosting;
        Account DrAccountAfterPosting;
        Account CrAccountAfterPosting;
        Transaction DebitTransaction;
        Transaction CreditTransaction;
        decimal Amount;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;


        public UserControlSinglePost(TransactionType ttype, string _user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
        {

            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new ThreadExceptionEventHandler(ThreadException);

            TAG = this.GetType().Name;

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname = notificationmessageEventname;

            if (Conn == null)
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (ttype == null)
            {
                throw new ArgumentNullException("Type");
            }
            TType = ttype;
            user = _user;
            transactions = new List<Transaction>();
            var _Schoolquery = (from sc in db.Schools
                                where sc.DefaultSchool == true
                                select sc).FirstOrDefault();
            School _School = _Schoolquery;
            school = _School;

            //initialize variables for printing 

            //configure the screen
            ConfigureScreen();

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished UserControlSinglePost initialization", TAG));

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

        private void UserControlSinglePost_Load(object sender, EventArgs e)
        {
            try
            {
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

                this.tableLayoutPanelSPost.RowStyles[10].Height = 0;
                this.tableLayoutPanelSPost.RowStyles[11].Height = 0;

                AutoCompleteStringCollection acscyr = new AutoCompleteStringCollection();
                acscyr.AddRange(this.AutoComplete_DrAccountIds());
                txtDrAccount.AutoCompleteCustomSource = acscyr;
                txtDrAccount.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtDrAccount.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                AutoCompleteStringCollection acsctrm = new AutoCompleteStringCollection();
                acsctrm.AddRange(this.AutoComplete_CrAccountIds());
                txtCrAccount.AutoCompleteCustomSource = acsctrm;
                txtCrAccount.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtCrAccount.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

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

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished UserControlSinglePost load", TAG));

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
        private void ConfigureScreen()
        {
            //use the transaction type to hide/show various controls e.g.
            //use the transaction type to set up various control defaults on the screen
            switch (TType.ScreenViewCreditAccountField)
            {
                case "V": //the field is visible; Visible=true
                    break;
                case "D": //the field is visible but Enabled=false
                    txtCrAccount.Enabled = false;
                    btnSelectCrAccount.Enabled = false;
                    break;
                case "X": //Not visible
                    lblCrAccountDetails.Visible = false;
                    lblCreditAccount.Visible = false;
                    btnSelectCrAccount.Visible = false;
                    txtCrAccount.Visible = false;
                    groupBoxCreditAccount.Visible = false;
                    this.tableLayoutPanelSPost.RowStyles[7].Height = 0;
                    break;
            }
            switch (TType.ScreenViewCreditNarrativeField)
            {
                case "V": //the field is visible; Visible=true
                    break;
                case "D": //the field is visible but Enabled=false
                    txtCrNarrative.Enabled = false;
                    break;
                case "X": //Not visible
                    lblCrNarrative.Visible = false;
                    txtCrNarrative.Visible = false;
                    groupBoxCrNarrative.Visible = false;
                    this.tableLayoutPanelSPost.RowStyles[6].Height = 0;
                    break;
            }
            switch (TType.ScreenViewDebitAccountField)
            {
                case "V": //the field is visible; Visible=true
                    break;
                case "D": //the field is visible but Enabled=false
                    txtDrAccount.Enabled = false;
                    btnSelectDrAccount.Enabled = false;
                    break;
                case "X": //Not visible
                    lblDebitAccount.Visible = false;
                    lblDrAccountDetails.Visible = false;
                    btnSelectDrAccount.Visible = false;
                    txtDrAccount.Visible = false;
                    groupBoxDrAccount.Visible = false;
                    this.tableLayoutPanelSPost.RowStyles[2].Height = 0;
                    break;
            }
            switch (TType.ScreenViewDebitNarrativeField)
            {
                case "V": //the field is visible; Visible=true
                    break;
                case "D": //the field is visible but Enabled=false
                    txtDebitNarrative.Enabled = false;
                    break;
                case "X": //Not visible
                    lblDrNarrative.Visible = false;
                    txtDebitNarrative.Visible = false;
                    groupBoxDrNarrative.Visible = false;
                    this.tableLayoutPanelSPost.RowStyles[5].Height = 0;
                    break;
            }
            switch (TType.ScreenViewAmountField)
            {
                case "V": //the field is visible; Visible=true
                    break;
                case "D": //the field is visible but Enabled=false
                    txtAmount.Enabled = false;
                    break;
                case "X": //Not visible
                    lblAmount.Visible = false;
                    txtAmount.Visible = false;
                    groupBoxAmount.Visible = false;
                    this.tableLayoutPanelSPost.RowStyles[8].Height = 0;
                    break;
            }
            switch (TType.ScreenViewModeofPaymentField)
            {
                case "V": //the field is visible; Visible=true
                    break;
                case "D": //the field is visible but Enabled=false
                    cboModeofPayment.Enabled = false;
                    break;
                case "X": //Not visible
                    lblModeofPayment.Visible = false;
                    cboModeofPayment.Visible = false;
                    groupBoxModeofPayment.Visible = false;
                    this.tableLayoutPanelSPost.RowStyles[3].Height = 0;
                    break;
            }
            switch (TType.ScreenViewValueDateField)
            {
                case "V": //the field is visible; Visible=true
                    break;
                case "D": //the field is visible but Enabled=false
                    dtpValueDate.Enabled = false;
                    break;
                case "X": //Not visible
                    this.lblValueDate.Visible = false;
                    dtpValueDate.Visible = false;
                    groupBoxValueDate.Visible = false;
                    this.tableLayoutPanelSPost.RowStyles[9].Height = 0;
                    break;
            }

            //use the transaction type to enter default transactions  
            if (TType.UseDefaultAmount.HasValue && TType.UseDefaultAmount.Value == true && TType.DefaultAmount != null)
            {
                txtAmount.Text = TType.DefaultAmount.ToString();
            }
            if (TType.UseDefaultCreditAccount.HasValue && TType.UseDefaultCreditAccount.Value == true && TType.DefaultCreditAccount != null)
            {
                txtCrAccount.Text = TType.DefaultCreditAccount.ToString();
            }
            if (TType.UseDefaultCreditNarrative.HasValue && TType.UseDefaultCreditNarrative.Value == true && TType.DefaultCreditNarrative != null)
            {
                txtCrNarrative.Text = TType.DefaultCreditNarrative.ToString();
            }
            if (TType.UseDefaultDebitAccount.HasValue && TType.UseDefaultDebitAccount.Value == true && TType.DefaultDebitAccount != null)
            {
                txtDrAccount.Text = TType.DefaultDebitAccount.ToString();
            }
            if (TType.UseDefaultDebitNarrative.HasValue && TType.UseDefaultDebitNarrative.Value == true && TType.DefaultDebitNarrative != null)
            {
                txtDebitNarrative.Text = TType.DefaultDebitNarrative.ToString();
            }
        }
        private bool IsTransactionValid()
        {
            bool noerror = true;
            //Debit Account
            if (string.IsNullOrEmpty(txtDrAccount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDrAccount, "Account ID cannot be null!");
                return false;
            }
            int _draccountid;
            if (!int.TryParse(txtDrAccount.Text, out _draccountid))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDrAccount, "Account ID must be integer!");
                return false;
            }

            DrAccountBeforePosting = rep.GetAccount(_draccountid);
            if (null == DrAccountBeforePosting)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtDrAccount, "Error retrieving the account!");
                return false;
            }

            //Credit Account
            if (string.IsNullOrEmpty(txtCrAccount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCrAccount, "Account ID cannot be null!");
                return false;
            }
            int _craccountid;
            if (!int.TryParse(txtCrAccount.Text, out _craccountid))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCrAccount, "Account ID must be integer!");
                return false;
            }

            CrAccountBeforePosting = rep.GetAccount(_craccountid);
            if (null == CrAccountBeforePosting)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtCrAccount, "Error retrieving the account!");
                return false;
            }
            //amount 
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAmount, "Amount cannot be null!");
                return false;
            }

            if (!decimal.TryParse(txtAmount.Text, out Amount))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtAmount, "Amount must be decimal!");
                return false;
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
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtAmount, "Amount cannot be null!");
                            return false;
                        }
                        break;
                    case "M":
                        if (string.IsNullOrEmpty(txtMpesaReceiptNo.Text))
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtMpesaReceiptNo, "Mpesa Receipt No cannot be null!");
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtMpesaAmountPaid.Text))
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtMpesaAmountPaid, "Amount cannot be null!");
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtMpesaSenderName.Text))
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtMpesaSenderName, "Mpesa Sender Name cannot be null!");
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtMpesaPhoneNumber.Text))
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtMpesaPhoneNumber, "Mpesa Phone Number cannot be null!");
                            return false;
                        }
                        break;
                    case "B":
                        if (string.IsNullOrEmpty(txtBankSlipNo.Text))
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtBankSlipNo, "Bank Slip Number cannot be null!");
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtbsBankSortCode.Text))
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtbsBankSortCode, "Bank Sort Code cannot be null!");
                            return false;
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
                                errorProvider1.Clear();
                                errorProvider1.SetError(txtbsBankSortCode, "Bank Sort Code does not exist!");
                                return false;
                            }
                        }
                        break;
                    case "Q":
                        if (string.IsNullOrEmpty(txtChequeNo.Text))
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtChequeNo, "Cheque Number cannot be null!");
                            return false;
                        }
                        if (string.IsNullOrEmpty(txtcqBankSortCode.Text))
                        {
                            errorProvider1.Clear();
                            errorProvider1.SetError(txtcqBankSortCode, "Bank Sort Code cannot be null!");
                            return false;
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
                                errorProvider1.Clear();
                                errorProvider1.SetError(txtcqBankSortCode, "Bank Sort Code does not exist!");
                                return false;
                            }
                        }
                        break;
                }
            }
            return noerror;
        }
        private void btnPost_Click(object sender, EventArgs e)
        {


            /*
             * 1. validate screen input
             * 2. build up transactions 
             * 3. transaction post- dry run to test whether transactions will fail due to
             *  3.1 blocked _Accounts
             *  3.2 account'st financial status - will the transaction overdraw?
             *  3.3 do _Accounts actually exist
             * 4. Post the list 
             *  4.1 Lock all transactions
             *  4.2 Post
             *  4.3 Unlock
             * 5. if(tt.printreceipt == true) Print a reciept according to layout
             */
            errorProvider1.Clear();
            try
            {
                if (IsTransactionValid())
                {
                    //Biuld up transactions 
                    string RawSalt = DateTime.Now.ToString("yMdHms");
                    string HashSalt = HashHelper.CreateRandomSalt();
                    int foundS1 = HashSalt.IndexOf("==");
                    int foundS2 = HashSalt.IndexOf("+");
                    int foundS3 = HashSalt.IndexOf("/");
                    if (foundS1 > 0)
                    {
                        HashSalt = HashSalt.Remove(foundS1);
                    }
                    if (foundS2 > 0)
                    {
                        HashSalt = HashSalt.Remove(foundS2);
                    }
                    if (foundS3 > 0)
                    {
                        HashSalt = HashSalt.Remove(foundS3);
                    }
                    string SaltedHash = RawSalt.Insert(5, HashSalt);
                    string _transRef = SaltedHash;
                    receiptNo = _transRef;

                    //debit transaction
                    DebitTransaction = new Transaction();
                    DebitTransaction.TransactionTypeId = TType.Id;
                    DebitTransaction.AccountId = DrAccountBeforePosting.Id;
                    DebitTransaction.Amount = Amount * -1;

                    var _drAccountquery = (from da in db.Accounts
                                           where da.Id == DebitTransaction.AccountId
                                           select da).FirstOrDefault();
                    DrAccountAfterPosting = _drAccountquery;

                    DebitTransaction.Narrative = BuildNarrative("D");
                    DebitTransaction.UserName = user;
                    DebitTransaction.Authorizer = "SYSTEM";
                    DebitTransaction.StatementFlag = TType.StatementFlag;
                    DebitTransaction.PostDate = DateTime.Now;
                    int valuedays = TType.ValueDays ?? 0;
                    DebitTransaction.ValueDate = DebitTransaction.PostDate.AddDays(valuedays);
                    DebitTransaction.RecordDate = DateTime.Now;
                    DebitTransaction.TransRef = _transRef;

                    transactions.Add(DebitTransaction);

                    //credit transaction 
                    CreditTransaction = new Transaction();
                    CreditTransaction.TransactionTypeId = TType.Id;
                    CreditTransaction.AccountId = CrAccountBeforePosting.Id;
                    CreditTransaction.Amount = Amount;

                    var _crAccountquery = (from ca in db.Accounts
                                           where ca.Id == CreditTransaction.AccountId
                                           select ca).FirstOrDefault();
                    CrAccountAfterPosting = _crAccountquery;

                    CreditTransaction.Narrative = BuildNarrative("C");
                    CreditTransaction.UserName = user;
                    CreditTransaction.Authorizer = "SYSTEM";
                    CreditTransaction.StatementFlag = TType.StatementFlag;
                    CreditTransaction.PostDate = DateTime.Now;
                    valuedays = TType.ValueDays ?? 0;
                    CreditTransaction.ValueDate = CreditTransaction.PostDate.AddDays(valuedays);
                    CreditTransaction.RecordDate = DateTime.Now;
                    CreditTransaction.TransRef = _transRef;

                    transactions.Add(CreditTransaction);

                    //Post transactions
                    try
                    {
                        rep.PostTransactions(transactions);

                        MessageBox.Show("Transactions Posted Successfully!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception exc)
                    {
                        Utils.ShowError(exc);
                        return;
                    }

                    //Print
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
                switch (item.Id)
                {
                    case 0:
                        return DateTime.Now.ToString("d/M/yyyy");
                    case 1:
                        return school.SchoolName;
                    case 2:
                        return school.Address1 + school.Address2;
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
                        return "Student Name";
                    case 10:
                        return "Student Admin No";
                    case 11:
                        return "Class";
                    default:
                        return "Unknown Field";
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string BuildNarrative(string type)
        {
            try
            {
                string narr = string.Empty;
                if ("D".Equals(type.ToUpper()))
                {
                    //build debit narrative
                    narr = DrAccountAfterPosting.AccountName;
                    switch (TType.NarrativeFlag)
                    {
                        case "S": //see narrative as per screen input
                            narr += txtDebitNarrative.Text;
                            break;
                        case "E": //see narrative as per screen input + account name
                            narr += txtDebitNarrative.Text + " - " + DrAccountAfterPosting.AccountName;
                            break;
                    }

                }
                else
                {
                    //build a credit narrative
                    narr = CrAccountAfterPosting.AccountName;
                    switch (TType.NarrativeFlag)
                    {
                        case "S": //see narrative as per screen input
                            narr += txtCrNarrative.Text;
                            break;
                        case "E": //see narrative as per screen input + account name
                            narr += txtCrNarrative.Text + " -  " + CrAccountAfterPosting.AccountName;
                            break;
                    }
                }
                return narr;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
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
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    throw new Exception("Exception Occured While Printing", ex);
                }
                //streamToPrint = new StreamReader ("C:\\MyFile.txt");
                //try
                //{
                //    printFont = new Font("Arial", 10);
                //    PrintDocument pd = new PrintDocument();
                //    pd.PrintPage += new PrintPageEventHandler
                //       (this.pd_PrintPage);
                //    pd.Print();
                //}
                //finally
                //{
                //    streamToPrint.Close();
                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
                    tableLayoutPanelSPost.SetRow(groupBoxMpesa, 3);
                    tableLayoutPanelSPost.SetColumn(groupBoxMpesa, 1);
                    groupBoxCheque.Visible = false;
                    groupBoxBankSlip.Visible = false;
                    break;
                case "B":
                    groupBoxBankSlip.Visible = true;
                    tableLayoutPanelSPost.SetRow(groupBoxBankSlip, 3);
                    tableLayoutPanelSPost.SetColumn(groupBoxBankSlip, 1);
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
        private void btnSelectDrAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm();
                SearchAccountsSimpleForm saf = new SearchAccountsSimpleForm(connection) { Owner = myForm };
                saf.OnAccountListSelected += new SearchAccountsSimpleForm.AccountSelectHandler(saf_OnDrAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnDrAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetDrAccountId(e._Account);
        }
        private void SetDrAccountId(Account _Account)
        {
            if (_Account != null)
            {
                txtDrAccount.Text = _Account.Id.ToString();
                lblDrAccountDetails.Text = "[" + _Account.AccountNo + " ]  -  [ " + _Account.AccountName.Trim() + " ]   Book Balance:  " + _Account.BookBalance.ToString("C2");
            }

        }
        private void btnSelectCrAccount_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm();
                SearchAccountsSimpleForm saf = new SearchAccountsSimpleForm(connection) { Owner = myForm };
                saf.OnAccountListSelected += new SearchAccountsSimpleForm.AccountSelectHandler(saf_OnCrAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void saf_OnCrAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetCrAccountId(e._Account);
        }
        private void SetCrAccountId(Account _Account)
        {
            if (_Account != null)
            {
                txtCrAccount.Text = _Account.Id.ToString();
                lblCrAccountDetails.Text = "[" + _Account.AccountNo + " ]  -  [ " + _Account.AccountName.Trim() + " ]   Book Balance:  " + _Account.BookBalance.ToString("C2");
            }

        }
        private void btnSearchchequeBank_Click(object sender, EventArgs e)
        {
            try
            {
                Form myForm = this.FindForm();
                SearchBanksSimpleForm saf = new Forms.SearchBanksSimpleForm(connection) { Owner = myForm };
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
                Form myForm = this.FindForm();
                SearchBanksSimpleForm saf = new Forms.SearchBanksSimpleForm(connection) { Owner = myForm };
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
        private void txtDrAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }
        private void txtDrAccount_KeyDown(object sender, KeyEventArgs e)
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
        private void txtCrAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }
        private void txtCrAccount_KeyDown(object sender, KeyEventArgs e)
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
            if (nonNumberEntered == true)
            {
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
        private void txtDrAccount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblDrAccountDetails.Text = string.Empty;
                int _accountid = 0;
                if (int.TryParse(txtDrAccount.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblDrAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtDrAccount_Validated(object sender, EventArgs e)
        {
            try
            {
                lblDrAccountDetails.Text = string.Empty;
                int _accountid = 0;
                if (int.TryParse(txtDrAccount.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblDrAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtDrAccount_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblDrAccountDetails.Text = string.Empty;
                int _accountid = 0;
                if (int.TryParse(txtDrAccount.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblDrAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtDrAccount_Leave(object sender, EventArgs e)
        {
            try
            {
                lblDrAccountDetails.Text = string.Empty;
                int _accountid = 0;
                if (int.TryParse(txtDrAccount.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblDrAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtCrAccount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblCrAccountDetails.Text = string.Empty;
                int _accountid = 0;
                if (int.TryParse(txtCrAccount.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblCrAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtCrAccount_Validated(object sender, EventArgs e)
        {
            try
            {
                lblCrAccountDetails.Text = string.Empty;
                int _accountid = 0;
                if (int.TryParse(txtCrAccount.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblCrAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtCrAccount_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblCrAccountDetails.Text = string.Empty;
                int _accountid = 0;
                if (int.TryParse(txtCrAccount.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblCrAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtCrAccount_Leave(object sender, EventArgs e)
        {
            try
            {
                lblCrAccountDetails.Text = string.Empty;
                int _accountid = 0;
                if (int.TryParse(txtCrAccount.Text.Trim(), out _accountid))
                {
                    var _accountqueryquery = (from ac in db.Accounts
                                              where ac.Id == _accountid
                                              select ac).FirstOrDefault();
                    if (_accountqueryquery != null)
                    {
                        lblCrAccountDetails.Text = "[" + _accountqueryquery.AccountNo + " ]  -  [ " + _accountqueryquery.AccountName.Trim() + " ]   Book Balance:  " + _accountqueryquery.BookBalance.ToString("C2");
                    }
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
        private void txtcqBankSortCode_Validated(object sender, EventArgs e)
        {
            try
            {
                lblSlipBankSortCodeDetails.Text = string.Empty;
                string _banksortcode = txtcqBankSortCode.Text.Trim();
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
        private void txtcqBankSortCode_TabIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblSlipBankSortCodeDetails.Text = string.Empty;
                string _banksortcode = txtcqBankSortCode.Text.Trim();
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
        private void txtcqBankSortCode_Leave(object sender, EventArgs e)
        {
            try
            {
                lblSlipBankSortCodeDetails.Text = string.Empty;
                string _banksortcode = txtcqBankSortCode.Text.Trim();
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
        private void txtbsBankSortCode_Validated(object sender, EventArgs e)
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
        private void txtbsBankSortCode_TabIndexChanged(object sender, EventArgs e)
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
        private void txtbsBankSortCode_Leave(object sender, EventArgs e)
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
        private void btnSMSGateWay_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Form _parentForm = this.FindForm();
                ReceivedSmsMessagesForm rsmf = new ReceivedSmsMessagesForm(user, connection) { Owner = _parentForm };
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
        private void txtMpesaAmountPaid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }
        private void txtMpesaAmountPaid_KeyDown(object sender, KeyEventArgs e)
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


































    }
}
