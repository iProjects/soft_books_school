using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rules
{
    public class RegisterExamRules
    {

        /* A CLASS FOR TYPICAL CHECKS BEFORE REGISTERING FOR EXAMS
         * 1) Is fees paid
         * 2) Is eligible - e.g. not debarred from examinations for any reason
         * 3) Pre-requisites  - completed unit/programme pre-requisites
         * 4) Attendance -  satisfactorily attended classes
         * 5) Completion - completed satisfactorily all programme requirements
         */

        //add variables to hold rule values

        decimal feescharged;
        decimal feespaid;
        bool eligible ;
        bool prerequisites;
        int unithrs;
        int hrsattended;
        bool completed;

        //results
        bool sucess = false;
        string msg = "unknown";

        public RegisterExamRules()
        {
        }

        #region Properties

        public bool IsSuccess
        {
            get { return sucess; }
            set { sucess = value; }
        }
        public string Message
        {
            get { return msg; }
            set { msg = value; }
        }
        //fees
        public decimal FeesCharged
        {
            get { return feescharged; }
            set { feescharged = value; }
        }
        public decimal FeesPaid
        {
            get { return feespaid; }
            set { feespaid = value; }
        }
        public bool IsFeesPaid
        {
            get { return (FeesCharged-FeesPaid) < 0; }
        }

        //Eligibility
        public bool IsEligible
        {
            get { return eligible; }
            set { sucess = eligible; }
        } 
        //Prerequisites
        public bool PrerequisitesDone
        {
            get { return prerequisites; }
            set { prerequisites = value; }
        } 
        //Attendance
        public int UnitHrs
        {
            get { return unithrs; }
            set { unithrs = value; }
        }
        public int HrsAttended
        {
            get { return hrsattended; }
            set { hrsattended = value; }
        } 
        //Completed
        public bool IsCompleted
        {
            get { return completed; }
            set { completed = value; }
        } 
        #endregion

        #region Exam rules methods

        #endregion

    }
}
