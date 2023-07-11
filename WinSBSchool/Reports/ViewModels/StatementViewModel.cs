using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{
    public class StatementViewModel
    {
        
        public string SchoolLogo { get; set; }
        public string SchoolSlogan { get; set; }
        public DateTime ReportDate {get; set; }
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
        public decimal Bal30 { get; set; }
        public decimal Bal60 { get; set; }
        public decimal Bal90 { get; set; }
        public decimal BalOver90 { get; set; }
        public decimal AmountDue { get; set; }
        public string ReportName 
        { 
            get 
            { 
                return "Account Statement";
            } 
        }
        public List<StatementTransaction> StatementTransactions { get; set; } 
        public decimal CurrentBalance
        {
            get
            {
                return this.StatementTransactions
                    .Select(t => t.Amount).Sum();
            }
        } 
        public decimal TotalDebits
        {
            get {
                return this.StatementTransactions
                    .Where(t=> t.Amount < 0)
                    .Select(t=>t.Amount).Sum();
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

    public class StatementTransaction
    {  
        public int Id { get; set; }
        public int TransactionTypeId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime RecordDate { get; set; }
        public DateTime? ValueDate { get; set; }
        public string Narrative { get; set; }
        public string StatementFlag { get; set; }
        public string Authorizer { get; set; }
        public string UserId { get; set; }
        public string TransRef { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal Balance { get; set; }  
    }
}