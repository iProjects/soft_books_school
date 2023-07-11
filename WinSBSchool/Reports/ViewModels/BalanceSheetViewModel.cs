using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{
    public class BalanceSheetViewModel
    {
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public string SchoolLogo { get; set; }
        public string SchoolSlogan { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportName
        {
            get
            {
                return "Balance Sheet";
            }
        }
        public List<BalanceSheetDTO> _BalanceSheets { get; set; }
        public List<int> ParentIds { get; set; }
        public decimal TotalY1
        {
            get
            {
                return this._BalanceSheets.Sum(e => e.TotalY1);
            }
        }
        public decimal TotalY2
        {
            get
            {
                return this._BalanceSheets.Sum(e => e.TotalY2);
            }
        }
    }
    public class BalanceSheetDTO
    {
        public int GroupId { get; set; }
        public string Descripion { get; set; }       
        public List<BalanceSheetLevel2> Level2BalanceSheets { get; set; }
        public decimal TotalY1
        {
            get
            {
                return this.Level2BalanceSheets.Sum(e => e.Yr1Amount);
            }
        }
        public decimal TotalY2
        {
            get
            {
                return this.Level2BalanceSheets.Sum(e => e.Yr2Amount);
            }
        }
    }

    public class BalanceSheetLevel2
    {
        public int ParentId { get; set; }
        public string Description { get; set; }
        public string AccountField { get; set; }
        public string Criteria { get; set; }
        public decimal Yr1Amount { get; set; }
        public decimal Yr2Amount { get; set; }
        public int ROrder { get; set; }
    }

}