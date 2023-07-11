using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonLib;
using DAL;
using WinSBSchool.Reports.ViewModels;
using System.Windows.Forms;

namespace WinSBSchool.Reports.ViewModelBuilders
{
   public class SchoolArrearsAndReceivablesViewModelBuilder
    {
       
        Repository rep;
        bool error = false;
        SchoolArrearsAndReceivablesViewModel _ViewModel; 
        DAL.School school; 
        string fileLogo;
        string slogan;
        string connection; 
        SBSchoolDBEntities db;
        int gradingsys;

        public SchoolArrearsAndReceivablesViewModelBuilder(DAL.School _school, string Conn)
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
        public SchoolArrearsAndReceivablesViewModel GetSchoolArrearsAndReceivablesViewModelBuilder()
        {
            try
            {
                if (!error)
                    Build ();
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
                _ViewModel = new SchoolArrearsAndReceivablesViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.SchoolName = school.SchoolName ;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        

    }
}
