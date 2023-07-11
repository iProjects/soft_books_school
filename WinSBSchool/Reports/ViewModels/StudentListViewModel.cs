using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{
   public class StudentListViewModel
   {
       public DateTime printedon { get; set; }
       public DateTime ReportDate { get; set; }
       public string SchoolLogo { get; set; }
       public string SchoolSlogan { get; set; }
       public string SchoolName { get; set; }
       public string SchoolAddress { get; set; } 
       public string ClassName { get; set; }
       public string ReportName
       {
           get
           {
               return "Students List\n";
           }
       }
       public List<StudentsListDTO> _StudentsDTO { get; set; }
   }

   public class StudentsListDTO
   {
       public string StudentName { get; set; }
       public string AdmissionNo { get; set; }
       public string Gender { get; set; }
       public DateTime DOB { get; set; }
       public string Phone { get; set; }
       public string Stream { get; set; }
       public string KCPEMark { get; set; }
       public string ParentName { get; set; }
       public string ParentPhoneno { get; set; }
       public DateTime AdmissionDate { get; set; }
   }
}
