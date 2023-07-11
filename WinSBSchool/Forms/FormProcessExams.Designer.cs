namespace WinSBSchool.Forms
{
    partial class FormProcessExams
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcessExams));
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstExamPeriods = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblTimeElapsedPeriod = new System.Windows.Forms.Label();
            this.progressBarPeriod = new System.Windows.Forms.ProgressBar();
            this.btnProcessExamByExamPeriod = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lstRegdExams = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnCloseExam = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstExams = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbClasses = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lblTimeElaspedProcess = new System.Windows.Forms.Label();
            this.progressBarProcess = new System.Windows.Forms.ProgressBar();
            this.btnProcessByClass = new System.Windows.Forms.Button();
            this.bindingSourceExamPeriods = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceExams = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceClasses = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceRegdExams = new System.Windows.Forms.BindingSource(this.components);
            this.processTimer = new System.Windows.Forms.Timer(this.components);
            this.Periodtimer = new System.Windows.Forms.Timer(this.components);
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExamPeriods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExams)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClasses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegdExams)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(110, 51);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstExamPeriods);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(216, 373);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Exam Periods";
            // 
            // lstExamPeriods
            // 
            this.lstExamPeriods.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstExamPeriods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstExamPeriods.FormattingEnabled = true;
            this.lstExamPeriods.Location = new System.Drawing.Point(3, 16);
            this.lstExamPeriods.Name = "lstExamPeriods";
            this.lstExamPeriods.Size = new System.Drawing.Size(210, 274);
            this.lstExamPeriods.TabIndex = 19;
            this.lstExamPeriods.SelectedIndexChanged += new System.EventHandler(this.lstExamPeriods_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTimeElapsedPeriod);
            this.groupBox4.Controls.Add(this.progressBarPeriod);
            this.groupBox4.Controls.Add(this.btnProcessExamByExamPeriod);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 290);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(210, 80);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            // 
            // lblTimeElapsedPeriod
            // 
            this.lblTimeElapsedPeriod.AutoSize = true;
            this.lblTimeElapsedPeriod.Location = new System.Drawing.Point(90, 23);
            this.lblTimeElapsedPeriod.Name = "lblTimeElapsedPeriod";
            this.lblTimeElapsedPeriod.Size = new System.Drawing.Size(26, 13);
            this.lblTimeElapsedPeriod.TabIndex = 23;
            this.lblTimeElapsedPeriod.Text = "time";
            // 
            // progressBarPeriod
            // 
            this.progressBarPeriod.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarPeriod.Location = new System.Drawing.Point(9, 46);
            this.progressBarPeriod.Name = "progressBarPeriod";
            this.progressBarPeriod.Size = new System.Drawing.Size(195, 23);
            this.progressBarPeriod.TabIndex = 2;
            // 
            // btnProcessExamByExamPeriod
            // 
            this.btnProcessExamByExamPeriod.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnProcessExamByExamPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessExamByExamPeriod.Location = new System.Drawing.Point(9, 18);
            this.btnProcessExamByExamPeriod.Name = "btnProcessExamByExamPeriod";
            this.btnProcessExamByExamPeriod.Size = new System.Drawing.Size(75, 23);
            this.btnProcessExamByExamPeriod.TabIndex = 0;
            this.btnProcessExamByExamPeriod.Text = "Process";
            this.btnProcessExamByExamPeriod.UseVisualStyleBackColor = false;
            this.btnProcessExamByExamPeriod.Click += new System.EventHandler(this.btnProcessExamByExamPeriod_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lstRegdExams);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(495, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 373);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Registered Exams ";
            // 
            // lstRegdExams
            // 
            this.lstRegdExams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRegdExams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRegdExams.FormattingEnabled = true;
            this.lstRegdExams.Location = new System.Drawing.Point(3, 16);
            this.lstRegdExams.Name = "lstRegdExams";
            this.lstRegdExams.Size = new System.Drawing.Size(194, 274);
            this.lstRegdExams.TabIndex = 20;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnCloseExam);
            this.groupBox7.Controls.Add(this.btnClose);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(3, 290);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(194, 80);
            this.groupBox7.TabIndex = 19;
            this.groupBox7.TabStop = false;
            // 
            // btnCloseExam
            // 
            this.btnCloseExam.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCloseExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseExam.Location = new System.Drawing.Point(17, 17);
            this.btnCloseExam.Name = "btnCloseExam";
            this.btnCloseExam.Size = new System.Drawing.Size(75, 23);
            this.btnCloseExam.TabIndex = 1;
            this.btnCloseExam.Text = "Close Exam";
            this.btnCloseExam.UseVisualStyleBackColor = false;
            this.btnCloseExam.Click += new System.EventHandler(this.btnCloseExam_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstExams);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(216, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(279, 373);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Exams";
            // 
            // lstExams
            // 
            this.lstExams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstExams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstExams.FormattingEnabled = true;
            this.lstExams.Location = new System.Drawing.Point(3, 71);
            this.lstExams.Name = "lstExams";
            this.lstExams.Size = new System.Drawing.Size(273, 219);
            this.lstExams.TabIndex = 20;
            this.lstExams.SelectedIndexChanged += new System.EventHandler(this.lstExams_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.cbClasses);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox6.Location = new System.Drawing.Point(3, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(273, 55);
            this.groupBox6.TabIndex = 19;
            this.groupBox6.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Classes";
            // 
            // cbClasses
            // 
            this.cbClasses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbClasses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbClasses.FormattingEnabled = true;
            this.cbClasses.Location = new System.Drawing.Point(71, 19);
            this.cbClasses.Name = "cbClasses";
            this.cbClasses.Size = new System.Drawing.Size(181, 21);
            this.cbClasses.TabIndex = 14;
            this.cbClasses.SelectedIndexChanged += new System.EventHandler(this.cbClasses_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblTimeElaspedProcess);
            this.groupBox5.Controls.Add(this.progressBarProcess);
            this.groupBox5.Controls.Add(this.btnProcessByClass);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.Location = new System.Drawing.Point(3, 290);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(273, 80);
            this.groupBox5.TabIndex = 18;
            this.groupBox5.TabStop = false;
            // 
            // lblTimeElaspedProcess
            // 
            this.lblTimeElaspedProcess.AutoSize = true;
            this.lblTimeElaspedProcess.Location = new System.Drawing.Point(105, 22);
            this.lblTimeElaspedProcess.Name = "lblTimeElaspedProcess";
            this.lblTimeElaspedProcess.Size = new System.Drawing.Size(26, 13);
            this.lblTimeElaspedProcess.TabIndex = 22;
            this.lblTimeElaspedProcess.Text = "time";
            // 
            // progressBarProcess
            // 
            this.progressBarProcess.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarProcess.Location = new System.Drawing.Point(15, 46);
            this.progressBarProcess.Name = "progressBarProcess";
            this.progressBarProcess.Size = new System.Drawing.Size(247, 23);
            this.progressBarProcess.TabIndex = 1;
            // 
            // btnProcessByClass
            // 
            this.btnProcessByClass.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnProcessByClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcessByClass.Location = new System.Drawing.Point(15, 17);
            this.btnProcessByClass.Name = "btnProcessByClass";
            this.btnProcessByClass.Size = new System.Drawing.Size(75, 23);
            this.btnProcessByClass.TabIndex = 0;
            this.btnProcessByClass.Text = "Process";
            this.btnProcessByClass.UseVisualStyleBackColor = false;
            this.btnProcessByClass.Click += new System.EventHandler(this.btnProcessExamsByClass_Click);
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.Text = "notifyIcon1";
            this.appNotifyIcon.Visible = true;
            // 
            // FormProcessExams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(695, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormProcessExams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Process Exams";
            this.Load += new System.EventHandler(this.FormProcessExams_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExamPeriods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExams)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceClasses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRegdExams)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceExamPeriods;
        private System.Windows.Forms.BindingSource bindingSourceExams;
        private System.Windows.Forms.BindingSource bindingSourceClasses;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindingSourceRegdExams;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstExamPeriods;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnProcessExamByExamPeriod;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstRegdExams;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstExams;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbClasses;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnProcessByClass;
        private System.Windows.Forms.ProgressBar progressBarProcess;
        private System.Windows.Forms.Label lblTimeElaspedProcess;
        private System.Windows.Forms.Timer processTimer;
        private System.Windows.Forms.Label lblTimeElapsedPeriod;
        private System.Windows.Forms.ProgressBar progressBarPeriod;
        private System.Windows.Forms.Timer Periodtimer;
        private System.Windows.Forms.Button btnCloseExam;
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
    }
}