using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using DAL;
using WinSBSchool.Infrastructure;
using WinSBSchool.Reports.ViewModels;
using System.Windows.Forms; 

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class ExamResultsByExamTypeViewModelBuilder
     {
          ExamResultsByExamTypeViewModel _ViewModel;
          SchoolClass _SchoolClass;
          School school;
          string connection;
          SBSchoolDBEntities db;
          Repository rep;
          bool error = false;
          int gradingsys;
          ExamType _ExamType;
          ExamPeriod _ExamPeriod;
          RegisteredExam _RegisteredExam;
          string fileLogo;
          string slogan;

          public ExamResultsByExamTypeViewModelBuilder(School _school, RegisteredExam registeredExam, ExamPeriod examPeriod, SchoolClass schoolClass, ExamType examType, string Conn)
        {

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (registeredExam == null)
                throw new ArgumentNullException("Registered Exam is invalid");
            _RegisteredExam = registeredExam;

            if (examPeriod == null)
                throw new ArgumentNullException("Exam Period is invalid");
            _ExamPeriod = examPeriod;

            if (examType == null)
                throw new ArgumentNullException("ExamType is invalid");
            _ExamType = examType;

            if (schoolClass == null)
                throw new ArgumentNullException("SchoolClass is invalid");
            _SchoolClass = schoolClass;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;
        }
        public ExamResultsByExamTypeViewModel GetModelBuilder()
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
            try
            {
                _ViewModel = new ExamResultsByExamTypeViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.ClassName = _SchoolClass.ClassName;
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolName = school.SchoolName;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel.Year = _ExamPeriod.Year;
                _ViewModel.Term = _ExamPeriod.Term;
                _ViewModel.ExamDate = _RegisteredExam.ExamDate;
                _ViewModel.ExamTypeShortcode = _ExamType.ShortCode;
                _ViewModel.ExamResults = this.GetExamResults();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<ExamResultsByExamTypeDTO> GetExamResults()
        {
            try
            {

                List<ExamResultsByExamTypeDTO> lstdto = new List<ExamResultsByExamTypeDTO>();

                var data = from se in db.StudentExams
                           join rg in db.RegisteredExams on se.RegdExamId equals rg.Id
                           join exm in db.Exams on rg.ExamId equals exm.Id
                           join et in db.ExamTypes on rg.ExamTypeId equals et.Id
                           join sj in db.Subjects on exm.SubjectShortCode equals sj.ShortCode
                           join st in db.Students on se.StudentId equals st.Id
                           where exm.ExamPeriodId == _ExamPeriod.Id
                           where exm.ClassId == _SchoolClass.Id 
                           where et.Id == _ExamType.Id
                           select new ExamTypeResult
                           {
                               StudentId = st.Id,                                
                               StudentAdminNo = st.AdminNo,
                               StudentName = st.StudentSurName + ", " + st.StudentOtherNames,
                               SubjectCode = sj.ShortCode,
                               ExamType = et.ShortCode,
                               Mark = se.Mark ?? 0
                           };

                var lst = data.ToList();
                foreach (var item in lst)
                {
                    item.Point = rep.PointLookUp(item.Mark, gradingsys);
                    item.Grade = rep.GradeLookUp(item.Mark, gradingsys);
                }

                /*get all possible _examTypesquery into a separate group*/
                var studentsquery = (from d in lst
                                      select d.StudentId)
                                .Distinct()
                                .ToList();
                _ViewModel._Students = studentsquery;

                var subjectsquery = (from d in lst
                                     orderby d.SubjectCode ascending
                                     select d.SubjectCode)
                               .Distinct()
                               .ToList();
                var clssbjectsquery = (from cs in db.ClassSubjects
                                       join sb in db.Subjects on cs.SubjectCode equals sb.ShortCode
                                       where cs.ClassId == _SchoolClass.Id
                                       where cs.Status == "A"
                                       select cs.SubjectCode).Distinct().ToList();
                _ViewModel._Subjects = clssbjectsquery;


                foreach (var stid in _ViewModel._Students)
                {
                    ExamResultsByExamTypeDTO strec = new ExamResultsByExamTypeDTO();
                    strec.StudentId = stid; 
                    strec.StudentExamResults = lst.Where(s => s.StudentId == stid).ToList();
                    strec.NoOfSubjects = _ViewModel._Subjects.Count();
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





     }
}