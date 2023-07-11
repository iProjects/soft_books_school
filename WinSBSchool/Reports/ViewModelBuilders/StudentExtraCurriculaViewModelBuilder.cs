﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonLib;
using DAL;
using WinSBSchool.Reports.ViewModels;
using System.Windows.Forms;

namespace WinSBSchool.Reports.ViewModelBuilders
{
   public class StudentExtraCurriculaViewModelBuilder
    {
       
        Repository rep;
        bool error = false;
        StudentExtraCurriculaViewModel _ViewModel;
        DAL.Programme programme;
        DAL.School school; 
        string fileLogo;
        string slogan;
        string connection; 
        SBSchoolDBEntities db;
        int gradingsys;

        public StudentExtraCurriculaViewModelBuilder(School _school, DAL.Programme _programme, string Conn)
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
        public StudentExtraCurriculaViewModel GetStudentExtraCurriculaViewModelBuilder()
        {
            try
            {
                if (!error)
                    BuildStudentExtraCurriculaViewModel();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }
        private void BuildStudentExtraCurriculaViewModel()
        {
            try
            {
                _ViewModel = new StudentExtraCurriculaViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.ProgrammeId = programme.Description ;
                _ViewModel.SchoolName = school.SchoolName  ;
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
