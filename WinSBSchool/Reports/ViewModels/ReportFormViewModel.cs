using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL; 

namespace WinSBSchool.Reports.ViewModels
{
    public class ReportFormViewModel
    {
        
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; } 
        public string ReportFormName { get; set; }
        public string Logo { get; set; }
        public string CompanySlogan { get; set; }
        public DateTime ReportDate { get; set; }
        public string StudentAdminNo { get; set; }
        public string ProgrammeId { get; set; }
        public string StudentName { get; set; }
        public string Class { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public string SubjectCode { get; set; }
        public string Description { get; set; }
        public int Mark { get; set; }
        public int OutOf { get; set; }
        public int Grade { get; set; }
        public string ReportName
        {
            get
            {
                return "Report Form\n"  ;
            }
        }
        public List<SubjectExamResult> StudentExamResults { get; set; }
        public double TotalMarks {
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
        public double AvgMarks
        {
            get
            {
                var res = StudentExamResults.Select(t => t.Mark);
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
        public string CurrentMeanGrade { get; set; }
        public string Term1MeanGrade { get; set; }
        public string Term2MeanGrade { get; set; }
        public string Term3MeanGrade { get; set; }
        public string Remarks { get; set; }
        public string Signed { get; set; }
    }


}