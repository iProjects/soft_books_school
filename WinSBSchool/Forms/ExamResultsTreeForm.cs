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
using System.Xml;
using System.Xml.Schema;
using WinSBSchool.Controls;

namespace WinSBSchool.Forms
{
    public partial class ExamTreeForm : Form
    {
        #region "Private Fields"
        string user;
        SBSchoolDBEntities db;
        string connection;
        int currentExamPeriod;
        string currentExamPeriodStr;
        List<int> ids = new List<int>();
        bool busy = false;
        #endregion "Private Fields"

        #region "Constructor"
        public ExamTreeForm(string _user, string Conn)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;

            db = new SBSchoolDBEntities(connection);

            user = _user;
        }
        #endregion "Constructor"

        #region "Private Methods"
        public void PopulateTreeWithClasses(TreeNode node)
        {
            try
            {
                List<SchoolClass> cls = db.SchoolClasses.Where (i=>i.IsDeleted==false && i.Status=="A").ToList();
                foreach (SchoolClass cl in cls)
                {
                    ExamNode i = new ExamNode(cl.Id.ToString(),
                                              "SchoolClasses",
                                              cl);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = cl.ClassName;
                    node.Nodes.Add(clnode);

                    PopulateTreeWithExams(clnode, cl);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeWithExams(TreeNode node, SchoolClass cl)
        {
            try
            {
                List<Exam> Exams = (db.Exams
                    .Where(i => i.IsDeleted == false && i.Enabled == true && i.Processed==true)
                    .Where(sub => sub.ClassId == cl.Id)
                    .Where(sub => sub.ExamPeriodId == currentExamPeriod)
                    .OrderBy(sub => sub.Subject.ShortCode)
                                       ).ToList();
                foreach (Exam exam in Exams)
                {
                    ExamNode i = new ExamNode(exam.Id.ToString(),
                                                  "Exams",
                                                  exam);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = exam.SubjectShortCode;
                    node.Nodes.Add(clnode);

                    PopulateTreeWithRegisteredExams(clnode, exam);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void PopulateTreeWithRegisteredExams(TreeNode node, Exam exam)
        {
            try
            {
                List<RegisteredExam> Examds = (db.RegisteredExams.Include("ExamType")
                    .Where(sub => sub.ExamId == exam.Id)
                    .Where(sub => sub.Status == "A" && sub.IsDeleted==false)
                     .OrderBy(sub => sub.ExamType.Description)
                    ).ToList();

                foreach (RegisteredExam rgdExam in Examds)
                {
                    ExamNode i = new ExamNode(rgdExam.Id.ToString(),
                                                  "RegisteredExams",
                                                  rgdExam);
                    TreeNode clnode = new TreeNode();
                    clnode.Tag = i;
                    clnode.Text = rgdExam.ExamType.Description;
                    node.Nodes.Add(clnode);
                    //groupBox3.Text = node.Nodes.Count.ToString();
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void sepf_OnExamPeriodListSelected(object sender, ExamPeriodSelectEventArgs e)
        {
            try
            {
                SetExamPeriod(e._ExamPeriod);

                BuildTree();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        private void SetExamPeriod(ExamPeriod _ExamPeriod)
        {
            try
            {
                if (_ExamPeriod != null)
                {
                    currentExamPeriod = _ExamPeriod.Id;
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnLoadExamPeriod_Click(object sender, EventArgs e)
        {
            try
            {
                /*Pick an _Exam period*/
                SearchExamPeriodsSimpleForm sepf = new SearchExamPeriodsSimpleForm(connection) { Owner = this };
                sepf.OnExamPeriodListSelected += new SearchExamPeriodsSimpleForm.ExamPeriodSelectHandler(sepf_OnExamPeriodListSelected);
                sepf.ShowDialog();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        public void BuildTree()
        {
            try
            {
                treeViewExamResults.Nodes.Clear(); // Clear any existing items
                treeViewExamResults.BeginUpdate(); // prevent overhead and flicker
                ExamPeriod s = (from n in db.ExamPeriods.Where(i => i.Id == currentExamPeriod)
                                select n).FirstOrDefault();
                TreeNode root = new TreeNode();
                if (s != null)
                {
                    currentExamPeriodStr = "EXP_" + currentExamPeriod;
                    ExamNode i = new ExamNode
                    {
                        Key = currentExamPeriod.ToString(),
                        Table = "ExamPeriod",
                        Item = s
                    };
                    root.Text = s.Description;
                    root.Tag = i;

                    PopulateTreeWithClasses(root);
                    treeViewExamResults.Nodes.Add(root);

                }
                treeViewExamResults.EndUpdate(); // re-enable the tree
                treeViewExamResults.Refresh(); // refresh the treeview display
                treeViewExamResults.ExpandAll(); // expand all nodes
                if (treeViewExamResults.Nodes.Count > 0)
                {
                    // Select the root node
                    treeViewExamResults.SelectedNode = treeViewExamResults.Nodes[0];
                }
                int count = treeViewExamResults.GetNodeCount(true);
                groupBox3.Text =  count.ToString();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex); 
            }
        }
        private void ExamTreeForm_Load(object sender, EventArgs e)
        {
            try
            {
                bindingSourceExamTypes.DataSource = db.ExamTypes.Where(i => i.IsDeleted == false && i.Status == "A").ToList();
                cbExamTypes.DisplayMember = "Description";
                cbExamTypes.ValueMember = "Id";
                cbExamTypes.DataSource = bindingSourceExamTypes;

                cbExamTypes.Visible = false;
                chkContribution.Visible = false;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void treeViewExamResults_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ExamPeriodClass _ExamPeriodClass = new ExamPeriodClass();
                // Get the node that was Selected
                TreeNode selectedNode = e.Node;
                if (selectedNode != null)
                {
                    ExamNode enode = (ExamNode)selectedNode.Tag;
                    switch (enode.Table)
                    {
                        case "ExamPeriod":
                            ExamPeriod _ExamPeriod = (ExamPeriod)enode.Item;
                            _ExamPeriodClass.ExamPeriod = _ExamPeriod.Id;
                            this.panelStudentResults.Controls.Clear();
                            break;
                        case "RegisteredExams":
                            RegisteredExam rgdExam = (RegisteredExam)enode.Item;
                            ExamTypeResultsUserControl reuc = new ExamTypeResultsUserControl(rgdExam, chkContribution.Checked, chkUseCurrentExam.Checked, user, connection);
                            reuc.Dock = DockStyle.Fill; this.panelStudentResults.Controls.Clear(); this.panelStudentResults.Controls.Add(reuc);
                            break;
                        case "Exams":
                            Exam _exam = (Exam)enode.Item;
                            SubjectResultsUserControl euc = new SubjectResultsUserControl(_exam, chkContribution.Checked, chkUseCurrentExam.Checked, user, connection);
                            euc.Dock = DockStyle.Fill; this.panelStudentResults.Controls.Clear(); this.panelStudentResults.Controls.Add(euc);
                            break;
                        case "SchoolClasses": //E.g.Year1, Term1, All ExamTypes(CAT 1 + CAT 2 + Main results)
                            SchoolClass _SchoolClass = (SchoolClass)enode.Item;
                            string parent = selectedNode.Parent.Text;
                            var examperiodquery = (from ep in db.ExamPeriods
                                                   where ep.Status=="A"
                                                   where ep.IsDeleted==false
                                                   where ep.Description == parent
                                                   select ep).FirstOrDefault();
                            ExamPeriod _examPeriod = examperiodquery;
                            _ExamPeriodClass.ClassId = _SchoolClass.Id;
                            _ExamPeriodClass.ExamPeriod = _examPeriod.Id;
                            ClassResultsUserControl f = new ClassResultsUserControl(_ExamPeriodClass, chkContribution.Checked, chkUseCurrentExam.Checked, user, connection);
                            f.Dock = DockStyle.Fill;
                            this.panelStudentResults.Controls.Clear();
                            this.panelStudentResults.Controls.Add(f);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void CreateIdList(int ParentId, List<int> Ids)
        {
            try
            {
                List<int> ChildIds = (from i in db.COAs
                                      where i.Parent == ParentId
                                      select i.Id).ToList();
                Ids.Add(ParentId);
                foreach (int child in ChildIds)
                {
                    CreateIdList(child, Ids);
                }
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkUseCurrentExam_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chkUseCurrentExam.Checked)
                {
                    chkUseCurrentExam.Text = "Using Current Exams (click to use closed Exams)";
                }
                else
                {
                    chkUseCurrentExam.Text = "Using Closed Exams (click to use current Exams)";
                }
            }
            catch (Exception ex)
            {
                Utils.LogEventViewer(ex);
            }
        }
        private void treeViewExamResults_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (busy) return;
            busy = true;
            try
            {
                checkNodes(e.Node, e.Node.Checked);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
            finally
            {
                busy = false;
            }
        }
        private void checkNodes(TreeNode node, bool check)
        {
            foreach (TreeNode child in node.Nodes)
            {
                child.Checked = check;
                checkNodes(child, check);
            }
        }
        private void btnExpandAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                treeViewExamResults.ExpandAll();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnCollapseAll_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                treeViewExamResults.CollapseAll();
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        } 
        #endregion "Private Methods"
    }

    public class ExamNode
    {
        public string Key { get; set; }
        public string Table { get; set; }
        public object Item { get; set; }

        public ExamNode()
        {

        }
        public ExamNode(string key, string table, object payload)
        {
            this.Key = key;
            this.Table = table;
            this.Item = payload;
        }
    }
    public class ExamPeriodClass
    {
        public int ClassId { get; set; }
        public int ExamPeriod { get; set; }
        public ExamPeriodClass()
        {

        }
        public ExamPeriodClass(int classId, int examPeriod)
        {
            this.ClassId = classId;
            this.ExamPeriod = examPeriod;

        }
    }

}