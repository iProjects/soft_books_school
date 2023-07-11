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
   public class StudentAccountStatusViewModelBuilder
    {
       
        Repository rep;
        bool error = false;
        StudentAccountStatusViewModel _ViewModel;
        DAL.Programme programme;
        DAL.School school; 
        string fileLogo;
        string slogan;
        SBSchoolDBEntities db;
        int gradingsys;
        string connection;

        public StudentAccountStatusViewModelBuilder(School _school, DAL.Programme _programme, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (_programme == null)
                throw new ArgumentNullException("Programme is invalid");

            programme = _programme;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;

        }
        public StudentAccountStatusViewModel GetStudentAccountStatusViewModelBuilder()
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
                _ViewModel = new StudentAccountStatusViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.SchoolName = school.SchoolName ;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
                _ViewModel.ProgrammeId = programme.Description ;
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
