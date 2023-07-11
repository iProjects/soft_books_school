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
   public class StudentDisciplineStatusViewModelBuilder
   {
       
        Repository rep;
        bool error = false;
        StudentDisciplineStatusViewModel _ViewModel;
        DAL.Programme programme;
        DAL.School school; 
        string fileLogo;
        string slogan;
        string connection; 
        SBSchoolDBEntities db;
        int gradingsys;

        public StudentDisciplineStatusViewModelBuilder(School _school, DAL.Programme _programme, string Conn)
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
        public StudentDisciplineStatusViewModel GetStudentDisciplineStatusViewModelBuilder()
        {
            try
            {
                if (!error)
                    BuildStudentDisciplineStatusViewModel();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void BuildStudentDisciplineStatusViewModel()
        {
            try
            {
                _ViewModel = new StudentDisciplineStatusViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.ProgrammeId = programme.Description ;
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
