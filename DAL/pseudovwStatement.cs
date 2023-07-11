using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class pseudovwStatement
    {
        #region "Public Properties"
        public DateTime date { get; set; }
        public string description { get; set; }
        public decimal amount { get; set; }
        public decimal balance { get; set; }
        #endregion "Public Properties"
    }

    public class pseudovwProgrammeCourses
    {
        #region "Public Properties"
        
        public string ProgrammeId { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public string CourseCode { get; set; }
        public string Description { get; set; }
        public int OutOf { get; set; }
        public int PassMark { get; set; }

        #endregion "Public Properties"
    }



    public class LocationNode
    {
        public string Key { get; set; }
        public string Table { get; set; }
        public object Item { get; set; }

        public LocationNode()
        {

        }
        public LocationNode(string key, string table, object payload)
        {
            this.Key = key;
            this.Table = table;
            this.Item = payload;
        }
    }
}
