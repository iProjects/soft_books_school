using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;
using DAL;
using WinSBSchool.Infrastructure;
using WinSBSchool.Reports.ViewModels;
using System.Windows.Forms;

namespace WinSBSchool.Reports.ViewModelBuilders
{
   public class TeacherReportFormViewModelBuilder
   {
       
        Repository rep;
        bool error = false;
        TeacherReportFormViewModel _ViewModel;
        DAL.Programme programme;
        DAL.School school; 
        string fileLogo;
        string slogan;
        string connection; 
        int gradingsys;
        SBSchoolDBEntities db;

        public TeacherReportFormViewModelBuilder(School _school, DAL.Programme _programme, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

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
        public TeacherReportFormViewModel GetTeacherAcademicReportFormViewModelBuilder()
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
                _ViewModel = new TeacherReportFormViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.SchoolName = school.SchoolName;
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
