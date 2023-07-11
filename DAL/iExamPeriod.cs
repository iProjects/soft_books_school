using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class iExamPeriod
    {
        int _Year;
        int _Term;
        int _ExamType;

        public iExamPeriod()
        {
        }

        public iExamPeriod(int year, int term, int examtype)
        {
            _Year = year;
            _Term = term;
            _ExamType = examtype;
        }

        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        public int Term
        {
            get { return _Term; }
            set { _Term = value; }
        }
        public int ExamType
        {
            get { return _ExamType; }
            set { _ExamType = value; }
        }
    }

    public enum ExaminationState
    {
        Open,
        Closed,
        Processed,
        NotProcessed,
        OpenNotProcessed,
        OpenProcessed,
        NotOpenProcessed,
        NotOpenNotProcessed
    }

    public class ReceivedSmsMessagesSelectEventArgs : System.EventArgs
    {
        decimal _Amount;
        string _PhoneNumber;
        string _Name;
        string _ReferenceNumber;

        public ReceivedSmsMessagesSelectEventArgs()
        {
        }

        public ReceivedSmsMessagesSelectEventArgs(decimal amount, string phonenumber, string name, string referencenumber)
        {
            _Amount = amount;
            _PhoneNumber = phonenumber;
            _Name = name;
            _ReferenceNumber = referencenumber;
        }

        public decimal Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string ReferenceNumber
        {
            get { return _ReferenceNumber; }
            set { _ReferenceNumber = value; }
        }
    }

















}