namespace WinSBSchool.Reports.Views.Screen
{
    partial class ViewTransactionDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTransactionDetailsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnNext = new System.Windows.Forms.LinkLabel();
            this.btnPrevious = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblAccountDetails = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboAccount = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpPostDate = new System.Windows.Forms.DateTimePicker();
            this.dtpRecordDate = new System.Windows.Forms.DateTimePicker();
            this.dtpValueDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboStatementFlag = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtTransRef = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNarrative = new System.Windows.Forms.TextBox();
            this.txtId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPrevious);
            this.groupBox1.Controls.Add(this.btnNext);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 530);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtId);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtTransRef);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtUserName);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cboStatementFlag);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtNarrative);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.dtpValueDate);
            this.groupBox2.Controls.Add(this.dtpRecordDate);
            this.groupBox2.Controls.Add(this.dtpPostDate);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboAccount);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboTransactionType);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lblAccountDetails);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(550, 530);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(370, 21);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 22);
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = true;
            this.btnNext.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.LinkColor = System.Drawing.Color.Yellow;
            this.btnNext.Location = new System.Drawing.Point(290, 21);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(48, 22);
            this.btnNext.TabIndex = 5;
            this.btnNext.TabStop = true;
            this.btnNext.Text = "Next";
            this.btnNext.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnNext_LinkClicked);
            // 
            // btnPrevious
            // 
            this.btnPrevious.AutoSize = true;
            this.btnPrevious.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.LinkColor = System.Drawing.Color.Yellow;
            this.btnPrevious.Location = new System.Drawing.Point(177, 21);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(81, 22);
            this.btnPrevious.TabIndex = 6;
            this.btnPrevious.TabStop = true;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPrevious_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Amount";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(164, 193);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(318, 20);
            this.txtAmount.TabIndex = 1;
            // 
            // lblAccountDetails
            // 
            this.lblAccountDetails.AutoSize = true;
            this.lblAccountDetails.Location = new System.Drawing.Point(164, 126);
            this.lblAccountDetails.Name = "lblAccountDetails";
            this.lblAccountDetails.Size = new System.Drawing.Size(82, 13);
            this.lblAccountDetails.TabIndex = 2;
            this.lblAccountDetails.Text = "Account Details";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Transaction Type";
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(164, 53);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(318, 21);
            this.cboTransactionType.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Account";
            // 
            // cboAccount
            // 
            this.cboAccount.FormattingEnabled = true;
            this.cboAccount.Location = new System.Drawing.Point(164, 89);
            this.cboAccount.Name = "cboAccount";
            this.cboAccount.Size = new System.Drawing.Size(318, 21);
            this.cboAccount.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Post Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(88, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Record Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(96, 343);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Value Date";
            // 
            // dtpPostDate
            // 
            this.dtpPostDate.Location = new System.Drawing.Point(164, 234);
            this.dtpPostDate.Name = "dtpPostDate";
            this.dtpPostDate.Size = new System.Drawing.Size(318, 20);
            this.dtpPostDate.TabIndex = 10;
            // 
            // dtpRecordDate
            // 
            this.dtpRecordDate.Location = new System.Drawing.Point(164, 286);
            this.dtpRecordDate.Name = "dtpRecordDate";
            this.dtpRecordDate.Size = new System.Drawing.Size(318, 20);
            this.dtpRecordDate.TabIndex = 11;
            // 
            // dtpValueDate
            // 
            this.dtpValueDate.Location = new System.Drawing.Point(164, 337);
            this.dtpValueDate.Name = "dtpValueDate";
            this.dtpValueDate.Size = new System.Drawing.Size(318, 20);
            this.dtpValueDate.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(104, 382);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Narrative";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(78, 441);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Statement Flag";
            // 
            // cboStatementFlag
            // 
            this.cboStatementFlag.FormattingEnabled = true;
            this.cboStatementFlag.Location = new System.Drawing.Point(164, 438);
            this.cboStatementFlag.Name = "cboStatementFlag";
            this.cboStatementFlag.Size = new System.Drawing.Size(318, 21);
            this.cboStatementFlag.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(94, 484);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "User Name";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(164, 481);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(318, 20);
            this.txtUserName.TabIndex = 18;
            // 
            // txtTransRef
            // 
            this.txtTransRef.Location = new System.Drawing.Point(164, 154);
            this.txtTransRef.Name = "txtTransRef";
            this.txtTransRef.Size = new System.Drawing.Size(318, 20);
            this.txtTransRef.TabIndex = 20;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Transaction Reference";
            // 
            // txtNarrative
            // 
            this.txtNarrative.Location = new System.Drawing.Point(164, 379);
            this.txtNarrative.Multiline = true;
            this.txtNarrative.Name = "txtNarrative";
            this.txtNarrative.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNarrative.Size = new System.Drawing.Size(318, 38);
            this.txtNarrative.TabIndex = 14;
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(164, 20);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(318, 20);
            this.txtId.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(138, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Id";
            // 
            // ViewTransactionDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(550, 587);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewTransactionDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transaction Details";
            this.Load += new System.EventHandler(this.ViewTransactionDetailsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnPrevious;
        private System.Windows.Forms.LinkLabel btnNext;
        private System.Windows.Forms.Label lblAccountDetails;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTransRef;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboStatementFlag;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpValueDate;
        private System.Windows.Forms.DateTimePicker dtpRecordDate;
        private System.Windows.Forms.DateTimePicker dtpPostDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNarrative;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label2;
    }
}