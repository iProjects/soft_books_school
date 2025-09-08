using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CommonLib;
using DAL;
using iTextSharp.text;
using VVX;
using WinSBSchool.Forms;
using WinSBSchool.Reports.PDFBuilders;
using WinSBSchool.Reports.ViewModelBuilders;
using WinSBSchool.Reports.ViewModels;
using WinSBSchool.Reports.Views.PDF;
using WinSBSchool.Forms.Charting;
using System.Threading;

namespace WinSBSchool.Reports.Viewer
{
    public partial class PDFViewer : Form
    {

        #region "Private Fields"
        string connection;
        private string msAppName = "SB School Report.....";
        string current_file_name = "";
        string msFolder = "";
        SBSchoolDBEntities db;
        Repository rep;
        PDFGen pdf_generator;
        int _Term;
        int _AccountId;
        public List<SelectedFontsDTO> SelectedFontsList;
        string _resourcesPath = null;
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;
        ExamPeriodClass _ExamPeriodClass;
        Exam _Exam;
        RegisteredExam _RegisteredExam;
        FeesStructure _FeesStructure;
        SchoolClass _SchoolClass;
        TimeTable _TimeTable;
        ClassStream _ClassStream;
        DateTime Startdate;
        DateTime Enddate;
        string _DocType;
        string _user;
        string TAG;
        List<notificationdto> _lstnotificationdto = new List<notificationdto>();
        //Event declaration:
        //event for publishing messages to output
        event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;
        event EventHandler<notificationmessageEventArgs> _notificationmessageEventname_from_parent;
        #endregion "Private Fields"

        #region "Constructor"
        public PDFViewer(string user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            _user = user;

            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PDFViewer initialization", TAG));

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF'st will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

            tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
            tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
            //tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];
            //tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
            //tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];
            //tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];

        }
        public PDFViewer(int _accountId, DateTime startdate, DateTime enddate, string user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PDFViewer initialization", TAG));

            _user = user;

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF'st will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

            if (_accountId == null)
                throw new ArgumentNullException("Account is invalid");
            _AccountId = _accountId;

            if (startdate == null)
                throw new ArgumentNullException("Startdate cannot be null");

            if (enddate == null)
            {
                enddate = DateTime.Now;
            }
            if (enddate < startdate)
            {
                MessageBox.Show("Enddate cannot be less than Startdate", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Startdate = startdate;
            Enddate = enddate;

            Account _account = rep.GetAccount(_AccountId);
            if (_account != null && Startdate != null && Enddate != null)
            {
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];

                SetUpForStatement(_AccountId, Startdate, Enddate);
                btnAccountStatement_Click(this, null);
            }
        }
        public PDFViewer(int _term, FeesStructure _feeStructure, SchoolClass _schoolclass, string user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PDFViewer initialization", TAG));

            _user = user;

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF'st will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

            if (_feeStructure == null)
                throw new ArgumentNullException("FeesStructure is invalid");
            _FeesStructure = _feeStructure;

            if (_schoolclass == null)
                throw new ArgumentNullException("SchoolClass is invalid");
            _SchoolClass = _schoolclass;

            if (_term == null)
                throw new ArgumentNullException("Term is invalid");
            _Term = _term;

            if (_Term != null && _FeesStructure != null && _SchoolClass != null)
            {
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];

                SetupforFeeStructureByClass(_Term, _FeesStructure, _SchoolClass);
                feeStructureByClassToolStripMenuItem_Click(this, null);
            }

        }
        public PDFViewer(string _doctype, string user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PDFViewer initialization", TAG));

            _user = user;

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF'st will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

            if (_doctype == null)
                throw new ArgumentNullException("DocType is invalid");
            _DocType = _doctype;

            if (_DocType != null)
            {
                switch (_DocType)
                {
                    case "profitandloss":

                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];

                        profitandLossToolStripMenuItem_Click(this, null);
                        break;
                    case "balancesheet":
                        balanceSheetToolStripMenuItem_Click(this, null);

                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];
                        tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];

                        break;
                }
            }
        }
        public PDFViewer(ExamPeriodClass excl, string user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PDFViewer initialization", TAG));

            _user = user;

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF'st will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

            if (excl == null)
                throw new ArgumentNullException("Exam Period /class is invalid");
            _ExamPeriodClass = excl;

            if (_ExamPeriodClass != null)
            {
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];

                SetupforExamResultsByClass(_ExamPeriodClass);
                ExamResultByClasstoolStripMenuItem_Click(this, null);
            }
        }
        public PDFViewer(Exam _exam, string user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PDFViewer initialization", TAG));

            _user = user;

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF'st will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

            if (_exam == null)
                throw new ArgumentNullException("Exam is invalid");
            _Exam = _exam;

            if (_Exam != null)
            {
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];

                SetupforExamResultsBySubject(_Exam);
                ExamResultBySubjectToolStripButton_Click(this, null);
            }
        }
        public PDFViewer(RegisteredExam _rgdexam, string user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PDFViewer initialization", TAG));

            _user = user;

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF'st will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

            if (_rgdexam == null)
                throw new ArgumentNullException("RegisteredExam is invalid");
            _RegisteredExam = _rgdexam;

            if (_RegisteredExam != null)
            {
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];

                SetupforExamResultsByExamType(_RegisteredExam);
                ExamResultByExamTypeToolStripButton_Click(this, null);
            }
        }
        public PDFViewer(ClassStream _clsStrm, TimeTable _timetable, string user, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname_from_parent)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            TAG = this.GetType().Name;

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(ThreadException);

            //Subscribing to the event: 
            //Dynamically:
            //EventName += HandlerName;
            _notificationmessageEventname += notificationmessageHandler;
            _notificationmessageEventname_from_parent = notificationmessageEventname_from_parent;

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PDFViewer initialization", TAG));

            _user = user;

            DisableAllMenus();

            Authorize();

            //--- init the folder in which generated PDF'st will be saved. 
            msFolder = AppDomain.CurrentDomain.BaseDirectory;
            int n = msFolder.LastIndexOf(@"\");
            msFolder = msFolder.Substring(0, n + 1);

            SetResourcePath();

            pdf_generator = new PDFGen(_resourcesPath, connection);

            if (_timetable == null)
                throw new ArgumentNullException("TimeTable is invalid");
            _TimeTable = _timetable;

            if (_clsStrm == null)
                throw new ArgumentNullException("ClassStream is invalid");
            _ClassStream = _clsStrm;

            tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
            tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
            tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];
            tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
            tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];
            tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];

            PrintTimeTablePerClassStream(_ClassStream, _TimeTable);
        }
        #endregion "Constructor"

        #region "Private Methods"
        #region "General Purpose Helpers for this Form"
        //************************************************************
        /// <summary>
        /// Refreshes the window's Caption/Title bar
        /// </summary>
        private void DoUpdateCaption()
        {
            try
            {
                this.Text = this.msAppName;

                if (this.current_file_name.Length == 0)
                {
                    this.Text += "<...no PDF file created...>";
                }
                else
                {
                    FileInfo fi = new FileInfo(get_reports_uri(this.current_file_name));
                    this.Text += @"...\" + fi.Name;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void DoPreProcess(object sender, EventArgs e)
        {
            this.lblstatusinfo.Text = string.Empty;
            string msg = "processing report...";
            this.lblstatusinfo.Text = msg;
            this.Text = msg;
        }
        public string pathlookup(string folder)
        {
            try
            {
                string app_dir = Utils.get_application_path();
                var dir = Path.Combine(app_dir, folder);
                
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }

                return dir;

            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        private void DoPostProcess(object sender, EventArgs e)
        {
            try
            {
                string dir = pathlookup("reports");
                string sRet = Utils.build_file_path(dir, current_file_name);
                int pdfCount = Directory.GetFiles(dir, "*.pdf", SearchOption.TopDirectoryOnly).Length;
                int excelCount = Directory.GetFiles(dir, "*.xls", SearchOption.TopDirectoryOnly).Length;
                int _totalFiles = pdfCount + excelCount;
                this.lblstatusinfo.Text = current_file_name.ToString() + "     [  " + _totalFiles.ToString() + "  ] ";

                copy_to_user_temp();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private string get_reports_uri(string sFile)
        {
            string sRet;
            try
            {
                string dir = pathlookup("reports");
                sRet = Utils.build_file_path(dir, sFile);

                //check if directory exists.
                if (!System.IO.Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                return sRet;
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
                return "";
            }
        }
        private void SetResourcePath()
        {
            string sRet = string.Empty;
            try
            {
                string dir = pathlookup("resources");
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
                else
                {
                    sRet = dir;
                }

                this._resourcesPath = sRet;
            }
            catch (Exception e)
            {
                Utils.ShowError(e);
                this._resourcesPath = Utils.build_file_path(msFolder, "resources");
            }
        }
        private void DoShowPDF(string sFilePDF)
        {
            this.DoUpdateCaption();
            this.webBrowser.Navigate(get_reports_uri(sFilePDF));
        }
        private void NavigateToHomePage()
        {
            try
            {
                string help_file = "index.html";

                string base_directory = AppDomain.CurrentDomain.BaseDirectory;
                string help_path = Path.Combine(base_directory, "help");
                string help_file_path = Path.Combine(help_path, help_file);

                FileInfo fi = new FileInfo(help_file_path);

                if (fi.Exists)
                    this.webBrowser.Navigate(fi.FullName);
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
            }
        }

        private void copy_to_user_temp()
        {
            try
            {
                string base_directory = AppDomain.CurrentDomain.BaseDirectory;
                string reports_path = Path.Combine(base_directory, "Reports");

                string temp_path = Path.GetTempPath();

                DirectoryInfo reports_dir_info = new DirectoryInfo(reports_path);
                DirectoryInfo temp_dir_info = new DirectoryInfo(temp_path);

                var files = reports_dir_info.GetFiles();

                foreach (var report_file_info in files)
                {
                    var _temp_file = Path.Combine(temp_path, report_file_info.Name);

                    System.IO.File.Copy(report_file_info.FullName, _temp_file, true);

                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }
        private bool NotifyMessage(string _Title, string _Text)
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
        private void lblstatusinfo_Click(object sender, EventArgs e)
        {
            try
            {
                string base_directory = AppDomain.CurrentDomain.BaseDirectory;
                string reports_path = Path.Combine(base_directory, "Reports");

                if (Directory.Exists(reports_path))
                {
                    string _filetoSelect = Path.Combine(reports_path, current_file_name);
                    // opens the folder in explorer and selects the displayed file
                    string args = string.Format("/Select, {0}", _filetoSelect);
                    ProcessStartInfo pfi = new ProcessStartInfo("Explorer.exe", args);
                    System.Diagnostics.Process.Start(pfi);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "General Purpose Helpers for this Form"

        #region "initialize"

        private void PDFViewer_Load(object sender, EventArgs e)
        {
            try
            {
                NavigateToHomePage();
                InitializeControls();

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished PDFViewer load", TAG));
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls()
        {
            try
            {
                PopulateYearsCombo();

                PopulateSchoolsGrid();

                PopulateProgrammesGrid();

                PopulateClassStudentsGrid();

                PopulateClassSubjectsGrid();

                this.dateTimePickerEndDate.Value = DateTime.Today;
                this.dateTimePickerStartDate.Value = DateTime.Today.AddMonths(-3);

                lblAccountDetails.Text = string.Empty;

                AutoCompleteStringCollection acsaccid = new AutoCompleteStringCollection();
                acsaccid.AddRange(this.AutoComplete_AccountIds());
                txtAccountId.AutoCompleteCustomSource = acsaccid;
                txtAccountId.AutoCompleteMode =
                    AutoCompleteMode.SuggestAppend;
                txtAccountId.AutoCompleteSource =
                     AutoCompleteSource.CustomSource;

                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageProgrammes)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSubjects)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStudents)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageStatement)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageRegdExams)];
                tabControlReportsData.SelectedTab = tabControlReportsData.TabPages[tabControlReportsData.TabPages.IndexOf(tabPageSchools)];

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.WriteToErrorLogFile_and_EventViewer(ex);
        }
        private void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            Log.WriteToErrorLogFile_and_EventViewer(ex);
        }

        //Event handler declaration:
        private void notificationmessageHandler(object sender, notificationmessageEventArgs args)
        {
            try
            {
                /* Handler logic */
                notificationdto _notificationdto = new notificationdto();

                DateTime currentDate = DateTime.Now;
                String dateTimenow = currentDate.ToString("dd-MM-yyyy HH:mm:ss tt");

                String _logtext = Environment.NewLine + "[ " + dateTimenow + " ]   " + args.message;

                _notificationdto._notification_message = _logtext;
                _notificationdto._created_datetime = dateTimenow;
                _notificationdto.TAG = args.TAG;

                _lstnotificationdto.Add(_notificationdto);
                Console.WriteLine(args.message);
                _notificationmessageEventname_from_parent.Invoke(this, new notificationmessageEventArgs(args.message, TAG));

                var _lstmsgdto = from msgdto in _lstnotificationdto
                                 orderby msgdto._created_datetime descending
                                 select msgdto._notification_message;

                String[] _logflippedlines = _lstmsgdto.ToArray();

                if (_logflippedlines.Length > 5000)
                {
                    _lstnotificationdto.Clear();
                }

                txtlog.Lines = _logflippedlines;
                txtlog.ScrollToCaret();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Authorize()
        {
            try
            {
                var _dbuserquery = from us in db.spUsers
                                   where us.UserName == _user
                                   select us;

                spUser LoggedInUser = _dbuserquery.FirstOrDefault();

                if (LoggedInUser != null)
                {
                    var allowedmenusquery = from arm in db.spAllowedReportsRolesMenus
                                            where arm.RoleId == LoggedInUser.RoleId
                                            select arm;
                    foreach (var armq in allowedmenusquery.ToList())
                    {
                        ToolStripMenuItem mnuitem = menuStrip1.Items.Find(armq.spReportsMenuItem.mnuName, true).OfType<ToolStripMenuItem>().FirstOrDefault();

                        if (mnuitem != null && armq.Allowed == true)
                        {
                            mnuitem.Enabled = true;
                        }

                        ToolStripItem tsbitem = toolStrip1.Items.Find(armq.spReportsMenuItem.mnuName, true).OfType<ToolStripItem>().FirstOrDefault();

                        if (tsbitem != null && armq.Allowed == true)
                        {
                            tsbitem.Enabled = true;
                        }

                        Button btnitem = tabPageStatement.Controls.Find(armq.spReportsMenuItem.mnuName, true).OfType<Button>().FirstOrDefault();

                        if (btnitem != null && armq.Allowed == true)
                        {
                            btnitem.Enabled = true;
                        }

                        Button btn1item = panel2.Controls.Find(armq.spReportsMenuItem.mnuName, true).OfType<Button>().FirstOrDefault();

                        if (btn1item != null && armq.Allowed == true)
                        {
                            btn1item.Enabled = true;
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void DisableAllMenus()
        {
            try
            {
                this.entityListsToolStripMenuItem.Enabled = false;
                this.studentListsToolStripMenuItem.Enabled = false;
                this.teachersListtoolStripMenuItem.Enabled = false;
                this.subjectListsToolStripMenuItem.Enabled = false;
                this.classListsToolStripMenuItem.Enabled = false;
                this.programmeCourseListToolStripMenuItem.Enabled = false;
                this.examResultsToolStripMenuItem.Enabled = false;
                this.examResultsbyClassToolStripMenuItem.Enabled = false;
                this.examResultsbySubjectToolStripMenuItem.Enabled = false;
                this.examResultsbyExamTypeToolStripMenuItem.Enabled = false;
                this.markSheetTableToolStripMenuItem.Enabled = false;
                this.preSchoolToolStripMenuItem.Enabled = false;
                this.primaryToolStripMenuItem.Enabled = false;
                this.secondaryToolStripMenuItem.Enabled = false;
                this.tertiaryToolStripMenuItem.Enabled = false;
                this.collegeToolStripMenuItem.Enabled = false;
                this.universityToolStripMenuItem.Enabled = false;
                this.academicReportsToolStripMenuItem.Enabled = false;
                this.studentAcademicToolStripMenuItem.Enabled = false;
                this.studentAcademicReportFormToolStripMenuItem.Enabled = false;
                this.studentAcademicProgressFormToolStripMenuItem.Enabled = false;
                this.studentPerformanceByTargetToolStripMenuItem.Enabled = false;
                this.teacherAcademicToolStripMenuItem.Enabled = false;
                this.teacherAcademicRepotFormToolStripMenuItem.Enabled = false;
                this.teachersProgressFormToolStripMenuItem.Enabled = false;
                this.teacherPerformanceByTargetToolStripMenuItem.Enabled = false;
                this.classAcademicToolStripMenuItem.Enabled = false;
                this.classesReportFormToolStripMenuItem.Enabled = false;
                this.classesProgressFormToolStripMenuItem.Enabled = false;
                this.classesPerformanceByTargetToolStripMenuItem.Enabled = false;
                this.classConsolidatedMarksheetToolStripMenuItem.Enabled = false;
                this.schoolAcademicToolStripMenuItem.Enabled = false;
                this.schoolsReportFormToolStripMenuItem.Enabled = false;
                this.schoolsProgressFormToolStripMenuItem.Enabled = false;
                this.schoolPerformanceByTargetToolStripMenuItem.Enabled = false;
                this.schoolPerformanceInTheRegionToolStripMenuItem.Enabled = false;
                this.financialReportsToolStripMenuItem.Enabled = false;
                this.studentFinancialReportToolStripMenuItem.Enabled = false;
                this.studentStatementToolStripMenuItem.Enabled = false;
                this.studentAccountStatusToolStripMenuItem.Enabled = false;
                this.studentArrearsReceivablesToolStripMenuItem.Enabled = false;
                this.parentStatementToolStripMenuItem.Enabled = false;
                this.parentAccountStatusToolStripMenuItem.Enabled = false;
                this.paymentReceiptsToolStripMenuItem.Enabled = false;
                this.studentFeesStructureToolStripMenuItem.Enabled = false;
                this.schoolFinancialReportToolStripMenuItem.Enabled = false;
                this.generalLToolStripMenuItem.Enabled = false;
                this.profitAndLossToolStripMenuItem.Enabled = false;
                this.balanceSheetToolStripMenuItem.Enabled = false;
                this.bankStatementToolStripMenuItem.Enabled = false;
                this.cashBookToolStripMenuItem.Enabled = false;
                this.schoolArrearsReceivablesToolStripMenuItem.Enabled = false;
                this.payablesToolStripMenuItem.Enabled = false;
                this.feesStructureToolStripMenuItem.Enabled = false;
                this.feeStructurebyClassToolStripMenuItem.Enabled = false;
                this.feeStructurebyProgrammeToolStripMenuItem.Enabled = false;
                this.feeStructurebyAccountTypesToolStripMenuItem.Enabled = false;
                this.nonAcademicReportToolStripMenuItem.Enabled = false;
                this.nonAcademicstudentToolStripMenuItem.Enabled = false;
                this.disciplineStatusToolStripMenuItem.Enabled = false;
                this.disciplinaryRecordToolStripMenuItem.Enabled = false;
                this.extraCurriculaToolStripMenuItem.Enabled = false;
                this.medicalRecordToolStripMenuItem.Enabled = false;
                this.attendanceRecordToolStripMenuItem.Enabled = false;
                this.timetableReportToolStripMenuItem.Enabled = false;
                this.btnAccountStatement.Enabled = false;
                this.listsToolStripDropDownButton.Enabled = false;
                this.studentsListtoolStripMenuItem.Enabled = false;
                this.teacherListstoolStripMenuItem.Enabled = false;
                this.subjectsListstoolStripMenuItem.Enabled = false;
                this.classesListstoolStripMenuItem.Enabled = false;
                this.programmesListstoolStripMenuItem.Enabled = false;
                this.reportFormsToolStripDropDownButton.Enabled = false;
                this.studentReportFormToolStripMenuItem.Enabled = false;
                this.teacherReportFormToolStripMenuItem.Enabled = false;
                this.classReportFormToolStripMenuItem.Enabled = false;
                this.schoolReportFormToolStripMenuItem.Enabled = false;
                this.progressFormsToolStripDropDownButton.Enabled = false;
                this.studentProgressFormToolStripMenuItem.Enabled = false;
                this.teacherProgressFormToolStripMenuItem.Enabled = false;
                this.classProgressFormToolStripMenuItem.Enabled = false;
                this.schoolProgressFormToolStripMenuItem.Enabled = false;
                this.PerformanceByTargetToolStripDropDownButton.Enabled = false;
                this.studentsPerformanceByTargetsToolStripMenuItem.Enabled = false;
                this.teachersPerformanceByTargetsToolStripMenuItem.Enabled = false;
                this.classPerformanceByTargetToolStripMenuItem.Enabled = false;
                this.schoolsPerformanceByTargetsToolStripMenuItem.Enabled = false;
                this.examResultsToolStripDropDownButton.Enabled = false;
                this.examsResultsbyClassToolStripMenuItem.Enabled = false;
                this.examsResultsBySubjectsToolStripMenuItem.Enabled = false;
                this.examsResultsByExamTypesToolStripMenuItem.Enabled = false;
                this.marksTableFormsToolStripDropDownButton.Enabled = false;
                this.preSchoolsMarkSheetToolStripMenuItem.Enabled = false;
                this.primarySchoolsMarkSheetToolStripMenuItem.Enabled = false;
                this.secondarySchoolsMarkSheetToolStripMenuItem.Enabled = false;
                this.tertiaryMarkSheetToolStripMenuItem.Enabled = false;
                this.collegeMarkSheetToolStripMenuItem.Enabled = false;
                this.universityMarkSheetToolStripMenuItem.Enabled = false;
                this.btnSearchbyAccount.Enabled = false;
                this.btnSearchbyStudent.Enabled = false;
                this.btnSearchExamPeriods.Enabled = false;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetUpForStatement(int _AccountId, DateTime startdate, DateTime enddate)
        {
            try
            {
                tabControlReportsData.SelectedTab = tabPageStatement;
                dateTimePickerStartDate.Value = startdate;
                dateTimePickerEndDate.Value = enddate;
                txtAccountId.Text = _AccountId.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetupforExamResultsByClass(ExamPeriodClass _examPeriodClass)
        {
            try
            {
                var SchoolClassesquery = from pc in db.SchoolClasses
                                         select pc;
                List<SchoolClass> SchoolClasses = SchoolClassesquery.ToList();
                cbclass.ValueMember = "Id";
                cbclass.DisplayMember = "ClassName";
                cbclass.DataSource = SchoolClasses;

                var SchoolClassquery = (from sc in db.SchoolClasses
                                        where sc.Id == _examPeriodClass.ClassId
                                        select sc).FirstOrDefault();
                SchoolClass _SchoolClass = SchoolClassquery;
                if (_SchoolClass != null)
                {
                    cbclass.SelectedValue = _SchoolClass.Id;
                }

                var ExamPeriodsquery = from ep in db.ExamPeriods
                                       where ep.Status == "A"
                                       orderby ep.Year, ep.Term ascending
                                       select ep;
                List<ExamPeriod> _ExamPeriods = ExamPeriodsquery.ToList();
                cbExamPeriod.DataSource = _ExamPeriods;
                cbExamPeriod.ValueMember = "Id";
                cbExamPeriod.DisplayMember = "Description";

                var ExamPeriodquery = (from ep in db.ExamPeriods
                                       where ep.Id == _examPeriodClass.ExamPeriod
                                       where ep.Status == "A"
                                       select ep).FirstOrDefault();
                ExamPeriod _ExamPeriod = ExamPeriodquery;
                if (_ExamPeriod != null)
                {
                    cbExamPeriod.SelectedValue = _ExamPeriod.Id;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetupforExamResultsBySubject(Exam _exam)
        {
            try
            {
                var SchoolClassesquery = from pc in db.SchoolClasses
                                         select pc;
                List<SchoolClass> SchoolClasses = SchoolClassesquery.ToList();
                cbclass.ValueMember = "Id";
                cbclass.DisplayMember = "ClassName";
                cbclass.DataSource = SchoolClasses;

                var SchoolClassquery = (from sc in db.SchoolClasses
                                        where sc.Id == _exam.ClassId
                                        select sc).FirstOrDefault();
                SchoolClass _SchoolClass = SchoolClassquery;
                if (_SchoolClass != null)
                {
                    cbclass.SelectedValue = _SchoolClass.Id;
                }

                var ExamPeriodsquery = from ep in db.ExamPeriods
                                       where ep.Status == "A"
                                       orderby ep.Year, ep.Term ascending
                                       select ep;
                List<ExamPeriod> _ExamPeriods = ExamPeriodsquery.ToList();
                cbExamPeriod.DataSource = _ExamPeriods;
                cbExamPeriod.ValueMember = "Id";
                cbExamPeriod.DisplayMember = "Description";

                var ExamPeriodquery = (from ep in db.ExamPeriods
                                       where ep.Id == _exam.ExamPeriodId
                                       where ep.Status == "A"
                                       select ep).FirstOrDefault();
                ExamPeriod _ExamPeriod = ExamPeriodquery;
                if (_ExamPeriod != null)
                {
                    cbExamPeriod.SelectedValue = _ExamPeriod.Id;
                }

                if (cbclass.SelectedIndex != -1)
                {

                    DAL.SchoolClass cls = (DAL.SchoolClass)cbclass.SelectedItem;
                    if (cls == null)
                        throw new ArgumentNullException("Class is invalid");

                    var classtudts = from st in db.Students
                                     join pc in db.ClassStreams on st.ClassStreamId equals pc.Id
                                     orderby pc.Description ascending
                                     where pc.ClassId == cls.Id
                                     where st.Status == "A"
                                     orderby st.ClassStream.Description ascending
                                     select st;
                    bindingSourceClassStudents.DataSource = classtudts.ToList();
                    groupBox3.Text = bindingSourceClassStudents.Count.ToString();

                    var classubjcts = from sub in db.ClassSubjects
                                      where sub.Status == "A"
                                      where sub.ClassId == cls.Id
                                      orderby sub.Subject.Description ascending
                                      select sub;

                    var classubjctquery = (from sub in db.ClassSubjects
                                           where sub.Status == "A"
                                           where sub.ClassId == cls.Id
                                           orderby sub.Subject.Description ascending
                                           where sub.SubjectCode == _exam.SubjectShortCode
                                           select sub).FirstOrDefault();
                    ClassSubject _Classsubject = classubjctquery;

                    bindingSourceClassSubjects.DataSource = classubjcts.ToList();
                    groupBox2.Text = bindingSourceClassSubjects.Count.ToString();

                    tabControlReportsData.SelectedTab = tabPageSubjects;
                    foreach (DataGridViewRow row in dataGridViewClassSubjects.Rows)
                    {
                        var boundItem = (ClassSubject)row.DataBoundItem;
                        if (boundItem.Id == _Classsubject.Id)
                        {
                            row.Selected = true;
                            int boundsrc = boundItem.Id;
                            bindingSourceClassSubjects.Position = row.Index;
                            break;
                        }
                    }

                    PopulateRegisteredExamsGrid();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetupforExamResultsByExamType(RegisteredExam _registeredexam)
        {
            try
            {
                var examquery = (from exm in db.Exams
                                 where exm.Id == _registeredexam.ExamId
                                 select exm).FirstOrDefault();
                Exam _exam = examquery;

                var SchoolClassesquery = from pc in db.SchoolClasses
                                         select pc;
                List<SchoolClass> SchoolClasses = SchoolClassesquery.ToList();
                cbclass.ValueMember = "Id";
                cbclass.DisplayMember = "ClassName";
                cbclass.DataSource = SchoolClasses;

                var SchoolClassquery = (from sc in db.SchoolClasses
                                        where sc.Id == _exam.ClassId
                                        select sc).FirstOrDefault();
                SchoolClass _SchoolClass = SchoolClassquery;
                if (_SchoolClass != null)
                {
                    cbclass.SelectedValue = _SchoolClass.Id;
                }

                var ExamPeriodsquery = from ep in db.ExamPeriods
                                       where ep.Status == "A"
                                       orderby ep.Year, ep.Term ascending
                                       select ep;
                List<ExamPeriod> _ExamPeriods = ExamPeriodsquery.ToList();
                cbExamPeriod.DataSource = _ExamPeriods;
                cbExamPeriod.ValueMember = "Id";
                cbExamPeriod.DisplayMember = "Description";

                var ExamPeriodquery = (from ep in db.ExamPeriods
                                       where ep.Id == _exam.ExamPeriodId
                                       where ep.Status == "A"
                                       select ep).FirstOrDefault();
                ExamPeriod _ExamPeriod = ExamPeriodquery;
                if (_ExamPeriod != null)
                {
                    cbExamPeriod.SelectedValue = _ExamPeriod.Id;
                }

                if (cbclass.SelectedIndex != -1)
                {

                    DAL.SchoolClass cls = (DAL.SchoolClass)cbclass.SelectedItem;
                    if (cls == null)
                        throw new ArgumentNullException("Class is invalid");

                    var classtudts = from st in db.Students
                                     join pc in db.ClassStreams on st.ClassStreamId equals pc.Id
                                     orderby pc.Description ascending
                                     where pc.ClassId == cls.Id
                                     where st.Status == "A"
                                     orderby st.ClassStream.Description ascending
                                     select st;
                    bindingSourceClassStudents.DataSource = classtudts.ToList();
                    groupBox3.Text = bindingSourceClassStudents.Count.ToString();

                    var classubjcts = from sub in db.ClassSubjects
                                      where sub.Status == "A"
                                      where sub.ClassId == cls.Id
                                      orderby sub.Subject.Description ascending
                                      select sub;

                    var classubjctquery = (from sub in db.ClassSubjects
                                           where sub.Status == "A"
                                           where sub.ClassId == cls.Id
                                           orderby sub.Subject.Description ascending
                                           where sub.SubjectCode == _exam.SubjectShortCode
                                           select sub).FirstOrDefault();
                    ClassSubject _Classsubject = classubjctquery;

                    bindingSourceClassSubjects.DataSource = classubjcts.ToList();
                    groupBox2.Text = bindingSourceClassSubjects.Count.ToString();

                    tabControlReportsData.SelectedTab = tabPageSubjects;
                    foreach (DataGridViewRow row in dataGridViewClassSubjects.Rows)
                    {
                        var boundItem = (ClassSubject)row.DataBoundItem;
                        if (boundItem.Id == _Classsubject.Id)
                        {
                            row.Selected = true;
                            int boundsrc = boundItem.Id;
                            bindingSourceClassSubjects.Position = row.Index;
                            break;
                        }
                    }

                    PopulateRegisteredExams(_registeredexam);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetupforFeeStructureByClass(int _term, FeesStructure _feeStructure, SchoolClass _schoolclass)
        {
            try
            {
                var SchoolClassesquery = from pc in db.SchoolClasses
                                         select pc;
                List<SchoolClass> SchoolClasses = SchoolClassesquery.ToList();
                cbclass.ValueMember = "Id";
                cbclass.DisplayMember = "ClassName";
                cbclass.DataSource = SchoolClasses;

                var SchoolClassquery = (from sc in db.SchoolClasses
                                        where sc.Id == _schoolclass.Id
                                        select sc).FirstOrDefault();
                SchoolClass _schoolClass = SchoolClassquery;
                if (_schoolClass != null)
                {
                    cbclass.SelectedValue = _schoolClass.Id;
                }

                var ExamPeriodsquery = from ep in db.ExamPeriods
                                       where ep.Status == "A"
                                       where ep.Year == _feeStructure.Year
                                       where ep.Term == _term
                                       orderby ep.Year, ep.Term ascending
                                       select ep;
                List<ExamPeriod> _ExamPeriods = ExamPeriodsquery.ToList();
                cbExamPeriod.DataSource = _ExamPeriods;
                cbExamPeriod.ValueMember = "Id";
                cbExamPeriod.DisplayMember = "Description";

                int _year = _feeStructure.Year;
                List<int> yrs = new List<int>() { _year };
                cbYear.DataSource = yrs;
                List<int> Trms = new List<int>() { _term };
                cbTerm.DataSource = Trms;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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

        private void PopulateSchoolsGrid()
        {
            bindingSourceSchools.DataSource = null;
            groupBox5.Text = bindingSourceSchools.Count.ToString();

            try
            {
                var _Schoolsquery = from pc in db.Schools
                                    where pc.Status == "A"
                                    where pc.IsDeleted == false
                                    select pc;
                bindingSourceSchools.DataSource = _Schoolsquery.ToList();
                groupBox5.Text = bindingSourceSchools.Count.ToString();

                var SchoolTypes = new BindingList<KeyValuePair<string, string>>();
                SchoolTypes.Add(new KeyValuePair<string, string>("1", "Pre-School"));
                SchoolTypes.Add(new KeyValuePair<string, string>("2", "Primary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("3", "Secondary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("4", "Tertiary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("5", "University"));
                SchoolTypes.Add(new KeyValuePair<string, string>("6", "Pre-School and Primary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("7", "Primary and Secondary"));
                SchoolTypes.Add(new KeyValuePair<string, string>("8", "Primary, Secondary and Pre-School"));
                DataGridViewComboBoxColumn colSchoolType = new DataGridViewComboBoxColumn();
                colSchoolType.HeaderText = "School Type";
                colSchoolType.Name = "cbSchoolType";
                colSchoolType.DataSource = SchoolTypes;
                colSchoolType.DisplayMember = "Value";
                colSchoolType.DataPropertyName = "SchoolType";
                colSchoolType.ValueMember = "Key";
                colSchoolType.MaxDropDownItems = 10;
                colSchoolType.DisplayIndex = 2;
                colSchoolType.MinimumWidth = 5;
                colSchoolType.Width = 100;
                colSchoolType.FlatStyle = FlatStyle.Flat;
                colSchoolType.DefaultCellStyle.NullValue = "--- Select ---";
                colSchoolType.ReadOnly = true;
                colSchoolType.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewSchools.Columns.Contains("cbSchoolType"))
                {
                    dataGridViewSchools.Columns.Add(colSchoolType);
                }

                dataGridViewSchools.AutoGenerateColumns = false;
                this.dataGridViewSchools.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewSchools.DataSource = bindingSourceSchools;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateProgrammesGrid()
        {
            bindingSourceProgrammes.DataSource = null;
            groupBox1.Text = bindingSourceProgrammes.Count.ToString();

            try
            {
                var _programmesquery = from pc in db.Programmes
                                       where pc.Status == "A"
                                       where pc.IsDeleted == false
                                       select pc;
                List<Programme> _programmes = _programmesquery.ToList();
                bindingSourceProgrammes.DataSource = _programmes;
                groupBox1.Text = bindingSourceProgrammes.Count.ToString();

                dataGridViewProgrammes.AutoGenerateColumns = false;
                this.dataGridViewProgrammes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewProgrammes.DataSource = bindingSourceProgrammes;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateProgrammeClasses()
        {
            bindingSourceSchoolClasses.DataSource = null;

            if (dataGridViewProgrammes.SelectedRows.Count != 0)
            {
                try
                {
                    Programme _selectedprogramme = (Programme)bindingSourceProgrammes.Current;

                    var _schoolclassesquery = from sc in db.SchoolClasses
                                              join pyr in db.ProgrammeYears on sc.ProgrammeYearId equals pyr.Id
                                              join pr in db.Programmes on pyr.ProgrammeId equals pr.Id
                                              where pr.Id == _selectedprogramme.Id
                                              where pr.Status == "A"
                                              where pr.IsDeleted == false
                                              where pyr.IsDeleted == false
                                              select sc;
                    List<SchoolClass> _schoolClasses = _schoolclassesquery.ToList();
                    bindingSourceSchoolClasses.DataSource = _schoolClasses;

                    cbclass.ValueMember = "Id";
                    cbclass.DisplayMember = "ClassName";
                    cbclass.DataSource = bindingSourceSchoolClasses;
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void PopulateYearsCombo()
        {
            try
            {
                var _yearsquery = (from ep in db.ExamPeriods
                                   where ep.Status == "A"
                                   where ep.IsDeleted == false
                                   orderby ep.Year ascending
                                   select ep.Year).Distinct().ToList();
                List<int> _years = _yearsquery;

                cbYear.DataSource = _years;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateTermsCombo()
        {
            cbTerm.DataSource = null;

            if (cbYear.SelectedIndex != -1)
            {
                try
                {
                    int year = (int)cbYear.SelectedItem;

                    var _termsquery = (from ep in db.ExamPeriods
                                       where ep.Year == year
                                       select ep.Term).Distinct().ToList();
                    List<int> _terms = _termsquery;

                    cbTerm.DataSource = _terms;
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void PopulateExamPeriodCombo()
        {
            bindingSourceExamPeriod.DataSource = null;

            if (cbYear.SelectedIndex != -1 && cbTerm.SelectedIndex != -1)
            {
                try
                {
                    int Yr = (int)cbYear.SelectedItem;
                    int Term = (int)cbTerm.SelectedItem;

                    var _examPeriodsquery = from ep in db.ExamPeriods
                                            where ep.Status == "A"
                                            where ep.IsDeleted == false
                                            orderby ep.Year ascending
                                            select ep;
                    List<ExamPeriod> _ExamPeriods = _examPeriodsquery.ToList();
                    bindingSourceExamPeriod.DataSource = _ExamPeriods;

                    cbExamPeriod.DataSource = bindingSourceExamPeriod;
                    cbExamPeriod.ValueMember = "Id";
                    cbExamPeriod.DisplayMember = "Description";

                    var _selectedexamperiodquery = (from ep in db.ExamPeriods
                                                    where ep.Status == "A"
                                                    where ep.IsDeleted == false
                                                    where ep.Year == Yr
                                                    where ep.Term == Term
                                                    select ep).FirstOrDefault();
                    ExamPeriod _selectedexamperiod = _selectedexamperiodquery;
                    if (_selectedexamperiod != null)
                    {
                        cbExamPeriod.SelectedValue = _selectedexamperiod.Id;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void PopulateClassStudentsGrid()
        {
            bindingSourceClassStudents.DataSource = null;
            groupBox3.Text = bindingSourceClassStudents.Count.ToString();

            if (cbclass.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    DAL.SchoolClass selectedclass = (DAL.SchoolClass)cbclass.SelectedItem;
                    School _selectedschool = (School)bindingSourceSchools.Current;

                    var _classStudentsquery = from st in db.Students
                                              join sc in db.Schools on st.SchoolId equals sc.Id
                                              join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                                              join scs in db.SchoolClasses on cs.ClassId equals scs.Id
                                              where st.Status == "A"
                                              where st.IsDeleted == false
                                              where sc.Id == _selectedschool.Id
                                              where scs.Id == selectedclass.Id
                                              orderby st.Id ascending
                                              select st;
                    List<Student> _classStudents = _classStudentsquery.ToList();
                    bindingSourceClassStudents.DataSource = _classStudentsquery;
                    groupBox3.Text = bindingSourceClassStudents.Count.ToString();

                    var classStreamsquery = from pc in db.ClassStreams
                                            where pc.IsDeleted == false
                                            select pc;
                    List<ClassStream> _ClassStreams = classStreamsquery.ToList();
                    DataGridViewComboBoxColumn colCboxClassStream = new DataGridViewComboBoxColumn();
                    colCboxClassStream.HeaderText = "Stream";
                    colCboxClassStream.Name = "cbClassStream";
                    colCboxClassStream.DataSource = _ClassStreams;
                    // The display member is the name column in the column datasource  
                    colCboxClassStream.DisplayMember = "Description";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxClassStream.DataPropertyName = "ClassStreamId";
                    // The value member is the primary key of the parent table  
                    colCboxClassStream.ValueMember = "Id";
                    colCboxClassStream.MaxDropDownItems = 10;
                    colCboxClassStream.Width = 70;
                    colCboxClassStream.DisplayIndex = 4;
                    colCboxClassStream.MinimumWidth = 5;
                    colCboxClassStream.FlatStyle = FlatStyle.Flat;
                    colCboxClassStream.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxClassStream.ReadOnly = true;
                    colCboxClassStream.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewClassStudents.Columns.Contains("cbClassStream"))
                    {
                        dataGridViewClassStudents.Columns.Add(colCboxClassStream);
                    }

                    dataGridViewClassStudents.AutoGenerateColumns = false;
                    this.dataGridViewClassStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewClassStudents.DataSource = bindingSourceClassStudents;
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void PopulateClassSubjectsGrid()
        {
            bindingSourceClassSubjects.DataSource = null;
            groupBox2.Text = bindingSourceClassSubjects.Count.ToString();

            if (cbclass.SelectedIndex != -1)
            {
                try
                {
                    DAL.SchoolClass cls = (DAL.SchoolClass)cbclass.SelectedItem;

                    var _classSubjectsquery = from sub in db.ClassSubjects
                                              where sub.ClassId == cls.Id
                                              where sub.Status == "A"
                                              orderby sub.Subject.Description ascending
                                              select sub;
                    List<ClassSubject> _classSubjects = _classSubjectsquery.ToList();
                    bindingSourceClassSubjects.DataSource = _classSubjects;
                    groupBox2.Text = bindingSourceClassSubjects.Count.ToString();

                    var teachers = from pc in db.Teachers
                                   where pc.Status == "A"
                                   where pc.IsDeleted == false
                                   select pc;
                    bindingSourceSubjectTeacher.DataSource = teachers.ToList();
                    DataGridViewComboBoxColumn colCboxSubjectTeacher = new DataGridViewComboBoxColumn();
                    colCboxSubjectTeacher.HeaderText = "Teacher";
                    colCboxSubjectTeacher.Name = "cbClassSubjectTeacher";
                    colCboxSubjectTeacher.DataSource = bindingSourceSubjectTeacher;
                    // The display member is the name column in the column datasource  
                    colCboxSubjectTeacher.DisplayMember = "Name";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxSubjectTeacher.DataPropertyName = "SubjectTeacherId";
                    // The value member is the primary key of the parent table  
                    colCboxSubjectTeacher.ValueMember = "Id";
                    colCboxSubjectTeacher.MaxDropDownItems = 10;
                    colCboxSubjectTeacher.Width = 100;
                    colCboxSubjectTeacher.DisplayIndex = 2;
                    colCboxSubjectTeacher.MinimumWidth = 5;
                    colCboxSubjectTeacher.FlatStyle = FlatStyle.Flat;
                    colCboxSubjectTeacher.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxSubjectTeacher.ReadOnly = true;
                    colCboxSubjectTeacher.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    if (!this.dataGridViewClassSubjects.Columns.Contains("cbClassSubjectTeacher"))
                    {
                        dataGridViewClassSubjects.Columns.Add(colCboxSubjectTeacher);
                    }

                    var subjectsquery = from pc in db.Subjects
                                        where pc.Status == "A"
                                        where pc.IsDeleted == false
                                        select pc;
                    List<Subject> _subjects = subjectsquery.ToList();
                    DataGridViewComboBoxColumn colCboxSubject = new DataGridViewComboBoxColumn();
                    colCboxSubject.HeaderText = "Subject";
                    colCboxSubject.Name = "cbClassSubject";
                    colCboxSubject.DataSource = _subjects;
                    // The display member is the name column in the column datasource  
                    colCboxSubject.DisplayMember = "Description";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxSubject.DataPropertyName = "SubjectCode";
                    // The value member is the primary key of the parent table  
                    colCboxSubject.ValueMember = "ShortCode";
                    colCboxSubject.MaxDropDownItems = 10;
                    colCboxSubject.Width = 250;
                    colCboxSubject.DisplayIndex = 1;
                    colCboxSubject.MinimumWidth = 5;
                    colCboxSubject.FlatStyle = FlatStyle.Flat;
                    colCboxSubject.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxSubject.ReadOnly = true;
                    if (!this.dataGridViewClassSubjects.Columns.Contains("cbClassSubject"))
                    {
                        dataGridViewClassSubjects.Columns.Add(colCboxSubject);
                    }

                    dataGridViewClassSubjects.AutoGenerateColumns = false;
                    this.dataGridViewClassSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewClassSubjects.DataSource = bindingSourceClassSubjects;
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void PopulateRegisteredExamsGrid()
        {
            bindingSourceRegisteredExams.DataSource = null;
            groupBox4.Text = bindingSourceRegisteredExams.Count.ToString();

            if (cbclass.SelectedIndex != -1 && cbExamPeriod.SelectedIndex != -1 && dataGridViewClassSubjects.SelectedRows.Count != 0)
            {
                try
                {
                    SchoolClass _SchoolClass = (DAL.SchoolClass)cbclass.SelectedItem;

                    ExamPeriod _ExamPeriod = (DAL.ExamPeriod)cbExamPeriod.SelectedItem;

                    ClassSubject _ClassSubject = (ClassSubject)bindingSourceClassSubjects.Current;

                    var _Examquery = (from exm in db.Exams
                                      where exm.ExamPeriodId == _ExamPeriod.Id
                                      where exm.ClassId == _SchoolClass.Id
                                      where exm.SubjectShortCode == _ClassSubject.SubjectCode
                                      where exm.Enabled == true
                                      select exm).FirstOrDefault();
                    Exam _Exam = (Exam)_Examquery;

                    if (_Exam != null)
                    {
                        var _registeredexamsquery = from rg in db.RegisteredExams
                                                    join exm in db.Exams on rg.ExamId equals exm.Id
                                                    where rg.ExamId == _Exam.Id
                                                    where exm.ClassId == _SchoolClass.Id
                                                    where exm.Id == _Exam.Id
                                                    where exm.ExamPeriodId == _ExamPeriod.Id
                                                    where exm.Enabled == true
                                                    where exm.IsDeleted == false
                                                    orderby rg.ExamType.ShortCode
                                                    select rg;
                        List<RegisteredExam> _RegisteredExams = _registeredexamsquery.ToList();
                        bindingSourceRegisteredExams.DataSource = _RegisteredExams;
                        groupBox4.Text = bindingSourceRegisteredExams.Count.ToString();

                        var examtypesquery = from etyp in db.ExamTypes
                                             select etyp;
                        List<ExamType> _examTypes = examtypesquery.ToList();
                        DataGridViewComboBoxColumn colCboxExamTypes = new DataGridViewComboBoxColumn();
                        colCboxExamTypes.HeaderText = "Exam_Type";
                        colCboxExamTypes.Name = "cbExamTypes";
                        colCboxExamTypes.DataSource = _examTypes;
                        // The display member is the name column in the column datasource  
                        colCboxExamTypes.DisplayMember = "Description";
                        // The DataPropertyName refers to the foreign key column on the datagridview datasource
                        colCboxExamTypes.DataPropertyName = "ExamTypeId";
                        // The value member is the primary key of the parent table  
                        colCboxExamTypes.ValueMember = "Id";
                        colCboxExamTypes.MaxDropDownItems = 10;
                        colCboxExamTypes.Width = 180;
                        colCboxExamTypes.DisplayIndex = 1;
                        colCboxExamTypes.MinimumWidth = 5;
                        colCboxExamTypes.FlatStyle = FlatStyle.Flat;
                        colCboxExamTypes.DefaultCellStyle.NullValue = "--- Select ---";
                        colCboxExamTypes.ReadOnly = true;
                        //colCboxExamTypes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (!this.dataGridViewRegisteredExams.Columns.Contains("cbExamTypes"))
                        {
                            dataGridViewRegisteredExams.Columns.Add(colCboxExamTypes);
                        }

                        var roomsquery = from rm in db.Rooms
                                         select rm;
                        List<Room> _Rooms = roomsquery.ToList();
                        DataGridViewComboBoxColumn colCboxRooms = new DataGridViewComboBoxColumn();
                        colCboxRooms.HeaderText = "Room";
                        colCboxRooms.Name = "cbRooms";
                        colCboxRooms.DataSource = _Rooms;
                        // The display member is the name column in the column datasource  
                        colCboxRooms.DisplayMember = "Description";
                        // The DataPropertyName refers to the foreign key column on the datagridview datasource
                        colCboxRooms.DataPropertyName = "RoomId";
                        // The value member is the primary key of the parent table  
                        colCboxRooms.ValueMember = "Id";
                        colCboxRooms.MaxDropDownItems = 10;
                        colCboxRooms.Width = 100;
                        colCboxRooms.DisplayIndex = 5;
                        colCboxRooms.MinimumWidth = 5;
                        colCboxRooms.FlatStyle = FlatStyle.Flat;
                        colCboxRooms.DefaultCellStyle.NullValue = "--- Select ---";
                        colCboxRooms.ReadOnly = true;
                        colCboxRooms.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (!this.dataGridViewRegisteredExams.Columns.Contains("cbRooms"))
                        {
                            dataGridViewRegisteredExams.Columns.Add(colCboxRooms);
                        }

                        dataGridViewRegisteredExams.AutoGenerateColumns = false;
                        this.dataGridViewRegisteredExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridViewRegisteredExams.DataSource = bindingSourceRegisteredExams;
                    }
                    if (_Exam == null)
                    {
                        bindingSourceRegisteredExams.DataSource = null;
                        groupBox4.Text = bindingSourceRegisteredExams.Count.ToString();
                        dataGridViewRegisteredExams.AutoGenerateColumns = false;
                        this.dataGridViewRegisteredExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridViewRegisteredExams.DataSource = bindingSourceRegisteredExams;
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void PopulateRegisteredExams(RegisteredExam _registeredexam)
        {
            bindingSourceRegisteredExams.DataSource = null;
            groupBox4.Text = bindingSourceRegisteredExams.Count.ToString();

            if (cbclass.SelectedIndex != -1 && cbExamPeriod.SelectedIndex != -1 && dataGridViewClassSubjects.SelectedRows.Count != 0)
            {
                try
                {
                    SchoolClass _SchoolClass = (DAL.SchoolClass)cbclass.SelectedItem;
                    if (_SchoolClass == null)
                        throw new ArgumentNullException("Class is invalid");

                    ExamPeriod _ExamPeriod = (DAL.ExamPeriod)cbExamPeriod.SelectedItem;
                    if (_ExamPeriod == null)
                        throw new ArgumentNullException("ExamPeriod is invalid");

                    ClassSubject _ClassSubject = (ClassSubject)bindingSourceClassSubjects.Current;
                    if (_ClassSubject == null)
                        throw new ArgumentNullException("ClassSubject is invalid");

                    var _Examquery = (from exm in db.Exams
                                      where exm.ExamPeriodId == _ExamPeriod.Id
                                      where exm.ClassId == _SchoolClass.Id
                                      where exm.SubjectShortCode == _ClassSubject.SubjectCode
                                      where exm.Closed == false
                                      where exm.Enabled == true
                                      select exm).FirstOrDefault();
                    Exam _Exam = (Exam)_Examquery;

                    if (_Exam != null)
                    {
                        var _RegisteredExamsquery = from rg in db.RegisteredExams
                                                    join exm in db.Exams on rg.ExamId equals exm.Id
                                                    where exm.ClassId == _SchoolClass.Id
                                                    where exm.Id == _Exam.Id
                                                    where exm.ExamPeriodId == _ExamPeriod.Id
                                                    where exm.Enabled == true
                                                    where exm.Closed == false
                                                    orderby rg.ExamType.ShortCode
                                                    select rg;
                        List<RegisteredExam> _RegisteredExams = _RegisteredExamsquery.ToList();
                        bindingSourceRegisteredExams.DataSource = _RegisteredExams;
                        groupBox4.Text = bindingSourceRegisteredExams.Count.ToString();

                        var examtypesquery = from etyp in db.ExamTypes
                                             select etyp;
                        List<ExamType> _examTypes = examtypesquery.ToList();
                        DataGridViewComboBoxColumn colCboxExamTypes = new DataGridViewComboBoxColumn();
                        colCboxExamTypes.HeaderText = "Exam Type";
                        colCboxExamTypes.Name = "cbExamTypes";
                        colCboxExamTypes.DataSource = _examTypes;
                        // The display member is the name column in the column datasource  
                        colCboxExamTypes.DisplayMember = "Description";
                        // The DataPropertyName refers to the foreign key column on the datagridview datasource
                        colCboxExamTypes.DataPropertyName = "ExamTypeId";
                        // The value member is the primary key of the parent table  
                        colCboxExamTypes.ValueMember = "Id";
                        colCboxExamTypes.MaxDropDownItems = 10;
                        colCboxExamTypes.Width = 200;
                        colCboxExamTypes.DisplayIndex = 1;
                        colCboxExamTypes.MinimumWidth = 5;
                        colCboxExamTypes.FlatStyle = FlatStyle.Flat;
                        colCboxExamTypes.DefaultCellStyle.NullValue = "--- Select ---";
                        colCboxExamTypes.ReadOnly = true;
                        //colCboxExamTypes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (!this.dataGridViewRegisteredExams.Columns.Contains("cbExamTypes"))
                        {
                            dataGridViewRegisteredExams.Columns.Add(colCboxExamTypes);
                        }

                        var roomsquery = from rm in db.Rooms
                                         select rm;
                        List<Room> _Rooms = roomsquery.ToList();
                        DataGridViewComboBoxColumn colCboxRooms = new DataGridViewComboBoxColumn();
                        colCboxRooms.HeaderText = "Room";
                        colCboxRooms.Name = "cbRooms";
                        colCboxRooms.DataSource = _Rooms;
                        // The display member is the name column in the column datasource  
                        colCboxRooms.DisplayMember = "Description";
                        // The DataPropertyName refers to the foreign key column on the datagridview datasource
                        colCboxRooms.DataPropertyName = "RoomId";
                        // The value member is the primary key of the parent table  
                        colCboxRooms.ValueMember = "Id";
                        colCboxRooms.MaxDropDownItems = 10;
                        colCboxRooms.Width = 100;
                        colCboxRooms.DisplayIndex = 4;
                        colCboxRooms.MinimumWidth = 5;
                        colCboxRooms.FlatStyle = FlatStyle.Flat;
                        colCboxRooms.DefaultCellStyle.NullValue = "--- Select ---";
                        colCboxRooms.ReadOnly = true;
                        colCboxRooms.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                        if (!this.dataGridViewRegisteredExams.Columns.Contains("cbRooms"))
                        {
                            dataGridViewRegisteredExams.Columns.Add(colCboxRooms);
                        }

                        dataGridViewRegisteredExams.AutoGenerateColumns = false;
                        this.dataGridViewRegisteredExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dataGridViewRegisteredExams.DataSource = bindingSourceRegisteredExams;

                        var RegisteredExamquery = (from rg in db.RegisteredExams
                                                   where rg.Id == _registeredexam.Id
                                                   select rg).FirstOrDefault();
                        RegisteredExam _RegisteredExam = RegisteredExamquery;

                        tabControlReportsData.SelectedTab = tabPageRegdExams;
                        foreach (DataGridViewRow row in dataGridViewRegisteredExams.Rows)
                        {
                            var boundItem = (RegisteredExam)row.DataBoundItem;
                            if (boundItem.Id == _RegisteredExam.Id)
                            {
                                row.Selected = true;
                                int boundsrc = boundItem.Id;
                                bindingSourceRegisteredExams.Position = row.Index;
                                break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void saf_OnAccountListSelected(object sender, AccountSelectEventArgs e)
        {
            SetAccountNos(e._Account);
        }
        private void SetAccountNos(Account _Account)
        {
            if (_Account != null)
            {
                txtAccountId.Text = _Account.Id.ToString();
            }
        }
        private void ssf_OnStudentListSelected(object sender, StudentAccountsSelectEventArgs e)
        {
            SetstdAccountNos(e._StudentAccount);
        }
        private void SetstdAccountNos(Account _StudentAccount)
        {
            if (_StudentAccount != null)
            {
                txtAccountId.Text = _StudentAccount.Id.ToString();
            }
        }
        private void sepf_OnExamPeriodListSelected(object sender, ExamPeriodSelectEventArgs e)
        {
            SetExamPeriod(e._ExamPeriod);
        }
        private void SetExamPeriod(ExamPeriod _ExamPeriod)
        {
            try
            {
                if (_ExamPeriod != null)
                {
                    bindingSourceExamPeriod.DataSource = _ExamPeriod;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void f_OnReportFontSettingstHandler(object sender, ReportFontSettingsEventArgs e)
        {
            SetSelectedFonts(e._SelectedFontsDTO);
        }
        private void SetSelectedFonts(List<SelectedFontsDTO> _selectedfonts)
        {
            if (_selectedfonts != null)
            {
                SelectedFontsList = _selectedfonts;
            }
        }

        private void PrintTimeTablePerClassStream(ClassStream _clsStrm, TimeTable _timetable)
        {
            if (_clsStrm != null && _timetable != null && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    current_file_name = "Time Table for Class Stream " + _clsStrm.Description.ToString().Trim() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ClassStreamTimeTableViewModelBuilder _ModelBuilder = new ClassStreamTimeTableViewModelBuilder(_School, _clsStrm, _timetable, connection);
                    ClassStreamTimeTableViewModel _ViewModel = _ModelBuilder.GetViewModelBuilder();

                    this.DoPreProcess(this, null);

                    if (pdf_generator.ShowClassStreamTimeTable(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(this, null);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
        }
        #endregion "initialize"

        #region "combobox"
        private void cbclass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateClassStudentsGrid();

                PopulateClassSubjectsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateTermsCombo();
                PopulateRegisteredExamsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cbTerm_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateExamPeriodCombo();
                PopulateRegisteredExamsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cbExamPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateRegisteredExamsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "combobox"

        #region "datagridviews"
        private void dataGridViewClassSubjects_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewClassStudents_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewClassSubjects_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ExamResultBySubjectToolStripButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewClassStudents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                StudentReportFormToolStripMenuItem_Click(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewRegisteredExams_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ExamResultByExamTypeToolStripButton_Click(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewRegisteredExams_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewClassSubjects_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                PopulateRegisteredExamsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewClassSubjects_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateRegisteredExamsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSchools_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewSchools_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateClassStudentsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewProgrammes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateProgrammeClasses();
                cbclass_SelectedIndexChanged(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewProgrammes_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "datagridviews"

        #region "buttons"
        private void btnFeedChartData_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Charting ssf = new Charting() { Owner = this };
                //ssf.OnStudentAccountsListSelected += new SearchStudentAccountsSimpleForm.StudentAccountsSelectHandler(ssf_OnStudentListSelected);
                ssf.Show();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAccountStatement_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAccountId.Text))
                {
                    MessageBox.Show("Account Id cannot be null",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (cbYear.SelectedIndex != -1 && cbTerm.SelectedIndex != -1 && !string.IsNullOrEmpty(txtAccountId.Text) && dataGridViewSchools.SelectedRows.Count != 0)
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int term = int.Parse(cbTerm.Text);
                    int year = int.Parse(cbYear.Text);
                    int _accountid = int.Parse(txtAccountId.Text);
                    var _accountquery = (from ac in db.Accounts
                                         where ac.Id == _accountid
                                         select ac).FirstOrDefault();
                    Account _Account = _accountquery;
                    if (_Account == null)
                    {
                        MessageBox.Show("Account Does not Exist!", "SB School");
                        return;
                    }
                    if (_Account != null)
                    {
                        current_file_name = "Statement  " + _Account.AccountNo + " - " + _Account.AccountName + "  " + term.ToString() + "  " + year.ToString() + ".pdf";

                        _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                        StatementViewModelBuilder _ModelBuilder =
                                           new StatementViewModelBuilder(_School, _accountid, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, connection);
                        StatementViewModel _ViewModel = _ModelBuilder.GetViewModel();

                        this.DoPreProcess(sender, e);

                        if (pdf_generator.ShowStatement(_ViewModel, get_reports_uri(current_file_name)))
                        {
                            DoShowPDF(current_file_name);
                        }

                        this.DoPostProcess(sender, e);
                    }
                }
                else
                {
                    MessageBox.Show("Please Select a School and an Exam Period", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                Utils.ShowError(ex);
            }
        }
        private void btnSearchbyStudent_Click(object sender, EventArgs e)
        {
            try
            {
                SearchStudentAccountsSimpleForm ssf = new Forms.SearchStudentAccountsSimpleForm(connection) { Owner = this };
                ssf.OnStudentAccountsListSelected += new SearchStudentAccountsSimpleForm.StudentAccountsSelectHandler(ssf_OnStudentListSelected);
                ssf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchAccountsSimpleForm saf = new Forms.SearchAccountsSimpleForm(connection) { Owner = this };
                saf.OnAccountListSelected += new SearchAccountsSimpleForm.AccountSelectHandler(saf_OnAccountListSelected);
                saf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSearchExamPeriods_Click(object sender, EventArgs e)
        {
            try
            {
                SearchExamPeriodsSimpleForm sepf = new Forms.SearchExamPeriodsSimpleForm(connection) { Owner = this };
                sepf.OnExamPeriodListSelected += new SearchExamPeriodsSimpleForm.ExamPeriodSelectHandler(sepf_OnExamPeriodListSelected);
                sepf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #endregion "buttons"

        #region "menus"
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void toolStripButtonTeacher_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                Utils.ShowError(ex);
            }
        }
        private void toolStripButtonClass_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                Utils.ShowError(ex);
            }
        }
        private void toolStripButtonTransaction_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                Utils.ShowError(ex);
            }

        }
        private void toolStripButtonMarkSheetExam_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                Utils.ShowError(ex);
            }
        }
        private void ExamResultByClasstoolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (cbExamPeriod.SelectedIndex != -1 && cbclass.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    DAL.SchoolClass _SchoolClass = (DAL.SchoolClass)cbclass.SelectedItem;

                    DAL.ExamPeriod _ExamPeriod = (DAL.ExamPeriod)bindingSourceExamPeriod.Current;

                    current_file_name = "Exam Results  " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ExamResultsByClassViewModelBuilder _ModelBuilder = new ExamResultsByClassViewModelBuilder(_School, _ExamPeriod, _SchoolClass, connection);
                    ExamResultsByClassViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowExamResultByExamPeriodByClass(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Class and an Exam Period",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ExamResultBySubjectToolStripButton_Click(object sender, EventArgs e)
        {
            if (cbExamPeriod.SelectedIndex != -1 && cbclass.SelectedIndex != -1 && dataGridViewClassSubjects.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;


                    string _ClassSubjectShortCode = ((DAL.ClassSubject)bindingSourceClassSubjects.Current).SubjectCode;

                    var _Subjectquery = (from sj in db.Subjects
                                         where sj.ShortCode == _ClassSubjectShortCode
                                         select sj).FirstOrDefault();

                    DAL.Subject _Subject = (DAL.Subject)_Subjectquery;

                    DAL.SchoolClass _SchoolClass = (DAL.SchoolClass)cbclass.SelectedItem;

                    DAL.ExamPeriod _ExamPeriod = (DAL.ExamPeriod)cbExamPeriod.SelectedItem;

                    current_file_name = "Exam Results  " + _SchoolClass.ClassName + " " + _Subject.Description.Trim() + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";
                    current_file_name = current_file_name.Replace(@"/", "");

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ExamResultsBySubjectViewModelBuilder _ModelBuilder = new ExamResultsBySubjectViewModelBuilder(_School, _ExamPeriod, _SchoolClass, _Subject, connection);
                    ExamResultsBySubjectViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowExamResultBySubject(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Class Subject and an Exam Period",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ExamResultByExamTypeToolStripButton_Click(object sender, EventArgs e)
        {
            if (cbExamPeriod.SelectedIndex != -1 && cbclass.SelectedIndex != -1 && dataGridViewRegisteredExams.SelectedRows.Count != 0 && dataGridViewClassSubjects.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;

                    string _ClassSubjectShortCode = ((DAL.ClassSubject)bindingSourceClassSubjects.Current).SubjectCode;

                    var _Subjectquery = (from sj in db.Subjects
                                         where sj.ShortCode == _ClassSubjectShortCode
                                         select sj).FirstOrDefault();

                    DAL.Subject _Subject = (DAL.Subject)_Subjectquery;

                    DAL.SchoolClass _SchoolClass = (DAL.SchoolClass)cbclass.SelectedItem;

                    DAL.ExamPeriod _ExamPeriod = (DAL.ExamPeriod)bindingSourceExamPeriod.Current;

                    RegisteredExam _RegisteredExam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    if (_RegisteredExam != null)
                    {

                        var _Examtypequery = (from etyp in db.ExamTypes
                                              where etyp.Id == _RegisteredExam.ExamTypeId
                                              select etyp).FirstOrDefault();
                        ExamType _ExamType = _Examtypequery;

                        current_file_name = "Exam Results  " + _SchoolClass.ClassName + " " + _ExamType.ShortCode.Trim() + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                        _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                        ExamResultsByExamTypeViewModelBuilder _ModelBuilder = new ExamResultsByExamTypeViewModelBuilder(_School, _RegisteredExam, _ExamPeriod, _SchoolClass, _ExamType, connection);
                        ExamResultsByExamTypeViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                        this.DoPreProcess(sender, e);

                        if (pdf_generator.ShowExamResultByExamType(_ViewModel, get_reports_uri(current_file_name)))
                        {
                            DoShowPDF(current_file_name);
                        }

                        this.DoPostProcess(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Class Subject and an Exam Period",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void toolStripButtonTimeTable_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                Utils.ShowError(ex);
            }
        }
        private void ProgrammeCourseListtoolStripMenuItemButton_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && cbYear.SelectedIndex != -1 && cbTerm.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int _Year = (int)cbYear.SelectedItem;

                    int _Term = (int)cbTerm.SelectedItem;

                    DAL.Programme _Programme = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Programme Course List " + _Programme.Description + " " + _Term.ToString() + " " + _Year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ProgrammeCourseListViewModelBuilder _ModelBuilder = new ProgrammeCourseListViewModelBuilder(_School, _Programme, connection);
                    ProgrammeCourseListViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowProgrammeCourseList(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School, a Programme, a year and a Term ", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void secondaryMarkSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check that the selected _school is a secondary _school
            if (this.cbExamPeriod.SelectedIndex != -1 && this.cbclass.SelectedIndex != -1 && dataGridViewRegisteredExams.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    //SelectFontsForm f = new SelectFontsForm() { Owner=this };

                    ////use a delegate to get the selected fonts
                    //f.OnReportFontSettingstHandler += new SelectFontsForm.ReportFontSettingstHandler(f_OnReportFontSettingstHandler);
                    //f.ShowDialog();

                    RegisteredExam _RegisteredExam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    ExamPeriod _ExamPeriod = (DAL.ExamPeriod)cbExamPeriod.SelectedItem;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    current_file_name = "Secondary  Mark  Sheet  " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ///TODO get a list of class ExamTypes
                    List<string> subjectcodes = new List<string>();
                    if (_SchoolClass == null)
                        throw new ArgumentNullException("SchoolClass is invalid");

                    subjectcodes = rep.GetClassSubjectCodes(_SchoolClass.Id);

                    SecondaryMarkSheetViewModelBuilder secondaryMarkSheetViewModelbuilder = new SecondaryMarkSheetViewModelBuilder(_School, _RegisteredExam, _ExamPeriod, _SchoolClass, connection);
                    SecondaryMarkSheetViewModel _ViewModel = secondaryMarkSheetViewModelbuilder.GetViewModel();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowSecondaryMarkSheet(_ViewModel, subjectcodes, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }

        }
        private void primaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check that the selected _school is a secondary _school
            if (this.cbExamPeriod.SelectedIndex != -1 && this.cbclass.SelectedIndex != -1 && dataGridViewRegisteredExams.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    //SelectFontsForm f = new SelectFontsForm() { Owner = this };

                    ////use a delegate to get the selected fonts
                    //f.OnReportFontSettingstHandler += new SelectFontsForm.ReportFontSettingstHandler(f_OnReportFontSettingstHandler);
                    //f.ShowDialog();

                    RegisteredExam _RegisteredExam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    ExamPeriod _ExamPeriod = (DAL.ExamPeriod)cbExamPeriod.SelectedItem;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    current_file_name = "Primary  Mark  Sheet  " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ///TODO get a list of class ExamTypes
                    List<string> subjectcodes = new List<string>();

                    if (_SchoolClass == null)
                        throw new ArgumentNullException("SchoolClass is invalid");
                    subjectcodes = rep.GetClassSubjectCodes(_SchoolClass.Id);

                    PrimaryMarksheetViewModelBuilder _ModelBuilder = new PrimaryMarksheetViewModelBuilder(_School, _RegisteredExam, _ExamPeriod, _SchoolClass, connection);
                    PrimaryMarksheetViewModel _ViewModel = _ModelBuilder.GetViewModel();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowPrimaryMarksheet(_ViewModel, subjectcodes, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }

        }
        private void preSchoolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check that the selected _school is a secondary _school
            if (this.cbExamPeriod.SelectedIndex != -1 && this.cbclass.SelectedIndex != -1 && dataGridViewRegisteredExams.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    //SelectFontsForm f = new SelectFontsForm() { Owner = this }; 
                    //use a delegate to get the selected fonts
                    //f.OnReportFontSettingstHandler += new SelectFontsForm.ReportFontSettingstHandler(f_OnReportFontSettingstHandler);
                    //f.ShowDialog();

                    RegisteredExam _RegisteredExam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    ExamPeriod _ExamPeriod = (DAL.ExamPeriod)cbExamPeriod.SelectedItem;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    current_file_name = "Pre School Mark  Sheet  " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ///TODO get a list of class ExamTypes
                    List<string> subjectcodes = new List<string>();
                    if (_SchoolClass == null)
                        throw new ArgumentNullException("SchoolClass is invalid");
                    subjectcodes = rep.GetClassSubjectCodes(_SchoolClass.Id);

                    PreSchoolMarksheetViewModelBuilder _ModelBuilder = new PreSchoolMarksheetViewModelBuilder(_School, _RegisteredExam, _ExamPeriod, _SchoolClass, connection);
                    PreSchoolMarksheetViewModel _ViewModel = _ModelBuilder.GetViewModel();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowPreSchoolMarksheeet(_ViewModel, subjectcodes, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }

        }
        private void tertiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check that the selected _school is a secondary _school
            if (this.cbExamPeriod.SelectedIndex != -1 && this.cbclass.SelectedIndex != -1 && dataGridViewRegisteredExams.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    //SelectFontsForm f = new SelectFontsForm() { Owner = this };

                    ////use a delegate to get the selected fonts
                    //f.OnReportFontSettingstHandler += new SelectFontsForm.ReportFontSettingstHandler(f_OnReportFontSettingstHandler);
                    //f.ShowDialog();

                    RegisteredExam _RegisteredExam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    ExamPeriod _ExamPeriod = (DAL.ExamPeriod)cbExamPeriod.SelectedItem;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    current_file_name = "Tertiary  Mark  Sheet   " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ///TODO get a list of class ExamTypes
                    List<string> subjectcodes = new List<string>();

                    if (_SchoolClass == null)
                        throw new ArgumentNullException("SchoolClass is invalid");
                    subjectcodes = rep.GetClassSubjectCodes(_SchoolClass.Id);

                    TertiaryMarksheetViewModelBuilder _ModelBuilder = new TertiaryMarksheetViewModelBuilder(_School, _RegisteredExam, _ExamPeriod, _SchoolClass, connection);
                    TertiaryMarksheetViewModel _ViewModel = _ModelBuilder.GetViewModel();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowTertiaryMarksheet(_ViewModel, subjectcodes, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }

        }
        private void collegeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check that the selected _school is a secondary _school
            if (this.cbExamPeriod.SelectedIndex != -1 && this.cbclass.SelectedIndex != -1 && dataGridViewRegisteredExams.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    //SelectFontsForm f = new SelectFontsForm() { Owner = this };

                    ////use a delegate to get the selected fonts
                    //f.OnReportFontSettingstHandler += new SelectFontsForm.ReportFontSettingstHandler(f_OnReportFontSettingstHandler);
                    //f.ShowDialog();

                    RegisteredExam _RegisteredExam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    ExamPeriod _ExamPeriod = (DAL.ExamPeriod)cbExamPeriod.SelectedItem;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    current_file_name = "College  Mark  Sheet  " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ///TODO get a list of class ExamTypes
                    List<string> subjectcodes = new List<string>();

                    if (_SchoolClass == null)
                        throw new ArgumentNullException("SchoolClass is invalid");
                    subjectcodes = rep.GetClassSubjectCodes(_SchoolClass.Id);

                    CollegeMarksheetViewModelBuilder _ModelBuilder = new CollegeMarksheetViewModelBuilder(_School, _RegisteredExam, _ExamPeriod, _SchoolClass, connection);
                    CollegeMarksheetViewModel _ViewModel = _ModelBuilder.GetViewModel();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowCollegeMarksheeet(_ViewModel, subjectcodes, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }

        }
        private void universityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check that the selected _school is a secondary _school
            if (this.cbExamPeriod.SelectedIndex != -1 && this.cbclass.SelectedIndex != -1 && dataGridViewRegisteredExams.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    //SelectFontsForm f = new SelectFontsForm() { Owner = this };

                    ////use a delegate to get the selected fonts
                    //f.OnReportFontSettingstHandler += new SelectFontsForm.ReportFontSettingstHandler(f_OnReportFontSettingstHandler);
                    //f.ShowDialog();

                    RegisteredExam _RegisteredExam = (RegisteredExam)bindingSourceRegisteredExams.Current;

                    ExamPeriod _ExamPeriod = (DAL.ExamPeriod)cbExamPeriod.SelectedItem;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    if (_SchoolClass == null)
                        throw new ArgumentNullException("SchoolClass is invalid");

                    current_file_name = "University  Mark Sheet   " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ///TODO get a list of class ExamTypes
                    List<string> subjectcodes = new List<string>();
                    subjectcodes = rep.GetClassSubjectCodes(_SchoolClass.Id);

                    UniversityMarksheeetViewModelBuilder _ModelBuilder = new UniversityMarksheeetViewModelBuilder(_School, _RegisteredExam, _ExamPeriod, _SchoolClass, connection);
                    UniversityMarksheeetViewModel _ViewModel = _ModelBuilder.GetViewModel();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowUniversityMarksheeet(_ViewModel, subjectcodes, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }

        }
        private void studentListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbclass.SelectedIndex != -1 && cbYear.SelectedIndex != -1 && cbTerm.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    DAL.SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    int _Year = (int)cbYear.SelectedItem;

                    int _Term = (int)cbTerm.SelectedItem;

                    current_file_name = "Students List " + _SchoolClass.ClassName + " " + _Term.ToString() + " " + _Year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentListViewModelBuilder _ModelBuilder = new StudentListViewModelBuilder(_School, _SchoolClass, connection);
                    StudentListViewModel _ViewModel = _ModelBuilder.GetStudentListViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentList(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);

                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Class, a Year and a Term",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void classListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbYear.SelectedIndex != -1 && cbTerm.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int _Year = (int)cbYear.SelectedItem;

                    int _Term = (int)cbTerm.SelectedItem;

                    current_file_name = "Classes List " + _Term.ToString() + " " + _Year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ClassListViewModelBuilder _ModelBuilder = new ClassListViewModelBuilder(_School, connection);
                    ClassListViewModel _ViewModel = _ModelBuilder.GetViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowClassList(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);

                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Year and a Term",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void subjectListsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbclass.SelectedIndex != -1 && cbYear.SelectedIndex != -1 && cbTerm.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int _Year = (int)cbYear.SelectedItem;

                    int _Term = (int)cbTerm.SelectedItem;

                    DAL.SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    current_file_name = "Subjects List " + _SchoolClass.ClassName + " " + _Term.ToString() + " " + _Year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    SubjectListViewModelBuilder _modelBuilder = new SubjectListViewModelBuilder(_School, _SchoolClass, connection);
                    SubjectListViewModel _ViewModel = _modelBuilder.GetViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowSubjectList(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Class a Year and a Term",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void studentProgressFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewClassStudents.SelectedRows.Count != 0 && cbExamPeriod.SelectedIndex != -1 && cbclass.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    Student _Student = (Student)bindingSourceClassStudents.Current;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    ExamPeriod _ExamPeriod = (ExamPeriod)cbExamPeriod.SelectedItem;

                    current_file_name = "Student Progress Report " + _Student.AdminNo + " - " + _Student.StudentSurName.Trim() + "  " + _Student.StudentOtherNames.Trim() + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentProgressFormViewModelBuilder _ModelBuilder = new StudentProgressFormViewModelBuilder(_School, _Student, _SchoolClass, _ExamPeriod, connection);
                    StudentProgressFormViewModel _ViewModel = _ModelBuilder.GetViewModel();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentProgressForm(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School, a Class, an Exam Period and a Student", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void studentPerformanceByTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewClassStudents.SelectedRows.Count != 0 && cbExamPeriod.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    Student _Student = (Student)bindingSourceClassStudents.Current;

                    ExamPeriod _ExamPeriod = (ExamPeriod)cbExamPeriod.SelectedItem;

                    current_file_name = "Student Performance By Target  " + _Student.AdminNo + " - " + _Student.StudentOtherNames.Trim() + "  " + _Student.StudentSurName.Trim() + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentPerformanceByTargetViewModelBuilder _ModelBuilder = new StudentPerformanceByTargetViewModelBuilder(_School, connection);
                    StudentPerformanceByTargetViewModel _ViewModel = _ModelBuilder.GetStudentPerformanceByTargetClassViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentPerformanceByTarget(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);

                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School, an Exam Period and a Student, ", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void classReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Check that the selected _school is a secondary _school
            if (cbclass.SelectedIndex != -1 && cbExamPeriod.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    ExamPeriod _ExamPeriod = (ExamPeriod)cbExamPeriod.SelectedItem;

                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(_SchoolClass.Id);

                    current_file_name = "Class Terminal Report " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    List<string> subjectcodes = new List<string>();

                    if (_SchoolClass == null)
                        throw new ArgumentNullException("SchoolClass is invalid");
                    subjectcodes = rep.GetClassSubjectCodes(_SchoolClass.Id);

                    ClassReportFormViewModelBuilder _ModelBuilder = new ClassReportFormViewModelBuilder(_School, _SchoolClass, connection);
                    ClassReportFormViewModel _ViewModel = _ModelBuilder.GetViewModel();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowClassReportForm(_ViewModel, subjectcodes, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School, a Class and an Exam Period", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void classProgressFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbclass.SelectedIndex != -1 && cbExamPeriod.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    ExamPeriod _ExamPeriod = (ExamPeriod)cbExamPeriod.SelectedItem;

                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(_SchoolClass.Id);

                    current_file_name = "Class Progress Report " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ClassProgressFormViewModelBuilder _ModelBuilder = new ClassProgressFormViewModelBuilder(_School, _SchoolClass, connection);
                    ClassProgressFormViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowClassProgressForm(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School, a Class and an Exam PEriod", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void classPerformanceByTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbclass.SelectedIndex != -1 && cbExamPeriod.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    ExamPeriod _ExamPeriod = (ExamPeriod)cbExamPeriod.SelectedItem;

                    current_file_name = "Class Performance By Target " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ClassPerformanceByTargetViewModelBuilder _ModelBuilder = new ClassPerformanceByTargetViewModelBuilder(_School, _SchoolClass, connection);
                    ClassPerformanceByTargetViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowClassPerformanceByTarget(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School, a Class and an Exam PEriod", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void classConsolidatedMarksheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbclass.SelectedIndex != -1 && cbExamPeriod.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    ExamPeriod _ExamPeriod = (ExamPeriod)cbExamPeriod.SelectedItem;

                    current_file_name = "Class Consolidated Mark Sheet " + _SchoolClass.ClassName + " " + _ExamPeriod.Term + " " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ClassConsolidatedMarksheetViewModelBuilder _ModelBuilder = new ClassConsolidatedMarksheetViewModelBuilder(_School, _SchoolClass, connection);
                    ClassConsolidatedMarksheetViewModel _ViewModel = _ModelBuilder.GetClassConsolidatedMarksheetViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowClassConsolidatedMarksheet(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School, a Class and an Exam PEriod", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void teacherReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    int term = int.Parse(cbTerm.Text);
                    int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Teacher Terminal Report " + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    TeacherReportFormViewModelBuilder _ModelBuilder = new TeacherReportFormViewModelBuilder(_School, programmes, connection);
                    TeacherReportFormViewModel _ViewModel = _ModelBuilder.GetTeacherAcademicReportFormViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowTeacherReportForm(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School, and a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void teacherProgressFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbclass.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    current_file_name = "Teacher Progress Report" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    TeacherProgressFormViewModelBuilder _ModelBuilder = new TeacherProgressFormViewModelBuilder(_School, _SchoolClass, connection);
                    TeacherProgressFormViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowTeacherProgressForm(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School and a Class", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void teacherPerformanceByTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbclass.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    current_file_name = "Teacher Performance By Target" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    TeacherPerformanceByTargetViewModelBuilder _ModelBuilder = new TeacherPerformanceByTargetViewModelBuilder(_School, _SchoolClass, connection);
                    TeacherPerformanceByTargetViewModel _ViewModel = _ModelBuilder.GetTeacherPerformanceByTargetViewModelBuilder();


                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowTeacherPerformanceByTarget(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School and a Class", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void SchoolReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    current_file_name = "School Terminal Report" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    SchoolReportFormViewModelBuilder _ModelBuilder = new SchoolReportFormViewModelBuilder(_School, connection);
                    SchoolReportFormViewModel _ViewModel = _ModelBuilder.GetSchoolReportFormViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowSchoolReportForm(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void schoolProgressFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    current_file_name = "School Progress Report" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    SchoolProgressFormViewModelBuilder _ModelBuilder = new SchoolProgressFormViewModelBuilder(_School, connection);
                    SchoolProgressFormViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowSchoolProgressForm(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void schoolPerformanceByTargetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    current_file_name = "School Performance By Target" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    SchoolPerformanceByTargetViewModelBuilder _ModelBuilder = new SchoolPerformanceByTargetViewModelBuilder(_School, connection);
                    SchoolPerformanceByTargetViewModel _ViewModel = _ModelBuilder.GetSchoolPerformanceByTargetViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowSchoolPerformanceByTarget(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void schoolPerformanceInTheRegionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    current_file_name = "School Performance in The Region" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    SchoolPerformanceInTheRegionViewModelBuilder _ModelBuilder = new SchoolPerformanceInTheRegionViewModelBuilder(_School, connection);
                    SchoolPerformanceInTheRegionViewModel _ViewModel = _ModelBuilder.GetSchoolPerformanceInTheRegionViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowSchoolPerformanceInTheRegion(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void studentStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewClassStudents.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    Student _Student = (Student)bindingSourceClassStudents.Current;

                    var _accountquery = (from ac in db.Accounts
                                         where ac.Id == _Student.GLAccountId
                                         where ac.Closed == false
                                         select ac).FirstOrDefault();
                    Account _Account = _accountquery;

                    if (_Account != null)
                    {

                        current_file_name = "Student Statement   " + _Account.AccountNo + " - " + _Account.AccountName + ".pdf";

                        _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                        StudentStatementViewModelBuilder svmBuilder =
                                           new StudentStatementViewModelBuilder(_School, _Account.Id, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, connection);
                        StudentStatementViewModel _ViewModel = svmBuilder.GetViewModel();

                        this.DoPreProcess(sender, e);

                        if (pdf_generator.ShowStudentStatement(_ViewModel, get_reports_uri(current_file_name)))
                        {
                            DoShowPDF(current_file_name);
                        }

                        this.DoPostProcess(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void studentAccountStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    int term = int.Parse(cbTerm.Text);
                    int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Student Acccount Status" + " " + term.ToString() + " " + year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentAccountStatusViewModelBuilder _ModelBuilder = new StudentAccountStatusViewModelBuilder(_School, programmes, connection);
                    StudentAccountStatusViewModel _ViewModel = _ModelBuilder.GetStudentAccountStatusViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentAccountStatus(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School and a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void arrearsReceivablesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    int term = int.Parse(cbTerm.Text);
                    int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Arrears and Receivables" + " " + term.ToString() + " " + year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentArrearsAndReceivablesViewModelBuilder _ModelBuilder = new StudentArrearsAndReceivablesViewModelBuilder(_School, programmes, connection);
                    StudentArrearsAndReceivablesViewModel _ViewModel = _ModelBuilder.GetStudentArrearsAndReceivablesViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentArrearsAndReceivables(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School and a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void parentStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAccountId.Text))
                {
                    MessageBox.Show("Account Id cannot be null",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                School _School = (School)bindingSourceSchools.Current;

                int term = int.Parse(cbTerm.Text);
                int year = int.Parse(cbYear.Text);
                int accid = int.Parse(txtAccountId.Text);

                current_file_name = "Parent Statement" + " " + term.ToString() + " " + year.ToString() + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                ParentStatementViewModelBuilder _ModelBuilder =
                                   new ParentStatementViewModelBuilder(_School, accid, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, connection);
                ParentStatementViewModel _ViewModel = _ModelBuilder.GetViewModel();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowParentStatement(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void parentAccountStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    int term = int.Parse(cbTerm.Text);
                    int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Parent Account Status" + " " + term.ToString() + " " + year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ParentAccountStatusViewModelBuilder _ModelBuilder = new ParentAccountStatusViewModelBuilder(_School, programmes, connection);
                    ParentAccountStatusViewModel _ViewModel = _ModelBuilder.GetParentAccountStatusViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowParentAccountStatus(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School and a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void paymentReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    int term = int.Parse(cbTerm.Text);
                    int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Payment Receipts" + " " + term.ToString() + " " + year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentPaymentReceiptsViewModelBuilder _ModelBuilder = new StudentPaymentReceiptsViewModelBuilder(_School, programmes, connection);
                    PaymentReceiptsViewModel _ViewModel = _ModelBuilder.GetPaymentReceiptsViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentPaymentReceipts(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select a School and a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void studentFeesStructureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewClassStudents.SelectedRows.Count != 0 && cbExamPeriod.SelectedIndex != -1 && cbclass.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    ExamPeriod _ExamPeriod = (ExamPeriod)cbExamPeriod.SelectedItem;

                    DAL.Student _Student = (Student)bindingSourceClassStudents.Current;

                    current_file_name = "Student Fee Structure  " + _Student.AdminNo + " - " + _Student.StudentSurName + " " + _Student.StudentOtherNames + " " + _ExamPeriod.Term + "  " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentFeeStructureViewModelBuilder _ModelBuilder = new StudentFeeStructureViewModelBuilder(_School, _SchoolClass, _ExamPeriod.Year, _ExamPeriod.Term, _Student, connection);
                    StudentFeeStructureViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentFeeStructure(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Class, an Exam Period and a Student",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void generalLedgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAccountId.Text))
                {
                    MessageBox.Show("Account Id cannot be null",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                School _School = (School)bindingSourceSchools.Current;

                int term = int.Parse(cbTerm.Text);
                int year = int.Parse(cbYear.Text);
                int accid = int.Parse(txtAccountId.Text);

                current_file_name = "Statement_" + accid + " " + term.ToString() + " " + year.ToString() + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                GeneralLedgerViewModelBuilder _ModelBuilder =
                                   new GeneralLedgerViewModelBuilder(_School, accid, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, connection);
                GeneralLegderViewModel _ViewModel = _ModelBuilder.BuildGLViewModel();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowGeneralLegder(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void profitandLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbYear.SelectedIndex != -1 && cbTerm.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int _Year = (int)cbYear.SelectedItem;

                    int _Term = (int)cbTerm.SelectedItem;

                    current_file_name = "Profit And Loss " + _Term.ToString() + " " + _Year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    ProfitAndLossViewModelBuilder profitAndLossViewModelBuilder = new ProfitAndLossViewModelBuilder(_School, connection);
                    ProfitAndLossViewModel _ViewModel = profitAndLossViewModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowProfitAndLoss(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Year and a Term",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void bSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    //int term = int.Parse(cbTerm.Text);
                    //int year = int.Parse(cbYear.Text); 

                    current_file_name = _School.SchoolName.ToString() + " Balance Sheet " + ".pdf";

                    BalanceSheetViewModelBuilder balanceSheetViewModelBuilder = new BalanceSheetViewModelBuilder(_School, connection);
                    BalanceSheetViewModel balanceSheetViewModel = balanceSheetViewModelBuilder.GetModelBuilder();
                    BalanceSheetPDFBuilder balanceSheetPDFBuilder = new BalanceSheetPDFBuilder(balanceSheetViewModel, current_file_name, connection);
                    balanceSheetPDFBuilder.GetPDF();
                    DoShowPDF(current_file_name);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void bankStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtAccountId.Text))
                {
                    MessageBox.Show("Account Id cannot be null",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                School _School = (School)bindingSourceSchools.Current;

                int accid = int.Parse(txtAccountId.Text);

                current_file_name = "Bank Statement " + ".pdf";

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                BankStatementViewModelBuilder _ModelBuilder =
                                   new BankStatementViewModelBuilder(_School, accid, dateTimePickerStartDate.Value, dateTimePickerEndDate.Value, connection);
                BankStatementViewModel _ViewModel = _ModelBuilder.GetViewModel();

                this.DoPreProcess(sender, e);

                if (pdf_generator.ShowBankStatement(_ViewModel, get_reports_uri(current_file_name)))
                {
                    DoShowPDF(current_file_name);
                }

                this.DoPostProcess(sender, e);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cashBookToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void arrearsReceivablesToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
        private void payablesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void feeStructureByClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbclass.SelectedIndex != -1 && cbTerm.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    DAL.SchoolClass SchoolClass = (DAL.SchoolClass)cbclass.SelectedItem;
                    int _Year = (int)cbYear.SelectedItem;
                    int _Term = (int)cbTerm.SelectedItem;

                    current_file_name = "Fee Structure  " + SchoolClass.ClassName + "  " + _Term.ToString() + " " + _Year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    FeeStructureByClassViewModelBuilder _ModelBuilder = new FeeStructureByClassViewModelBuilder(_School, SchoolClass, _Year, _Term, connection);
                    FeeStructureByClassViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowFeeStructureByClass(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Class, a Year and a Term",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void feeStructureByProgrammeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    //int term = int.Parse(cbTerm.Text);
                    //int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = programmes.Description.ToString() + ".pdf";

                    FeeStructureByProgrammeViewModelBuilder feeStructureByClassViewModelBuilder = new FeeStructureByProgrammeViewModelBuilder(_School, programmes, connection);
                    FeeStructureByProgrammeViewModel feeStructureByProgrammeViewModel = feeStructureByClassViewModelBuilder.GetFeeStructureByProgrammeViewModelBuilder();
                    FeeStructureByProgrammePDFBuilder feeStructureByProgrammePDFBuilder = new FeeStructureByProgrammePDFBuilder(feeStructureByProgrammeViewModel, current_file_name);
                    feeStructureByProgrammePDFBuilder.GetPDF();

                    DoShowPDF(current_file_name);

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please Select a School, a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void feeStructureByAccountTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    //int term = int.Parse(cbTerm.Text);
                    //int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = programmes.Description.ToString() + ".pdf";

                    FeeStructureByAccountTypeViewModelBuilder feeStructureByAccountTypeViewModelBuilder = new FeeStructureByAccountTypeViewModelBuilder(_School, programmes, connection);
                    FeeStructureByAccountTypesViewModel feeStructureByAccountTypesViewModel = feeStructureByAccountTypeViewModelBuilder.GetFeeStructureByAccountTypesViewModelBuilder();
                    FeeStructureByAccountTypesPDFBuilder feeStructureByAccountTypesPDFBuilder = new FeeStructureByAccountTypesPDFBuilder(feeStructureByAccountTypesViewModel, current_file_name);
                    feeStructureByAccountTypesPDFBuilder.GetPDF();

                    DoShowPDF(current_file_name);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please Select a School, a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void disciplineStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    //int term = int.Parse(cbTerm.Text);
                    //int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Student Discipline Status" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentDisciplineStatusViewModelBuilder _ModelBuilder = new StudentDisciplineStatusViewModelBuilder(_School, programmes, connection);
                    StudentDisciplineStatusViewModel _ViewModel = _ModelBuilder.GetStudentDisciplineStatusViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentDisciplineStatus(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please Select a School, a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void disciplinaryRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    //int term = int.Parse(cbTerm.Text);
                    //int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Student Disciplinary Record" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentDisciplinaryRecordViewModelBuilder _ModelBuilder = new StudentDisciplinaryRecordViewModelBuilder(_School, programmes, connection);
                    StudentDisciplinaryRecordViewModel _ViewModel = _ModelBuilder.GetStudentDisciplinaryRecordViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentDisciplinaryRecord(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please Select a School, a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void extraCurriculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    //int term = int.Parse(cbTerm.Text);
                    //int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Extra Curricular Activities" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentExtraCurriculaViewModelBuilder _ModelBuilder = new StudentExtraCurriculaViewModelBuilder(_School, programmes, connection);
                    StudentExtraCurriculaViewModel _ViewModel = _ModelBuilder.GetStudentExtraCurriculaViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentExtraCurricula(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please Select a School, a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void medicalRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    //int term = int.Parse(cbTerm.Text);
                    //int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Medical Record" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentMedicalRecordViewModelBuilder _ModelBuilder = new StudentMedicalRecordViewModelBuilder(_School, programmes, connection);
                    StudentMedicalRecordViewModel _ViewModel = _ModelBuilder.GetStudentMedicalRecordViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentMedicalRecord(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please Select a School, a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void attendanceRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewProgrammes.SelectedRows.Count != 0 && dataGridViewSchools.SelectedRows.Count != 0)
            {

                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int classid = ((SchoolClass)cbclass.SelectedItem).Id;
                    List<DAL.ClassSubject> cs = rep.GetAllClassSubjects(classid);
                    //int term = int.Parse(cbTerm.Text);
                    //int year = int.Parse(cbYear.Text);
                    DAL.Programme programmes = (DAL.Programme)bindingSourceProgrammes.Current;

                    current_file_name = "Student Attendance Record" + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentAttendanceRecordViewModelBuilder _ModelBuilder = new StudentAttendanceRecordViewModelBuilder(_School, programmes, connection);
                    StudentAttendanceRecordViewModel _ViewModel = _ModelBuilder.GetStudentAttendanceRecordViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentAttendanceRecord(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please Select a School, a Programme", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void StudentReportFormToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridViewClassStudents.SelectedRows.Count != 0 && cbExamPeriod.SelectedIndex != -1 && cbclass.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    Student _Student = (Student)bindingSourceClassStudents.Current;

                    SchoolClass _SchoolClass = (SchoolClass)cbclass.SelectedItem;

                    ExamPeriod _ExamPeriod = (ExamPeriod)cbExamPeriod.SelectedItem;

                    current_file_name = "Student Terminal Report  " + _Student.AdminNo + " - " + _Student.StudentSurName.Trim() + "  " + _Student.StudentOtherNames.Trim() + "  " + _ExamPeriod.Term + "  " + _ExamPeriod.Year + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    StudentReportFormViewModelBuilder _ModelBuilder = new StudentReportFormViewModelBuilder(_School, _Student, _SchoolClass, _ExamPeriod, connection);
                    StudentReportFormViewModel _ViewModel = _ModelBuilder.GetViewModel();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowStudentAcademicReport(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }

                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, an Exam Period, a Class and a Student", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void teachersListtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbYear.SelectedIndex != -1 && cbTerm.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int _Year = (int)cbYear.SelectedItem;

                    int _Term = (int)cbTerm.SelectedItem;

                    current_file_name = "Teachers List " + _Term.ToString() + " " + _Year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    TeachersListViewModelBuilder _ModelBuilder = new TeachersListViewModelBuilder(_School, connection);
                    TeachersListViewModel _ViewModel = _ModelBuilder.GetViewModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowTeachersList(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Year and a Term",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void balanceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbYear.SelectedIndex != -1 && cbTerm.SelectedIndex != -1 && dataGridViewSchools.SelectedRows.Count != 0)
            {
                try
                {
                    School _School = (School)bindingSourceSchools.Current;

                    int _Year = (int)cbYear.SelectedItem;

                    int _Term = (int)cbTerm.SelectedItem;

                    current_file_name = "Balance Sheet " + _Term.ToString() + " " + _Year.ToString() + ".pdf";

                    _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("generating report [ " + current_file_name + " ]", TAG));

                    BalanceSheetViewModelBuilder _ModelBuilder = new BalanceSheetViewModelBuilder(_School, connection);
                    BalanceSheetViewModel _ViewModel = _ModelBuilder.GetModelBuilder();

                    this.DoPreProcess(sender, e);

                    if (pdf_generator.ShowBalanceSheet(_ViewModel, get_reports_uri(current_file_name)))
                    {
                        DoShowPDF(current_file_name);
                    }

                    this.DoPostProcess(sender, e);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
            else
            {
                MessageBox.Show("Please select  a School, a Year and a Term",
                 "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion "menus"
        #region "textboxes"
        private void txtAccountId_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
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
        #endregion "textboxes"
        #endregion "Private Methods"



    }
}