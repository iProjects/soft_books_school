using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{
   public class ClassListViewModel
    {
        public DateTime printedon { get; set; }
        public DateTime ReportDate { get; set; }
        public string SchoolLogo { get; set; }
        public string SchoolSlogan { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string Programme { get; set; } 
        public string ReportName
        {
            get
            {
                return "Classes List\n";
            }
        }
        public List<SchoolClassesDTO> _ClassesList { get; set; }
    }

   public class SchoolClassesDTO
   {
       public string ShortCode { get; set; }
       public string ClassName { get; set; }
       public int ProgrammeYearId { get; set; }
       public int NoOfSubjects { get; set; }
       public int? ClassTeacher { get; set; }
       public int? NoofStudents { get; set; }
   }
}
