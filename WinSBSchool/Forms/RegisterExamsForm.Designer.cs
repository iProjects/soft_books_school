namespace WinSBSchool.Forms
{
    partial class RegisterExamsForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewRegdExams = new System.Windows.Forms.DataGridView();
            this.ColumnExamDate = new WinSBSchool.Forms.CalendarColumn();
            this.ColumnInvilgilator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboClasses = new System.Windows.Forms.ComboBox();
            this.btnPopulate = new System.Windows.Forms.Button();
            this.btnSelectExamPeriod = new System.Windows.Forms.Button();
            this.txtExamPeriod = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboSchoolClass = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.timeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createExamTimeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAllExamTimeTableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.examsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contributionByExamTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceExams = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceSchoolClasses = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceRegdExams = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceExamType = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceRooms = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new WinSBSchool.Forms.CalendarColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegdExams)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSchoolClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegdExams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExamType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRooms)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewRegdExams);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.menuStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(886, 329);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewRegdExams
            // 
            this.dataGridViewRegdExams.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRegdExams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewRegdExams.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRegdExams.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnExamDate,
            this.ColumnInvilgilator});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewRegdExams.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewRegdExams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRegdExams.Location = new System.Drawing.Point(3, 124);
            this.dataGridViewRegdExams.MultiSelect = false;
            this.dataGridViewRegdExams.Name = "dataGridViewRegdExams";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewRegdExams.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewRegdExams.Size = new System.Drawing.Size(880, 202);
            this.dataGridViewRegdExams.TabIndex = 17;
            this.dataGridViewRegdExams.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewRegdExams_DataError);
            // 
            // ColumnExamDate
            // 
            this.ColumnExamDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnExamDate.DataPropertyName = "ExamDate";
            this.ColumnExamDate.HeaderText = "Exam Date";
            this.ColumnExamDate.Name = "ColumnExamDate";
            this.ColumnExamDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnExamDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnInvilgilator
            // 
            this.ColumnInvilgilator.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnInvilgilator.DataPropertyName = "Invilgilator";
            this.ColumnInvilgilator.HeaderText = "Invilgilator";
            this.ColumnInvilgilator.Name = "ColumnInvilgilator";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cboClasses);
            this.groupBox3.Controls.Add(this.btnPopulate);
            this.groupBox3.Controls.Add(this.btnSelectExamPeriod);
            this.groupBox3.Controls.Add(this.txtExamPeriod);
            this.groupBox3.Controls.Add(this.lblMessage);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.cboSchoolClass);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 40);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(880, 84);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Set  Exam Period";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Exam Types";
            // 
            // cboClasses
            // 
            this.cboClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboClasses.FormattingEnabled = true;
            this.cboClasses.Location = new System.Drawing.Point(92, 50);
            this.cboClasses.Name = "cboClasses";
            this.cboClasses.Size = new System.Drawing.Size(152, 21);
            this.cboClasses.TabIndex = 21;
            // 
            // btnPopulate
            // 
            this.btnPopulate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPopulate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPopulate.Location = new System.Drawing.Point(679, 48);
            this.btnPopulate.Name = "btnPopulate";
            this.btnPopulate.Size = new System.Drawing.Size(75, 23);
            this.btnPopulate.TabIndex = 20;
            this.btnPopulate.Text = "Populate";
            this.btnPopulate.UseVisualStyleBackColor = false;
            this.btnPopulate.Click += new System.EventHandler(this.btnPopulate_Click);
            // 
            // btnSelectExamPeriod
            // 
            this.btnSelectExamPeriod.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSelectExamPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectExamPeriod.Location = new System.Drawing.Point(177, 18);
            this.btnSelectExamPeriod.Name = "btnSelectExamPeriod";
            this.btnSelectExamPeriod.Size = new System.Drawing.Size(28, 23);
            this.btnSelectExamPeriod.TabIndex = 19;
            this.btnSelectExamPeriod.Text = ": :";
            this.btnSelectExamPeriod.UseVisualStyleBackColor = false;
            this.btnSelectExamPeriod.Click += new System.EventHandler(this.btnSelectExamPeriod_Click);
            // 
            // txtExamPeriod
            // 
            this.txtExamPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExamPeriod.Enabled = false;
            this.txtExamPeriod.Location = new System.Drawing.Point(92, 18);
            this.txtExamPeriod.Name = "txtExamPeriod";
            this.txtExamPeriod.Size = new System.Drawing.Size(78, 20);
            this.txtExamPeriod.TabIndex = 18;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(288, 24);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(78, 13);
            this.lblMessage.TabIndex = 17;
            this.lblMessage.Text = "None Selected";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Exam Period";
            // 
            // cboSchoolClass
            // 
            this.cboSchoolClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchoolClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSchoolClass.FormattingEnabled = true;
            this.cboSchoolClass.Location = new System.Drawing.Point(679, 17);
            this.cboSchoolClass.Name = "cboSchoolClass";
            this.cboSchoolClass.Size = new System.Drawing.Size(180, 21);
            this.cboSchoolClass.TabIndex = 15;
            this.cboSchoolClass.SelectedIndexChanged += new System.EventHandler(this.cboSchoolClass_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(641, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Class:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timeTableToolStripMenuItem,
            this.examsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 16);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(880, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // timeTableToolStripMenuItem
            // 
            this.timeTableToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createExamTimeTableToolStripMenuItem,
            this.createAllExamTimeTableToolStripMenuItem});
            this.timeTableToolStripMenuItem.Name = "timeTableToolStripMenuItem";
            this.timeTableToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.timeTableToolStripMenuItem.Text = "TimeTable";
            // 
            // createExamTimeTableToolStripMenuItem
            // 
            this.createExamTimeTableToolStripMenuItem.Name = "createExamTimeTableToolStripMenuItem";
            this.createExamTimeTableToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.createExamTimeTableToolStripMenuItem.Text = "Create Exam Time Table";
            this.createExamTimeTableToolStripMenuItem.Click += new System.EventHandler(this.createExamTimeTableToolStripMenuItem_Click);
            // 
            // createAllExamTimeTableToolStripMenuItem
            // 
            this.createAllExamTimeTableToolStripMenuItem.Name = "createAllExamTimeTableToolStripMenuItem";
            this.createAllExamTimeTableToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.createAllExamTimeTableToolStripMenuItem.Text = "Create All Exam Time Table";
            this.createAllExamTimeTableToolStripMenuItem.Click += new System.EventHandler(this.createAllExamTimeTableToolStripMenuItem_Click);
            // 
            // examsToolStripMenuItemcopy
            // 
            this.examsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contributionByExamTypeToolStripMenuItem});
            this.examsToolStripMenuItem.Name = "examsToolStripMenuItem";
            this.examsToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.examsToolStripMenuItem.Text = "&Exams";
            // 
            // contributionByExamTypeToolStripMenuItem
            // 
            this.contributionByExamTypeToolStripMenuItem.Name = "contributionByExamTypeToolStripMenuItem";
            this.contributionByExamTypeToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.contributionByExamTypeToolStripMenuItem.Text = "Contribution By Exam Type";
            this.contributionByExamTypeToolStripMenuItem.Click += new System.EventHandler(this.contributionByExamTypeToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 329);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(886, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.LinkColor = System.Drawing.Color.Yellow;
            this.btnSave.Location = new System.Drawing.Point(677, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 25);
            this.btnSave.TabIndex = 23;
            this.btnSave.TabStop = true;
            this.btnSave.Text = "Save";
            this.btnSave.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSave_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(790, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 25);
            this.btnClose.TabIndex = 22;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ExamPeriodId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Exam Period";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ClassId";
            this.dataGridViewTextBoxColumn2.HeaderText = "ClassName Subject";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
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
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Invilgilator";
            this.dataGridViewTextBoxColumn3.HeaderText = "Invilgilator";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // RegisterExamsForm
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnSave;
            this.ClientSize = new System.Drawing.Size(886, 386);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RegisterExamsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Exams";
            this.Load += new System.EventHandler(this.RegisterExamsForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRegdExams)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSchoolClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegdExams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExamType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRooms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource bindingSourceExams;
        private System.Windows.Forms.ComboBox cboSchoolClass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bindingSourceSchoolClasses;
        private System.Windows.Forms.BindingSource bindingSourceRegdExams;
        private System.Windows.Forms.BindingSource bindingSourceExamType;
        private System.Windows.Forms.BindingSource bindingSourceRooms;
        private System.Windows.Forms.LinkLabel btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnSelectExamPeriod;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExamPeriod;
        private System.Windows.Forms.Button btnPopulate;
        private System.Windows.Forms.DataGridView dataGridViewRegdExams;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem timeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createExamTimeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createAllExamTimeTableToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem examsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contributionByExamTypeToolStripMenuItem;
        private CalendarColumn ColumnExamDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInvilgilator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboClasses;
    }
}