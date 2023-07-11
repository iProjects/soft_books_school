using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace WinSBSchool.Reports.ViewModels
{
   public class PrimaryMarksheetViewModel
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
                return "Primary Mark Sheet\n";
            }
        }

        public List<SecStudentMarkSheetRecord> ExamResults { get; set; }
        
    }
   public class PriStudentMarkSheetRecord
   {
       public Student Student;
       public int NoOfSubjects { get; set; }
       public string MeanGrade { get; set; }
       public int Rank { get; set; }
       public List<SubjectExamResult> SubjectsExamResult { get; set; }


       public double? TotalMarks
       {
           get
           {
               return this.SubjectsExamResult
                   .Select(t => t.Mark).Sum();
           }
       }
       public double? MeanMarks
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
               return this.SubjectsExamResult
                   .Select(t => t.Mark).Average();
           }
       }
       public double? TotalPoints
       {
           get
           {
               return this.SubjectsExamResult
                   .Select(t => t.Point).Sum();
           }
       }
       public double? AveragePoints
       {
           get
           {
               return this.SubjectsExamResult
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
