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
            this.cboschoolclasses = new System.Windows.Forms.ComboBox();
            this.bindingSourceSchoolClasses = new System.Windows.Forms.BindingSource(this.components);
            this.btnadvancedfilter = new System.Windows.Forms.Button();
            this.txtSearchByRegNo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnclearfilter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bindingSourceattendance = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnpopulate = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DataGridViewattendance = new System.Windows.Forms.DataGridView();
            this.Columnid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attended = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReasonForNotAttending = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSchoolClasses)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceattendance)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewattendance)).BeginInit();
            this.SuspendLayout();
            // 
            // cboschoolclasses
            // 
            this.cboschoolclasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboschoolclasses.Location = new System.Drawing.Point(113, 9);
            this.cboschoolclasses.Name = "cboschoolclasses";
            this.cboschoolclasses.Size = new System.Drawing.Size(133, 21);
            this.cboschoolclasses.TabIndex = 9;
            this.cboschoolclasses.SelectedIndexChanged += new System.EventHandler(this.cboschoolclasses_SelectedIndexChanged);
            // 
            // btnadvancedfilter
            // 
            this.btnadvancedfilter.Location = new System.Drawing.Point(649, 8);
            this.btnadvancedfilter.Name = "btnadvancedfilter";
            this.btnadvancedfilter.Size = new System.Drawing.Size(105, 23);
            this.btnadvancedfilter.TabIndex = 9;
            this.btnadvancedfilter.Text = "Advanced Filter";
            this.btnadvancedfilter.UseVisualStyleBackColor = true;
            this.btnadvancedfilter.Click += new System.EventHandler(this.btnadvancedfilter_Click);
            // 
            // txtSearchByRegNo
            // 
            this.txtSearchByRegNo.Location = new System.Drawing.Point(427, 8);
            this.txtSearchByRegNo.Name = "txtSearchByRegNo";
            this.txtSearchByRegNo.Size = new System.Drawing.Size(144, 20);
            this.txtSearchByRegNo.TabIndex = 1;
            this.txtSearchByRegNo.TextChanged += new System.EventHandler(this.txtSearchByRegNo_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnclearfilter);
            this.panel1.Controls.Add(this.cboschoolclasses);
            this.panel1.Controls.Add(this.btnadvancedfilter);
            this.panel1.Controls.Add(this.txtSearchByRegNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 222);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 44);
            this.panel1.TabIndex = 22;
            // 
            // btnclearfilter
            // 
            this.btnclearfilter.Location = new System.Drawing.Point(795, 8);
            this.btnclearfilter.Name = "btnclearfilter";
            this.btnclearfilter.Size = new System.Drawing.Size(78, 23);
            this.btnclearfilter.TabIndex = 11;
            this.btnclearfilter.Text = "Clear Filter";
            this.btnclearfilter.UseVisualStyleBackColor = true;
            this.btnclearfilter.Click += new System.EventHandler(this.btnclearfilter_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Filter By ClassName:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(330, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Search By Reg.No:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel2.Controls.Add(this.btnpopulate);
            this.panel2.Controls.Add(this.btSave);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(918, 40);
            this.panel2.TabIndex = 19;
            // 
            // btnpopulate
            // 
            this.btnpopulate.Location = new System.Drawing.Point(412, 4);
            this.btnpopulate.Name = "btnpopulate";
            this.btnpopulate.Size = new System.Drawing.Size(75, 23);
            this.btnpopulate.TabIndex = 1;
            this.btnpopulate.Text = "Populate";
            this.btnpopulate.UseVisualStyleBackColor = true;
            this.btnpopulate.Click += new System.EventHandler(this.btnpopulate_Click);
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
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panel3.Controls.Add(this.monthCalendar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(918, 182);
            this.panel3.TabIndex = 20;
            // 
            // monthCalendar
            // 
            this.monthCalendar.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.ShowWeekNumbers = true;
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar_DateChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.groupBox1.Controls.Add(this.DataGridViewattendance);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 104);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // DataGridViewattendance
            // 
            this.DataGridViewattendance.AllowUserToAddRows = false;
            this.DataGridViewattendance.AllowUserToDeleteRows = false;
            this.DataGridViewattendance.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Columnid,
            this.Attended,
            this.ReasonForNotAttending});
            this.DataGridViewattendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataGridViewattendance.Location = new System.Drawing.Point(3, 16);
            this.DataGridViewattendance.MultiSelect = false;
            this.DataGridViewattendance.Name = "DataGridViewattendance";
            this.DataGridViewattendance.ReadOnly = true;
            this.DataGridViewattendance.Size = new System.Drawing.Size(912, 85);
            this.DataGridViewattendance.TabIndex = 22;
            this.DataGridViewattendance.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewattendance_CellContentDoubleClick);
            this.DataGridViewattendance.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.DataGridViewattendance_DataError);
            // 
            // Columnid
            // 
            this.Columnid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Columnid.DataPropertyName = "Id";
            this.Columnid.HeaderText = "Id";
            this.Columnid.Name = "Columnid";
            this.Columnid.ReadOnly = true;
            this.Columnid.Width = 50;
            // 
            // Attended
            // 
            this.Attended.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Attended.DataPropertyName = "Attended";
            this.Attended.HeaderText = "Attended";
            this.Attended.Name = "Attended";
            this.Attended.ReadOnly = true;
            // 
            // ReasonForNotAttending
            // 
            this.ReasonForNotAttending.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ReasonForNotAttending.DataPropertyName = "ReasonForNotAttending";
            this.ReasonForNotAttending.HeaderText = "Reason For Not Attending";
            this.ReasonForNotAttending.Name = "ReasonForNotAttending";
            this.ReasonForNotAttending.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn2.HeaderText = "Id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ReasonForNotAttending";
            this.dataGridViewTextBoxColumn3.HeaderText = "Reason For Not Attending";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // AttendanceSheetControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Name = "AttendanceSheetControl";
            this.Size = new System.Drawing.Size(918, 370);
            this.Load += new System.EventHandler(this.AttendanceSheetControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSchoolClasses)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceattendance)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewattendance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboschoolclasses;
        private System.Windows.Forms.BindingSource bindingSourceSchoolClasses;
        private System.Windows.Forms.Button btnadvancedfilter;
        private System.Windows.Forms.TextBox txtSearchByRegNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource bindingSourceattendance;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnpopulate;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DataGridViewattendance;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Attended;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReasonForNotAttending;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnclearfilter;
    }
}
