namespace WinSBSchool.Forms
{
    partial class EditProgrammeForm
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
            System.Windows.Forms.Label label15;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditProgrammeForm));
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnUpdate = new System.Windows.Forms.LinkLabel();
            this.bindingSourceProgrammeCourses = new System.Windows.Forms.BindingSource(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControlProgrammes = new System.Windows.Forms.TabControl();
            this.tabPageProgrammeDetails = new System.Windows.Forms.TabPage();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.chkIsDefaultProgramme = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.txtHours = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtShortCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageProgrammeYears = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listViewProgrammeYears = new System.Windows.Forms.ListView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtPrYrDescription = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtPYrFees = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNextYear = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddProgrammeYear = new System.Windows.Forms.LinkLabel();
            this.btnDeleteProgrammeYear = new System.Windows.Forms.LinkLabel();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageProgrammeYearCourses = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ListViewProgrammeYearCourses = new System.Windows.Forms.ListView();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtRetakeFees = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtExamFees = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtTuitionFees = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPYCNoOfHours = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSemester = new System.Windows.Forms.TextBox();
            this.btnDeleteProgrammeYearCourse = new System.Windows.Forms.LinkLabel();
            this.cboprogrammecourses = new System.Windows.Forms.ComboBox();
            this.btnAddProgrammeYearCourse = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProgrammeCourses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControlProgrammes.SuspendLayout();
            this.tabPageProgrammeDetails.SuspendLayout();
            this.tabPageProgrammeYears.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPageProgrammeYearCourses.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(137, 238);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(41, 13);
            label15.TabIndex = 63;
            label15.Text = "Status*";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(391, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.LinkColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(264, 11);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(61, 18);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = true;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUpdate_LinkClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 424);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 37);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControlProgrammes);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 424);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // tabControlProgrammes
            // 
            this.tabControlProgrammes.Controls.Add(this.tabPageProgrammeDetails);
            this.tabControlProgrammes.Controls.Add(this.tabPageProgrammeYears);
            this.tabControlProgrammes.Controls.Add(this.tabPageProgrammeYearCourses);
            this.tabControlProgrammes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlProgrammes.Location = new System.Drawing.Point(3, 16);
            this.tabControlProgrammes.Name = "tabControlProgrammes";
            this.tabControlProgrammes.SelectedIndex = 0;
            this.tabControlProgrammes.Size = new System.Drawing.Size(728, 405);
            this.tabControlProgrammes.TabIndex = 0;
            this.tabControlProgrammes.SelectedIndexChanged += new System.EventHandler(this.tabControlProgrammes_SelectedIndexChanged);
            // 
            // tabPageProgrammeDetails
            // 
            this.tabPageProgrammeDetails.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageProgrammeDetails.Controls.Add(this.cboStatus);
            this.tabPageProgrammeDetails.Controls.Add(label15);
            this.tabPageProgrammeDetails.Controls.Add(this.chkIsDefaultProgramme);
            this.tabPageProgrammeDetails.Controls.Add(this.label1);
            this.tabPageProgrammeDetails.Controls.Add(this.txtFees);
            this.tabPageProgrammeDetails.Controls.Add(this.txtHours);
            this.tabPageProgrammeDetails.Controls.Add(this.label4);
            this.tabPageProgrammeDetails.Controls.Add(this.label7);
            this.tabPageProgrammeDetails.Controls.Add(this.txtDescription);
            this.tabPageProgrammeDetails.Controls.Add(this.txtShortCode);
            this.tabPageProgrammeDetails.Controls.Add(this.label2);
            this.tabPageProgrammeDetails.Location = new System.Drawing.Point(4, 22);
            this.tabPageProgrammeDetails.Name = "tabPageProgrammeDetails";
            this.tabPageProgrammeDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProgrammeDetails.Size = new System.Drawing.Size(720, 379);
            this.tabPageProgrammeDetails.TabIndex = 0;
            this.tabPageProgrammeDetails.Text = "Programme";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(181, 234);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(347, 21);
            this.cboStatus.TabIndex = 4;
            // 
            // chkIsDefaultProgramme
            // 
            this.chkIsDefaultProgramme.AutoSize = true;
            this.chkIsDefaultProgramme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsDefaultProgramme.Location = new System.Drawing.Point(181, 269);
            this.chkIsDefaultProgramme.Name = "chkIsDefaultProgramme";
            this.chkIsDefaultProgramme.Size = new System.Drawing.Size(117, 17);
            this.chkIsDefaultProgramme.TabIndex = 5;
            this.chkIsDefaultProgramme.Text = "Default Programme*";
            this.chkIsDefaultProgramme.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Short Code*";
            // 
            // txtFees
            // 
            this.txtFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFees.Location = new System.Drawing.Point(181, 199);
            this.txtFees.MaxLength = 8;
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(347, 20);
            this.txtFees.TabIndex = 3;
            this.txtFees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFees_KeyDown);
            this.txtFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFees_KeyPress);
            // 
            // txtHours
            // 
            this.txtHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHours.Location = new System.Drawing.Point(181, 160);
            this.txtHours.MaxLength = 4;
            this.txtHours.Name = "txtHours";
            this.txtHours.Size = new System.Drawing.Size(347, 20);
            this.txtHours.TabIndex = 2;
            this.txtHours.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtHours_KeyDown);
            this.txtHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtHours_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(149, 202);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Fees";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(144, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Hours";
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(181, 121);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(347, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // txtShortCode
            // 
            this.txtShortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortCode.Location = new System.Drawing.Point(181, 82);
            this.txtShortCode.MaxLength = 10;
            this.txtShortCode.Name = "txtShortCode";
            this.txtShortCode.Size = new System.Drawing.Size(347, 20);
            this.txtShortCode.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description*";
            // 
            // tabPageProgrammeYears
            // 
            this.tabPageProgrammeYears.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageProgrammeYears.Controls.Add(this.groupBox3);
            this.tabPageProgrammeYears.Controls.Add(this.groupBox4);
            this.tabPageProgrammeYears.Location = new System.Drawing.Point(4, 22);
            this.tabPageProgrammeYears.Name = "tabPageProgrammeYears";
            this.tabPageProgrammeYears.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProgrammeYears.Size = new System.Drawing.Size(720, 379);
            this.tabPageProgrammeYears.TabIndex = 2;
            this.tabPageProgrammeYears.Text = "Programme Years";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listViewProgrammeYears);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(471, 373);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // listViewProgrammeYears
            // 
            this.listViewProgrammeYears.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewProgrammeYears.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewProgrammeYears.FullRowSelect = true;
            this.listViewProgrammeYears.GridLines = true;
            this.listViewProgrammeYears.HideSelection = false;
            this.listViewProgrammeYears.HoverSelection = true;
            this.listViewProgrammeYears.Location = new System.Drawing.Point(3, 16);
            this.listViewProgrammeYears.MultiSelect = false;
            this.listViewProgrammeYears.Name = "listViewProgrammeYears";
            this.listViewProgrammeYears.ShowItemToolTips = true;
            this.listViewProgrammeYears.Size = new System.Drawing.Size(465, 354);
            this.listViewProgrammeYears.TabIndex = 0;
            this.listViewProgrammeYears.UseCompatibleStateImageBehavior = false;
            this.listViewProgrammeYears.View = System.Windows.Forms.View.Details;
            this.listViewProgrammeYears.SelectedIndexChanged += new System.EventHandler(this.listViewProgrammeYears_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtPrYrDescription);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.txtPYrFees);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txtNextYear);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.btnAddProgrammeYear);
            this.groupBox4.Controls.Add(this.btnDeleteProgrammeYear);
            this.groupBox4.Controls.Add(this.txtYear);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(474, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(243, 373);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // txtPrYrDescription
            // 
            this.txtPrYrDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrYrDescription.Location = new System.Drawing.Point(80, 83);
            this.txtPrYrDescription.MaxLength = 250;
            this.txtPrYrDescription.Name = "txtPrYrDescription";
            this.txtPrYrDescription.Size = new System.Drawing.Size(135, 20);
            this.txtPrYrDescription.TabIndex = 1;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 13);
            this.label14.TabIndex = 66;
            this.label14.Text = "Description*";
            // 
            // txtPYrFees
            // 
            this.txtPYrFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPYrFees.Location = new System.Drawing.Point(80, 155);
            this.txtPYrFees.MaxLength = 8;
            this.txtPYrFees.Name = "txtPYrFees";
            this.txtPYrFees.Size = new System.Drawing.Size(135, 20);
            this.txtPYrFees.TabIndex = 3;
            this.txtPYrFees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPYrFees_KeyDown);
            this.txtPYrFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPYrFees_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "Fees";
            // 
            // txtNextYear
            // 
            this.txtNextYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNextYear.Location = new System.Drawing.Point(80, 119);
            this.txtNextYear.MaxLength = 1;
            this.txtNextYear.Name = "txtNextYear";
            this.txtNextYear.Size = new System.Drawing.Size(135, 20);
            this.txtNextYear.TabIndex = 2;
            this.txtNextYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNextYear_KeyDown);
            this.txtNextYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNextYear_KeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 122);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Next Year";
            // 
            // btnAddProgrammeYear
            // 
            this.btnAddProgrammeYear.AutoSize = true;
            this.btnAddProgrammeYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddProgrammeYear.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddProgrammeYear.Location = new System.Drawing.Point(79, 223);
            this.btnAddProgrammeYear.Name = "btnAddProgrammeYear";
            this.btnAddProgrammeYear.Size = new System.Drawing.Size(36, 18);
            this.btnAddProgrammeYear.TabIndex = 4;
            this.btnAddProgrammeYear.TabStop = true;
            this.btnAddProgrammeYear.Text = "Add";
            this.btnAddProgrammeYear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddProgrammeYear_LinkClicked);
            // 
            // btnDeleteProgrammeYear
            // 
            this.btnDeleteProgrammeYear.AutoSize = true;
            this.btnDeleteProgrammeYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteProgrammeYear.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteProgrammeYear.Location = new System.Drawing.Point(145, 223);
            this.btnDeleteProgrammeYear.Name = "btnDeleteProgrammeYear";
            this.btnDeleteProgrammeYear.Size = new System.Drawing.Size(56, 18);
            this.btnDeleteProgrammeYear.TabIndex = 5;
            this.btnDeleteProgrammeYear.TabStop = true;
            this.btnDeleteProgrammeYear.Text = "Delete";
            this.btnDeleteProgrammeYear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteProgrammeYear_LinkClicked);
            // 
            // txtYear
            // 
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtYear.Location = new System.Drawing.Point(80, 47);
            this.txtYear.MaxLength = 1;
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(135, 20);
            this.txtYear.TabIndex = 0;
            this.txtYear.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtYear_KeyDown);
            this.txtYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYear_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(45, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Year*";
            // 
            // tabPageProgrammeYearCourses
            // 
            this.tabPageProgrammeYearCourses.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageProgrammeYearCourses.Controls.Add(this.groupBox5);
            this.tabPageProgrammeYearCourses.Controls.Add(this.groupBox6);
            this.tabPageProgrammeYearCourses.Location = new System.Drawing.Point(4, 22);
            this.tabPageProgrammeYearCourses.Name = "tabPageProgrammeYearCourses";
            this.tabPageProgrammeYearCourses.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProgrammeYearCourses.Size = new System.Drawing.Size(720, 379);
            this.tabPageProgrammeYearCourses.TabIndex = 1;
            this.tabPageProgrammeYearCourses.Text = "Programme Year Courses";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ListViewProgrammeYearCourses);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(484, 373);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            // 
            // ListViewProgrammeYearCourses
            // 
            this.ListViewProgrammeYearCourses.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewProgrammeYearCourses.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListViewProgrammeYearCourses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewProgrammeYearCourses.FullRowSelect = true;
            this.ListViewProgrammeYearCourses.GridLines = true;
            this.ListViewProgrammeYearCourses.HideSelection = false;
            this.ListViewProgrammeYearCourses.HotTracking = true;
            this.ListViewProgrammeYearCourses.HoverSelection = true;
            this.ListViewProgrammeYearCourses.Location = new System.Drawing.Point(3, 16);
            this.ListViewProgrammeYearCourses.MultiSelect = false;
            this.ListViewProgrammeYearCourses.Name = "ListViewProgrammeYearCourses";
            this.ListViewProgrammeYearCourses.ShowItemToolTips = true;
            this.ListViewProgrammeYearCourses.Size = new System.Drawing.Size(478, 354);
            this.ListViewProgrammeYearCourses.TabIndex = 5;
            this.ListViewProgrammeYearCourses.UseCompatibleStateImageBehavior = false;
            this.ListViewProgrammeYearCourses.View = System.Windows.Forms.View.Details;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtRetakeFees);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.txtExamFees);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Controls.Add(this.txtTuitionFees);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.txtPYCNoOfHours);
            this.groupBox6.Controls.Add(this.label10);
            this.groupBox6.Controls.Add(this.txtSemester);
            this.groupBox6.Controls.Add(this.btnDeleteProgrammeYearCourse);
            this.groupBox6.Controls.Add(this.cboprogrammecourses);
            this.groupBox6.Controls.Add(this.btnAddProgrammeYearCourse);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.Location = new System.Drawing.Point(487, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(230, 373);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // txtRetakeFees
            // 
            this.txtRetakeFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRetakeFees.Location = new System.Drawing.Point(81, 235);
            this.txtRetakeFees.MaxLength = 8;
            this.txtRetakeFees.Name = "txtRetakeFees";
            this.txtRetakeFees.Size = new System.Drawing.Size(122, 20);
            this.txtRetakeFees.TabIndex = 5;
            this.txtRetakeFees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResitFees_KeyDown);
            this.txtRetakeFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResitFees_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 238);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 65;
            this.label13.Text = "Retake Fees";
            // 
            // txtExamFees
            // 
            this.txtExamFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExamFees.Location = new System.Drawing.Point(81, 195);
            this.txtExamFees.MaxLength = 8;
            this.txtExamFees.Name = "txtExamFees";
            this.txtExamFees.Size = new System.Drawing.Size(122, 20);
            this.txtExamFees.TabIndex = 4;
            this.txtExamFees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExamFees_KeyDown);
            this.txtExamFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtExamFees_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 198);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "Exam Fees";
            // 
            // txtTuitionFees
            // 
            this.txtTuitionFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTuitionFees.Location = new System.Drawing.Point(81, 155);
            this.txtTuitionFees.MaxLength = 8;
            this.txtTuitionFees.Name = "txtTuitionFees";
            this.txtTuitionFees.Size = new System.Drawing.Size(122, 20);
            this.txtTuitionFees.TabIndex = 3;
            this.txtTuitionFees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTuitionFees_KeyDown);
            this.txtTuitionFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTuitionFees_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 158);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 61;
            this.label11.Text = "Tuition Fees*";
            // 
            // txtPYCNoOfHours
            // 
            this.txtPYCNoOfHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPYCNoOfHours.Location = new System.Drawing.Point(81, 115);
            this.txtPYCNoOfHours.MaxLength = 4;
            this.txtPYCNoOfHours.Name = "txtPYCNoOfHours";
            this.txtPYCNoOfHours.Size = new System.Drawing.Size(122, 20);
            this.txtPYCNoOfHours.TabIndex = 2;
            this.txtPYCNoOfHours.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPYCNoOfHours_KeyDown);
            this.txtPYCNoOfHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPYCNoOfHours_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(11, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 13);
            this.label10.TabIndex = 59;
            this.label10.Text = "No of Hours*";
            // 
            // txtSemester
            // 
            this.txtSemester.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSemester.Location = new System.Drawing.Point(81, 75);
            this.txtSemester.MaxLength = 1;
            this.txtSemester.Name = "txtSemester";
            this.txtSemester.Size = new System.Drawing.Size(122, 20);
            this.txtSemester.TabIndex = 1;
            this.txtSemester.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSemester_KeyDown);
            this.txtSemester.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSemester_KeyPress);
            // 
            // btnDeleteProgrammeYearCourse
            // 
            this.btnDeleteProgrammeYearCourse.AutoSize = true;
            this.btnDeleteProgrammeYearCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteProgrammeYearCourse.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteProgrammeYearCourse.Location = new System.Drawing.Point(129, 289);
            this.btnDeleteProgrammeYearCourse.Name = "btnDeleteProgrammeYearCourse";
            this.btnDeleteProgrammeYearCourse.Size = new System.Drawing.Size(56, 18);
            this.btnDeleteProgrammeYearCourse.TabIndex = 7;
            this.btnDeleteProgrammeYearCourse.TabStop = true;
            this.btnDeleteProgrammeYearCourse.Text = "Delete";
            this.btnDeleteProgrammeYearCourse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteProgrammeYearCourse_LinkClicked);
            // 
            // cboprogrammecourses
            // 
            this.cboprogrammecourses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboprogrammecourses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboprogrammecourses.FormattingEnabled = true;
            this.cboprogrammecourses.Location = new System.Drawing.Point(81, 34);
            this.cboprogrammecourses.Name = "cboprogrammecourses";
            this.cboprogrammecourses.Size = new System.Drawing.Size(122, 21);
            this.cboprogrammecourses.TabIndex = 0;
            // 
            // btnAddProgrammeYearCourse
            // 
            this.btnAddProgrammeYearCourse.AutoSize = true;
            this.btnAddProgrammeYearCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddProgrammeYearCourse.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddProgrammeYearCourse.Location = new System.Drawing.Point(73, 289);
            this.btnAddProgrammeYearCourse.Name = "btnAddProgrammeYearCourse";
            this.btnAddProgrammeYearCourse.Size = new System.Drawing.Size(36, 18);
            this.btnAddProgrammeYearCourse.TabIndex = 6;
            this.btnAddProgrammeYearCourse.TabStop = true;
            this.btnAddProgrammeYearCourse.Text = "Add";
            this.btnAddProgrammeYearCourse.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddProgrammeYearCourse_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Semester*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 53;
            this.label5.Text = "Course*";
            // 
            // EditProgrammeForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditProgrammeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditProgrammeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceProgrammeCourses)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControlProgrammes.ResumeLayout(false);
            this.tabPageProgrammeDetails.ResumeLayout(false);
            this.tabPageProgrammeDetails.PerformLayout();
            this.tabPageProgrammeYears.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageProgrammeYearCourses.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnUpdate;
        private System.Windows.Forms.BindingSource bindingSourceProgrammeCourses;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControlProgrammes;
        private System.Windows.Forms.TabPage tabPageProgrammeDetails;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.TextBox txtHours;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtShortCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tabPageProgrammeYears;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listViewProgrammeYears;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnAddProgrammeYear;
        private System.Windows.Forms.LinkLabel btnDeleteProgrammeYear;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPageProgrammeYearCourses;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ListView ListViewProgrammeYearCourses;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.LinkLabel btnDeleteProgrammeYearCourse;
        private System.Windows.Forms.LinkLabel btnAddProgrammeYearCourse;
        private System.Windows.Forms.TextBox txtSemester;
        private System.Windows.Forms.ComboBox cboprogrammecourses;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPYrFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNextYear;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRetakeFees;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtExamFees;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtTuitionFees;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPYCNoOfHours;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPrYrDescription;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chkIsDefaultProgramme;
        private System.Windows.Forms.ComboBox cboStatus;
    }
}