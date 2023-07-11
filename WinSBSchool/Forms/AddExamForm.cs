using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class AddExamForm : Form
    {

        string user;
        SBSchoolDBEntities db;
        string connection;
        ExamPeriod _ExamPeriod;
        SchoolClass _SchoolClass;

        public AddExamForm(ExamPeriod _examPeriod, SchoolClass _schoolClass, string _user, string Conn)
        {
            InitializeComponent();
            user = _user;

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);

            if (_schoolClass == null)
                throw new ArgumentNullException("SchoolClass");
            _SchoolClass = _schoolClass;

            if (_examPeriod == null)
                throw new ArgumentNullException("ExamPeriod");
            _ExamPeriod = _examPeriod;

        }

        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            errorProvider1.Clear();
            if (IsExamValid())
            {
                try
                {
                    int _examperiod = int.Parse(cboExamPeriods.SelectedValue.ToString());
                    int _classid = int.Parse(cboClass.SelectedValue.ToString());
                    string _subjectshortcode = cboSubject.SelectedValue.ToString();

                    Exam _exm = new Exam();
                    _exm.ExamPeriodId = _examperiod;
                    _exm.ClassId = _classid;
                    _exm.SubjectShortCode = _subjectshortcode;
                    _exm.LastModified = dtpLastModified.Value;
                    _exm.ModifiedBy = txtModifiedby.Text;
                    _exm.Enabled = chkEnabled.Checked;
                    _exm.Closed = false;
                    _exm.Processed = false;
                    _exm.IsDeleted = false;

                    if (db.Exams.Any(o => o.ExamPeriodId == _examperiod && o.ClassId == _classid && o.SubjectShortCode == _subjectshortcode && o.IsDeleted == false))
                    {
                        MessageBox.Show("Exam Exists!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (!db.Exams.Any(o => o.ExamPeriodId == _examperiod && o.ClassId == _classid && o.SubjectShortCode == _subjectshortcode && o.IsDeleted == false))
                    {
                        db.Exams.AddObject(_exm);
                        db.SaveChanges();

                        ExamsForm f = (ExamsForm)this.Owner;
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
        private bool IsExamValid()
        {
            bool noerror = true;
            if (cboExamPeriods.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboExamPeriods, "Select Exam Period!");
                return false;
            }
            if (cboClass.SelectedIndex == -1)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboClass, "Select Class!");
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
        private void AddExamForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _exmprdsquery = from eps in db.ExamPeriods
                                    orderby eps.Year, eps.Term ascending
                                    where eps.Status == "A"
                                    where eps.IsDeleted == false
                                    select eps;
                List<ExamPeriod> _ExamPeriods = _exmprdsquery.ToList();
                cboExamPeriods.DataSource = _ExamPeriods;
                cboExamPeriods.ValueMember = "Id";
                cboExamPeriods.DisplayMember = "Description";
                cboExamPeriods.SelectedValue = _ExamPeriod.Id;

                var _sclcls = from sc in db.SchoolClasses
                              where sc.IsDeleted == false
                              where sc.Status == "A"
                              select sc;
                List<SchoolClass> _SchoolClasses = _sclcls.ToList();
                cboClass.DataSource = _SchoolClasses;
                cboClass.ValueMember = "Id";
                cboClass.DisplayMember = "ClassName";
                cboClass.SelectedValue = _SchoolClass.Id;

                txtModifiedby.Text = user;

                chkEnabled.Checked = true;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboSubject.DataSource = null;

            if (cboClass.SelectedIndex != -1 && cboExamPeriods.SelectedIndex != -1)
            {
                try
                {
                    SchoolClass sclass = (SchoolClass)cboClass.SelectedItem;
                    ExamPeriod _period = (ExamPeriod)cboExamPeriods.SelectedItem;

                    var _existingclasssubjectsquery = (from ex in db.Exams
                                                       join sj in db.Subjects on ex.SubjectShortCode equals sj.ShortCode
                                                       join cs in db.ClassSubjects on sj.ShortCode equals cs.SubjectCode
                                                       join ep in db.ExamPeriods on ex.ExamPeriodId equals ep.Id
                                                       where ex.ExamPeriodId == _period.Id
                                                       where cs.ClassId == sclass.Id
                                                       where ex.ClassId == sclass.Id
                                                       where cs.IsDeleted == false
                                                       select ex.SubjectShortCode).Distinct();
                    List<string> _ExistingExams = _existingclasssubjectsquery.ToList();

                    var _newclassubjectsquery = (from sj in db.Subjects
                                                 join cs in db.ClassSubjects on sj.ShortCode equals cs.SubjectCode
                                                 where cs.ClassId == sclass.Id
                                                 where sj.Status == "A"
                                                 where cs.Status == "A"
                                                 where cs.IsDeleted == false
                                                 where sj.IsDeleted == false
                                                 where !_ExistingExams.Contains(cs.SubjectCode)
                                                 orderby sj.Description
                                                 select sj).Distinct().OrderBy(i => i.ShortCode);
                    List<Subject> _subjects = _newclassubjectsquery.ToList();

                    cboSubject.DataSource = _subjects;
                    cboSubject.ValueMember = "ShortCode";
                    cboSubject.DisplayMember = "Description";
                    cboSubject.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }



















    }
}