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
   public class ClassListViewModelBuilder
   {
       
         
        ClassListViewModel _ViewModel; 
        DAL.School school;
        string fileLogo;
        string slogan;
        string connection;
        SBSchoolDBEntities db;
        Repository rep;
        bool error = false;
        int gradingsys;

        public ClassListViewModelBuilder(School _school, string Conn)
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
        public ClassListViewModel GetViewModelBuilder()
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
                _ViewModel = new ClassListViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today; 
                _ViewModel.SchoolName = school.SchoolName.Trim();
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2; 
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel._ClassesList = this.GetClassList();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<SchoolClassesDTO> GetClassList()
        {
            try
            {
                List<SchoolClassesDTO> lstschcls = new List<SchoolClassesDTO>();
                var _ScholClassesquery = from sc in db.SchoolClasses
                                         select sc;
                List<SchoolClass> _SchoolClasses = _ScholClassesquery.ToList();

                foreach (SchoolClass _SchoolClass in _SchoolClasses)
                {
                    SchoolClassesDTO schcls = new SchoolClassesDTO();
                    schcls.ShortCode = _SchoolClass.ShortCode;
                    schcls.ClassName = _SchoolClass.ClassName;
                    schcls.ProgrammeYearId = _SchoolClass.ProgrammeYearId;
                    schcls.NoOfSubjects = _SchoolClass.NoOfSubjects;
                    schcls.ClassTeacher = _SchoolClass.TeacherId;
                    var _ClassStudentsquery = from st in db.Students
                                              join cs in db.ClassStreams on st.ClassStreamId equals cs.Id
                                              where cs.ClassId == _SchoolClass.Id
                                              orderby cs.Id ascending
                                              where st.Status =="A"
                                             select st;
                    List<Student> _classStudents = _ClassStudentsquery.ToList();
                    schcls.NoofStudents = _classStudents.Count;
                    lstschcls.Add(schcls);
                }
                return lstschcls;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }



   }
}
