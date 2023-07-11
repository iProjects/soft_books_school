using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonLib;
using GL.DAL;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.ViewModelBuilders
{
   public class BSViewModelBuilder
    { 
        Repository rep;
        bool error = false;
        BSViewModel _ViewModel;
        GL.DAL.Programme programme;
        GL.DAL.School school; 
        string fileLogo;
        string slogan;
        string connection;
        int schoolId;

        public BSViewModelBuilder(GL.DAL.Programme _programme, string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            if (_programme == null)
                throw new ArgumentNullException("Programme is invalid");

            programme = _programme;

            schoolId = int.Parse(rep.SettingLookup("SCHOOLID"));
            school = rep.GetSchool(schoolId);
            fileLogo = rep.SettingLookup("COMPANYLOGO");
            slogan = rep.SettingLookup("COMPANYSLOGAN");

        }
        public BSViewModel GetBSViewModelBuilder()
        {
            try
            {
                if (!error)
                    BuildBSViewModelViewModel();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        private void BuildBSViewModelViewModel()
        {
            try
            {
                _ViewModel = new BSViewModel();
                _ViewModel.printedon = DateTime.Today;
                _ViewModel.ReportDate = DateTime.Today;
                
                _ViewModel.SchoolName = school.SchoolName.Trim(); 
                _ViewModel.SchoolLogo = fileLogo;
                _ViewModel.SchoolSlogan = slogan;
                
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }

        

    }

}
