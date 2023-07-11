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
    public class ProfitAndLossViewModelBuilder
    {
        Repository rep;
        ProfitAndLossViewModel _ViewModel;
        string connection;
        School school;
        SBSchoolDBEntities db;
        string slogan;
        string fileLogo;
        int gradingsys;
        bool error = false;
        List<int> ids = new List<int>();
        List<int> PL2incids = new List<int>();
        List<int> PL2expids = new List<int>();
        List<int> BS2assids = new List<int>();
        List<int> BS2liabids = new List<int>();
        List<int> BS2capbids = new List<int>();

        public ProfitAndLossViewModelBuilder(School _school, string Conn)
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
        public ProfitAndLossViewModel GetModelBuilder()
        {
            try
            {
                if (!error)
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
                _ViewModel = new ProfitAndLossViewModel();
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.SchoolName = school.SchoolName;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2;
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel._ProfitAndLoss = GetProfitAndLoss();
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<ProfitAndLossDTO> GetProfitAndLoss()
        {
            try
            {
                List<ProfitAndLossDTO> lstdto = new List<ProfitAndLossDTO>();

                var plquery = (from pl2 in db.PL_Level2
                                   join pl1 in db.PL_Level1 on pl2.ParentId equals pl1.Id
                                   select new ProfitAndLossLevel2
                                   {
                                       ParentId = pl2.ParentId,
                                       Description = pl2.Description,
                                       AccountField = pl2.AccField,
                                       Criteria = pl2.PLCriteria,
                                       Yr1Amount = pl2.Yr1Amount,
                                       Yr2Amount = pl2.Yr2Amount,
                                       ROrder = pl2.ROrder
                                   }).ToList();

                var lstpl = plquery.ToList();

                var ParentIdsquery = (from d in lstpl
                                      select d.ParentId)
                               .Distinct()
                               .ToList();
                _ViewModel.ParentIds = ParentIdsquery;

                foreach (var parentid in _ViewModel.ParentIds)
                {
                    ProfitAndLossDTO pl2 = new ProfitAndLossDTO();
                    pl2.GroupId = parentid;
                    pl2.Level2ProfitAndLoss = lstpl.Where(s => s.ParentId == parentid).ToList();

                    lstdto.Add(pl2);
                }
                return lstdto;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        } 
        private void GeneratePL()
        {
            try
            {
                List<ProfitAndLossDTO> lstdto = new List<ProfitAndLossDTO>();

                //INCOME
                var inc = (from pl1 in db.PL_Level1
                           where pl1.PLGroup == "INC"
                           select pl1).FirstOrDefault();
                var incomequery = (from s in db.COAs
                                   where s.Description == "INCOME"
                                   select s).FirstOrDefault();
                COA income = incomequery;
                int incId = income.Id;
                List<int> incidstoexclude = new List<int> { incId };
                CreatePL2List(incId, PL2incids);
                List<int> pl2incintlst = PL2incids.Except(incidstoexclude).ToList();
                var PL2incquery = db.COAs.Where(crtu => pl2incintlst.Contains(crtu.Id)).ToList();

                foreach (var pll2 in PL2incquery.ToList())
                {
                    PL_Level2 pl2 = new PL_Level2();
                    pl2.ParentId = inc.Id;
                    pl2.Description = pll2.Description;
                    pl2.AccField = "BookBalance";
                    pl2.PLCriteria = "COAId=" + pll2.Id;
                    pl2.Yr1Amount = ComputeCoaAccTotals(pll2.Id);
                    pl2.Yr2Amount = ComputeCoaAccTotals(pll2.Id);
                    pl2.ROrder = pll2.COALevel;

                    if (!db.PL_Level2.Any(i => i.Description == pl2.Description && i.ParentId == pl2.ParentId))
                    {
                        db.PL_Level2.AddObject(pl2);
                        db.SaveChanges();
                    }
                }

                //EXPENSES
                var exp = (from pl1 in db.PL_Level1
                           where pl1.PLGroup == "EXP"
                           select pl1).FirstOrDefault();
                var expensequery = (from s in db.COAs
                                    where s.Description == "EXPENSES"
                                    select s).FirstOrDefault();
                COA expense = expensequery;
                int expenseId = expense.Id;
                List<int> expidstoexclude = new List<int> { expenseId };
                CreatePL2List(expenseId, PL2expids);
                List<int> pl2expintlst = PL2expids.Except(expidstoexclude).ToList();
                var PL2expquery = db.COAs.Where(crtu => pl2expintlst.Contains(crtu.Id));

                foreach (var pll2 in PL2expquery.ToList())
                {
                    PL_Level2 pl2 = new PL_Level2();
                    pl2.ParentId = exp.Id;
                    pl2.Description = pll2.Description;
                    pl2.AccField = "BookBalance";
                    pl2.PLCriteria = "COAId=" + pll2.Id;
                    pl2.Yr1Amount = ComputeCoaAccTotals(pll2.Id);
                    pl2.Yr2Amount = ComputeCoaAccTotals(pll2.Id);
                    pl2.ROrder = pll2.COALevel;

                    if (!db.PL_Level2.Any(i => i.Description == pl2.Description && i.ParentId == pl2.ParentId))
                    {
                        db.PL_Level2.AddObject(pl2);
                        db.SaveChanges();
                    }

                }
            }
            catch (Exception ex)
            {
                CommonLib.Utils.ShowError(ex);
            }
        }
        private void CreatePL2List(int ParentId, List<int> PL2ids)
        {
            try
            {
                List<int> ChildIds = (from i in db.COAs
                                      where i.Parent == ParentId
                                      select i.Id).ToList();
                PL2ids.Add(ParentId);
                foreach (int child in ChildIds)
                {
                    CreatePL2List(child, PL2ids);
                }
            }
            catch (Exception ex)
            {

                Utils.ShowError(ex);
            }
        }
        private decimal ComputeCoaAccTotals(int coaid)
        {
            try
            {
                decimal res = 0;
                List<int> lstIds = new List<int>();
                CreateIdList(coaid, lstIds);
                var accQuery = db.Accounts.Where(crtu => lstIds.Contains(crtu.COAId));
                if (accQuery.Count() > 0)
                    res = accQuery.Sum(i => i.BookBalance);

                return res;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return 0;
            }
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



    }
}

