using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace WinSBSchool.Reports.ViewModels
{
    public class ProgrammeCourseListViewModel
    {
        public DateTime printedon { get; set; }
        public DateTime ReportDate { get; set; }
        public string SchoolLogo { get; set; }
        public string SchoolSlogan { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; } 
        public string ProgrammeDescription { get; set; }
        public string ClassName { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public string ReportName
        {
            get
            {
                return "Programme Courses List\n"  ;
            }
        }

        public List<ProgramCoursesDTO> Courses { get; set; } 
    }

    public class ProgramCoursesDTO
    {
        public YearTerm YearTerm { get; set; }
        public List<ProgrammeYearCours> ProgrammeYrCrs { get; set; }
    }



}
