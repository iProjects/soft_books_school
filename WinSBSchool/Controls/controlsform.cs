using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using System.Threading;
using DAL;

namespace WinSBSchool.Controls
{
    public partial class controlsform : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public controlsform(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished controlsform initialization", TAG));

        }

        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            Log.Write_To_Log_File_temp_dir(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }

        private void ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            Log.Write_To_Log_File_temp_dir(ex);
            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs(ex.ToString(), TAG));
        }
        private void controlsform_Load(object sender, EventArgs e)
        {
            btnattendance_Click(sender, e);

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished controlsform load", TAG));

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnattendance_Click(object sender, EventArgs e)
        {
            try
            {
                Control usercontrol = new AttendanceSheetControl(user, connection, _notificationmessageEventname);
                usercontrol.Dock = DockStyle.Fill;
                panelControls.Controls.Clear();
                panelControls.Controls.Add(usercontrol);
                this.Text = "Attendance";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnclass_Click(object sender, EventArgs e)
        {
            try
            {
                Control usercontrol = new ClassControl(user, connection, _notificationmessageEventname);
                usercontrol.Dock = DockStyle.Fill;
                panelControls.Controls.Clear();
                panelControls.Controls.Add(usercontrol);
                this.Text = "Class";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnstudentdetails_Click(object sender, EventArgs e)
        {
            try
            {
                Control usercontrol = new StudentDetailsControl(user, connection, _notificationmessageEventname);
                usercontrol.Dock = DockStyle.Fill;
                panelControls.Controls.Clear();
                panelControls.Controls.Add(usercontrol);
                this.Text = "Student Details";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnuclass_Click(object sender, EventArgs e)
        {
            try
            {
                Control usercontrol = new ucClass(user, connection, _notificationmessageEventname);
                usercontrol.Dock = DockStyle.Fill;
                panelControls.Controls.Clear();
                panelControls.Controls.Add(usercontrol);
                this.Text = "Class";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnustudent_Click(object sender, EventArgs e)
        {
            try
            {
                Control usercontrol = new ucStudent(user, connection, _notificationmessageEventname);
                usercontrol.Dock = DockStyle.Fill;
                panelControls.Controls.Clear();
                panelControls.Controls.Add(usercontrol);
                this.Text = "Student";
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }




    }
}
