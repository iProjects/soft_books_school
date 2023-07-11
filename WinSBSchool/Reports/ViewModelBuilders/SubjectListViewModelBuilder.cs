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
    public class SubjectListViewModelBuilder
    {
        Repository rep;
        SBSchoolDBEntities db;
        bool error = false;
        SubjectListViewModel _ViewModel;
        DAL.SchoolClass _SchoolClass;
        DAL.School school;
        string fileLogo;
        string slogan;
        string connection;
        int gradingsys;

        public List<Subject> Subjects = new List<Subject>();

        //delegate
        public delegate void ReportsEngineCompleteEventHandler(object sender, ReportsEngineCompleteEventArg e);
        //event
        public event ReportsEngineCompleteEventHandler OnCompleteReportsEngine;


        public SubjectListViewModelBuilder(School _school, DAL.SchoolClass schoolClass, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            if (schoolClass == null)
                throw new ArgumentNullException("SchoolClass is invalid");
            _SchoolClass = schoolClass;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;
        }

        public SubjectListViewModel GetViewModelBuilder()
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
                _ViewModel = new SubjectListViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.ClassName = _SchoolClass.ClassName;
                _ViewModel.SchoolName = school.SchoolName;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2;
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel._ClassSubjectsList = this.GetSubjectsList();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<SubjectsListDTO> GetSubjectsList()
        {
            try
            {
                List<SubjectsListDTO> lstSubjects = new List<SubjectsListDTO>();
                var _classSubjectsquery = from sb in db.Subjects
                                          where sb.IsDeleted == false
                                          where sb.Status == "A"
                                          join cs in db.ClassSubjects on sb.ShortCode equals cs.SubjectCode
                                          where cs.Status == "A"
                                          where cs.IsDeleted == false
                                          where cs.ClassId == this._SchoolClass.Id
                                          select sb;
                Subjects = _classSubjectsquery.ToList();

                foreach (var sb in Subjects)
                {

                    SubjectsListDTO sld = new SubjectsListDTO();
                    sld.ShortCode = sb.ShortCode.Trim();
                    sld.Description = sb.Description.Trim();
                    if (sb.OutOf != null)
                    {
                        sld.OutOf = sb.OutOf ?? 0;
                    }
                    if (sb.PassMark != null)
                    {
                        sld.PassMark = sb.PassMark ?? 0;
                    }
                    if (sb.NoOfRequiredHours != null)
                    {
                        sld.NoOfRequiredHours = sb.NoOfRequiredHours ?? 0;
                    }
                    if (sb.Fees != null)
                    {
                        sld.Fees = sb.Fees ?? 0;
                    }

                    lstSubjects.Add(sld);
                }

                return lstSubjects;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }










    }
}