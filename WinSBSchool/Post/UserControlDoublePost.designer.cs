namespace WinSBSchool.Forms
{
    partial class UserControlDoublePost
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblCrNarrative = new System.Windows.Forms.Label();
            this.lblDrNarrative = new System.Windows.Forms.Label();
            this.txtDebitNarrative = new System.Windows.Forms.TextBox();
            this.txtCrNarrative = new System.Windows.Forms.TextBox();
            this.groupBoxCreditAccount = new System.Windows.Forms.GroupBox();
            this.lblCrAccountDetails = new System.Windows.Forms.Label();
            this.txtCrAccount = new System.Windows.Forms.TextBox();
            this.btnSelectCrAccount = new System.Windows.Forms.Button();
            this.groupBoxDrAccount = new System.Windows.Forms.GroupBox();
            this.lblDrAccountDetails = new System.Windows.Forms.Label();
            this.txtDrAccount = new System.Windows.Forms.TextBox();
            this.btnSelectDrAccount = new System.Windows.Forms.Button();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.dtpValueDate = new System.Windows.Forms.DateTimePicker();
            this.lblDebitAccount = new System.Windows.Forms.Label();
            this.lblModeofPayment = new System.Windows.Forms.Label();
            this.lblCreditAccount = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.lblValueDate = new System.Windows.Forms.Label();
            this.btnPost = new System.Windows.Forms.Button();
            this.cboModeofPayment = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelDPost = new System.Windows.Forms.TableLayoutPanel();
            this.groupBoxMpesa = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMpesaPhoneNumber = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtMpesaSenderName = new System.Windows.Forms.TextBox();
            this.btnSMSGateWay = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMpesaReceiptNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMpesaAmountPaid = new System.Windows.Forms.TextBox();
            this.groupBoxCheque = new System.Windows.Forms.GroupBox();
            this.lblChequeBankSortCodeDetails = new System.Windows.Forms.Label();
            this.btnSearchchequeBank = new System.Windows.Forms.Button();
            this.txtcqBankSortCode = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtChequeNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBoxBankSlip = new System.Windows.Forms.GroupBox();
            this.lblSlipBankSortCodeDetails = new System.Windows.Forms.Label();
            this.btnSearchslipBank = new System.Windows.Forms.Button();
            this.txtbsBankSortCode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtBankSlipNo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBoxModeofPayment = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBoxValueDate = new System.Windows.Forms.GroupBox();
            this.groupBoxDrNarrative = new System.Windows.Forms.GroupBox();
            this.groupBoxCrNarrative = new System.Windows.Forms.GroupBox();
            this.groupBoxAmount = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBoxCreditAccount.SuspendLayout();
            this.groupBoxDrAccount.SuspendLayout();
            this.tableLayoutPanelDPost.SuspendLayout();
            this.groupBoxMpesa.SuspendLayout();
            this.groupBoxCheque.SuspendLayout();
            this.groupBoxBankSlip.SuspendLayout();
            this.groupBoxModeofPayment.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBoxValueDate.SuspendLayout();
            this.groupBoxDrNarrative.SuspendLayout();
            this.groupBoxCrNarrative.SuspendLayout();
            this.groupBoxAmount.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // lblCrNarrative
            // 
            this.lblCrNarrative.AutoSize = true;
            this.lblCrNarrative.Location = new System.Drawing.Point(3, 308);
            this.lblCrNarrative.Name = "lblCrNarrative";
            this.lblCrNarrative.Size = new System.Drawing.Size(80, 13);
            this.lblCrNarrative.TabIndex = 60;
            this.lblCrNarrative.Text = "Credit Narrative";
            // 
            // lblDrNarrative
            // 
            this.lblDrNarrative.AutoSize = true;
            this.lblDrNarrative.Location = new System.Drawing.Point(3, 253);
            this.lblDrNarrative.Name = "lblDrNarrative";
            this.lblDrNarrative.Size = new System.Drawing.Size(78, 13);
            this.lblDrNarrative.TabIndex = 59;
            this.lblDrNarrative.Text = "Debit Narrative";
            // 
            // txtDebitNarrative
            // 
            this.txtDebitNarrative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDebitNarrative.Location = new System.Drawing.Point(6, 9);
            this.txtDebitNarrative.MaxLength = 250;
            this.txtDebitNarrative.Name = "txtDebitNarrative";
            this.txtDebitNarrative.Size = new System.Drawing.Size(272, 20);
            this.txtDebitNarrative.TabIndex = 0;
            // 
            // txtCrNarrative
            // 
            this.txtCrNarrative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrNarrative.Location = new System.Drawing.Point(6, 9);
            this.txtCrNarrative.MaxLength = 250;
            this.txtCrNarrative.Name = "txtCrNarrative";
            this.txtCrNarrative.Size = new System.Drawing.Size(272, 20);
            this.txtCrNarrative.TabIndex = 0;
            // 
            // groupBoxCreditAccount
            // 
            this.groupBoxCreditAccount.Controls.Add(this.lblCrAccountDetails);
            this.groupBoxCreditAccount.Controls.Add(this.txtCrAccount);
            this.groupBoxCreditAccount.Controls.Add(this.btnSelectCrAccount);
            this.groupBoxCreditAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCreditAccount.Location = new System.Drawing.Point(130, 366);
            this.groupBoxCreditAccount.Name = "groupBoxCreditAccount";
            this.groupBoxCreditAccount.Size = new System.Drawing.Size(598, 66);
            this.groupBoxCreditAccount.TabIndex = 5;
            this.groupBoxCreditAccount.TabStop = false;
            // 
            // lblCrAccountDetails
            // 
            this.lblCrAccountDetails.AutoSize = true;
            this.lblCrAccountDetails.Location = new System.Drawing.Point(5, 31);
            this.lblCrAccountDetails.Name = "lblCrAccountDetails";
            this.lblCrAccountDetails.Size = new System.Drawing.Size(19, 13);
            this.lblCrAccountDetails.TabIndex = 32;
            this.lblCrAccountDetails.Text = "::::";
            // 
            // txtCrAccount
            // 
            this.txtCrAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrAccount.Location = new System.Drawing.Point(6, 10);
            this.txtCrAccount.MaxLength = 4;
            this.txtCrAccount.Name = "txtCrAccount";
            this.txtCrAccount.Size = new System.Drawing.Size(142, 20);
            this.txtCrAccount.TabIndex = 0;
            this.txtCrAccount.TabIndexChanged += new System.EventHandler(this.txtCrAccount_TabIndexChanged);
            this.txtCrAccount.TextChanged += new System.EventHandler(this.txtCrAccount_TextChanged);
            this.txtCrAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCrAccount_KeyDown);
            this.txtCrAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrAccount_KeyPress);
            this.txtCrAccount.Leave += new System.EventHandler(this.txtCrAccount_Leave);
            this.txtCrAccount.Validated += new System.EventHandler(this.txtCrAccount_Validated);
            // 
            // btnSelectCrAccount
            // 
            this.btnSelectCrAccount.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSelectCrAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectCrAccount.Location = new System.Drawing.Point(214, 8);
            this.btnSelectCrAccount.Name = "btnSelectCrAccount";
            this.btnSelectCrAccount.Size = new System.Drawing.Size(36, 23);
            this.btnSelectCrAccount.TabIndex = 1;
            this.btnSelectCrAccount.Text = ":::";
            this.btnSelectCrAccount.UseVisualStyleBackColor = false;
            this.btnSelectCrAccount.Click += new System.EventHandler(this.btnSelectCrAccount_Click);
            // 
            // groupBoxDrAccount
            // 
            this.groupBoxDrAccount.Controls.Add(this.lblDrAccountDetails);
            this.groupBoxDrAccount.Controls.Add(this.txtDrAccount);
            this.groupBoxDrAccount.Controls.Add(this.btnSelectDrAccount);
            this.groupBoxDrAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDrAccount.Location = new System.Drawing.Point(130, 10);
            this.groupBoxDrAccount.Name = "groupBoxDrAccount";
            this.groupBoxDrAccount.Size = new System.Drawing.Size(598, 66);
            this.groupBoxDrAccount.TabIndex = 0;
            this.groupBoxDrAccount.TabStop = false;
            // 
            // lblDrAccountDetails
            // 
            this.lblDrAccountDetails.AutoSize = true;
            this.lblDrAccountDetails.Location = new System.Drawing.Point(3, 33);
            this.lblDrAccountDetails.Name = "lblDrAccountDetails";
            this.lblDrAccountDetails.Size = new System.Drawing.Size(19, 13);
            this.lblDrAccountDetails.TabIndex = 32;
            this.lblDrAccountDetails.Text = "::::";
            // 
            // txtDrAccount
            // 
            this.txtDrAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrAccount.Location = new System.Drawing.Point(6, 10);
            this.txtDrAccount.MaxLength = 4;
            this.txtDrAccount.Name = "txtDrAccount";
            this.txtDrAccount.Size = new System.Drawing.Size(142, 20);
            this.txtDrAccount.TabIndex = 0;
            this.txtDrAccount.TabIndexChanged += new System.EventHandler(this.txtDrAccount_TabIndexChanged);
            this.txtDrAccount.TextChanged += new System.EventHandler(this.txtDrAccount_TextChanged);
            this.txtDrAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDrAccount_KeyDown);
            this.txtDrAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDrAccount_KeyPress);
            this.txtDrAccount.Leave += new System.EventHandler(this.txtDrAccount_Leave);
            this.txtDrAccount.Validated += new System.EventHandler(this.txtDrAccount_Validated);
            // 
            // btnSelectDrAccount
            // 
            this.btnSelectDrAccount.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSelectDrAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectDrAccount.Location = new System.Drawing.Point(214, 7);
            this.btnSelectDrAccount.Name = "btnSelectDrAccount";
            this.btnSelectDrAccount.Size = new System.Drawing.Size(36, 23);
            this.btnSelectDrAccount.TabIndex = 1;
            this.btnSelectDrAccount.Text = ":::";
            this.btnSelectDrAccount.UseVisualStyleBackColor = false;
            this.btnSelectDrAccount.Click += new System.EventHandler(this.btnSelectDrAccount_Click);
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(6, 10);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(272, 20);
            this.txtAmount.TabIndex = 0;
            this.txtAmount.TextChanged += new System.EventHandler(this.txtAmount_TextChanged);
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAmount_KeyDown);
            this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAmount_KeyPress);
            this.txtAmount.Validated += new System.EventHandler(this.txtAmount_Validated);
            // 
            // dtpValueDate
            // 
            this.dtpValueDate.Location = new System.Drawing.Point(6, 6);
            this.dtpValueDate.Name = "dtpValueDate";
            this.dtpValueDate.Size = new System.Drawing.Size(266, 20);
            this.dtpValueDate.TabIndex = 0;
            // 
            // lblDebitAccount
            // 
            this.lblDebitAccount.AutoSize = true;
            this.lblDebitAccount.Location = new System.Drawing.Point(3, 7);
            this.lblDebitAccount.Name = "lblDebitAccount";
            this.lblDebitAccount.Size = new System.Drawing.Size(75, 13);
            this.lblDebitAccount.TabIndex = 4;
            this.lblDebitAccount.Text = "Debit Account";
            // 
            // lblModeofPayment
            // 
            this.lblModeofPayment.AutoSize = true;
            this.lblModeofPayment.Location = new System.Drawing.Point(3, 79);
            this.lblModeofPayment.Name = "lblModeofPayment";
            this.lblModeofPayment.Size = new System.Drawing.Size(99, 13);
            this.lblModeofPayment.TabIndex = 48;
            this.lblModeofPayment.Text = "Method of Payment";
            // 
            // lblCreditAccount
            // 
            this.lblCreditAccount.AutoSize = true;
            this.lblCreditAccount.Location = new System.Drawing.Point(3, 363);
            this.lblCreditAccount.Name = "lblCreditAccount";
            this.lblCreditAccount.Size = new System.Drawing.Size(77, 13);
            this.lblCreditAccount.TabIndex = 34;
            this.lblCreditAccount.Text = "Credit Account";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(3, 435);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(47, 13);
            this.lblAmount.TabIndex = 35;
            this.lblAmount.Text = "Amount*";
            // 
            // lblValueDate
            // 
            this.lblValueDate.AutoSize = true;
            this.lblValueDate.Location = new System.Drawing.Point(3, 495);
            this.lblValueDate.Name = "lblValueDate";
            this.lblValueDate.Size = new System.Drawing.Size(60, 13);
            this.lblValueDate.TabIndex = 45;
            this.lblValueDate.Text = "Value Date";
            // 
            // btnPost
            // 
            this.btnPost.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnPost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPost.Location = new System.Drawing.Point(94, 9);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(75, 22);
            this.btnPost.TabIndex = 0;
            this.btnPost.Text = "Post";
            this.btnPost.UseVisualStyleBackColor = false;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // cboModeofPayment
            // 
            this.cboModeofPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModeofPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboModeofPayment.FormattingEnabled = true;
            this.cboModeofPayment.Location = new System.Drawing.Point(6, 9);
            this.cboModeofPayment.Name = "cboModeofPayment";
            this.cboModeofPayment.Size = new System.Drawing.Size(272, 21);
            this.cboModeofPayment.TabIndex = 0;
            this.cboModeofPayment.SelectedIndexChanged += new System.EventHandler(this.cboModeofPayment_SelectedIndexChanged);
            // 
            // tableLayoutPanelDPost
            // 
            this.tableLayoutPanelDPost.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanelDPost.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelDPost.ColumnCount = 3;
            this.tableLayoutPanelDPost.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.2292F));
            this.tableLayoutPanelDPost.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.74893F));
            this.tableLayoutPanelDPost.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1.021862F));
            this.tableLayoutPanelDPost.Controls.Add(this.lblValueDate, 0, 8);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxMpesa, 1, 10);
            this.tableLayoutPanelDPost.Controls.Add(this.lblAmount, 0, 7);
            this.tableLayoutPanelDPost.Controls.Add(this.lblCreditAccount, 0, 6);
            this.tableLayoutPanelDPost.Controls.Add(this.lblModeofPayment, 0, 2);
            this.tableLayoutPanelDPost.Controls.Add(this.lblDebitAccount, 0, 1);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxDrAccount, 1, 1);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxCreditAccount, 1, 6);
            this.tableLayoutPanelDPost.Controls.Add(this.lblDrNarrative, 0, 4);
            this.tableLayoutPanelDPost.Controls.Add(this.lblCrNarrative, 0, 5);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxCheque, 1, 3);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxBankSlip, 1, 11);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxModeofPayment, 1, 2);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBox4, 1, 9);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxValueDate, 1, 8);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxDrNarrative, 1, 4);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxCrNarrative, 1, 5);
            this.tableLayoutPanelDPost.Controls.Add(this.groupBoxAmount, 1, 7);
            this.tableLayoutPanelDPost.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelDPost.Name = "tableLayoutPanelDPost";
            this.tableLayoutPanelDPost.RowCount = 12;
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 0.9828452F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.730167F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.682086F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.74268F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.42578F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.42578F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.730167F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.136607F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.467913F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.449695F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.832898F));
            this.tableLayoutPanelDPost.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.96867F));
            this.tableLayoutPanelDPost.Size = new System.Drawing.Size(740, 766);
            this.tableLayoutPanelDPost.TabIndex = 0;
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
            this.groupBoxMpesa.Controls.Add(this.label7);
            this.groupBoxMpesa.Controls.Add(this.txtMpesaAmountPaid);
            this.groupBoxMpesa.Location = new System.Drawing.Point(130, 601);
            this.groupBoxMpesa.Name = "groupBoxMpesa";
            this.groupBoxMpesa.Size = new System.Drawing.Size(598, 52);
            this.groupBoxMpesa.TabIndex = 9;
            this.groupBoxMpesa.TabStop = false;
            this.groupBoxMpesa.Text = "Mpesa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(361, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Phone Number";
            // 
            // txtMpesaPhoneNumber
            // 
            this.txtMpesaPhoneNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMpesaPhoneNumber.Location = new System.Drawing.Point(441, 28);
            this.txtMpesaPhoneNumber.MaxLength = 250;
            this.txtMpesaPhoneNumber.Name = "txtMpesaPhoneNumber";
            this.txtMpesaPhoneNumber.Size = new System.Drawing.Size(130, 20);
            this.txtMpesaPhoneNumber.TabIndex = 3;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(404, 11);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(35, 13);
            this.label30.TabIndex = 15;
            this.label30.Text = "Name";
            // 
            // txtMpesaSenderName
            // 
            this.txtMpesaSenderName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMpesaSenderName.Location = new System.Drawing.Point(441, 8);
            this.txtMpesaSenderName.MaxLength = 250;
            this.txtMpesaSenderName.Name = "txtMpesaSenderName";
            this.txtMpesaSenderName.Size = new System.Drawing.Size(130, 20);
            this.txtMpesaSenderName.TabIndex = 2;
            // 
            // btnSMSGateWay
            // 
            this.btnSMSGateWay.AutoSize = true;
            this.btnSMSGateWay.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnSMSGateWay.LinkColor = System.Drawing.Color.Yellow;
            this.btnSMSGateWay.Location = new System.Drawing.Point(7, 26);
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
            this.label8.Location = new System.Drawing.Point(136, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Receipt No";
            // 
            // txtMpesaReceiptNo
            // 
            this.txtMpesaReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMpesaReceiptNo.Location = new System.Drawing.Point(199, 8);
            this.txtMpesaReceiptNo.MaxLength = 250;
            this.txtMpesaReceiptNo.Name = "txtMpesaReceiptNo";
            this.txtMpesaReceiptNo.Size = new System.Drawing.Size(128, 20);
            this.txtMpesaReceiptNo.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(130, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Amount Paid";
            // 
            // txtMpesaAmountPaid
            // 
            this.txtMpesaAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMpesaAmountPaid.Location = new System.Drawing.Point(199, 28);
            this.txtMpesaAmountPaid.MaxLength = 8;
            this.txtMpesaAmountPaid.Name = "txtMpesaAmountPaid";
            this.txtMpesaAmountPaid.Size = new System.Drawing.Size(128, 20);
            this.txtMpesaAmountPaid.TabIndex = 1;
            this.txtMpesaAmountPaid.TextChanged += new System.EventHandler(this.txtMpesaAmountPaid_TextChanged);
            this.txtMpesaAmountPaid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMpesaAmountPaid_KeyDown);
            this.txtMpesaAmountPaid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMpesaAmountPaid_KeyPress);
            this.txtMpesaAmountPaid.Validated += new System.EventHandler(this.txtMpesaAmountPaid_Validated);
            // 
            // groupBoxCheque
            // 
            this.groupBoxCheque.Controls.Add(this.lblChequeBankSortCodeDetails);
            this.groupBoxCheque.Controls.Add(this.btnSearchchequeBank);
            this.groupBoxCheque.Controls.Add(this.txtcqBankSortCode);
            this.groupBoxCheque.Controls.Add(this.label9);
            this.groupBoxCheque.Controls.Add(this.txtChequeNo);
            this.groupBoxCheque.Controls.Add(this.label11);
            this.groupBoxCheque.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCheque.Location = new System.Drawing.Point(130, 146);
            this.groupBoxCheque.Name = "groupBoxCheque";
            this.groupBoxCheque.Size = new System.Drawing.Size(598, 104);
            this.groupBoxCheque.TabIndex = 2;
            this.groupBoxCheque.TabStop = false;
            this.groupBoxCheque.Text = "Cheque";
            // 
            // lblChequeBankSortCodeDetails
            // 
            this.lblChequeBankSortCodeDetails.AutoSize = true;
            this.lblChequeBankSortCodeDetails.Location = new System.Drawing.Point(6, 55);
            this.lblChequeBankSortCodeDetails.Name = "lblChequeBankSortCodeDetails";
            this.lblChequeBankSortCodeDetails.Size = new System.Drawing.Size(19, 13);
            this.lblChequeBankSortCodeDetails.TabIndex = 39;
            this.lblChequeBankSortCodeDetails.Text = "::::";
            // 
            // btnSearchchequeBank
            // 
            this.btnSearchchequeBank.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchchequeBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchchequeBank.Location = new System.Drawing.Point(213, 30);
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
            this.txtcqBankSortCode.Location = new System.Drawing.Point(94, 31);
            this.txtcqBankSortCode.MaxLength = 5;
            this.txtcqBankSortCode.Name = "txtcqBankSortCode";
            this.txtcqBankSortCode.Size = new System.Drawing.Size(90, 20);
            this.txtcqBankSortCode.TabIndex = 1;
            this.txtcqBankSortCode.TabIndexChanged += new System.EventHandler(this.txtcqBankSortCode_TabIndexChanged);
            this.txtcqBankSortCode.TextChanged += new System.EventHandler(this.txtcqBankSortCode_TextChanged);
            this.txtcqBankSortCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtcqBankSortCode_KeyDown);
            this.txtcqBankSortCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtcqBankSortCode_KeyPress);
            this.txtcqBankSortCode.Leave += new System.EventHandler(this.txtcqBankSortCode_Leave);
            this.txtcqBankSortCode.Validated += new System.EventHandler(this.txtcqBankSortCode_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Cheque  No";
            // 
            // txtChequeNo
            // 
            this.txtChequeNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChequeNo.Location = new System.Drawing.Point(94, 8);
            this.txtChequeNo.MaxLength = 250;
            this.txtChequeNo.Name = "txtChequeNo";
            this.txtChequeNo.Size = new System.Drawing.Size(156, 20);
            this.txtChequeNo.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(10, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(82, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Bank Sort Code";
            // 
            // groupBoxBankSlip
            // 
            this.groupBoxBankSlip.Controls.Add(this.lblSlipBankSortCodeDetails);
            this.groupBoxBankSlip.Controls.Add(this.btnSearchslipBank);
            this.groupBoxBankSlip.Controls.Add(this.txtbsBankSortCode);
            this.groupBoxBankSlip.Controls.Add(this.label12);
            this.groupBoxBankSlip.Controls.Add(this.txtBankSlipNo);
            this.groupBoxBankSlip.Controls.Add(this.label13);
            this.groupBoxBankSlip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxBankSlip.Location = new System.Drawing.Point(130, 659);
            this.groupBoxBankSlip.Name = "groupBoxBankSlip";
            this.groupBoxBankSlip.Size = new System.Drawing.Size(598, 104);
            this.groupBoxBankSlip.TabIndex = 10;
            this.groupBoxBankSlip.TabStop = false;
            this.groupBoxBankSlip.Text = "Bank Slip";
            // 
            // lblSlipBankSortCodeDetails
            // 
            this.lblSlipBankSortCodeDetails.AutoSize = true;
            this.lblSlipBankSortCodeDetails.Location = new System.Drawing.Point(7, 54);
            this.lblSlipBankSortCodeDetails.Name = "lblSlipBankSortCodeDetails";
            this.lblSlipBankSortCodeDetails.Size = new System.Drawing.Size(19, 13);
            this.lblSlipBankSortCodeDetails.TabIndex = 39;
            this.lblSlipBankSortCodeDetails.Text = "::::";
            // 
            // btnSearchslipBank
            // 
            this.btnSearchslipBank.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchslipBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchslipBank.Location = new System.Drawing.Point(210, 32);
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
            this.txtbsBankSortCode.Location = new System.Drawing.Point(94, 33);
            this.txtbsBankSortCode.MaxLength = 5;
            this.txtbsBankSortCode.Name = "txtbsBankSortCode";
            this.txtbsBankSortCode.Size = new System.Drawing.Size(86, 20);
            this.txtbsBankSortCode.TabIndex = 1;
            this.txtbsBankSortCode.TabIndexChanged += new System.EventHandler(this.txtbsBankSortCode_TabIndexChanged);
            this.txtbsBankSortCode.TextChanged += new System.EventHandler(this.txtbsBankSortCode_TextChanged);
            this.txtbsBankSortCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbsBankSortCode_KeyDown);
            this.txtbsBankSortCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbsBankSortCode_KeyPress);
            this.txtbsBankSortCode.Leave += new System.EventHandler(this.txtbsBankSortCode_Leave);
            this.txtbsBankSortCode.Validated += new System.EventHandler(this.txtbsBankSortCode_Validated);
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
            this.label13.Location = new System.Drawing.Point(10, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Bank Sort Code";
            // 
            // groupBoxModeofPayment
            // 
            this.groupBoxModeofPayment.Controls.Add(this.cboModeofPayment);
            this.groupBoxModeofPayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxModeofPayment.Location = new System.Drawing.Point(130, 82);
            this.groupBoxModeofPayment.Name = "groupBoxModeofPayment";
            this.groupBoxModeofPayment.Size = new System.Drawing.Size(598, 58);
            this.groupBoxModeofPayment.TabIndex = 1;
            this.groupBoxModeofPayment.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnPost);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(130, 546);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(598, 49);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            // 
            // groupBoxValueDate
            // 
            this.groupBoxValueDate.Controls.Add(this.dtpValueDate);
            this.groupBoxValueDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxValueDate.Location = new System.Drawing.Point(130, 498);
            this.groupBoxValueDate.Name = "groupBoxValueDate";
            this.groupBoxValueDate.Size = new System.Drawing.Size(598, 42);
            this.groupBoxValueDate.TabIndex = 7;
            this.groupBoxValueDate.TabStop = false;
            // 
            // groupBoxDrNarrative
            // 
            this.groupBoxDrNarrative.Controls.Add(this.txtDebitNarrative);
            this.groupBoxDrNarrative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxDrNarrative.Location = new System.Drawing.Point(130, 256);
            this.groupBoxDrNarrative.Name = "groupBoxDrNarrative";
            this.groupBoxDrNarrative.Size = new System.Drawing.Size(598, 49);
            this.groupBoxDrNarrative.TabIndex = 3;
            this.groupBoxDrNarrative.TabStop = false;
            // 
            // groupBoxCrNarrative
            // 
            this.groupBoxCrNarrative.Controls.Add(this.txtCrNarrative);
            this.groupBoxCrNarrative.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCrNarrative.Location = new System.Drawing.Point(130, 311);
            this.groupBoxCrNarrative.Name = "groupBoxCrNarrative";
            this.groupBoxCrNarrative.Size = new System.Drawing.Size(598, 49);
            this.groupBoxCrNarrative.TabIndex = 4;
            this.groupBoxCrNarrative.TabStop = false;
            // 
            // groupBoxAmount
            // 
            this.groupBoxAmount.Controls.Add(this.txtAmount);
            this.groupBoxAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxAmount.Location = new System.Drawing.Point(130, 438);
            this.groupBoxAmount.Name = "groupBoxAmount";
            this.groupBoxAmount.Size = new System.Drawing.Size(598, 54);
            this.groupBoxAmount.TabIndex = 6;
            this.groupBoxAmount.TabStop = false;
            // 
            // UserControlDoublePost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelDPost);
            this.Name = "UserControlDoublePost";
            this.Size = new System.Drawing.Size(740, 766);
            this.Load += new System.EventHandler(this.UserControlDoublePost_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBoxCreditAccount.ResumeLayout(false);
            this.groupBoxCreditAccount.PerformLayout();
            this.groupBoxDrAccount.ResumeLayout(false);
            this.groupBoxDrAccount.PerformLayout();
            this.tableLayoutPanelDPost.ResumeLayout(false);
            this.tableLayoutPanelDPost.PerformLayout();
            this.groupBoxMpesa.ResumeLayout(false);
            this.groupBoxMpesa.PerformLayout();
            this.groupBoxCheque.ResumeLayout(false);
            this.groupBoxCheque.PerformLayout();
            this.groupBoxBankSlip.ResumeLayout(false);
            this.groupBoxBankSlip.PerformLayout();
            this.groupBoxModeofPayment.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBoxValueDate.ResumeLayout(false);
            this.groupBoxDrNarrative.ResumeLayout(false);
            this.groupBoxDrNarrative.PerformLayout();
            this.groupBoxCrNarrative.ResumeLayout(false);
            this.groupBoxCrNarrative.PerformLayout();
            this.groupBoxAmount.ResumeLayout(false);
            this.groupBoxAmount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelDPost;
        private System.Windows.Forms.ComboBox cboModeofPayment;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.Label lblValueDate;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label lblCreditAccount;
        private System.Windows.Forms.Label lblModeofPayment;
        private System.Windows.Forms.Label lblDebitAccount;
        private System.Windows.Forms.DateTimePicker dtpValueDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.GroupBox groupBoxDrAccount;
        private System.Windows.Forms.TextBox txtDrAccount;
        private System.Windows.Forms.Button btnSelectDrAccount;
        private System.Windows.Forms.GroupBox groupBoxCreditAccount;
        private System.Windows.Forms.TextBox txtCrAccount;
        private System.Windows.Forms.Button btnSelectCrAccount;
        private System.Windows.Forms.TextBox txtCrNarrative;
        private System.Windows.Forms.TextBox txtDebitNarrative;
        private System.Windows.Forms.Label lblDrNarrative;
        private System.Windows.Forms.Label lblCrNarrative;
        private System.Windows.Forms.GroupBox groupBoxCheque;
        private System.Windows.Forms.Button btnSearchchequeBank;
        private System.Windows.Forms.TextBox txtcqBankSortCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtChequeNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBoxBankSlip;
        private System.Windows.Forms.Button btnSearchslipBank;
        private System.Windows.Forms.TextBox txtbsBankSortCode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtBankSlipNo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblDrAccountDetails;
        private System.Windows.Forms.Label lblCrAccountDetails;
        private System.Windows.Forms.Label lblChequeBankSortCodeDetails;
        private System.Windows.Forms.Label lblSlipBankSortCodeDetails;
        private System.Windows.Forms.GroupBox groupBoxModeofPayment;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBoxValueDate;
        private System.Windows.Forms.GroupBox groupBoxDrNarrative;
        private System.Windows.Forms.GroupBox groupBoxCrNarrative;
        private System.Windows.Forms.GroupBox groupBoxAmount;
        private System.Windows.Forms.GroupBox groupBoxMpesa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMpesaPhoneNumber;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TextBox txtMpesaSenderName;
        private System.Windows.Forms.LinkLabel btnSMSGateWay;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMpesaReceiptNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMpesaAmountPaid;
    }
}
