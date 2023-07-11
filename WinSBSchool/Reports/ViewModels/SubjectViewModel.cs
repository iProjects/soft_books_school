using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace WinSBSchool.Reports.ViewModels
{
   public class SubjectViewModel
    {
       public SubjectViewModel() { }
       public DateTime printedon { get; set; }
       public DateTime ReportDate { get; set; }
       public string SchoolAddress { get; set; } 
       public string SchoolLogo { get; set; }
       public string SchoolSlogan { get; set; }
       public string ReportName
       {
           get
           {
               return "Subjects List\n"  ;
           }
       }
       public string SchoolName { get; set; }
       public string ProgrammeId { get; set; }
        public List<SchoolSubjectlist> ListofSubjects { get; set; } 
    }

   public class ScSubject
   {
       public string ShortCode { get; set; }
       public string Description { get; set; }
       public int OutOf { get; set; }
       public int PassMark { get; set; }
       public string Status { get; set; }
       public int ROrder { get; set; }
       public string Remarks { get; set; }
   }
   public class SchoolSubjectlist
   {
       public SchoolSubjectlist() { }
       public List<ScSubject> SubjectList { get; set; }


   }
}

