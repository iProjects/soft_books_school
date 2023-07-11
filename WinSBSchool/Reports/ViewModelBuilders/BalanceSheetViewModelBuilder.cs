using System;  
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using System.Drawing;
using System.IO; 
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib; 
using DAL;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class BalanceSheetViewModelBuilder
   {
       Repository rep;
       BalanceSheetViewModel _ViewModel;
       string connection; 
       School school;   
       SBSchoolDBEntities db;
       string slogan;
       string fileLogo;
       int gradingsys;
       bool error = false;
       List<int> ids = new List<int>();

        public BalanceSheetViewModelBuilder(School _school,string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;

        }
        public BalanceSheetViewModel GetModelBuilder()
        {
            try
            { 
                    Build();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void Build()
        {
            try
            {
                _ViewModel = new BalanceSheetViewModel(); 
                _ViewModel.ReportDate = DateTime.Today; 
                _ViewModel.SchoolName = school.SchoolName;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel._BalanceSheets = GetBalanceSheets();
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<BalanceSheetDTO> GetBalanceSheets()
        {
            try
            {
                List<BalanceSheetDTO> lstdto = new List<BalanceSheetDTO>(); 

                var blcshtquery = (from bs2 in db.BS_Level2
                           join bs1 in db.BS_Level1 on bs2.ParentId equals bs1.Id
                            select new BalanceSheetLevel2
                           {
                               ParentId=bs2.ParentId,
                               Description=bs2.Description,                                
                               AccountField = bs2.AccField,
                               Criteria = bs2.BSCriteria,
                               Yr1Amount = bs2.Yr1Amount,
                               Yr2Amount = bs2.Yr2Amount,
                               ROrder = bs2.ROrder
                           } ).ToList();

                var blcshtlst = blcshtquery.ToList();

                var ParentIdsquery = (from d in blcshtlst
                                      select d.ParentId)
                               .Distinct()
                               .ToList();
                _ViewModel.ParentIds = ParentIdsquery;

                decimal totals = 0;

                foreach (var parentid in  _ViewModel.ParentIds)
                {                   
                    BalanceSheetDTO bsl2 = new BalanceSheetDTO();
                    bsl2.GroupId = parentid;
                    bsl2.Level2BalanceSheets = blcshtlst.Where(s => s.ParentId == parentid).ToList();
                     
                    lstdto.Add(bsl2);
                }

                return lstdto;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void GenerateBS(DataTable bsdt)
        {
            try
            {
                //ASSETS
                DataRow dr = bsdt.NewRow();

                dr["L1Description"] = "ASSETS";

                bsdt.Rows.Add(dr);


                var ass = (from bs2 in db.BS_Level2
                           join bs1 in db.BS_Level1 on bs2.ParentId equals bs1.Id
                           where bs1.BSGroup == "ASS"
                           select bs2).ToList();

                decimal assTotal = 0;
                decimal assTotalYr2 = 0;

                foreach (BS_Level2 item in ass)
                {
                    decimal total = ExecuteCriteriaBS(item.BSCriteria);
                    assTotal += total;

                    DataRow idr = bsdt.NewRow();
                    idr["L1Description"] = "";
                    idr["L2Description"] = item.Description;

                    decimal yr1Amt = 0;
                    decimal.TryParse(idr["Yr1"].ToString(), out yr1Amt);
                    assTotalYr2 += yr1Amt;

                    idr["Yr2"] = yr1Amt;
                    idr["Yr1"] = total;

                    bsdt.Rows.Add(idr);
                }
                DataRow assTotaldr = bsdt.NewRow();
                assTotaldr["L1Description"] = "TOTAL ASSETS";
                assTotaldr["L2Description"] = "";
                assTotaldr["Yr2"] = assTotalYr2;
                assTotaldr["Yr1"] = assTotal;

                bsdt.Rows.Add(assTotaldr);

                //LIABILITIES
                DataRow edr = bsdt.NewRow();
                edr["L1Description"] = "LIABILITIES";
                bsdt.Rows.Add(edr);

                var liab = (from bs2 in db.BS_Level2
                            join bs1 in db.BS_Level1 on bs2.ParentId equals bs1.Id
                            where bs1.BSGroup == "LIAB"
                            select bs2).ToList();
                decimal liabTotal = 0;
                decimal liabTotalYr2 = 0;
                foreach (BS_Level2 item in liab)
                {
                    decimal total = ExecuteCriteriaBS(item.BSCriteria);
                    liabTotal += total;
                    DataRow idr = bsdt.NewRow();
                    idr["L1Description"] = "";
                    idr["L2Description"] = item.Description;
                    decimal yr1Amt = 0;
                    decimal.TryParse(idr["Yr1"].ToString(), out yr1Amt);
                    liabTotalYr2 += yr1Amt;
                    idr["Yr2"] = yr1Amt;
                    idr["Yr1"] = total;

                    bsdt.Rows.Add(idr);
                }
                DataRow liabTotaldr = bsdt.NewRow();
                liabTotaldr["L1Description"] = "TOTAL LIABILITIES";
                liabTotaldr["L2Description"] = "";
                liabTotaldr["Yr2"] = liabTotalYr2;
                liabTotaldr["Yr1"] = liabTotal;

                bsdt.Rows.Add(liabTotaldr);

                //CAPITAL 
                DataRow cdr = bsdt.NewRow();
                cdr["L1Description"] = "CAPITAL";
                bsdt.Rows.Add(cdr);


                var cap = (from bs2 in db.BS_Level2
                           join bs1 in db.BS_Level1 on bs2.ParentId equals bs1.Id
                           where bs1.BSGroup == "CAP"
                           select bs2).ToList();
                decimal capTotal = 0;
                decimal capTotalYr2 = 0;
                foreach (BS_Level2 item in cap)
                {
                    decimal total = ExecuteCriteriaBS(item.BSCriteria);
                    capTotal += total;
                    DataRow idr = bsdt.NewRow();
                    idr["L1Description"] = "";
                    idr["L2Description"] = item.Description;
                    decimal yr1Amt = 0;
                    decimal.TryParse(idr["Yr1"].ToString(), out yr1Amt);
                    capTotalYr2 += yr1Amt;
                    idr["Yr2"] = yr1Amt;
                    idr["Yr1"] = total;

                    bsdt.Rows.Add(idr);
                }
                DataRow capTotaldr = bsdt.NewRow();
                capTotaldr["L1Description"] = "TOTAL CAPITAL";
                capTotaldr["L2Description"] = "";
                capTotaldr["Yr2"] = capTotalYr2;
                capTotaldr["Yr1"] = capTotal;

                bsdt.Rows.Add(capTotaldr);


                //TOTAL LIABILITIES & CAPITAL
                decimal totliabcap = capTotal + liabTotal;
                decimal totliabcapYr2 = capTotalYr2 + liabTotalYr2;
                DataRow totliabcapDr = bsdt.NewRow();
                totliabcapDr["L1Description"] = "TOTAL LIABILITIES & CAPITAL";
                totliabcapDr["L2Description"] = "";
                totliabcapDr["Yr2"] = totliabcapYr2;
                totliabcapDr["Yr1"] = totliabcap;
                bsdt.Rows.Add(totliabcapDr);


            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private decimal ExecuteCriteriaBS(string Criteria)
        {
            decimal res = 0;
            //COAId=32
            string[] items = Criteria.Split('=');
            switch (items[0])
            {
                case "COAId":
                    int parentId = int.Parse(items[1]);
                    List<int> Ids = new List<int>();
                    CreateIdList(parentId, Ids);
                    var accQuery = db.Accounts.Where(crtu => Ids.Contains(crtu.COAId));
                    if (accQuery.Count() > 0)
                        res = accQuery.Sum(i => i.BookBalance);
                    break;
            }

            return res;
        }
        private void CreateIdList(int ParentId, List<int> Ids)
        {
            try
            {
                List<int> ChildIds = (from i in db.COAs
                                      where i.Parent == ParentId
                                      select i.Id).ToList();
                Ids.Add(ParentId);
                foreach (int child in ChildIds)
                {
                    CreateIdList(child, Ids);
                }
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private void CreateIdList(TreeNode node)
        {
            try
            {
                int itemId = int.Parse(node.Name);
                ids.Add(itemId);
                foreach (TreeNode child in node.Nodes)
                {
                    CreateIdList(child);
                }
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }

    }
}

