using System; 
using System.Collections.Generic; 
using System.ComponentModel;
using System.Configuration; 
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing; 
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using CommonLib; 
using DAL;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace WinSBSchool.Forms
{
    public partial class ReceivedSmsMessagesForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string _user;
        string connection;
        List<GSMMessage> _smsMessages;
        //delegate
        public delegate void ReceivedSmsMessagesSelectHandler(object sender, ReceivedSmsMessagesSelectEventArgs e);
        //event
        public event ReceivedSmsMessagesSelectHandler OnReceivedSmsMessagesSelected;


        public ReceivedSmsMessagesForm(string user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            _user = user;
        } 
         
        public void RefreshGrid()
        {
            try
            {
                if (chkProcessedSms.Checked)
                { 
                    bindingSourceSms.DataSource = null;
                    _smsMessages = new List<GSMMessage>();
                    var _smsquery = from sms in rep.GetAllSmsMessageStores()
                                    where sms.IsDeleted == false
                                    select sms;
                    _smsMessages = _smsquery.ToList();
                    bindingSourceSms.DataSource = _smsMessages.ToList();
                    groupBox2.Text = bindingSourceSms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSms.Rows)
                    {
                        dataGridViewSms.Rows[dataGridViewSms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSms.Rows.Count - 1;
                        bindingSourceSms.Position = nRowIndex;
                    }
                }
                else
                { 
                    bindingSourceSms.DataSource = null;
                    _smsMessages = new List<GSMMessage>();
                    var _smsquery = from sms in rep.GetAllSmsMessageStores()
                                    where sms.Processed == false
                                    where sms.IsDeleted == false
                                    select sms;
                    _smsMessages = _smsquery.ToList();
                    bindingSourceSms.DataSource = _smsMessages.ToList();
                    groupBox2.Text = bindingSourceSms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSms.Rows)
                    {
                        dataGridViewSms.Rows[dataGridViewSms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSms.Rows.Count - 1;
                        bindingSourceSms.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void SmsMessagesForm_Load(object sender, EventArgs e)
        {
            try
            {
                ClearControls();
                _smsMessages = new List<GSMMessage>();
                var _smsquery = from sms in rep.GetAllSmsMessageStores()
                                where sms.Processed == false
                                where sms.IsDeleted == false
                                select sms;
                _smsMessages = _smsquery.ToList();
                bindingSourceSms.DataSource = _smsMessages.ToList();
                groupBox2.Text = bindingSourceSms.Count.ToString();
                dataGridViewSms.AutoGenerateColumns = false;
                dataGridViewSms.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewSms.DataSource = bindingSourceSms;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public bool SaveReceivedSMStoDB()
        {
            try
            {
                //create a modem 
                HuaweiModem modem = new HuaweiModem(connection);
                GSMMessage gsmsms = new GSMMessage();
                List<GSMMessage> _GSMMessagesinDB = rep.GetAllSmsMessageStores();

                List<GSMMessage> _GSMMessagesinSim = modem.GetAllReceivedMessages();

                List<GSMMessage> _GSMMessagesInSimNotInDB = _GSMMessagesinSim.Where(p => !_GSMMessagesinDB.Any(i => i.UserDataText == p.UserDataText && i.OriginatingAddress == p.OriginatingAddress && i.SCTimestamp == p.SCTimestamp)).ToList();

                foreach (var sms in _GSMMessagesInSimNotInDB)
                {
                    rep.AddNewSmsMessageStore(sms);
                }
                return true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
                NotifyMessage(Utils.APP_NAME, ex.Message.ToString().Trim());
                return false;
            }
        }
        public bool NotifyMessage(string _Title, string _Text)
        {
            try
            {
                appNotifyIcon.Text = Utils.APP_NAME;
                appNotifyIcon.Icon = new Icon("Resources/Icons/SchoolStudents.ico");
                appNotifyIcon.BalloonTipIcon = ToolTipIcon.Info;
                appNotifyIcon.BalloonTipTitle = _Title;
                appNotifyIcon.BalloonTipText = _Text;
                appNotifyIcon.Visible = true;
                appNotifyIcon.ShowBalloonTip(900000);

                return true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
                return false;
            }
        }
        private void dataGridViewSms_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btnSubmit_LinkClicked(sender, null);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void chkProcessedSms_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkProcessedSms.Checked)
                {
                    bindingSourceSms.DataSource = null;
                    _smsMessages = new List<GSMMessage>();
                    var _smsquery = from sms in rep.GetAllSmsMessageStores()
                                    where sms.IsDeleted == false
                                    select sms;
                    _smsMessages = _smsquery.ToList();
                    bindingSourceSms.DataSource = _smsMessages.ToList();
                    groupBox2.Text = bindingSourceSms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSms.Rows)
                    {
                        dataGridViewSms.Rows[dataGridViewSms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSms.Rows.Count - 1;
                        bindingSourceSms.Position = nRowIndex;
                    }
                }
                else
                {
                    bindingSourceSms.DataSource = null;
                    _smsMessages = new List<GSMMessage>();
                    var _smsquery = from sms in rep.GetAllSmsMessageStores()
                                    where sms.Processed == false
                                    where sms.IsDeleted == false
                                    select sms;
                    _smsMessages = _smsquery.ToList();
                    bindingSourceSms.DataSource = _smsMessages.ToList();
                    groupBox2.Text = bindingSourceSms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSms.Rows)
                    {
                        dataGridViewSms.Rows[dataGridViewSms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSms.Rows.Count - 1;
                        bindingSourceSms.Position = nRowIndex;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSms_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSms_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewSms.SelectedRows.Count != 0)
                {
                    GSMMessage _sms = (GSMMessage)bindingSourceSms.Current;

                    txtReadMessage.Text = _sms.UserDataText.Trim();
                    lblDate.Text = "Date Sent: " + _sms.SCTimestamp.Trim();
                    lblOriginatingAddressType.Text = "Type: " + _sms.OriginatingAddressType.Trim();
                    lblSmsStorage.Text = "Storage: " + _sms.Storage.Trim();
                }
                if (dataGridViewSms.SelectedRows.Count == 0)
                {
                    ClearControls();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ClearControls()
        {
            try
            {
                txtReadMessage.Text = string.Empty;
                lblDate.Text = string.Empty;
                lblOriginatingAddressType.Text = string.Empty;
                lblSmsStorage.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void txtReadMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = true;
                if (Char.IsLetter(e.KeyChar)) e.Handled = true;
                if (Char.IsNumber(e.KeyChar)) e.Handled = true;
                if (Char.IsPunctuation(e.KeyChar)) e.Handled = true;
                if (Char.IsSurrogate(e.KeyChar)) e.Handled = true;
                if (Char.IsSymbol(e.KeyChar)) e.Handled = true;
                if (Char.IsWhiteSpace(e.KeyChar)) e.Handled = true;
                if (e.KeyChar == (char)Keys.Back) e.Handled = true;
                if (e.KeyChar == (char)Keys.Space) e.Handled = true;
                if (e.KeyChar == (char)Keys.Delete) e.Handled = true;
                if (e.KeyChar == (char)Keys.Clear) e.Handled = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewSms.SelectedRows.Count != 0)
                {
                    GSMMessage _sms = (GSMMessage)bindingSourceSms.Current;

                    txtReadMessage.Text = _sms.UserDataText.Trim();
                    lblDate.Text = "Date Sent: " + _sms.SCTimestamp.Trim();
                    lblOriginatingAddressType.Text = "Type: " + _sms.OriginatingAddressType.Trim();
                    lblSmsStorage.Text = "Storage: " + _sms.Storage.Trim(); 
                }
                if (dataGridViewSms.SelectedRows.Count == 0)
                {
                    ClearControls();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSubmit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewSms.SelectedRows.Count != 0)
                {
                    GSMMessage message = (GSMMessage)bindingSourceSms.Current;

                    //extract phone number, transaction amount, reference number
                    char[] delimiters = new char[] { ' ', '\n', '\r' };
                    string[] messagearray = message.UserDataText.Split(delimiters);

                    string _mpesa_amount = messagearray[Convert.ToInt32(rep.SettingLookup("MPESAAMOUNT"))].ToString();
                    string _firstname = messagearray[Convert.ToInt32(rep.SettingLookup("FIRSTNAME"))].ToString();
                    string _lastname = messagearray[Convert.ToInt32(rep.SettingLookup("LASTNAME"))].ToString();
                    string _phonenumber = messagearray[Convert.ToInt32(rep.SettingLookup("SENDERPHONENUMBER"))].ToString();
                    string _referencenumber = messagearray[Convert.ToInt32(rep.SettingLookup("MPESAREFERENCENUMBER"))].ToString();

                    message.MessageStatus = "Read";
                    message.Processed = true;
                      
                    string[] _amount = System.Text.RegularExpressions.Regex.Split(_mpesa_amount, @"Ksh");
                    decimal txnamount = decimal.Parse(_amount[1]);

                    string _Output = _mpesa_amount + _firstname + _lastname + _phonenumber;
                    foreach (var sms in messagearray)
                    {
                        System.Diagnostics.Debug.WriteLine(sms + Environment.NewLine);
                        _Output += Environment.NewLine + sms + Environment.NewLine;
                    }
                    string _filePath = @"D:\Data\001\testsplitsms.txt";
                    using (System.IO.FileStream aFile = new System.IO.FileStream(_filePath, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite))
                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(aFile))
                    {
                        sw.WriteLine("**********************************************************************");
                        sw.WriteLine(_Output);
                        sw.WriteLine("**********************************************************************");
                    }

                    OnReceivedSmsMessagesSelected(this, new ReceivedSmsMessagesSelectEventArgs(txnamount, _phonenumber, _firstname + "  " + _lastname, _referencenumber));

                    this.Close(); 
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (chkProcessedSms.Checked)
                {
                    SaveReceivedSMStoDB();
                    bindingSourceSms.DataSource = null;
                    _smsMessages = new List<GSMMessage>();
                    var _smsquery = from sms in rep.GetAllSmsMessageStores()
                                    where sms.IsDeleted == false
                                    select sms;
                    _smsMessages = _smsquery.ToList();
                    bindingSourceSms.DataSource = _smsMessages.ToList();
                    groupBox2.Text = bindingSourceSms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSms.Rows)
                    {
                        dataGridViewSms.Rows[dataGridViewSms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSms.Rows.Count - 1;
                        bindingSourceSms.Position = nRowIndex;
                    }
                }
                else
                {
                    SaveReceivedSMStoDB();
                    bindingSourceSms.DataSource = null;
                    _smsMessages = new List<GSMMessage>();
                    var _smsquery = from sms in rep.GetAllSmsMessageStores()
                                    where sms.Processed == false
                                    where sms.IsDeleted == false
                                    select sms;
                    _smsMessages = _smsquery.ToList();
                    bindingSourceSms.DataSource = _smsMessages.ToList();
                    groupBox2.Text = bindingSourceSms.Count.ToString();
                    foreach (DataGridViewRow row in dataGridViewSms.Rows)
                    {
                        dataGridViewSms.Rows[dataGridViewSms.Rows.Count - 1].Selected = true;
                        int nRowIndex = dataGridViewSms.Rows.Count - 1;
                        bindingSourceSms.Position = nRowIndex;
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