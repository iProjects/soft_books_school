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
    public partial class AddClassSubjectForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        SchoolClass _SchoolClass;
        string connection;

        public AddClassSubjectForm(SchoolClass schoolclass, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (schoolclass == null)
                throw new ArgumentNullException("SchoolClass");
            _SchoolClass = schoolclass;
        }

        private void AddClassSubjectForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _sbjcttchrsquery = from tc in db.Teachers
                                       where tc.Status == "A"
                                       where tc.IsDeleted == false
                                       orderby tc.Name ascending
                                       select tc;
                List<Teacher> _SubjectTeachers = _sbjcttchrsquery.ToList();
                cboClassSubjectTeacher.DataSource = _SubjectTeachers;
                cboClassSubjectTeacher.ValueMember = "Id";
                cboClassSubjectTeacher.DisplayMember = "Name";
                cboClassSubjectTeacher.SelectedIndex = -1;

                var _existingclasssubjectsquery = from cs in db.ClassSubjects
                                             join sc in db.SchoolClasses on cs.ClassId equals sc.Id
                                             where sc.Id == _SchoolClass.Id
                                             where cs.IsDeleted==false
                                             where sc.IsDeleted==false
                                             select cs.SubjectCode;
                List<string> _existingclasssubjects = _existingclasssubjectsquery.ToList();

                var _programmecoursequery = (from pyc in db.ProgrammeYearCourses
                                             join sc in db.SchoolClasses on pyc.ProgrammeYearId equals sc.ProgrammeYearId
                                             where sc.Id == _SchoolClass.Id
                                             where pyc.IsDeleted==false
                                             where sc.IsDeleted==false
                                             where pyc.ProgrammeYearId == _SchoolClass.ProgrammeYearId
                                             select pyc.CourseId).ToList();

                var clssbjctquery = from sj in db.Subjects
                                    where sj.Status == "A"
                                    where sj.IsDeleted == false
                                    orderby sj.Description ascending
                                    where _programmecoursequery.Contains(sj.ShortCode)
                                    where !_existingclasssubjects.Contains(sj.ShortCode)
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
        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsClassSubjectValid())
            {
                try
                {
                    ClassSubject _ClassSubject = new ClassSubject();
                    _ClassSubject.ClassId = _SchoolClass.Id;
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
                    _ClassSubject.IsDeleted = false;

                    if (db.ClassSubjects.Any(o => o.ClassId == _SchoolClass.Id && o.SubjectCode == _ClassSubject.SubjectCode && o.IsDeleted == false))
                    {
                        MessageBox.Show("Subject Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.ClassSubjects.Any(o => o.ClassId == _SchoolClass.Id && o.SubjectCode == _ClassSubject.SubjectCode && o.IsDeleted == false))
                    {

                        db.ClassSubjects.AddObject(_ClassSubject);
                        db.SaveChanges();

                        EditClassForm f = (EditClassForm)this.Owner;
                        f.RefreshSubjectsGrid();
                        this.Close();
                    }
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