namespace WinSBSchool.Forms
{
    partial class EditSchoolForm
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
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label indexLabel;
            System.Windows.Forms.Label schoolNameLabel;
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label address2Label;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label telephoneLabel;
            System.Windows.Forms.Label cellphoneLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSchoolForm));
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnUpdate = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtSlogan = new System.Windows.Forms.TextBox();
            this.txtLogo = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.btnCreateSCustomer = new System.Windows.Forms.LinkLabel();
            this.btnSearchCustomerId = new System.Windows.Forms.Button();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.cboGradingSystem = new System.Windows.Forms.ComboBox();
            this.cboSchoolType = new System.Windows.Forms.ComboBox();
            this.chkIsDefaultSchool = new System.Windows.Forms.CheckBox();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.txtSchoolName = new System.Windows.Forms.TextBox();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtSMTPServer = new System.Windows.Forms.TextBox();
            this.txtSMSGateway = new System.Windows.Forms.TextBox();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtCellPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            indexLabel = new System.Windows.Forms.Label();
            schoolNameLabel = new System.Windows.Forms.Label();
            address1Label = new System.Windows.Forms.Label();
            address2Label = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            telephoneLabel = new System.Windows.Forms.Label();
            cellphoneLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(41, 114);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(85, 13);
            label3.TabIndex = 82;
            label3.Text = "Grading System*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(55, 83);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(71, 13);
            label4.TabIndex = 81;
            label4.Text = "School Type*";
            // 
            // indexLabel
            // 
            indexLabel.AutoSize = true;
            indexLabel.Location = new System.Drawing.Point(54, 26);
            indexLabel.Name = "indexLabel";
            indexLabel.Size = new System.Drawing.Size(73, 13);
            indexLabel.TabIndex = 72;
            indexLabel.Text = "School Index*";
            // 
            // schoolNameLabel
            // 
            schoolNameLabel.AutoSize = true;
            schoolNameLabel.Location = new System.Drawing.Point(52, 55);
            schoolNameLabel.Name = "schoolNameLabel";
            schoolNameLabel.Size = new System.Drawing.Size(75, 13);
            schoolNameLabel.TabIndex = 73;
            schoolNameLabel.Text = "School Name*";
            // 
            // address1Label
            // 
            address1Label.AutoSize = true;
            address1Label.Location = new System.Drawing.Point(72, 173);
            address1Label.Name = "address1Label";
            address1Label.Size = new System.Drawing.Size(55, 13);
            address1Label.TabIndex = 77;
            address1Label.Text = "Address1*";
            // 
            // address2Label
            // 
            address2Label.AutoSize = true;
            address2Label.Location = new System.Drawing.Point(76, 201);
            address2Label.Name = "address2Label";
            address2Label.Size = new System.Drawing.Size(51, 13);
            address2Label.TabIndex = 78;
            address2Label.Text = "Address2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(11, 143);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(116, 13);
            label5.TabIndex = 86;
            label5.Text = "School Gl Customer Id*";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(85, 331);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 13);
            label6.TabIndex = 88;
            label6.Text = "Status*";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(20, 165);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 13);
            label1.TabIndex = 89;
            label1.Text = "SMTP Server";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(16, 193);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(75, 13);
            label2.TabIndex = 90;
            label2.Text = "SMS Gateway";
            // 
            // telephoneLabel
            // 
            telephoneLabel.AutoSize = true;
            telephoneLabel.Location = new System.Drawing.Point(33, 109);
            telephoneLabel.Name = "telephoneLabel";
            telephoneLabel.Size = new System.Drawing.Size(58, 13);
            telephoneLabel.TabIndex = 86;
            telephoneLabel.Text = "Telephone";
            // 
            // cellphoneLabel
            // 
            cellphoneLabel.AutoSize = true;
            cellphoneLabel.Location = new System.Drawing.Point(37, 81);
            cellphoneLabel.Name = "cellphoneLabel";
            cellphoneLabel.Size = new System.Drawing.Size(54, 13);
            cellphoneLabel.TabIndex = 87;
            cellphoneLabel.Text = "Cellphone";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(59, 137);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(32, 13);
            emailLabel.TabIndex = 88;
            emailLabel.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(83, 231);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(44, 13);
            label7.TabIndex = 98;
            label7.Text = "Slogan*";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(92, 260);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(35, 13);
            label8.TabIndex = 99;
            label8.Text = "Logo*";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(316, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.buttonClose_LinkClicked);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.LinkColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(174, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(61, 18);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = true;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUpdate_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 422);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 36);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.txtSlogan);
            this.groupBox2.Controls.Add(this.txtLogo);
            this.groupBox2.Controls.Add(label7);
            this.groupBox2.Controls.Add(label8);
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(label6);
            this.groupBox2.Controls.Add(this.btnCreateSCustomer);
            this.groupBox2.Controls.Add(this.btnSearchCustomerId);
            this.groupBox2.Controls.Add(this.txtAccountId);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(this.cboGradingSystem);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(this.cboSchoolType);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(this.chkIsDefaultSchool);
            this.groupBox2.Controls.Add(indexLabel);
            this.groupBox2.Controls.Add(this.txtIndex);
            this.groupBox2.Controls.Add(this.txtSchoolName);
            this.groupBox2.Controls.Add(this.txtAddress1);
            this.groupBox2.Controls.Add(this.txtAddress2);
            this.groupBox2.Controls.Add(schoolNameLabel);
            this.groupBox2.Controls.Add(address1Label);
            this.groupBox2.Controls.Add(address2Label);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 390);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Location = new System.Drawing.Point(406, 259);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(34, 23);
            this.btnBrowse.TabIndex = 9;
            this.btnBrowse.Text = ":::";
            this.btnBrowse.UseVisualStyleBackColor = false;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtSlogan
            // 
            this.txtSlogan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSlogan.Location = new System.Drawing.Point(129, 228);
            this.txtSlogan.MaxLength = 500;
            this.txtSlogan.Name = "txtSlogan";
            this.txtSlogan.Size = new System.Drawing.Size(315, 20);
            this.txtSlogan.TabIndex = 7;
            // 
            // txtLogo
            // 
            this.txtLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogo.Location = new System.Drawing.Point(129, 257);
            this.txtLogo.MaxLength = 800;
            this.txtLogo.Multiline = true;
            this.txtLogo.Name = "txtLogo";
            this.txtLogo.Size = new System.Drawing.Size(245, 62);
            this.txtLogo.TabIndex = 8;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(129, 328);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(315, 21);
            this.cboStatus.TabIndex = 10;
            // 
            // btnCreateSCustomer
            // 
            this.btnCreateSCustomer.AutoSize = true;
            this.btnCreateSCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateSCustomer.LinkColor = System.Drawing.Color.Yellow;
            this.btnCreateSCustomer.Location = new System.Drawing.Point(253, 143);
            this.btnCreateSCustomer.Name = "btnCreateSCustomer";
            this.btnCreateSCustomer.Size = new System.Drawing.Size(123, 16);
            this.btnCreateSCustomer.TabIndex = 13;
            this.btnCreateSCustomer.TabStop = true;
            this.btnCreateSCustomer.Text = "Create Customer";
            this.btnCreateSCustomer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCreateCustomer_LinkClicked);
            // 
            // btnSearchCustomerId
            // 
            this.btnSearchCustomerId.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchCustomerId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCustomerId.Location = new System.Drawing.Point(406, 141);
            this.btnSearchCustomerId.Name = "btnSearchCustomerId";
            this.btnSearchCustomerId.Size = new System.Drawing.Size(34, 23);
            this.btnSearchCustomerId.TabIndex = 14;
            this.btnSearchCustomerId.TabStop = false;
            this.btnSearchCustomerId.Text = ":::";
            this.btnSearchCustomerId.UseVisualStyleBackColor = false;
            this.btnSearchCustomerId.Click += new System.EventHandler(this.btnSearchCustomerId_Click);
            // 
            // txtAccountId
            // 
            this.txtAccountId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountId.Location = new System.Drawing.Point(129, 141);
            this.txtAccountId.MaxLength = 4;
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(89, 20);
            this.txtAccountId.TabIndex = 4;
            this.txtAccountId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            this.txtAccountId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerID_KeyPress);
            // 
            // cboGradingSystem
            // 
            this.cboGradingSystem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGradingSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboGradingSystem.FormattingEnabled = true;
            this.cboGradingSystem.Location = new System.Drawing.Point(129, 111);
            this.cboGradingSystem.Name = "cboGradingSystem";
            this.cboGradingSystem.Size = new System.Drawing.Size(313, 21);
            this.cboGradingSystem.TabIndex = 3;
            // 
            // cboSchoolType
            // 
            this.cboSchoolType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchoolType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSchoolType.FormattingEnabled = true;
            this.cboSchoolType.Location = new System.Drawing.Point(129, 81);
            this.cboSchoolType.Name = "cboSchoolType";
            this.cboSchoolType.Size = new System.Drawing.Size(313, 21);
            this.cboSchoolType.TabIndex = 2;
            // 
            // chkIsDefaultSchool
            // 
            this.chkIsDefaultSchool.AutoSize = true;
            this.chkIsDefaultSchool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkIsDefaultSchool.Location = new System.Drawing.Point(129, 358);
            this.chkIsDefaultSchool.Name = "chkIsDefaultSchool";
            this.chkIsDefaultSchool.Size = new System.Drawing.Size(97, 17);
            this.chkIsDefaultSchool.TabIndex = 11;
            this.chkIsDefaultSchool.Text = "Default School*";
            this.chkIsDefaultSchool.UseVisualStyleBackColor = true;
            // 
            // txtIndex
            // 
            this.txtIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIndex.Location = new System.Drawing.Point(129, 23);
            this.txtIndex.MaxLength = 250;
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(315, 20);
            this.txtIndex.TabIndex = 0;
            // 
            // txtSchoolName
            // 
            this.txtSchoolName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSchoolName.Location = new System.Drawing.Point(129, 52);
            this.txtSchoolName.MaxLength = 250;
            this.txtSchoolName.Name = "txtSchoolName";
            this.txtSchoolName.Size = new System.Drawing.Size(315, 20);
            this.txtSchoolName.TabIndex = 1;
            // 
            // txtAddress1
            // 
            this.txtAddress1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress1.Location = new System.Drawing.Point(129, 170);
            this.txtAddress1.MaxLength = 250;
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(315, 20);
            this.txtAddress1.TabIndex = 5;
            // 
            // txtAddress2
            // 
            this.txtAddress2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress2.Location = new System.Drawing.Point(129, 199);
            this.txtAddress2.MaxLength = 250;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(315, 20);
            this.txtAddress2.TabIndex = 6;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(491, 422);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(483, 396);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Info";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(483, 396);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Technical Info";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtSMTPServer);
            this.groupBox3.Controls.Add(this.txtSMSGateway);
            this.groupBox3.Controls.Add(label1);
            this.groupBox3.Controls.Add(label2);
            this.groupBox3.Controls.Add(this.txtTelephone);
            this.groupBox3.Controls.Add(this.txtCellPhone);
            this.groupBox3.Controls.Add(this.txtEmail);
            this.groupBox3.Controls.Add(telephoneLabel);
            this.groupBox3.Controls.Add(cellphoneLabel);
            this.groupBox3.Controls.Add(emailLabel);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(477, 390);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // txtSMTPServer
            // 
            this.txtSMTPServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSMTPServer.Location = new System.Drawing.Point(93, 162);
            this.txtSMTPServer.MaxLength = 250;
            this.txtSMTPServer.Name = "txtSMTPServer";
            this.txtSMTPServer.Size = new System.Drawing.Size(315, 20);
            this.txtSMTPServer.TabIndex = 3;
            // 
            // txtSMSGateway
            // 
            this.txtSMSGateway.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSMSGateway.Location = new System.Drawing.Point(93, 190);
            this.txtSMSGateway.MaxLength = 250;
            this.txtSMSGateway.Name = "txtSMSGateway";
            this.txtSMSGateway.Size = new System.Drawing.Size(315, 20);
            this.txtSMSGateway.TabIndex = 4;
            // 
            // txtTelephone
            // 
            this.txtTelephone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTelephone.Location = new System.Drawing.Point(93, 106);
            this.txtTelephone.MaxLength = 250;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(315, 20);
            this.txtTelephone.TabIndex = 1;
            // 
            // txtCellPhone
            // 
            this.txtCellPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCellPhone.Location = new System.Drawing.Point(93, 78);
            this.txtCellPhone.MaxLength = 250;
            this.txtCellPhone.Name = "txtCellPhone";
            this.txtCellPhone.Size = new System.Drawing.Size(315, 20);
            this.txtCellPhone.TabIndex = 0;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(93, 134);
            this.txtEmail.MaxLength = 250;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(315, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // EditSchoolForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(491, 458);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditSchoolForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditSchoolForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnUpdate;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboGradingSystem;
        private System.Windows.Forms.ComboBox cboSchoolType;
        private System.Windows.Forms.CheckBox chkIsDefaultSchool;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.TextBox txtSchoolName;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.TextBox txtAddress2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Button btnSearchCustomerId;
        private System.Windows.Forms.LinkLabel btnCreateSCustomer;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtSMTPServer;
        private System.Windows.Forms.TextBox txtSMSGateway;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtCellPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtSlogan;
        private System.Windows.Forms.TextBox txtLogo;
    }
}