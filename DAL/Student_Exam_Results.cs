using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GL.DAL
{
    public class SubjectExamResult
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double? Mark { get; set; }
        public double? OutOf { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
    }
    public class Student_Exam_Results
    {
        public int StudentId { get; set; }
        public string StudentAdminNo { get; set; }
        public string StudentName { get; set; }
        public double? Mark { get; set; }
        public string Grade { get; set; }
    }
    public class PriSubjectExamResult
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double? Mark { get; set; }
        public double? OutOf { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
    }
    public class PSSubjectExamResult
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double? Mark { get; set; }
        public double? OutOf { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
    }
    public class CollSubjectExamResult
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double? Mark { get; set; }
        public double? OutOf { get; set; }
        public double? Point { get; set; }
        public string Grade { get; set; }
    }
    public class TerSubjectExamResult
    {
        public int StudentId { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public double? Mark { get; set; }
        public double? OutOf { get; set; }
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
}
