using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class StatementViewModelBuilder
    {

        StatementViewModel _ViewModel;
        bool error = false;
        string connection;
        Customer customer;
        Repository rep;
        SBSchoolDBEntities db;
        DAL.School school;
        int gradingsys;
        Account account;
        List<Transaction> transactions;
        DateTime Startdate;
        DateTime Enddate;
        string fileLogo;
        string slogan;

        public StatementViewModelBuilder(School _school, int accountid, DateTime startdate, DateTime enddate, string Conn)
        {

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (startdate == null) throw new ArgumentNullException("Startdate cannot be null");
            if (enddate == null)
            {
                enddate = DateTime.Now;
            }

            if (enddate < startdate)
            {
                MessageBox.Show("Enddate cannot be less than Startdate", "SB School", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            account = rep.GetAccounts(accountid);
            if (account == null)
            {
                throw new ArgumentNullException("Account Id [" + accountid + "] does not exist");
            }

            if (account != null)
                customer = rep.GetCustomer(account.CustomerId);
            if (customer == null)
            {
                throw new ArgumentNullException("Account Id [" + accountid + "] does not have a valid customer");
            }

            transactions = rep.GetTransactions(accountid, startdate, enddate);
            Startdate = startdate;
            Enddate = enddate;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;
        }
        public StatementViewModel GetViewModel()
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
        public void Build()
        {
            try
            {
                _ViewModel = new StatementViewModel();
                _ViewModel.ReportDate = DateTime.Now;
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel.StartDate = this.Startdate;
                _ViewModel.EndDate = this.Enddate;
                _ViewModel.SchoolName = school.SchoolName;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2;
                _ViewModel.CustomerName = customer.CustomerName;
                _ViewModel.CustomerAddress = customer.Address;
                _ViewModel.CustomerTelephone = customer.Telephone;
                _ViewModel.CustomerEmail = customer.Email;
                _ViewModel.BillToName = customer.BillToName;
                _ViewModel.BillToAddress = customer.BillToAddress;
                _ViewModel.BillToTelephone = customer.BillToTelephone;
                _ViewModel.BillToEmail = customer.BillToEmail;
                _ViewModel.Bal30 = account.Bal30 ?? 0;
                _ViewModel.Bal60 = account.Bal60 ?? 0;
                _ViewModel.Bal90 = account.Bal90 ?? 0;
                _ViewModel.BalOver90 = account.BalOver90 ?? 0;
                _ViewModel.AmountDue = account.ClearedBalance;
                _ViewModel.StatementTransactions = this.ComputeStatementTransactions();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<StatementTransaction> ComputeStatementTransactions()
        {
            try
            {
                List<StatementTransaction> lstTransactions = new List<StatementTransaction>();

                decimal runningBal = 0;
                StatementTransaction BalBF = new StatementTransaction();
                BalBF.Id = 0;
                BalBF.TransactionTypeId = 0;
                BalBF.AccountId = account.Id;
                BalBF.Amount = rep.GetBalanceBF(account.Id, Startdate);
                BalBF.PostDate = Startdate;
                BalBF.RecordDate = Startdate;
                BalBF.ValueDate = Startdate;
                BalBF.Narrative = "Balance B/F";
                BalBF.StatementFlag = "Credit";
                BalBF.Authorizer = "SYSTEM";
                BalBF.UserId = "SYSTEM";
                BalBF.TransRef = GenerateRandomTransactionReference();
                BalBF.IsDeleted = false;

                BalBF.Balance = BalBF.Amount;
                runningBal = BalBF.Balance;

                lstTransactions.Add(BalBF);

                foreach (Transaction t in transactions)
                {
                    StatementTransaction tx = new StatementTransaction();
                    tx.Id = t.Id;
                    tx.TransactionTypeId = t.TransactionTypeId;
                    tx.AccountId = t.AccountId;
                    tx.Amount = t.Amount;
                    tx.PostDate = t.PostDate;
                    tx.RecordDate = t.RecordDate;
                    tx.ValueDate = t.ValueDate;
                    tx.Narrative = t.Narrative;
                    tx.StatementFlag = t.StatementFlag;
                    tx.Authorizer = t.Authorizer;
                    tx.UserId = t.UserName;
                    tx.TransRef = t.TransRef;
                    tx.IsDeleted = t.IsDeleted;

                    //Compute running balance
                    runningBal += t.Amount;
                    tx.Balance = runningBal;

                    lstTransactions.Add(tx);
                }
                return lstTransactions;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        public string GenerateRandomTransactionReference()
        {
            try
            {
                string receiptNo = string.Empty;
                string RawSalt = DateTime.Now.ToString("yMdHms");
                string HashSalt = HashHelper.CreateRandomSalt();
                int foundS1 = HashSalt.IndexOf("==");
                int foundS2 = HashSalt.IndexOf("+");
                int foundS3 = HashSalt.IndexOf("/");
                if (foundS1 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS1);
                }
                if (foundS2 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS2);
                }
                if (foundS3 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS3);
                }
                string SaltedHash = RawSalt.Insert(5, HashSalt);
                string _transRef = SaltedHash;
                receiptNo = _transRef;
                return receiptNo;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }





























    }
}