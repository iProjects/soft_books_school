using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using WinSBSchool.Reports.ViewModels;
using CommonLib;
using WinSBSchool.Infrastructure;
using System.Windows.Forms;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class TransactionViewModelBuilder
    {
        Repository rep;
        bool error = false;
        TransactionViewModel _ViewModel;
        string connection;
        DAL.School school;
        int gradingsys; 
        string fileLogo;
        string slogan;

        public TransactionViewModelBuilder(School _school, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;
        }

        private void BuildTransactionReportModel()
        {
            _ViewModel = new TransactionViewModel();
            _ViewModel.printedon = DateTime.Today;
            _ViewModel.SchoolName = school.SchoolName;
            _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
            _ViewModel.SchoolLogo = fileLogo;
            _ViewModel.SchoolSlogan = slogan;
            _ViewModel.ListofTransactions = this.GetSchoolTransactionlist();
        }
        public TransactionViewModel Gettransactionmodel()
        {
            try
            {
                if (!error)
                    BuildTransactionReportModel();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }

        private List<SchoolTransactionlist> GetSchoolTransactionlist()
        {
            List<SchoolTransactionlist> populatedTransactionlistmodel = new List<SchoolTransactionlist>();
            List<Transaction> Transactionlist = rep.GetAllTransactions();


            SchoolTransactionlist bst = new SchoolTransactionlist();
            var Items = from p in Transactionlist
                        select new STransaction
                        {

                            Amount = p.Amount,
                            Narrative = p.Narrative,
                            UserID = p.UserName,
                            Authorizer = p.Authorizer,
                            StatementFlag = p.StatementFlag,
                            PostDate = p.PostDate,
                            ValueDate = p.ValueDate ?? DateTime.Today,
                            RecordDate = p.RecordDate,

                        };
            bst.TransactionList = Items.ToList();

            if (Items.Count() > 0)
                populatedTransactionlistmodel.Add(bst);

            return populatedTransactionlistmodel;

        }

    }

}
