using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class RegisteredStudentDTO
    {
        public int ExamID { get; set; }
        public int StudentID { get; set; }

        public RegisteredStudentDTO(int examid, int studentid)
        {
            ExamID = examid;
            StudentID = studentid;
        }
    }

    public partial class AttendanceModel
    {
        public AttendanceModel()
        {
        }

        public string AdminNo { get; set; }
        public int ClassStreamId { get; set; }
        public int SchoolClassId { get; set; } 
        public bool Attended { get; set; } 
        public DateTime EndDateTime { get; set; }
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public string ReasonForNotAttending { get; set; }
        public DateTime StartDateTime { get; set; }
        public int StudentId { get; set; }
        public string SubjectShortCode { get; set; }
        public string SubjectDescription { get; set; }
        public string StudentName { get; set; }
        public string ClassName { get; set; }
        public string ClassStreamName { get; set; }

    }



}
