using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CommonLib;
using DAL;

namespace WinSBSchool.Forms
{
    public partial class ProcessExamsForm : Form
    {

        SBSchoolDBEntities db;
        Repository rep;
        string user;
        string connection;
        ExamPeriod ep;

        public ProcessExamsForm(string s, string Conn)
        {
            InitializeComponent();
            user = s;

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
            rep = new Repository(connection);
            db = new SBSchoolDBEntities(connection);
        }
        private void ProcessExamsForm_Load(object sender, EventArgs e)
        {

            try
            {
                var exmtyps = from et in db.ExamTypes
                              select et;
                List<ExamType> examtypes = exmtyps.ToList();

                bindingSourceExamTypes.DataSource = examtypes;

                DataGridViewComboBoxColumn colCboxExamTypes = new DataGridViewComboBoxColumn();
                colCboxExamTypes.HeaderText = "Exam Type";
                colCboxExamTypes.Name = "cbExamTypes";
                colCboxExamTypes.DataSource = bindingSourceExamTypes;
                // The display member is the name column in the column datasource  
                colCboxExamTypes.DisplayMember = "Description";
                // The DataPropertyName refers to the foreign key column on the datagridview datasource
                colCboxExamTypes.DataPropertyName = "ExamTypeId";
                // The value member is the primary key of the parent table  
                colCboxExamTypes.ValueMember = "Id";
                colCboxExamTypes.MaxDropDownItems = 10;
                colCboxExamTypes.Width = 100;
                colCboxExamTypes.DisplayIndex = 2;
                colCboxExamTypes.MinimumWidth = 100;
                colCboxExamTypes.FlatStyle = FlatStyle.Flat;
                colCboxExamTypes.DefaultCellStyle.NullValue = "--- Select ---";
                colCboxExamTypes.ReadOnly = true;
                if (!this.dataGridViewExamPeriods.Columns.Contains("cbExamTypes"))
                {
                    dataGridViewExamPeriods.Columns.Add(colCboxExamTypes);
                }


                //load all _examTypesquery not closed
                List<ExamPeriod> openExams = this.GetExamPeriods(ExaminationState.Open);

                bindingSourceExamPeriods.DataSource = openExams;
                this.dataGridViewExamPeriods.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewExamPeriods.AutoGenerateColumns = false;
                dataGridViewExamPeriods.DataSource = bindingSourceExamPeriods;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public List<ExamPeriod> GetExamPeriods(ExaminationState pstate)
        {
            if (pstate == ExaminationState.OpenProcessed)
            {
                return rep.GetExamPeriods(true, true);
            }
            else if (pstate == ExaminationState.OpenNotProcessed)
            {
                return rep.GetExamPeriods(true, false);
            }
            else if (pstate == ExaminationState.NotOpenProcessed)
            {
                return rep.GetExamPeriods(false, true);
            }
            else if (pstate == ExaminationState.NotOpenNotProcessed)
            {
                return rep.GetExamPeriods(false, true);
            }
            else if (pstate == ExaminationState.Open)
            {
                return rep.GetOpenExamPeriods(true);
            }
            else if (pstate == ExaminationState.Closed)
            {
                return rep.GetOpenExamPeriods(false);
            }
            else if (pstate == ExaminationState.Processed)
            {
                return rep.GetProcessedExamPeriods(true);
            }
            else if (pstate == ExaminationState.NotProcessed)
            {
                return rep.GetProcessedExamPeriods(false);
            }
            else //ColumnDefault is not processed
            {
                return rep.GetProcessedExamPeriods(false);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCloseExamination_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewExamPeriods.SelectedRows.Count != 0)
                {
                    ep = (ExamPeriod)bindingSourceExamPeriods.Current;
                    //if (ep.Closed)
                    //{
                    //    if (DialogResult.Yes == MessageBox.Show("Are you sure you want to Close this ExamType?", "Confirm Close", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    //    {
                    //        // Todo close the school here
                    //        //CSchool cp = new CSchool();
                    //        //cp.ArchiveSchool(pay.Period, pay.Year);

                    //        // Todo code for removing record from the payslipmaster
                    //        RefreshSubjectsGrid();
                    //    }
                    //}
                    //else
                    //{
                    //    MessageBox.Show("You are not allowed to close a non Processed ExamType!");
                    //}
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnProcessExamination_Click(object sender, EventArgs e)
        {
            if (dataGridViewExamPeriods.SelectedRows.Count != 0)
            {
                try
                {
                    ExamPeriod ep = (ExamPeriod)bindingSourceExamPeriods.Current;

                    var _exam_type = (from et in db.ExamTypes
                                      where et.Id == ep.Id
                                      select et).FirstOrDefault();

                    ExamType _ExamType = _exam_type;

                    string examtypeshortcode = _ExamType.ShortCode.Trim();

                    // see if the StudentProgresses_Temp has records and they are for this ExamPeriod
                    //if not, decline processing
                    //set up
                    int termwc = 0;
                    int yearWc = 0;
                    string examtypeshortcodewc = null;

                    if (!rep.WorkingCopyNotClosed(ref termwc, ref yearWc, ref examtypeshortcodewc))
                    {
                        bool simulateRun = false;
                        ProcessExamNow(ep.Term, ep.Year, ep.Id, simulateRun);

                        //pay.DateRun = DateTime.Now.Date;
                        //pay.RunBy =user;

                        //rep.Update_Exam_DateRun(pay);
                    }

                    else if (examtypeshortcodewc == examtypeshortcode)
                    {
                        if (DialogResult.Yes == MessageBox.Show("Exam already processed! \nDo you wish to overwrite?", "Confirm Overwrite", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            bool simulateRun = true;
                            ProcessExamNow(ep.Term, ep.Year, ep.Id, simulateRun);

                            //pay.DateRun = DateTime.Now.Date;
                            //pay.RunBy = user;

                            //rep.Update_Exam_DateRun(pay);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must close the previously Processed Exam before proceeding");
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                    return;
                }
            }
        }
        private void ProcessExamNow(int term, int year, int ExamTypeId, bool simulateRun)
        {

            var ttlstdnts = from st in db.Students
                            select st;
            List<Student> totalstudets = ttlstdnts.ToList();

            pbStatus.Minimum = 0;
            pbStatus.Maximum = totalstudets.Count();

            lstProcessResults.Items.Clear();

            CExams cp = new CExams(user, connection);

            //subscribe to the events
            cp.OnCompleteGenerateExams += new CExams.ExamsCompleteEventHandler(cp_OnCompleteGenerateExam);

            string sError = string.Empty;

            //cp.RunExams(simulateRun, term, year, ExamTypeId, ref sError);
            rep.MarkExamPeriodAsProcessed(term, year, ExamTypeId);

            if (sError != "")
            {
                Log.WriteToErrorLogFile(new Exception(sError));
            };
            MessageBox.Show("Successfully run");
            RefreshGrid();
        }
        //Handle the event
        private void cp_OnCompleteGenerateExam(object sender, ExamCompleteEventArg e)
        {
            pbStatus.Value = e.StatusValue;
            lstProcessResults.Items.Add(e.ErrorMsg);
        }
        public void RefreshGrid()
        {
            bindingSourceExamPeriods.DataSource = null;
            List<ExamPeriod> openExams = this.GetExamPeriods(ExaminationState.Open);
            bindingSourceExamPeriods.DataSource = openExams;

        }
    }
}
