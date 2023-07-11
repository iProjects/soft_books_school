using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonLib;
using DAL;
using WinSBSchool.Reports.ViewModels;
using System.Windows.Forms;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class StudentProgressFormViewModelBuilder
    {
        StudentProgressFormViewModel _ViewModel;
        SchoolClass _SchoolClass;
        ExamPeriod _ExamPeriod;
        School school;
        string connection;
        Student _Student;
        int gradingsys;
        SBSchoolDBEntities db;
        Repository rep;
        bool error = false;
        string fileLogo;
        string slogan;

        public StudentProgressFormViewModelBuilder(School _school, Student _student, SchoolClass _schoolClass, ExamPeriod _examPeriod, string Conn)
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
        public StudentProgressFormViewModel GetViewModel()
        {
            try
            {
                if (!error)
                    Build();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void Build()
        {
            _ViewModel = new StudentProgressFormViewModel();
            _ViewModel.SchoolSlogan = slogan;
            _ViewModel.SchoolLogo = fileLogo;
            _ViewModel.ReportDate = DateTime.Now;
            _ViewModel.StudentAdminNo = _Student.AdminNo;
            _ViewModel.StudentName = _Student.StudentSurName + ",  " + _Student.StudentOtherNames;
            var _classstreamquery = (from cs in db.ClassStreams
                                     join st in db.Students on cs.Id equals st.ClassStreamId
                                     select cs).FirstOrDefault();
            ClassStream csrm = _classstreamquery;
            _ViewModel.ClassStream = csrm.Description;
            _ViewModel.ClassName = _SchoolClass.ClassName;
            _ViewModel.Year = _ExamPeriod.Year;
            _ViewModel.Term = _ExamPeriod.Term;
            _ViewModel.SchoolName = school.SchoolName;
            _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2;
            _ViewModel.Term1MeanGrade = _Student.Term1MeanGrade;
            _ViewModel.Term2MeanGrade = _Student.Term2MeanGrade;
            _ViewModel.Term3MeanGrade = _Student.Term3MeanGrade;
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
        }
        private List<StudentProgressFormDTO> GetExamResults()
        {
            try
            {
                List<StudentProgressFormDTO> lstdto = new List<StudentProgressFormDTO>();

                var data = from ser in db.StudentsExamResults_Temp
                           join sd in db.Students on ser.StudentId equals sd.Id
                           join st in db.StudentExams on sd.Id equals st.StudentId
                           join rg in db.RegisteredExams on st.RegdExamId equals rg.Id
                           join em in db.Exams on rg.ExamId equals em.Id
                           join et in db.ExamTypes on rg.ExamTypeId equals et.Id
                           join sj in db.Subjects on em.SubjectShortCode equals sj.ShortCode
                           where em.ExamPeriodId == _ExamPeriod.Id
                           where em.ClassId == _SchoolClass.Id
                           where st.StudentId == _Student.Id
                           select new SubjectExamResult
                           {
                               SubjectCode = sj.ShortCode,
                               ExamTypeShortCode = et.ShortCode,
                               Mark = st.Mark ?? 0
                           };

                var lst = data.ToList();
                foreach (var item in lst)
                {
                    item.Point = rep.PointLookUp(item.Mark, gradingsys);
                    item.Grade = rep.GradeLookUp(item.Mark, gradingsys);
                }

                /*get all possible _examTypesquery into a separate group*/
                var examtypesquery = (from d in lst
                                      select d.ExamTypeShortCode)
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
                    StudentProgressFormDTO strec = new StudentProgressFormDTO();
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
        private List<StudentProgressFormDTO> GetStudentProgress()
        {
            try
            {
                List<StudentProgressFormDTO> lstdto = new List<StudentProgressFormDTO>();

                var data = from ser in db.StudentProgresses_Temp
                           join sd in db.Students on ser.StudentId equals sd.Id
                           join st in db.StudentExams on sd.Id equals st.StudentId
                           join rg in db.RegisteredExams on st.RegdExamId equals rg.Id
                           join em in db.Exams on rg.ExamId equals em.Id
                           join et in db.ExamTypes on rg.ExamTypeId equals et.Id
                           join sj in db.Subjects on em.SubjectShortCode equals sj.ShortCode
                           where em.ExamPeriodId == _ExamPeriod.Id
                           where em.ClassId == _SchoolClass.Id
                           where st.StudentId == _Student.Id
                           select new SubjectExamResult
                           {
                               SubjectCode = sj.ShortCode,
                               ExamTypeShortCode = et.ShortCode,
                               Mark = st.Mark ?? 0
                           };

                var lst = data.ToList();
                foreach (var item in lst)
                {
                    item.Point = rep.PointLookUp(item.Mark, gradingsys);
                    item.Grade = rep.GradeLookUp(item.Mark, gradingsys);
                }

                /*get all possible _examTypesquery into a separate group*/
                var examtypesquery = (from d in lst
                                      select d.ExamTypeShortCode)
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
                    StudentProgressFormDTO strec = new StudentProgressFormDTO();
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
        













    }
}