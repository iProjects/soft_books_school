using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;
using Rules;

namespace WinSBSchool.Forms
{
    public partial class RegisterStudentsForm : Form
    {
        Repository rep;
        SBSchoolDBEntities db;
        string user;
        Exam _Exam;
        string connection;
        List<StudentRegisterErrors> serrors;
        private int updateStatusCounter = 60;

        public RegisterStudentsForm(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            user = _user;

            serrors = new List<StudentRegisterErrors>();
        }
        private void btnClose_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
        private void btnSearchExams_Click(object sender, EventArgs e)
        {
            try
            {
                SearchExamsSimpleForm f = new SearchExamsSimpleForm(connection) { Owner = this };
                f.OnExamListSelected += new SearchExamsSimpleForm.ExamSelectHandler(f_OnExamListSelected);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnAdvancedSearchExams_Click(object sender, EventArgs e)
        {
            try
            {
                SearchExamsForm f = new SearchExamsForm(connection) { Owner = this };
                f.OnExamListSelected += new SearchExamsForm.ExamSelectHandler(f_OnExamListSelected);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void f_OnExamListSelected(object sender, ExamSelectEventArgs e)
        {
            try
            {
                SetExam(e._Exam);
                RefreshGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SetExam(Exam exam)
        {
            try
            {
                if (exam != null)
                {
                    _Exam = exam;
                    if (_Exam != null)
                    {
                        txtExam.Text = _Exam.Id.ToString();
                    }
                    lblExamPeriod.Text = string.Empty;
                    var _examperiodquery = (from ep in db.ExamPeriods
                                            where ep.Status == "A"
                                            where ep.IsDeleted == false
                                            where ep.Id == _Exam.ExamPeriodId
                                            select ep).FirstOrDefault();
                    ExamPeriod _examperiod = _examperiodquery;
                    if (_examperiod != null)
                    {
                        lblExamPeriod.Text = _examperiod.Description;
                    }
                    lblSubjectDescription.Text = string.Empty;
                    var subjectquery = (from sj in db.Subjects
                                        where sj.Status == "A"
                                        where sj.IsDeleted == false
                                        where sj.ShortCode == _Exam.SubjectShortCode
                                        select sj).FirstOrDefault();
                    Subject _subject = subjectquery;
                    if (_subject != null)
                    {
                        lblSubjectDescription.Text = _subject.Description;
                    }
                    cboSchoolClass.SelectedIndex = -1;
                    var _SchoolClassquery = (from sc in db.SchoolClasses
                                             where sc.Status == "A"
                                             where sc.IsDeleted == false
                                             where sc.Id == _Exam.ClassId
                                             select sc).FirstOrDefault();
                    SchoolClass cls = _SchoolClassquery;
                    if (cls != null)
                    {
                        cboSchoolClass.SelectedValue = cls.Id;
                    }
                    var _examtypequery = from et in db.ExamTypes
                                         where et.Status == "A"
                                         where et.IsDeleted == false
                                         join rg in db.RegisteredExams on et.Id equals rg.ExamTypeId
                                         where rg.Status == "A"
                                         join exm in db.Exams on rg.ExamId equals exm.Id
                                         where exm.Enabled == true
                                         where exm.Closed == false
                                         where exm.IsDeleted == false
                                         where exm.ClassId == cls.Id
                                         where exm.Id == _Exam.Id
                                         where exm.Enabled == true
                                         where exm.Closed == false
                                         orderby et.Description ascending
                                         select et;
                    List<ExamType> _ExamTypes = _examtypequery.ToList();
                    cbRegisteredExamTypes.ValueMember = "Id";
                    cbRegisteredExamTypes.DisplayMember = "Description";
                    cbRegisteredExamTypes.DataSource = _ExamTypes;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnPopulate_Click(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();
                RefreshGrid();
                RefreshNonEligibleStudentsGrid();
                if (cboSchoolClass.SelectedIndex != -1 && cbRegisteredExamTypes.SelectedIndex != -1 && _Exam != null)
                {

                    int _counter = 0;

                    SchoolClass cls = (SchoolClass)cboSchoolClass.SelectedItem;

                    ExamType _ExamType = (ExamType)cbRegisteredExamTypes.SelectedItem;

                    var _ExamPeriodquery = (from epq in db.ExamPeriods
                                            where epq.IsDeleted == false
                                            where epq.Status == "A"
                                            where epq.Id == _Exam.ExamPeriodId
                                            select epq).FirstOrDefault();

                    ExamPeriod _ExamPeriod = _ExamPeriodquery;

                    var _RegisteredExamquery = (from re in db.RegisteredExams
                                                where re.Status == "A"
                                                join exm in db.Exams on re.ExamId equals exm.Id
                                                where exm.Enabled == true
                                                where exm.IsDeleted == false
                                                where exm.Closed == false
                                                join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.Id
                                                where ep.Status == "A"
                                                where ep.IsDeleted == false
                                                where re.ExamTypeId == _ExamType.Id
                                                where exm.ExamPeriodId == _ExamPeriod.Id
                                                where exm.ClassId == cls.Id
                                                where re.ExamTypeId == _ExamType.Id
                                                where re.ExamId == _Exam.Id
                                                select re).FirstOrDefault();
                    RegisteredExam _RegisteredExam = _RegisteredExamquery;

                    if (_RegisteredExam != null)
                    {
                        PopulateRegisteredExam(_Exam, _RegisteredExam, cls, _counter);
                    }

                    RefreshGrid(_RegisteredExam);

                    if (bindingSourceRegdStudents.Count > 0)
                    {
                        MessageBox.Show("Students Registration Successfull. " + Environment.NewLine + "Exam: " + _Exam.Subject.Description + Environment.NewLine + "Exam Type: " + _ExamType.Description + Environment.NewLine + " Term: " + _ExamPeriod.Term.ToString() + Environment.NewLine + " Year: " + _ExamPeriod.Year.ToString() + Environment.NewLine + " Class: " + cls.ClassName, "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (bindingSourceRegdStudents.Count == 0)
                    {
                        MessageBox.Show("No Students Registered!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void updateStatusTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                updateStatusCounter--;
                if (updateStatusCounter == 0)
                {
                    lblTimeElasped.Text = string.Empty;
                    updateStatusTimer.Stop();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateRegisteredExam(Exam _Exam, RegisteredExam regExam, SchoolClass cls, int _counter)
        {
            try
            {
                serrors = new List<StudentRegisterErrors>();
                bindingSourceNonEligibleStudents.DataSource = null;
                groupBox4.Text = "Students Not Registered  " + bindingSourceNonEligibleStudents.Count.ToString();

                progressBarProcess.Visible = true;
                DateTime startTime = DateTime.Now;
                lblTimeElasped.Text = string.Empty;

                var _ClassStudentsquery = from st in db.Students
                                          where st.IsDeleted == false
                                          where st.Status == "A"
                                          join cs in db.ClassStreams
                                          on st.ClassStreamId equals cs.Id
                                          where cs.IsDeleted == false
                                          where cs.ClassId == cls.Id
                                          where st.Status == "A"
                                          orderby cs.Id ascending
                                          select st;
                List<Student> _Students = _ClassStudentsquery.ToList();

                progressBarProcess.Minimum = 0;
                progressBarProcess.Maximum = _Students.Count();

                if (regExam != null)
                {
                    RulesEngineService res = new RulesEngineService(db, rep, _Exam, user);

                    res.OnCompleteRulesEngine += new RulesEngineService.RulesEngineCompleteEventHandler(res_OnCompleteRulesEngine);
                    res.RunEgineOnSingleStudent(_Students, cls, regExam, _counter, user, chkUseRules.Checked);

                    RefreshNonEligibleStudentsGrid(res._StudentRegisterErrors, cls);

                    DateTime endTime = DateTime.Now;

                    TimeSpan tt = endTime - startTime;

                    lblTimeElasped.Text = string.Format("{0} ms", tt.TotalMilliseconds);

                    updateStatusTimer.Tick += new EventHandler(updateStatusTimer_Tick);
                    updateStatusTimer.Interval = 1000; // 1 second
                    updateStatusTimer.Start();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void PopulateRegisteredExam(List<Student> _Students, Exam _exam, RegisteredExam regExam, SchoolClass cls, int _counter)
        {
            try
            {
                foreach (Student student in _Students)
                {
                    RegisterExamRules strules = new RegisterExamRules();
                    //PopulateRulesObject(strules, student);
                    //load and run the rules engine
                    //RulesMediator.RunRules<RegisterExamRules>(strules, "RegExamsRuleSet");
                    if (!db.StudentExams.Any(o => o.RegdExamId == regExam.Id
                        && o.StudentId == student.Id))
                    {
                        //StudentExam studentExam = new StudentExam();
                        //studentExam.StudentId = student.Id;
                        //studentExam.RegdExamId = regExam.Id;
                        //student.Status = "A";
                        //studentExam.ModifiedBy = user;
                        //studentExam.LastModified = DateTime.Now;

                        //db.StudentExams.AddObject(studentExam);
                        //db.SaveChanges();

                        //No Match!
                        if (strules.IsSuccess)
                        {

                        }
                        else
                        {
                            //serrors.Add(new StudentRegisterErrors(student.Id, strules.Message));
                        }
                    }
                }
                //serrors.Add(new StudentRegisterErrors(25, "Testing error"));
                //bindingSourceNonEligibleStudents.DataSource = serrors;
                //groupBox4.Text = "Students Not Registered  " + bindingSourceNonEligibleStudents.Count.ToString();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cfs_OnCompleteRegisterStudents(object sender, RegisterStudentsCompleteEventArg e)
        {
            try
            {
                if (chkUseRules.Checked)
                {
                    progressBarProcess.Value = e.StatusValue;
                    NotifyMessage("REGISTER + RULES ENGINES RUNNING...", e.StatusValue.ToString());
                }
                else
                {
                    progressBarProcess.Value = e.StatusValue;
                    NotifyMessage("REGISTER ENGINE RUNNING...", e.StatusValue.ToString());
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void res_OnCompleteRulesEngine(object sender, RulesEngineCompleteEventArg e)
        {
            try
            {
                if (chkUseRules.Checked)
                {
                    progressBarProcess.Value = e.StatusValue;
                    NotifyMessage("REGISTER + RULES ENGINES RUNNING...", e._Template);
                }
                else
                {
                    progressBarProcess.Value = e.StatusValue;
                    NotifyMessage("REGISTER ENGINE RUNNING...", e._Template);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public RegisterExamRules PopulateRulesObject(RegisterExamRules strules, Student st)
        {
            try
            {

                strules.HrsAttended = this.CalculateStudentAttendanceHrs(st);//use attendance module to sum the hours attended
                strules.FeesPaid = this.CalculateStudentFeesPaid(st);//7000.00M;//use the gl module to retrieve fees paid
                strules.FeesCharged = this.GetStudentFeesCharged(st); //use the fees module to retrieve fees charged for this programme/unit
                strules.UnitHrs = GetUnitHours(st);// use the _school module to retreive hours needed for this programme/unit 
                strules.IsEligible = st.Eligible ?? true;
                strules.PrerequisitesDone = true; //
                strules.IsCompleted = true; // 
                strules.IsSuccess = strules.IsFeesPaid;

                return strules;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private int GetUnitHours(Student st)
        {
            try
            {
                int unithrs = 0;
                var _programmeCoursequery = (from pyc in db.ProgrammeYearCourses
                                             where pyc.IsDeleted == false
                                             join py in db.ProgrammeYears on pyc.ProgrammeYearId equals py.Id
                                             where py.IsDeleted == false
                                             join sc in db.SchoolClasses on py.Id equals sc.ProgrammeYearId
                                             where sc.IsDeleted == false
                                             where sc.Status == "A"
                                             join cs in db.ClassStreams on sc.Id equals cs.ClassId
                                             where cs.Id == st.ClassStreamId
                                             where cs.IsDeleted == false
                                             select pyc).FirstOrDefault();
                ProgrammeYearCours _ProgrammeYearCours = _programmeCoursequery;

                if (_ProgrammeYearCours.NoOfHrs != null)
                {
                    unithrs = _ProgrammeYearCours.NoOfHrs ?? 0;
                }
                return unithrs;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        private decimal CalculateStudentFeesPaid(Student _Student)
        {
            try
            {
                decimal feespaid = 0;
                //get the customer id given a _Student id 
                int acc = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);
                if (acc != -1)
                {
                    var _accountquery = (from ac in db.Accounts
                                         where ac.Id == acc
                                         where ac.Closed == false
                                         select ac).FirstOrDefault();
                    Account _Account = _accountquery;
                    feespaid = _Account.BookBalance;
                }
                return feespaid;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        private int CalculateStudentAttendanceHrs(Student _Student)
        {
            try
            {
                int hrsattended = 0;
                var attendancequery = from att in db.Attendances
                                      where att.IsDeleted == false
                                      where att.StudentId == _Student.Id
                                      select att;
                List<Attendance> _Attendance = attendancequery.ToList();

                if (_Attendance != null)
                {
                    hrsattended = _Attendance.Sum(i => i.EndDateTime.Hour - i.StartDateTime.Hour);
                }
                return hrsattended;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        private decimal GetStudentFeesCharged(Student _Student)
        {
            try
            {
                decimal _fessCharged = 0;
                var _ExamPeriodquery = (from epq in db.ExamPeriods
                                        where epq.IsDeleted == false
                                        where epq.Status == "A"
                                        where epq.Id == _Exam.ExamPeriodId
                                        select epq).FirstOrDefault();
                ExamPeriod _ExamPeriod = _ExamPeriodquery;

                var _feestructurequery = (from fs in db.FeesStructures
                                          where fs.IsDeleted == false
                                          where fs.IsDefault == true
                                          select fs).FirstOrDefault();
                FeesStructure _FeesStructure = _feestructurequery;

                string RawSalt = DateTime.Now.ToString("yMdHms");
                string HashSalt = HashHelper.CreateRandomSalt();
                int foundS1 = HashSalt.IndexOf("==");
                int foundS2 = HashSalt.IndexOf("+");
                int foundS3 = HashSalt.IndexOf("/");
                if (foundS1 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS1);
                }
                if (foundS2 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS2);
                }
                if (foundS3 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS3);
                }
                string SaltedHash = RawSalt.Insert(5, HashSalt);
                string _transRef = SaltedHash;
                List<Transaction> _Transactions = this.ComputeFees(_Student, _FeesStructure.Id, _ExamPeriod.Term, _transRef, user);

                if (_Transactions.Count != 0)
                {
                    var _accountBookBalance = _Transactions.Sum(i => i.Amount);
                    if (_accountBookBalance != null)
                    {
                        _fessCharged = _accountBookBalance;
                    }
                }
                return _fessCharged;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        public List<Transaction> ComputeFees(Student _student, int feestructureId, int _term, string _transRef, string user)
        {
            try
            {
                List<Transaction> lst = new List<Transaction>();

                var cls = (from cs in db.ClassStreams
                           where cs.IsDeleted == false
                           join st in db.Students on cs.Id equals st.ClassStreamId
                           where st.IsDeleted == false
                           where st.Status == "A"
                           where st.Id == _student.Id
                           select cs).FirstOrDefault();
                ClassStream _ClsStrm = cls;

                var _SchoolClassesquery = (from sc in db.SchoolClasses
                                           where sc.IsDeleted == false
                                           where sc.Status == "A"
                                           join cs in db.ClassStreams on _student.ClassStreamId equals cs.Id
                                           where cs.IsDeleted == false
                                           where cs.ClassId == sc.Id
                                           select sc).FirstOrDefault();
                SchoolClass _SchoolClass = _SchoolClassesquery;

                var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                  where fs.IsDeleted == false
                                                  where fs.FeeStructureId == feestructureId
                                                  where fs.Term == _term
                                                  where fs.SchoolClassId == _SchoolClass.Id
                                                  select fs;
                List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();

                var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                               where fs.IsDeleted == false
                                               where fs.FeeStructureId == feestructureId
                                               select fs;
                List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();

                foreach (FeeStructureAcademic feeStructureAcademic in _FeeStructureAcademics)
                {

                    //Debit transaction
                    Transaction drtxn = new Transaction();
                    drtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                    int dracc = rep.GetStudentGLAccount(_student.GLAccountId ?? -1);
                    if (dracc == -1) dracc = int.Parse(rep.SettingLookup("SUSPDR"));
                    drtxn.AccountId = dracc;
                    drtxn.Amount = feeStructureAcademic.Amount * -1;
                    drtxn.UserName = user;
                    drtxn.Authorizer = "SYSTEM";
                    drtxn.StatementFlag = "Y";
                    drtxn.PostDate = DateTime.Today;
                    drtxn.ValueDate = DateTime.Today;
                    drtxn.RecordDate = DateTime.Today;
                    drtxn.TransRef = _transRef;

                    drtxn.Narrative = this.BuildNarrative(_student, _ClsStrm, _SchoolClass, drtxn.AccountId, drtxn.Amount, feeStructureAcademic.Description, "D");
                    lst.Add(drtxn);

                }
                foreach (FeeStructureOther _feeStructureOther in _FeeStructureOthers)
                {

                    //Debit transaction
                    Transaction drtxn = new Transaction();
                    drtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                    int dracc = rep.GetStudentGLAccount(_student.GLAccountId ?? -1);
                    if (dracc == -1) dracc = int.Parse(rep.SettingLookup("SUSPDR"));
                    drtxn.AccountId = dracc;
                    drtxn.Amount = _feeStructureOther.Amount * -1;
                    drtxn.UserName = user;
                    drtxn.Authorizer = "SYSTEM";
                    drtxn.StatementFlag = "Y";
                    drtxn.PostDate = DateTime.Today;
                    drtxn.ValueDate = DateTime.Today;
                    drtxn.RecordDate = DateTime.Today;
                    drtxn.TransRef = _transRef;

                    drtxn.Narrative = this.BuildNarrative(_student, _ClsStrm, _SchoolClass, drtxn.AccountId, drtxn.Amount, _feeStructureOther.Description, "D");
                    lst.Add(drtxn);

                }

                return lst;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string BuildNarrative(Student _student, ClassStream _ClsStrm, SchoolClass _SchoolClass, int accountid, decimal amount, string description, string TType)
        {
            try
            {
                string narr = string.Empty;
                var accntquery = (from acc in db.Accounts
                                  where acc.Closed == false
                                  where acc.Id == accountid
                                  select acc).FirstOrDefault();
                Account _account = accntquery;

                if (_account != null)
                {

                    switch (TType)
                    {
                        case "C":  //build Credit narrative 
                            narr += description + " -  Account [ " + " Name: " + _account.AccountName + ", No: " + _account.AccountNo + " ] " + "Amount [ " + amount.ToString("#,##0") + " ] " + " Student - [ Name: " + _student.StudentSurName + "  " + _student.StudentOtherNames + " ]  [ " + " Admin No: [ " + _student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
                            break;
                        case "D":  //build Debit narrative 
                            narr += description + " -  Account  [" + " Name: " + _account.AccountName + ", No: " + _account.AccountNo + "] " + " Amount [ " + amount.ToString("#,##0") + " ]";
                            break;
                    }

                }
                return narr;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void RefreshGrid()
        {
            bindingSourceRegdStudents.DataSource = null;
            groupBox6.Text = bindingSourceRegdStudents.Count.ToString();

            if (cbRegisteredExamTypes.SelectedIndex != -1 && cboSchoolClass.SelectedIndex != -1 && _Exam != null)
            {
                try
                {
                    SchoolClass cls = (SchoolClass)cboSchoolClass.SelectedItem;
                    ExamType _ExamType = (ExamType)cbRegisteredExamTypes.SelectedItem;

                    if (_ExamType != null)
                    {
                        var _RegisteredExamquery = (from re in db.RegisteredExams
                                                    where re.Status == "A"
                                                    join exm in db.Exams on re.ExamId equals exm.Id
                                                    where exm.Enabled == true
                                                    where exm.IsDeleted == false
                                                    where exm.Id == _Exam.Id
                                                    where exm.ClassId == cls.Id
                                                    where re.ExamTypeId == _ExamType.Id
                                                    select re).FirstOrDefault();
                        RegisteredExam _RegisteredExam = _RegisteredExamquery;

                        if (_RegisteredExam != null)
                        {
                            var _StudentExamsquery = from se in db.StudentExams
                                                     where se.RegdExamId == _RegisteredExam.Id
                                                     select se;
                            List<StudentExam> _StudentExams = _StudentExamsquery.ToList();

                            bindingSourceRegdStudents.DataSource = _StudentExams;
                            groupBox6.Text = bindingSourceRegdStudents.Count.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void RefreshGrid(RegisteredExam _RegisteredExam)
        {
            try
            {
                bindingSourceRegdStudents.DataSource = null;
                groupBox6.Text = bindingSourceRegdStudents.Count.ToString();

                if (_RegisteredExam != null)
                {
                    var _StudentExamsquery = from se in db.StudentExams
                                             where se.RegdExamId == _RegisteredExam.Id
                                             select se;
                    List<StudentExam> _StudentExams = _StudentExamsquery.ToList();
                    bindingSourceRegdStudents.DataSource = _StudentExams;
                    groupBox6.Text = bindingSourceRegdStudents.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshNonEligibleStudentsGrid(List<StudentRegisterErrors> _StudentRegisterErrors, SchoolClass cls)
        {
            try
            {
                bindingSourceNonEligibleStudents.DataSource = null;
                groupBox4.Text = "Students Not Registered  " + bindingSourceNonEligibleStudents.Count.ToString();

                if (_StudentRegisterErrors.Count != 0)
                {

                    bindingSourceNonEligibleStudents.DataSource = _StudentRegisterErrors;
                    groupBox4.Text = "Students Not Registered  " + bindingSourceNonEligibleStudents.Count.ToString();

                    var _ClassStudentsquery = from st in db.Students
                                              where st.IsDeleted == false
                                              join cs in db.ClassStreams
                                              on st.ClassStreamId equals cs.Id
                                              where cs.ClassId == cls.Id
                                              where st.Status == "A"
                                              where cs.IsDeleted == false
                                              orderby cs.Id ascending
                                              select st;
                    List<Student> _StudentAdmino = _ClassStudentsquery.ToList();

                    DataGridViewComboBoxColumn colCboxStudentAdmino = new DataGridViewComboBoxColumn();
                    colCboxStudentAdmino.HeaderText = "Admin No";
                    colCboxStudentAdmino.Name = "cbStudentAdmino";
                    colCboxStudentAdmino.DataSource = _StudentAdmino;
                    // The display member is the name column in the column datasource  
                    colCboxStudentAdmino.DisplayMember = "AdminNo";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxStudentAdmino.DataPropertyName = "StudentId";
                    // The value member is the primary key of the parent table  
                    colCboxStudentAdmino.ValueMember = "Id";
                    colCboxStudentAdmino.MaxDropDownItems = 10;
                    colCboxStudentAdmino.Width = 60;
                    colCboxStudentAdmino.DisplayIndex = 1;
                    colCboxStudentAdmino.MinimumWidth = 5;
                    colCboxStudentAdmino.FlatStyle = FlatStyle.Flat;
                    colCboxStudentAdmino.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxStudentAdmino.ReadOnly = true;
                    if (!this.dataGridViewNonEligibleStudents.Columns.Contains("cbStudentAdmino"))
                    {
                        dataGridViewNonEligibleStudents.Columns.Add(colCboxStudentAdmino);
                    }

                    List<Student> _StudentSurNames = _ClassStudentsquery.ToList();
                    DataGridViewComboBoxColumn colCboxStudentSurName = new DataGridViewComboBoxColumn();
                    colCboxStudentSurName.HeaderText = "SurName";
                    colCboxStudentSurName.Name = "cbStudentSurName";
                    colCboxStudentSurName.DataSource = _StudentSurNames;
                    // The display member is the name column in the column datasource  
                    colCboxStudentSurName.DisplayMember = "StudentSurName";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxStudentSurName.DataPropertyName = "StudentId";
                    // The value member is the primary key of the parent table  
                    colCboxStudentSurName.ValueMember = "Id";
                    colCboxStudentSurName.MaxDropDownItems = 10;
                    colCboxStudentSurName.Width = 70;
                    colCboxStudentSurName.DisplayIndex = 2;
                    colCboxStudentSurName.MinimumWidth = 5;
                    colCboxStudentSurName.FlatStyle = FlatStyle.Flat;
                    colCboxStudentSurName.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxStudentSurName.ReadOnly = true;
                    if (!this.dataGridViewNonEligibleStudents.Columns.Contains("cbStudentSurName"))
                    {
                        dataGridViewNonEligibleStudents.Columns.Add(colCboxStudentSurName);
                    }

                    List<Student> _Students = _ClassStudentsquery.ToList();
                    DataGridViewComboBoxColumn colCboxStudentOtherNames = new DataGridViewComboBoxColumn();
                    colCboxStudentOtherNames.HeaderText = "Other Names";
                    colCboxStudentOtherNames.Name = "cbStudentOtherNames";
                    colCboxStudentOtherNames.DataSource = _Students;
                    // The display member is the name column in the column datasource  
                    colCboxStudentOtherNames.DisplayMember = "StudentOtherNames";
                    // The DataPropertyName refers to the foreign key column on the datagridview datasource
                    colCboxStudentOtherNames.DataPropertyName = "StudentId";
                    // The value member is the primary key of the parent table  
                    colCboxStudentOtherNames.ValueMember = "Id";
                    colCboxStudentOtherNames.MaxDropDownItems = 10;
                    colCboxStudentOtherNames.Width = 110;
                    colCboxStudentOtherNames.DisplayIndex = 3;
                    colCboxStudentOtherNames.MinimumWidth = 5;
                    colCboxStudentOtherNames.FlatStyle = FlatStyle.Flat;
                    colCboxStudentOtherNames.DefaultCellStyle.NullValue = "--- Select ---";
                    colCboxStudentOtherNames.ReadOnly = true;
                    if (!this.dataGridViewNonEligibleStudents.Columns.Contains("cbStudentOtherNames"))
                    {
                        dataGridViewNonEligibleStudents.Columns.Add(colCboxStudentOtherNames);
                    }

                    dataGridViewNonEligibleStudents.AutoGenerateColumns = false;
                    dataGridViewNonEligibleStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridViewNonEligibleStudents.DataSource = bindingSourceNonEligibleStudents;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void RefreshNonEligibleStudentsGrid()
        {
            try
            {
                bindingSourceNonEligibleStudents.DataSource = null;
                groupBox4.Text = "Students Not Registered  " + bindingSourceNonEligibleStudents.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void ClearGrid()
        {
            try
            {
                bindingSourceNonEligibleStudents.DataSource = null;
                groupBox4.Text = "Students Not Registered  " + bindingSourceNonEligibleStudents.Count.ToString();
                dataGridViewNonEligibleStudents.DataSource = bindingSourceNonEligibleStudents;

                bindingSourceRegdStudents.DataSource = null;
                groupBox6.Text = bindingSourceRegdStudents.Count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<StudentRegisterErrors> RunRegistrationRulesEngine(List<Student> _Students)
        {
            try
            {
                List<StudentRegisterErrors> _serrors = new List<StudentRegisterErrors>();

                foreach (Student student in _Students)
                {
                    RegisterExamRules strules = new RegisterExamRules();
                    PopulateRulesObject(strules, student);
                    //load and run the rules engine
                    RulesMediator.RunRules<RegisterExamRules>(strules, "RegExamsRuleSet");

                    //Not Meeting Requirements for Registration
                    if (!strules.IsSuccess)
                    {
                        _serrors.Add(new StudentRegisterErrors(student.Id, strules.Message));
                    }
                    else
                    {
                        //_serrors.Add(new StudentRegisterErrors(student.Id, strules.Message));
                    }
                }
                return _serrors;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void RegisterStudentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                var _SchoolClassesquery = from sc in db.SchoolClasses
                                          where sc.Status == "A"
                                          where sc.IsDeleted == false
                                          select sc;
                List<SchoolClass> _SchoolClasses = _SchoolClassesquery.ToList();
                cboSchoolClass.DisplayMember = "ClassName";
                cboSchoolClass.ValueMember = "Id";
                cboSchoolClass.DataSource = _SchoolClasses;

                var _StudentsAdminNoquery = from st in db.Students
                                            where st.Status == "A"
                                            where st.IsDeleted == false
                                            select st;
                List<Student> _StudentsAdminNo = _StudentsAdminNoquery.ToList();

                DataGridViewComboBoxColumn colCboxClassStudentAdmino = new DataGridViewComboBoxColumn();
                colCboxClassStudentAdmino.HeaderText = "AdminNo";
                colCboxClassStudentAdmino.Name = "cbClassStudents";
                colCboxClassStudentAdmino.DataSource = _StudentsAdminNo;
                // The display member is the name column in the column datasource  
                colCboxClassStudentAdmino.DisplayMember = "AdminNo";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxClassStudentAdmino.DataPropertyName = "StudentId";
                // The value member is the primary key of the parent table  
                colCboxClassStudentAdmino.ValueMember = "Id";
                colCboxClassStudentAdmino.MaxDropDownItems = 10;
                colCboxClassStudentAdmino.Width = 150;
                colCboxClassStudentAdmino.DisplayIndex = 1;
                colCboxClassStudentAdmino.MinimumWidth = 5;
                colCboxClassStudentAdmino.FlatStyle = FlatStyle.Flat;
                colCboxClassStudentAdmino.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassStudentAdmino.ReadOnly = true;
                if (!this.dataGridViewRegdStudents.Columns.Contains("cbClassStudents"))
                {
                    dataGridViewRegdStudents.Columns.Add(colCboxClassStudentAdmino);
                }

                var _StudentsSurNamequery = from st in db.Students
                                            where st.Status == "A"
                                            where st.IsDeleted == false
                                            select st;
                List<Student> _StudentsSurName = _StudentsSurNamequery.ToList();

                DataGridViewComboBoxColumn colCboxClassStudentsurName = new DataGridViewComboBoxColumn();
                colCboxClassStudentsurName.HeaderText = "SurName";
                colCboxClassStudentsurName.Name = "cbClassStudentSurName";
                colCboxClassStudentsurName.DataSource = _StudentsSurName;
                // The display member is the name column in the column datasource  
                colCboxClassStudentsurName.DisplayMember = "StudentSurName";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxClassStudentsurName.DataPropertyName = "StudentId";
                // The value member is the primary key of the parent table  
                colCboxClassStudentsurName.ValueMember = "Id";
                colCboxClassStudentsurName.MaxDropDownItems = 10;
                colCboxClassStudentsurName.Width = 200;
                colCboxClassStudentsurName.DisplayIndex = 2;
                colCboxClassStudentsurName.MinimumWidth = 5;
                colCboxClassStudentsurName.FlatStyle = FlatStyle.Flat;
                colCboxClassStudentsurName.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassStudentsurName.ReadOnly = true;
                if (!this.dataGridViewRegdStudents.Columns.Contains("cbClassStudentSurName"))
                {
                    dataGridViewRegdStudents.Columns.Add(colCboxClassStudentsurName);
                }

                var _StudentsOtherNamesquery = from st in db.Students
                                               where st.IsDeleted == false
                                               where st.Status == "A"
                                               select st;
                List<Student> _StudentsOtherNames = _StudentsOtherNamesquery.ToList();

                DataGridViewComboBoxColumn colCboxClassStudentOtherNames = new DataGridViewComboBoxColumn();
                colCboxClassStudentOtherNames.HeaderText = "OtherNames";
                colCboxClassStudentOtherNames.Name = "cbClassStudentOtherNames";
                colCboxClassStudentOtherNames.DataSource = _StudentsOtherNames;
                // The display member is the name column in the column datasource  
                colCboxClassStudentOtherNames.DisplayMember = "StudentOtherNames";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxClassStudentOtherNames.DataPropertyName = "StudentId";
                // The value member is the primary key of the parent table  
                colCboxClassStudentOtherNames.ValueMember = "Id";
                colCboxClassStudentOtherNames.MaxDropDownItems = 10;
                colCboxClassStudentOtherNames.Width = 200;
                colCboxClassStudentOtherNames.DisplayIndex = 3;
                colCboxClassStudentOtherNames.MinimumWidth = 5;
                colCboxClassStudentOtherNames.FlatStyle = FlatStyle.Flat;
                colCboxClassStudentOtherNames.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxClassStudentOtherNames.ReadOnly = true;
                colCboxClassStudentOtherNames.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!this.dataGridViewRegdStudents.Columns.Contains("cbClassStudentOtherNames"))
                {
                    dataGridViewRegdStudents.Columns.Add(colCboxClassStudentOtherNames);
                }

                dataGridViewRegdStudents.AutoGenerateColumns = false;
                dataGridViewRegdStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewRegdStudents.DataSource = bindingSourceRegdStudents;

                lblExamPeriod.Text = string.Empty;
                lblSubjectDescription.Text = string.Empty;
                txtExam.Enabled = false;
                progressBarProcess.Visible = false;
                lblTimeElasped.Text = string.Empty;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cboSchoolClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();
                RefreshGrid();
                RefreshNonEligibleStudentsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSave_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                db.SaveChanges(System.Data.Objects.SaveOptions.AcceptAllChangesAfterSave);
                MessageBox.Show("Succesfully saved", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void cbRegdExams_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();
                RefreshGrid();
                RefreshNonEligibleStudentsGrid();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnPopulateAll_Click(object sender, EventArgs e)
        {
            try
            {
                ClearGrid();
                RegisterAllStudentsForAllSubjects();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
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
        private void RegisterAllStudentsForAllSubjects()
        {
            RefreshGrid();
            RefreshNonEligibleStudentsGrid();

            if (cboSchoolClass.SelectedIndex != -1 && cbRegisteredExamTypes.SelectedIndex != -1 && _Exam != null)
            {
                try
                {
                    serrors = new List<StudentRegisterErrors>();
                    int _counter = 0;
                    //progressBarProcess.Visible = true;
                    //DateTime startTime = DateTime.Now;
                    //lblTimeElasped.Text = string.Empty;

                    SchoolClass cls = (SchoolClass)cboSchoolClass.SelectedItem;

                    ExamType _ExamType = (ExamType)cbRegisteredExamTypes.SelectedItem;

                    var _ExamPeriodquery = (from epq in db.ExamPeriods
                                            where epq.IsDeleted == false
                                            where epq.Status == "A"
                                            where epq.Id == _Exam.ExamPeriodId
                                            select epq).FirstOrDefault();
                    ExamPeriod _ExamPeriod = _ExamPeriodquery;

                    var _RegisteredExamquery = from exm in db.Exams
                                               where exm.Closed == false
                                               where exm.IsDeleted == false
                                               where exm.Enabled == true
                                               join ep in db.ExamPeriods on exm.ExamPeriodId equals ep.Id
                                               where ep.Status == "A"
                                               where ep.IsDeleted == false
                                               join re in db.RegisteredExams on exm.Id equals re.ExamId
                                               where re.Status == "A"
                                               join et in db.ExamTypes on re.ExamTypeId equals et.Id
                                               where et.Status == "A"
                                               where et.IsDeleted == false
                                               where re.ExamTypeId == _ExamType.Id
                                               where exm.ExamPeriodId == _ExamPeriod.Id
                                               where exm.ClassId == cls.Id
                                               select re;
                    List<RegisteredExam> _RegisteredExams = _RegisteredExamquery.ToList();

                    var _ClassStudentsquery = from st in db.Students
                                              where st.Status == "A"
                                              where st.IsDeleted == false
                                              join cs in db.ClassStreams
                                              on st.ClassStreamId equals cs.Id
                                              where st.IsDeleted == false
                                              where cs.ClassId == cls.Id
                                              where st.Status == "A"
                                              orderby cs.Id ascending
                                              select st;
                    List<Student> _Students = _ClassStudentsquery.ToList();

                    //progressBarProcess.Minimum = 0;
                    //progressBarProcess.Maximum = _Students.Count();
                    foreach (var _registeredExam in _RegisteredExams)
                    {
                        if (_registeredExam != null)
                        {
                            PopulateRegisteredExam(_Exam, _registeredExam, cls, _counter);

                            //RulesEngineService res = new RulesEngineService(db, rep, _Exam, user);

                            //res.OnCompleteRulesEngine += new RulesEngineService.RulesEngineCompleteEventHandler(res_OnCompleteRulesEngine);
                            //res.RunEgineOnSingleStudent(_Students, cls, _registeredExam, _counter, user, chkUseRules.Checked);

                            //RefreshNonEligibleStudentsGrid(res._StudentRegisterErrors, cls);
                        }
                    }
                    RefreshGrid();

                    //DateTime endTime = DateTime.Now;

                    //TimeSpan tt = endTime - startTime;

                    //lblTimeElasped.Text = string.Format("{0} ms", tt.TotalMilliseconds);

                    //updateStatusTimer.Tick += new EventHandler(updateStatusTimer_Tick);
                    //updateStatusTimer.Interval = 1000; // 1 second
                    //updateStatusTimer.Start();

                    if (bindingSourceRegdStudents.Count > 0)
                    {
                        MessageBox.Show("Students Registration Successfull. " + Environment.NewLine + "Exam Type: " + _ExamType.Description + Environment.NewLine + " Term: " + _ExamPeriod.Term.ToString() + Environment.NewLine + " Year: " + _ExamPeriod.Year.ToString() + Environment.NewLine + " Class: " + cls.ClassName, "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (bindingSourceRegdStudents.Count == 0)
                    {
                        MessageBox.Show("No Students Registered!", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridViewRegdStudents_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void dataGridViewNonEligibleStudents_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Reports.Viewer.PDFViewer _viewer = new Reports.Viewer.PDFViewer(user, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private void printExamCardSelectedClassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Reports.Viewer.PDFViewer _viewer = new Reports.Viewer.PDFViewer(user, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private void printExamCardAllClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //Reports.Viewer.PDFViewer _viewer = new Reports.Viewer.PDFViewer(user, connection);
                //_viewer.WindowState = FormWindowState.Normal;
                //_viewer.StartPosition = FormStartPosition.CenterScreen;
                //_viewer.Show();
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }

    }

    public class RegisterStudentsService
    {
        //delegate
        public delegate void RegisterStudentsCompleteEventHandler(object sender, RegisterStudentsCompleteEventArg e);
        //event
        public event RegisterStudentsCompleteEventHandler OnCompleteRegisterStudents;

        SBSchoolDBEntities db;
        Repository rep;

        public RegisterStudentsService(SBSchoolDBEntities _db, Repository _rep)
        {
            if (_db == null)
                throw new ArgumentNullException("SBSchoolDBEntities");
            db = _db;

            if (_rep == null)
                throw new ArgumentNullException("Repository");
            rep = _rep;

        }
        public void RegisterStudentsAllSubjects(List<RegisteredExam> _RegisteredExams, SchoolClass cls, int _counter, string user)
        {
            try
            {
                var _ClassStudentsquery = from st in db.Students
                                          where st.IsDeleted == false
                                          where st.Status == "A"
                                          join cs in db.ClassStreams
                                          on st.ClassStreamId equals cs.Id
                                          where cs.IsDeleted == false
                                          where cs.ClassId == cls.Id
                                          where st.Status == "A"
                                          orderby cs.Id ascending
                                          select st;
                List<Student> _Students = _ClassStudentsquery.ToList();

                foreach (var r in _RegisteredExams)
                {
                    RegisterStudentsAllSubjects(_Students, cls, r, user);

                    _counter++;
                    OnCompleteRegisterStudents(this, new RegisterStudentsCompleteEventArg(_counter));
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RegisterStudentsAllSubjects(List<Student> _Students, SchoolClass cls, RegisteredExam regExam, string user)
        {
            try
            {
                foreach (Student s in _Students)
                {
                    PopulateRegisteredStudents(s, regExam, user);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void RegisterStudentsSingleSubject(List<Student> _Students, SchoolClass cls, RegisteredExam regExam, int _counter, string user)
        {
            try
            {
                foreach (Student s in _Students)
                {
                    PopulateRegisteredStudents(s, regExam, user);

                    _counter++;
                    OnCompleteRegisterStudents(this, new RegisterStudentsCompleteEventArg(_counter));
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateRegisteredStudents(Student student, RegisteredExam regExam, string user)
        {

            try
            {
                RegisterExamRules strules = new RegisterExamRules();
                //PopulateRulesObject(strules, student);
                //load and run the rules engine
                //RulesMediator.RunRules<RegisterExamRules>(strules, "RegExamsRuleSet");

                //Not Meeting Requirements for Registration
                if (strules.IsSuccess)
                {
                    if (!db.StudentExams.Any(o => o.RegdExamId == regExam.Id
                        && o.StudentId == student.Id))
                    {
                        StudentExam studentExam = new StudentExam();
                        studentExam.StudentId = student.Id;
                        studentExam.RegdExamId = regExam.Id;
                        student.Status = "A";
                        studentExam.ModifiedBy = user;
                        studentExam.LastModified = DateTime.Now;

                        //db.StudentExams.AddObject(studentExam);
                        //db.SaveChanges(); 
                    }
                }
                else
                {
                    //serrors.Add(new StudentRegisterErrors(student.Id, strules.Message));
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }







    }


    public class RulesEngineService
    {
        //delegate
        public delegate void RulesEngineCompleteEventHandler(object sender, RulesEngineCompleteEventArg e);
        //event
        public event RulesEngineCompleteEventHandler OnCompleteRulesEngine;

        SBSchoolDBEntities db;
        Repository rep;
        string user;
        Exam _Exam;
        List<StudentRegisterErrors> serrors;
        public List<StudentRegisterErrors> _StudentRegisterErrors
        {
            get { return this.serrors; }
            set { serrors = value; }
        }
        public RulesEngineService(SBSchoolDBEntities _db, Repository _rep, Exam Exam, string _user)
        {
            if (_db == null)
                throw new ArgumentNullException("SBSchoolDBEntities");
            db = _db;

            if (_rep == null)
                throw new ArgumentNullException("Repository");
            rep = _rep;

            if (_user == null)
                throw new ArgumentNullException("user");
            user = _user;

            if (Exam == null)
                throw new ArgumentNullException("Exam");
            _Exam = Exam;

            serrors = new List<StudentRegisterErrors>();
        }
        public RegisterExamRules PopulateRulesObject(RegisterExamRules strules, Student st)
        {
            try
            {

                strules.HrsAttended = this.CalculateStudentAttendanceHrs(st);//use attendance module to sum the hours attended
                strules.FeesPaid = this.CalculateStudentFeesPaid(st);//7000.00M;//use the gl module to retrieve fees paid
                strules.FeesCharged = this.GetStudentFeesCharged(st); //use the fees module to retrieve fees charged for this programme/unit
                strules.UnitHrs = GetUnitHours(st);// use the _school module to retreive hours needed for this programme/unit 
                strules.IsEligible = st.Eligible ?? true;
                strules.PrerequisitesDone = true; //
                strules.IsCompleted = strules.UnitHrs == strules.HrsAttended; // 
                strules.IsSuccess = strules.IsCompleted && strules.IsEligible && strules.PrerequisitesDone && strules.IsFeesPaid;

                return strules;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private int GetUnitHours(Student st)
        {
            try
            {
                int unithrs = 0;
                var _programmeCoursequery = (from pyc in db.ProgrammeYearCourses
                                             where pyc.IsDeleted == false
                                             join py in db.ProgrammeYears on pyc.ProgrammeYearId equals py.Id
                                             where py.IsDeleted == false
                                             join sc in db.SchoolClasses on py.Id equals sc.ProgrammeYearId
                                             where sc.IsDeleted == false
                                             where sc.Status == "A"
                                             join cs in db.ClassStreams on sc.Id equals cs.ClassId
                                             where cs.Id == st.ClassStreamId
                                             where cs.IsDeleted == false
                                             select pyc).FirstOrDefault();
                ProgrammeYearCours _ProgrammeYearCours = _programmeCoursequery;

                if (_ProgrammeYearCours.NoOfHrs != null)
                {
                    unithrs = _ProgrammeYearCours.NoOfHrs ?? 0;
                }
                return unithrs;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        private decimal CalculateStudentFeesPaid(Student _Student)
        {
            try
            {
                decimal feespaid = 0;
                //get the customer id given a _Student id 
                int acc = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);
                if (acc != -1)
                {
                    var _accountquery = (from ac in db.Accounts
                                         where ac.Id == acc
                                         where ac.Closed == false
                                         select ac).FirstOrDefault();
                    Account _Account = _accountquery;
                    if (_Account != null)
                    {
                        var _transactionquery = from tr in db.Transactions
                                                where tr.AccountId == _Account.Id
                                                select tr;
                        List<Transaction> _transactions = _transactionquery.ToList();

                        feespaid = _transactions.Sum(i => i.Amount);
                    }
                }
                return feespaid;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        private int CalculateStudentAttendanceHrs(Student _Student)
        {
            try
            {
                int hrsattended = 0;
                var attendancequery = from att in db.Attendances
                                      where att.IsDeleted == false
                                      where att.StudentId == _Student.Id
                                      select att;
                List<Attendance> _Attendance = attendancequery.ToList();

                if (_Attendance != null)
                {
                    hrsattended = _Attendance.Sum(i => i.EndDateTime.Hour - i.StartDateTime.Hour);
                }
                return hrsattended;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        private decimal GetStudentFeesCharged(Student _Student)
        {
            try
            {
                decimal _fessCharged = 0;
                var _ExamPeriodquery = (from epq in db.ExamPeriods
                                        where epq.IsDeleted == false
                                        where epq.Status == "A"
                                        where epq.Id == _Exam.ExamPeriodId
                                        select epq).FirstOrDefault();
                ExamPeriod _ExamPeriod = _ExamPeriodquery;

                var _feestructurequery = (from fs in db.FeesStructures
                                          where fs.IsDeleted == false
                                          where fs.IsDefault == true
                                          select fs).FirstOrDefault();
                FeesStructure _FeesStructure = _feestructurequery;

                string _transRef = this.GenerateTransactionReference();

                List<Transaction> _Transactions = this.ComputeFees(_Student, _FeesStructure.Id, _ExamPeriod.Term, _transRef, user);

                if (_Transactions.Count != 0)
                {
                    var _accountBookBalance = _Transactions.Sum(i => i.Amount);
                    if (_accountBookBalance != null)
                    {
                        _fessCharged = _accountBookBalance;
                    }
                }
                return _fessCharged;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
        }
        private string GenerateTransactionReference()
        {
            try
            {
                string RawSalt = DateTime.Now.ToString("yMdHms");
                string HashSalt = HashHelper.CreateRandomSalt();
                int foundS1 = HashSalt.IndexOf("==");
                int foundS2 = HashSalt.IndexOf("+");
                int foundS3 = HashSalt.IndexOf("/");
                string SaltedHash = RawSalt.Insert(1, HashSalt);
                string _transRef = SaltedHash;

                return _transRef;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        public List<Transaction> ComputeFees(Student _student, int feestructureId, int _term, string _transRef, string user)
        {
            try
            {
                List<Transaction> lst = new List<Transaction>();

                var cls = (from cs in db.ClassStreams
                           where cs.IsDeleted == false
                           join st in db.Students on cs.Id equals st.ClassStreamId
                           where st.Id == _student.Id
                           where st.IsDeleted == false
                           where st.Status == "A"
                           select cs).FirstOrDefault();
                ClassStream _ClsStrm = cls;

                var _SchoolClassesquery = (from sc in db.SchoolClasses
                                           where sc.IsDeleted == false
                                           where sc.Status == "A"
                                           join cs in db.ClassStreams on _student.ClassStreamId equals cs.Id
                                           where cs.IsDeleted == false
                                           where cs.ClassId == sc.Id
                                           select sc).FirstOrDefault();
                SchoolClass _SchoolClass = _SchoolClassesquery;

                var _FeeStructureAcademicsquery = from fs in db.FeeStructureAcademics
                                                  where fs.IsDeleted == false
                                                  where fs.FeeStructureId == feestructureId
                                                  where fs.Term == _term
                                                  where fs.SchoolClassId == _SchoolClass.Id
                                                  select fs;
                List<FeeStructureAcademic> _FeeStructureAcademics = _FeeStructureAcademicsquery.ToList();

                var _FeeStructureOthersquery = from fs in db.FeeStructureOthers
                                               where fs.IsDeleted == false
                                               where fs.FeeStructureId == feestructureId
                                               select fs;
                List<FeeStructureOther> _FeeStructureOthers = _FeeStructureOthersquery.ToList();

                foreach (FeeStructureAcademic feeStructureAcademic in _FeeStructureAcademics)
                {

                    //Debit transaction
                    Transaction drtxn = new Transaction();
                    drtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                    int dracc = rep.GetStudentGLAccount(_student.GLAccountId ?? -1);
                    if (dracc == -1) dracc = int.Parse(rep.SettingLookup("SUSPDR"));
                    drtxn.AccountId = dracc;
                    drtxn.Amount = feeStructureAcademic.Amount;
                    drtxn.UserName = user;
                    drtxn.Authorizer = "SYSTEM";
                    drtxn.StatementFlag = "Y";
                    drtxn.PostDate = DateTime.Today;
                    drtxn.ValueDate = DateTime.Today;
                    drtxn.RecordDate = DateTime.Today;
                    drtxn.TransRef = _transRef;

                    drtxn.Narrative = this.BuildNarrative(_student, _ClsStrm, _SchoolClass, drtxn.AccountId, drtxn.Amount, feeStructureAcademic.Description, "D");
                    lst.Add(drtxn);

                }
                foreach (FeeStructureOther _feeStructureOther in _FeeStructureOthers)
                {

                    //Debit transaction
                    Transaction drtxn = new Transaction();
                    drtxn.TransactionTypeId = int.Parse(rep.SettingLookup("FEESPOSTINGTXN"));
                    int dracc = rep.GetStudentGLAccount(_student.GLAccountId ?? -1);
                    if (dracc == -1) dracc = int.Parse(rep.SettingLookup("SUSPDR"));
                    drtxn.AccountId = dracc;
                    drtxn.Amount = _feeStructureOther.Amount;
                    drtxn.UserName = user;
                    drtxn.Authorizer = "SYSTEM";
                    drtxn.StatementFlag = "Y";
                    drtxn.PostDate = DateTime.Today;
                    drtxn.ValueDate = DateTime.Today;
                    drtxn.RecordDate = DateTime.Today;
                    drtxn.TransRef = _transRef;

                    drtxn.Narrative = this.BuildNarrative(_student, _ClsStrm, _SchoolClass, drtxn.AccountId, drtxn.Amount, _feeStructureOther.Description, "D");
                    lst.Add(drtxn);

                }

                return lst;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private string BuildNarrative(Student _student, ClassStream _ClsStrm, SchoolClass _SchoolClass, int accountid, decimal amount, string description, string TType)
        {
            try
            {
                string narr = string.Empty;
                var accntquery = (from acc in db.Accounts
                                  where acc.Id == accountid
                                  where acc.Closed == false
                                  select acc).FirstOrDefault();
                Account _account = accntquery;
                if (_account != null)
                {

                    switch (TType)
                    {
                        case "C":  //build Credit narrative 
                            narr += description + " -  Account [ " + " Name: " + _account.AccountName + ", No: " + _account.AccountNo + " ] " + "Amount [ " + amount.ToString("#,##0") + " ] " + " Student - [ Name: " + _student.StudentSurName + "  " + _student.StudentOtherNames + " ]  [ " + " Admin No: [ " + _student.AdminNo + " ] " + " Class: [ " + _SchoolClass.ClassName + " ] " + " Stream: [ " + _ClsStrm.Description + " ] ";
                            break;
                        case "D":  //build Debit narrative 
                            narr += description + " -  Account  [" + " Name: " + _account.AccountName + ", No: " + _account.AccountNo + "] " + " Amount [ " + amount.ToString("#,##0") + " ]";
                            break;
                    }
                }
                return narr;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        public void RunEgineOnSingleStudent(List<Student> _Students, SchoolClass cls, RegisteredExam regExam, int _counter, string user, bool UseRules)
        {
            try
            {
                foreach (Student s in _Students)
                {
                    PopulateRegisteredStudents(s, regExam, user, UseRules);

                    _counter++;
                    OnCompleteRulesEngine(this, new RulesEngineCompleteEventArg(_counter, "Admin  No: " + s.AdminNo + Environment.NewLine + "Name: " + s.StudentSurName + " " + s.StudentOtherNames + Environment.NewLine + "Exam: " + regExam.Exam.Subject.Description + Environment.NewLine + "Exam Type: " + regExam.ExamType.Description + Environment.NewLine + "Stream: " + s.ClassStream.Description + Environment.NewLine + "Class: " + s.ClassStream.SchoolClass.ClassName));
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateRegisteredStudents(Student student, RegisteredExam regExam, string user, bool UseRules)
        {
            try
            {
                if (UseRules == true)
                {
                    RegisterExamRules strules = new RegisterExamRules();
                    PopulateRulesObject(strules, student);
                    //load and run the rules engine
                    RulesMediator.RunRules<RegisterExamRules>(strules, "RegExamsRuleSet");

                    //Meeting Requirements for Registration
                    if (strules.IsSuccess)
                    {
                        if (!db.StudentExams.Any(o => o.RegdExamId == regExam.Id
                            && o.StudentId == student.Id))
                        {
                            StudentExam studentExam = new StudentExam();
                            studentExam.StudentId = student.Id;
                            studentExam.RegdExamId = regExam.Id;
                            student.Status = "A";
                            studentExam.ModifiedBy = user;
                            studentExam.LastModified = DateTime.Now;
                            studentExam.IsDeleted = false;
                            //studentExam.Mark = 0;

                            db.StudentExams.AddObject(studentExam);
                            db.SaveChanges();

                        }
                    }
                    else
                    {
                        serrors.Add(new StudentRegisterErrors(student.Id, strules.Message));
                    }
                }
                else
                {
                    if (!db.StudentExams.Any(o => o.RegdExamId == regExam.Id
                           && o.StudentId == student.Id))
                    {
                        StudentExam studentExam = new StudentExam();
                        studentExam.StudentId = student.Id;
                        studentExam.RegdExamId = regExam.Id;
                        student.Status = "A";
                        studentExam.ModifiedBy = user;
                        studentExam.LastModified = DateTime.Now;

                        db.StudentExams.AddObject(studentExam);
                        db.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

    }

    public class RegisterStudentsCompleteEventArg : System.EventArgs
    {
        private int svalue;

        public RegisterStudentsCompleteEventArg(int value)
        {
            svalue = value;
        }

        public int StatusValue
        {
            get { return svalue; }
        }
    }

    public class RulesEngineCompleteEventArg : System.EventArgs
    {
        private int svalue;
        private string _template;

        public RulesEngineCompleteEventArg(int value, string template)
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

    public class StudentRegisterErrors
    {
        int studentid;
        string message;

        public StudentRegisterErrors()
        {
        }
        public StudentRegisterErrors(int student, string msg)
        {
            studentid = student;
            message = msg;
        }

        public int StudentId
        {
            get
            { return this.studentid; }
            set { studentid = value; }
        }
        public string Message
        {
            get { return this.message; }
            set { message = value; }
        }
    }

}