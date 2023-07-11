using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using WinSBSchool.Reports.ViewModelBuilders;
using WinSBSchool.Reports.ViewModels;
using CommonLib;

namespace WinSBSchool.Forms
{

    public partial class FormProcessExams : Form
    {
        #region "Private Properties"
        Repository rep;
        SBSchoolDBEntities db;
        string user;
        string connection;
        School school;
        int gradingsys;
        private int updateprocessStatusCounter = 60;
        private int updateStatusCounter = 60;
        SchoolClass _SchoolClass;
        ExamPeriod _ExamPeriod;
        #endregion "Private Properties"

        #region "Contructor"
        public FormProcessExams(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Connection is invalid.");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            user = _user;

            //Get grading system
            var _Schoolquery = (from sc in db.Schools
                                where sc.DefaultSchool == true
                                select sc).FirstOrDefault();
            School _School = _Schoolquery;
            school = _School;

            if (school == null)
                throw new ArgumentNullException("School is invalid.");
            connection = Conn;

            gradingsys = school.GradingSystem;
        }
        #endregion "Contructor"

        #region "Private Methods"
        private void btnProcessExamByExamPeriod_Click(object sender, EventArgs e)
        {
            if (lstExamPeriods.SelectedIndex != -1)
            {
                try
                {
                    ExamPeriod examperiod = (ExamPeriod)lstExamPeriods.SelectedItem;
                    var _schoolclassesquery = from sc in db.SchoolClasses
                                              where sc.IsDeleted == false
                                              where sc.Status == "A"
                                              select sc;
                    List<SchoolClass> _SchoolClasses = _schoolclassesquery.ToList();

                    foreach (var cls in _SchoolClasses)
                    {

                        var _examsquery = from exm in db.Exams
                                          where exm.Closed == false
                                          where exm.IsDeleted == false
                                          where exm.Enabled == true
                                          join cs in db.SchoolClasses on exm.ClassId equals cs.Id
                                          where cs.IsDeleted == false
                                          where cs.Status == "A"
                                          join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.Id
                                          where ep.Status == "A"
                                          where ep.IsDeleted == false
                                          where exm.ExamPeriodId == examperiod.Id
                                          where exm.ClassId == cls.Id
                                          select exm;
                        List<Exam> _exams = _examsquery.ToList();

                        foreach (var _Exam in _exams)
                        {
                         // see if the StudentsExamResults_Temp has records and they are for this Exam
                         //if not, decline processing
                         //set up 

                            if (db.StudentsExamResults_Temp.Any(i => i.Examid == _Exam.Id && i.SchoolClassId == cls.Id))
                            {
                                if (DialogResult.Yes == MessageBox.Show("Exam: " + _Exam.Subject.Description + Environment.NewLine + "Class: " + cls.ClassName + Environment.NewLine + "Period: " + examperiod.Description + Environment.NewLine + "already processed! \nDo you wish to overwrite?", "Confirm Overwrite", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                                {
                                    rep.ClearStudentsExamResults_Temp(cls.Id, _Exam.Id);
                                    rep.ClearStudentProgresses_Temp(cls.Id, _Exam.Id);
                                    //rep.TruncateStudentProgresses_Temp();
                                    //rep.TruncateWorkingTables();

                                    ProcessExam(examperiod, cls, _Exam);
                                }
                            }
                            else
                            {
                                ProcessExam(examperiod, cls, _Exam);
                            }
                        }
                    }
                    MessageBox.Show("Process Successfull!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                    return;
                }
            }
        }
        private void btnProcessExamsByClass_Click(object sender, EventArgs e)
        {
            if (lstExamPeriods.SelectedIndex != -1 && cbClasses.SelectedIndex != -1 && lstExams.SelectedIndex != -1)
            {
                try
                {
                    ExamPeriod examperiod = (ExamPeriod)lstExamPeriods.SelectedItem;
                    SchoolClass cls = (SchoolClass)cbClasses.SelectedItem;
                    Exam _Exam = (Exam)lstExams.SelectedItem;

                    // see if the StudentsExamResults_Temp has records and they are for this Exam
                    //if not, decline processing
                    //set up 

                    if (db.StudentsExamResults_Temp.Any(i => i.Examid == _Exam.Id && i.SchoolClassId == cls.Id))
                    {
                        if (DialogResult.Yes == MessageBox.Show("Exam: " + _Exam.Subject.Description + Environment.NewLine + "Class: " + cls.ClassName + Environment.NewLine + "Period: " + examperiod.Description + Environment.NewLine + "already processed! \nDo you wish to overwrite?", "Confirm Overwrite", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            rep.ClearStudentsExamResults_Temp(cls.Id, _Exam.Id);
                            rep.ClearStudentProgresses_Temp(cls.Id, _Exam.Id);

                            //rep.ClearStudentsExamResults_Temp(cls.Id, _Exam.Id);
                            //rep.TruncateStudentProgresses_Temp();
                            //rep.TruncateWorkingTables();

                            ProcessExam(examperiod, cls, _Exam);
                            MessageBox.Show("Process Successfull!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        ProcessExam(examperiod, cls, _Exam);
                        MessageBox.Show("Process Successfull!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                    return;
                }
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
        private void ProcessExamsHandler()
        {
            if (lstExamPeriods.SelectedIndex != -1 && cbClasses.SelectedIndex != -1 && lstExams.SelectedIndex != -1)
            {
                ExamPeriod _examperiod = (ExamPeriod)lstExamPeriods.SelectedItem;
                SchoolClass _class = (SchoolClass)cbClasses.SelectedItem;
                Exam _exam = (Exam)lstExams.SelectedItem;

                try
                {
                    // see if the payslip_master_temp has records and they are for this school
                    //if not, decline processing
                    //set up
                    int _examperiodWc = 0;
                    int _classWc = 0;
                    int _examWc = 0;

                    if (!WorkingCopyNotClosed(ref _examperiodWc, ref _classWc, ref _examWc))
                    {

                    }
                    else if (_examperiodWc == _examperiod.Id && _classWc == _class.Id && _examWc == _exam.Id)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Exam already processed! \nDo you wish to overwrite?", "Confirm Overwrite", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("You must close the previously Processed school before proceeding", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                    return;
                }
            }
        }
        public bool WorkingCopyNotClosed(ref int _studentid, ref int _classid, ref int _examid)
        {
            try
            {

                var cnt = db.StudentsExamResults_Temp.Count();
                if (cnt > 0)
                {
                    var rec = db.StudentsExamResults_Temp.First();
                    _studentid = rec.StudentId;
                    _classid = rec.SchoolClassId;
                    _examid = rec.Examid;
                }
                else
                {

                }

                return cnt > 0;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return false;
            }
        }
        private void ProcessExamNow(int _examperiodid, int _classid, int _examid)
        {
            try
            {


            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void postprocessTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                updateprocessStatusCounter--;
                if (updateprocessStatusCounter == 0)
                {
                    lblTimeElaspedProcess.Text = string.Empty;
                    processTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void Periodtimer_Tick(object sender, EventArgs e)
        {
            try
            {
                updateStatusCounter--;
                if (updateStatusCounter == 0)
                {
                    lblTimeElapsedPeriod.Text = string.Empty;
                    Periodtimer.Stop();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void eps_OnCompleteExamProcess(object sender, ExamProcessCompleteEventArg e)
        {
            try
            {
                progressBarProcess.Value = e.StatusValue;
                NotifyMessage("EXAM PROCESSING ENGINE RUNNING...", e._Template);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void pbp_OnCompleteExamProcess(object sender, ExamProcessCompleteEventArg e)
        {
            try
            {
                progressBarPeriod.Value = e.StatusValue;
                NotifyMessage("EXAM PROCESSING ENGINE RUNNING...", e._Template);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ProcessExam(ExamPeriod _examPeriod, SchoolClass _schoolClass, Exam _exam)
        {
            try
            {
                progressBarProcess.Visible = true;
                int _counter = 0;
                DateTime startTime = DateTime.Now;
                lblTimeElaspedProcess.Text = string.Empty;

                var data = from se in db.StudentExams
                           join st in db.Students on se.StudentId equals st.Id
                           where st.Status == "A"
                           where st.IsDeleted == false
                           join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                           where cs.IsDeleted == false
                           join sc in db.SchoolClasses on cs.SchoolClass.Id equals sc.Id
                           where sc.Status == "A"
                           where sc.IsDeleted == false
                           join re in db.RegisteredExams on se.RegdExamId equals re.Id
                           where re.IsDeleted == false
                           where re.Status == "A"
                           join et in db.ExamTypes on re.ExamTypeId equals et.Id
                           where et.Status == "A"
                           where et.IsDeleted == false
                           join ex in db.Exams on re.ExamId equals ex.Id
                           where ex.IsDeleted == false
                           where ex.Closed == false
                           where ex.Enabled == true
                           join ep in db.ExamPeriods on ex.ExamPeriodId equals ep.Id
                           where ep.Status == "A"
                           where ep.IsDeleted == false
                           join sb in db.Subjects on ex.SubjectShortCode equals sb.ShortCode
                           where sb.Status == "A"
                           where sb.IsDeleted == false
                           where ep.Id == _examPeriod.Id
                           where sc.Id == _schoolClass.Id
                           where ex.Id == _exam.Id
                           where re.ContributionFlag == true
                           select new
                           {
                               StudentId = st.Id,
                               StudentSurName = st.StudentSurName,
                               StudentOtherNames = st.StudentOtherNames,
                               AdminNo = st.AdminNo,
                               SubjectShortCode = ex.SubjectShortCode,
                               SubjectDescription = sb.Description,
                               ContributionFlag = re.ContributionFlag,
                               Contribution = re.Contribution,
                               Mark = se.Mark,
                               _ExamTypeShortCode = et.ShortCode,
                               _ExamTypeDescription = et.Description,
                               _Teacher = sc.Teacher.Name,
                               _ClassStream = cs.Description,
                               _ClassName = sc.ClassName,
                               _ClassShortCode = sc.ShortCode,
                               _ExamId = ex.Id,
                               _SchoolClassId = sc.Id,
                               _TeacherId = sc.Teacher.Id,
                               _Status = st.Status,
                               _ExamperiodDesc = ep.Description,
                               _Term = ep.Term,
                               _Year = ep.Year
                           };

                var lst = data.ToList();

                var _gropings = from d in data
                                orderby d.AdminNo ascending
                                group d by new
                                {
                                    d.StudentId
                                }
                                    into grp
                                    select new
                                    {
                                        StudentId = grp.Key.StudentId,
                                        Marks = grp.GroupBy(f => f.ContributionFlag)
                                        .Select(m => new
                                        {
                                            Title = m.Key,
                                            Sum = m.Sum(c => c.Mark * c.Contribution),
                                            Contribution = m.Sum(d => d.Contribution)
                                        }),
                                        Results = from d in grp
                                                  group d by d.ContributionFlag into grp2
                                                  select new
                                                  {
                                                      _TotalMark = grp2.Sum(c => c.Mark * c.Contribution),
                                                      ContributionFlag = grp2.Key,
                                                      Contribution = grp2.Sum(d => d.Contribution),
                                                      Results = grp2
                                                  },
                                        _Results = grp,
                                        ResultsCount = (from g in grp
                                                        where g.ContributionFlag == true
                                                        select g).Count()
                                    };

                var _lstg = _gropings.ToList();

                var groups = from d in _lstg
                             orderby d.StudentId ascending
                             group d by new
                             {
                                 StudentId = d.StudentId
                             }
                                 into grp
                                 select new
                                 {
                                     StudentId = grp.Key.StudentId,
                                     Marks = grp.GroupBy(f => f.StudentId)
                                     .Select(m => new
                                     {
                                         Title = m.Key,
                                     }),
                                     list = grp
                                 };

                var _groups = groups.ToList();

                var _studentResultsquery = (from d in lst
                                            group d by new
                                            {
                                                d.StudentId
                                            }
                                                into grp
                                                orderby grp.Key.StudentId ascending
                                                select new ProcessExamination
                                                {
                                                    _Studentid = grp.Key.StudentId,
                                                    _Marks = (from d in grp
                                                              group d by d.SubjectShortCode into grp2
                                                              select new ProcessMarksDTO
                                                               {
                                                                   TotalMarks = grp2.Sum(c => c.Mark * c.Contribution),
                                                                   Contribution = grp2.Sum(d => d.Contribution)
                                                               }).ToList(),
                                                    _SubjectShortCode = (from d in grp
                                                                         group d by d.SubjectShortCode into grp2
                                                                         select new ProcessSubjectDTO
                                                                         {
                                                                             _SubjectShortCode = grp2.Key
                                                                         }).ToList(),
                                                    _ExamTypeShortCode = (from d in grp
                                                                          group d by d._ExamTypeShortCode into grp2
                                                                          select new ProcessExamTypeDTO
                                                                         {
                                                                             _ExamTypeShortCode = grp2.Key
                                                                         }).ToList(), 
                                                    _ProcessExaminations = (from g in grp
                                                                            select new ProcessExaminationDTO
                                                                            {
                                                                                _ExamTypeDescription = g._ExamTypeDescription,
                                                                                _ExamTypeShortCode = g._ExamTypeShortCode,
                                                                                _Teacher = g._Teacher,
                                                                                AdminNo = g.AdminNo,
                                                                                Contribution = g.Contribution,
                                                                                ContributionFlag = g.ContributionFlag,
                                                                                Mark = g.Mark,
                                                                                StudentId = g.StudentId,
                                                                                StudentOtherNames = g.StudentOtherNames,
                                                                                StudentSurName = g.StudentSurName,
                                                                                SubjectDescription = g.SubjectDescription,
                                                                                SubjectShortCode = g.SubjectShortCode,
                                                                                _ClassName = g._ClassName,
                                                                                _ClassShortCode = g._ClassShortCode,
                                                                                _ClassStream = g._ClassStream,
                                                                                Examid = g._ExamId,
                                                                                SchoolClassId = g._SchoolClassId,
                                                                                Status = g._Status,
                                                                                TeacherId = g._TeacherId,
                                                                                _Examperiod = g._ExamperiodDesc,
                                                                                _Term = g._Term,
                                                                                _Year = g._Year
                                                                            }).ToList()
                                                })
                          .ToList();
                var _studentResults = _studentResultsquery.ToList();

                //do the actual ranking and regrouping according to subject order
                var q = from s in _studentResults
                        orderby s._Marks.Sum(i=>i.MeanMarks) ascending
                        orderby s._Rank ascending
                        select new
                        {
                            _Studentid = s._Studentid,
                            _Rank = (from o in _studentResults
                                    where o._Marks.Sum(i => i.MeanMarks) > s._Marks.Sum(i => i.MeanMarks)
                                    select o).Count() + 1
                        };

                //Pass 2
                foreach (var rec in _studentResults)
                {
                    var rank = q.Where(s => s._Studentid == rec._Studentid).SingleOrDefault();

                    if (rank != null)
                        rec._Rank = rank._Rank;
                }

                foreach (var _examType in _studentResults)
                {
                    progressBarProcess.Minimum = 0;
                    progressBarProcess.Maximum = _studentResults.Count();

                    ExamProcessService eps = new ExamProcessService();

                    //subscribe to the events
                    eps.OnCompleteExamProcess += new ExamProcessService.ExamProcessCompleteEventHandler(eps_OnCompleteExamProcess);

                    eps.ProcessExams(_examType, db, rep, gradingsys, _counter, connection);
                }


                rep.MarkExamAsProcessed(_exam);

                PopulateExams();

                DateTime endTime = DateTime.Now;

                TimeSpan tt = endTime - startTime;

                lblTimeElaspedProcess.Text = string.Format("{0} ms", tt.TotalMilliseconds);

                processTimer.Tick += new EventHandler(postprocessTimer_Tick);
                processTimer.Interval = 1000; // 1 second
                processTimer.Start();




                //double totalcontribution = 0.00;
                //var con = db.ExamDets
                //          .Where(ed => ed._ExamId == _Exam._ExamId)
                //          .Where(ed => ed.ContributionFlag == true)
                //          .Select(ed => ed.Contribution);

                //if (con.Count() > 0)
                //{
                //    totalcontribution = con.Sum();
                //}
                //if (totalcontribution != 1)
                //{
                //    throw new Exception("Total contribution does not add up to 1");
                //}
                //var examrec = (from exm in db.Exams
                //               join ed in db.ExamDets
                //                 on exm._ExamId equals ed._ExamId
                //               where exm._ExamId == _Exam._ExamId

                //               join rge in db.RegisteredExams
                //                 on exm._ExamId equals rge.ExamDetId

                //               join str in db.StudentExams
                //                 on rge.RegdExamId equals str.RegdExamId

                //               select new
                //               {
                //                   StudentId = str.StudentId,
                //                   Subject = _Exam.SubjectShortCode,
                //                   Mark = str.Mark,
                //                   ExamType = 1,
                //                   Contribution = ed.Contribution
                //               }).ToList();


                //if (examrec.Count() > 0)
                //{
                //    var studentid = examrec.First().StudentId;
                //    var Mark = examrec.Sum(exa => exa.Mark * exa.Contribution);
                //    //look up the grade
                //    var Grade = GradeLookUp(Mark, gradingsys);

                //    var Target = (from crtxn in db.StudentSubjectTagets
                //                  where crtxn.SubjectShortCode == _Exam.SubjectShortCode
                //                  where crtxn.StudentId == studentid
                //                  select crtxn.Target)
                //                 .FirstOrDefault();
                //    if (!db.StudentsExamResults.Any(st => st.StudentId == studentid && st.Examid == _Exam._ExamId))
                //    {
                //        StudentsExamResult ster = new StudentsExamResult();
                //        ster.Examid = _Exam._ExamId;
                //        ster.StudentId = studentid;
                //        ster.SchoolClass = _Exam.ClassId;
                //        db.StudentsExamResults.AddObject(ster);
                //        db.SaveChanges();
                //    }

                //    var ser = (from st in db.StudentsExamResults
                //               where st.SchoolClass == _Exam.ClassId
                //               where st.StudentId == studentid
                //               where st.Examid == _Exam._ExamId
                //               select st)
                //              .FirstOrDefault();

                //    if (ser == null)
                //        throw new Exception("Record not found");

                //    StudentsExamResultsDetail serd = new StudentsExamResultsDetail();
                //    serd.StudentExamResultId = ser.StudentExamResultId;
                //    serd.Subject = _Exam.SubjectShortCode;
                //    serd.Mark = Mark;
                //    serd.Grade = Grade;
                //    serd.Mark_Target = Target;
                //    db.StudentsExamResultsDetails.AddObject(serd);
                //    db.SaveChanges();

                //}
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return;
            }
        }
        private void FormProcessExams_Load(object sender, EventArgs e)
        {
            try
            {
                var exms = from ep in db.ExamPeriods
                           where ep.IsDeleted == false
                           where ep.Status == "A"
                           orderby ep.Year ascending
                           select ep;
                List<ExamPeriod> _examperiods = exms.ToList();
                bindingSourceExamPeriods.DataSource = _examperiods;
                lstExamPeriods.ValueMember = "Id";
                lstExamPeriods.DisplayMember = "Description";
                lstExamPeriods.DataSource = bindingSourceExamPeriods;
                groupBox1.Text = "Exam Periods [ " + bindingSourceExamPeriods.Count.ToString() + " ] ";

                var scls = from sc in db.SchoolClasses
                           where sc.Status == "A"
                           where sc.IsDeleted == false
                           select sc;
                List<SchoolClass> schoolclasses = scls.ToList();
                bindingSourceClasses.DataSource = schoolclasses;
                cbClasses.ValueMember = "Id";
                cbClasses.DisplayMember = "ClassName";
                cbClasses.DataSource = bindingSourceClasses;
                //groupBox6.Text = bindingSourceClasses.Count.ToString();

                progressBarProcess.Visible = false;
                progressBarPeriod.Visible = false;
                lblTimeElaspedProcess.Text = string.Empty;
                lblTimeElapsedPeriod.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lstExamPeriods_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                _ExamPeriod = (ExamPeriod)lstExamPeriods.SelectedItem;
                PopulateExams();
                PopulateRegisteredExams();
                progressBarPeriod.Value = 0;
                lblTimeElapsedPeriod.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cbClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbClasses.SelectedIndex != -1)
            {
                try
                {
                    _SchoolClass = (SchoolClass)cbClasses.SelectedItem;
                    PopulateExams();
                    PopulateRegisteredExams();
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void lstExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                PopulateRegisteredExams();
                progressBarProcess.Value = 0;
                lblTimeElaspedProcess.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateExams()
        {
            bindingSourceExams.DataSource = null;
            groupBox2.Text = "Exams [ " + bindingSourceExams.Count.ToString() + " ]";
            bindingSourceRegdExams.DataSource = null;
            groupBox3.Text = "Registered Exams [ " + bindingSourceRegdExams.Count.ToString() + " ]";

            if (lstExamPeriods.SelectedIndex != -1 && cbClasses.SelectedIndex != -1)
            {
                try
                {
                    ExamPeriod ep = (ExamPeriod)lstExamPeriods.SelectedItem;
                    SchoolClass cls = (SchoolClass)cbClasses.SelectedItem;

                    var exms = from em in rep.GetNonClosedExams(ep, cls)
                               select em;
                    List<Exam> exams = exms.ToList();
                    bindingSourceExams.DataSource = exams;
                    lstExams.ValueMember = "Id";
                    lstExams.DisplayMember = "SubjectShortCode";
                    lstExams.DataSource = bindingSourceExams;
                    groupBox2.Text = "Exams [ " + bindingSourceExams.Count.ToString() + " ]";

                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                    return;
                }
            }
        }
        private void PopulateRegisteredExams()
        {
            bindingSourceRegdExams.DataSource = null;
            if (lstExams.SelectedIndex != -1 && cbClasses.SelectedIndex != -1)
            {
                try
                {
                    SchoolClass _SchoolClass = (SchoolClass)cbClasses.SelectedItem;
                    Exam _exam = (Exam)lstExams.SelectedItem;

                    var _examtypesquery = from ed in db.ExamTypes
                                          where ed.IsDeleted == false
                                          where ed.Status == "A"
                                          join rg in db.RegisteredExams on ed.Id equals rg.ExamTypeId
                                          join exm in db.Exams on rg.ExamId equals exm.Id
                                          where exm.ClassId == _SchoolClass.Id
                                          where exm.Id == _exam.Id
                                          where exm.IsDeleted == false
                                          where exm.Enabled == true
                                          where exm.Closed == false
                                          orderby ed.Description ascending
                                          select ed;
                    List<ExamType> _ExamTypes = _examtypesquery.ToList();

                    if (_ExamTypes != null)
                    {
                        bindingSourceRegdExams.DataSource = _ExamTypes;
                        groupBox3.Text = "Registered Exams [ " + bindingSourceRegdExams.Count.ToString() + " ] ";
                        lstRegdExams.DataSource = bindingSourceRegdExams;
                        lstRegdExams.DisplayMember = "Description";
                        lstRegdExams.ValueMember = "Id";
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                    return;
                }
            }
        }
        private string GradeLookUp(double? Mark, int gradingsys)
        {
            if (!Mark.HasValue) return "No Mark";
            if (!(Mark is double)) return "No Mark";
            try
            {
                var rt = (from r in db.GradingSystemDets
                          orderby r.LMark ascending
                          where r.GradingSystemId == gradingsys
                          where r.LMark <= Mark.Value
                          where r.UMark >= Mark.Value
                          select r).SingleOrDefault();
                string ret = "Unknown";
                if (rt == null) { return ret; }
                return rt.Grade.Trim();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return "Unknown";
            }
        }
        private void btnCloseExam_Click(object sender, EventArgs e)
        {
            if (lstExamPeriods.SelectedIndex != -1 && lstExams.SelectedIndex != -1 && cbClasses.SelectedIndex != -1)
            {
                try
                {
                    ExamPeriod _Examperiod = (ExamPeriod)lstExamPeriods.SelectedItem;
                    Exam _sExam = (Exam)lstExams.SelectedItem;
                    SchoolClass _SchoolClass = (SchoolClass)cbClasses.SelectedItem;

                    if (_sExam.Processed)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Once Closed an Exam cannot be processed! \nDo you wish to Close?", "Confirm Closure", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            ArchiveExam(_Examperiod, _sExam, _SchoolClass);
                            PopulateExams();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You are not allowed to close a non Processed Exam!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        public void ArchiveExam(ExamPeriod _Examperiod, Exam _Exam, SchoolClass _SchoolClass)
        {

            try
            {
                //Remove previous records first if any
                rep.ClearStudentsExamResults(_Exam.Id, _SchoolClass.Id);
                rep.ClearStudentsExamResultsDetail(_Exam.Id, _Exam.SubjectShortCode);


                //Transfer records from working tables to permanent tables
                //StudentsExamResults_Temp --> StudentsExamResults
                //StudentsExamResultsDetail_Temp --> StudentsExamResultsDetail
                rep.CopyExamResultsFromTemps();

                //Clear StudentsExamResults_Temp + StudentsExamResultsDetail_Temp table
                rep.ClearStudentsExamResults_Temp();
                rep.ClearStudentsExamResultsDetail_Temp();

                //Mark Exam as Closed
                rep.MarkExamAsClosed(_Exam.Id);
            }
            catch (Exception e)
            {
                Log.WriteToErrorLogFile(e);
            }
        }
        private List<ExamResultsByClassDTO> GetExamResults()
        {
            try
            {
                //ExamResultsByClassViewModelBuilder mb = new ExamResultsByClassViewModelBuilder(_ExamPeriod, _SchoolClass, connection);
                //ExamResultsByClassViewModel _ViewModel = mb.GetModelBuilder();

                List<ExamResultsByClassDTO> lstdto = new List<ExamResultsByClassDTO>();

                //var data = from se in db.StudentExams
                //           join rg in db.RegisteredExams on se.RegdExamId equals rg.Id
                //           join exm in db.Exams on rg.ExamId equals exm.Id
                //           join et in db.ExamTypes on rg.ExamTypeId equals et.Id
                //           join sj in db.Subjects on exm.SubjectShortCode equals sj.ShortCode
                //           join st in db.Students on se.StudentId equals st.Id
                //           where exm.ExamPeriodId == _ExamPeriod.Id
                //           where exm.ClassId == _SchoolClass.Id
                //           select new ClassExamResult
                //           {
                //               StudentId = st.Id,
                //               StudentAdminNo = st.AdminNo,
                //               StudentName = st.StudentSurName + ", " + st.StudentOtherNames,
                //               SubjectCode = sj.ShortCode,
                //               ExamType = et.ShortCode,
                //               Mark = se.Mark
                //           };

                //var lst = data.ToList();

                //foreach (var item in lst)
                //{
                //    item.Point = rep.PointLookUp(item.Mark, gradingsys);
                //    item.Grade = rep.GradeLookUp(item.Mark, gradingsys);
                //}

                ///*get all possible _examTypesquery into a separate group*/
                //var examtypesquery = (from d in lst
                //                      select d.ExamType)
                //               .Distinct()
                //               .ToList();
                //_ViewModel._ExamTypes = examtypesquery;

                //var subjectsquery = (from d in lst
                //                     orderby d.SubjectCode ascending
                //                     select d.SubjectCode)
                //               .Distinct()
                //               .ToList();
                //var clssbjectsquery = (from cs in db.ClassSubjects
                //                       join sb in db.Subjects on cs.SubjectCode equals sb.ShortCode
                //                       where cs.ClassId == _SchoolClass.Id
                //                       where cs.Status == "A"
                //                       select cs.SubjectCode).Distinct().ToList();
                //_ViewModel._Subjects = clssbjectsquery;

                //var studentsquery = (from d in lst
                //                     select d.StudentId)
                //               .Distinct()
                //               .ToList();
                //_ViewModel._Students = studentsquery;

                //var groups = from d in lst
                //             group d by new { d.StudentId, d.SubjectCode, d.StudentAdminNo, d.StudentName, d.ExamType, d.Mark } into grp
                //             select new ClassExamResult
                //             {
                //                 StudentId = grp.Key.StudentId,
                //                 StudentAdminNo = grp.Key.StudentAdminNo,
                //                 StudentName = grp.Key.StudentName,
                //                 SubjectCode = grp.Key.SubjectCode,
                //                 ExamType = grp.Key.ExamType,
                //                 Mark = grp.Key.Mark
                //             };

                //var _groupeddto = from d in data
                //                  group d by new
                //                  {
                //                      StudentId = d.StudentId,
                //                      StudentName = d.StudentName,
                //                      d.SubjectCode,
                //                      d.Mark
                //                  }
                //                      into grp
                //                      select new ClassSubjectsExamTypes
                //                      {
                //                          StudentId = grp.Key.StudentId,
                //                          SubjectCode = grp.Key.SubjectCode,
                //                          NoOfExamTypes = _ViewModel._ExamTypes.Count(),
                //                          Marks = grp.GroupBy(f => f.SubjectCode)
                //                          .Select(m => new MarksDTO
                //                          {
                //                              Mark = m.Sum(c => c.Mark)
                //                          }),
                //                          Rank = (from o in grp
                //                                  where o.Mark > grp.Key.Mark
                //                                  select o).Count() + 1
                //                      };

                //foreach (var item in _groupeddto.ToList())
                //{
                //    //item.Mark = groups.Sum(i => i.Mark);
                //}
                //foreach (var sub in subjectsquery)
                //{
                //    double? _sum = 0;
                //    var sum = groups.Where(s => s.SubjectCode == sub).Sum(s => s.Mark);
                //    _sum = sum;
                //}
                //foreach (var stid in _ViewModel._Students)
                //{
                //    ExamResultsByClassDTO strec = new ExamResultsByClassDTO();
                //    strec.StudentId = stid;
                //    strec.StudentExamResults = _groupeddto.Where(s => s.StudentId == stid).ToList();
                //    strec.NoOfSubjects = _ViewModel._Subjects.Count();
                //    string _mark = strec.MeanMarks.ToString("N0");
                //    double _Mrk = double.Parse(_mark);
                //    strec.MeanGrade = rep.GradeLookUp(_Mrk, gradingsys);
                //    strec.Remarks = rep.RemarkLookUp(_Mrk, gradingsys);

                //    lstdto.Add(strec);
                //}

                //var q = from _school in lst
                //        orderby _school.Mark ascending
                //        orderby _school.Rank ascending
                //        select new
                //        {
                //            Mark = _school.Mark,
                //            Rank = (from o in lst
                //                    where o.Mark > _school.Mark
                //                    select o).Count() + 1
                //        };
                //foreach (var rec in q)
                //{
                //    //var rank = q.Where(_school => _school.AdminNo == rec.StudentAdminNo).SingleOrDefault();

                //    //if (rank != null)
                //    //    rec.Rank = rank.Rank;
                //}

                return lstdto.OrderByDescending(i => i.Rank).ToList();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private List<SecStudentMarkSheetRecord> RankstudentsMarksheet(List<SubjectExamResult> SubjectsExamResult)
        {
            List<SecStudentMarkSheetRecord> lst = new List<SecStudentMarkSheetRecord>();

            //Pass 1
            List<Student> classStudents = rep.GetClassStudents(_SchoolClass);
            foreach (Student student in classStudents)
            {
                SecStudentMarkSheetRecord strec = new SecStudentMarkSheetRecord();
                strec.NoOfSubjects = _SchoolClass.NoOfSubjects;
                strec.Student = student;
                strec.SubjectsExamResult = SubjectsExamResult.Where(s => s.StudentId == student.Id).ToList();
                strec.MeanGrade = rep.GradeLookUp(strec.MeanMarks, gradingsys);
                lst.Add(strec);
            }

            //do the actual ranking and regrouping according to subject order
            var q = from s in lst
                    orderby s.MeanMarks ascending
                    orderby s.Rank ascending
                    select new
                    {
                        AdminNo = s.Student.AdminNo,
                        Rank = (from o in lst
                                where o.MeanMarks > s.MeanMarks
                                select o).Count() + 1
                    };

            //Pass 2
            foreach (var rec in lst)
            {
                var rank = q.Where(s => s.AdminNo == rec.Student.AdminNo).SingleOrDefault();

                if (rank != null)
                    rec.Rank = rank.Rank;
            }

            return lst;
        }
        #endregion "Private Methods"
    }

    public class ExamProcessService
    {
        //delegate
        public delegate void ExamProcessCompleteEventHandler(object sender, ExamProcessCompleteEventArg e);
        //event
        public event ExamProcessCompleteEventHandler OnCompleteExamProcess;

        public ExamProcessService()
        {

        }
        public void ProcessExams(ProcessExamination _results, SBSchoolDBEntities db, Repository rep, int gradingsys, int _counter, string Conn)
        {
            try
            {
                db = new SBSchoolDBEntities(Conn);
                rep = new Repository(Conn);


                var _studentResultsquery = from d in _results._ProcessExaminations
                                           group d by new
                                           {
                                               d.StudentId,
                                               d.Examid,
                                               d.SchoolClassId,
                                               d._Examperiod,
                                               d._ClassShortCode,
                                               d.SubjectShortCode,
                                               d.TeacherId,
                                               d.Status,
                                               d._ExamTypeShortCode,
                                               d._Term,
                                               d._Year,
                                               d.AdminNo,
                                               d._ClassName,
                                               d._ClassStream,
                                               d._ExamTypeDescription,
                                               d._Teacher,
                                               d.StudentOtherNames,
                                               d.StudentSurName,
                                               d.SubjectDescription                                            
                                           }
                                               into grp
                                               select new ProcessExaminationDTO
                                               {
                                                   StudentId = grp.Key.StudentId,
                                                   Examid = grp.Key.Examid,
                                                   SchoolClassId = grp.Key.SchoolClassId,
                                                   TeacherId = grp.Key.TeacherId,
                                                   Status = grp.Key.Status,
                                                   _ClassShortCode = grp.Key._ClassShortCode,
                                                   _ExamTypeShortCode = grp.Key._ExamTypeShortCode,
                                                   _Term = grp.Key._Term,
                                                   _Year = grp.Key._Year,
                                                   SubjectShortCode = grp.Key.SubjectShortCode,
                                                   AdminNo = grp.Key.AdminNo,
                                                   _ClassName = grp.Key._ClassName,
                                                   _ClassStream = grp.Key._ClassStream,
                                                   _ExamTypeDescription = grp.Key._ExamTypeDescription,
                                                   _Teacher = grp.Key._Teacher,
                                                   StudentOtherNames = grp.Key.StudentOtherNames,
                                                   StudentSurName = grp.Key.StudentSurName,
                                                   SubjectDescription = grp.Key.SubjectDescription,
                                                   _Examperiod = grp.Key._Examperiod
                                               };
                var _studentResults = _studentResultsquery.FirstOrDefault();


                var _Tmrk = _results._Marks.Sum(i => i.TotalMarks);
                decimal tmark = decimal.Parse(_Tmrk.ToString());
                decimal totalmark = Math.Round(tmark, 1, MidpointRounding.AwayFromZero);
                string _tmark = totalmark.ToString();
                double TotalMarks = double.Parse(_tmark);

                var _Mrk = _results._Marks.Select(i => i.MeanMarks).FirstOrDefault();
                decimal mark = decimal.Parse(_Mrk.ToString());
                decimal meanmark = Math.Round(mark, 1, MidpointRounding.AwayFromZero);
                string _mark = meanmark.ToString();
                double MeanMarks = double.Parse(_mark);

                string MeanGrade = rep.GradeLookUp(MeanMarks, gradingsys);
                var TotalPoints = rep.PointLookUp(MeanMarks, gradingsys);
                var _ExamTypeShortCode = _results._ExamTypeShortCode.Select(i => i._ExamTypeShortCode).FirstOrDefault();

                ProcessExaminationDTO _dto = (ProcessExaminationDTO)_studentResults;

                StudentsExamResults_Temp _resultsTable = new StudentsExamResults_Temp();
                _resultsTable.StudentId = _dto.StudentId;
                _resultsTable.Examid = _dto.Examid;
                _resultsTable.SchoolClassId = _dto.SchoolClassId;
                _resultsTable.TeacherId = _dto.TeacherId;
                _resultsTable.TotalMarks_Target = TotalMarks;
                _resultsTable.TotalPoints_Target = TotalPoints;
                _resultsTable.Position_Target = 0;
                _resultsTable.MeanMarks_Target = MeanMarks;
                _resultsTable.MeanGrade_Target = MeanGrade;
                _resultsTable.TotalMarks = TotalMarks;
                _resultsTable.TotalPoints = TotalPoints;
                _resultsTable.Position = 0;
                _resultsTable.MeanMarks = MeanMarks;
                _resultsTable.MeanGrade = MeanGrade;
                _resultsTable.ClassTeacherRemark = _dto.ClassTeacherRemark;
                _resultsTable.HeadTeacherRemark = _dto.HeadTeacherRemark;
                _resultsTable.Status = _dto.Status;
                _resultsTable.IsDeleted = false;

                if (!db.StudentsExamResults_Temp.Any(i => i.Examid == _resultsTable.Examid && i.StudentId == _resultsTable.StudentId))
                {
                    db.StudentsExamResults_Temp.AddObject(_resultsTable);
                    db.SaveChanges();
                }

                var _StudentsExamResultsquery = (from s in db.StudentsExamResults_Temp
                                                 where s.SchoolClassId == _dto.SchoolClassId
                                                 where s.StudentId == _dto.StudentId
                                                 where s.Examid == _dto.Examid
                                                 select s).FirstOrDefault();
                StudentsExamResults_Temp _StudentsExamResult = _StudentsExamResultsquery;

                var Target = (from t in db.StudentSubjectTargets
                              where t.SubjectShortCode == _dto.SubjectShortCode
                              where t.StudentId == _dto.StudentId
                              select t.Target).FirstOrDefault();

                if (_StudentsExamResult != null)
                {

                    StudentsExamResultsDetail_Temp _resultsTableDets = new StudentsExamResultsDetail_Temp();
                    _resultsTableDets.StudentsExamResults_TempId = _StudentsExamResult.Id;
                    _resultsTableDets.SubjectShortCode = _dto.SubjectShortCode;
                    _resultsTableDets.Mark = MeanMarks;
                    _resultsTableDets.Grade = MeanGrade;
                    _resultsTableDets.Mark_Target = MeanMarks;
                    _resultsTableDets.Grade_Target = MeanGrade;
                    _resultsTableDets.IsDeleted = false;

                    if (!db.StudentsExamResultsDetail_Temp.Any(i => i.StudentsExamResults_TempId == _resultsTableDets.StudentsExamResults_TempId && i.SubjectShortCode == _resultsTableDets.SubjectShortCode))
                    {
                        db.StudentsExamResultsDetail_Temp.AddObject(_resultsTableDets);
                        db.SaveChanges();
                    }
                }

                StudentProgresses_Temp _progressTable = new StudentProgresses_Temp();
                _progressTable.StudentId = _dto.StudentId;
                _progressTable.ExamId = _dto.Examid;
                _progressTable.SchoolClassId = _dto.SchoolClassId;
                _progressTable.Year = _dto._Year;
                _progressTable.Term = _dto._Term;
                _progressTable.ClassShortCode = _dto._ClassShortCode;
                _progressTable.SubjectShortCode = _dto.SubjectShortCode;
                _progressTable.TeacherId = _dto.TeacherId;
                _progressTable.TotalMarks = TotalMarks;
                _progressTable.TotalPoints = TotalPoints;
                _progressTable.Position = 0;
                _progressTable.MeanMarks = MeanMarks;
                _progressTable.MeanGrade = MeanGrade;
                _progressTable.ClassTeacherRemark = _dto.ClassTeacherRemark;
                _progressTable.HeadTeacherRemark = _dto.HeadTeacherRemark;
                _progressTable.IsDeleted = false;

                if (!db.StudentProgresses_Temp.Any(i => i.StudentId == _progressTable.StudentId && i.Year == _progressTable.Year && i.Term == _progressTable.Term && i.ClassShortCode == _progressTable.ClassShortCode && i.SubjectShortCode == _progressTable.SubjectShortCode))
                {
                    db.StudentProgresses_Temp.AddObject(_progressTable);
                    db.SaveChanges();
                }

                _counter++;
                OnCompleteExamProcess(this, new ExamProcessCompleteEventArg(_counter, "Admin  No: " + _dto.AdminNo + Environment.NewLine + "Name: " + _dto.StudentSurName + " " + _dto.StudentOtherNames + Environment.NewLine + "Exam: " + _dto.SubjectDescription + Environment.NewLine + "Stream: " + _dto._ClassStream + Environment.NewLine + "Class: " + _dto._ClassName + Environment.NewLine + "ExamPeriod: " + _dto._Examperiod));

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
    }

    public class ExamProcessCompleteEventArg : System.EventArgs
    {
        private int svalue;
        private string _template;

        public ExamProcessCompleteEventArg(int value, string template)
        {
            svalue = value;
            _template = template;
        }

        public int StatusValue
        {
            get { return svalue; }
        }
        public string _Template
        {
            get { return _template; }
        }
    }












}

