namespace WinSBSchool.Forms
{
    partial class EditSubjectForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label indexLabel;
            System.Windows.Forms.Label schoolNameLabel;
            System.Windows.Forms.Label telephoneLabel;
            System.Windows.Forms.Label cellphoneLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label address2Label;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSubjectForm));
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnUpdate = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFees = new System.Windows.Forms.TextBox();
            this.txtNoofRequiredHours = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtShortCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtOutOf = new System.Windows.Forms.TextBox();
            this.txtPassMark = new System.Windows.Forms.TextBox();
            this.txtROrder = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtSubSubjectShortCode = new System.Windows.Forms.TextBox();
            this.txtSubSubjectDescription = new System.Windows.Forms.TextBox();
            this.txtSubSubjectOutOf = new System.Windows.Forms.TextBox();
            this.txtSubSubjectPassMark = new System.Windows.Forms.TextBox();
            this.txtSubSubjectROrder = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSubSubjects = new System.Windows.Forms.DataGridView();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            indexLabel = new System.Windows.Forms.Label();
            schoolNameLabel = new System.Windows.Forms.Label();
            telephoneLabel = new System.Windows.Forms.Label();
            cellphoneLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            address1Label = new System.Windows.Forms.Label();
            address2Label = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubSubjects)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(108, 239);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 13);
            label2.TabIndex = 87;
            label2.Text = "Fees";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(28, 212);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 13);
            label1.TabIndex = 85;
            label1.Text = "No of Required Hours";
            // 
            // indexLabel
            // 
            indexLabel.AutoSize = true;
            indexLabel.Location = new System.Drawing.Point(74, 22);
            indexLabel.Name = "indexLabel";
            indexLabel.Size = new System.Drawing.Size(64, 13);
            indexLabel.TabIndex = 77;
            indexLabel.Text = "Short Code*";
            // 
            // schoolNameLabel
            // 
            schoolNameLabel.AutoSize = true;
            schoolNameLabel.Location = new System.Drawing.Point(74, 49);
            schoolNameLabel.Name = "schoolNameLabel";
            schoolNameLabel.Size = new System.Drawing.Size(64, 13);
            schoolNameLabel.TabIndex = 78;
            schoolNameLabel.Text = "Description*";
            // 
            // telephoneLabel
            // 
            telephoneLabel.AutoSize = true;
            telephoneLabel.Location = new System.Drawing.Point(100, 76);
            telephoneLabel.Name = "telephoneLabel";
            telephoneLabel.Size = new System.Drawing.Size(38, 13);
            telephoneLabel.TabIndex = 79;
            telephoneLabel.Text = "Out Of";
            // 
            // cellphoneLabel
            // 
            cellphoneLabel.AutoSize = true;
            cellphoneLabel.Location = new System.Drawing.Point(81, 103);
            cellphoneLabel.Name = "cellphoneLabel";
            cellphoneLabel.Size = new System.Drawing.Size(57, 13);
            cellphoneLabel.TabIndex = 80;
            cellphoneLabel.Text = "Pass Mark";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(100, 158);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(37, 13);
            emailLabel.TabIndex = 81;
            emailLabel.Text = "Status";
            // 
            // address1Label
            // 
            address1Label.AutoSize = true;
            address1Label.Location = new System.Drawing.Point(94, 130);
            address1Label.Name = "address1Label";
            address1Label.Size = new System.Drawing.Size(44, 13);
            address1Label.TabIndex = 82;
            address1Label.Text = "R Order";
            // 
            // address2Label
            // 
            address2Label.AutoSize = true;
            address2Label.Location = new System.Drawing.Point(89, 185);
            address2Label.Name = "address2Label";
            address2Label.Size = new System.Drawing.Size(49, 13);
            address2Label.TabIndex = 83;
            address2Label.Text = "Remarks";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(11, 35);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 13);
            label3.TabIndex = 88;
            label3.Text = "Short Code*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(11, 62);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(64, 13);
            label4.TabIndex = 89;
            label4.Text = "Description*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(37, 89);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(38, 13);
            label5.TabIndex = 90;
            label5.Text = "Out Of";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(18, 117);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(57, 13);
            label6.TabIndex = 91;
            label6.Text = "Pass Mark";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(31, 143);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(44, 13);
            label7.TabIndex = 92;
            label7.Text = "R Order";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(293, 10);
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
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.LinkColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(172, 10);
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
            this.groupBox1.Location = new System.Drawing.Point(0, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(508, 36);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tabControl1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(508, 315);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(502, 296);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(494, 270);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Subject";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFees);
            this.groupBox3.Controls.Add(label2);
            this.groupBox3.Controls.Add(this.txtNoofRequiredHours);
            this.groupBox3.Controls.Add(label1);
            this.groupBox3.Controls.Add(this.cboStatus);
            this.groupBox3.Controls.Add(indexLabel);
            this.groupBox3.Controls.Add(this.txtShortCode);
            this.groupBox3.Controls.Add(this.txtDescription);
            this.groupBox3.Controls.Add(this.txtOutOf);
            this.groupBox3.Controls.Add(this.txtPassMark);
            this.groupBox3.Controls.Add(this.txtROrder);
            this.groupBox3.Controls.Add(this.txtRemarks);
            this.groupBox3.Controls.Add(schoolNameLabel);
            this.groupBox3.Controls.Add(telephoneLabel);
            this.groupBox3.Controls.Add(cellphoneLabel);
            this.groupBox3.Controls.Add(emailLabel);
            this.groupBox3.Controls.Add(address1Label);
            this.groupBox3.Controls.Add(address2Label);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(488, 264);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // txtFees
            // 
            this.txtFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFees.Location = new System.Drawing.Point(140, 236);
            this.txtFees.MaxLength = 8;
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(290, 20);
            this.txtFees.TabIndex = 8;
            // 
            // txtNoofRequiredHours
            // 
            this.txtNoofRequiredHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoofRequiredHours.Location = new System.Drawing.Point(140, 209);
            this.txtNoofRequiredHours.MaxLength = 4;
            this.txtNoofRequiredHours.Name = "txtNoofRequiredHours";
            this.txtNoofRequiredHours.Size = new System.Drawing.Size(290, 20);
            this.txtNoofRequiredHours.TabIndex = 7;
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(140, 154);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(290, 21);
            this.cboStatus.TabIndex = 5;
            // 
            // txtShortCode
            // 
            this.txtShortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortCode.Enabled = false;
            this.txtShortCode.Location = new System.Drawing.Point(140, 19);
            this.txtShortCode.MaxLength = 10;
            this.txtShortCode.Name = "txtShortCode";
            this.txtShortCode.Size = new System.Drawing.Size(290, 20);
            this.txtShortCode.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(140, 46);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(290, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // txtOutOf
            // 
            this.txtOutOf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutOf.Location = new System.Drawing.Point(140, 73);
            this.txtOutOf.MaxLength = 4;
            this.txtOutOf.Name = "txtOutOf";
            this.txtOutOf.Size = new System.Drawing.Size(290, 20);
            this.txtOutOf.TabIndex = 2;
            // 
            // txtPassMark
            // 
            this.txtPassMark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassMark.Location = new System.Drawing.Point(140, 100);
            this.txtPassMark.MaxLength = 4;
            this.txtPassMark.Name = "txtPassMark";
            this.txtPassMark.Size = new System.Drawing.Size(290, 20);
            this.txtPassMark.TabIndex = 3;
            // 
            // txtROrder
            // 
            this.txtROrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtROrder.Location = new System.Drawing.Point(140, 127);
            this.txtROrder.MaxLength = 4;
            this.txtROrder.Name = "txtROrder";
            this.txtROrder.Size = new System.Drawing.Size(290, 20);
            this.txtROrder.TabIndex = 4;
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(140, 182);
            this.txtRemarks.MaxLength = 250;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(290, 20);
            this.txtRemarks.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(494, 270);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sub-Subjects";
            // 
            // txtSubSubjectShortCode
            // 
            this.txtSubSubjectShortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubSubjectShortCode.Enabled = false;
            this.txtSubSubjectShortCode.Location = new System.Drawing.Point(77, 32);
            this.txtSubSubjectShortCode.MaxLength = 10;
            this.txtSubSubjectShortCode.Name = "txtSubSubjectShortCode";
            this.txtSubSubjectShortCode.Size = new System.Drawing.Size(175, 20);
            this.txtSubSubjectShortCode.TabIndex = 0;
            // 
            // txtSubSubjectDescription
            // 
            this.txtSubSubjectDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubSubjectDescription.Location = new System.Drawing.Point(77, 59);
            this.txtSubSubjectDescription.MaxLength = 50;
            this.txtSubSubjectDescription.Name = "txtSubSubjectDescription";
            this.txtSubSubjectDescription.Size = new System.Drawing.Size(175, 20);
            this.txtSubSubjectDescription.TabIndex = 1;
            // 
            // txtSubSubjectOutOf
            // 
            this.txtSubSubjectOutOf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubSubjectOutOf.Location = new System.Drawing.Point(77, 86);
            this.txtSubSubjectOutOf.MaxLength = 4;
            this.txtSubSubjectOutOf.Name = "txtSubSubjectOutOf";
            this.txtSubSubjectOutOf.Size = new System.Drawing.Size(175, 20);
            this.txtSubSubjectOutOf.TabIndex = 2;
            // 
            // txtSubSubjectPassMark
            // 
            this.txtSubSubjectPassMark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubSubjectPassMark.Location = new System.Drawing.Point(77, 113);
            this.txtSubSubjectPassMark.MaxLength = 4;
            this.txtSubSubjectPassMark.Name = "txtSubSubjectPassMark";
            this.txtSubSubjectPassMark.Size = new System.Drawing.Size(175, 20);
            this.txtSubSubjectPassMark.TabIndex = 3;
            // 
            // txtSubSubjectROrder
            // 
            this.txtSubSubjectROrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubSubjectROrder.Location = new System.Drawing.Point(77, 140);
            this.txtSubSubjectROrder.MaxLength = 4;
            this.txtSubSubjectROrder.Name = "txtSubSubjectROrder";
            this.txtSubSubjectROrder.Size = new System.Drawing.Size(175, 20);
            this.txtSubSubjectROrder.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.txtSubSubjectROrder);
            this.groupBox4.Controls.Add(label3);
            this.groupBox4.Controls.Add(label7);
            this.groupBox4.Controls.Add(this.txtSubSubjectShortCode);
            this.groupBox4.Controls.Add(label6);
            this.groupBox4.Controls.Add(this.txtSubSubjectDescription);
            this.groupBox4.Controls.Add(label5);
            this.groupBox4.Controls.Add(this.txtSubSubjectOutOf);
            this.groupBox4.Controls.Add(label4);
            this.groupBox4.Controls.Add(this.txtSubSubjectPassMark);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(200, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(291, 264);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridViewSubSubjects);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(197, 264);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // dataGridViewSubSubjects
            // 
            this.dataGridViewSubSubjects.AllowUserToAddRows = false;
            this.dataGridViewSubSubjects.AllowUserToDeleteRows = false;
            this.dataGridViewSubSubjects.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSubSubjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSubSubjects.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewSubSubjects.MultiSelect = false;
            this.dataGridViewSubSubjects.Name = "dataGridViewSubSubjects";
            this.dataGridViewSubSubjects.ReadOnly = true;
            this.dataGridViewSubSubjects.Size = new System.Drawing.Size(191, 245);
            this.dataGridViewSubSubjects.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(164, 183);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 18);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(102, 183);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // EditSubjectForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(508, 351);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditSubjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditSubjectForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSubSubjects)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.TextBox txtNoofRequiredHours;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtShortCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtOutOf;
        private System.Windows.Forms.TextBox txtPassMark;
        private System.Windows.Forms.TextBox txtROrder;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtSubSubjectShortCode;
        private System.Windows.Forms.TextBox txtSubSubjectDescription;
        private System.Windows.Forms.TextBox txtSubSubjectOutOf;
        private System.Windows.Forms.TextBox txtSubSubjectPassMark;
        private System.Windows.Forms.TextBox txtSubSubjectROrder;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridViewSubSubjects;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.LinkLabel btnAdd;
    }
}