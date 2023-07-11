namespace WinSBSchool.Forms
{
    partial class PayFeesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayFeesForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPost = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBoxMpesa = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMpesaPhoneNumber = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtMpesaSenderName = new System.Windows.Forms.TextBox();
            this.btnSMSGateWay = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMpesaReceiptNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMpesaAmountPaid = new System.Windows.Forms.TextBox();
            this.lblAccountDetails = new System.Windows.Forms.Label();
            this.groupBoxBankSlip = new System.Windows.Forms.GroupBox();
            this.lblSlipBankSortCodeDetails = new System.Windows.Forms.Label();
            this.btnSearchslipBank = new System.Windows.Forms.Button();
            this.txtbsBankSortCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBankSlipNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBoxCheque = new System.Windows.Forms.GroupBox();
            this.lblChequeBankSortCodeDetails = new System.Windows.Forms.Label();
            this.btnSearchchequeBank = new System.Windows.Forms.Button();
            this.txtcqBankSortCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboModeofPayment = new System.Windows.Forms.ComboBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBoxMpesa.SuspendLayout();
            this.groupBoxBankSlip.SuspendLayout();
            this.groupBoxCheque.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPost);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 335);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(469, 45);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnPost
            // 
            this.btnPost.AutoSize = true;
            this.btnPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnPost.LinkColor = System.Drawing.Color.Yellow;
            this.btnPost.Location = new System.Drawing.Point(151, 16);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(43, 18);
            this.btnPost.TabIndex = 0;
            this.btnPost.TabStop = true;
            this.btnPost.Text = "Post";
            this.btnPost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPost_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(223, 16);
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBoxMpesa);
            this.groupBox2.Controls.Add(this.lblAccountDetails);
            this.groupBox2.Controls.Add(this.groupBoxBankSlip);
            this.groupBox2.Controls.Add(this.groupBoxCheque);
            this.groupBox2.Controls.Add(this.txtAccountId);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cboModeofPayment);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.cboTransactionType);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(469, 335);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // groupBoxMpesa
            // 
            this.groupBoxMpesa.Controls.Add(this.label1);
            this.groupBoxMpesa.Controls.Add(this.txtMpesaPhoneNumber);
            this.groupBoxMpesa.Controls.Add(this.label30);
            this.groupBoxMpesa.Controls.Add(this.txtMpesaSenderName);
            this.groupBoxMpesa.Controls.Add(this.btnSMSGateWay);
            this.groupBoxMpesa.Controls.Add(this.label8);
            this.groupBoxMpesa.Controls.Add(this.txtMpesaReceiptNo);
            this.groupBoxMpesa.Controls.Add(this.label2);
            this.groupBoxMpesa.Controls.Add(this.txtMpesaAmountPaid);
            this.groupBoxMpesa.Location = new System.Drawing.Point(34, 127);
            this.groupBoxMpesa.Name = "groupBoxMpesa";
            this.groupBoxMpesa.Size = new System.Drawing.Size(311, 146);
            this.groupBoxMpesa.TabIndex = 4;
            this.groupBoxMpesa.TabStop = false;
            this.groupBoxMpesa.Text = "Mpesa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Phone Number";
            // 
            // txtMpesaPhoneNumber
            // 
            this.txtMpesaPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMpesaPhoneNumber.Location = new System.Drawing.Point(87, 96);
            this.txtMpesaPhoneNumber.MaxLength = 250;
            this.txtMpesaPhoneNumber.Name = "txtMpesaPhoneNumber";
            this.txtMpesaPhoneNumber.Size = new System.Drawing.Size(183, 20);
            this.txtMpesaPhoneNumber.TabIndex = 3;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(50, 72);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 13);
            this.label30.TabIndex = 15;
            this.label30.Text = "Name";
            // 
            // txtMpesaSenderName
            // 
            this.txtMpesaSenderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMpesaSenderName.Location = new System.Drawing.Point(87, 69);
            this.txtMpesaSenderName.MaxLength = 250;
            this.txtMpesaSenderName.Name = "txtMpesaSenderName";
            this.txtMpesaSenderName.Size = new System.Drawing.Size(183, 20);
            this.txtMpesaSenderName.TabIndex = 2;
            // 
            // btnSMSGateWay
            // 
            this.btnSMSGateWay.AutoSize = true;
            this.btnSMSGateWay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSMSGateWay.LinkColor = System.Drawing.Color.Yellow;
            this.btnSMSGateWay.Location = new System.Drawing.Point(88, 123);
            this.btnSMSGateWay.Name = "btnSMSGateWay";
            this.btnSMSGateWay.Size = new System.Drawing.Size(97, 15);
            this.btnSMSGateWay.TabIndex = 4;
            this.btnSMSGateWay.TabStop = true;
            this.btnSMSGateWay.Text = "SMS GateWay";
            this.btnSMSGateWay.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSMSGateWay_LinkClicked);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Receipt No";
            // 
            // txtMpesaReceiptNo
            // 
            this.txtMpesaReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMpesaReceiptNo.Location = new System.Drawing.Point(87, 15);
            this.txtMpesaReceiptNo.MaxLength = 250;
            this.txtMpesaReceiptNo.Name = "txtMpesaReceiptNo";
            this.txtMpesaReceiptNo.Size = new System.Drawing.Size(183, 20);
            this.txtMpesaReceiptNo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Amount Paid";
            // 
            // txtMpesaAmountPaid
            // 
            this.txtMpesaAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMpesaAmountPaid.Location = new System.Drawing.Point(87, 42);
            this.txtMpesaAmountPaid.MaxLength = 8;
            this.txtMpesaAmountPaid.Name = "txtMpesaAmountPaid";
            this.txtMpesaAmountPaid.Size = new System.Drawing.Size(183, 20);
            this.txtMpesaAmountPaid.TabIndex = 1;
            this.txtMpesaAmountPaid.TextChanged += new System.EventHandler(this.txtMpesaAmountPaid_TextChanged);
            this.txtMpesaAmountPaid.Validated += new System.EventHandler(this.txtMpesaAmountPaid_Validated);
            // 
            // lblAccountDetails
            // 
            this.lblAccountDetails.AutoSize = true;
            this.lblAccountDetails.Location = new System.Drawing.Point(125, 90);
            this.lblAccountDetails.Name = "lblAccountDetails";
            this.lblAccountDetails.Size = new System.Drawing.Size(47, 13);
            this.lblAccountDetails.TabIndex = 38;
            this.lblAccountDetails.Text = "Account";
            // 
            // groupBoxBankSlip
            // 
            this.groupBoxBankSlip.Controls.Add(this.lblSlipBankSortCodeDetails);
            this.groupBoxBankSlip.Controls.Add(this.btnSearchslipBank);
            this.groupBoxBankSlip.Controls.Add(this.txtbsBankSortCode);
            this.groupBoxBankSlip.Controls.Add(this.label12);
            this.groupBoxBankSlip.Controls.Add(this.txtBankSlipNo);
            this.groupBoxBankSlip.Controls.Add(this.label13);
            this.groupBoxBankSlip.Location = new System.Drawing.Point(307, 105);
            this.groupBoxBankSlip.Name = "groupBoxBankSlip";
            this.groupBoxBankSlip.Size = new System.Drawing.Size(342, 83);
            this.groupBoxBankSlip.TabIndex = 4;
            this.groupBoxBankSlip.TabStop = false;
            this.groupBoxBankSlip.Text = "Bank Slip";
            // 
            // lblSlipBankSortCodeDetails
            // 
            this.lblSlipBankSortCodeDetails.AutoSize = true;
            this.lblSlipBankSortCodeDetails.Location = new System.Drawing.Point(19, 60);
            this.lblSlipBankSortCodeDetails.Name = "lblSlipBankSortCodeDetails";
            this.lblSlipBankSortCodeDetails.Size = new System.Drawing.Size(19, 13);
            this.lblSlipBankSortCodeDetails.TabIndex = 40;
            this.lblSlipBankSortCodeDetails.Text = "::::";
            // 
            // btnSearchslipBank
            // 
            this.btnSearchslipBank.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchslipBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchslipBank.Location = new System.Drawing.Point(210, 33);
            this.btnSearchslipBank.Name = "btnSearchslipBank";
            this.btnSearchslipBank.Size = new System.Drawing.Size(36, 23);
            this.btnSearchslipBank.TabIndex = 2;
            this.btnSearchslipBank.TabStop = false;
            this.btnSearchslipBank.Text = ":::";
            this.btnSearchslipBank.UseVisualStyleBackColor = false;
            this.btnSearchslipBank.Click += new System.EventHandler(this.btnSearchslipBank_Click);
            // 
            // txtbsBankSortCode
            // 
            this.txtbsBankSortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbsBankSortCode.Location = new System.Drawing.Point(94, 34);
            this.txtbsBankSortCode.MaxLength = 5;
            this.txtbsBankSortCode.Name = "txtbsBankSortCode";
            this.txtbsBankSortCode.Size = new System.Drawing.Size(86, 20);
            this.txtbsBankSortCode.TabIndex = 1;
            this.txtbsBankSortCode.TextChanged += new System.EventHandler(this.txtbsBankSortCode_TextChanged);
            this.txtbsBankSortCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbsBankSortCode_KeyDown);
            this.txtbsBankSortCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbsBankSortCode_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(51, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Slip No";
            // 
            // txtBankSlipNo
            // 
            this.txtBankSlipNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBankSlipNo.Location = new System.Drawing.Point(94, 10);
            this.txtBankSlipNo.MaxLength = 250;
            this.txtBankSlipNo.Name = "txtBankSlipNo";
            this.txtBankSlipNo.Size = new System.Drawing.Size(156, 20);
            this.txtBankSlipNo.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Bank Sort Code";
            // 
            // groupBoxCheque
            // 
            this.groupBoxCheque.Controls.Add(this.lblChequeBankSortCodeDetails);
            this.groupBoxCheque.Controls.Add(this.btnSearchchequeBank);
            this.groupBoxCheque.Controls.Add(this.txtcqBankSortCode);
            this.groupBoxCheque.Controls.Add(this.label9);
            this.groupBoxCheque.Controls.Add(this.txtChequeNo);
            this.groupBoxCheque.Controls.Add(this.label11);
            this.groupBoxCheque.Location = new System.Drawing.Point(111, 183);
            this.groupBoxCheque.Name = "groupBoxCheque";
            this.groupBoxCheque.Size = new System.Drawing.Size(280, 90);
            this.groupBoxCheque.TabIndex = 4;
            this.groupBoxCheque.TabStop = false;
            this.groupBoxCheque.Text = "Cheque";
            // 
            // lblChequeBankSortCodeDetails
            // 
            this.lblChequeBankSortCodeDetails.AutoSize = true;
            this.lblChequeBankSortCodeDetails.Location = new System.Drawing.Point(14, 63);
            this.lblChequeBankSortCodeDetails.Name = "lblChequeBankSortCodeDetails";
            this.lblChequeBankSortCodeDetails.Size = new System.Drawing.Size(19, 13);
            this.lblChequeBankSortCodeDetails.TabIndex = 40;
            this.lblChequeBankSortCodeDetails.Text = "::::";
            // 
            // btnSearchchequeBank
            // 
            this.btnSearchchequeBank.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchchequeBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchchequeBank.Location = new System.Drawing.Point(213, 35);
            this.btnSearchchequeBank.Name = "btnSearchchequeBank";
            this.btnSearchchequeBank.Size = new System.Drawing.Size(36, 23);
            this.btnSearchchequeBank.TabIndex = 2;
            this.btnSearchchequeBank.TabStop = false;
            this.btnSearchchequeBank.Text = ":::";
            this.btnSearchchequeBank.UseVisualStyleBackColor = false;
            this.btnSearchchequeBank.Click += new System.EventHandler(this.btnSearchchequeBank_Click);
            // 
            // txtcqBankSortCode
            // 
            this.txtcqBankSortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtcqBankSortCode.Location = new System.Drawing.Point(94, 36);
            this.txtcqBankSortCode.MaxLength = 5;
            this.txtcqBankSortCode.Name = "txtcqBankSortCode";
            this.txtcqBankSortCode.Size = new System.Drawing.Size(90, 20);
            this.txtcqBankSortCode.TabIndex = 1;
            this.txtcqBankSortCode.TextChanged += new System.EventHandler(this.txtcqBankSortCode_TextChanged);
            this.txtcqBankSortCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcqBankSortCode_KeyDown);
            this.txtcqBankSortCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcqBankSortCode_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Cheque  No";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeNo.Location = new System.Drawing.Point(94, 11);
            this.txtChequeNo.MaxLength = 250;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(156, 20);
            this.txtChequeNo.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Bank Sort Code";
            // 
            // txtAccountId
            // 
            this.txtAccountId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountId.Location = new System.Drawing.Point(120, 54);
            this.txtAccountId.MaxLength = 4;
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(175, 20);
            this.txtAccountId.TabIndex = 1;
            this.txtAccountId.TabIndexChanged += new System.EventHandler(this.txtAccountId_TabIndexChanged);
            this.txtAccountId.TextChanged += new System.EventHandler(this.txtAccountId_TextChanged);
            this.txtAccountId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountId_KeyDown);
            this.txtAccountId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountId_KeyPress);
            this.txtAccountId.Leave += new System.EventHandler(this.txtAccountId_Leave);
            this.txtAccountId.Validated += new System.EventHandler(this.txtAccountId_Validated);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.Location = new System.Drawing.Point(345, 51);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(36, 23);
            this.btnSelect.TabIndex = 37;
            this.btnSelect.TabStop = false;
            this.btnSelect.Text = ":::";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transaction Type*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Method of Payment*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 58);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Account*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(71, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Amount*";
            // 
            // cboModeofPayment
            // 
            this.cboModeofPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeofPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModeofPayment.FormattingEnabled = true;
            this.cboModeofPayment.Location = new System.Drawing.Point(120, 149);
            this.cboModeofPayment.Name = "cboModeofPayment";
            this.cboModeofPayment.Size = new System.Drawing.Size(261, 21);
            this.cboModeofPayment.TabIndex = 3;
            this.cboModeofPayment.SelectedIndexChanged += new System.EventHandler(this.cboModeofPayment_SelectedIndexChanged);
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(120, 118);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(261, 20);
            this.txtAmount.TabIndex = 2;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Validated += new System.EventHandler(this.txtAmount_Validated);
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(120, 22);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(261, 21);
            this.cboTransactionType.TabIndex = 0;
            // 
            // PayFeesForm
            // 
            this.AcceptButton = this.btnPost;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(469, 380);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PayFeesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pay Fees";
            this.Load += new System.EventHandler(this.PayFeesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxMpesa.ResumeLayout(false);
            this.groupBoxMpesa.PerformLayout();
            this.groupBoxBankSlip.ResumeLayout(false);
            this.groupBoxBankSlip.PerformLayout();
            this.groupBoxCheque.ResumeLayout(false);
            this.groupBoxCheque.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnPost;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboModeofPayment;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.GroupBox groupBoxCheque;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBoxBankSlip;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBankSlipNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtbsBankSortCode;
        private System.Windows.Forms.TextBox txtcqBankSortCode;
        private System.Windows.Forms.Button btnSearchslipBank;
        private System.Windows.Forms.Button btnSearchchequeBank;
        private System.Windows.Forms.Label lblChequeBankSortCodeDetails;
        private System.Windows.Forms.Label lblSlipBankSortCodeDetails;
        private System.Windows.Forms.Label lblAccountDetails;
        private System.Windows.Forms.GroupBox groupBoxMpesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMpesaPhoneNumber;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtMpesaSenderName;
        private System.Windows.Forms.LinkLabel btnSMSGateWay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMpesaReceiptNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMpesaAmountPaid;
    }
}