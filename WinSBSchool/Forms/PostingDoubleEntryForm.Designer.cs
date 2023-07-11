namespace WinSBSchool.Forms
{
    partial class PostingDoubleEntryForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dpPostDate = new System.Windows.Forms.DateTimePicker();
            this.dpValueDate = new System.Windows.Forms.DateTimePicker();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.txtCrNarrative = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPost = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDrNarrative = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCAccountId = new System.Windows.Forms.TextBox();
            this.btnSearchCAccount = new System.Windows.Forms.Button();
            this.txtDAccountId = new System.Windows.Forms.TextBox();
            this.btnSearchDAccount = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(76, 253);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Post Date*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Value Date";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Transaction Type*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Debit Account Id*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Credit Narrative*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 142);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Amount*";
            // 
            // dpPostDate
            // 
            this.dpPostDate.Location = new System.Drawing.Point(139, 251);
            this.dpPostDate.Name = "dpPostDate";
            this.dpPostDate.Size = new System.Drawing.Size(304, 20);
            this.dpPostDate.TabIndex = 6;
            // 
            // dpValueDate
            // 
            this.dpValueDate.Location = new System.Drawing.Point(139, 288);
            this.dpValueDate.Name = "dpValueDate";
            this.dpValueDate.Size = new System.Drawing.Size(304, 20);
            this.dpValueDate.TabIndex = 7;
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(139, 28);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(304, 21);
            this.cboTransactionType.TabIndex = 0;
            // 
            // txtCrNarrative
            // 
            this.txtCrNarrative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrNarrative.Location = new System.Drawing.Point(139, 214);
            this.txtCrNarrative.MaxLength = 100;
            this.txtCrNarrative.Name = "txtCrNarrative";
            this.txtCrNarrative.Size = new System.Drawing.Size(304, 20);
            this.txtCrNarrative.TabIndex = 5;
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(139, 140);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(304, 20);
            this.txtAmount.TabIndex = 3;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnPost
            // 
            this.btnPost.AutoSize = true;
            this.btnPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.LinkColor = System.Drawing.Color.Yellow;
            this.btnPost.Location = new System.Drawing.Point(183, 16);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(59, 25);
            this.btnPost.TabIndex = 0;
            this.btnPost.TabStop = true;
            this.btnPost.Text = "Post";
            this.btnPost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPost_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(313, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(41, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Credit Account Id*";
            // 
            // txtDrNarrative
            // 
            this.txtDrNarrative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDrNarrative.Location = new System.Drawing.Point(139, 177);
            this.txtDrNarrative.MaxLength = 100;
            this.txtDrNarrative.Name = "txtDrNarrative";
            this.txtDrNarrative.Size = new System.Drawing.Size(304, 20);
            this.txtDrNarrative.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 179);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Debit Narrative*";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPost);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 336);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 49);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDAccountId);
            this.groupBox2.Controls.Add(this.btnSearchDAccount);
            this.groupBox2.Controls.Add(this.txtCAccountId);
            this.groupBox2.Controls.Add(this.btnSearchCAccount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDrNarrative);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dpPostDate);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.dpValueDate);
            this.groupBox2.Controls.Add(this.txtCrNarrative);
            this.groupBox2.Controls.Add(this.cboTransactionType);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(510, 336);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtCAccountId
            // 
            this.txtCAccountId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCAccountId.Location = new System.Drawing.Point(139, 66);
            this.txtCAccountId.MaxLength = 4;
            this.txtCAccountId.Name = "txtCAccountId";
            this.txtCAccountId.Size = new System.Drawing.Size(190, 20);
            this.txtCAccountId.TabIndex = 36;
            // 
            // btnSearchCAccount
            // 
            this.btnSearchCAccount.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchCAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCAccount.Location = new System.Drawing.Point(359, 60);
            this.btnSearchCAccount.Name = "btnSearchCAccount";
            this.btnSearchCAccount.Size = new System.Drawing.Size(36, 23);
            this.btnSearchCAccount.TabIndex = 37;
            this.btnSearchCAccount.Text = ":::";
            this.btnSearchCAccount.UseVisualStyleBackColor = false;
            this.btnSearchCAccount.Click += new System.EventHandler(this.btnSearchCAccount_Click);
            // 
            // txtDAccountId
            // 
            this.txtDAccountId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDAccountId.Location = new System.Drawing.Point(141, 103);
            this.txtDAccountId.MaxLength = 4;
            this.txtDAccountId.Name = "txtDAccountId";
            this.txtDAccountId.Size = new System.Drawing.Size(190, 20);
            this.txtDAccountId.TabIndex = 38;
            // 
            // btnSearchDAccount
            // 
            this.btnSearchDAccount.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchDAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchDAccount.Location = new System.Drawing.Point(359, 104);
            this.btnSearchDAccount.Name = "btnSearchDAccount";
            this.btnSearchDAccount.Size = new System.Drawing.Size(36, 23);
            this.btnSearchDAccount.TabIndex = 39;
            this.btnSearchDAccount.Text = ":::";
            this.btnSearchDAccount.UseVisualStyleBackColor = false;
            this.btnSearchDAccount.Click += new System.EventHandler(this.btnSearchbyDAccount_Click);
            // 
            // PostingDoubleEntryForm
            // 
            this.AcceptButton = this.btnPost;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(510, 385);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "PostingDoubleEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Double Entry";
            this.Load += new System.EventHandler(this.PostingDoubleEntryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dpPostDate;
        private System.Windows.Forms.DateTimePicker dpValueDate;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.TextBox txtCrNarrative;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnPost;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDrNarrative;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDAccountId;
        private System.Windows.Forms.Button btnSearchDAccount;
        private System.Windows.Forms.TextBox txtCAccountId;
        private System.Windows.Forms.Button btnSearchCAccount;
    }
}