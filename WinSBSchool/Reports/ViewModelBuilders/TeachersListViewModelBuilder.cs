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
    public class TeachersListViewModelBuilder
    {
        Repository rep;
        string connection;
        bool error = false;
        TeachersListViewModel _ViewModel;
        DAL.School school;
        string fileLogo;
        string slogan; 
        int gradingsys;
        SBSchoolDBEntities db;

        public TeachersListViewModelBuilder(School _school, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;
        }

        public TeachersListViewModel GetViewModelBuilder()
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
            _ViewModel = new TeachersListViewModel();
            _ViewModel.printedon = DateTime.Today;
            _ViewModel.ReportDate = DateTime.Today;
            _ViewModel.SchoolName = school.SchoolName;
            _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
            _ViewModel.SchoolLogo = fileLogo;
            _ViewModel.SchoolSlogan = slogan;
            _ViewModel._TeachersList = this.GetTeacherslist();
        }

        private List<TeachersListDTO> GetTeacherslist()
        {
            List<TeachersListDTO> lstTeachers = new List<TeachersListDTO>();
            var _teachersquery = from tc in db.Teachers
                                where tc.Status == "A"
                                select tc;
            List<Teacher> _Teachers = _teachersquery.ToList();

            foreach (var t in _Teachers)
            {
                TeachersListDTO tld = new TeachersListDTO();
                tld.TeacherName = t.Name;
                tld.IDNo = t.IDNo;
                tld.TSCNo = t.TSCNo;
                tld.Position = t.Position;
                tld.Qualification = t.HighestQualification;
                tld.Email = t.Email;
                tld.Status = t.Status;
                tld.DateJoined = t.DateJoined ?? DateTime.Now;
                tld.DateLeft = t.DateLeft ?? DateTime.Now;

                lstTeachers.Add(tld);
            }
            return lstTeachers;
        }



    }
}