using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Objects;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class EditClassSubjectForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        SchoolClass _SchoolClass;
        ClassSubject _ClassSubject;
        string connection; 

        public EditClassSubjectForm(ClassSubject _classsubject, SchoolClass schoolclass, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (_classsubject == null)
                throw new ArgumentNullException("ClassSubject");
            _ClassSubject = _classsubject;

            if (schoolclass == null)
                throw new ArgumentNullException("SchoolClass");
            _SchoolClass = schoolclass;
        }

        private void EditClassSubjectForm_Load(object sender, EventArgs e)
        {
            try
            { 
                var _sbjcttchrsquery = from tc in db.Teachers
                                       where tc.Status == "A"
                                       where tc.IsDeleted==false
                                       orderby tc.Name ascending
                                       select tc;
                List<Teacher> _SubjectTeachers = _sbjcttchrsquery.ToList();
                cboClassSubjectTeacher.DataSource = _SubjectTeachers;
                cboClassSubjectTeacher.ValueMember = "Id";
                cboClassSubjectTeacher.DisplayMember = "Name";
                cboClassSubjectTeacher.SelectedIndex = -1;

                var _programmecoursequery = (from pyc in db.ProgrammeYearCourses
                                             where pyc.ProgrammeYearId == _SchoolClass.ProgrammeYearId
                                             select pyc.CourseId).ToList();

                var clssbjctquery = from sj in db.Subjects
                                    where sj.Status == "A"
                                    where sj.IsDeleted == false
                                    orderby sj.Description ascending
                                    where _programmecoursequery.Contains(sj.ShortCode)
                                    select sj;
                List<Subject> _ClassSubjects = clssbjctquery.ToList();
                cboClassSubject.DataSource = _ClassSubjects;
                cboClassSubject.ValueMember = "ShortCode";
                cboClassSubject.DisplayMember = "Description";
                cboClassSubject.SelectedIndex = -1;

                var status = new BindingList<KeyValuePair<string, string>>();
                status.Add(new KeyValuePair<string, string>("A", "Active"));
                status.Add(new KeyValuePair<string, string>("N", "Non-Active"));
                cboStatus.DataSource = status;
                cboStatus.ValueMember = "Key";
                cboStatus.DisplayMember = "Value"; 

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
                if (_ClassSubject.SubjectCode != null)
                {
                    cboClassSubject.SelectedValue = _ClassSubject.SubjectCode;
                }
                if (_ClassSubject.SubjectTeacherId != null)
                {
                    cboClassSubjectTeacher.SelectedValue = _ClassSubject.SubjectTeacherId;
                }
                if (_ClassSubject.Status != null)
                {
                    cboStatus.SelectedValue = _ClassSubject.Status;
                }
                if (_ClassSubject.Room != null)
                {
                    txtClassRoom.Text = _ClassSubject.Room.Trim();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private bool IsClassSubjectValid()
        {
            bool noerror = true;
            if (cboClassSubject.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboClassSubject, "Select Class Subject!");
                return false;
            }
            if (cboClassSubjectTeacher.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboClassSubjectTeacher, "Select Subject Teacher!");
                return false;
            }
            if (cboStatus.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboStatus, "Select Status!");
                return false;
            }
            return noerror;
        }
        private void btnUpdate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsClassSubjectValid())
            {
                try
                {  
                    if (cboClassSubject.SelectedIndex != -1)
                    {
                        _ClassSubject.SubjectCode = cboClassSubject.SelectedValue.ToString();
                    }
                    if (cboClassSubjectTeacher.SelectedIndex != -1)
                    {
                        _ClassSubject.SubjectTeacherId = int.Parse(cboClassSubjectTeacher.SelectedValue.ToString());
                    }
                    if (cboStatus.SelectedIndex != -1)
                    {
                        _ClassSubject.Status = cboStatus.SelectedValue.ToString();
                    }
                    if (!string.IsNullOrEmpty(txtClassRoom.Text))
                    {
                        _ClassSubject.Room = txtClassRoom.Text.Trim();
                    }

                    rep.UpdateClassSubject(_ClassSubject);

                    EditClassForm f = (EditClassForm)this.Owner;
                    f.RefreshSubjectsGrid();
                    this.Close();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

         

    }
}
