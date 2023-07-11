namespace WinSBSchool.Controls
{
    partial class ucClass
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.Label classIdLabel;
            System.Windows.Forms.Label classNameLabel;
            System.Windows.Forms.Label classTeacherLabel;
            System.Windows.Forms.Label remarksLabel;
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpDetails = new System.Windows.Forms.TabPage();
            this.grpAdmission = new System.Windows.Forms.GroupBox();
            this.classTeacherComboBox = new System.Windows.Forms.ComboBox();
            this.classIdTextBox = new System.Windows.Forms.TextBox();
            this.classNameTextBox = new System.Windows.Forms.TextBox();
            this.remarksTextBox = new System.Windows.Forms.TextBox();
            this.tbpSubjects = new System.Windows.Forms.TabPage();
            this.grpField = new System.Windows.Forms.GroupBox();
            this.classSubjectsDataGridView = new System.Windows.Forms.DataGridView();
            this.tbpStudents = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.studentDataGridView = new System.Windows.Forms.DataGridView();
            this.tbpCurricular = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbpPromotion = new System.Windows.Forms.TabPage();
            this.tbAttendance = new System.Windows.Forms.TabPage();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.tbSendMessage = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonSendSMS = new System.Windows.Forms.Button();
            this.buttonSendEmail = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.tbpRemarks = new System.Windows.Forms.TabPage();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            classIdLabel = new System.Windows.Forms.Label();
            classNameLabel = new System.Windows.Forms.Label();
            classTeacherLabel = new System.Windows.Forms.Label();
            remarksLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tbpDetails.SuspendLayout();
            this.grpAdmission.SuspendLayout();
            this.tbpSubjects.SuspendLayout();
            this.grpField.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.classSubjectsDataGridView)).BeginInit();
            this.tbpStudents.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentDataGridView)).BeginInit();
            this.tbpCurricular.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.tbAttendance.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.tbSendMessage.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tbpRemarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // classIdLabel
            // 
            classIdLabel.AutoSize = true;
            classIdLabel.Location = new System.Drawing.Point(19, 42);
            classIdLabel.Name = "classIdLabel";
            classIdLabel.Size = new System.Drawing.Size(75, 13);
            classIdLabel.TabIndex = 0;
            classIdLabel.Text = "ClassName Id:";
            // 
            // classNameLabel
            // 
            classNameLabel.AutoSize = true;
            classNameLabel.Location = new System.Drawing.Point(19, 68);
            classNameLabel.Name = "classNameLabel";
            classNameLabel.Size = new System.Drawing.Size(94, 13);
            classNameLabel.TabIndex = 2;
            classNameLabel.Text = "ClassName Name:";
            // 
            // classTeacherLabel
            // 
            classTeacherLabel.AutoSize = true;
            classTeacherLabel.Location = new System.Drawing.Point(19, 94);
            classTeacherLabel.Name = "classTeacherLabel";
            classTeacherLabel.Size = new System.Drawing.Size(106, 13);
            classTeacherLabel.TabIndex = 4;
            classTeacherLabel.Text = "ClassName Teacher:";
            // 
            // remarksLabel
            // 
            remarksLabel.AutoSize = true;
            remarksLabel.Location = new System.Drawing.Point(19, 120);
            remarksLabel.Name = "remarksLabel";
            remarksLabel.Size = new System.Drawing.Size(52, 13);
            remarksLabel.TabIndex = 6;
            remarksLabel.Text = "Remarks:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpDetails);
            this.tabControl1.Controls.Add(this.tbpSubjects);
            this.tabControl1.Controls.Add(this.tbpStudents);
            this.tabControl1.Controls.Add(this.tbpCurricular);
            this.tabControl1.Controls.Add(this.tbpPromotion);
            this.tabControl1.Controls.Add(this.tbAttendance);
            this.tabControl1.Controls.Add(this.tbSendMessage);
            this.tabControl1.Controls.Add(this.tbpRemarks);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(661, 343);
            this.tabControl1.TabIndex = 16;
            // 
            // tbpDetails
            // 
            this.tbpDetails.Controls.Add(this.grpAdmission);
            this.tbpDetails.Location = new System.Drawing.Point(4, 22);
            this.tbpDetails.Name = "tbpDetails";
            this.tbpDetails.Size = new System.Drawing.Size(653, 317);
            this.tbpDetails.TabIndex = 1;
            this.tbpDetails.Text = "Details";
            this.tbpDetails.UseVisualStyleBackColor = true;
            // 
            // grpAdmission
            // 
            this.grpAdmission.BackColor = System.Drawing.Color.AliceBlue;
            this.grpAdmission.Controls.Add(this.classTeacherComboBox);
            this.grpAdmission.Controls.Add(classIdLabel);
            this.grpAdmission.Controls.Add(this.classIdTextBox);
            this.grpAdmission.Controls.Add(classNameLabel);
            this.grpAdmission.Controls.Add(this.classNameTextBox);
            this.grpAdmission.Controls.Add(classTeacherLabel);
            this.grpAdmission.Controls.Add(remarksLabel);
            this.grpAdmission.Controls.Add(this.remarksTextBox);
            this.grpAdmission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpAdmission.Location = new System.Drawing.Point(0, 0);
            this.grpAdmission.Name = "grpAdmission";
            this.grpAdmission.Size = new System.Drawing.Size(653, 317);
            this.grpAdmission.TabIndex = 0;
            this.grpAdmission.TabStop = false;
            // 
            // classTeacherComboBox
            // 
            this.classTeacherComboBox.DisplayMember = "Name";
            this.classTeacherComboBox.FormattingEnabled = true;
            this.classTeacherComboBox.Location = new System.Drawing.Point(103, 90);
            this.classTeacherComboBox.Name = "classTeacherComboBox";
            this.classTeacherComboBox.Size = new System.Drawing.Size(144, 21);
            this.classTeacherComboBox.TabIndex = 8;
            this.classTeacherComboBox.ValueMember = "TeacherId";
            // 
            // classIdTextBox
            // 
            this.classIdTextBox.Location = new System.Drawing.Point(103, 39);
            this.classIdTextBox.Name = "classIdTextBox";
            this.classIdTextBox.Size = new System.Drawing.Size(144, 20);
            this.classIdTextBox.TabIndex = 1;
            // 
            // classNameTextBox
            // 
            this.classNameTextBox.Location = new System.Drawing.Point(103, 65);
            this.classNameTextBox.Name = "classNameTextBox";
            this.classNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.classNameTextBox.TabIndex = 3;
            // 
            // remarksTextBox
            // 
            this.remarksTextBox.Location = new System.Drawing.Point(103, 117);
            this.remarksTextBox.Multiline = true;
            this.remarksTextBox.Name = "remarksTextBox";
            this.remarksTextBox.Size = new System.Drawing.Size(144, 78);
            this.remarksTextBox.TabIndex = 7;
            // 
            // tbpSubjects
            // 
            this.tbpSubjects.Controls.Add(this.grpField);
            this.tbpSubjects.Location = new System.Drawing.Point(4, 22);
            this.tbpSubjects.Name = "tbpSubjects";
            this.tbpSubjects.Size = new System.Drawing.Size(653, 317);
            this.tbpSubjects.TabIndex = 0;
            this.tbpSubjects.Text = "Subjects";
            this.tbpSubjects.UseVisualStyleBackColor = true;
            // 
            // grpField
            // 
            this.grpField.BackColor = System.Drawing.Color.AliceBlue;
            this.grpField.Controls.Add(this.classSubjectsDataGridView);
            this.grpField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpField.Location = new System.Drawing.Point(0, 0);
            this.grpField.Name = "grpField";
            this.grpField.Size = new System.Drawing.Size(653, 317);
            this.grpField.TabIndex = 14;
            this.grpField.TabStop = false;
            // 
            // classSubjectsDataGridView
            // 
            this.classSubjectsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.classSubjectsDataGridView.Location = new System.Drawing.Point(3, 16);
            this.classSubjectsDataGridView.Name = "classSubjectsDataGridView";
            this.classSubjectsDataGridView.Size = new System.Drawing.Size(647, 298);
            this.classSubjectsDataGridView.TabIndex = 0;
            // 
            // tbpStudents
            // 
            this.tbpStudents.BackColor = System.Drawing.Color.AliceBlue;
            this.tbpStudents.Controls.Add(this.groupBox6);
            this.tbpStudents.Location = new System.Drawing.Point(4, 22);
            this.tbpStudents.Name = "tbpStudents";
            this.tbpStudents.Size = new System.Drawing.Size(653, 317);
            this.tbpStudents.TabIndex = 2;
            this.tbpStudents.Text = "Students";
            this.tbpStudents.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.studentDataGridView);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(653, 317);
            this.groupBox6.TabIndex = 20;
            this.groupBox6.TabStop = false;
            // 
            // studentDataGridView
            // 
            this.studentDataGridView.AllowUserToAddRows = false;
            this.studentDataGridView.AllowUserToDeleteRows = false;
            this.studentDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.studentDataGridView.Location = new System.Drawing.Point(3, 16);
            this.studentDataGridView.Name = "studentDataGridView";
            this.studentDataGridView.Size = new System.Drawing.Size(647, 298);
            this.studentDataGridView.TabIndex = 0;
            // 
            // tbpCurricular
            // 
            this.tbpCurricular.BackColor = System.Drawing.Color.AliceBlue;
            this.tbpCurricular.Controls.Add(this.groupBox7);
            this.tbpCurricular.Location = new System.Drawing.Point(4, 22);
            this.tbpCurricular.Name = "tbpCurricular";
            this.tbpCurricular.Size = new System.Drawing.Size(653, 317);
            this.tbpCurricular.TabIndex = 7;
            this.tbpCurricular.Text = "Academic";
            this.tbpCurricular.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.splitContainer1);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(653, 317);
            this.groupBox7.TabIndex = 8;
            this.groupBox7.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 16);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(647, 298);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 0;
            // 
            // tbpPromotion
            // 
            this.tbpPromotion.BackColor = System.Drawing.Color.AliceBlue;
            this.tbpPromotion.Location = new System.Drawing.Point(4, 22);
            this.tbpPromotion.Name = "tbpPromotion";
            this.tbpPromotion.Size = new System.Drawing.Size(653, 317);
            this.tbpPromotion.TabIndex = 4;
            this.tbpPromotion.Text = "Promotions";
            this.tbpPromotion.UseVisualStyleBackColor = true;
            // 
            // tbAttendance
            // 
            this.tbAttendance.BackColor = System.Drawing.Color.AliceBlue;
            this.tbAttendance.Controls.Add(this.groupBox9);
            this.tbAttendance.Location = new System.Drawing.Point(4, 22);
            this.tbAttendance.Name = "tbAttendance";
            this.tbAttendance.Padding = new System.Windows.Forms.Padding(3);
            this.tbAttendance.Size = new System.Drawing.Size(653, 317);
            this.tbAttendance.TabIndex = 8;
            this.tbAttendance.Text = "Attendance";
            this.tbAttendance.UseVisualStyleBackColor = true;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.monthCalendar1);
            this.groupBox9.Location = new System.Drawing.Point(10, 6);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(264, 197);
            this.groupBox9.TabIndex = 19;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Show By";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 30);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.ShowWeekNumbers = true;
            this.monthCalendar1.TabIndex = 0;
            // 
            // tbSendMessage
            // 
            this.tbSendMessage.Controls.Add(this.groupBox8);
            this.tbSendMessage.Location = new System.Drawing.Point(4, 22);
            this.tbSendMessage.Name = "tbSendMessage";
            this.tbSendMessage.Padding = new System.Windows.Forms.Padding(3);
            this.tbSendMessage.Size = new System.Drawing.Size(653, 317);
            this.tbSendMessage.TabIndex = 9;
            this.tbSendMessage.Text = "Send Message";
            this.tbSendMessage.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox8.Controls.Add(this.button2);
            this.groupBox8.Controls.Add(this.button1);
            this.groupBox8.Controls.Add(this.buttonSendSMS);
            this.groupBox8.Controls.Add(this.buttonSendEmail);
            this.groupBox8.Controls.Add(this.textBox3);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Controls.Add(this.textBox2);
            this.groupBox8.Controls.Add(this.textBox1);
            this.groupBox8.Controls.Add(this.label27);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(647, 311);
            this.groupBox8.TabIndex = 9;
            this.groupBox8.TabStop = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(497, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Fill ClassName Phone Nos";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Fill ClassName Email Addresses";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonSendSMS
            // 
            this.buttonSendSMS.Location = new System.Drawing.Point(497, 154);
            this.buttonSendSMS.Name = "buttonSendSMS";
            this.buttonSendSMS.Size = new System.Drawing.Size(148, 23);
            this.buttonSendSMS.TabIndex = 12;
            this.buttonSendSMS.Text = "Send SMS Now";
            this.buttonSendSMS.UseVisualStyleBackColor = true;
            // 
            // buttonSendEmail
            // 
            this.buttonSendEmail.Location = new System.Drawing.Point(497, 125);
            this.buttonSendEmail.Name = "buttonSendEmail";
            this.buttonSendEmail.Size = new System.Drawing.Size(148, 23);
            this.buttonSendEmail.TabIndex = 11;
            this.buttonSendEmail.Text = "Send Email Now";
            this.buttonSendEmail.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.Location = new System.Drawing.Point(100, 17);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(361, 20);
            this.textBox3.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(20, 17);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 23);
            this.label17.TabIndex = 9;
            this.label17.Text = "To:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(23, 69);
            this.textBox2.MaxLength = 120;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(438, 108);
            this.textBox2.TabIndex = 8;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(100, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(361, 20);
            this.textBox1.TabIndex = 7;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(20, 43);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(74, 23);
            this.label27.TabIndex = 6;
            this.label27.Text = "Subject:";
            // 
            // tbpRemarks
            // 
            this.tbpRemarks.Controls.Add(this.txtRemarks);
            this.tbpRemarks.Location = new System.Drawing.Point(4, 22);
            this.tbpRemarks.Name = "tbpRemarks";
            this.tbpRemarks.Size = new System.Drawing.Size(653, 317);
            this.tbpRemarks.TabIndex = 6;
            this.tbpRemarks.Text = "Remarks";
            this.tbpRemarks.UseVisualStyleBackColor = true;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BackColor = System.Drawing.Color.White;
            this.txtRemarks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRemarks.Location = new System.Drawing.Point(0, 0);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(653, 317);
            this.txtRemarks.TabIndex = 27;
            // 
            // ucClass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ucClass";
            this.Size = new System.Drawing.Size(661, 343);
            this.tabControl1.ResumeLayout(false);
            this.tbpDetails.ResumeLayout(false);
            this.grpAdmission.ResumeLayout(false);
            this.grpAdmission.PerformLayout();
            this.tbpSubjects.ResumeLayout(false);
            this.grpField.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.classSubjectsDataGridView)).EndInit();
            this.tbpStudents.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.studentDataGridView)).EndInit();
            this.tbpCurricular.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tbAttendance.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.tbSendMessage.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tbpRemarks.ResumeLayout(false);
            this.tbpRemarks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpDetails;
        private System.Windows.Forms.GroupBox grpAdmission;
        private System.Windows.Forms.ComboBox classTeacherComboBox;
        private System.Windows.Forms.TextBox classIdTextBox;
        private System.Windows.Forms.TextBox classNameTextBox;
        private System.Windows.Forms.TextBox remarksTextBox;
        private System.Windows.Forms.TabPage tbpSubjects;
        private System.Windows.Forms.GroupBox grpField;
        private System.Windows.Forms.DataGridView classSubjectsDataGridView;
        private System.Windows.Forms.TabPage tbpStudents;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView studentDataGridView;
        private System.Windows.Forms.TabPage tbpCurricular;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabPage tbpPromotion;
        private System.Windows.Forms.TabPage tbAttendance;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.TabPage tbSendMessage;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonSendSMS;
        private System.Windows.Forms.Button buttonSendEmail;
        public System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TabPage tbpRemarks;
        private System.Windows.Forms.TextBox txtRemarks;

    }
}
