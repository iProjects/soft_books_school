namespace WinSBSchool.Forms
{
    partial class RegisterStudentsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterStudentsForm));
            this.btnPopulate = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUseRules = new System.Windows.Forms.CheckBox();
            this.lblSubjectDescription = new System.Windows.Forms.Label();
            this.cbRegisteredExamTypes = new System.Windows.Forms.ComboBox();
            this.btnPopulateAll = new System.Windows.Forms.Button();
            this.btnSelectExam = new System.Windows.Forms.Button();
            this.txtExam = new System.Windows.Forms.TextBox();
            this.lblExamPeriod = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSchoolClass = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblTimeElasped = new System.Windows.Forms.Label();
            this.progressBarProcess = new System.Windows.Forms.ProgressBar();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridViewRegdStudents = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.examsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.printExamCardSelectedClassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printExamCardAllClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridViewNonEligibleStudents = new System.Windows.Forms.DataGridView();
            this.ColumnNonEligibleStudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bindingSourceRegdStudents = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceNonEligibleStudents = new System.Windows.Forms.BindingSource(this.components);
            this.updateStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new WinSBSchool.Forms.CalendarColumn();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegdStudents)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNonEligibleStudents)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegdStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNonEligibleStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPopulate
            // 
            this.btnPopulate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPopulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopulate.Location = new System.Drawing.Point(551, 49);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(61, 23);
            this.btnPopulate.TabIndex = 20;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = false;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkUseRules);
            this.groupBox3.Controls.Add(this.lblSubjectDescription);
            this.groupBox3.Controls.Add(this.cbRegisteredExamTypes);
            this.groupBox3.Controls.Add(this.btnPopulateAll);
            this.groupBox3.Controls.Add(this.btnPopulate);
            this.groupBox3.Controls.Add(this.btnSelectExam);
            this.groupBox3.Controls.Add(this.txtExam);
            this.groupBox3.Controls.Add(this.lblExamPeriod);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboSchoolClass);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(721, 84);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set  Exam";
            // 
            // chkUseRules
            // 
            this.chkUseRules.AutoSize = true;
            this.chkUseRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkUseRules.Location = new System.Drawing.Point(444, 52);
            this.chkUseRules.Name = "chkUseRules";
            this.chkUseRules.Size = new System.Drawing.Size(72, 17);
            this.chkUseRules.TabIndex = 27;
            this.chkUseRules.Text = "Use Rules";
            this.chkUseRules.UseVisualStyleBackColor = true;
            // 
            // lblSubjectDescription
            // 
            this.lblSubjectDescription.AutoSize = true;
            this.lblSubjectDescription.Location = new System.Drawing.Point(252, 20);
            this.lblSubjectDescription.Name = "lblSubjectDescription";
            this.lblSubjectDescription.Size = new System.Drawing.Size(43, 13);
            this.lblSubjectDescription.TabIndex = 26;
            this.lblSubjectDescription.Text = "Subject";
            // 
            // cbRegisteredExamTypes
            // 
            this.cbRegisteredExamTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRegisteredExamTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRegisteredExamTypes.FormattingEnabled = true;
            this.cbRegisteredExamTypes.Location = new System.Drawing.Point(92, 49);
            this.cbRegisteredExamTypes.Name = "cbRegisteredExamTypes";
            this.cbRegisteredExamTypes.Size = new System.Drawing.Size(301, 21);
            this.cbRegisteredExamTypes.TabIndex = 21;
            this.cbRegisteredExamTypes.SelectedIndexChanged += new System.EventHandler(this.cbRegdExams_SelectedIndexChanged);
            // 
            // btnPopulateAll
            // 
            this.btnPopulateAll.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPopulateAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopulateAll.Location = new System.Drawing.Point(627, 49);
            this.btnPopulateAll.Name = "btnPopulateAll";
            this.btnPopulateAll.Size = new System.Drawing.Size(75, 23);
            this.btnPopulateAll.TabIndex = 20;
            this.btnPopulateAll.Text = "Populate All";
            this.btnPopulateAll.UseVisualStyleBackColor = false;
            this.btnPopulateAll.Click += new System.EventHandler(this.btnPopulateAll_Click);
            // 
            // btnSelectExam
            // 
            this.btnSelectExam.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSelectExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectExam.Location = new System.Drawing.Point(150, 16);
            this.btnSelectExam.Name = "btnSelectExam";
            this.btnSelectExam.Size = new System.Drawing.Size(28, 23);
            this.btnSelectExam.TabIndex = 19;
            this.btnSelectExam.Text = ": :";
            this.btnSelectExam.UseVisualStyleBackColor = false;
            this.btnSelectExam.Click += new System.EventHandler(this.btnSearchExams_Click);
            // 
            // txtExam
            // 
            this.txtExam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExam.Enabled = false;
            this.txtExam.Location = new System.Drawing.Point(92, 18);
            this.txtExam.Name = "txtExam";
            this.txtExam.Size = new System.Drawing.Size(52, 20);
            this.txtExam.TabIndex = 18;
            // 
            // lblExamPeriod
            // 
            this.lblExamPeriod.AutoSize = true;
            this.lblExamPeriod.Location = new System.Drawing.Point(184, 20);
            this.lblExamPeriod.Name = "lblExamPeriod";
            this.lblExamPeriod.Size = new System.Drawing.Size(66, 13);
            this.lblExamPeriod.TabIndex = 17;
            this.lblExamPeriod.Text = "Exam Period";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Exam Type*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Exam Id*";
            // 
            // cboSchoolClass
            // 
            this.cboSchoolClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchoolClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSchoolClass.FormattingEnabled = true;
            this.cboSchoolClass.Location = new System.Drawing.Point(551, 12);
            this.cboSchoolClass.Name = "cboSchoolClass";
            this.cboSchoolClass.Size = new System.Drawing.Size(138, 21);
            this.cboSchoolClass.TabIndex = 15;
            this.cboSchoolClass.SelectedIndexChanged += new System.EventHandler(this.cboSchoolClass_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(510, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Class*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(9, 27);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 22;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblTimeElasped);
            this.groupBox2.Controls.Add(this.progressBarProcess);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.menuStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(727, 272);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            // 
            // lblTimeElasped
            // 
            this.lblTimeElasped.AutoSize = true;
            this.lblTimeElasped.Location = new System.Drawing.Point(624, 21);
            this.lblTimeElasped.Name = "lblTimeElasped";
            this.lblTimeElasped.Size = new System.Drawing.Size(26, 13);
            this.lblTimeElasped.TabIndex = 21;
            this.lblTimeElasped.Text = "time";
            // 
            // progressBarProcess
            // 
            this.progressBarProcess.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarProcess.Location = new System.Drawing.Point(229, 16);
            this.progressBarProcess.Name = "progressBarProcess";
            this.progressBarProcess.Size = new System.Drawing.Size(386, 23);
            this.progressBarProcess.TabIndex = 20;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridViewRegdStudents);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 124);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(721, 145);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            // 
            // dataGridViewRegdStudents
            // 
            this.dataGridViewRegdStudents.AllowUserToAddRows = false;
            this.dataGridViewRegdStudents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRegdStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRegdStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegdStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRegdStudents.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRegdStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRegdStudents.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewRegdStudents.MultiSelect = false;
            this.dataGridViewRegdStudents.Name = "dataGridViewRegdStudents";
            this.dataGridViewRegdStudents.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRegdStudents.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewRegdStudents.Size = new System.Drawing.Size(715, 126);
            this.dataGridViewRegdStudents.TabIndex = 18;
            this.dataGridViewRegdStudents.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewRegdStudents_DataError);
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.DataPropertyName = "Id";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Width = 50;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.examsToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(721, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // examsToolStripMenuItem
            // 
            this.examsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.printExamCardSelectedClassToolStripMenuItem,
            this.toolStripSeparator1,
            this.printExamCardAllClassesToolStripMenuItem});
            this.examsToolStripMenuItem.Name = "examsToolStripMenuItem";
            this.examsToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.examsToolStripMenuItem.Text = "&Exam Cards";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.printToolStripMenuItem.Text = "Print Exam Card - Selected Student";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(240, 6);
            // 
            // printExamCardSelectedClassToolStripMenuItem
            // 
            this.printExamCardSelectedClassToolStripMenuItem.Name = "printExamCardSelectedClassToolStripMenuItem";
            this.printExamCardSelectedClassToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.printExamCardSelectedClassToolStripMenuItem.Text = "Print Exam Card - Selected Class:";
            this.printExamCardSelectedClassToolStripMenuItem.Click += new System.EventHandler(this.printExamCardSelectedClassToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(240, 6);
            // 
            // printExamCardAllClassesToolStripMenuItem
            // 
            this.printExamCardAllClassesToolStripMenuItem.Name = "printExamCardAllClassesToolStripMenuItem";
            this.printExamCardAllClassesToolStripMenuItem.Size = new System.Drawing.Size(243, 22);
            this.printExamCardAllClassesToolStripMenuItem.Text = "Print Exam Card - All Classes";
            this.printExamCardAllClassesToolStripMenuItem.Click += new System.EventHandler(this.printExamCardAllClassesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(12, 20);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 149);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridViewNonEligibleStudents);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(641, 130);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Students Not Registered";
            // 
            // dataGridViewNonEligibleStudents
            // 
            this.dataGridViewNonEligibleStudents.AllowUserToAddRows = false;
            this.dataGridViewNonEligibleStudents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNonEligibleStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewNonEligibleStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNonEligibleStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNonEligibleStudentId,
            this.ColumnMessage});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewNonEligibleStudents.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewNonEligibleStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewNonEligibleStudents.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewNonEligibleStudents.MultiSelect = false;
            this.dataGridViewNonEligibleStudents.Name = "dataGridViewNonEligibleStudents";
            this.dataGridViewNonEligibleStudents.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewNonEligibleStudents.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewNonEligibleStudents.Size = new System.Drawing.Size(635, 111);
            this.dataGridViewNonEligibleStudents.TabIndex = 24;
            this.dataGridViewNonEligibleStudents.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewNonEligibleStudents_DataError);
            // 
            // ColumnNonEligibleStudentId
            // 
            this.ColumnNonEligibleStudentId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnNonEligibleStudentId.DataPropertyName = "StudentId";
            this.ColumnNonEligibleStudentId.HeaderText = "Id";
            this.ColumnNonEligibleStudentId.Name = "ColumnNonEligibleStudentId";
            this.ColumnNonEligibleStudentId.ReadOnly = true;
            this.ColumnNonEligibleStudentId.Width = 50;
            // 
            // ColumnMessage
            // 
            this.ColumnMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMessage.DataPropertyName = "Message";
            this.ColumnMessage.HeaderText = "Message";
            this.ColumnMessage.Name = "ColumnMessage";
            this.ColumnMessage.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnClose);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(644, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(80, 130);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.Text = "notifyIcon1";
            this.appNotifyIcon.Visible = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ExamPeriodId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Exam Period";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ClassId";
            this.dataGridViewTextBoxColumn2.HeaderText = "ClassName Subject";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Invilgilator";
            this.dataGridViewTextBoxColumn3.HeaderText = "Invilgilator";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calendarColumn1.DataPropertyName = "ExamDate";
            this.calendarColumn1.HeaderText = "Exam Date";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // RegisterStudentsForm
            // 
            this.AcceptButton = this.btnPopulate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(727, 421);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RegisterStudentsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Students";
            this.Load += new System.EventHandler(this.RegisterStudentsForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegdStudents)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNonEligibleStudents)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegdStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceNonEligibleStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbRegisteredExamTypes;
        private System.Windows.Forms.Button btnSelectExam;
        private System.Windows.Forms.TextBox txtExam;
        private System.Windows.Forms.Label lblExamPeriod;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboSchoolClass;
        private System.Windows.Forms.Label label4;
        private CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource bindingSourceRegdStudents;
        private System.Windows.Forms.Button btnPopulateAll;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem examsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printExamCardSelectedClassToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printExamCardAllClassesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridViewNonEligibleStudents;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.BindingSource bindingSourceNonEligibleStudents;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.Label lblSubjectDescription;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridViewRegdStudents;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ProgressBar progressBarProcess;
        private System.Windows.Forms.Label lblTimeElasped;
        private System.Windows.Forms.Timer updateStatusTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNonEligibleStudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMessage;
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.CheckBox chkUseRules;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;

    }
}