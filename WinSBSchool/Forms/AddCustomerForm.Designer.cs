namespace WinSBSchool.Forms
{
    partial class AddCustomerForm
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
            System.Windows.Forms.Label address1Label;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddCustomerForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblbankdetails = new System.Windows.Forms.Label();
            this.btnSearchBankSortCode = new System.Windows.Forms.Button();
            this.txtBankSortCode = new System.Windows.Forms.TextBox();
            this.txtCustomerNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceBank = new System.Windows.Forms.BindingSource(this.components);
            address1Label = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBank)).BeginInit();
            this.SuspendLayout();
            // 
            // address1Label
            // 
            address1Label.AutoSize = true;
            address1Label.Location = new System.Drawing.Point(25, 206);
            address1Label.Name = "address1Label";
            address1Label.Size = new System.Drawing.Size(69, 13);
            address1Label.TabIndex = 143;
            address1Label.Text = "Bank Branch";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(458, 38);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(261, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(169, 11);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblbankdetails);
            this.groupBox2.Controls.Add(this.btnSearchBankSortCode);
            this.groupBox2.Controls.Add(this.txtBankSortCode);
            this.groupBox2.Controls.Add(address1Label);
            this.groupBox2.Controls.Add(this.txtCustomerNo);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.txtPhone);
            this.groupBox2.Controls.Add(this.txtAddress);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 258);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lblbankdetails
            // 
            this.lblbankdetails.AutoSize = true;
            this.lblbankdetails.Location = new System.Drawing.Point(93, 233);
            this.lblbankdetails.Name = "lblbankdetails";
            this.lblbankdetails.Size = new System.Drawing.Size(67, 13);
            this.lblbankdetails.TabIndex = 146;
            this.lblbankdetails.Text = "Bank Details";
            // 
            // btnSearchBankSortCode
            // 
            this.btnSearchBankSortCode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchBankSortCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchBankSortCode.Location = new System.Drawing.Point(316, 197);
            this.btnSearchBankSortCode.Name = "btnSearchBankSortCode";
            this.btnSearchBankSortCode.Size = new System.Drawing.Size(58, 23);
            this.btnSearchBankSortCode.TabIndex = 5;
            this.btnSearchBankSortCode.TabStop = false;
            this.btnSearchBankSortCode.Text = ":::";
            this.btnSearchBankSortCode.UseVisualStyleBackColor = false;
            this.btnSearchBankSortCode.Click += new System.EventHandler(this.btnSearchBankSortCode_Click);
            // 
            // txtBankSortCode
            // 
            this.txtBankSortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankSortCode.Location = new System.Drawing.Point(96, 202);
            this.txtBankSortCode.MaxLength = 5;
            this.txtBankSortCode.Name = "txtBankSortCode";
            this.txtBankSortCode.Size = new System.Drawing.Size(185, 20);
            this.txtBankSortCode.TabIndex = 5;
            this.txtBankSortCode.TextChanged += new System.EventHandler(this.txtBankSortCode_TextChanged);
            this.txtBankSortCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBankSortCode_KeyDown);
            this.txtBankSortCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBankSortCode_KeyPress);
            // 
            // txtCustomerNo
            // 
            this.txtCustomerNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerNo.Location = new System.Drawing.Point(96, 50);
            this.txtCustomerNo.Name = "txtCustomerNo";
            this.txtCustomerNo.Size = new System.Drawing.Size(278, 20);
            this.txtCustomerNo.TabIndex = 1;
            this.txtCustomerNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerNo_KeyDown);
            this.txtCustomerNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerNo_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Number*";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(96, 164);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(278, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(96, 126);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(278, 20);
            this.txtPhone.TabIndex = 3;
            // 
            // txtAddress
            // 
            this.txtAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAddress.Location = new System.Drawing.Point(96, 88);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(278, 20);
            this.txtAddress.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(96, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(278, 20);
            this.txtName.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Email";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Phone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Address";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddCustomerForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(458, 296);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddCustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Customer";
            this.Load += new System.EventHandler(this.AddNewCustomerForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceBank)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.BindingSource bindingSourceBank;
        private System.Windows.Forms.TextBox txtCustomerNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSearchBankSortCode;
        private System.Windows.Forms.TextBox txtBankSortCode;
        private System.Windows.Forms.Label lblbankdetails;
    }
}