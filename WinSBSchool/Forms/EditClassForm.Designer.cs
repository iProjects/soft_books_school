namespace WinSBSchool.Forms
{
    partial class EditClassForm
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
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label indexLabel;
            System.Windows.Forms.Label schoolNameLabel;
            System.Windows.Forms.Label telephoneLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditClassForm));
            this.btnUpdate = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtNextYearLevel = new System.Windows.Forms.TextBox();
            this.txtNoOfSubjects = new System.Windows.Forms.TextBox();
            this.txtCurrentYearLevel = new System.Windows.Forms.TextBox();
            this.cboProgrammeYears = new System.Windows.Forms.ComboBox();
            this.cboClassTeacher = new System.Windows.Forms.ComboBox();
            this.txtShortCode = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dataGridViewClassSubject = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRoom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.chkInActive = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.LinkLabel();
            this.btnDeleteClassSubject = new System.Windows.Forms.LinkLabel();
            this.btnAddClassSubject = new System.Windows.Forms.LinkLabel();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lstClassStreams = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAddClassStreams = new System.Windows.Forms.LinkLabel();
            this.btnDeleteClassStream = new System.Windows.Forms.LinkLabel();
            this.txtStreamDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bindingSourceClassSubjects = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceClassStreams = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceTeachers = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceSubjects = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            indexLabel = new System.Windows.Forms.Label();
            schoolNameLabel = new System.Windows.Forms.Label();
            telephoneLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassSubject)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClassSubjects)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClassStreams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTeachers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(66, 226);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(49, 13);
            label5.TabIndex = 73;
            label5.Text = "Remarks";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(32, 197);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 13);
            label4.TabIndex = 71;
            label4.Text = "Next Year Level";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(32, 109);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(83, 13);
            label3.TabIndex = 69;
            label3.Text = "No Of Subjects*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 168);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(95, 13);
            label2.TabIndex = 67;
            label2.Text = "Current Year Level";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(52, 79);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 13);
            label1.TabIndex = 65;
            label1.Text = "Programme*";
            // 
            // indexLabel
            // 
            indexLabel.AutoSize = true;
            indexLabel.Location = new System.Drawing.Point(51, 21);
            indexLabel.Name = "indexLabel";
            indexLabel.Size = new System.Drawing.Size(64, 13);
            indexLabel.TabIndex = 62;
            indexLabel.Text = "Short Code*";
            // 
            // schoolNameLabel
            // 
            schoolNameLabel.AutoSize = true;
            schoolNameLabel.Location = new System.Drawing.Point(76, 50);
            schoolNameLabel.Name = "schoolNameLabel";
            schoolNameLabel.Size = new System.Drawing.Size(39, 13);
            schoolNameLabel.TabIndex = 63;
            schoolNameLabel.Text = "Name*";
            // 
            // telephoneLabel
            // 
            telephoneLabel.AutoSize = true;
            telephoneLabel.Location = new System.Drawing.Point(69, 137);
            telephoneLabel.Name = "telephoneLabel";
            telephoneLabel.Size = new System.Drawing.Size(47, 13);
            telephoneLabel.TabIndex = 64;
            telephoneLabel.Text = "Teacher";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(73, 255);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(41, 13);
            label7.TabIndex = 77;
            label7.Text = "Status*";
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.LinkColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(225, 9);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(61, 18);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = true;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUpdate_LinkClicked);
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
            this.btnClose.Location = new System.Drawing.Point(331, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 353);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(645, 37);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 353);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(639, 334);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(631, 308);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Class:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboStatus);
            this.groupBox3.Controls.Add(label7);
            this.groupBox3.Controls.Add(label5);
            this.groupBox3.Controls.Add(this.txtRemarks);
            this.groupBox3.Controls.Add(label4);
            this.groupBox3.Controls.Add(this.txtNextYearLevel);
            this.groupBox3.Controls.Add(label3);
            this.groupBox3.Controls.Add(this.txtNoOfSubjects);
            this.groupBox3.Controls.Add(label2);
            this.groupBox3.Controls.Add(this.txtCurrentYearLevel);
            this.groupBox3.Controls.Add(this.cboProgrammeYears);
            this.groupBox3.Controls.Add(label1);
            this.groupBox3.Controls.Add(this.cboClassTeacher);
            this.groupBox3.Controls.Add(indexLabel);
            this.groupBox3.Controls.Add(this.txtShortCode);
            this.groupBox3.Controls.Add(this.txtClassName);
            this.groupBox3.Controls.Add(schoolNameLabel);
            this.groupBox3.Controls.Add(telephoneLabel);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(625, 302);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(117, 252);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(460, 21);
            this.cboStatus.TabIndex = 8;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(117, 223);
            this.txtRemarks.MaxLength = 250;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(460, 20);
            this.txtRemarks.TabIndex = 7;
            // 
            // txtNextYearLevel
            // 
            this.txtNextYearLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNextYearLevel.Location = new System.Drawing.Point(117, 194);
            this.txtNextYearLevel.MaxLength = 4;
            this.txtNextYearLevel.Name = "txtNextYearLevel";
            this.txtNextYearLevel.Size = new System.Drawing.Size(460, 20);
            this.txtNextYearLevel.TabIndex = 6;
            this.txtNextYearLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNextYearLevel_KeyDown);
            this.txtNextYearLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNextYearLevel_KeyPress);
            // 
            // txtNoOfSubjects
            // 
            this.txtNoOfSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfSubjects.Location = new System.Drawing.Point(117, 106);
            this.txtNoOfSubjects.MaxLength = 4;
            this.txtNoOfSubjects.Name = "txtNoOfSubjects";
            this.txtNoOfSubjects.Size = new System.Drawing.Size(460, 20);
            this.txtNoOfSubjects.TabIndex = 3;
            this.txtNoOfSubjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoOfSubjects_KeyDown);
            this.txtNoOfSubjects.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfSubjects_KeyPress);
            // 
            // txtCurrentYearLevel
            // 
            this.txtCurrentYearLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentYearLevel.Location = new System.Drawing.Point(117, 165);
            this.txtCurrentYearLevel.MaxLength = 4;
            this.txtCurrentYearLevel.Name = "txtCurrentYearLevel";
            this.txtCurrentYearLevel.Size = new System.Drawing.Size(460, 20);
            this.txtCurrentYearLevel.TabIndex = 5;
            this.txtCurrentYearLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurrentYearLevel_KeyDown);
            this.txtCurrentYearLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentYearLevel_KeyPress);
            // 
            // cboProgrammeYears
            // 
            this.cboProgrammeYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProgrammeYears.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProgrammeYears.FormattingEnabled = true;
            this.cboProgrammeYears.Location = new System.Drawing.Point(119, 76);
            this.cboProgrammeYears.Name = "cboProgrammeYears";
            this.cboProgrammeYears.Size = new System.Drawing.Size(460, 21);
            this.cboProgrammeYears.TabIndex = 2;
            // 
            // cboClassTeacher
            // 
            this.cboClassTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboClassTeacher.FormattingEnabled = true;
            this.cboClassTeacher.Location = new System.Drawing.Point(119, 135);
            this.cboClassTeacher.Name = "cboClassTeacher";
            this.cboClassTeacher.Size = new System.Drawing.Size(460, 21);
            this.cboClassTeacher.TabIndex = 4;
            // 
            // txtShortCode
            // 
            this.txtShortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortCode.Location = new System.Drawing.Point(117, 18);
            this.txtShortCode.MaxLength = 15;
            this.txtShortCode.Name = "txtShortCode";
            this.txtShortCode.Size = new System.Drawing.Size(460, 20);
            this.txtShortCode.TabIndex = 0;
            // 
            // txtClassName
            // 
            this.txtClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassName.Location = new System.Drawing.Point(117, 47);
            this.txtClassName.MaxLength = 100;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(460, 20);
            this.txtClassName.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(631, 308);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Class: Subjects";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.dataGridViewClassSubject);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(625, 259);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // dataGridViewClassSubject
            // 
            this.dataGridViewClassSubject.AllowUserToAddRows = false;
            this.dataGridViewClassSubject.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClassSubject.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewClassSubject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassSubject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnRoom});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewClassSubject.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewClassSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewClassSubject.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewClassSubject.MultiSelect = false;
            this.dataGridViewClassSubject.Name = "dataGridViewClassSubject";
            this.dataGridViewClassSubject.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewClassSubject.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewClassSubject.Size = new System.Drawing.Size(619, 240);
            this.dataGridViewClassSubject.TabIndex = 0;
            this.dataGridViewClassSubject.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClassSubject_CellContentDoubleClick);
            this.dataGridViewClassSubject.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewClassSubject_DataError);
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
            // ColumnRoom
            // 
            this.ColumnRoom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnRoom.DataPropertyName = "Room";
            this.ColumnRoom.HeaderText = "Room";
            this.ColumnRoom.MinimumWidth = 100;
            this.ColumnRoom.Name = "ColumnRoom";
            this.ColumnRoom.ReadOnly = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.chkInActive);
            this.groupBox7.Controls.Add(this.btnEdit);
            this.groupBox7.Controls.Add(this.btnDeleteClassSubject);
            this.groupBox7.Controls.Add(this.btnAddClassSubject);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(3, 262);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(625, 43);
            this.groupBox7.TabIndex = 1;
            this.groupBox7.TabStop = false;
            // 
            // chkInActive
            // 
            this.chkInActive.AutoSize = true;
            this.chkInActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInActive.Location = new System.Drawing.Point(29, 17);
            this.chkInActive.Name = "chkInActive";
            this.chkInActive.Size = new System.Drawing.Size(65, 17);
            this.chkInActive.TabIndex = 36;
            this.chkInActive.Text = "In Active";
            this.chkInActive.UseVisualStyleBackColor = true;
            this.chkInActive.CheckedChanged += new System.EventHandler(this.chkInActive_CheckedChanged);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.LinkColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(510, 14);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(41, 20);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.TabStop = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEdit_LinkClicked);
            // 
            // btnDeleteClassSubject
            // 
            this.btnDeleteClassSubject.AutoSize = true;
            this.btnDeleteClassSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteClassSubject.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteClassSubject.Location = new System.Drawing.Point(557, 14);
            this.btnDeleteClassSubject.Name = "btnDeleteClassSubject";
            this.btnDeleteClassSubject.Size = new System.Drawing.Size(62, 20);
            this.btnDeleteClassSubject.TabIndex = 9;
            this.btnDeleteClassSubject.TabStop = true;
            this.btnDeleteClassSubject.Text = "Delete";
            this.btnDeleteClassSubject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteClassSubject_LinkClicked);
            // 
            // btnAddClassSubject
            // 
            this.btnAddClassSubject.AutoSize = true;
            this.btnAddClassSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddClassSubject.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddClassSubject.Location = new System.Drawing.Point(463, 14);
            this.btnAddClassSubject.Name = "btnAddClassSubject";
            this.btnAddClassSubject.Size = new System.Drawing.Size(41, 20);
            this.btnAddClassSubject.TabIndex = 0;
            this.btnAddClassSubject.TabStop = true;
            this.btnAddClassSubject.Text = "Add";
            this.btnAddClassSubject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddClassSubject_LinkClicked);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(631, 308);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Class: Streams";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstClassStreams);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(353, 302);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // lstClassStreams
            // 
            this.lstClassStreams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstClassStreams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstClassStreams.FormattingEnabled = true;
            this.lstClassStreams.Location = new System.Drawing.Point(3, 16);
            this.lstClassStreams.Name = "lstClassStreams";
            this.lstClassStreams.Size = new System.Drawing.Size(347, 283);
            this.lstClassStreams.Sorted = true;
            this.lstClassStreams.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnAddClassStreams);
            this.groupBox5.Controls.Add(this.btnDeleteClassStream);
            this.groupBox5.Controls.Add(this.txtStreamDescription);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Location = new System.Drawing.Point(356, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(272, 302);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // btnAddClassStreams
            // 
            this.btnAddClassStreams.AutoSize = true;
            this.btnAddClassStreams.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddClassStreams.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddClassStreams.Location = new System.Drawing.Point(90, 148);
            this.btnAddClassStreams.Name = "btnAddClassStreams";
            this.btnAddClassStreams.Size = new System.Drawing.Size(36, 18);
            this.btnAddClassStreams.TabIndex = 1;
            this.btnAddClassStreams.TabStop = true;
            this.btnAddClassStreams.Text = "Add";
            this.btnAddClassStreams.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddClassStream_LinkClicked);
            // 
            // btnDeleteClassStream
            // 
            this.btnDeleteClassStream.AutoSize = true;
            this.btnDeleteClassStream.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteClassStream.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteClassStream.Location = new System.Drawing.Point(148, 148);
            this.btnDeleteClassStream.Name = "btnDeleteClassStream";
            this.btnDeleteClassStream.Size = new System.Drawing.Size(56, 18);
            this.btnDeleteClassStream.TabIndex = 2;
            this.btnDeleteClassStream.TabStop = true;
            this.btnDeleteClassStream.Text = "Delete";
            this.btnDeleteClassStream.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteClassStream_LinkClicked);
            // 
            // txtStreamDescription
            // 
            this.txtStreamDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStreamDescription.Location = new System.Drawing.Point(73, 113);
            this.txtStreamDescription.MaxLength = 50;
            this.txtStreamDescription.Name = "txtStreamDescription";
            this.txtStreamDescription.Size = new System.Drawing.Size(170, 20);
            this.txtStreamDescription.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Description*";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Room";
            this.dataGridViewTextBoxColumn1.HeaderText = "Room";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 50;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Room";
            this.dataGridViewTextBoxColumn2.HeaderText = "Room";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // EditClassForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(645, 390);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditClassForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassSubject)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClassSubjects)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClassStreams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTeachers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSubjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnUpdate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.BindingSource bindingSourceClassSubjects;
        private System.Windows.Forms.BindingSource bindingSourceClassStreams;
        private System.Windows.Forms.BindingSource bindingSourceTeachers;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.LinkLabel btnAddClassSubject;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.LinkLabel btnDeleteClassStream;
        private System.Windows.Forms.TextBox txtStreamDescription;
        private System.Windows.Forms.LinkLabel btnAddClassStreams;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtNextYearLevel;
        private System.Windows.Forms.TextBox txtNoOfSubjects;
        private System.Windows.Forms.TextBox txtCurrentYearLevel;
        private System.Windows.Forms.ComboBox cboProgrammeYears;
        private System.Windows.Forms.ComboBox cboClassTeacher;
        private System.Windows.Forms.TextBox txtShortCode;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dataGridViewClassSubject;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lstClassStreams;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.LinkLabel btnDeleteClassSubject;
        private System.Windows.Forms.BindingSource bindingSourceSubjects;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRoom;
        private System.Windows.Forms.LinkLabel btnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.CheckBox chkInActive;
        private System.Windows.Forms.ComboBox cboStatus;

    }
}