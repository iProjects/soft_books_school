using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinSBSchool.Reports.ViewModels
{
    public class ProfitAndLossViewModel
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
                 return "Profit And Loss";
             }
         }
         public List<ProfitAndLossDTO> _ProfitAndLoss { get; set; }
         public List<int> ParentIds { get; set; }
         public decimal TotalY1
         {
             get
             {
                 return this._ProfitAndLoss.Sum(e => e.TotalY1);
             }
         }
         public decimal TotalY2
         {
             get
             {
                 return this._ProfitAndLoss.Sum(e => e.TotalY2);
             }
         }
     }
    public class ProfitAndLossDTO
    {
        public int GroupId { get; set; }
        public string Descripion { get; set; }
        public List<ProfitAndLossLevel2> Level2ProfitAndLoss { get; set; }
        public decimal TotalY1
        {
            get
            {
                return this.Level2ProfitAndLoss.Sum(e => e.Yr1Amount);
            }
        }
        public decimal TotalY2
        {
            get
            {
                return this.Level2ProfitAndLoss.Sum(e => e.Yr2Amount);
            }
        }
    }

    public class ProfitAndLossLevel2
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