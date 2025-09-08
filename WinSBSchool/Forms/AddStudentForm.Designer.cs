namespace WinSBSchool.Forms
{
    partial class AddStudentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStudentForm));
            this.btnAddNewStudent = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.lblNoofYears = new System.Windows.Forms.Label();
            this.cboStudentAdmissionType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUploadPhoto = new System.Windows.Forms.LinkLabel();
            this.imgStudentPhoto = new System.Windows.Forms.PictureBox();
            this.cboCurrentClass = new System.Windows.Forms.ComboBox();
            this.label55 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtKCPE = new System.Windows.Forms.TextBox();
            this.txtHomePage = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtAdmittedBy = new System.Windows.Forms.TextBox();
            this.txtOtherNames = new System.Windows.Forms.TextBox();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtAdminNo = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label45 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.cboSchool = new System.Windows.Forms.ComboBox();
            this.label51 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.dpAdmissionDate = new System.Windows.Forms.DateTimePicker();
            this.dpDOB = new System.Windows.Forms.DateTimePicker();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtKCSE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label47 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStudentPhoto)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddNewStudent
            // 
            this.btnAddNewStudent.AutoSize = true;
            this.btnAddNewStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddNewStudent.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddNewStudent.Location = new System.Drawing.Point(346, 11);
            this.btnAddNewStudent.Name = "btnAddNewStudent";
            this.btnAddNewStudent.Size = new System.Drawing.Size(36, 18);
            this.btnAddNewStudent.TabIndex = 0;
            this.btnAddNewStudent.TabStop = true;
            this.btnAddNewStudent.Text = "Add";
            this.btnAddNewStudent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(420, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnAddNewStudent);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 469);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(762, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(762, 469);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage7);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(3, 16);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(756, 450);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage7.Controls.Add(this.cboStatus);
            this.tabPage7.Controls.Add(this.label47);
            this.tabPage7.Controls.Add(this.txtKCSE);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.lblNoofYears);
            this.tabPage7.Controls.Add(this.cboStudentAdmissionType);
            this.tabPage7.Controls.Add(this.label1);
            this.tabPage7.Controls.Add(this.btnUploadPhoto);
            this.tabPage7.Controls.Add(this.imgStudentPhoto);
            this.tabPage7.Controls.Add(this.cboCurrentClass);
            this.tabPage7.Controls.Add(this.label55);
            this.tabPage7.Controls.Add(this.txtEmail);
            this.tabPage7.Controls.Add(this.txtPhone);
            this.tabPage7.Controls.Add(this.txtAddress);
            this.tabPage7.Controls.Add(this.txtKCPE);
            this.tabPage7.Controls.Add(this.txtHomePage);
            this.tabPage7.Controls.Add(this.txtRemarks);
            this.tabPage7.Controls.Add(this.txtAdmittedBy);
            this.tabPage7.Controls.Add(this.txtOtherNames);
            this.tabPage7.Controls.Add(this.txtSurname);
            this.tabPage7.Controls.Add(this.txtAdminNo);
            this.tabPage7.Controls.Add(this.label44);
            this.tabPage7.Controls.Add(this.label45);
            this.tabPage7.Controls.Add(this.label46);
            this.tabPage7.Controls.Add(this.label49);
            this.tabPage7.Controls.Add(this.label50);
            this.tabPage7.Controls.Add(this.cboSchool);
            this.tabPage7.Controls.Add(this.label51);
            this.tabPage7.Controls.Add(this.label52);
            this.tabPage7.Controls.Add(this.cboGender);
            this.tabPage7.Controls.Add(this.dpAdmissionDate);
            this.tabPage7.Controls.Add(this.dpDOB);
            this.tabPage7.Controls.Add(this.label53);
            this.tabPage7.Controls.Add(this.label54);
            this.tabPage7.Controls.Add(this.label56);
            this.tabPage7.Controls.Add(this.label57);
            this.tabPage7.Controls.Add(this.label58);
            this.tabPage7.Controls.Add(this.label59);
            this.tabPage7.Controls.Add(this.label60);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(748, 424);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Student Info";
            // 
            // lblNoofYears
            // 
            this.lblNoofYears.AutoSize = true;
            this.lblNoofYears.Location = new System.Drawing.Point(236, 202);
            this.lblNoofYears.Name = "lblNoofYears";
            this.lblNoofYears.Size = new System.Drawing.Size(41, 13);
            this.lblNoofYears.TabIndex = 73;
            this.lblNoofYears.Text = "0 years";
            // 
            // cboStudentAdmissionType
            // 
            this.cboStudentAdmissionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStudentAdmissionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStudentAdmissionType.FormattingEnabled = true;
            this.cboStudentAdmissionType.Location = new System.Drawing.Point(94, 346);
            this.cboStudentAdmissionType.Name = "cboStudentAdmissionType";
            this.cboStudentAdmissionType.Size = new System.Drawing.Size(197, 21);
            this.cboStudentAdmissionType.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 350);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 72;
            this.label1.Text = "Admission Type";
            // 
            // btnUploadPhoto
            // 
            this.btnUploadPhoto.AutoSize = true;
            this.btnUploadPhoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadPhoto.LinkColor = System.Drawing.Color.Yellow;
            this.btnUploadPhoto.Location = new System.Drawing.Point(428, 368);
            this.btnUploadPhoto.Name = "btnUploadPhoto";
            this.btnUploadPhoto.Size = new System.Drawing.Size(103, 16);
            this.btnUploadPhoto.TabIndex = 17;
            this.btnUploadPhoto.TabStop = true;
            this.btnUploadPhoto.Text = "Upload Photo";
            this.btnUploadPhoto.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUploadPhoto_LinkClicked);
            // 
            // imgStudentPhoto
            // 
            this.imgStudentPhoto.ErrorImage = global::WinSBSchool.Properties.Resources.defaultphoto;
            this.imgStudentPhoto.Location = new System.Drawing.Point(426, 184);
            this.imgStudentPhoto.Name = "imgStudentPhoto";
            this.imgStudentPhoto.Size = new System.Drawing.Size(275, 179);
            this.imgStudentPhoto.TabIndex = 69;
            this.imgStudentPhoto.TabStop = false;
            // 
            // cboCurrentClass
            // 
            this.cboCurrentClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCurrentClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCurrentClass.FormattingEnabled = true;
            this.cboCurrentClass.Location = new System.Drawing.Point(94, 42);
            this.cboCurrentClass.Name = "cboCurrentClass";
            this.cboCurrentClass.Size = new System.Drawing.Size(197, 21);
            this.cboCurrentClass.TabIndex = 1;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(18, 45);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(73, 13);
            this.label55.TabIndex = 66;
            this.label55.Text = "Current Class*";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(94, 256);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(197, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(94, 226);
            this.txtPhone.MaxLength = 50;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(197, 20);
            this.txtPhone.TabIndex = 7;
            this.txtPhone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPhone_KeyDown);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(94, 286);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(197, 20);
            this.txtAddress.TabIndex = 9;
            // 
            // txtKCPE
            // 
            this.txtKCPE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKCPE.Location = new System.Drawing.Point(493, 14);
            this.txtKCPE.MaxLength = 50;
            this.txtKCPE.Name = "txtKCPE";
            this.txtKCPE.Size = new System.Drawing.Size(208, 20);
            this.txtKCPE.TabIndex = 12;
            this.txtKCPE.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKCPE_KeyDown);
            this.txtKCPE.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKCPE_KeyPress);
            // 
            // txtHomePage
            // 
            this.txtHomePage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHomePage.Location = new System.Drawing.Point(94, 316);
            this.txtHomePage.MaxLength = 50;
            this.txtHomePage.Name = "txtHomePage";
            this.txtHomePage.Size = new System.Drawing.Size(197, 20);
            this.txtHomePage.TabIndex = 10;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(493, 108);
            this.txtRemarks.MaxLength = 500;
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(208, 22);
            this.txtRemarks.TabIndex = 16;
            // 
            // txtAdmittedBy
            // 
            this.txtAdmittedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdmittedBy.Location = new System.Drawing.Point(493, 77);
            this.txtAdmittedBy.MaxLength = 50;
            this.txtAdmittedBy.Name = "txtAdmittedBy";
            this.txtAdmittedBy.Size = new System.Drawing.Size(208, 20);
            this.txtAdmittedBy.TabIndex = 15;
            // 
            // txtOtherNames
            // 
            this.txtOtherNames.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOtherNames.Location = new System.Drawing.Point(94, 135);
            this.txtOtherNames.MaxLength = 50;
            this.txtOtherNames.Name = "txtOtherNames";
            this.txtOtherNames.Size = new System.Drawing.Size(197, 20);
            this.txtOtherNames.TabIndex = 4;
            // 
            // txtSurname
            // 
            this.txtSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSurname.Location = new System.Drawing.Point(94, 105);
            this.txtSurname.MaxLength = 50;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(197, 20);
            this.txtSurname.TabIndex = 3;
            // 
            // txtAdminNo
            // 
            this.txtAdminNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminNo.Location = new System.Drawing.Point(94, 74);
            this.txtAdminNo.MaxLength = 50;
            this.txtAdminNo.Name = "txtAdminNo";
            this.txtAdminNo.Size = new System.Drawing.Size(197, 20);
            this.txtAdminNo.TabIndex = 2;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(60, 259);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(32, 13);
            this.label44.TabIndex = 64;
            this.label44.Text = "Email";
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(54, 229);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(38, 13);
            this.label45.TabIndex = 63;
            this.label45.Text = "Phone";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(47, 289);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(45, 13);
            this.label46.TabIndex = 61;
            this.label46.Text = "Address";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(456, 17);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(35, 13);
            this.label49.TabIndex = 54;
            this.label49.Text = "KCPE";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(29, 319);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(63, 13);
            this.label50.TabIndex = 35;
            this.label50.Text = "Home Page";
            // 
            // cboSchool
            // 
            this.cboSchool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSchool.FormattingEnabled = true;
            this.cboSchool.Location = new System.Drawing.Point(94, 11);
            this.cboSchool.Name = "cboSchool";
            this.cboSchool.Size = new System.Drawing.Size(267, 21);
            this.cboSchool.TabIndex = 0;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(47, 14);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(44, 13);
            this.label51.TabIndex = 32;
            this.label51.Text = "School*";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(442, 111);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(49, 13);
            this.label52.TabIndex = 28;
            this.label52.Text = "Remarks";
            // 
            // cboGender
            // 
            this.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(94, 165);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(197, 21);
            this.cboGender.TabIndex = 5;
            // 
            // dpAdmissionDate
            // 
            this.dpAdmissionDate.Location = new System.Drawing.Point(493, 46);
            this.dpAdmissionDate.Name = "dpAdmissionDate";
            this.dpAdmissionDate.Size = new System.Drawing.Size(208, 20);
            this.dpAdmissionDate.TabIndex = 14;
            // 
            // dpDOB
            // 
            this.dpDOB.CustomFormat = "";
            this.dpDOB.Location = new System.Drawing.Point(94, 196);
            this.dpDOB.Name = "dpDOB";
            this.dpDOB.Size = new System.Drawing.Size(136, 20);
            this.dpDOB.TabIndex = 6;
            this.dpDOB.ValueChanged += new System.EventHandler(this.dpDOB_ValueChanged);
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(412, 49);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(80, 13);
            this.label53.TabIndex = 23;
            this.label53.Text = "Admission Date";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(428, 80);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(63, 13);
            this.label54.TabIndex = 22;
            this.label54.Text = "Admitted By";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(45, 168);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(46, 13);
            this.label56.TabIndex = 14;
            this.label56.Text = "Gender*";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Location = new System.Drawing.Point(27, 200);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(66, 13);
            this.label57.TabIndex = 12;
            this.label57.Text = "Date of Birth";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Location = new System.Drawing.Point(19, 138);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(73, 13);
            this.label58.TabIndex = 6;
            this.label58.Text = "Other Names*";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Location = new System.Drawing.Point(39, 108);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(53, 13);
            this.label59.TabIndex = 4;
            this.label59.Text = "Surname*";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Location = new System.Drawing.Point(17, 77);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(75, 13);
            this.label60.TabIndex = 0;
            this.label60.Text = "Admission No*";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtKCSE
            // 
            this.txtKCSE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKCSE.Location = new System.Drawing.Point(94, 383);
            this.txtKCSE.MaxLength = 50;
            this.txtKCSE.Name = "txtKCSE";
            this.txtKCSE.Size = new System.Drawing.Size(197, 20);
            this.txtKCSE.TabIndex = 74;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 386);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 75;
            this.label2.Text = "KCSE";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(493, 140);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(208, 21);
            this.cboStatus.TabIndex = 76;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(453, 144);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(37, 13);
            this.label47.TabIndex = 77;
            this.label47.Text = "Status";
            // 
            // AddStudentForm
            // 
            this.AcceptButton = this.btnAddNewStudent;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(762, 514);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New Student";
            this.Load += new System.EventHandler(this.AddStudentForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgStudentPhoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnAddNewStudent;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.ComboBox cboCurrentClass;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtKCPE;
        private System.Windows.Forms.TextBox txtHomePage;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtAdmittedBy;
        private System.Windows.Forms.TextBox txtOtherNames;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.TextBox txtAdminNo;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.ComboBox cboSchool;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.DateTimePicker dpAdmissionDate;
        private System.Windows.Forms.DateTimePicker dpDOB;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.LinkLabel btnUploadPhoto;
        private System.Windows.Forms.PictureBox imgStudentPhoto;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ComboBox cboStudentAdmissionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNoofYears;
        private System.Windows.Forms.TextBox txtKCSE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label47;
    }
}