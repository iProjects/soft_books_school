using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonLib;
using GL.DAL;
using WinSBSchool.Reports.ViewModels;

namespace WinSBSchool.Reports.ViewModelBuilders
{
   public class PSViewModelBuilder
    {
       
        Repository rep;
        bool error = false;
        PSViewModel _ViewModel;
        GL.DAL.Programme programme;
        GL.DAL.School school; 
        string fileLogo;
        string slogan;
        string connection;
        int schoolId;

        public PSViewModelBuilder(GL.DAL.Programme _programme, string Conn)
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
        public PSViewModel GetPSViewModelBuilder()
        {
            try
            {
                if (!error)
                    BuildPSViewModelViewModel();
                return _ViewModel;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        private void BuildPSViewModelViewModel()
        {
            try
            {
                _ViewModel = new PSViewModel();
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
