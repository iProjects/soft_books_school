using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using DAL;
using CommonLib;

namespace WinSBSchool.Controls
{
    public partial class AttendanceSheetControl : UserControl
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        string user;
        public string TAG;
        //Event declaration:
        //event for publishing messages to output
        public event EventHandler<notificationmessageEventArgs> _notificationmessageEventname;

        public AttendanceSheetControl(string UserName, string Conn, EventHandler<notificationmessageEventArgs> notificationmessageEventname)
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

            _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AttendanceSheetControl initialization", TAG));

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
        private void AttendanceSheetControl_Load(object sender, EventArgs e)
        {
            try
            {
                var classes_query = from sc in db.SchoolClasses
                                    where sc.IsDeleted == false
                                    where sc.Status == "A"
                                    select sc;
                List<SchoolClass> _SchoolClasss = classes_query.ToList();

                bindingSourceSchoolClasses.DataSource = _SchoolClasss;
                cboschoolclasses.DataSource = bindingSourceSchoolClasses;
                cboschoolclasses.ValueMember = "Id";
                cboschoolclasses.DisplayMember = "ClassName";
                cboschoolclasses.SelectedIndex = -1;

                var students_query = from sd in db.Students
                                     where sd.Status == "A"
                                     where sd.IsDeleted == false
                                     select sd;
                List<Student> _students = students_query.ToList();

                DataGridViewComboBoxColumn colCboxStudent = new DataGridViewComboBoxColumn();
                colCboxStudent.HeaderText = "Student";
                colCboxStudent.Name = "cbStudent";
                colCboxStudent.DataSource = _students;
                colCboxStudent.DisplayMember = "StudentOtherNames";
                colCboxStudent.DataPropertyName = "StudentId";
                colCboxStudent.ValueMember = "Id";
                colCboxStudent.MaxDropDownItems = 10;
                colCboxStudent.DisplayIndex = 1;
                colCboxStudent.MinimumWidth = 5;
                colCboxStudent.Width = 100;
                colCboxStudent.FlatStyle = FlatStyle.Flat;
                colCboxStudent.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxStudent.ReadOnly = true;
                if (!this.DataGridViewattendance.Columns.Contains("cbStudent"))
                {
                    DataGridViewattendance.Columns.Add(colCboxStudent);
                }

                var attendance_query = from att in db.Attendances
                                       where att.IsDeleted == false
                                       select att;
                List<Attendance> _Attendances = attendance_query.ToList();

                bindingSourceattendance.DataSource = _Attendances;
                DataGridViewattendance.AutoGenerateColumns = false;
                this.DataGridViewattendance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                DataGridViewattendance.DataSource = bindingSourceattendance;

                _notificationmessageEventname.Invoke(this, new notificationmessageEventArgs("finished AttendanceSheetControl load", TAG));
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnpopulate_Click(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }

        private void btnadvancedfilter_Click(object sender, EventArgs e)
        {

        }

        private void attendanceDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = false;
            }
            catch (Exception ex)
            {
                Log.Write_To_Log_File_temp_dir(ex);
            }
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            try
            {
                var selected_date = monthCalendar.SelectionRange.Start.Date;

                var attendance_query = from att in db.Attendances
                                       where att.StartDateTime == selected_date
                                       where att.IsDeleted == false
                                       select att;
                List<Attendance> _Attendances = attendance_query.ToList();

                bindingSourceattendance.DataSource = _Attendances;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void txtSearchByRegNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSearchByRegNo.Text))
                {
                    string regno = txtSearchByRegNo.Text.Trim();

                    var attendance_query = from att in db.Attendances
                                           join st in db.Students on att.StudentId equals st.Id
                                           where st.AdminNo.StartsWith(regno)
                                           where att.IsDeleted == false
                                           select att;
                    List<Attendance> _Attendances = attendance_query.ToList();

                    bindingSourceattendance.DataSource = _Attendances;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void cboschoolclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboschoolclasses.SelectedItem != null)
                {
                    SchoolClass school_class = (SchoolClass)cboschoolclasses.SelectedItem;

                    var attendance_query = from att in db.Attendances
                                           join st in db.Students on att.StudentId equals st.Id
                                           join csm in db.ClassStreams on st.ClassStreamId equals csm.Id
                                           join scs in db.SchoolClasses on csm.ClassId equals scs.Id
                                           where scs.Id == school_class.Id
                                           where att.IsDeleted == false
                                           select att;
                    List<Attendance> _Attendances = attendance_query.ToList();

                    bindingSourceattendance.DataSource = _Attendances;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private void btnclearfilter_Click(object sender, EventArgs e)
        {
            cboschoolclasses.SelectedIndex = -1;
            txtSearchByRegNo.Text = string.Empty;
        }

        private void DataGridViewattendance_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DataGridViewattendance_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                e.ThrowException = false;
            }
            catch (Exception ex)
            {
                Log.Write_To_Log_File_temp_dir(ex);
            }
        }

    }
}
