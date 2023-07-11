using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GL.DAL
{
    public class _Exams
    {
        #region Constructor

        public _Exams()
        {

        }

        #endregion


        public int Period { get; set; }
        public int Year { get; set; }
        public DateTime PayPeriod
        {
            get
            {
                return new DateTime(Year, Period, 1);
            }
        }

        public string PayrollMonth
        {
            get
            {
                return PayPeriod.ToString("MMMM");
            }
        }

        public string PayrollYear
        {
            get
            {
                return PayPeriod.ToString("yyyy");
            }
        }

        public DateTime PaymentDate { get; set; }

        public string PrintedBy { get; set; }

        public DateTime PrintedOn { get; set; }

        //emp info
        public string EmpName { get; set; }

        public string EmpNo { get; set; }

        public string Department { get; set; }

        public string NhifNo { get; set; }

        public string NssfNo { get; set; }

        public string PayPoint { get; set; } //HQ, etc

        public string PIN { get; set; }

        public string EmpGroup { get; set; } //PP,Temp

        public string EmpPayroll { get; set; } //Exec; surb



        //employer info
        public string CompName { get; set; }

        public string CompAddr { get; set; }

        public string CompTel { get; set; }

        //Payslip
        public decimal BasicPay { get; set; }

        //public List<NonCashBenefits> Benefits { get; set; }
        public decimal TotalBenefits
        {
            get;
            set;
        }

        public decimal Variables { get; set; }



        public decimal HourlyPay
        {
            get;
            set;
        }

        public decimal GrossTaxableEarnings { get; set; }


        public decimal MortgageRelief { get; set; }


        public decimal GrossTax { get; set; }

        public decimal PersonalRelief { get; set; }



        //PensionTotals
        public decimal PensionEmployer { get; set; }
        public decimal PensionEmployee { get; set; }
        public decimal NSSFEmployer { get; set; }

        //Payment
        public string BankBranch { get; set; }
        public string Account { get; set; }

    }
}