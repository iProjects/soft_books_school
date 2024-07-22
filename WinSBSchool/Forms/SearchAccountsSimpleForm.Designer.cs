namespace WinSBSchool.Forms
{
    partial class SearchAccountsSimpleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchAccountsSimpleForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewAccounts = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.txtAccountName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnloadall = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.bindingSourceAccounts = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBookBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnaddaccount = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounts)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccounts)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewAccounts);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(833, 269);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // dataGridViewAccounts
            // 
            this.dataGridViewAccounts.AllowUserToAddRows = false;
            this.dataGridViewAccounts.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAccounts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccounts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAccountID,
            this.ColumnAccountName,
            this.ColumnAccountNo,
            this.ColumnBookBalance});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewAccounts.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAccounts.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewAccounts.MultiSelect = false;
            this.dataGridViewAccounts.Name = "dataGridViewAccounts";
            this.dataGridViewAccounts.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAccounts.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewAccounts.Size = new System.Drawing.Size(827, 250);
            this.dataGridViewAccounts.TabIndex = 0;
            this.dataGridViewAccounts.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAccounts_CellContentDoubleClick);
            this.dataGridViewAccounts.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewAccounts_DataError);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(104, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Account No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(279, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Account Name:";
            // 
            // txtAccountId
            // 
            this.txtAccountId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountId.Location = new System.Drawing.Point(36, 21);
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(54, 20);
            this.txtAccountId.TabIndex = 0;
            this.txtAccountId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccountId_KeyDown);
            this.txtAccountId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountId_KeyPress);
            this.txtAccountId.Validated += new System.EventHandler(this.txtAccountId_Validated);
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountNo.Location = new System.Drawing.Point(177, 21);
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(81, 20);
            this.txtAccountNo.TabIndex = 1;
            this.txtAccountNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountNo_KeyPress);
            this.txtAccountNo.Validated += new System.EventHandler(this.txtAccountNo_Validated);
            // 
            // txtAccountName
            // 
            this.txtAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountName.Location = new System.Drawing.Point(366, 21);
            this.txtAccountName.Name = "txtAccountName";
            this.txtAccountName.Size = new System.Drawing.Size(152, 20);
            this.txtAccountName.TabIndex = 2;
            this.txtAccountName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountName_KeyPress);
            this.txtAccountName.Validated += new System.EventHandler(this.txtAccountName_Validated);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(746, 58);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmit.Location = new System.Drawing.Point(653, 58);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnaddaccount);
            this.groupBox2.Controls.Add(this.btnloadall);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCustomerName);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtAccountId);
            this.groupBox2.Controls.Add(this.txtAccountNo);
            this.groupBox2.Controls.Add(this.txtAccountName);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnSubmit);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(833, 104);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnloadall
            // 
            this.btnloadall.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnloadall.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnloadall.Location = new System.Drawing.Point(560, 58);
            this.btnloadall.Name = "btnloadall";
            this.btnloadall.Size = new System.Drawing.Size(75, 23);
            this.btnloadall.TabIndex = 4;
            this.btnloadall.Text = "Load All";
            this.btnloadall.UseVisualStyleBackColor = false;
            this.btnloadall.Click += new System.EventHandler(this.btnloadall_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(565, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Customer Name";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Location = new System.Drawing.Point(653, 21);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(145, 20);
            this.txtCustomerName.TabIndex = 3;
            this.txtCustomerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCustomerId_KeyDown);
            this.txtCustomerName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCustomerId_KeyPress);
            this.txtCustomerName.Validated += new System.EventHandler(this.txtCustomerId_Validated);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ExamPeriodId";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Year";
            this.dataGridViewTextBoxColumn2.HeaderText = "Year";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Term";
            this.dataGridViewTextBoxColumn3.HeaderText = "Term";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Description";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn4.HeaderText = "Description";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 200;
            // 
            // ColumnAccountID
            // 
            this.ColumnAccountID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnAccountID.DataPropertyName = "Id";
            this.ColumnAccountID.HeaderText = "Id";
            this.ColumnAccountID.Name = "ColumnAccountID";
            this.ColumnAccountID.ReadOnly = true;
            this.ColumnAccountID.Width = 50;
            // 
            // ColumnAccountName
            // 
            this.ColumnAccountName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnAccountName.DataPropertyName = "AccountName";
            this.ColumnAccountName.HeaderText = "Name";
            this.ColumnAccountName.Name = "ColumnAccountName";
            this.ColumnAccountName.ReadOnly = true;
            this.ColumnAccountName.Width = 140;
            // 
            // ColumnAccountNo
            // 
            this.ColumnAccountNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnAccountNo.DataPropertyName = "AccountNo";
            this.ColumnAccountNo.HeaderText = "Number";
            this.ColumnAccountNo.Name = "ColumnAccountNo";
            this.ColumnAccountNo.ReadOnly = true;
            this.ColumnAccountNo.Width = 80;
            // 
            // ColumnBookBalance
            // 
            this.ColumnBookBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnBookBalance.DataPropertyName = "BookBalance";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.ColumnBookBalance.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnBookBalance.HeaderText = "Book Balance";
            this.ColumnBookBalance.Name = "ColumnBookBalance";
            this.ColumnBookBalance.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn5.HeaderText = "Status";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // btnaddaccount
            // 
            this.btnaddaccount.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnaddaccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaddaccount.Location = new System.Drawing.Point(447, 58);
            this.btnaddaccount.Name = "btnaddaccount";
            this.btnaddaccount.Size = new System.Drawing.Size(93, 23);
            this.btnaddaccount.TabIndex = 18;
            this.btnaddaccount.Text = "Add Account";
            this.btnaddaccount.UseVisualStyleBackColor = false;
            this.btnaddaccount.Click += new System.EventHandler(this.btnaddaccount_Click);
            // 
            // SearchAccountsSimpleForm
            // 
            this.AcceptButton = this.btnloadall;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(833, 373);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SearchAccountsSimpleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search Account";
            this.Load += new System.EventHandler(this.SearchAccountsSimpleForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounts)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceAccounts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource bindingSourceAccounts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.TextBox txtAccountName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewAccounts;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBookBalance;
        private System.Windows.Forms.Button btnloadall;
        private System.Windows.Forms.Button btnaddaccount;
    }
}