using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class StudentDTO
    {
        public int GLAccountId { get; set; }  
        public decimal Amount { get; set; }
        public DateTime PostDate { get; set; } 
        public string Narrative { get; set; }
        public string StatementFlag { get; set; }
        public string Subjectcode { get; set; }
    }

    public class ChartDTO
    {
        public int Xaxis { get; set; }
        public double? Yaxis { get; set; }
    }


}
