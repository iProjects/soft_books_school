using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class RegisterExamPeriods : Form
    {
        Repository rep;
        string user;
        string connection;
        public RegisterExamPeriods(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            user = _user;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ExamPeriod ep = new ExamPeriod()
                {
                  
 
                };
                rep.AddNewExamPeriod(ep);

                this.Close();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += "\n" + ex.InnerException.Message;
                MessageBox.Show(msg);
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterExamPeriods_Load(object sender, EventArgs e)
        {
            bindingSourceExamTypes.DataSource = rep.GetAllExamTypes();
            cboExamType.DataSource = bindingSourceExamTypes;
            cboExamType.ValueMember = "Id";
            cboExamType.DisplayMember = "ShortCode";
        }
    }
}
