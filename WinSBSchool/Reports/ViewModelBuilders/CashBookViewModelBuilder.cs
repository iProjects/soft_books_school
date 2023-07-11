using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonLib;
using DAL;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class CashBookViewModelBuilder
      {
        Repository rep; 
        CashBookViewModel _ViewModel;
        string connection;
        School school; 
        Customer customer;
        Account account;
        List<Transaction> transactions;
        DateTime Startdate;
        DateTime Enddate;
        SBSchoolDBEntities db;
        int gradingsys;
        string fileLogo;
        string slogan;

        public CashBookViewModelBuilder(School _school, int accountid, DateTime startdate, DateTime enddate, string Conn)
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

            if (enddate < startdate) throw new ArgumentNullException("Enddate cannot be less than Startdate");

           
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

        public CashBookViewModel Build()
        {
            _ViewModel = new CashBookViewModel(); 
            _ViewModel.ReportDate = DateTime.Now; 
            _ViewModel.SchoolLogo  = fileLogo; 
            _ViewModel.SchoolSlogan  = slogan; 
            _ViewModel.StartDate = Startdate;
            _ViewModel.EndDate = this.Enddate;
            _ViewModel.SchoolName = school.SchoolName.Trim();
            _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
            _ViewModel.CustomerName = customer.CustomerName;
            _ViewModel.CustomerAddress = customer.Address;
            _ViewModel.CustomerTelephone = customer.Telephone;
            _ViewModel.CustomerEmail = customer.Email;
            _ViewModel.BillToName = customer.BillToName;
            _ViewModel.BillToAddress = customer.BillToAddress;
            _ViewModel.BillToTelephone = customer.BillToTelephone;
            _ViewModel.BillToEmail = customer.BillToEmail;
            _ViewModel.CBStatementTransactions = this.ComputeCBStatementTransactions();
            _ViewModel.Bal30 = account.Bal30 ?? 0;
            _ViewModel.Bal60 = account.Bal60 ?? 0;
            _ViewModel.Bal90 = account.Bal90 ?? 0;
            _ViewModel.BalOver90 = account.BalOver90 ?? 0;
            _ViewModel.AmountDue = _ViewModel.CurrentBalance;

            return _ViewModel;
        }

        private List<CBStatementTransaction> ComputeCBStatementTransactions()
        {
            List<CBStatementTransaction> lst = new List<CBStatementTransaction>();

            decimal runningBal = 0;
            CBStatementTransaction BalBF = new CBStatementTransaction();
            BalBF.PostDate = Startdate;
            BalBF.Narrative = "Balance B/F";
            BalBF.Amount = rep.GetBalanceBF(account.Id, Startdate);
            BalBF.Balance = BalBF.Amount;
            runningBal = BalBF.Balance;

            lst.Add(BalBF);

            foreach (Transaction t in transactions)
            {
                CBStatementTransaction tx = new CBStatementTransaction();
                tx.PostDate = t.PostDate;
                tx.Narrative = t.Narrative;
                tx.Amount = t.Amount;

                //Compute running balance
                runningBal += t.Amount;
                tx.Balance = runningBal;
                lst.Add(tx);
            }
            return lst;
        }
    }
}