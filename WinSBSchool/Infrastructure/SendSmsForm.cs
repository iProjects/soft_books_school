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
    public partial class SendSmsForm : Form
    {
        #region "public properties"
        public static Int16 Comm_Port = 0;
        public static Int32 Comm_BaudRate = 0;
        public static Int32 Comm_TimeOut = 0;
        public static GsmCommMain comm;
        #endregion "public properties"

        #region "private properties"
        private string Manufacturer;
        private string Model;
        private string _phoneNo;
        private string Revision;
        private string SerialNumber;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        Repository rep;
        SBSchoolDBEntities db;
        string _user;
        string connection;
        #endregion "private properties"

        public SendSmsForm(string user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            _user = user;
        }
        public SendSmsForm(string phoneno)
        {
            InitializeComponent();

            _phoneNo = phoneno;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                comm.Close();
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
            }
            finally
            {
                this.Close();
            }
        }
        private void SendSmsForm_Load(object sender, EventArgs e)
        {
            try
            {
                Comm_Port = Convert.ToInt16(ConfigurationManager.AppSettings["Comm_Port"]);
                Comm_BaudRate = Convert.ToInt32(ConfigurationManager.AppSettings["Comm_BaudRate"]);
                Comm_TimeOut = Convert.ToInt32(ConfigurationManager.AppSettings["Comm_TimeOut"]);

                List<string> _ports = new List<string>();
                //Retrieve the list of all COM  ports on your computer
                string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    if (!_ports.Contains(port))
                    {
                        _ports.Add(port);
                    }
                }
                cboPorts.DataSource = _ports;

                txtBaudRate.Text = Comm_BaudRate.ToString();
                txtTimeOut.Text = Comm_TimeOut.ToString();
                if (_phoneNo != null)
                {
                    txtPhoneNumber.Text = _phoneNo.Trim();
                }

                AutoCompleteStringCollection acscphnn = new AutoCompleteStringCollection();
                acscphnn.AddRange(this.AutoComplete_PhoneNumber());
                txtPhoneNumber.AutoCompleteCustomSource = acscphnn;
                txtPhoneNumber.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtPhoneNumber.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string[] AutoComplete_PhoneNumber()
        {
            try
            {
                string auto_complete_phoneno = "Resources/auto_complete_phoneno.xml";
                List<string> logged_phonenos = new List<string>();
                if (File.Exists(auto_complete_phoneno))
                {
                    List<SBSystem_Exp> successfully_logged_phonenos = SQLHelper.GetDataFromSBSystem_ExpXML(auto_complete_phoneno);
                    foreach (var item in successfully_logged_phonenos)
                    {
                        logged_phonenos.Add(item.Name);
                    }
                }
                return logged_phonenos.ToArray();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private bool SaveAutoCompletePhoneNo(string phoneno, string message)
        {
            try
            {
                string auto_complete_phoneno = "Resources/auto_complete_phoneno.xml";
                if (File.Exists(auto_complete_phoneno))
                {

                    List<string> logged_phonenos = new List<string>();
                    List<SBSystem_Exp> successfully_logged_phonenos = SQLHelper.GetDataFromSBSystem_ExpXML(auto_complete_phoneno);
                    foreach (var item in successfully_logged_phonenos)
                    {
                        logged_phonenos.Add(item.Name);
                    }
                    if (!logged_phonenos.Contains(phoneno))
                    {
                        XDocument doc = XDocument.Load(auto_complete_phoneno);
                        doc.Element("Systems").Add(
                            new XElement("System",
                            new XAttribute("Name", phoneno),
                            new XAttribute("Application", message)));
                        doc.Save(auto_complete_phoneno);
                    }
                }
                if (!File.Exists(auto_complete_phoneno))
                {

                    List<SBSystem_Exp> systems = new List<SBSystem_Exp>() { new SBSystem_Exp(phoneno, message) };

                    var xml = new XElement("Systems", systems.Select(x => new XElement("System",
                                           new XAttribute("Name", x.Name),
                                           new XAttribute("Application", x.Application))));
                    xml.Save(auto_complete_phoneno);
                }
                return true;
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
                return false;
            }
        }
        public bool Connect()
        {
            try
            {
                comm = new GsmCommMain(Comm_Port, Comm_BaudRate, Comm_TimeOut);
                bool connected = false;
                comm.Open();

                if (comm.IsConnected())
                {
                    Manufacturer = comm.IdentifyDevice().Manufacturer.ToUpper().ToString();
                    Model = comm.IdentifyDevice().Model.ToUpper().ToString();
                    Revision = comm.IdentifyDevice().Revision.ToUpper().ToString();
                    SerialNumber = comm.IdentifyDevice().SerialNumber.ToUpper().ToString();

                    connected = true;

                    NotifyMessage(Utils.APP_NAME, "Port Successfully Opened. Info..." + Environment.NewLine + "Port : " + Comm_Port.ToString() + Environment.NewLine + "Manufacturer : " + Manufacturer + Environment.NewLine + "Model : " + Model + Environment.NewLine + "Serial Number : " + SerialNumber + Environment.NewLine + "Revision : " + Revision);
                }
                return connected;
            }
            catch (Exception ex)
            {
                NotifyMessage(Utils.APP_NAME, ex.Message.ToString().Trim());
                return false;
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();
                if (IsSmsValid())
                {
                    string _port = (string)cboPorts.Text;
                    short _selectedport;
                    if (short.TryParse(cboPorts.Text.Trim(), out _selectedport))
                    {

                    }
                    if (!short.TryParse(cboPorts.Text.Trim(), out _selectedport))
                    {
                        _selectedport = short.Parse(_port.Split('M')[1]);
                    }
                    Comm_Port = _selectedport;
                    Comm_BaudRate = int.Parse(txtBaudRate.Text.Trim());
                    Comm_TimeOut = int.Parse(txtTimeOut.Text.Trim());
                    string CELL_Number = txtPhoneNumber.Text.Trim();
                    string SMS_Message = txtMessage.Text.Trim();

                    SmsSubmitPdu pdu1 = new SmsSubmitPdu(SMS_Message, CELL_Number, "");
                    comm.SendMessage(pdu1);
                    NotifyMessage(Utils.APP_NAME, "SMS Message Successfully Sent...");
                    this.SaveAutoCompletePhoneNo(CELL_Number, SMS_Message);
                    comm.Close();
                }
            }
            catch (Exception ex)
            {
                NotifyMessage(Utils.APP_NAME, ex.Message.ToString().Trim());
            }
        }
        public bool IsSmsValid()
        {
            bool no_error = true;
            if (string.IsNullOrEmpty(cboPorts.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboPorts, "Port cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtBaudRate.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtBaudRate, "Baud Rate cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtTimeOut.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtTimeOut, "Time Out cannot be null!");
                return false;
            }
            if (string.IsNullOrEmpty(txtPhoneNumber.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPhoneNumber, "Recepient Number cannot be null!");
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
        public void GetIPv4GlobalStatistics()
        {
            try
            {
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                IPGlobalStatistics ipstat = properties.GetIPv4GlobalStatistics();
                Console.WriteLine("  Inbound Packet Data:");
                Console.WriteLine("      Received ............................ : {0}",
                ipstat.ReceivedPackets);
                Console.WriteLine("      Forwarded ........................... : {0}",
                ipstat.ReceivedPacketsForwarded);
                Console.WriteLine("      Delivered ........................... : {0}",
                ipstat.ReceivedPacketsDelivered);
                Console.WriteLine("      Discarded ........................... : {0}",
                ipstat.ReceivedPacketsDiscarded);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void GetActiveTcpConnections()
        {
            try
            {
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
                foreach (TcpConnectionInformation c in connections)
                {
                    Console.WriteLine("{0} <==> {1}",
                        c.LocalEndPoint.ToString(),
                        c.RemoteEndPoint.ToString());
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void GetActiveTcpListeners()
        {
            try
            {
                IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] endPoints = properties.GetActiveTcpListeners();
                foreach (IPEndPoint e in endPoints)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public bool PortInUse(int port)
        {
            try
            {
                bool inUse = false;

                IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
                IPEndPoint[] ipEndPoints = ipProperties.GetActiveTcpListeners();

                foreach (IPEndPoint endPoint in ipEndPoints)
                {
                    if (endPoint.Port == port)
                    {
                        inUse = true;
                        break;
                    }
                }
                return inUse;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
        private void cboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPorts.SelectedIndex != -1)
            {
                try
                {
                    string _port = (string)cboPorts.SelectedItem;
                    short intport = short.Parse(_port.Split('M')[1]);
                    Comm_Port = intport;
                    Connect();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnConnect_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(cboPorts.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboPorts, "Port cannot be null!");
                return;
            }
            if (!string.IsNullOrEmpty(cboPorts.Text))
            {
                try
                {
                    string _port = (string)cboPorts.Text;
                    short _selectedport;
                    if (short.TryParse(cboPorts.Text.Trim(), out _selectedport))
                    {

                    }
                    if (!short.TryParse(cboPorts.Text.Trim(), out _selectedport))
                    {
                        _selectedport = short.Parse(_port.Split('M')[1]);
                    }
                    Comm_Port = _selectedport;
                    Connect();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void SendSmsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                comm.Close();
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
            }
        }
        private void btnGetPorts_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> _ports = new List<string>();
                //Retrieve the list of all COM  ports on your computer
                string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    if (!_ports.Contains(port))
                    {
                        _ports.Add(port);
                    }
                }
                cboPorts.DataSource = _ports;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboPorts_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //List<string> _ports = new List<string>();
                ////Retrieve the list of all COM  ports on your computer
                //string[] ports = System.IO.Ports.SerialPort.GetPortNames();
                //foreach (string port in ports)
                //{
                //    _ports.Add(port);
                //}
                //cboPorts.DataSource = _ports;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboPorts_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
        }
        private void cboPorts_KeyDown(object sender, KeyEventArgs e)
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