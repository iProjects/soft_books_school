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
   public class TeacherProgressFormViewModelBuilder
    {
       
        Repository rep;
        bool error = false;
        TeacherProgressFormViewModel _ViewModel;
        DAL.SchoolClass _SchoolClass;
        DAL.School school; 
        string fileLogo;
        string slogan;
        string connection; 
        int gradingsys;
        SBSchoolDBEntities db;

        public TeacherProgressFormViewModelBuilder(School _school, DAL.SchoolClass _schoolClass, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (_schoolClass == null)
                throw new ArgumentNullException("SchoolClass is invalid");

            _SchoolClass = _schoolClass;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;
        }
        public TeacherProgressFormViewModel GetModelBuilder()
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
                _ViewModel = new TeacherProgressFormViewModel();
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
