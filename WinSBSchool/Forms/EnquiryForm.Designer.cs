namespace WinSBSchool.Forms
{
    partial class EnquiryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboAccountNumber = new System.Windows.Forms.ComboBox();
            this.cboAdmissionNumber = new System.Windows.Forms.ComboBox();
            this.dateTimePickerEndDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearchAccount = new System.Windows.Forms.LinkLabel();
            this.btnSearch = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.bindingSourceTransactions = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.ColumnTransactionTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNarrative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btntransactions = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTransactions)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btntransactions);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboAccountNumber);
            this.groupBox1.Controls.Add(this.cboAdmissionNumber);
            this.groupBox1.Controls.Add(this.dateTimePickerEndDate);
            this.groupBox1.Controls.Add(this.dateTimePickerStartDate);
            this.groupBox1.Controls.Add(this.btnSearchAccount);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Start Date";
            // 
            // cboAccountNumber
            // 
            this.cboAccountNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAccountNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAccountNumber.FormattingEnabled = true;
            this.cboAccountNumber.Location = new System.Drawing.Point(96, 22);
            this.cboAccountNumber.Name = "cboAccountNumber";
            this.cboAccountNumber.Size = new System.Drawing.Size(184, 21);
            this.cboAccountNumber.TabIndex = 11;
            // 
            // cboAdmissionNumber
            // 
            this.cboAdmissionNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAdmissionNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboAdmissionNumber.FormattingEnabled = true;
            this.cboAdmissionNumber.Location = new System.Drawing.Point(96, 64);
            this.cboAdmissionNumber.Name = "cboAdmissionNumber";
            this.cboAdmissionNumber.Size = new System.Drawing.Size(184, 21);
            this.cboAdmissionNumber.TabIndex = 10;
            this.cboAdmissionNumber.Visible = false;
            // 
            // dateTimePickerEndDate
            // 
            this.dateTimePickerEndDate.Location = new System.Drawing.Point(365, 22);
            this.dateTimePickerEndDate.Name = "dateTimePickerEndDate";
            this.dateTimePickerEndDate.Size = new System.Drawing.Size(188, 20);
            this.dateTimePickerEndDate.TabIndex = 7;
            // 
            // dateTimePickerStartDate
            // 
            this.dateTimePickerStartDate.Location = new System.Drawing.Point(365, 64);
            this.dateTimePickerStartDate.Name = "dateTimePickerStartDate";
            this.dateTimePickerStartDate.Size = new System.Drawing.Size(188, 20);
            this.dateTimePickerStartDate.TabIndex = 6;
            // 
            // btnSearchAccount
            // 
            this.btnSearchAccount.AutoSize = true;
            this.btnSearchAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSearchAccount.LinkColor = System.Drawing.Color.Yellow;
            this.btnSearchAccount.Location = new System.Drawing.Point(602, 16);
            this.btnSearchAccount.Name = "btnSearchAccount";
            this.btnSearchAccount.Size = new System.Drawing.Size(127, 18);
            this.btnSearchAccount.TabIndex = 5;
            this.btnSearchAccount.TabStop = true;
            this.btnSearchAccount.Text = "Search Account";
            this.btnSearchAccount.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSearchAccount_LinkClicked);
            // 
            // btnSearch
            // 
            this.btnSearch.AutoSize = true;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnSearch.LinkColor = System.Drawing.Color.Yellow;
            this.btnSearch.Location = new System.Drawing.Point(602, 44);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(61, 18);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.TabStop = true;
            this.btnSearch.Text = "Search";
            this.btnSearch.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSearch_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(312, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "End Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Account No";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Admission No";
            this.label1.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(704, 541);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 31);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TransactionTypeId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Transaction Type Id";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccountID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Account";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Narrative";
            this.dataGridViewTextBoxColumn3.HeaderText = "Narrative";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn4.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewTransactions);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(810, 266);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "TRANSACTIONS LIST";
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
            this.ColumnTransactionTypeId,
            this.ColumnAccountID,
            this.ColumnNarrative,
            this.ColumnAmount});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTransactions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewTransactions.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewTransactions.MultiSelect = false;
            this.dataGridViewTransactions.Name = "dataGridViewTransactions";
            this.dataGridViewTransactions.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTransactions.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTransactions.Size = new System.Drawing.Size(804, 247);
            this.dataGridViewTransactions.TabIndex = 6;
            // 
            // ColumnTransactionTypeId
            // 
            this.ColumnTransactionTypeId.DataPropertyName = "TransactionTypeId";
            this.ColumnTransactionTypeId.HeaderText = "Id";
            this.ColumnTransactionTypeId.MinimumWidth = 100;
            this.ColumnTransactionTypeId.Name = "ColumnTransactionTypeId";
            this.ColumnTransactionTypeId.ReadOnly = true;
            // 
            // ColumnAccountID
            // 
            this.ColumnAccountID.DataPropertyName = "AccountID";
            this.ColumnAccountID.HeaderText = "Account";
            this.ColumnAccountID.Name = "ColumnAccountID";
            this.ColumnAccountID.ReadOnly = true;
            // 
            // ColumnNarrative
            // 
            this.ColumnNarrative.DataPropertyName = "Narrative";
            this.ColumnNarrative.HeaderText = "Narrative";
            this.ColumnNarrative.Name = "ColumnNarrative";
            this.ColumnNarrative.ReadOnly = true;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.MinimumWidth = 100;
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            // 
            // btntransactions
            // 
            this.btntransactions.AutoSize = true;
            this.btntransactions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btntransactions.LinkColor = System.Drawing.Color.Yellow;
            this.btntransactions.Location = new System.Drawing.Point(602, 74);
            this.btntransactions.Name = "btntransactions";
            this.btntransactions.Size = new System.Drawing.Size(106, 18);
            this.btntransactions.TabIndex = 13;
            this.btntransactions.TabStop = true;
            this.btntransactions.Text = "Transactions";
            this.btntransactions.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btntransactions_LinkClicked);
            // 
            // EnquiryForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(810, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Name = "EnquiryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enquiry ";
            this.Load += new System.EventHandler(this.EnquiryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTransactions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEndDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartDate;
        private System.Windows.Forms.LinkLabel btnSearchAccount;
        private System.Windows.Forms.LinkLabel btnSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.BindingSource bindingSourceTransactions;
        private System.Windows.Forms.ComboBox cboAccountNumber;
        private System.Windows.Forms.ComboBox cboAdmissionNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTransactionTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNarrative;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.LinkLabel btntransactions;
    }
}