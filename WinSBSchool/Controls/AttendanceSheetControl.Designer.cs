namespace WinSBSchool.Controls
{
    partial class AttendanceSheetControl
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
            this.components = new System.ComponentModel.Container();
            this.studentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.classBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonFilter = new System.Windows.Forms.Button();
            this.txtSearchByRegNo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReasonForNotAttending = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attended = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SchoolDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btPopulate = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.attendanceDataGridView = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDataGridView)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // studentBindingSource
            // 
            this.studentBindingSource.DataMember = "Student";
            // 
            // classComboBox
            // 
            this.classComboBox.DataSource = this.classBindingSource;
            this.classComboBox.DisplayMember = "ClassName";
            this.classComboBox.Location = new System.Drawing.Point(96, 5);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(112, 21);
            this.classComboBox.TabIndex = 9;
            this.classComboBox.ValueMember = "ClassId";
            // 
            // classBindingSource
            // 
            this.classBindingSource.DataMember = "ClassName";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(688, 3);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(105, 23);
            this.buttonFilter.TabIndex = 9;
            this.buttonFilter.Text = "Advanced Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            // 
            // txtSearchByRegNo
            // 
            this.txtSearchByRegNo.Location = new System.Drawing.Point(434, 5);
            this.txtSearchByRegNo.Name = "txtSearchByRegNo";
            this.txtSearchByRegNo.Size = new System.Drawing.Size(144, 20);
            this.txtSearchByRegNo.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.AliceBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.classComboBox);
            this.panel1.Controls.Add(this.buttonFilter);
            this.panel1.Controls.Add(this.txtSearchByRegNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 44);
            this.panel1.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter By ClassName:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(330, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search By Reg.No:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // attendanceBindingSource
            // 
            this.attendanceBindingSource.DataMember = "StudentAttendance";
            this.attendanceBindingSource.DataSource = this.studentBindingSource;
            // 
            // ReasonForNotAttending
            // 
            this.ReasonForNotAttending.DataPropertyName = "ReasonForNotAttending";
            this.ReasonForNotAttending.HeaderText = "ReasonForNotAttending";
            this.ReasonForNotAttending.Name = "ReasonForNotAttending";
            // 
            // Attended
            // 
            this.Attended.DataPropertyName = "Attended";
            this.Attended.HeaderText = "Attended";
            this.Attended.Name = "Attended";
            // 
            // StudentId
            // 
            this.Student.DataPropertyName = "Student";
            this.Student.HeaderText = "Student";
            this.Student.Name = "Student";
            // 
            // SchoolDate
            // 
            this.SchoolDate.DataPropertyName = "SchoolDate";
            this.SchoolDate.HeaderText = "SchoolDate";
            this.SchoolDate.Name = "SchoolDate";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btPopulate);
            this.panel2.Controls.Add(this.btSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(704, 40);
            this.panel2.TabIndex = 19;
            // 
            // btPopulate
            // 
            this.btPopulate.Location = new System.Drawing.Point(412, 4);
            this.btPopulate.Name = "btPopulate";
            this.btPopulate.Size = new System.Drawing.Size(75, 23);
            this.btPopulate.TabIndex = 1;
            this.btPopulate.Text = "Populate";
            this.btPopulate.UseVisualStyleBackColor = true;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(529, 4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 0;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // attendanceDataGridView
            // 
            this.attendanceDataGridView.AutoGenerateColumns = false;
            this.attendanceDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.SchoolDate,
            this.Student,
            this.Attended,
            this.ReasonForNotAttending});
            this.attendanceDataGridView.DataSource = this.attendanceBindingSource;
            this.attendanceDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.attendanceDataGridView.Location = new System.Drawing.Point(0, 182);
            this.attendanceDataGridView.Name = "attendanceDataGridView";
            this.attendanceDataGridView.Size = new System.Drawing.Size(704, 188);
            this.attendanceDataGridView.TabIndex = 21;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.monthCalendar1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(704, 182);
            this.panel3.TabIndex = 20;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // AttendanceSheetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.attendanceDataGridView);
            this.Controls.Add(this.panel3);
            this.Name = "AttendanceSheetControl";
            this.Size = new System.Drawing.Size(704, 370);
            ((System.ComponentModel.ISupportInitialize)(this.studentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.classBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attendanceDataGridView)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource studentBindingSource;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.BindingSource classBindingSource;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.TextBox txtSearchByRegNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource attendanceBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReasonForNotAttending;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Attended;
        private System.Windows.Forms.DataGridViewTextBoxColumn Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn SchoolDate;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btPopulate;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.DataGridView attendanceDataGridView;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
    }
}
