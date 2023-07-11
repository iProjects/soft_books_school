using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class YearTerm
    {

            public int Year { get; set; }
            public List<int> Term { get; set; }
    }
    public class SubjectsResultsDTO
    {
        public int Year { get; set; }
        public int Term { get; set; }
        public DateTime ExamDate { get; set; }
        public string ExamType { get; set; }
    }
}
