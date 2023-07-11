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
    public class ExamResultsBySubjectViewModelBuilder
    {

        ExamResultsBySubjectViewModel _ViewModel;
        SchoolClass _SchoolClass;
        School school;
        string connection;
        SBSchoolDBEntities db;
        Repository rep;
        bool error = false;
        int gradingsys; 
        Subject _Subject;
        ExamPeriod _ExamPeriod; 
        string fileLogo;
        string slogan;

        public ExamResultsBySubjectViewModelBuilder(School _school, ExamPeriod examPeriod, SchoolClass schoolClass, Subject subject, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (subject == null)
                throw new ArgumentNullException("Subject is invalid");
            _Subject = subject;

            if (examPeriod == null)
                throw new ArgumentNullException("Exam Period is invalid");
            _ExamPeriod = examPeriod; 

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

        public ExamResultsBySubjectViewModel GetModelBuilder()
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
                _ViewModel = new ExamResultsBySubjectViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.ClassName = _SchoolClass.ClassName.Trim();
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolName = school.SchoolName.Trim();
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
                _ViewModel.SchoolSlogan = slogan.Trim();
                _ViewModel.Year = _ExamPeriod.Year;
                _ViewModel.Term = _ExamPeriod.Term;
                _ViewModel.ExamShortcode = _Subject.ShortCode;
                _ViewModel.ExamResults = this.GetExamResults();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<ExamResultsBySubjectDTO> GetExamResults()
        {
            try
            {
                List<ExamResultsBySubjectDTO> lstdto = new List<ExamResultsBySubjectDTO>();

                var data = from se in db.StudentExams
                           join rg in db.RegisteredExams on se.RegdExamId equals rg.Id
                           join exm in db.Exams on rg.ExamId equals exm.Id
                           join et in db.ExamTypes on rg.ExamTypeId equals et.Id
                           join sj in db.Subjects on exm.SubjectShortCode equals sj.ShortCode
                           join st in db.Students on se.StudentId equals st.Id
                           where exm.ExamPeriodId == _ExamPeriod.Id
                           where exm.ClassId == _SchoolClass.Id
                           where exm.SubjectShortCode == _Subject.ShortCode
                           select new SubjectExamResult
                           {
                               StudentId = st.Id,
                               SubjectCode = sj.ShortCode,
                               ExamTypeShortCode = et.ShortCode,
                               Mark = se.Mark ?? 0,
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

                var studentsquery = (from d in lst
                                     select d.StudentId)
                               .Distinct()
                               .ToList();
                _ViewModel._Students = studentsquery; 

                foreach (var stid in _ViewModel._Students)
                {
                    ExamResultsBySubjectDTO strec = new ExamResultsBySubjectDTO();
                    strec.StudentId = stid;
                    strec.StudentExamResults = lst.Where(s => s.StudentId == stid).ToList();
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
        

    }
}