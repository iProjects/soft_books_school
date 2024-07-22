namespace WinSBSchool.Forms
{
    partial class TransactionsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionsForm));
            this.btnDoubleEntryPosting = new System.Windows.Forms.LinkLabel();
            this.btnMuiltiEntryPosting = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnSingleEntryPosting = new System.Windows.Forms.LinkLabel();
            this.bindingSourceTransactions = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnrefresh = new System.Windows.Forms.LinkLabel();
            this.btnviewdetails = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bindingSourceaccounts = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourcetransactiontypes = new System.Windows.Forms.BindingSource(this.components);
            this.panelPager = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTransRef = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNarrative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPostDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRecordDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txttransactionreference = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboaccount = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtppostdate = new System.Windows.Forms.DateTimePicker();
            this.btnclearfilter = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTransactions)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceaccounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcetransactiontypes)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDoubleEntryPosting
            // 
            this.btnDoubleEntryPosting.AutoSize = true;
            this.btnDoubleEntryPosting.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoubleEntryPosting.LinkColor = System.Drawing.Color.Yellow;
            this.btnDoubleEntryPosting.Location = new System.Drawing.Point(206, 73);
            this.btnDoubleEntryPosting.Name = "btnDoubleEntryPosting";
            this.btnDoubleEntryPosting.Size = new System.Drawing.Size(190, 22);
            this.btnDoubleEntryPosting.TabIndex = 1;
            this.btnDoubleEntryPosting.TabStop = true;
            this.btnDoubleEntryPosting.Text = "Double  Entry Posting";
            this.btnDoubleEntryPosting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDoubleEntryPosting_LinkClicked);
            // 
            // btnMuiltiEntryPosting
            // 
            this.btnMuiltiEntryPosting.AutoSize = true;
            this.btnMuiltiEntryPosting.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuiltiEntryPosting.LinkColor = System.Drawing.Color.Yellow;
            this.btnMuiltiEntryPosting.Location = new System.Drawing.Point(413, 73);
            this.btnMuiltiEntryPosting.Name = "btnMuiltiEntryPosting";
            this.btnMuiltiEntryPosting.Size = new System.Drawing.Size(171, 22);
            this.btnMuiltiEntryPosting.TabIndex = 2;
            this.btnMuiltiEntryPosting.TabStop = true;
            this.btnMuiltiEntryPosting.Text = "Multi Entry Posting";
            this.btnMuiltiEntryPosting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnMuiltiEntryPosting_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(818, 75);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 22);
            this.btnClose.TabIndex = 5;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnSingleEntryPosting
            // 
            this.btnSingleEntryPosting.AutoSize = true;
            this.btnSingleEntryPosting.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleEntryPosting.LinkColor = System.Drawing.Color.Yellow;
            this.btnSingleEntryPosting.Location = new System.Drawing.Point(12, 73);
            this.btnSingleEntryPosting.Name = "btnSingleEntryPosting";
            this.btnSingleEntryPosting.Size = new System.Drawing.Size(177, 22);
            this.btnSingleEntryPosting.TabIndex = 0;
            this.btnSingleEntryPosting.TabStop = true;
            this.btnSingleEntryPosting.Text = "Single Entry Posting";
            this.btnSingleEntryPosting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSingleEntryPosting_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelPager);
            this.groupBox1.Controls.Add(this.btnrefresh);
            this.groupBox1.Controls.Add(this.btnviewdetails);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnMuiltiEntryPosting);
            this.groupBox1.Controls.Add(this.btnDoubleEntryPosting);
            this.groupBox1.Controls.Add(this.btnSingleEntryPosting);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 515);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1136, 119);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnrefresh
            // 
            this.btnrefresh.AutoSize = true;
            this.btnrefresh.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrefresh.LinkColor = System.Drawing.Color.Yellow;
            this.btnrefresh.Location = new System.Drawing.Point(727, 75);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(74, 22);
            this.btnrefresh.TabIndex = 4;
            this.btnrefresh.TabStop = true;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnrefresh_LinkClicked);
            // 
            // btnviewdetails
            // 
            this.btnviewdetails.AutoSize = true;
            this.btnviewdetails.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnviewdetails.LinkColor = System.Drawing.Color.Yellow;
            this.btnviewdetails.Location = new System.Drawing.Point(601, 75);
            this.btnviewdetails.Name = "btnviewdetails";
            this.btnviewdetails.Size = new System.Drawing.Size(109, 22);
            this.btnviewdetails.TabIndex = 3;
            this.btnviewdetails.TabStop = true;
            this.btnviewdetails.Text = "view Details";
            this.btnviewdetails.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnviewdetails_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnclearfilter);
            this.groupBox2.Controls.Add(this.dtppostdate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboaccount);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txttransactionreference);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1136, 73);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // panelPager
            // 
            this.panelPager.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panelPager.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelPager.Location = new System.Drawing.Point(3, 16);
            this.panelPager.Name = "panelPager";
            this.panelPager.Size = new System.Drawing.Size(1130, 54);
            this.panelPager.TabIndex = 7;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewTransactions);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 73);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1136, 442);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // dataGridViewTransactions
            // 
            this.dataGridViewTransactions.AllowUserToAddRows = false;
            this.dataGridViewTransactions.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnTransRef,
            this.ColumnAmount,
            this.ColumnNarrative,
            this.ColumnPostDate,
            this.ColumnValueDate,
            this.ColumnRecordDate,
            this.ColumnUserName});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTransactions.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTransactions.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewTransactions.Name = "dataGridViewTransactions";
            this.dataGridViewTransactions.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTransactions.Size = new System.Drawing.Size(1130, 423);
            this.dataGridViewTransactions.TabIndex = 1;
            this.dataGridViewTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTransactions_CellContentDoubleClick);
            this.dataGridViewTransactions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewTransactions_DataError);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TransactionTypeId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Transaction Type";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccountID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Account";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn3.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Narrative";
            this.dataGridViewTextBoxColumn4.HeaderText = "Narrative";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 110;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "UserID";
            this.dataGridViewTextBoxColumn5.HeaderText = "User";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 110;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Authorizer";
            this.dataGridViewTextBoxColumn6.HeaderText = "Authorizer";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 110;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "StatementFlag";
            this.dataGridViewTextBoxColumn7.HeaderText = "Statement Flag";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 120;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PostDate";
            this.dataGridViewTextBoxColumn8.HeaderText = "Post Date";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.DataPropertyName = "Id";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Width = 30;
            // 
            // ColumnTransRef
            // 
            this.ColumnTransRef.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnTransRef.DataPropertyName = "TransRef";
            this.ColumnTransRef.HeaderText = "Transaction Refefence";
            this.ColumnTransRef.Name = "ColumnTransRef";
            this.ColumnTransRef.ReadOnly = true;
            this.ColumnTransRef.Width = 80;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 90;
            // 
            // ColumnNarrative
            // 
            this.ColumnNarrative.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnNarrative.DataPropertyName = "Narrative";
            this.ColumnNarrative.HeaderText = "Narrative";
            this.ColumnNarrative.Name = "ColumnNarrative";
            this.ColumnNarrative.ReadOnly = true;
            this.ColumnNarrative.Width = 180;
            // 
            // ColumnPostDate
            // 
            this.ColumnPostDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnPostDate.DataPropertyName = "PostDate";
            this.ColumnPostDate.HeaderText = "Post Date";
            this.ColumnPostDate.Name = "ColumnPostDate";
            this.ColumnPostDate.ReadOnly = true;
            this.ColumnPostDate.Width = 115;
            // 
            // ColumnValueDate
            // 
            this.ColumnValueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnValueDate.DataPropertyName = "ValueDate";
            this.ColumnValueDate.HeaderText = "Value Date";
            this.ColumnValueDate.Name = "ColumnValueDate";
            this.ColumnValueDate.ReadOnly = true;
            this.ColumnValueDate.Width = 115;
            // 
            // ColumnRecordDate
            // 
            this.ColumnRecordDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnRecordDate.DataPropertyName = "RecordDate";
            this.ColumnRecordDate.HeaderText = "Record Date";
            this.ColumnRecordDate.Name = "ColumnRecordDate";
            this.ColumnRecordDate.ReadOnly = true;
            this.ColumnRecordDate.Width = 115;
            // 
            // ColumnUserName
            // 
            this.ColumnUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnUserName.DataPropertyName = "UserName";
            this.ColumnUserName.HeaderText = "User";
            this.ColumnUserName.Name = "ColumnUserName";
            this.ColumnUserName.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "ValueDate";
            this.dataGridViewTextBoxColumn9.HeaderText = "Value Date";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "RecordDate";
            this.dataGridViewTextBoxColumn10.HeaderText = "Record Date";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(331, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction Reference";
            // 
            // txttransactionreference
            // 
            this.txttransactionreference.Location = new System.Drawing.Point(453, 31);
            this.txttransactionreference.Name = "txttransactionreference";
            this.txttransactionreference.Size = new System.Drawing.Size(171, 20);
            this.txttransactionreference.TabIndex = 1;
            this.txttransactionreference.TextChanged += new System.EventHandler(this.txttransactionreference_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Account";
            // 
            // cboaccount
            // 
            this.cboaccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboaccount.FormattingEnabled = true;
            this.cboaccount.Location = new System.Drawing.Point(77, 31);
            this.cboaccount.Name = "cboaccount";
            this.cboaccount.Size = new System.Drawing.Size(189, 21);
            this.cboaccount.TabIndex = 0;
            this.cboaccount.SelectedIndexChanged += new System.EventHandler(this.cboaccount_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(662, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Post Date";
            // 
            // dtppostdate
            // 
            this.dtppostdate.Location = new System.Drawing.Point(731, 31);
            this.dtppostdate.Name = "dtppostdate";
            this.dtppostdate.Size = new System.Drawing.Size(225, 20);
            this.dtppostdate.TabIndex = 2;
            this.dtppostdate.ValueChanged += new System.EventHandler(this.dtppostdate_ValueChanged);
            // 
            // btnclearfilter
            // 
            this.btnclearfilter.AutoSize = true;
            this.btnclearfilter.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnclearfilter.LinkColor = System.Drawing.Color.Yellow;
            this.btnclearfilter.Location = new System.Drawing.Point(995, 31);
            this.btnclearfilter.Name = "btnclearfilter";
            this.btnclearfilter.Size = new System.Drawing.Size(106, 22);
            this.btnclearfilter.TabIndex = 3;
            this.btnclearfilter.TabStop = true;
            this.btnclearfilter.Text = "Clear Filter";
            this.btnclearfilter.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnclearfilter_LinkClicked);
            // 
            // TransactionsForm
            // 
            this.AcceptButton = this.btnrefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1136, 634);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TransactionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTransactions)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceaccounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourcetransactiontypes)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnDoubleEntryPosting;
        private System.Windows.Forms.LinkLabel btnMuiltiEntryPosting;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnSingleEntryPosting;
        private System.Windows.Forms.BindingSource bindingSourceTransactions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.BindingSource bindingSourceaccounts;
        private System.Windows.Forms.BindingSource bindingSourcetransactiontypes;
        private System.Windows.Forms.LinkLabel btnviewdetails;
        private System.Windows.Forms.LinkLabel btnrefresh;
        private System.Windows.Forms.Panel panelPager;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTransRef;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNarrative;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPostDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRecordDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserName;
        private System.Windows.Forms.DateTimePicker dtppostdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboaccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txttransactionreference;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel btnclearfilter;
    }
}