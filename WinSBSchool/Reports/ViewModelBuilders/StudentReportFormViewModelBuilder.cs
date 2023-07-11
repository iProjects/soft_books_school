using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing; 
using System.IO;
using System.Linq; 
using System.Text;
using System.Windows.Forms; 
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;
using CommonLib;
using DAL;
using WinSBSchool.Forms.Charting;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class StudentReportFormViewModelBuilder
    {

        StudentReportFormViewModel _ViewModel;
        SchoolClass _SchoolClass;
        ExamPeriod _ExamPeriod;
        School school;
        string connection;
        Student _Student;
        int gradingsys;
        SBSchoolDBEntities db;
        Repository rep;
        DataTable dtDataPoints = null;
        string fileLogo;
        string slogan;

        public StudentReportFormViewModelBuilder(School _school, Student _student, SchoolClass _schoolClass, ExamPeriod _examPeriod, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (_student == null)
                throw new ArgumentNullException("Student");
            _Student = _student;

            if (_examPeriod == null)
                throw new ArgumentNullException("ExamPeriod");
            _ExamPeriod = _examPeriod;

            if (_schoolClass == null)
                throw new ArgumentNullException("SchoolClass is invalid");
            _SchoolClass = _schoolClass;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;
        }

        public StudentReportFormViewModel GetViewModel()
        {
            try
            {
                Build();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        public void Build()
        {
            try
            {
                _ViewModel = new StudentReportFormViewModel();
                dtDataPoints = new DataTable();
                _ViewModel.SchoolSlogan = slogan; 
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.ReportDate = DateTime.Now;
                _ViewModel.StudentId = _Student.Id;
                _ViewModel.StudentAdminNo = _Student.AdminNo;
                _ViewModel.StudentName = _Student.StudentSurName + ",  " + _Student.StudentOtherNames;
                var _classstreamquery = (from cs in db.ClassStreams
                                         join st in db.Students on cs.Id equals st.ClassStreamId
                                         select cs).FirstOrDefault();
                ClassStream csrm = _classstreamquery;
                _ViewModel.ClassStream = csrm.Description;
                _ViewModel.ClassName = _SchoolClass.ClassName;
                var _classteacherquery = (from tc in db.Teachers
                                          where tc.Id == _SchoolClass.TeacherId
                                          select tc).FirstOrDefault();
                Teacher teacher = _classteacherquery;
                _ViewModel.ClassTeacher = teacher.Name;
                _ViewModel.Year = _ExamPeriod.Year;
                _ViewModel.Term = _ExamPeriod.Term;
                _ViewModel.SchoolName = school.SchoolName;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2;
                _ViewModel.Term1MeanGrade = _Student.Term1MeanGrade;
                _ViewModel.Term2MeanGrade = _Student.Term2MeanGrade;
                _ViewModel.Term3MeanGrade = _Student.Term3MeanGrade;
                _ViewModel.KcpeMarks = double.Parse(_Student.KCPE);
                if (_Student.GLAccountId != null)
                {
                    int dracc = rep.GetStudentGLAccount(_Student.GLAccountId ?? -1);
                    if (dracc == -1) dracc = int.Parse(rep.SettingLookup("SUSPDR"));
                    _ViewModel.FeeBalance = rep.GetStudentGLAccountBookBalance(_Student.GLAccountId ?? dracc);
                }
                _ViewModel.StudentDTOExamResults = this.GetExamResults();
                string _mark = _ViewModel.AverageMarks.ToString("N0");
                double _Mrk = double.Parse(_mark);
                _ViewModel.CurrentMeanGrade = rep.GradeLookUp(_Mrk, gradingsys);
                _ViewModel._GradingDTO = this.GetGradingDTO();
                _ViewModel.NextTerm = this.GetStudentNextTerm();
                _ViewModel.CurrentYear = DateTime.Now.Year;
                _ViewModel.FeeStructureAcademics = this.GetFeeStructureAcademics();
                _ViewModel.FeeStructureOthers = this.GetFeeStructureOthers();
                _ViewModel.chart = this.BuildChart();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<StudentReportFormDTO> GetExamResults()
        {
            try
            {
                List<StudentReportFormDTO> lstdto = new List<StudentReportFormDTO>();

                var data = from ser in db.StudentsExamResults_Temp
                           join sd in db.Students on ser.StudentId equals sd.Id
                           join st in db.StudentExams on sd.Id equals st.StudentId
                           join rg in db.RegisteredExams on st.RegdExamId equals rg.Id
                           join em in db.Exams on rg.ExamId equals em.Id
                           join et in db.ExamTypes on rg.ExamTypeId equals et.Id
                           join sj in db.Subjects on em.SubjectShortCode equals sj.ShortCode
                           join ep in db.ExamPeriods on em.ExamPeriodId equals ep.Id
                           join sc in db.SchoolClasses on em.ClassId equals sc.Id
                           where ep.Id == _ExamPeriod.Id
                           where sc.Id == _SchoolClass.Id
                           where st.StudentId == _Student.Id
                           select new SubjectExamResult
                           {
                               StudentId =sd.Id,
                               SubjectCode = sj.ShortCode,
                               ExamTypeShortCode = et.ShortCode,
                               Mark = st.Mark ?? 0,
                               OutOf=rg.OutOf,
                               ExamperriodId=ep.Id,
                               SchoolClassId=sc.Id
                           };

                var lst = data.ToList();
                foreach (var item in lst)
                {
                    item.Point = rep.PointLookUp(item.Mark, gradingsys);
                    item.Grade = rep.GradeLookUp(item.Mark, gradingsys);
                }

                /*get all possible _examTypesquery into a separate group*/
                var examtypesquery = (from d in lst
                                      where d.StudentId == _Student.Id
                                      where d.ExamperriodId == _ExamPeriod.Id
                                      where d.SchoolClassId==_SchoolClass.Id
                                      group d by new
                                      {
                                          d.ExamTypeShortCode,
                                          d.OutOf
                                      }
                                          into grp
                                      select new ExamTypeDTO
                                      {                                          
                                            ShortCode=grp.Key.ExamTypeShortCode,
                                            OutOf=grp.Key.OutOf
                                      })
                                .Distinct()
                                .ToList();
                _ViewModel._ExamTypes = examtypesquery;

                var subjectsquery = (from d in lst
                                     select d.SubjectCode)
                               .Distinct()
                               .ToList();
                var clssbjectsquery = (from cs in db.ClassSubjects
                                       join sb in db.Subjects on cs.SubjectCode equals sb.ShortCode
                                       where cs.ClassId == _SchoolClass.Id
                                       where cs.Status == "A"
                                       select cs.SubjectCode).Distinct().ToList();
                _ViewModel._Subjects = clssbjectsquery;

                foreach (var sub in _ViewModel._Subjects)
                {
                    StudentReportFormDTO strec = new StudentReportFormDTO();
                    strec.SubjectCode = sub;
                    strec.SubjectsExamResult = lst.Where(s => s.SubjectCode == sub).ToList();
                    strec.NoOfExamTypes = _ViewModel._ExamTypes.Count();
                    string _mark = strec.MeanMarks.ToString("N0");
                    double _Mrk = double.Parse(_mark);
                    strec.MeanGrade = rep.GradeLookUp(_Mrk, gradingsys);
                    strec.Remarks = rep.RemarkLookUp(_Mrk, gradingsys);

                    lstdto.Add(strec);
                }

                return lstdto;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private List<GradingDTO> GetGradingDTO()
        {
            try
            {
                List<GradingDTO> lstdto = new List<GradingDTO>();

                var data = from gs in db.GradingSystems
                           join gsd in db.GradingSystemDets on gs.Id equals gsd.GradingSystemId
                           where gs.Id == gradingsys
                           select new GradingDTO
                           {
                               Grade = gsd.Grade,
                               LowerMark = gsd.LMark,
                               UpperMark = gsd.UMark,
                               Point = gsd.Point ?? 0,
                               Remarks = gsd.Remarks
                           };

                var lst = data.ToList();

                foreach (var gs in lst)
                {
                    GradingDTO strec = new GradingDTO();
                    strec.Grade = gs.Grade;
                    strec.LowerMark = gs.LowerMark;
                    strec.UpperMark = gs.UpperMark;
                    strec.Point = gs.Point;
                    strec.Remarks = gs.Remarks;

                    lstdto.Add(strec);
                }

                return lstdto;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private int GetStudentNextTerm()
        {
            try
            {
                int currentmonth = DateTime.Now.Month;
                if (currentmonth >= 1 && currentmonth <= 4)
                {
                    _ViewModel.CurrentTerm = 1;
                    _ViewModel.NextTerm = 2;
                }
                else if (currentmonth >= 5 && currentmonth <= 8)
                {
                    _ViewModel.CurrentTerm = 2;
                    _ViewModel.NextTerm = 3;

                }
                else if (currentmonth >= 9 && currentmonth <= 12)
                {
                    _ViewModel.CurrentTerm = 3;
                    _ViewModel.NextTerm = 1;
                }
                return _ViewModel.NextTerm;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 1;
            }
        }
        private int GetStudentNextYear()
        {
            try
            {
                int currentyear = DateTime.Now.Year;
                if (currentyear >= 1 && currentyear <= 4)
                {
                    _ViewModel.CurrentTerm = 1;
                    _ViewModel.NextTerm = 2;
                }
                else if (currentyear >= 5 && currentyear <= 8)
                {
                    _ViewModel.CurrentTerm = 2;
                    _ViewModel.NextTerm = 3;

                }
                else if (currentyear >= 9 && currentyear <= 12)
                {
                    _ViewModel.CurrentTerm = 3;
                    _ViewModel.NextTerm = 1;
                }
                return _ViewModel.NextTerm;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 1;
            }
        }
        private List<FeeStructureAcademicDTO> GetFeeStructureAcademics()
        {
            try
            {
                List<FeeStructureAcademicDTO> lst = new List<FeeStructureAcademicDTO>();
                List<FeeStructureAcademicDTO> FeeStructureAcademics = new List<FeeStructureAcademicDTO>();

                var feeStructurequery = (from fs in db.FeesStructures
                                         where fs.Year == _ViewModel.CurrentYear
                                         select fs).FirstOrDefault();
                FeesStructure FeeStructure = feeStructurequery;

                var FeeStructureAcademicsquery = from fsa in db.FeeStructureAcademics
                                                 where fsa.SchoolClassId == _SchoolClass.Id
                                                 where fsa.Term == _ViewModel.NextTerm
                                                 where fsa.FeeStructureId == FeeStructure.Id
                                                 select new FeeStructureAcademicDTO
                                                 {
                                                     Description = fsa.Description,
                                                     Amount = fsa.Amount,
                                                     AmountPeriod = fsa.AmountPeriod
                                                 };
                FeeStructureAcademics = FeeStructureAcademicsquery.ToList();

                foreach (var fs in FeeStructureAcademicsquery.ToList())
                {
                    FeeStructureAcademicDTO fsd = new FeeStructureAcademicDTO();
                    fsd.Description = fs.Description;
                    fsd.Amount = fs.Amount;
                    fsd.AmountPeriod = fs.AmountPeriod;
                    lst.Add(fsd);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private List<FeeStructureOthersDTO> GetFeeStructureOthers()
        {
            try
            {
                List<FeeStructureOthersDTO> lst = new List<FeeStructureOthersDTO>();
                List<FeeStructureOthersDTO> FeeStructureOthers = new List<FeeStructureOthersDTO>();
                var feeStructurequery = (from fs in db.FeesStructures
                                         where fs.Year == _ViewModel.CurrentYear
                                         select fs).FirstOrDefault();
                FeesStructure FeeStructure = feeStructurequery;

                var FeeStructureOthersquery = from fso in db.FeeStructureOthers
                                              where fso.FeeStructureId == FeeStructure.Id
                                              select new FeeStructureOthersDTO
                                              {
                                                  Description = fso.Description,
                                                  Amount = fso.Amount,
                                                  AmountPeriod = fso.AmountPeriod,
                                                  ApplicableTo = fso.ApplicableTo
                                              };
                FeeStructureOthers = FeeStructureOthersquery.ToList();

                foreach (var fs in FeeStructureOthers)
                {
                    FeeStructureOthersDTO fsd = new FeeStructureOthersDTO();
                    fsd.Description = fs.Description;
                    fsd.Amount = fs.Amount;
                    fsd.AmountPeriod = fs.AmountPeriod;
                    fsd.ApplicableTo = fs.ApplicableTo;
                    lst.Add(fsd);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private Chart GenerateChart()
        {
            try
            {
                Chart chart = new Chart();
                WindowsCharting charting = new WindowsCharting();
                DataTable dt = new DataTable();

                var _studentquery = from st in db.Students
                                    where st.Id == _ViewModel.StudentId
                                    select st;
                Student _student = _studentquery.FirstOrDefault();

                var _schoolquery = from sc in db.Schools
                                   where sc.Id == _student.SchoolId
                                   select sc;
                School _school = _schoolquery.FirstOrDefault();

                var _gradesquery = from gsd in db.GradingSystemDets
                                   join gs in db.GradingSystems on gsd.GradingSystemId equals gs.Id
                                   where _school.GradingSystem == gs.Id
                                   select gsd;
                List<GradingSystemDet> _gradingsystemdetails = _gradesquery.ToList();

                var _termsquery = (from ep in db.ExamPeriods
                                   select ep.Term).Distinct().ToList();
                List<int> _terms = _termsquery;

                var _progressresultsquery = from pr in db.StudentProgresses_Temp
                                            where _terms.Contains(pr.Term)
                                            where pr.StudentId == _ViewModel.StudentId
                                            group pr by new
                                 {
                                     StudentId = pr.StudentId,
                                     ExamId = pr.ExamId,
                                     SchoolClassId = pr.SchoolClassId,
                                     Year = pr.Year,
                                     Term = pr.Term,
                                     ClassShortCode = pr.ClassShortCode,
                                     SubjectShortCode = pr.SubjectShortCode,
                                     TeacherId = pr.TeacherId,
                                     TotalMarks = pr.TotalMarks,
                                     TotalPoints = pr.TotalPoints,
                                     Position = pr.Position,
                                     MeanMarks = pr.MeanMarks,
                                     MeanGrade = pr.MeanGrade,
                                     ClassTeacherRemark = pr.ClassTeacherRemark,
                                     HeadTeacherRemark = pr.HeadTeacherRemark,
                                     IsDeleted = pr.IsDeleted
                                 }
                                                into grp
                                                select new StudentProgresses_TempDTO
                                                       {
                                                           StudentId = grp.Key.StudentId,
                                                           ExamId = grp.Key.ExamId,
                                                           SchoolClassId = grp.Key.SchoolClassId,
                                                           Year = grp.Key.Year,
                                                           Term = grp.Key.Term,
                                                           ClassShortCode = grp.Key.ClassShortCode,
                                                           SubjectShortCode = grp.Key.SubjectShortCode,
                                                           TeacherId = grp.Key.TeacherId,
                                                           TotalMarks = grp.Key.TotalMarks,
                                                           TotalPoints = grp.Key.TotalPoints,
                                                           Position = grp.Key.Position,
                                                           MeanMarks = grp.Key.MeanMarks,
                                                           MeanGrade = grp.Key.MeanGrade,
                                                           ClassTeacherRemark = grp.Key.ClassTeacherRemark,
                                                           HeadTeacherRemark = grp.Key.HeadTeacherRemark,
                                                           IsDeleted = grp.Key.IsDeleted
                                                       };
                List<StudentProgresses_TempDTO> _progressresults = _progressresultsquery.ToList();

                var _classResultsquery = from d in _progressresultsquery
                                         group d by new
                                         {
                                             d.StudentId
                                         }
                                             into grp
                                             select new
                                             {
                                                 StudentId = grp.Key.StudentId,
                                                 Marks = grp.GroupBy(f => f.SubjectShortCode)
                                                 .Select(m => new
                                                 {
                                                     Title = m.Key,
                                                     Sum = m.Sum(c => c.TotalMarks)
                                                 }),
                                                 _Marks = (from d in grp
                                                           group d by d.SubjectShortCode into grp2
                                                           select new ProcessMarksDTO
                                                           {
                                                               TotalMarks = grp2.Sum(c => c.TotalMarks * grp2.Count()),
                                                               Contribution = grp2.Sum(d => grp2.Count())
                                                           }).ToList(),
                                                 _SubjectShortCode = (from d in grp
                                                                      group d by d.SubjectShortCode into grp2
                                                                      select new ProcessSubjectDTO
                                                                      {
                                                                          _SubjectShortCode = grp2.Key
                                                                      }).ToList(),
                                                 _ExamTypeShortCode = (from d in grp
                                                                       group d by d.SubjectShortCode into grp2
                                                                       select new ProcessExamTypeDTO
                                                                       {
                                                                           _ExamTypeShortCode = grp2.Key
                                                                       }).ToList(),
                                                 _ProcessExaminations = (from g in grp
                                                                         select new ProcessExaminationDTO
                                                                         {
                                                                             _Term = g.Term,
                                                                             _ClassShortCode = g.ClassShortCode,
                                                                             _Year = g.Year,
                                                                             Examid = g.ExamId,
                                                                             IsDeleted = g.IsDeleted.ToString(),
                                                                             MeanMarks = g.MeanMarks ?? 0,
                                                                             MeanGrade = g.MeanGrade,
                                                                             Position = g.Position,
                                                                             SchoolClassId = g.SchoolClassId,
                                                                             StudentId = g.StudentId,
                                                                             SubjectShortCode = g.SubjectShortCode,
                                                                             TotalMarks = g.TotalMarks,
                                                                             TotalPoints = g.TotalPoints ?? 0
                                                                         }).ToList()
                                             };
                //var _classResults = _classResultsquery.ToList();
                 
                dt.Columns.Add("", typeof(int));
                foreach (var t in _terms)
                {  
                    foreach (var item in _progressresults.Where(i => i.Term == t))
                    {
                        dt.Rows.Add(item.TotalPoints);
                    }
                }
                //int _rowid = 1;
                //foreach (var item in _progressresults)
                //{
                //    dt.Rows.Add( item.Term, item.TotalPoints);
                //    _rowid++;
                //}
                chart = charting.GenerateChart(dt, 1500, 300, System.Drawing.Color.Red.ToString(), 1);
                chart.ChartAreas[0].Area3DStyle.Enable3D = true;
                return chart;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private Byte[] BuildChart()
        {
            try
            {
                var chart = GenerateChart();

                using (var chartimage = new MemoryStream())
                {
                    chart.SaveImage(chartimage, ChartImageFormat.Jpeg);
                    return chartimage.GetBuffer();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }













































    }
}