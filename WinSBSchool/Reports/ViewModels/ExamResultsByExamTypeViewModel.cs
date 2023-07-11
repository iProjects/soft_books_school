using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace WinSBSchool.Reports.ViewModels
{
    public class ExamResultsByExamTypeViewModel
    {
        public DateTime printedon { get; set; }
        public DateTime ReportDate { get; set; }
        public string SchoolLogo { get; set; }
        public string SchoolSlogan { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string ProgrammeId { get; set; }
        public string ClassName { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public string ExamTypeShortcode { get; set; }
        public DateTime? ExamDate { get; set; }
        public string ReportName
        {
            get
            {
                return "Exam Results By Exam Type\n";
            }
        }
        public List<ExamResultsByExamTypeDTO> ExamResults { get; set; }
        public List<int> _Students { get; set; }
        public List<string> _Subjects { get; set; }
        public List<string> _ExamTypes { get; set; }
    }


    public class ExamResultsByExamTypeDTO
    {
        public int StudentId { get; set; }
        public string ExamType { get; set; }
        public string SubjectCode { get; set; }
        public string StudentNames { get; set; }
        public double? Point { get; set; }
        public string MeanGrade { get; set; }
        public string Remarks { get; set; }
        public int Rank { get; set; }
        public double? Mark { get; set; }
        public string Grade { get; set; }
        public int NoOfSubjects { get; set; }
        public DAL.Subject Subject { get; set; }
        public List<ExamTypeResult> StudentExamResults { get; set; }
        public double TotalMarks
        {
            get
            {
                var res = StudentExamResults.Select(t => t.Mark);
                if (res.Count() > 0)
                {
                    return res.Sum();
                }
                else
                {
                    return 0;
                }
            }
        } 
        public double MeanMarks
        {
            get
            {
                return this.TotalMarks / this.NoOfSubjects;
            }
        }
        public double? AverageMarks
        {
            get
            {
                return this.StudentExamResults
                    .Select(t => t.Mark).Average();
            }
        }
        public double? TotalPoints
        {
            get
            {
                return this.StudentExamResults
                    .Select(t => t.Point).Sum();
            }
        }
        public double? AveragePoints
        {
            get
            {
                return this.StudentExamResults
                    .Select(t => t.Mark).Average();
            }
        }
        public double? MeanPoints
        {
            get
            {
                return this.TotalPoints / this.NoOfSubjects;
            }
        }
    }



}
