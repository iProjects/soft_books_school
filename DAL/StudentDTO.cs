using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
   public class StudentDTO
    {
       public string Subjectcode { get; set; }
    }

   public class ChartDTO
   {
       public int Xaxis { get; set; }
       public double? Yaxis { get; set; }
   }


}
