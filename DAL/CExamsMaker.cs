using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Diagnostics;
using CommonLib;

namespace GL.DAL
{
    public class CExamsMaker
    {

        #region Private Properties

        #region Employee info
        decimal _EmployeeRate;
        decimal _EmployerRate;
        string _EmpNo;
        string _MaritalStatus;
        decimal _Basic; 

        #endregion

        #region Settings & House keepting
        decimal _defaultRelief_Married;
        decimal _defaultRelief_Single;
        string _User;
        DateTime _PaymentDate = DateTime.Now;
        public int _PaymentPeriod;
        public int _Year;
        private string pensionSchemeFlag;


        Repository rep = new Repository();

        public bool _erorr = false;
        public string _errMsg;
        private bool anonymous = false;

        #endregion

        #region employee tax info
        decimal _PensionableEarnings;
        #endregion

        #endregion

        #region Constructors
        //used to make _exams for an employee
        public CExamsMaker(int Period, int Year, string EmpNo, string User)
        {
            try
            {
                _PaymentPeriod = Period;
                _Year = Year;
                _EmpNo = EmpNo;
                _User = User;
                anonymous = false;

                //load settings
                if (!Load())
                {
                    _erorr = true;
                    _errMsg = "Unable to load configs. please check the settings table";
                    Log.WriteToErrorLogFile(new Exception(_errMsg)); //log

                }
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
            }
        }

        //used to make anonymous _exams
        public CExamsMaker(decimal TaxablePay)
        {
            _Basic = TaxablePay;
            anonymous = true;

            if (!Load())
            {
                _erorr = true;
                Log.WriteToErrorLogFile(new Exception("Unable to load configs. please check the settings table")); //log
            }
        }

        #endregion

        #region Public Members
        public _Exams CreatePayslipFromTransactions()
        {
            //create _exams from loaded info. 
            _Exams _exams = new _Exams();

            if (!AddEmployeeEmployer(_exams))
            {
                return null;
            }

            if (!AddDeductions(_exams))
            {
                return null;
            }

            if (!AddPensionInfo(_exams))
            {
                return null;
            }

            if (!AddTaxInfo(_exams))
            {
                return null;
            }

            return _exams;
        }


        public _Exams CreateAnonymousPayslip()
        {
            _Exams _exams = new _Exams();
            _exams.PaymentDate = DateTime.Today;
            _exams.PrintedBy = "System";
            _exams.PrintedOn = DateTime.Today;

            //emp info
            _exams.EmpName = "System";
            _exams.EmpNo = "System";
            _exams.PayPoint = "System";  //HQ, etc

            _exams.PIN = "System";
            _exams.EmpGroup = "System"; //PP,Temp
            _exams.EmpPayroll = "System"; //Exec; surb
            _exams.Period = DateTime.Today.Month;
            _exams.Year = DateTime.Today.Year;

            //employer info    
            _exams.CompName = "System";
            _exams.CompAddr = "System";
            _exams.CompTel = "System";


            //PensionTotals
            _exams.PensionEmployer = 0;
            _exams.PensionEmployee = 0;

            //Payment
            _exams.BankBranch = "";
            _exams.Account = "";

            return _exams;
        }

        #endregion

        #region private build members

        private bool AddEmployeeEmployer(_Exams _exams)
        {
            try
            {
                _exams.PaymentDate = _PaymentDate;
                _exams.PrintedBy = _User;
                _exams.PrintedOn = DateTime.Today; 
                _exams.Year = _Year; 
                return true;
            }
            catch (Exception e)
            {
                Log.WriteToErrorLogFile(e);
                return false;
            }
        }

        private bool AddPensionInfo(_Exams _exams)
        {
            try
            {
                //PensionTotals
                decimal employeeContribution = 0, employercontribution = 0;
                decimal empAmt1 = 0, emplAmt1 = 0, empAmt2 = 0, emplAmt2 = 0, empAmt3 = 0, emplAmt3 = 0;

                empAmt1 = this.GetEmployeeContribution();
                emplAmt1 = this.GetEmployerContribution();

                empAmt2 = this.GetEmployeeContribution();
                emplAmt2 = 0;

                empAmt3 = empAmt1 + empAmt2;
                emplAmt3 = emplAmt1 + emplAmt2;
                switch (pensionSchemeFlag)
                {
                    case "1":
                        /*
                         * Pension is contributory at a rate defined in settings a
                         * PEN1E -employee contribution rate  
                         * PEN1R - emplyer contribution rate
                         * Pensionable earnings are defined by earnings marked with AddToPension flag
                         * 
                         * Employee only or Employer only contribution scheme can be achieved by setting
                         * PEN1E or PEN1R rates to 0
                         */
                        employeeContribution = empAmt1;
                        employercontribution = emplAmt1;
                        break;
                    case "2":
                        /*
                         * Only the employee contributes.
                         * The amount is set by adding pension item as a payroll item with 
                         * ITEMTYPE = EMPECONTR 	
                         * TAXTRACKING = DEDUCTIBLE
                         * The items must also be named Pension
                         */
                        employeeContribution = empAmt2;
                        employercontribution = emplAmt2;
                        break;
                    case "3":
                        /*
                         *Mixed case of 1 and 2
                         */
                        employeeContribution = empAmt3;
                        employercontribution = emplAmt3;
                        break;

                }
                _exams.PensionEmployer = employercontribution;
                _exams.PensionEmployee = employeeContribution;

                UpdateEmployeePension(pensionSchemeFlag, _exams);

                //update employer contribution
                _exams.NSSFEmployer = decimal.Parse(rep.SettingLookup("EMPNSSF"));

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }

        private void UpdateEmployeePension(string pensionSchemeFlag, _Exams _exams)
        {
             
        }

        private bool AddTaxInfo(_Exams _exams)
        {
            try
            { 

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }

        private bool AddDeductions(_Exams _exams)
        {
            /*This adds all deductions in employee transactions including
             *1. zero place holders for  PENSION, PAYE 
             *2. actual values for NSSF, NHIF
             */
            try
            {
               

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return false;
            }
        }
        #endregion

        //load general settings
        private bool Load()
        {
            try
            {
                //Settings
                decimal.TryParse(rep.SettingLookup("MRELIEF"), out _defaultRelief_Married);
                decimal.TryParse(rep.SettingLookup("SRELIEF"), out _defaultRelief_Single);
                //Settings
                decimal.TryParse(rep.SettingLookup("PEN1E"), out _EmployeeRate);
                decimal.TryParse(rep.SettingLookup("PEN1R"), out _EmployerRate);


                pensionSchemeFlag = rep.SettingLookup("DEFCONTRSCHEME");

                //load employee info
                if (!anonymous)
                {
                     
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                _erorr = true;
                _errMsg = "Error processing Load() \n" + ex.Message;
                return false;
            }

        }

        #region _Exams Item Computations/Lookups

        
        #endregion


        #region Pension

        private decimal EmployeePensionRate
        {
            get
            {
                return _EmployeeRate;
            }
            set
            {
                _EmployeeRate = value;
            }
        }

        private decimal EmployerPensionRate
        {
            get
            {
                return _EmployerRate;
            }
            set
            {
                _EmployerRate = value;
            }
        }

        private decimal GetEmployeeContribution()
        {
            return (_PensionableEarnings * _EmployeeRate) / 100;
        }

        private decimal GetEmployerContribution()
        {
            return (_PensionableEarnings * _EmployerRate) / 100;
        }

        #endregion

    }
}
