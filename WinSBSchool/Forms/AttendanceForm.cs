using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using WinSBSchool.Controls;
using System.Threading;

namespace WinSBSchool.Forms
{
    public partial class AttendanceForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection; 
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public AttendanceForm(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AttendanceForm initialization", TAG));

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
        private void AttendanceForm_Load(object sender, EventArgs e)
        {
            try
            {  
                var Attendancequery = from sc in rep.GetAllAttendances()
                                      where sc.IsDeleted == false
                                      select sc;
                List<AttendanceModel> _Attendances = Attendancequery.ToList();
                bindingSourceAttendance.DataSource = _Attendances;
                dataGridViewAttendance.AutoGenerateColumns = false;
                this.dataGridViewAttendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewAttendance.DataSource = bindingSourceAttendance;
                groupBox2.Text = bindingSourceAttendance.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RefreshGrid()
        {
            try
            { 
                bindingSourceAttendance.DataSource = null;
                var Attendancequery = from sc in rep.GetAllAttendances()
                                      where sc.IsDeleted==false
                                      select sc;
                List<AttendanceModel> _Attendances = Attendancequery.ToList();
                bindingSourceAttendance.DataSource = _Attendances;
                groupBox2.Text = bindingSourceAttendance.Count.ToString();
                foreach (DataGridViewRow row in dataGridViewAttendance.Rows)
                {
                    dataGridViewAttendance.Rows[dataGridViewAttendance.Rows.Count - 1].Selected = true;
                    int nRowIndex = dataGridViewAttendance.Rows.Count - 1;
                    bindingSourceAttendance.Position = nRowIndex;
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            { 
                Forms.AddAttendanceForm ac = new Forms.AddAttendanceForm(connection) { Owner = this };
                ac.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewAttendance.SelectedRows.Count != 0)
                {
                    DAL.AttendanceModel _Attendance = (DAL.AttendanceModel)bindingSourceAttendance.Current;

                    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to delete  Attendance", "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        rep.DeleteAttendance(_Attendance);

                        RefreshGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void btnEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewAttendance.SelectedRows.Count != 0)
                {
                    DAL.AttendanceModel _Attendance = (DAL.AttendanceModel)bindingSourceAttendance.Current;
                    Forms.EditAttendanceForm ec = new Forms.EditAttendanceForm(_Attendance, connection) { Owner = this };
                    ec.Text = "Edit Attendance";
                    ec.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewAttendance_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridViewAttendance.SelectedRows.Count != 0)
                {
                    DAL.AttendanceModel _Attendance = (DAL.AttendanceModel)bindingSourceAttendance.Current;
                    Forms.EditAttendanceForm ec = new Forms.EditAttendanceForm(_Attendance, connection) { Owner = this };
                    ec.Text = "Edit Attendance";
                    ec.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnViewDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (dataGridViewAttendance.SelectedRows.Count != 0)
                {
                    DAL.AttendanceModel _Attendance = (DAL.AttendanceModel)bindingSourceAttendance.Current;
                    Forms.EditAttendanceForm ec = new Forms.EditAttendanceForm(_Attendance, connection) { Owner = this };
                    ec.Text = "Attendance Details";
                    ec.DisableControls();
                    ec.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void dataGridViewAttendance_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            controlsform asc = new controlsform(user, connection, _notificationmessageEventname);
            asc.Show();
        } 












    }
}