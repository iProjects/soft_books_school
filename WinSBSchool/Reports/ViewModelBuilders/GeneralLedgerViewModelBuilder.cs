 using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonLib;
using DAL;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.ViewModelBuilders
{
    public class GeneralLedgerViewModelBuilder
    {
        Repository rep; 
        string fileLogo;
        string slogan;
        string connection;
        DateTime Enddate;
        DateTime Startdate;
        DAL.School school; 
        Account account;
        GeneralLegderViewModel _ViewModel;
        public List<AccountGroup> AccountGroups;

        public GeneralLedgerViewModelBuilder(School _school, int accountid, DateTime startdate, DateTime enddate, string Conn)
        {

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            
            rep = new Repository(connection);

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
            Startdate = startdate;
            Enddate = enddate;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;

            fileLogo = school.Logo;
            slogan = school.Slogan;
        }
        
        public GeneralLegderViewModel BuildGLViewModel()
        {
            _ViewModel = new GeneralLegderViewModel();            
            _ViewModel.ReportDate = DateTime.Now;
            _ViewModel.StartDate = Startdate;
            _ViewModel.Logo = fileLogo;
            _ViewModel.CompanySlogan = slogan;
            _ViewModel.EndDate = this.Enddate;
            _ViewModel.SchoolName = school.SchoolName.Trim();
            _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
            _ViewModel.AccountGroups = this.GetAccountGroups();
            
            return _ViewModel;
        }
        private List<AccountGroup> GetAccountGroups()
        {
            List<AccountGroup> lst = new List<AccountGroup>();

            
            AccountGroup acntgrp = new AccountGroup();
            acntgrp.Description = account.AccountName;
            acntgrp.Accounts = rep.GetAllAccounts();

            lst.Add(acntgrp);

            foreach (AccountGroup t in AccountGroups)
            {
                AccountGroup tx = new AccountGroup();
                tx.Accounts = t.Accounts;
                tx.Description = t.Description;
                
                lst.Add(tx);
            }
            return lst;
        }

    }

}