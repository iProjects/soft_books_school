using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{
    public class FeeStructureByClassViewModel
    {
        public DateTime printedon { get; set; }
        public DateTime ReportDate { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolLogo { get; set; }
        public string SchoolSlogan { get; set; }
        public string SchoolName { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int year { get; set; }
        public int Term { get; set; }
        public string ReportName
        {
            get
            {
                return "Fee Structure For Academic Year:  " + year.ToString() + "\n" + "Term: " +  Term.ToString();
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
        public decimal TotalFees
        {
            get
            {
                return TotalAcademicFees + TotalOtherFees;
            }
        }


    }

    public class FeeStructureAcademicDTO
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string AmountPeriod { get; set; }

    }
    public class FeeStructureOthersDTO
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string AmountPeriod { get; set; }
        public string ApplicableTo { get; set; }
    }



}