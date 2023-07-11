using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{
   public class TeacherProgressFormViewModel
   {
       public DateTime printedon { get; set; }
       public DateTime ReportDate { get; set; }
       public string SchoolLogo { get; set; }
       public string SchoolSlogan { get; set; }
       public string SchoolName { get; set; }
       public string SchoolAddress { get; set; } 
       public string ProgrammeId { get; set; }
       public string ReportName
       {
           get
           {
               return "Teacher Progress Form\n"  ;
           }
       }
   }
}