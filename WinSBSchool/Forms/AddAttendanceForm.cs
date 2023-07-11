using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class AddAttendanceForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;

        public AddAttendanceForm(string Conn)
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }

        private void AddAttendanceForm_Load(object sender, EventArgs e)
        {
            try
            {
                var Studentsquery = from tc in db.Students
                                    where tc.IsDeleted == false
                                    where tc.Status == "A"
                                    select tc;
                List<Student> _Students = Studentsquery.ToList();
                cboStudent.DataSource = _Students;
                cboStudent.ValueMember = "Id";
                cboStudent.DisplayMember = "StudentOtherNames";
                cboStudent.SelectedIndex = -1;
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
        public bool IsAttendanceValid()
        {
            bool noerror = true;
            if (cboStudent.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboStudent, "Select Student!");
                return false;
            }
            if (cboSubject.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboSubject, "Select Subject!");
                return false;
            }
            return noerror;
        }
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsAttendanceValid())
            {
                try
                {
                    DAL.AttendanceModel _Attendance = new DAL.AttendanceModel();
                    if (cboStudent.SelectedIndex != -1)
                    {
                        _Attendance.StudentId = int.Parse(cboStudent.SelectedValue.ToString());
                    }
                    if (cboSubject.SelectedIndex != -1)
                    {
                        _Attendance.SubjectShortCode = cboSubject.SelectedValue.ToString();
                    }
                    _Attendance.StartDateTime = dtpStartTime.Value;
                    _Attendance.EndDateTime = dtpEndTime.Value;
                    _Attendance.Attended = chkAttended.Checked;
                    if (!string.IsNullOrEmpty(txtReasonForNotAttending.Text))
                    {
                        _Attendance.ReasonForNotAttending = txtReasonForNotAttending.Text.Trim();
                    }
                    _Attendance.IsDeleted = false;


                    if (db.Attendances.Any(o => o.StudentId == _Attendance.StudentId && o.SubjectShortCode == _Attendance.SubjectShortCode && o.StartDateTime == _Attendance.StartDateTime && o.EndDateTime == _Attendance.EndDateTime))
                    {
                        MessageBox.Show("Attendance Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Attendances.Any(o => o.StudentId == _Attendance.StudentId && o.SubjectShortCode == _Attendance.SubjectShortCode && o.StartDateTime == _Attendance.StartDateTime && o.EndDateTime == _Attendance.EndDateTime))
                    {
                        rep.AddNewAttendance(_Attendance);

                        AttendanceForm f = (AttendanceForm)this.Owner;
                        f.RefreshGrid();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void cboStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboStudent.SelectedIndex == -1)
                {
                    cboSubject.Enabled = false;
                }
                if (cboStudent.SelectedIndex != -1)
                {
                    cboSubject.Enabled = true;

                    Student _student = (Student)cboStudent.SelectedItem;

                    var _schoolclassquery = from sc in db.SchoolClasses
                                            where sc.IsDeleted == false
                                            join cs in db.ClassStreams on sc.Id equals cs.ClassId
                                            join st in db.Students on cs.Id equals st.ClassStreamId
                                            where cs.IsDeleted == false
                                            where st.IsDeleted == false
                                            where st.Id == _student.Id
                                            select sc;
                    SchoolClass _schoolclass = _schoolclassquery.FirstOrDefault();

                    var _classsubjectsquery = from sb in db.Subjects
                                              join cs in db.ClassSubjects on sb.ShortCode equals cs.SubjectCode
                                              where sb.IsDeleted == false
                                              where cs.IsDeleted == false
                                              where cs.Status=="A"
                                              where cs.ClassId == _schoolclass.Id
                                              select sb;
                    List<Subject> _classsubjects = _classsubjectsquery.ToList();
                    cboSubject.DataSource = _classsubjects;
                    cboSubject.ValueMember = "ShortCode";
                    cboSubject.DisplayMember = "Description";
                    cboSubject.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }







    }
}