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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewTransactions = new System.Windows.Forms.DataGridView();
            this.ColumnTransactionTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAccountID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNarrative = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAuthorizer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatementFlag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPostDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRecordDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDoubleEntryPosting = new System.Windows.Forms.LinkLabel();
            this.btnMuiltiEntryPosting = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnSingleEntryPosting = new System.Windows.Forms.LinkLabel();
            this.bindingSourceTransactions = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTransactions)).BeginInit();
            this.SuspendLayout();
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
            this.ColumnAmount,
            this.ColumnNarrative,
            this.ColumnUserID,
            this.ColumnAuthorizer,
            this.ColumnStatementFlag,
            this.ColumnPostDate,
            this.ColumnValueDate,
            this.ColumnRecordDate});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTransactions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTransactions.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridViewTransactions.Location = new System.Drawing.Point(0, 0);
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
            this.dataGridViewTransactions.Size = new System.Drawing.Size(810, 549);
            this.dataGridViewTransactions.TabIndex = 0;
            // 
            // ColumnTransactionTypeId
            // 
            this.ColumnTransactionTypeId.DataPropertyName = "TransactionTypeId";
            this.ColumnTransactionTypeId.HeaderText = "Transaction Type";
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
            // ColumnAmount
            // 
            this.ColumnAmount.DataPropertyName = "Amount";
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            // 
            // ColumnNarrative
            // 
            this.ColumnNarrative.DataPropertyName = "Narrative";
            this.ColumnNarrative.HeaderText = "Narrative";
            this.ColumnNarrative.Name = "ColumnNarrative";
            this.ColumnNarrative.ReadOnly = true;
            // 
            // ColumnUserID
            // 
            this.ColumnUserID.DataPropertyName = "UserID";
            this.ColumnUserID.HeaderText = "User";
            this.ColumnUserID.Name = "ColumnUserID";
            this.ColumnUserID.ReadOnly = true;
            // 
            // ColumnAuthorizer
            // 
            this.ColumnAuthorizer.DataPropertyName = "Authorizer";
            this.ColumnAuthorizer.HeaderText = "Authorizer";
            this.ColumnAuthorizer.Name = "ColumnAuthorizer";
            this.ColumnAuthorizer.ReadOnly = true;
            // 
            // ColumnStatementFlag
            // 
            this.ColumnStatementFlag.DataPropertyName = "StatementFlag";
            this.ColumnStatementFlag.HeaderText = "Statement Flag";
            this.ColumnStatementFlag.Name = "ColumnStatementFlag";
            this.ColumnStatementFlag.ReadOnly = true;
            // 
            // ColumnPostDate
            // 
            this.ColumnPostDate.DataPropertyName = "PostDate";
            this.ColumnPostDate.HeaderText = "Post Date";
            this.ColumnPostDate.Name = "ColumnPostDate";
            this.ColumnPostDate.ReadOnly = true;
            // 
            // ColumnValueDate
            // 
            this.ColumnValueDate.DataPropertyName = "ValueDate";
            this.ColumnValueDate.HeaderText = "Value Date";
            this.ColumnValueDate.Name = "ColumnValueDate";
            this.ColumnValueDate.ReadOnly = true;
            // 
            // ColumnRecordDate
            // 
            this.ColumnRecordDate.DataPropertyName = "RecordDate";
            this.ColumnRecordDate.HeaderText = "Record Date";
            this.ColumnRecordDate.Name = "ColumnRecordDate";
            this.ColumnRecordDate.ReadOnly = true;
            // 
            // btnDoubleEntryPosting
            // 
            this.btnDoubleEntryPosting.AutoSize = true;
            this.btnDoubleEntryPosting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoubleEntryPosting.LinkColor = System.Drawing.Color.Yellow;
            this.btnDoubleEntryPosting.Location = new System.Drawing.Point(326, 552);
            this.btnDoubleEntryPosting.Name = "btnDoubleEntryPosting";
            this.btnDoubleEntryPosting.Size = new System.Drawing.Size(212, 24);
            this.btnDoubleEntryPosting.TabIndex = 1;
            this.btnDoubleEntryPosting.TabStop = true;
            this.btnDoubleEntryPosting.Text = "Double  Entry Posting";
            this.btnDoubleEntryPosting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDoubleEntryPosting_LinkClicked);
            // 
            // btnMuiltiEntryPosting
            // 
            this.btnMuiltiEntryPosting.AutoSize = true;
            this.btnMuiltiEntryPosting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMuiltiEntryPosting.LinkColor = System.Drawing.Color.Yellow;
            this.btnMuiltiEntryPosting.Location = new System.Drawing.Point(544, 552);
            this.btnMuiltiEntryPosting.Name = "btnMuiltiEntryPosting";
            this.btnMuiltiEntryPosting.Size = new System.Drawing.Size(183, 24);
            this.btnMuiltiEntryPosting.TabIndex = 2;
            this.btnMuiltiEntryPosting.TabStop = true;
            this.btnMuiltiEntryPosting.Text = "Multi Entry Posting";
            this.btnMuiltiEntryPosting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnMuiltiEntryPosting_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(733, 552);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnSingleEntryPosting
            // 
            this.btnSingleEntryPosting.AutoSize = true;
            this.btnSingleEntryPosting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSingleEntryPosting.LinkColor = System.Drawing.Color.Yellow;
            this.btnSingleEntryPosting.Location = new System.Drawing.Point(122, 552);
            this.btnSingleEntryPosting.Name = "btnSingleEntryPosting";
            this.btnSingleEntryPosting.Size = new System.Drawing.Size(198, 24);
            this.btnSingleEntryPosting.TabIndex = 4;
            this.btnSingleEntryPosting.TabStop = true;
            this.btnSingleEntryPosting.Text = "Single Entry Posting";
            this.btnSingleEntryPosting.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSingleEntryPosting_LinkClicked);
            // 
            // TransactionsForm
            // 
            this.AcceptButton = this.btnMuiltiEntryPosting;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(810, 373);
            this.Controls.Add(this.btnSingleEntryPosting);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnMuiltiEntryPosting);
            this.Controls.Add(this.btnDoubleEntryPosting);
            this.Controls.Add(this.dataGridViewTransactions);
            this.Name = "TransactionsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.TransactionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTransactions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceTransactions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTransactions;
        private System.Windows.Forms.LinkLabel btnDoubleEntryPosting;
        private System.Windows.Forms.LinkLabel btnMuiltiEntryPosting;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnSingleEntryPosting;
        private System.Windows.Forms.BindingSource bindingSourceTransactions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTransactionTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAccountID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNarrative;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAuthorizer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatementFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPostDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRecordDate;
    }
}