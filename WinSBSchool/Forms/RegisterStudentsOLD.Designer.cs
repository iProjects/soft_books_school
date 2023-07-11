namespace WinSBSchool.Forms
{
    partial class RegisterStudentsOLD
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveAllClasses = new System.Windows.Forms.LinkLabel();
            this.lstTargetSubjects = new System.Windows.Forms.ListBox();
            this.btnRemoveSingleClass = new System.Windows.Forms.LinkLabel();
            this.lstSourceSubjects = new System.Windows.Forms.ListBox();
            this.btnAddAllClasses = new System.Windows.Forms.LinkLabel();
            this.btnAddSingleClass = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboExamType = new System.Windows.Forms.ComboBox();
            this.cboTerm = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.lbTargetStudents = new System.Windows.Forms.ListBox();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.lbStudents = new System.Windows.Forms.ListBox();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(679, 488);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(671, 462);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Examination  Period";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveAllClasses);
            this.groupBox2.Controls.Add(this.lstTargetSubjects);
            this.groupBox2.Controls.Add(this.btnRemoveSingleClass);
            this.groupBox2.Controls.Add(this.lstSourceSubjects);
            this.groupBox2.Controls.Add(this.btnAddAllClasses);
            this.groupBox2.Controls.Add(this.btnAddSingleClass);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(-4, 130);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 335);
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
            // lstTargetSubjects
            // 
            this.lstTargetSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTargetSubjects.FormattingEnabled = true;
            this.lstTargetSubjects.ItemHeight = 16;
            this.lstTargetSubjects.Location = new System.Drawing.Point(333, 18);
            this.lstTargetSubjects.Name = "lstTargetSubjects";
            this.lstTargetSubjects.Size = new System.Drawing.Size(233, 306);
            this.lstTargetSubjects.TabIndex = 0;
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
            // 
            // lstSourceSubjects
            // 
            this.lstSourceSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstSourceSubjects.FormattingEnabled = true;
            this.lstSourceSubjects.ItemHeight = 16;
            this.lstSourceSubjects.Location = new System.Drawing.Point(10, 18);
            this.lstSourceSubjects.Name = "lstSourceSubjects";
            this.lstSourceSubjects.Size = new System.Drawing.Size(263, 306);
            this.lstSourceSubjects.TabIndex = 0;
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
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.label9);
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
            this.groupBox1.Size = new System.Drawing.Size(665, 121);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set  Exam Period";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(349, 87);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 28);
            this.button1.TabIndex = 9;
            this.button1.Text = "Register all _ExamPeriod for all subjects";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(396, 58);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(153, 23);
            this.comboBox2.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(358, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 7;
            this.label9.Text = "ClassName";
            // 
            // cboExamType
            // 
            this.cboExamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboExamType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboExamType.FormattingEnabled = true;
            this.cboExamType.Location = new System.Drawing.Point(396, 19);
            this.cboExamType.Name = "cboExamType";
            this.cboExamType.Size = new System.Drawing.Size(151, 23);
            this.cboExamType.TabIndex = 6;
            // 
            // cboTerm
            // 
            this.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTerm.FormattingEnabled = true;
            this.cboTerm.Location = new System.Drawing.Point(83, 56);
            this.cboTerm.Name = "cboTerm";
            this.cboTerm.Size = new System.Drawing.Size(153, 23);
            this.cboTerm.TabIndex = 5;
            // 
            // cboYear
            // 
            this.cboYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(81, 19);
            this.cboYear.MaxLength = 4;
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(155, 23);
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
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage4.Controls.Add(this.btnSave);
            this.tabPage4.Controls.Add(this.label8);
            this.tabPage4.Controls.Add(this.comboBox1);
            this.tabPage4.Controls.Add(this.groupBox7);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(671, 462);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Class_ Students";
            // 
            // btnSave
            // 
            this.btnSave.AutoSize = true;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(450, 423);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(155, 20);
            this.btnSave.TabIndex = 5;
            this.btnSave.TabStop = true;
            this.btnSave.Text = "Register Students";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(21, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Select Subject";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(154, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(170, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.linkLabel3);
            this.groupBox7.Controls.Add(this.lbTargetStudents);
            this.groupBox7.Controls.Add(this.linkLabel4);
            this.groupBox7.Controls.Add(this.lbStudents);
            this.groupBox7.Controls.Add(this.linkLabel5);
            this.groupBox7.Controls.Add(this.linkLabel6);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(-4, 68);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(606, 335);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.Location = new System.Drawing.Point(280, 204);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(48, 31);
            this.linkLabel3.TabIndex = 6;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "<<";
            // 
            // lbTargetStudents
            // 
            this.lbTargetStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTargetStudents.FormattingEnabled = true;
            this.lbTargetStudents.ItemHeight = 16;
            this.lbTargetStudents.Location = new System.Drawing.Point(333, 18);
            this.lbTargetStudents.Name = "lbTargetStudents";
            this.lbTargetStudents.Size = new System.Drawing.Size(233, 306);
            this.lbTargetStudents.TabIndex = 0;
            // 
            // linkLabel4
            // 
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel4.Location = new System.Drawing.Point(286, 159);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(31, 31);
            this.linkLabel4.TabIndex = 5;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = "<";
            // 
            // lbStudents
            // 
            this.lbStudents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbStudents.FormattingEnabled = true;
            this.lbStudents.ItemHeight = 16;
            this.lbStudents.Location = new System.Drawing.Point(10, 18);
            this.lbStudents.Name = "lbStudents";
            this.lbStudents.Size = new System.Drawing.Size(263, 306);
            this.lbStudents.TabIndex = 0;
            // 
            // linkLabel5
            // 
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel5.Location = new System.Drawing.Point(280, 122);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(48, 31);
            this.linkLabel5.TabIndex = 4;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = ">>";
            // 
            // linkLabel6
            // 
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel6.Location = new System.Drawing.Point(286, 75);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(31, 31);
            this.linkLabel6.TabIndex = 3;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = ">";
            // 
            // RegisterStudentsOLD
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 488);
            this.Controls.Add(this.tabControl1);
            this.Name = "RegisterStudentsOLD";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterStudents";
            this.Load += new System.EventHandler(this.RegisterStudentsOLD_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel btnRemoveAllClasses;
        private System.Windows.Forms.ListBox lstTargetSubjects;
        private System.Windows.Forms.LinkLabel btnRemoveSingleClass;
        private System.Windows.Forms.ListBox lstSourceSubjects;
        private System.Windows.Forms.LinkLabel btnAddAllClasses;
        private System.Windows.Forms.LinkLabel btnAddSingleClass;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboExamType;
        private System.Windows.Forms.ComboBox cboTerm;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.ListBox lbTargetStudents;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.ListBox lbStudents;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel6;
        private System.Windows.Forms.LinkLabel btnSave;
    }
}