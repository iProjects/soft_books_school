namespace WinSBSchool.Forms
{
    partial class AddFeeStructureOthersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddFeeStructureOthersForm));
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblAccountDetails = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.btnSearchAccount = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cboApplicableTo = new System.Windows.Forms.ComboBox();
            this.cboAmountPeriod = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboFeeStructure = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(290, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(505, 35);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(188, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblAccountDetails);
            this.groupBox2.Controls.Add(this.txtAccountId);
            this.groupBox2.Controls.Add(this.btnSearchAccount);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboApplicableTo);
            this.groupBox2.Controls.Add(this.cboAmountPeriod);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboFeeStructure);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(505, 249);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // lblAccountDetails
            // 
            this.lblAccountDetails.AutoSize = true;
            this.lblAccountDetails.Location = new System.Drawing.Point(103, 88);
            this.lblAccountDetails.Name = "lblAccountDetails";
            this.lblAccountDetails.Size = new System.Drawing.Size(19, 13);
            this.lblAccountDetails.TabIndex = 30;
            this.lblAccountDetails.Text = "::::";
            // 
            // txtAccountId
            // 
            this.txtAccountId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountId.Location = new System.Drawing.Point(103, 58);
            this.txtAccountId.MaxLength = 4;
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(273, 20);
            this.txtAccountId.TabIndex = 1;
            this.txtAccountId.TabIndexChanged += new System.EventHandler(this.txtAccountId_TabIndexChanged);
            this.txtAccountId.TextChanged += new System.EventHandler(this.txtAccountId_TextChanged);
            this.txtAccountId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountID_KeyDown);
            this.txtAccountId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountID_KeyPress);
            this.txtAccountId.Leave += new System.EventHandler(this.txtAccountId_Leave);
            this.txtAccountId.Validated += new System.EventHandler(this.txtAccountId_Validated);
            // 
            // btnSearchAccount
            // 
            this.btnSearchAccount.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAccount.Location = new System.Drawing.Point(410, 57);
            this.btnSearchAccount.Name = "btnSearchAccount";
            this.btnSearchAccount.Size = new System.Drawing.Size(36, 23);
            this.btnSearchAccount.TabIndex = 6;
            this.btnSearchAccount.Text = ":::";
            this.btnSearchAccount.UseVisualStyleBackColor = false;
            this.btnSearchAccount.Click += new System.EventHandler(this.btnSearchAccount_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Account Id*";
            // 
            // cboApplicableTo
            // 
            this.cboApplicableTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboApplicableTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboApplicableTo.FormattingEnabled = true;
            this.cboApplicableTo.Location = new System.Drawing.Point(103, 202);
            this.cboApplicableTo.Name = "cboApplicableTo";
            this.cboApplicableTo.Size = new System.Drawing.Size(344, 21);
            this.cboApplicableTo.TabIndex = 5;
            // 
            // cboAmountPeriod
            // 
            this.cboAmountPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAmountPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAmountPeriod.FormattingEnabled = true;
            this.cboAmountPeriod.Location = new System.Drawing.Point(103, 171);
            this.cboAmountPeriod.Name = "cboAmountPeriod";
            this.cboAmountPeriod.Size = new System.Drawing.Size(344, 21);
            this.cboAmountPeriod.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Applicable To*";
            // 
            // cboFeeStructure
            // 
            this.cboFeeStructure.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeeStructure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboFeeStructure.FormattingEnabled = true;
            this.cboFeeStructure.Location = new System.Drawing.Point(103, 27);
            this.cboFeeStructure.Name = "cboFeeStructure";
            this.cboFeeStructure.Size = new System.Drawing.Size(344, 21);
            this.cboFeeStructure.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(103, 111);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(344, 20);
            this.txtDescription.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Amount Period*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fee Structure*";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(103, 141);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(344, 20);
            this.txtAmount.TabIndex = 3;
            this.txtAmount.Text = "0";
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount*";
            // 
            // AddFeeStructureOthersForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(505, 284);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddFeeStructureOthersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add FeeStructure Others";
            this.Load += new System.EventHandler(this.AddFeeStructureOthersForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboFeeStructure;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboAmountPeriod;
        private System.Windows.Forms.ComboBox cboApplicableTo;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Button btnSearchAccount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAccountDetails;
    }
}