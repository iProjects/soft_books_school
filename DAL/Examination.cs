using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class Examination
    { 

        #region "Constructor"
        public Examination()
        {

        }
        #endregion "Constructor"  

        public int StudentId { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public string ClassShortCode { get; set; }
        public string ExamTypeShortCode { get; set; }
        public int TeacherId { get; set; }
        public float TotalMarks { get; set; }
        public float TotalPoints { get; set; }
        public int Position { get; set; }
        public float MeanMarks { get; set; }
        public string MeanGrade { get; set; }
        public string ClassTeacherRemark { get; set; }
        public string HeadTeacherRemark { get; set; }
        public string PrintedBy { get; set; }
        public DateTime PrintedOn { get; set; } 
    } 
    public class ProcessExamination
    {
        public string examTypeShortCode { get; set; } 
        public Student _Student { get; set; } 
        public int _Studentid { get; set; }
        public List<ProcessMarksDTO> _Marks { get; set; }
        public List<ProcessExaminationDTO> _ProcessExaminations { get; set; }
        public List<ProcessSubjectDTO> _SubjectShortCode { get; set; }
        public List<ProcessExamTypeDTO> _ExamTypeShortCode { get; set; }
        public int _Rank { get; set; }
    }
    public class ProcessMarksDTO
    {
        public double? TotalMarks { get; set; }
        public double? Contribution { get; set; }
        public double? MeanMarks { get { return TotalMarks / Contribution; } }
        public string MeanGrade { get; set; }       
    }
    public class ProcessSubjectDTO
    { 
        public string _SubjectShortCode { get; set; }  
    }
    public class ProcessExamTypeDTO
    {
        public string _ExamTypeShortCode { get; set; }
    }
    public class ProcessExaminationDTO
    {
        public int StudentId { get; set; }
        public string StudentSurName { get; set; }
        public string StudentOtherNames { get; set; }
        public string AdminNo { get; set; } 
        public string SubjectDescription { get; set; }
        public bool ContributionFlag { get; set; }
        public double? Contribution { get; set; } 
        public string _ExamTypeShortCode { get; set; }
        public string _ExamTypeDescription { get; set; }
        public string _Teacher { get; set; }
        public string _ClassStream { get; set; }
        public string _ClassShortCode { get; set; }
        public string _ClassName { get; set; } 
        public int Examid { get; set; }
        public string _Examperiod { get; set; }
        public int _Examperiodid { get; set; }
        public int _Term { get; set; }
        public int _Year { get; set; }
        public int SchoolClassId { get; set; }
        public int TeacherId { get; set; }
        public double TotalMarks_Target { get; set; }
        public double TotalPoints_Target { get; set; }
        public int? Position_Target { get; set; }
        public double MeanMarks_Target { get; set; }
        public string MeanGrade_Target { get; set; }
        public double? TotalMarks { get; set; }
        public double TotalPoints { get; set; }
        public int? Position { get; set; }
        public double MeanMarks { get; set; }
        public string MeanGrade { get; set; }
        public string ClassTeacherRemark { get; set; }
        public string HeadTeacherRemark { get; set; }
        public string Status { get; set; } 
        public int StudentsExamResults_TempId { get; set; }
        public string SubjectShortCode { get; set; }
        public double? Mark { get; set; }
        public string Grade { get; set; } 
        public double Mark_Target { get; set; }
        public string Grade_Target { get; set; }
        public string IsDeleted { get; set; } 

    }
    public class StudentProgresses_TempDTO
    {
        public int StudentId { get; set; }
        public int ExamId { get; set; }
        public int SchoolClassId { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public string ClassShortCode { get; set; }
        public string SubjectShortCode { get; set; }
        public int? TeacherId { get; set; }
        public double? TotalMarks { get; set; }
        public double? TotalPoints { get; set; }
        public int? Position { get; set; }
        public double? MeanMarks { get; set; }
        public string MeanGrade { get; set; }
        public string ClassTeacherRemark { get; set; }
        public string HeadTeacherRemark { get; set; }
        public bool? IsDeleted { get; set; }
    }










}
