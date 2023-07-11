using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class EditAttendanceForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string connection;
        DAL.AttendanceModel _Attendance;

        public EditAttendanceForm(DAL.AttendanceModel Attendance, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            _Attendance = Attendance;
        }

        private void EditAttendanceForm_Load(object sender, EventArgs e)
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

                var Subjectsquery = from sj in db.Subjects
                                    where sj.Status == "A"
                                    where sj.IsDeleted == false
                                    select sj;
                List<Subject> _Subjects = Subjectsquery.ToList();
                cboSubject.DataSource = _Subjects;
                cboSubject.ValueMember = "ShortCode";
                cboSubject.DisplayMember = "Description";
                cboSubject.SelectedIndex = -1;

                InitializeControls();

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
                if (_Attendance.StudentId != null)
                {
                    cboStudent.SelectedValue = _Attendance.StudentId;
                }
                if (_Attendance.SubjectShortCode != null)
                {
                    cboSubject.SelectedValue = _Attendance.SubjectShortCode.Trim();
                }
                if (_Attendance.StartDateTime != null)
                {
                    dtpStartTime.Value = _Attendance.StartDateTime;
                }
                if (_Attendance.EndDateTime != null)
                {
                    dtpEndTime.Value = _Attendance.EndDateTime;
                }
                if (_Attendance.Attended != null)
                {
                    chkAttended.Checked = _Attendance.Attended;
                }
                if (_Attendance.ReasonForNotAttending != null)
                {
                    txtReasonForNotAttending.Text = _Attendance.ReasonForNotAttending.Trim();
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
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsAttendanceValid())
            {
                try
                {
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
                        _Attendance.ReasonForNotAttending = Utils.ConvertFirstLetterToUpper(txtReasonForNotAttending.Text.Trim());
                    }

                    if (db.Attendances.Any(o => o.StudentId == _Attendance.StudentId && o.SubjectShortCode == _Attendance.SubjectShortCode && o.StartDateTime == _Attendance.StartDateTime && o.EndDateTime == _Attendance.EndDateTime))
                    {
                        MessageBox.Show("Attendance Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Attendances.Any(o => o.StudentId == _Attendance.StudentId && o.SubjectShortCode == _Attendance.SubjectShortCode && o.StartDateTime == _Attendance.StartDateTime && o.EndDateTime == _Attendance.EndDateTime))
                    {
                        rep.UpdateAttendance(_Attendance);

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
        public void DisableControls()
        {
            cboStudent.Enabled = false;
            cboSubject.Enabled = false;
            dtpStartTime.Enabled = false;
            dtpEndTime.Enabled = false;
            chkAttended.Enabled = false;
            txtReasonForNotAttending.Enabled = false;
            btnUpdate.Enabled = false;
            btnUpdate.Visible = false;
            btnClose.Location = btnUpdate.Location;
        }









    }
}