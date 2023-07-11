using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using DAL;
using WinSBSchool.Reports.ViewModels;
using System.IO;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class ReportFormViewModelBuilder
    {
        Repository rep; 
        ReportFormViewModel _ViewModel;
        SchoolClass _SchoolClass; 
        RegisteredExam _RegisteredExam;  
        List<SubjectExamResult> studentExams; 
        ExamPeriod _ExamPeriod;
        School school;
        ExamType _ExamType;
        string connection;
        Student _Student;
        int gradingsys;
        SBSchoolDBEntities db;
        string fileLogo;
        string slogan;

        public ReportFormViewModelBuilder(School _school, Student _student, SchoolClass _schoolClass, RegisteredExam _registeredExam, ExamPeriod _examPeriod, ExamType examType, string Conn)
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

            if (_registeredExam == null)
                throw new ArgumentNullException("RegisteredExam");
            _RegisteredExam = _registeredExam;

            if (examType == null)
                throw new ArgumentNullException("ExamType is invalid");
            _ExamType = examType;

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

        public ReportFormViewModel BuildReportFormViewModel()
        {
            _ViewModel = new ReportFormViewModel(); 
            _ViewModel.Logo = fileLogo; 
            _ViewModel.CompanySlogan = slogan;
            _ViewModel.SchoolName = school.SchoolName; 
            _ViewModel.ReportDate = DateTime.Now;
            _ViewModel.StudentAdminNo = _Student.AdminNo;
            _ViewModel.StudentName = _Student.StudentOtherNames;
            _ViewModel.Class = _Student.ClassStreamId.ToString();
            _ViewModel.Year = _ExamPeriod.Year;
            _ViewModel.Term = _ExamPeriod.Term;
            //_ViewModel.SubjectCode = _Student.AdminNo;
            _ViewModel.Description= _Student.StudentOtherNames;
            //_ViewModel.Mark = _Student.CurrentClass.ToString();
            //_ViewModel.OutOf = _AllowedRoleMenus.Year;
            _ViewModel.SchoolName = school.SchoolName ;
            _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
            _ViewModel.StudentExamResults = this.ComputeExamGrades();
            _ViewModel.CurrentMeanGrade = rep.GradeLookUp(_ViewModel.AvgMarks,gradingsys);
            _ViewModel.Term1MeanGrade = _Student.Term1MeanGrade;
            _ViewModel.Term2MeanGrade = _Student.Term2MeanGrade;
            _ViewModel.Term3MeanGrade = _Student.Term3MeanGrade;
            //_ViewModel.Remarks = subject.Remarks;

            return _ViewModel;
        }


        public List<SubjectExamResult> ComputeExamGrades()
        {
            foreach(var se in studentExams )
            {
                se.Grade = rep.GradeLookUp(se.Mark, this.gradingsys);
            }

            return studentExams;
        }
 }
}

