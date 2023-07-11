using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL; 


namespace WinSBSchool.Reports.ViewModels
{
   public class SchoolReportFormViewModel
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
               return "School Report Form\n" ;
           }
       }
   }
}