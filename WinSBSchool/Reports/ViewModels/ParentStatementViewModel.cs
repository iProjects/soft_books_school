using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{
   public class ParentStatementViewModel
    {
       public string ReportName
       {
           get
           {
               return "Parent Statement\n";
           }
       }
        public string Logo { get; set; }
        public string CompanySlogan { get; set; }
        public DateTime ReportDate { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerTelephone { get; set; }
        public string CustomerEmail { get; set; }
        public string BillToName { get; set; }
        public string BillToAddress { get; set; }
        public string BillToTelephone { get; set; }
        public string BillToEmail { get; set; }
        public List<StatementTransaction> StatementTransactions { get; set; }
        public decimal CurrentBalance
        {
            get
            {
                return this.StatementTransactions
                    .Select(t => t.Amount).Sum();
            }
        }
        public decimal Bal30 { get; set; }
        public decimal Bal60 { get; set; }
        public decimal Bal90 { get; set; }
        public decimal BalOver90 { get; set; }
        public decimal AmountDue { get; set; }
        public decimal TotalDebits
        {
            get
            {
                return this.StatementTransactions
                    .Where(t => t.Amount < 0)
                    .Select(t => t.Amount).Sum();
            }
        }
        public Decimal TotalCredits
        {
            get
            {
                return this.StatementTransactions
                    .Where(t => t.Amount > 0)
                    .Select(t => t.Amount).Sum();
            }
        }


    }
}