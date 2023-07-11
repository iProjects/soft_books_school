using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

namespace WinSBSchool.Reports.ViewModels
{
   public class TransactionViewModel
    {
       public TransactionViewModel() { }
        public List<SchoolTransactionlist> ListofTransactions { get; set; }
        public DateTime printedon { get; set; }
        public string SchoolAddress { get; set; } 
        public DateTime ReportDate { get; set; }
        public string ProgrammeId { get; set; }
        public string SchoolLogo { get; set; }
        public string ReportName
        {
            get
            {
                return "Transactions\n"  ;
            }
        }
        public string SchoolSlogan { get; set; }
        public string SchoolName { get; set; } 
    }

   public class STransaction
   {
       public string TransactionTypeID { get; set; }
       public string AccountID { get; set; }
       public decimal Amount { get; set; }
       public string Narrative { get; set; }
       public string UserID { get; set; }
       public string Authorizer { get; set; }
       public string StatementFlag { get; set; }
       public DateTime PostDate { get; set; }
       public DateTime ValueDate { get; set; }
       public DateTime RecordDate { get; set; }
   }

   public class SchoolTransactionlist
   {
       public SchoolTransactionlist() { }
       public List<STransaction> TransactionList { get; set; }


   }
}
