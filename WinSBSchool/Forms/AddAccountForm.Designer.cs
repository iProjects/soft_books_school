﻿namespace WinSBSchool.Forms
{
    partial class AddAccountForm
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
            System.Windows.Forms.Label telephoneLabel;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label indexLabel;
            System.Windows.Forms.Label schoolNameLabel;
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAccountForm));
            this.btnclose = new System.Windows.Forms.LinkLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.bindingSourceBank = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceCustomerId = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceAccountTypes = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceAccSchool = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbopassflags = new System.Windows.Forms.ComboBox();
            this.lblbankdetails = new System.Windows.Forms.Label();
            this.lblcustomerdetails = new System.Windows.Forms.Label();
            this.btnSearchBankSortCode = new System.Windows.Forms.Button();
            this.txtBankSortCode = new System.Windows.Forms.TextBox();
            this.cboCOA = new System.Windows.Forms.ComboBox();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.cboAccountTypes = new System.Windows.Forms.ComboBox();
            this.btnSearchCustomerId = new System.Windows.Forms.Button();
            this.cboSchoolBranch = new System.Windows.Forms.ComboBox();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            telephoneLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            indexLabel = new System.Windows.Forms.Label();
            schoolNameLabel = new System.Windows.Forms.Label();
            address1Label = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomerId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccountTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccSchool)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // telephoneLabel
            // 
            telephoneLabel.AutoSize = true;
            telephoneLabel.Location = new System.Drawing.Point(33, 60);
            telephoneLabel.Name = "telephoneLabel";
            telephoneLabel.Size = new System.Drawing.Size(78, 13);
            telephoneLabel.TabIndex = 132;
            telephoneLabel.Text = "Account Type*";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(34, 264);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(77, 13);
            label5.TabIndex = 131;
            label5.Text = "School Branch";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(43, 180);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(68, 13);
            label4.TabIndex = 130;
            label4.Text = "Account No*";
            // 
            // indexLabel
            // 
            indexLabel.AutoSize = true;
            indexLabel.Location = new System.Drawing.Point(56, 94);
            indexLabel.Name = "indexLabel";
            indexLabel.Size = new System.Drawing.Size(56, 13);
            indexLabel.TabIndex = 127;
            indexLabel.Text = "Owner ID*";
            // 
            // schoolNameLabel
            // 
            schoolNameLabel.AutoSize = true;
            schoolNameLabel.Location = new System.Drawing.Point(29, 149);
            schoolNameLabel.Name = "schoolNameLabel";
            schoolNameLabel.Size = new System.Drawing.Size(82, 13);
            schoolNameLabel.TabIndex = 128;
            schoolNameLabel.Text = "Account Name*";
            // 
            // address1Label
            // 
            address1Label.AutoSize = true;
            address1Label.Location = new System.Drawing.Point(42, 213);
            address1Label.Name = "address1Label";
            address1Label.Size = new System.Drawing.Size(69, 13);
            address1Label.TabIndex = 129;
            address1Label.Text = "Bank Branch";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(17, 18);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(93, 13);
            label1.TabIndex = 136;
            label1.Text = "Chart Of Account*";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(58, 303);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(53, 13);
            label2.TabIndex = 146;
            label2.Text = "Pass Flag";
            // 
            // btnclose
            // 
            this.btnclose.AutoSize = true;
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnclose.LinkColor = System.Drawing.Color.Yellow;
            this.btnclose.Location = new System.Drawing.Point(256, 10);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(52, 18);
            this.btnclose.TabIndex = 1;
            this.btnclose.TabStop = true;
            this.btnclose.Text = "Close";
            this.btnclose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(165, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnclose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 340);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(488, 40);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbopassflags);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Controls.Add(this.lblbankdetails);
            this.groupBox2.Controls.Add(this.lblcustomerdetails);
            this.groupBox2.Controls.Add(this.btnSearchBankSortCode);
            this.groupBox2.Controls.Add(this.txtBankSortCode);
            this.groupBox2.Controls.Add(this.cboCOA);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(this.txtCustomerID);
            this.groupBox2.Controls.Add(this.cboAccountTypes);
            this.groupBox2.Controls.Add(telephoneLabel);
            this.groupBox2.Controls.Add(this.btnSearchCustomerId);
            this.groupBox2.Controls.Add(this.cboSchoolBranch);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(this.txtAccountNo);
            this.groupBox2.Controls.Add(label4);
            this.groupBox2.Controls.Add(indexLabel);
            this.groupBox2.Controls.Add(this.txtAccountName);
            this.groupBox2.Controls.Add(schoolNameLabel);
            this.groupBox2.Controls.Add(address1Label);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 340);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cbopassflags
            // 
            this.cbopassflags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopassflags.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbopassflags.FormattingEnabled = true;
            this.cbopassflags.Location = new System.Drawing.Point(117, 299);
            this.cbopassflags.Name = "cbopassflags";
            this.cbopassflags.Size = new System.Drawing.Size(315, 21);
            this.cbopassflags.TabIndex = 7;
            // 
            // lblbankdetails
            // 
            this.lblbankdetails.AutoSize = true;
            this.lblbankdetails.Location = new System.Drawing.Point(114, 236);
            this.lblbankdetails.Name = "lblbankdetails";
            this.lblbankdetails.Size = new System.Drawing.Size(67, 13);
            this.lblbankdetails.TabIndex = 144;
            this.lblbankdetails.Text = "Bank Details";
            // 
            // lblcustomerdetails
            // 
            this.lblcustomerdetails.AutoSize = true;
            this.lblcustomerdetails.Location = new System.Drawing.Point(115, 116);
            this.lblcustomerdetails.Name = "lblcustomerdetails";
            this.lblcustomerdetails.Size = new System.Drawing.Size(86, 13);
            this.lblcustomerdetails.TabIndex = 143;
            this.lblcustomerdetails.Text = "Customer Details";
            // 
            // btnSearchBankSortCode
            // 
            this.btnSearchBankSortCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchBankSortCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBankSortCode.Location = new System.Drawing.Point(374, 205);
            this.btnSearchBankSortCode.Name = "btnSearchBankSortCode";
            this.btnSearchBankSortCode.Size = new System.Drawing.Size(58, 23);
            this.btnSearchBankSortCode.TabIndex = 142;
            this.btnSearchBankSortCode.TabStop = false;
            this.btnSearchBankSortCode.Text = ":::";
            this.btnSearchBankSortCode.UseVisualStyleBackColor = false;
            this.btnSearchBankSortCode.Click += new System.EventHandler(this.btnSearchBankSortCode_Click);
            // 
            // txtBankSortCode
            // 
            this.txtBankSortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankSortCode.Location = new System.Drawing.Point(117, 208);
            this.txtBankSortCode.MaxLength = 5;
            this.txtBankSortCode.Name = "txtBankSortCode";
            this.txtBankSortCode.Size = new System.Drawing.Size(220, 20);
            this.txtBankSortCode.TabIndex = 5;
            this.txtBankSortCode.TextChanged += new System.EventHandler(this.txtBankSortCode_TextChanged);
            this.txtBankSortCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBankSortCode_KeyDown);
            this.txtBankSortCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBankSortCode_KeyPress);
            // 
            // cboCOA
            // 
            this.cboCOA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCOA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCOA.FormattingEnabled = true;
            this.cboCOA.IntegralHeight = false;
            this.cboCOA.Location = new System.Drawing.Point(117, 15);
            this.cboCOA.Name = "cboCOA";
            this.cboCOA.Size = new System.Drawing.Size(315, 21);
            this.cboCOA.TabIndex = 0;
            this.cboCOA.SelectedIndexChanged += new System.EventHandler(this.cboCOA_SelectedIndexChanged);
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerID.Location = new System.Drawing.Point(118, 86);
            this.txtCustomerID.MaxLength = 50;
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(220, 20);
            this.txtCustomerID.TabIndex = 2;
            this.txtCustomerID.TextChanged += new System.EventHandler(this.txtCustomerID_TextChanged);
            this.txtCustomerID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerID_KeyDown);
            this.txtCustomerID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerID_KeyPress);
            // 
            // cboAccountTypes
            // 
            this.cboAccountTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAccountTypes.FormattingEnabled = true;
            this.cboAccountTypes.Location = new System.Drawing.Point(117, 52);
            this.cboAccountTypes.Name = "cboAccountTypes";
            this.cboAccountTypes.Size = new System.Drawing.Size(315, 21);
            this.cboAccountTypes.TabIndex = 1;
            // 
            // btnSearchCustomerId
            // 
            this.btnSearchCustomerId.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchCustomerId.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCustomerId.Location = new System.Drawing.Point(375, 86);
            this.btnSearchCustomerId.Name = "btnSearchCustomerId";
            this.btnSearchCustomerId.Size = new System.Drawing.Size(58, 23);
            this.btnSearchCustomerId.TabIndex = 6;
            this.btnSearchCustomerId.TabStop = false;
            this.btnSearchCustomerId.Text = ":::";
            this.btnSearchCustomerId.UseVisualStyleBackColor = false;
            this.btnSearchCustomerId.Click += new System.EventHandler(this.btnSearchCustomerId_Click);
            // 
            // cboSchoolBranch
            // 
            this.cboSchoolBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSchoolBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSchoolBranch.FormattingEnabled = true;
            this.cboSchoolBranch.Location = new System.Drawing.Point(117, 259);
            this.cboSchoolBranch.Name = "cboSchoolBranch";
            this.cboSchoolBranch.Size = new System.Drawing.Size(315, 21);
            this.cboSchoolBranch.TabIndex = 6;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNo.Location = new System.Drawing.Point(117, 172);
            this.txtAccountNo.MaxLength = 50;
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(315, 20);
            this.txtAccountNo.TabIndex = 4;
            // 
            // txtAccountName
            // 
            this.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountName.Location = new System.Drawing.Point(117, 141);
            this.txtAccountName.MaxLength = 100;
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(315, 20);
            this.txtAccountName.TabIndex = 3;
            // 
            // AddAccountForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnclose;
            this.ClientSize = new System.Drawing.Size(488, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open  Account ";
            this.Load += new System.EventHandler(this.AddAccountForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceCustomerId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccountTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccSchool)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnclose;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.BindingSource bindingSourceBank;
        private System.Windows.Forms.BindingSource bindingSourceCustomerId;
        private System.Windows.Forms.BindingSource bindingSourceAccountTypes;
        private System.Windows.Forms.BindingSource bindingSourceAccSchool;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboAccountTypes;
        private System.Windows.Forms.Button btnSearchCustomerId;
        private System.Windows.Forms.ComboBox cboSchoolBranch;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.ComboBox cboCOA;
        private System.Windows.Forms.TextBox txtBankSortCode;
        private System.Windows.Forms.Button btnSearchBankSortCode;
        private System.Windows.Forms.Label lblbankdetails;
        private System.Windows.Forms.Label lblcustomerdetails;
        private System.Windows.Forms.ComboBox cbopassflags;
    }
}