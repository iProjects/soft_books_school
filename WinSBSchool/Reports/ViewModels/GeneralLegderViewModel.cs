using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{

   public class GeneralLegderViewModel
    {

        public string ReportName
        { 
            get
            { 
                return "General Ledger"; 
            }
        }
        public string Logo { get; set; }
        public string CompanySlogan { get; set; }
        public DateTime ReportDate { get; set; }
        public DateTime StartDate { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; } 
        public DateTime EndDate { get; set; }
        public List<AccountGroup> AccountGroups { get; set; }
        public decimal TotalDebits
        {

            get
            {

                return this.AccountGroups.Sum(ag => ag.Debits);

            }

        }

        public Decimal TotalCredits
        {
            get
            {

                return this.AccountGroups.Sum(ag => ag.Credits);

            }
        }
    }



    public class AccountGroup
    {

        public string Description { get; set; }
        public List<DAL.Account> Accounts { get; set; }
        public decimal Debits
        {

            get
            {

                return Accounts.Where(a => a.BookBalance < 0).Sum(a => a.BookBalance);

            }

        }

        public decimal Credits
        {

            get
            {

                return Accounts.Where(a => a.BookBalance > 0).Sum(a => a.BookBalance);

            }

        }

    }

}

