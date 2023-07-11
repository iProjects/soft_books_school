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
   public class PrimaryMarksheetViewModelBuilder
    {
       Repository rep;
        SBSchoolDBEntities db;
        bool error = false;
        PrimaryMarksheetViewModel _ViewModel;
        RegisteredExam _RegisteredExam;
        DAL.SchoolClass _cls;
        DAL.School school;
        ExamPeriod _Examperiod;
        ExamType _ExamType; 
        string fileLogo;
        string slogan;
        string connection; 
        int gradingsys;

        public PrimaryMarksheetViewModelBuilder(School _school, RegisteredExam registeredExam, ExamPeriod examperiod, SchoolClass cls, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db=new SBSchoolDBEntities(connection);

            if (registeredExam == null)
                throw new ArgumentNullException("RegisteredExam is invalid");
            _RegisteredExam = registeredExam;

            var _Examtypequery = (from et in db.ExamTypes
                                 where et.Id == _RegisteredExam.ExamTypeId
                                 select et).FirstOrDefault();
            _ExamType = _Examtypequery;

            if (examperiod == null)
                throw new ArgumentNullException("Exam Period is invalid");
            _Examperiod = examperiod;

            if (cls == null)
                throw new ArgumentNullException("SchoolClass is invalid");
            _cls = cls;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;

        }
        public PrimaryMarksheetViewModel GetViewModel()
        {
            try
            {
                if (!error) Build();
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
                _ViewModel = new PrimaryMarksheetViewModel();

                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.ClassName = _cls.ClassName ; 
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel.SchoolName = school.SchoolName.Trim();
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
                _ViewModel.Year = _Examperiod.Year;
                _ViewModel.Term = _Examperiod.Term;
                _ViewModel.ExamDate = _Examperiod.StartDate;
                _ViewModel.ExamTypeShortcode = _ExamType.ShortCode;
                _ViewModel.ExamResults = this.GetStudentExamResults();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<SecStudentMarkSheetRecord> GetStudentExamResults()
        {

            //pass 1
            //get unranked list
            List<SubjectExamResult> SubjectsExamResult =
                rep.GetSecExamResultsBySubject(_Examperiod.Id, _ExamType.Id, _cls.Id, gradingsys);

            //pass 2
            //Rank the list
            List<SecStudentMarkSheetRecord> lst = RankstudentsMarksheet(SubjectsExamResult);

            return lst.OrderByDescending(i => i.MeanMarks).ThenByDescending(i => i.Rank).ToList();
        }
        private List<SecStudentMarkSheetRecord> RankstudentsMarksheet(List<SubjectExamResult> SubjectsExamResult)
        {
            List<SecStudentMarkSheetRecord> lst = new List<SecStudentMarkSheetRecord>();

            //Pass 1
            List<Student> classStudents = rep.GetClassStudents(_cls);
            foreach (Student student in classStudents)
            {
                SecStudentMarkSheetRecord strec = new SecStudentMarkSheetRecord();
                strec.NoOfSubjects = _cls.NoOfSubjects;
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



    }
}


