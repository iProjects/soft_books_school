using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{

    public class ReportsEngineCompleteEventArg : System.EventArgs
    {
        private int svalue;
        private string _template;

        public ReportsEngineCompleteEventArg(int value, string template)
        {
            svalue = value;
            _template = template;
        }

        public int StatusValue
        {
            get { return svalue; }
        }

        public string _Template
        {
            get { return _template; }
        }
    }

    public class RegisteredExamDTO
    {
        public int Year { get; set; }
        public int Term { get; set; }
        public int ExamType { get; set; }
        public int ClassSubjectId { get; set; }
        public string Room { get; set; }
        public string Status { get; set; }
    }
}
