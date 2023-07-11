namespace WinSBSchool.Forms
{
    partial class AddClassForm
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label indexLabel;
            System.Windows.Forms.Label schoolNameLabel;
            System.Windows.Forms.Label telephoneLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddClassForm));
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtNextYearLevel = new System.Windows.Forms.TextBox();
            this.txtNoOfSubjects = new System.Windows.Forms.TextBox();
            this.txtCurrentYearLevel = new System.Windows.Forms.TextBox();
            this.cboProgrammeYears = new System.Windows.Forms.ComboBox();
            this.cboClassTeacher = new System.Windows.Forms.ComboBox();
            this.txtShortCode = new System.Windows.Forms.TextBox();
            this.txtClassName = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            indexLabel = new System.Windows.Forms.Label();
            schoolNameLabel = new System.Windows.Forms.Label();
            telephoneLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(50, 77);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(64, 13);
            label1.TabIndex = 65;
            label1.Text = "Programme*";
            // 
            // indexLabel
            // 
            indexLabel.AutoSize = true;
            indexLabel.Location = new System.Drawing.Point(51, 17);
            indexLabel.Name = "indexLabel";
            indexLabel.Size = new System.Drawing.Size(64, 13);
            indexLabel.TabIndex = 62;
            indexLabel.Text = "Short Code*";
            // 
            // schoolNameLabel
            // 
            schoolNameLabel.AutoSize = true;
            schoolNameLabel.Location = new System.Drawing.Point(76, 47);
            schoolNameLabel.Name = "schoolNameLabel";
            schoolNameLabel.Size = new System.Drawing.Size(39, 13);
            schoolNameLabel.TabIndex = 63;
            schoolNameLabel.Text = "Name*";
            // 
            // telephoneLabel
            // 
            telephoneLabel.AutoSize = true;
            telephoneLabel.Location = new System.Drawing.Point(63, 138);
            telephoneLabel.Name = "telephoneLabel";
            telephoneLabel.Size = new System.Drawing.Size(51, 13);
            telephoneLabel.TabIndex = 64;
            telephoneLabel.Text = "Teacher*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(20, 169);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(95, 13);
            label2.TabIndex = 67;
            label2.Text = "Current Year Level";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(32, 199);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(83, 13);
            label4.TabIndex = 71;
            label4.Text = "Next Year Level";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(66, 229);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(49, 13);
            label5.TabIndex = 73;
            label5.Text = "Remarks";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(73, 255);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 13);
            label6.TabIndex = 75;
            label6.Text = "Status*";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(292, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buttonClose_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(217, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 288);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(579, 35);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(label6);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(this.txtNextYearLevel);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(this.txtNoOfSubjects);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Controls.Add(this.txtCurrentYearLevel);
            this.groupBox2.Controls.Add(this.cboProgrammeYears);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(this.cboClassTeacher);
            this.groupBox2.Controls.Add(indexLabel);
            this.groupBox2.Controls.Add(this.txtShortCode);
            this.groupBox2.Controls.Add(this.txtClassName);
            this.groupBox2.Controls.Add(schoolNameLabel);
            this.groupBox2.Controls.Add(telephoneLabel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(579, 288);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(117, 252);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(379, 21);
            this.cboStatus.TabIndex = 8;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(117, 226);
            this.txtRemarks.MaxLength = 250;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(379, 20);
            this.txtRemarks.TabIndex = 7;
            // 
            // txtNextYearLevel
            // 
            this.txtNextYearLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNextYearLevel.Location = new System.Drawing.Point(117, 196);
            this.txtNextYearLevel.MaxLength = 4;
            this.txtNextYearLevel.Name = "txtNextYearLevel";
            this.txtNextYearLevel.Size = new System.Drawing.Size(379, 20);
            this.txtNextYearLevel.TabIndex = 6;
            this.txtNextYearLevel.Text = "0";
            this.txtNextYearLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNextYearLevel_KeyDown);
            this.txtNextYearLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNextYearLevel_KeyPress);
            // 
            // txtNoOfSubjects
            // 
            this.txtNoOfSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoOfSubjects.Location = new System.Drawing.Point(117, 105);
            this.txtNoOfSubjects.MaxLength = 4;
            this.txtNoOfSubjects.Name = "txtNoOfSubjects";
            this.txtNoOfSubjects.Size = new System.Drawing.Size(379, 20);
            this.txtNoOfSubjects.TabIndex = 3;
            this.txtNoOfSubjects.Text = "0";
            this.txtNoOfSubjects.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoOfSubjects_KeyDown);
            this.txtNoOfSubjects.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoOfSubjects_KeyPress);
            // 
            // txtCurrentYearLevel
            // 
            this.txtCurrentYearLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCurrentYearLevel.Location = new System.Drawing.Point(117, 166);
            this.txtCurrentYearLevel.MaxLength = 4;
            this.txtCurrentYearLevel.Name = "txtCurrentYearLevel";
            this.txtCurrentYearLevel.Size = new System.Drawing.Size(379, 20);
            this.txtCurrentYearLevel.TabIndex = 5;
            this.txtCurrentYearLevel.Text = "0";
            this.txtCurrentYearLevel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurrentYearLevel_KeyDown);
            this.txtCurrentYearLevel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCurrentYearLevel_KeyPress);
            // 
            // cboProgrammeYears
            // 
            this.cboProgrammeYears.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProgrammeYears.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboProgrammeYears.FormattingEnabled = true;
            this.cboProgrammeYears.Location = new System.Drawing.Point(117, 74);
            this.cboProgrammeYears.Name = "cboProgrammeYears";
            this.cboProgrammeYears.Size = new System.Drawing.Size(379, 21);
            this.cboProgrammeYears.TabIndex = 2;
            // 
            // cboClassTeacher
            // 
            this.cboClassTeacher.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassTeacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboClassTeacher.FormattingEnabled = true;
            this.cboClassTeacher.Location = new System.Drawing.Point(117, 135);
            this.cboClassTeacher.Name = "cboClassTeacher";
            this.cboClassTeacher.Size = new System.Drawing.Size(379, 21);
            this.cboClassTeacher.TabIndex = 4;
            // 
            // txtShortCode
            // 
            this.txtShortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortCode.Location = new System.Drawing.Point(117, 14);
            this.txtShortCode.MaxLength = 15;
            this.txtShortCode.Name = "txtShortCode";
            this.txtShortCode.Size = new System.Drawing.Size(379, 20);
            this.txtShortCode.TabIndex = 0;
            // 
            // txtClassName
            // 
            this.txtClassName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClassName.Location = new System.Drawing.Point(117, 44);
            this.txtClassName.MaxLength = 100;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(379, 20);
            this.txtClassName.TabIndex = 1;
            // 
            // AddClassForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(579, 323);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddClassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Class";
            this.Load += new System.EventHandler(this.AddClassForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCurrentYearLevel;
        private System.Windows.Forms.ComboBox cboProgrammeYears;
        private System.Windows.Forms.ComboBox cboClassTeacher;
        private System.Windows.Forms.TextBox txtShortCode;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtNextYearLevel;
        private System.Windows.Forms.TextBox txtNoOfSubjects;
        private System.Windows.Forms.ComboBox cboStatus;
    }
}