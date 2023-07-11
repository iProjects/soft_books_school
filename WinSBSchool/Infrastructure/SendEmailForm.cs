using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using CommonLib;
using DAL;
using GsmComm.GsmCommunication;
using GsmComm.Interfaces;
using GsmComm.PduConverter;
using GsmComm.Server;
using Microsoft.Win32;
using Splash; 

namespace WinSBSchool
{
    public partial class SendEmailForm : Form
    {
        #region "private properties"
        private string _email;
        #endregion "private properties"

        public SendEmailForm(string _eml)
        {
            InitializeComponent();

            _email = _eml; 
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SendEmailForm_Load(object sender, EventArgs e)
        {
            try
            {
                InitializeControls();

                chkEnableSsl.Checked = true;

                AutoCompleteStringCollection acscml = new AutoCompleteStringCollection();
                acscml.AddRange(this.AutoComplete_Email());
                txtTo.AutoCompleteCustomSource = acscml;
                txtTo.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtTo.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_Email()
        {
            try
            {
                string auto_complete_email = "Resources/auto_complete_email.xml";
                List<string> logged_emails = new List<string>();
                if (File.Exists(auto_complete_email))
                {
                    List<SBSystem_Exp> successfully_logged_emails = SQLHelper.GetDataFromSBSystem_ExpXML(auto_complete_email);
                    foreach (var item in successfully_logged_emails)
                    {
                        logged_emails.Add(item.Name);
                    }
                }
                return logged_emails.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private bool SaveAutoCompleteEmail(string email, string message)
        {
            try
            {
                string auto_complete_email = "Resources/auto_complete_email.xml";
                if (File.Exists(auto_complete_email))
                {

                    List<string> logged_emails = new List<string>();
                    List<SBSystem_Exp> successfully_logged_emails = SQLHelper.GetDataFromSBSystem_ExpXML(auto_complete_email);
                    foreach (var item in successfully_logged_emails)
                    {
                        logged_emails.Add(item.Name);
                    }
                    if (!logged_emails.Contains(email))
                    {
                        XDocument doc = XDocument.Load(auto_complete_email);
                        doc.Element("Systems").Add(
                            new XElement("System",
                            new XAttribute("Name", email),
                            new XAttribute("Application", message)));
                        doc.Save(auto_complete_email);
                    }
                }
                if (!File.Exists(auto_complete_email))
                {

                    List<SBSystem_Exp> systems = new List<SBSystem_Exp>() { new SBSystem_Exp(email, message) };

                    var xml = new XElement("Systems", systems.Select(x => new XElement("System",
                                           new XAttribute("Name", x.Name),
                                           new XAttribute("Application", x.Application))));
                    xml.Save(auto_complete_email);
                }
                return true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
                return false;
            }
        }
        private void InitializeControls()
        {
            try
            {
                txtTo.Text = "kevinmatin4@gmail.com";
                txtFrom.Text = "kevinmk30@gmail.com";
                txtTimeOut.Text = "5000000";
                txtPort.Text = "587";
                chkEnableSsl.Checked = true;
                txtHost.Text = "smtp.gmail.com";
                txtUserName.Text = "kevinmk30@gmail.com";
                txtPassWord.Text = "kevinbrian";
                txtSubject.Text = "soft books school [ " + DateTime.Now.ToString() + " ]";
                txtMessage.Text = "soft books school [ " + DateTime.Now.ToString() + " ]";
                txtBcc.Text = "kevinmatin6@gmail.com";
                txtCc.Text = "kevinmatin5@gmail.com";
                if (_email != null)
                {
                    txtTo.Text = _email.Trim();
                    txtBcc.Text = _email.Trim();
                    txtCc.Text = _email.Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (IsEmailValid())
                {
                    string addressTo = txtTo.Text.Trim();
                    string addressFrom = txtFrom.Text.Trim();
                    string subject = txtSubject.Text.Trim();
                    string Body = txtMessage.Text.Trim();
                    int TimeOut = int.Parse(txtTimeOut.Text.Trim());
                    int Port = int.Parse(txtPort.Text.Trim());
                    bool EnableSsl = chkEnableSsl.Checked;
                    string Host = txtHost.Text.Trim();
                    string UserName = txtUserName.Text.Trim();
                    string Password = txtPassWord.Text.Trim();
                    string Bcc = txtBcc.Text.Trim();

                    SendMessage(addressTo, addressFrom, subject, Body, TimeOut, Port, EnableSsl, Host, UserName, Password, Bcc); 
                }
            }
            catch (Exception ex)
            {
                NotifyMessage(Utils.APP_NAME, ex.Message.ToString().Trim());
            }
        }
        public bool IsEmailValid()
        {
            bool no_error = true;
            if (string.IsNullOrEmpty(txtHost.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtHost, "Host cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPort.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPort, "Port cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTimeOut.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTimeOut, "Time Out cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtUserName, "User Name cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPassWord.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPassWord, "Pass Word cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtFrom.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtFrom, "From cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTo.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTo, "To cannot be null!");
                return false;
            }
            if (!string.IsNullOrEmpty(txtTo.Text))
            {
                System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
                if (!rEMail.IsMatch(txtTo.Text))
                {

                    errorProvider1.Clear();
                    errorProvider1.SetError(txtTo, "Invalid Email!");
                    txtTo.SelectAll();
                    return false;
                }
            }
            if (string.IsNullOrEmpty(txtSubject.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtSubject, "Subject cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtMessage.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtMessage, "Message cannot be null!");
                return false;
            }
            return no_error;
        }
        public bool SendMessage(string addressTo, string addressFrom, string subject, string Body, int TimeOut, int Port, bool EnableSsl, string Host, string UserName, string Password, string Bcc)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.To.Add(addressTo);
                message.Subject = subject;
                message.From = new System.Net.Mail.MailAddress(addressFrom);
                message.Body = Body;
                message.ReplyToList.Add(addressFrom);
                message.Bcc.Add(Bcc);

                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.UseDefaultCredentials = false;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = UserName;
                NetworkCred.Password = Password;
                smtp.Credentials = NetworkCred;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Host = Host;
                smtp.EnableSsl = EnableSsl;
                smtp.Port = Port;
                smtp.Timeout = TimeOut;
                smtp.Send(message);

                NotifyMessage(Utils.APP_NAME, "Email Message Successfully Sent...");
                this.SaveAutoCompleteEmail(addressTo, Body);

                return true;
            }
            catch (Exception ex)
            {
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
        public bool ReadEmail(string _Title, string _Text)
        {
            try
            {
                //var client = new POPClient();
                //client.Connect("pop.gmail.com", 995, true);
                //client.Authenticate("admin@bendytree.com", "YourPasswordHere");
                //var count = client.GetMessageCount();
                //Message message = client.GetMessage(count);
                //Console.WriteLine(message.Headers.Subject);

                return true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
                return false;
            }
        } 
        















    }
}