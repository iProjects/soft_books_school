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
    public class ProgrammeCourseListViewModelBuilder
    {

        Repository rep;
        bool error = false;
        ProgrammeCourseListViewModel _ViewModel;
        DAL.Programme _Programme;
        DAL.School school;
        string fileLogo;
        string slogan;
        string connection;
        SBSchoolDBEntities db;
        int gradingsys;

        public ProgrammeCourseListViewModelBuilder(School _school, DAL.Programme _programme, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (_programme == null)
                throw new ArgumentNullException("Programme is invalid");
            _Programme = _programme;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;

        }
        public ProgrammeCourseListViewModel GetModelBuilder()
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
                _ViewModel = new ProgrammeCourseListViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.SchoolName = school.SchoolName;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2;
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel.ProgrammeDescription = _Programme.Description;
                _ViewModel.Courses = this.GetProgrammeCourseList();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }

        private List<ProgramCoursesDTO> GetProgrammeCourseList()
        {
            List<ProgramCoursesDTO> lstProgrammeCourses = new List<ProgramCoursesDTO>();

            List<YearTerm> yts = rep.GetProgrammeYearTerms(_Programme.Id.Trim());

            var _programmeyrsquery = from py in db.ProgrammeYears
                                     where py.ProgrammeId == _Programme.Id
                                     select py;
            List<ProgrammeYear> _ProgrammeYrs = _programmeyrsquery.ToList();

            foreach (var pry in yts)
            {
                ProgramCoursesDTO pc = new ProgramCoursesDTO();
                pc.YearTerm = pry;
                var _progYrquery = (from py in db.ProgrammeYears
                                    where py.ProgrammeId == _Programme.Id
                                    where py.Year == pry.Year
                                    select py).FirstOrDefault();
                ProgrammeYear _ProgrammeYear = _progYrquery;

                List<ProgrammeYearCours> _ProgrammeYearCourses = new List<ProgrammeYearCours>();

                foreach (var sm in pry.Term)
                {

                    var _ProgramYearCoursequery = (from pyc in db.ProgrammeYearCourses
                                                   where pyc.ProgrammeId == _Programme.Id
                                                   where pyc.ProgrammeYearId == _ProgrammeYear.Id
                                                   where pyc.Semester == sm
                                                   select pyc).FirstOrDefault();
                    ProgrammeYearCours _ProgYrCrs = _ProgramYearCoursequery;

                    if (!_ProgrammeYearCourses.Contains(_ProgYrCrs))
                    {
                        _ProgrammeYearCourses.Add(_ProgYrCrs);
                    }

                    pc.ProgrammeYrCrs = _ProgrammeYearCourses;

                    lstProgrammeCourses.Add(pc);
                }
            }

            return lstProgrammeCourses;
        }





    }
}
