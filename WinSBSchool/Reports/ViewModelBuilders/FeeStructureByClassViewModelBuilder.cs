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
    public class FeeStructureByClassViewModelBuilder
    {

        Repository rep;
        bool error = false;
        FeeStructureByClassViewModel _ViewModel;
        SchoolClass _SchoolClass;
        DAL.School school;
        int Year;
        int Term;
        string fileLogo;
        string slogan;
        string connection;
        SBSchoolDBEntities db;
        int gradingsys;

        public FeeStructureByClassViewModelBuilder(School _school, SchoolClass Sc, int Yr, int _term, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);

            if (Sc == null)
                throw new ArgumentNullException("SchoolClass is invalid");
            _SchoolClass = Sc;

            if (Yr == null)
                throw new ArgumentNullException("Year is invalid");
            Year = Yr;

            if (_term == null)
                throw new ArgumentNullException("Term is invalid");
            Term = _term;

            if (_school == null)
                throw new ArgumentNullException("School is invalid");
            school = _school;
            gradingsys = school.GradingSystem;

            fileLogo = school.Logo;
            slogan = school.Slogan;

        }
        public FeeStructureByClassViewModel GetModelBuilder()
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
                _ViewModel = new FeeStructureByClassViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                _ViewModel.SchoolName = school.SchoolName;
                _ViewModel.SchoolAddress = school.Address1 + ", " + school.Address2;
                _ViewModel.ClassName = _SchoolClass.ClassName;
                _ViewModel.ClassId = _SchoolClass.Id;
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.year = Year;
                _ViewModel.Term = Term;
                _ViewModel.SchoolSlogan = slogan;
                _ViewModel.FeeStructureAcademics = this.GetFeeStructureAcademics();
                _ViewModel.FeeStructureOthers = this.GetFeeStructureOthers();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private List<FeeStructureAcademicDTO> GetFeeStructureAcademics()
        {
            try
            {
                List<FeeStructureAcademicDTO> lst = new List<FeeStructureAcademicDTO>();
                List<FeeStructureAcademicDTO> FeeStructureAcademics = new List<FeeStructureAcademicDTO>();

                var feeStructurequery = (from fs in db.FeesStructures
                                         where fs.Year == Year
                                         select fs).FirstOrDefault();
                FeesStructure FeeStructure = feeStructurequery;

                var FeeStructureAcademicsquery = from fsa in db.FeeStructureAcademics
                                                 where fsa.SchoolClassId == _SchoolClass.Id
                                                 where fsa.Term == Term
                                                 where fsa.FeeStructureId == FeeStructure.Id
                                                 select new FeeStructureAcademicDTO
                                                 {
                                                     Description = fsa.Description,
                                                     Amount = fsa.Amount,
                                                     AmountPeriod = fsa.AmountPeriod
                                                 };
                FeeStructureAcademics = FeeStructureAcademicsquery.ToList();

                foreach (var fs in FeeStructureAcademicsquery.ToList())
                {
                    FeeStructureAcademicDTO fsd = new FeeStructureAcademicDTO();
                    fsd.Description = fs.Description;
                    fsd.Amount = fs.Amount;
                    fsd.AmountPeriod = fs.AmountPeriod;
                    lst.Add(fsd);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }

        private List<FeeStructureOthersDTO> GetFeeStructureOthers()
        {
            try
            {
                List<FeeStructureOthersDTO> lst = new List<FeeStructureOthersDTO>();
                List<FeeStructureOthersDTO> FeeStructureOthers = new List<FeeStructureOthersDTO>();
                var feeStructurequery = (from fs in db.FeesStructures
                                         where fs.Year == Year
                                         select fs).FirstOrDefault();
                FeesStructure FeeStructure = feeStructurequery;

                var FeeStructureOthersquery = from fso in db.FeeStructureOthers
                                              where fso.FeeStructureId == FeeStructure.Id
                                              select new FeeStructureOthersDTO
                                              {
                                                  Description = fso.Description,
                                                  Amount = fso.Amount,
                                                  AmountPeriod = fso.AmountPeriod,
                                                  ApplicableTo = fso.ApplicableTo
                                              };
                FeeStructureOthers = FeeStructureOthersquery.ToList();

                foreach (var fs in FeeStructureOthers)
                {
                    FeeStructureOthersDTO fsd = new FeeStructureOthersDTO();
                    fsd.Description = fs.Description;
                    fsd.Amount = fs.Amount;
                    fsd.AmountPeriod = fs.AmountPeriod;
                    fsd.ApplicableTo = fs.ApplicableTo;
                    lst.Add(fsd);
                }
                return lst;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
                return null;
            }
        }





    }
}
