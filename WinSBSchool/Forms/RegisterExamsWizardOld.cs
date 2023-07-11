using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GL.DAL;
using CommonLib;
using System.Collections.ObjectModel;

namespace WinSchool.Forms
{
    public partial class RegisterExamsWizardOld : Form
    {

        Repository rep;
        string user;

        BindingList<SchoolClass> TargetClasses;
        BindingList<SchoolClass> SourceClasses;

        BindingList<ClassSubject> SourceClassSubjects;
        BindingList<ClassSubject> TargetClassSubjects;


        BindingList<RegisteredExam> TargetRegisteredExams;

        TabPage currentTab;

        public RegisterExamsWizardOld(string s)
        {
            InitializeComponent();
            user = s;
            rep = new Repository();

            var allclasses = rep.GetAllClasses();
            SourceClasses = new BindingList<SchoolClass>(allclasses);

            lstSourceClasses.DataSource = SourceClasses;
            lstSourceClasses.ValueMember = "ClassId";
            lstSourceClasses.DisplayMember = "ClassName";


            lstTargetClasses.DataSource = TargetClasses;
            lstTargetClasses.ValueMember = "ClassId";
            lstTargetClasses.DisplayMember = "ClassName";

            cbSelectedClasses.DataSource = TargetClasses;
            cbSelectedClasses.ValueMember = "ClassId";
            cbSelectedClasses.DisplayMember = "ClassName";

            lbTargetSubjects.DataSource = TargetClassSubjects;
            lbTargetSubjects.DisplayMember = "";
            lbTargetSubjects.ValueMember = "";

            dataGridView1.DataSource = TargetRegisteredExams;

            currentTab = tabControl1.TabPages[0];
        }

        private void RegisterExamsWizard_Load(object sender, EventArgs e)
        {
            List<ExamType> examtypes = rep.GetAllExamTypes();
            cboExamType.DataSource = examtypes;
            cboExamType.ValueMember = "Id";
            cboExamType.DisplayMember = "ShortCode";
            cboExamType.SelectedValue = 1;          
            
            var terms = new BindingList<KeyValuePair<int, string>>();
            terms.Add(new KeyValuePair<int, string>(1, "ONE"));
            terms.Add(new KeyValuePair<int, string>(2, "TWO"));
            terms.Add(new KeyValuePair<int, string>(3, "THREE"));
            cboTerm.DataSource = terms;
            cboTerm.ValueMember = "Key";
            cboTerm.DisplayMember = "Value";
            cboTerm.SelectedValue = -1;

            cboYear.Text = DateTime.Today.Year.ToString();
        
            btnBack.Enabled = false;


            if ((string.IsNullOrEmpty(cboYear.Text) || cboTerm.SelectedValue == null || cboExamType.SelectedValue == null || lstTargetClasses.Items.Count == 0))
            {
                btnNext.Enabled = false;
            }
            else
            {
                btnNext.Enabled = true;
            }
                
        }

        void RegisterExamsWizard_OnExamPeriodChanged(object sender, ExamHandlerEventArgs e)
        {
            //throw new NotImplementedException();
        }

        #region "Custom Methods"
        private void AddTabPage(TabPage tabpage)
        {
            tabControl1.TabPages.Add(tabpage);
        }

        private void RemoveTabPage(TabPage tabpage)
        {
            tabControl1.TabPages.Remove(tabpage);
        }
        #endregion "Custom Methods"

        //private void btnNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    errorProvider1.Clear();

        //    switch (tabControl1.SelectedTab.Name)
        //    {
        //        case "tabPage1":
        //            if (IsExamValid())
        //            {
        //                AddTabPage(tabPage3);                        
        //                tabControl1.SelectedTab = tabPage3;
        //                RemoveTabPage(tabPage1);
        //                btnBack.Enabled = true;
        //                btnNext.Enabled = true;
        //            }
        //            break;
        //        case "tabPage3":
        //            if (IsExamSubjectsValid())
        //            {
        //                AddTabPage(tabPage2);
        //                foreach (SchoolClass s in lstTargetClasses.Items)
        //                {
        //                    observableTransactions.Add(s);
        //                }
        //                tabControl1.SelectedTab = tabPage2;
        //                RemoveTabPage(tabPage3);
        //                btnBack.Enabled = true;
        //                btnNext.Enabled = false;
        //            }
        //            break;
        //    }
        //}

        //private void btnBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{

        //    switch (tabControl1.SelectedTab.Name)
        //    {
        //        case "tabPage2":
        //              AddTabPage(tabPage3);
        //                tabControl1.SelectedTab = tabPage3;
        //                RemoveTabPage(tabPage2);
        //                btnBack.Enabled = true;
        //                btnNext.Enabled = true;
                    
        //            break;
        //        case "tabPage3":
        //            AddTabPage(tabPage1);
        //            tabControl1.SelectedTab = tabPage1;
        //            RemoveTabPage(tabPage3);
        //            btnBack.Enabled = false;
        //            btnNext.Enabled = true;
        //            break;
        //    }
            

        //}

        private void btnCancel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void btnAddSingleClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!TargetClasses.Contains(lstSourceClasses.SelectedItem))
            {
                TargetClasses.Add((SchoolClass)lstSourceClasses.SelectedItem);
                SourceClasses.Remove((SchoolClass)lstSourceClasses.SelectedItem);
            }
        }

        private void btnRemoveSingleClass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             if (lstTargetClasses.SelectedIndex != -1)
                {
                    SourceClasses.Add((SchoolClass)lstSourceClasses.SelectedItem);
                    TargetClasses.Remove((SchoolClass)lstSourceClasses.SelectedItem);
                }

        }

        //private void btnAddAllClasses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    foreach (SchoolClass s in lstSourceClasses.Items)
        //    {
        //        if (!lstTargetClasses.Items.Contains(s))
        //        {
        //            lstTargetClasses.Items.Add(s);
        //        }

        //    }
        //}

        //private void btnRemoveAllClasses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        //{
        //    lstTargetClasses.Items.Clear();
        //}


        #region "Validation"
        //private bool IsExamSubjectsValid()
        //{
        //    bool noerror = true;
        //    if (lstTargetSubjects.Items.Count == 0)
        //    {
        //        errorProvider1.Clear();
        //        errorProvider1.SetError(lstTargetSubjects, "Select Subjects doing Exams during the set Period!");
        //        return false;
        //    }
        //    return noerror;
        //}


        private bool IsExamValid()
        {
            bool noerror = true;

            if (string.IsNullOrEmpty(cboYear.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboYear, "Year cannot be Null!");
                return false;
            }
            if (cboTerm.SelectedValue == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboTerm, "Select Term!");
                return false;
            }
            if (cboExamType.SelectedValue == null)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboExamType, "Select Exam Type!");
                return false;
            }
            if (lstTargetClasses.Items.Count == 0)
            {
                errorProvider1.Clear();
                errorProvider1.SetError(lstTargetClasses, "Select Classes doing Exams during the set  Period!");
                return false;
            }
            return noerror;
        }
        #endregion "Validation"

       
        private void listBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selectedclass = Convert.ToString(listBoxClasses.SelectedValue);
            //studentsinclassQuery = context.Students.Where(i => i.CurrentClass == selectedclass).OrderBy(i => i.StudentSurName);
            //StudentsbindingSource.DataSource = studentsinclassQuery;
            //lstStudents.DataSource = StudentsbindingSource;
            //lstStudents.ValueMember = "Id";
            //lstStudents.DisplayMember = "StudentSurName";

        }

     
       

        private void cbSelectedClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the selected class
            //lbclasses = Classrep.getclasssubjects(selectedclass)
            //
            
        }


        private void lnkAddSingleSubject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbClassSubjects.SelectedIndex != -1)
            {
                SourceClassSubjects.Add((ClassSubject)lstSourceClasses.SelectedItem);
                TargetClassSubjects.Remove((ClassSubject)lstSourceClasses.SelectedItem);

                
            }
        }

        private void lnkRemoveSingleSubject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lbTargetSubjects.SelectedIndex != -1)
            {
                TargetClassSubjects.Add((ClassSubject)lstSourceClasses.SelectedItem);
                SourceClassSubjects.Remove((ClassSubject)lstSourceClasses.SelectedItem);
            }

        }

        private void RegenerateRegisteredItems()
        {
            TargetRegisteredExams.Clear();
            foreach (var cs in SourceClassSubjects)
            {
                RegisteredExam r = new RegisteredExam();

                r.ExamDate = DateTime.Now;
                r.ExamType = (int?) cboExamType.SelectedValue;
                r.Subject = cs.SubjectCode;
                r.Class = cs.ClassId;

                TargetRegisteredExams.Add(r);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var cs in TargetRegisteredExams)
            {
                rep.AddNewRegisteredExam(cs);
 
            }
        }

        private void btnNext_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Navigate("F");
        }

        private void Navigate(string Direction)
        {
            switch (Direction)
            {
                case "F" :
                    switch (currentTab.Name)
                    { 
                        case "tabPageEnd":
                            break;
                        case "tabPageStart":
                            currentTab = tabControl1.TabPages[1];
                            break;
                        case "tabPageClassSubjects":
                            currentTab = tabControl1.TabPages[2];
                            RegenerateRegisteredItems();
                            break;
                        default:
                            currentTab = tabControl1.TabPages[0];
                            break;
                    }
                    break;

                case "B":
                    switch (currentTab.Name)
                    {
                        case "tabPageEnd":
                            currentTab = tabControl1.TabPages[1];
                            break;
                        case "tabPageStart":
                            break;
                        case "tabPageClassSubjects":
                            currentTab = tabControl1.TabPages[0];
                            break;
                        default:
                            currentTab = tabControl1.TabPages[0];
                            break;
                    }
                    break;

                default :
                    currentTab = tabControl1.TabPages[0];
                    break;
            }

            foreach (TabPage t in tabControl1.TabPages)
            {
                if (!t.Equals(currentTab))
                {
                    tabControl1.TabPages.Remove(t); 
                }
            }
        }

        private void btnregisterAllStudentsforAllSubjects_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void btnAddAllClasses_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void lbClassSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }


    }


    public class ExamHandlerEventArgs : System.EventArgs
    {
        // add local member variables to hold text
        private int _year;
        private int _term;

        // class constructor
        public ExamHandlerEventArgs(int Year, int Term)
        {
            this._year = Year;
            this._term = Term;
        }


    }

}