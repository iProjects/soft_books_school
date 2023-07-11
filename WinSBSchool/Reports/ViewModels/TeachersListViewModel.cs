using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace WinSBSchool.Reports.ViewModels
{
    public class TeachersListViewModel
    {
        public DateTime printedon { get; set; }
        public DateTime ReportDate { get; set; }
        public string SchoolLogo { get; set; }
        public string SchoolSlogan { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; } 
        public string ReportName
        {
            get
            {
                return "Teachers List\n";
            }
        }
        public List<TeachersListDTO> _TeachersList { get; set; } 
    }

    public class TeachersListDTO
    {
        public string TeacherName { get; set; }
        public string IDNo { get; set; }
        public string TSCNo { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Qualification { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateLeft { get; set; }
    }

     
}