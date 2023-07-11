using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonLib;

namespace DAL
{    
    public class CExams
    {
        #region "properties"
        Repository rep;
        string connection; 
        SBSchoolDBEntities db;
        string _User;
        string receiptNo;
        public delegate void ExamsCompleteEventHandler(object sender, ExamCompleteEventArg e);
        public event ExamsCompleteEventHandler OnCompleteGenerateExams;
        #endregion "properties"

        #region "constructor"
        public CExams(string us, string Conn)
        { 
            if(string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Connection");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection);

            _User = us;
        }
        #endregion "constructor"

        #region "methods"  
        public string GenerateRandomTransactionReference()
        { 
            try
            {
                string RawSalt = DateTime.Now.ToString("yMdHms");
                string HashSalt = HashHelper.CreateRandomSalt();
                int foundS1 = HashSalt.IndexOf("==");
                int foundS2 = HashSalt.IndexOf("+");
                int foundS3 = HashSalt.IndexOf("/");
                if (foundS1 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS1);
                }
                if (foundS2 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS2);
                }
                if (foundS3 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS3);
                }
                string SaltedHash = RawSalt.Insert(5, HashSalt);
                string _transRef = SaltedHash;
                receiptNo = _transRef;
                return receiptNo;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex); 
                return null;
            }
        }  
        #endregion "methods"
    }

    public class ExamCompleteEventArg
    {
        private int svalue;
        private bool _error;
        private string _errorMsg;

        public ExamCompleteEventArg(int value, bool error, string errorMsg)
        {
            svalue = value;
            _error = error;
            _errorMsg = errorMsg;
        }

        public int StatusValue
        {
            get { return svalue; }
        }
        public string ErrorMsg
        {
            get { return _errorMsg; }
        }
        public bool Error
        {
            get { return _error; }
        }
    }

    public class TransactionReferenceGenerator
    {
        #region "properties"
        Repository rep;
        string connection;
        SBSchoolDBEntities db; 
        string receiptNo; 
        #endregion "properties"

        #region "constructor" 
        public TransactionReferenceGenerator(string Conn)
        {
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Connection");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);
            rep = new Repository(connection); 
        }
        #endregion "constructor"

        #region "methods"
        public string GenerateRandomTransactionReference()
        {
            try
            {
                string RawSalt = DateTime.Now.ToString("yMdHms");
                string HashSalt = HashHelper.CreateRandomSalt();
                int foundS1 = HashSalt.IndexOf("==");
                int foundS2 = HashSalt.IndexOf("+");
                int foundS3 = HashSalt.IndexOf("/");
                if (foundS1 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS1);
                }
                if (foundS2 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS2);
                }
                if (foundS3 > 0)
                {
                    HashSalt = HashSalt.Remove(foundS3);
                }
                string SaltedHash = RawSalt.Insert(5, HashSalt);
                string _transRef = SaltedHash;
                receiptNo = _transRef;
                return receiptNo;
            }
            catch (Exception ex)
            {
                Log.WriteToErrorLogFile(ex);
                return null;
            }
        }
        #endregion "methods"
    }

}
