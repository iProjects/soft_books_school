using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinSBSchool.Reports.ViewModels
{
    public class StudentReportFormViewModel
    {
        public Byte[] chart { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; } 
        public string SchoolLogo { get; set; }
        public string SchoolSlogan { get; set; }
        public DateTime ReportDate { get; set; }
        public int StudentId { get; set; }
        public string StudentAdminNo { get; set; }
        public string StudentName { get; set; }
        public double KcpeMarks { get; set; }
        public string ClassName { get; set; }
        public string ClassTeacher { get; set; }
        public string ClassStream { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public int CurrentTerm { get; set; }
        public int NextTerm { get; set; }
        public int CurrentYear { get; set; }
        public string ExamTypeShortcode { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public int Mark { get; set; }
        public int OutOf { get; set; }
        public int OutOfThisTerm { get; set; }
        public int OutOfLastTerm { get; set; }
        public int Grade { get; set; }
        public int PositionLastTerm { get; set; }
        public int PositionThisTerm { get; set; }
        public string CurrentMeanGrade { get; set; }
        public string Term1MeanGrade { get; set; }
        public string Term2MeanGrade { get; set; }
        public string Term3MeanGrade { get; set; }
        public decimal  FeeBalance { get; set; }
        public decimal NextTermFees { get; set; }
        public string Remarks { get; set; }
        public string Signed { get; set; }
        public string ReportName
        {
            get
            {
                return "Student Report Form\n";
            }
        }
        public List<StudentReportFormDTO> StudentDTOExamResults { get; set; }
        public List<GradingDTO> _GradingDTO { get; set; }
        //public List<string> _ExamTypes { get; set; }
        public List<ExamTypeDTO> _ExamTypes { get; set; }
        public List<string> _Subjects { get; set; }
        public double TotalMarks
        {
            get
            {
                var res = StudentDTOExamResults.Select(t => t.TotalMarks);
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
        public double AverageMarks
        {
            get
            {
                var res = StudentDTOExamResults.Select(t => t.MeanMarks);
                if (res.Count() > 0)
                {
                    double totalAvrg = res.Sum();
                    double Avrgmrk = totalAvrg / this._Subjects.Count();
                    return Avrgmrk;
                }
                else
                {
                    return 0;
                }
            }
        }
        public double AvgMarks
        {
            get
            {
                var res = StudentDTOExamResults.Select(t => t.TotalMarks);
                if (res.Count() > 0)
                {
                    return res.Average();
                }
                else
                {
                    return 0;
                }
            }
        }
        public List<FeeStructureAcademicDTO> FeeStructureAcademics { get; set; }
        public List<FeeStructureOthersDTO> FeeStructureOthers { get; set; }
        public decimal TotalAcademicFees
        {
            get
            {
                return this.FeeStructureAcademics
                    .Select(t => t.Amount).Sum();
            }
        }
        public decimal TotalOtherFees
        {
            get
            {
                return this.FeeStructureOthers
                    .Select(t => t.Amount).Sum();
            }
        }
        public decimal NextTermTotalFees
        {
            get
            {
                return TotalAcademicFees + TotalOtherFees;
            }
        }


    }



    public class StudentReportFormDTO
    {
        public string ExamType { get; set; }
        public string SubjectCode { get; set; }
        public double? Point { get; set; }
        public double? Mark { get; set; }
        public string MeanGrade { get; set; }
        public int Rank { get; set; }
        public int StudentId { get; set; }
        public string Grade { get; set; }
        public int NoOfExamTypes { get; set; }
        public string Remarks { get; set; }
        public List<SubjectExamResult> SubjectsExamResult { get; set; }
        public double TotalMarks
        {
            get
            {
                var res = SubjectsExamResult.Select(t => t.Mark);
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
                return this.TotalPoints / this.NoOfExamTypes;
            }
        }

    }




}