using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace WinSBSchool.Reports.ViewModels
{
    public class ClassStreamTimeTableViewModel
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
                return "Class Stream Time Table\n";
            }
        }
        public List<ClassStreamTimeTableListDTO> _TimeTableList { get; set; } 
    }

    public class ClassStreamTimeTableListDTO
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



        public string SubjectShortCode { get; set; }
        public int? RoomId { get; set; }
        public string Recurrent { get; set; }
        public string Activity { get; set; }
        public string Venue { get; set; }
        public string Text { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }

     
}