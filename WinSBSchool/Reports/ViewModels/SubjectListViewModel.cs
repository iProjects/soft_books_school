using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{
   public class SubjectListViewModel
   {
       public DateTime printedon { get; set; }
       public DateTime ReportDate { get; set; }
       public string SchoolLogo { get; set; }
       public string SchoolSlogan { get; set; }
       public string SchoolName { get; set; }
       public string SchoolAddress { get; set; } 
       public string ProgrammeId { get; set; }
       public string ClassName { get; set; }
       public string ReportName
       {
           get
           {
               return "Subjects List\n" ;
           }
       }
       public List<SubjectsListDTO> _ClassSubjectsList { get; set; }
   }

   public class SubjectsListDTO
   {
       public string ShortCode { get; set; }
       public string Description { get; set; }
       public int OutOf { get; set; }
       public int PassMark { get; set; }
       public int NoOfRequiredHours { get; set; }
       public decimal Fees { get; set; } 
   }
}
