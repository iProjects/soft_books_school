namespace WinSBSchool.Forms
{
    partial class ExamTreeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamTreeForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeViewExamResults = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loadExamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelStudentResults = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkUseCurrentExam = new System.Windows.Forms.CheckBox();
            this.chkContribution = new System.Windows.Forms.CheckBox();
            this.cbExamTypes = new System.Windows.Forms.ComboBox();
            this.btnLoadExamPeriod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSourceExamTypes = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExpandAll = new System.Windows.Forms.LinkLabel();
            this.btnCollapseAll = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bindingSourceStudentResults = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExamTypes)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStudentResults)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(980, 304);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(972, 278);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Exam Results";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 63);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelStudentResults);
            this.splitContainer1.Size = new System.Drawing.Size(966, 212);
            this.splitContainer1.SplitterDistance = 333;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.treeViewExamResults);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(333, 212);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // treeViewExamResults
            // 
            this.treeViewExamResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewExamResults.CheckBoxes = true;
            this.treeViewExamResults.ContextMenuStrip = this.contextMenuStrip1;
            this.treeViewExamResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewExamResults.FullRowSelect = true;
            this.treeViewExamResults.HideSelection = false;
            this.treeViewExamResults.Location = new System.Drawing.Point(3, 16);
            this.treeViewExamResults.Name = "treeViewExamResults";
            this.treeViewExamResults.ShowNodeToolTips = true;
            this.treeViewExamResults.Size = new System.Drawing.Size(327, 193);
            this.treeViewExamResults.TabIndex = 1;
            this.treeViewExamResults.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewExamResults_AfterCheck);
            this.treeViewExamResults.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewExamResults_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadExamToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(127, 26);
            // 
            // loadExamToolStripMenuItem
            // 
            this.loadExamToolStripMenuItem.Name = "loadExamToolStripMenuItem";
            this.loadExamToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.loadExamToolStripMenuItem.Text = "Load Exam";
            this.loadExamToolStripMenuItem.Click += new System.EventHandler(this.btnLoadExamPeriod_Click);
            // 
            // panelStudentResults
            // 
            this.panelStudentResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStudentResults.Location = new System.Drawing.Point(0, 0);
            this.panelStudentResults.Name = "panelStudentResults";
            this.panelStudentResults.Size = new System.Drawing.Size(629, 212);
            this.panelStudentResults.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(966, 212);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkUseCurrentExam);
            this.panel1.Controls.Add(this.chkContribution);
            this.panel1.Controls.Add(this.cbExamTypes);
            this.panel1.Controls.Add(this.btnLoadExamPeriod);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(966, 60);
            this.panel1.TabIndex = 0;
            // 
            // chkUseCurrentExam
            // 
            this.chkUseCurrentExam.AutoSize = true;
            this.chkUseCurrentExam.Checked = true;
            this.chkUseCurrentExam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseCurrentExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUseCurrentExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUseCurrentExam.Location = new System.Drawing.Point(174, 13);
            this.chkUseCurrentExam.Name = "chkUseCurrentExam";
            this.chkUseCurrentExam.Size = new System.Drawing.Size(260, 17);
            this.chkUseCurrentExam.TabIndex = 4;
            this.chkUseCurrentExam.Text = "Using Current Exam (uncheck to use other Exams)";
            this.chkUseCurrentExam.UseVisualStyleBackColor = true;
            this.chkUseCurrentExam.CheckedChanged += new System.EventHandler(this.chkUseCurrentExam_CheckedChanged);
            // 
            // chkContribution
            // 
            this.chkContribution.AutoSize = true;
            this.chkContribution.Checked = true;
            this.chkContribution.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkContribution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkContribution.Location = new System.Drawing.Point(493, 13);
            this.chkContribution.Name = "chkContribution";
            this.chkContribution.Size = new System.Drawing.Size(163, 17);
            this.chkContribution.TabIndex = 3;
            this.chkContribution.Text = "Show contributing exams only";
            this.chkContribution.UseVisualStyleBackColor = true;
            // 
            // cbExamTypes
            // 
            this.cbExamTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExamTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbExamTypes.FormattingEnabled = true;
            this.cbExamTypes.Location = new System.Drawing.Point(689, 9);
            this.cbExamTypes.Name = "cbExamTypes";
            this.cbExamTypes.Size = new System.Drawing.Size(206, 21);
            this.cbExamTypes.TabIndex = 2;
            // 
            // btnLoadExamPeriod
            // 
            this.btnLoadExamPeriod.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnLoadExamPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadExamPeriod.Location = new System.Drawing.Point(18, 13);
            this.btnLoadExamPeriod.Name = "btnLoadExamPeriod";
            this.btnLoadExamPeriod.Size = new System.Drawing.Size(75, 23);
            this.btnLoadExamPeriod.TabIndex = 1;
            this.btnLoadExamPeriod.Text = "Load Exam Period";
            this.btnLoadExamPeriod.UseVisualStyleBackColor = false;
            this.btnLoadExamPeriod.Click += new System.EventHandler(this.btnLoadExamPeriod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Browse Exam Period ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExpandAll);
            this.groupBox1.Controls.Add(this.btnCollapseAll);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 323);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 50);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnExpandAll
            // 
            this.btnExpandAll.AutoSize = true;
            this.btnExpandAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnExpandAll.LinkColor = System.Drawing.Color.Yellow;
            this.btnExpandAll.Location = new System.Drawing.Point(10, 16);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(84, 17);
            this.btnExpandAll.TabIndex = 35;
            this.btnExpandAll.TabStop = true;
            this.btnExpandAll.Text = "Expand All";
            this.btnExpandAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnExpandAll_LinkClicked);
            // 
            // btnCollapseAll
            // 
            this.btnCollapseAll.AutoSize = true;
            this.btnCollapseAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnCollapseAll.LinkColor = System.Drawing.Color.Yellow;
            this.btnCollapseAll.Location = new System.Drawing.Point(100, 16);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(93, 17);
            this.btnCollapseAll.TabIndex = 34;
            this.btnCollapseAll.TabStop = true;
            this.btnCollapseAll.Text = "Collapse All";
            this.btnCollapseAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCollapseAll_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(899, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(986, 323);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // ExamTreeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(986, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExamTreeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exam  Results";
            this.Load += new System.EventHandler(this.ExamTreeForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExamTypes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceStudentResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLoadExamPeriod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbExamTypes;
        private System.Windows.Forms.BindingSource bindingSourceExamTypes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.BindingSource bindingSourceStudentResults;
        private System.Windows.Forms.Panel panelStudentResults;
        private System.Windows.Forms.CheckBox chkContribution;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem loadExamToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeViewExamResults;
        private System.Windows.Forms.CheckBox chkUseCurrentExam;
        private System.Windows.Forms.LinkLabel btnExpandAll;
        private System.Windows.Forms.LinkLabel btnCollapseAll;

    }
}