namespace WinSchool.Forms
{
    partial class RegisterExamsWizardOld
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageStart = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveAllClasses = new System.Windows.Forms.LinkLabel();
            this.lstTargetClasses = new System.Windows.Forms.ListBox();
            this.btnRemoveSingleClass = new System.Windows.Forms.LinkLabel();
            this.lstSourceClasses = new System.Windows.Forms.ListBox();
            this.btnAddAllClasses = new System.Windows.Forms.LinkLabel();
            this.btnAddSingleClass = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnregisterAllStudentsforAllSubjects = new System.Windows.Forms.LinkLabel();
            this.cboExamType = new System.Windows.Forms.ComboBox();
            this.cboTerm = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageClassSubjects = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSelectedClasses = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lnkRemoveAllSubjects = new System.Windows.Forms.LinkLabel();
            this.lbTargetSubjects = new System.Windows.Forms.ListBox();
            this.lnkRemoveSingleSubject = new System.Windows.Forms.LinkLabel();
            this.lbClassSubjects = new System.Windows.Forms.ListBox();
            this.lnkAddAllSubjects = new System.Windows.Forms.LinkLabel();
            this.lnkAddSingleSubject = new System.Windows.Forms.LinkLabel();
            this.tabPageEnd = new System.Windows.Forms.TabPage();
            this.btnRegisterExam = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Term = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Class = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Room = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack = new System.Windows.Forms.LinkLabel();
            this.btnNext = new System.Windows.Forms.LinkLabel();
            this.btnCancel = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.StudentsbindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageStart.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPageClassSubjects.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPageEnd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsbindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 497);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(755, 54);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageStart);
            this.tabControl1.Controls.Add(this.tabPageClassSubjects);
            this.tabControl1.Controls.Add(this.tabPageEnd);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(755, 497);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPageStart
            // 
            this.tabPageStart.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageStart.Controls.Add(this.label4);
            this.tabPageStart.Controls.Add(this.groupBox2);
            this.tabPageStart.Controls.Add(this.groupBox1);
            this.tabPageStart.Location = new System.Drawing.Point(4, 22);
            this.tabPageStart.Name = "tabPageStart";
            this.tabPageStart.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStart.Size = new System.Drawing.Size(747, 471);
            this.tabPageStart.TabIndex = 0;
            this.tabPageStart.Text = "Examination  Period";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(97, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(356, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Select Classes doing Exams during the set  Period";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveAllClasses);
            this.groupBox2.Controls.Add(this.lstTargetClasses);
            this.groupBox2.Controls.Add(this.btnRemoveSingleClass);
            this.groupBox2.Controls.Add(this.lstSourceClasses);
            this.groupBox2.Controls.Add(this.btnAddAllClasses);
            this.groupBox2.Controls.Add(this.btnAddSingleClass);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(-4, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(743, 335);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnRemoveAllClasses
            // 
            this.btnRemoveAllClasses.AutoSize = true;
            this.btnRemoveAllClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAllClasses.Location = new System.Drawing.Point(280, 204);
            this.btnRemoveAllClasses.Name = "btnRemoveAllClasses";
            this.btnRemoveAllClasses.Size = new System.Drawing.Size(48, 31);
            this.btnRemoveAllClasses.TabIndex = 6;
            this.btnRemoveAllClasses.TabStop = true;
            this.btnRemoveAllClasses.Text = "<<";
            // 
            // lstTargetClasses
            // 
            this.lstTargetClasses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTargetClasses.FormattingEnabled = true;
            this.lstTargetClasses.ItemHeight = 16;
            this.lstTargetClasses.Location = new System.Drawing.Point(334, 18);
            this.lstTargetClasses.Name = "lstTargetClasses";
            this.lstTargetClasses.Size = new System.Drawing.Size(353, 306);
            this.lstTargetClasses.TabIndex = 0;
            // 
            // btnRemoveSingleClass
            // 
            this.btnRemoveSingleClass.AutoSize = true;
            this.btnRemoveSingleClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveSingleClass.Location = new System.Drawing.Point(286, 159);
            this.btnRemoveSingleClass.Name = "btnRemoveSingleClass";
            this.btnRemoveSingleClass.Size = new System.Drawing.Size(31, 31);
            this.btnRemoveSingleClass.TabIndex = 5;
            this.btnRemoveSingleClass.TabStop = true;
            this.btnRemoveSingleClass.Text = "<";
            this.btnRemoveSingleClass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRemoveSingleClass_LinkClicked);
            // 
            // lstSourceClasses
            // 
            this.lstSourceClasses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSourceClasses.FormattingEnabled = true;
            this.lstSourceClasses.ItemHeight = 16;
            this.lstSourceClasses.Location = new System.Drawing.Point(10, 18);
            this.lstSourceClasses.Name = "lstSourceClasses";
            this.lstSourceClasses.Size = new System.Drawing.Size(263, 306);
            this.lstSourceClasses.TabIndex = 0;
            // 
            // btnAddAllClasses
            // 
            this.btnAddAllClasses.AutoSize = true;
            this.btnAddAllClasses.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAllClasses.Location = new System.Drawing.Point(280, 122);
            this.btnAddAllClasses.Name = "btnAddAllClasses";
            this.btnAddAllClasses.Size = new System.Drawing.Size(48, 31);
            this.btnAddAllClasses.TabIndex = 4;
            this.btnAddAllClasses.TabStop = true;
            this.btnAddAllClasses.Text = ">>";
            this.btnAddAllClasses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddAllClasses_LinkClicked);
            // 
            // btnAddSingleClass
            // 
            this.btnAddSingleClass.AutoSize = true;
            this.btnAddSingleClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSingleClass.Location = new System.Drawing.Point(286, 75);
            this.btnAddSingleClass.Name = "btnAddSingleClass";
            this.btnAddSingleClass.Size = new System.Drawing.Size(31, 31);
            this.btnAddSingleClass.TabIndex = 3;
            this.btnAddSingleClass.TabStop = true;
            this.btnAddSingleClass.Text = ">";
            this.btnAddSingleClass.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddSingleClass_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnregisterAllStudentsforAllSubjects);
            this.groupBox1.Controls.Add(this.cboExamType);
            this.groupBox1.Controls.Add(this.cboTerm);
            this.groupBox1.Controls.Add(this.cboYear);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(741, 99);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set  Exam Period";
            // 
            // btnregisterAllStudentsforAllSubjects
            // 
            this.btnregisterAllStudentsforAllSubjects.AutoEllipsis = true;
            this.btnregisterAllStudentsforAllSubjects.AutoSize = true;
            this.btnregisterAllStudentsforAllSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnregisterAllStudentsforAllSubjects.Location = new System.Drawing.Point(380, 73);
            this.btnregisterAllStudentsforAllSubjects.Name = "btnregisterAllStudentsforAllSubjects";
            this.btnregisterAllStudentsforAllSubjects.Size = new System.Drawing.Size(245, 15);
            this.btnregisterAllStudentsforAllSubjects.TabIndex = 7;
            this.btnregisterAllStudentsforAllSubjects.TabStop = true;
            this.btnregisterAllStudentsforAllSubjects.Text = "Register All Students For All Subjects";
            this.btnregisterAllStudentsforAllSubjects.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnregisterAllStudentsforAllSubjects_LinkClicked);
            // 
            // cboExamType
            // 
            this.cboExamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExamType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboExamType.FormattingEnabled = true;
            this.cboExamType.Location = new System.Drawing.Point(396, 19);
            this.cboExamType.Name = "cboExamType";
            this.cboExamType.Size = new System.Drawing.Size(203, 23);
            this.cboExamType.TabIndex = 6;
            // 
            // cboTerm
            // 
            this.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTerm.FormattingEnabled = true;
            this.cboTerm.Location = new System.Drawing.Point(83, 56);
            this.cboTerm.Name = "cboTerm";
            this.cboTerm.Size = new System.Drawing.Size(183, 23);
            this.cboTerm.TabIndex = 5;
            // 
            // cboYear
            // 
            this.cboYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(81, 19);
            this.cboYear.MaxLength = 4;
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(185, 23);
            this.cboYear.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(322, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Exam Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Term";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Year";
            // 
            // tabPageClassSubjects
            // 
            this.tabPageClassSubjects.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageClassSubjects.Controls.Add(this.label8);
            this.tabPageClassSubjects.Controls.Add(this.cbSelectedClasses);
            this.tabPageClassSubjects.Controls.Add(this.groupBox7);
            this.tabPageClassSubjects.Location = new System.Drawing.Point(4, 22);
            this.tabPageClassSubjects.Name = "tabPageClassSubjects";
            this.tabPageClassSubjects.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageClassSubjects.Size = new System.Drawing.Size(747, 471);
            this.tabPageClassSubjects.TabIndex = 3;
            this.tabPageClassSubjects.Text = "Class Subjects";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(60, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Selected Classes";
            // 
            // cbSelectedClasses
            // 
            this.cbSelectedClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelectedClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSelectedClasses.FormattingEnabled = true;
            this.cbSelectedClasses.Location = new System.Drawing.Point(154, 19);
            this.cbSelectedClasses.Name = "cbSelectedClasses";
            this.cbSelectedClasses.Size = new System.Drawing.Size(202, 21);
            this.cbSelectedClasses.TabIndex = 3;
            this.cbSelectedClasses.SelectedIndexChanged += new System.EventHandler(this.cbSelectedClasses_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lnkRemoveAllSubjects);
            this.groupBox7.Controls.Add(this.lbTargetSubjects);
            this.groupBox7.Controls.Add(this.lnkRemoveSingleSubject);
            this.groupBox7.Controls.Add(this.lbClassSubjects);
            this.groupBox7.Controls.Add(this.lnkAddAllSubjects);
            this.groupBox7.Controls.Add(this.lnkAddSingleSubject);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(-4, 68);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(745, 335);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            // 
            // lnkRemoveAllSubjects
            // 
            this.lnkRemoveAllSubjects.AutoSize = true;
            this.lnkRemoveAllSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRemoveAllSubjects.Location = new System.Drawing.Point(304, 211);
            this.lnkRemoveAllSubjects.Name = "lnkRemoveAllSubjects";
            this.lnkRemoveAllSubjects.Size = new System.Drawing.Size(48, 31);
            this.lnkRemoveAllSubjects.TabIndex = 6;
            this.lnkRemoveAllSubjects.TabStop = true;
            this.lnkRemoveAllSubjects.Text = "<<";
            // 
            // lbTargetSubjects
            // 
            this.lbTargetSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTargetSubjects.FormattingEnabled = true;
            this.lbTargetSubjects.ItemHeight = 16;
            this.lbTargetSubjects.Location = new System.Drawing.Point(368, 18);
            this.lbTargetSubjects.Name = "lbTargetSubjects";
            this.lbTargetSubjects.Size = new System.Drawing.Size(329, 306);
            this.lbTargetSubjects.TabIndex = 0;
            // 
            // lnkRemoveSingleSubject
            // 
            this.lnkRemoveSingleSubject.AutoSize = true;
            this.lnkRemoveSingleSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRemoveSingleSubject.Location = new System.Drawing.Point(310, 180);
            this.lnkRemoveSingleSubject.Name = "lnkRemoveSingleSubject";
            this.lnkRemoveSingleSubject.Size = new System.Drawing.Size(31, 31);
            this.lnkRemoveSingleSubject.TabIndex = 5;
            this.lnkRemoveSingleSubject.TabStop = true;
            this.lnkRemoveSingleSubject.Text = "<";
            this.lnkRemoveSingleSubject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRemoveSingleSubject_LinkClicked);
            // 
            // lbClassSubjects
            // 
            this.lbClassSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbClassSubjects.FormattingEnabled = true;
            this.lbClassSubjects.ItemHeight = 16;
            this.lbClassSubjects.Location = new System.Drawing.Point(10, 18);
            this.lbClassSubjects.Name = "lbClassSubjects";
            this.lbClassSubjects.Size = new System.Drawing.Size(263, 306);
            this.lbClassSubjects.TabIndex = 0;
            // 
            // lnkAddAllSubjects
            // 
            this.lnkAddAllSubjects.AutoSize = true;
            this.lnkAddAllSubjects.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddAllSubjects.Location = new System.Drawing.Point(304, 129);
            this.lnkAddAllSubjects.Name = "lnkAddAllSubjects";
            this.lnkAddAllSubjects.Size = new System.Drawing.Size(48, 31);
            this.lnkAddAllSubjects.TabIndex = 4;
            this.lnkAddAllSubjects.TabStop = true;
            this.lnkAddAllSubjects.Text = ">>";
            // 
            // lnkAddSingleSubject
            // 
            this.lnkAddSingleSubject.AutoSize = true;
            this.lnkAddSingleSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAddSingleSubject.Location = new System.Drawing.Point(310, 82);
            this.lnkAddSingleSubject.Name = "lnkAddSingleSubject";
            this.lnkAddSingleSubject.Size = new System.Drawing.Size(31, 31);
            this.lnkAddSingleSubject.TabIndex = 3;
            this.lnkAddSingleSubject.TabStop = true;
            this.lnkAddSingleSubject.Text = ">";
            this.lnkAddSingleSubject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAddSingleSubject_LinkClicked);
            // 
            // tabPageEnd
            // 
            this.tabPageEnd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageEnd.Controls.Add(this.btnRegisterExam);
            this.tabPageEnd.Controls.Add(this.dataGridView1);
            this.tabPageEnd.Location = new System.Drawing.Point(4, 22);
            this.tabPageEnd.Name = "tabPageEnd";
            this.tabPageEnd.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEnd.Size = new System.Drawing.Size(747, 471);
            this.tabPageEnd.TabIndex = 4;
            this.tabPageEnd.Text = "tabPage2";
            // 
            // btnRegisterExam
            // 
            this.btnRegisterExam.AutoSize = true;
            this.btnRegisterExam.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterExam.Location = new System.Drawing.Point(611, 430);
            this.btnRegisterExam.Name = "btnRegisterExam";
            this.btnRegisterExam.Size = new System.Drawing.Size(124, 31);
            this.btnRegisterExam.TabIndex = 8;
            this.btnRegisterExam.TabStop = true;
            this.btnRegisterExam.Text = "Register";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Year,
            this.Term,
            this.Class,
            this.Subject,
            this.Room,
            this.ExamDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(8, 23);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(731, 399);
            this.dataGridView1.TabIndex = 7;
            // 
            // Year
            // 
            this.Year.HeaderText = "Year";
            this.Year.Name = "Year";
            // 
            // Term
            // 
            this.Term.HeaderText = "Term";
            this.Term.Name = "Term";
            // 
            // Class
            // 
            this.Class.HeaderText = "Class";
            this.Class.Name = "Class";
            // 
            // Subject
            // 
            this.Subject.HeaderText = "Subject";
            this.Subject.Name = "Subject";
            this.Subject.Width = 150;
            // 
            // Room
            // 
            this.Room.HeaderText = "Room";
            this.Room.Name = "Room";
            this.Room.Width = 150;
            // 
            // ExamDate
            // 
            this.ExamDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ExamDate.HeaderText = "ExamDate";
            this.ExamDate.MinimumWidth = 50;
            this.ExamDate.Name = "ExamDate";
            // 
            // btnBack
            // 
            this.btnBack.AutoSize = true;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Location = new System.Drawing.Point(139, 511);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(104, 31);
            this.btnBack.TabIndex = 2;
            this.btnBack.TabStop = true;
            this.btnBack.Text = "< Back";
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(261, 509);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(99, 31);
            this.btnNext.TabIndex = 3;
            this.btnNext.TabStop = true;
            this.btnNext.Text = "Next >";
            this.btnNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnNext_LinkClicked);
            // 
            // btnCancel
            // 
            this.btnCancel.AutoSize = true;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(378, 511);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 31);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.TabStop = true;
            this.btnCancel.Text = "Close";
            this.btnCancel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCancel_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // RegisterExamsWizardOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(755, 551);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.splitter1);
            this.Name = "RegisterExamsWizardOld";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registration of Exams";
            this.Load += new System.EventHandler(this.RegisterExamsWizard_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageStart.ResumeLayout(false);
            this.tabPageStart.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPageClassSubjects.ResumeLayout(false);
            this.tabPageClassSubjects.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPageEnd.ResumeLayout(false);
            this.tabPageEnd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StudentsbindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageStart;
        private System.Windows.Forms.LinkLabel btnBack;
        private System.Windows.Forms.LinkLabel btnNext;
        private System.Windows.Forms.LinkLabel btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstTargetClasses;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstSourceClasses;
        private System.Windows.Forms.ComboBox cboExamType;
        private System.Windows.Forms.ComboBox cboTerm;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.LinkLabel btnRemoveAllClasses;
        private System.Windows.Forms.LinkLabel btnRemoveSingleClass;
        private System.Windows.Forms.LinkLabel btnAddAllClasses;
        private System.Windows.Forms.LinkLabel btnAddSingleClass;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource StudentsbindingSource;
        private System.Windows.Forms.LinkLabel btnregisterAllStudentsforAllSubjects;
        private System.Windows.Forms.TabPage tabPageClassSubjects;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbSelectedClasses;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.LinkLabel lnkRemoveAllSubjects;
        private System.Windows.Forms.ListBox lbTargetSubjects;
        private System.Windows.Forms.LinkLabel lnkRemoveSingleSubject;
        private System.Windows.Forms.ListBox lbClassSubjects;
        private System.Windows.Forms.LinkLabel lnkAddAllSubjects;
        private System.Windows.Forms.LinkLabel lnkAddSingleSubject;
        private System.Windows.Forms.TabPage tabPageEnd;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.LinkLabel btnRegisterExam;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Term;
        private System.Windows.Forms.DataGridViewTextBoxColumn Class;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Room;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamDate;

    }
}