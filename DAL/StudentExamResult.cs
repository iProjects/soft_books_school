using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class StudentExamResult
    {
        public int StudentId { get; set; }
        public string StudentAdminNo { get; set; }
        public string ExamType { get; set; }
        public string StudentName { get; set; }
        public string SubjectCode { get; set; }
        public double? OutOf { get; set; }
        public double? Point { get; set; }
        public bool ContributionFlag { get; set; }
        public double? Contribution { get; set; }
        public double? Mark { get; set; }
        public string Grade { get; set; }

    }
    public class SubjectExamResult
    {
        public int StudentId { get; set; }
        public string AdminNo { get; set; }
        public string StudentSurName { get; set; }
        public string StudentOtherNames { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double Mark { get; set; }
        public int ExamperriodId { get; set; }
        public int SchoolClassId { get; set; }
        public string ExamTypeShortCode { get; set; }
        public double? OutOf { get; set; }
        public double? Point { get; set; }
        public bool ContributionFlag { get; set; }
        public double? Contribution { get; set; }
        public string Grade { get; set; }
        public string Remarks { get; set; }
    }   
    public class ClassExamResult
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentAdminNo { get; set; }
        public string SubjectCode { get; set; }
        public string ExamType { get; set; }
        public int Rank { get; set; }
        public bool ContributionFlag { get; set; }
        public double? Contribution { get; set; }
        public double?  Mark { get; set; }
        public IQueryable<double?> Marks { get; set; }  
        public double? Point { get; set; }
        public string Grade { get; set; }
        public int NoOfExamTypes { get; set; }
        public List<ClassSubjectsExamTypes> _ExamTypesinResults { get; set; }
        public double TotalMarks
        {
            get
            {
                var res = _ExamTypesinResults.Select(t => t.Mark);
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
                return this.TotalMarks / this.NoOfExamTypes;
            }
        }
    }
    public class SubjectResult
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentAdminNo { get; set; }
        public string ExamType { get; set; } 
        public string SubjectCode { get; set; }
        public bool ContributionFlag { get; set; }
        public double? Mark { get; set; }
        public double? Contribution { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
    }
    public class ExamTypeResult
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentAdminNo { get; set; }
        public string SubjectCode { get; set; }
        public bool ContributionFlag { get; set; }
        public double Mark { get; set; }
        public string ExamType { get; set; } 
        public double? Contribution { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
    }   
    public class ReportFormResults
    { 
        public string SubjectCode { get; set; }
        public string ExamType { get; set; }
        public double? Mark { get; set; } 
        public double? Point { get; set; }
        public string Grade { get; set; }
    }
    public class UniSubjectExamResult
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double? Mark { get; set; }
        public double? OutOf { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
    }
    public class ClsSubjectExamResult
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double? Mark { get; set; }
        public double? OutOf { get; set; }
        public IEnumerable<MarksDTO> Marks { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
        public double TotalMarks
        {
            get
            {
                var res = Marks.Select(t => t.Mark ?? 0);
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
    }
    public class TchSubjectExamResult
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double? Mark { get; set; }
        public double? OutOf { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
    }
    public class StdSubjectExamResult
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double? Mark { get; set; }
        public double? OutOf { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
    }
    public class ClassSubjectsExamTypes
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentAdminNo { get; set; }
        public int Rank { get; set; }
        public string SubjectCode { get; set; }
        public string ExamType { get; set; }
        public bool ContributionFlag { get; set; }
        public double? Contribution { get; set; } 
        public double? Point { get; set; }
        public string Grade { get; set; }
        public int NoOfExamTypes { get; set; } 
        public string Description { get; set; } 
        public double Mark { get; set; }
        public IEnumerable<MarksDTO> Marks { get; set; }
        public double TotalMarks
        {
            get
            {
                var res = Marks.Select(t => t.Mark ?? 0);
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
                return this.TotalMarks / this.NoOfExamTypes;
            }
        }
    }
    public class MarksDTO
    { 
        public double? Mark { get; set; }
        public bool ContributionFlag { get; set; }
        public double? Contribution { get; set; } 
    }
    public class GradingDTO
    {
        public double LowerMark { get; set; }
        public double UpperMark { get; set; }
        public string Grade { get; set; }
        public double Point { get; set; }
        public string Remarks { get; set; }
    }
    public class ExamTypeDTO
    {
        public string ShortCode { get; set; } 
        public double? OutOf { get; set; }
    }
}