namespace WinSBSchool.Forms
{
    partial class PostingMuiltiEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostingMuiltiEntryForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAccountID = new System.Windows.Forms.TextBox();
            this.btnSearchAccount = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNarrative = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dpValueDate = new System.Windows.Forms.DateTimePicker();
            this.dpPostDate = new System.Windows.Forms.DateTimePicker();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnAddTransaction = new System.Windows.Forms.LinkLabel();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPostTransaction = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.bindingSourceTransactions = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNarrative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblaccountdetails = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 311);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblaccountdetails);
            this.groupBox4.Controls.Add(this.txtAccountID);
            this.groupBox4.Controls.Add(this.btnSearchAccount);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.txtAmount);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtNarrative);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.cboTransactionType);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.dpValueDate);
            this.groupBox4.Controls.Add(this.dpPostDate);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(498, 249);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            // 
            // txtAccountID
            // 
            this.txtAccountID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountID.Location = new System.Drawing.Point(121, 55);
            this.txtAccountID.MaxLength = 4;
            this.txtAccountID.Name = "txtAccountID";
            this.txtAccountID.Size = new System.Drawing.Size(249, 20);
            this.txtAccountID.TabIndex = 22;
            this.txtAccountID.TextChanged += new System.EventHandler(this.txtAccountID_TextChanged);
            // 
            // btnSearchAccount
            // 
            this.btnSearchAccount.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAccount.Location = new System.Drawing.Point(404, 55);
            this.btnSearchAccount.Name = "btnSearchAccount";
            this.btnSearchAccount.Size = new System.Drawing.Size(36, 23);
            this.btnSearchAccount.TabIndex = 23;
            this.btnSearchAccount.Text = ":::";
            this.btnSearchAccount.UseVisualStyleBackColor = false;
            this.btnSearchAccount.Click += new System.EventHandler(this.btnSearchbyAccount_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Transaction Type*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Post Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Value Date";
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(121, 108);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(319, 20);
            this.txtAmount.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Account Id*";
            // 
            // txtNarrative
            // 
            this.txtNarrative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarrative.Location = new System.Drawing.Point(121, 142);
            this.txtNarrative.MaxLength = 100;
            this.txtNarrative.Name = "txtNarrative";
            this.txtNarrative.Size = new System.Drawing.Size(319, 20);
            this.txtNarrative.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Narrative*";
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(121, 19);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(319, 21);
            this.cboTransactionType.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(68, 110);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Amount*";
            // 
            // dpValueDate
            // 
            this.dpValueDate.Location = new System.Drawing.Point(121, 210);
            this.dpValueDate.Name = "dpValueDate";
            this.dpValueDate.Size = new System.Drawing.Size(319, 20);
            this.dpValueDate.TabIndex = 5;
            // 
            // dpPostDate
            // 
            this.dpPostDate.Location = new System.Drawing.Point(121, 177);
            this.dpPostDate.Name = "dpPostDate";
            this.dpPostDate.Size = new System.Drawing.Size(319, 20);
            this.dpPostDate.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnAddTransaction);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 265);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(498, 43);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.AutoSize = true;
            this.btnAddTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTransaction.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddTransaction.Location = new System.Drawing.Point(228, 16);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(41, 20);
            this.btnAddTransaction.TabIndex = 6;
            this.btnAddTransaction.TabStop = true;
            this.btnAddTransaction.Text = "Add";
            this.btnAddTransaction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddTransaction_LinkClicked);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(280, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 20);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(371, 18);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(54, 20);
            this.btnClose.TabIndex = 9;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
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
            this.dataGridViewTransactions.Size = new System.Drawing.Size(498, 170);
            this.dataGridViewTransactions.TabIndex = 1;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // btnPostTransaction
            // 
            this.btnPostTransaction.AutoSize = true;
            this.btnPostTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostTransaction.LinkColor = System.Drawing.Color.Yellow;
            this.btnPostTransaction.Location = new System.Drawing.Point(206, 18);
            this.btnPostTransaction.Name = "btnPostTransaction";
            this.btnPostTransaction.Size = new System.Drawing.Size(45, 20);
            this.btnPostTransaction.TabIndex = 8;
            this.btnPostTransaction.TabStop = true;
            this.btnPostTransaction.Text = "Post";
            this.btnPostTransaction.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPostTransaction_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPostTransaction);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 500);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 49);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dataGridViewTransactions);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 311);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(504, 189);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
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
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "AccountID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Account";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
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
            // lblaccountdetails
            // 
            this.lblaccountdetails.AutoSize = true;
            this.lblaccountdetails.Location = new System.Drawing.Point(118, 85);
            this.lblaccountdetails.Name = "lblaccountdetails";
            this.lblaccountdetails.Size = new System.Drawing.Size(82, 13);
            this.lblaccountdetails.TabIndex = 27;
            this.lblaccountdetails.Text = "Account Details";
            // 
            // PostingMuiltiEntryForm
            // 
            this.AcceptButton = this.btnPostTransaction;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(504, 549);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PostingMuiltiEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Muilti Entry Transaction Posting";
            this.Load += new System.EventHandler(this.PostingMuiltiEntryForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtNarrative;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.DateTimePicker dpValueDate;
        private System.Windows.Forms.DateTimePicker dpPostDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAddTransaction;
        private System.Windows.Forms.LinkLabel btnPostTransaction;
        private System.Windows.Forms.BindingSource bindingSourceTransactions;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNarrative;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.TextBox txtAccountID;
        private System.Windows.Forms.Button btnSearchAccount;
        private System.Windows.Forms.Label lblaccountdetails;
    }
}