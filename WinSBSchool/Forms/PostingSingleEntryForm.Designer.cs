namespace WinSBSchool.Forms
{
    partial class PostingSingleEntryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostingSingleEntryForm));
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.txtNarrative = new System.Windows.Forms.TextBox();
            this.cboTransactionType = new System.Windows.Forms.ComboBox();
            this.dpValueDate = new System.Windows.Forms.DateTimePicker();
            this.dpPostDate = new System.Windows.Forms.DateTimePicker();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnPost = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtAccountId = new System.Windows.Forms.TextBox();
            this.btnSearchAccount = new System.Windows.Forms.Button();
            this.lblaccountdetails = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAmount
            // 
            this.txtAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAmount.Location = new System.Drawing.Point(131, 135);
            this.txtAmount.MaxLength = 8;
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(330, 20);
            this.txtAmount.TabIndex = 2;
            // 
            // txtNarrative
            // 
            this.txtNarrative.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNarrative.Location = new System.Drawing.Point(131, 173);
            this.txtNarrative.MaxLength = 100;
            this.txtNarrative.Name = "txtNarrative";
            this.txtNarrative.Size = new System.Drawing.Size(330, 20);
            this.txtNarrative.TabIndex = 3;
            // 
            // cboTransactionType
            // 
            this.cboTransactionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTransactionType.FormattingEnabled = true;
            this.cboTransactionType.Location = new System.Drawing.Point(131, 31);
            this.cboTransactionType.Name = "cboTransactionType";
            this.cboTransactionType.Size = new System.Drawing.Size(330, 21);
            this.cboTransactionType.TabIndex = 0;
            // 
            // dpValueDate
            // 
            this.dpValueDate.Location = new System.Drawing.Point(131, 249);
            this.dpValueDate.Name = "dpValueDate";
            this.dpValueDate.Size = new System.Drawing.Size(330, 20);
            this.dpValueDate.TabIndex = 5;
            // 
            // dpPostDate
            // 
            this.dpPostDate.Location = new System.Drawing.Point(131, 211);
            this.dpPostDate.Name = "dpPostDate";
            this.dpPostDate.Size = new System.Drawing.Size(330, 20);
            this.dpPostDate.TabIndex = 4;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Amount*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Narrative*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "AccountId*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Transaction Type*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Value Date";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Post Date*";
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(290, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(63, 24);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnPost
            // 
            this.btnPost.AutoSize = true;
            this.btnPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.LinkColor = System.Drawing.Color.Yellow;
            this.btnPost.Location = new System.Drawing.Point(218, 17);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(50, 24);
            this.btnPost.TabIndex = 0;
            this.btnPost.TabStop = true;
            this.btnPost.Text = "Post";
            this.btnPost.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPost_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnPost);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 301);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 51);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblaccountdetails);
            this.groupBox2.Controls.Add(this.txtAccountId);
            this.groupBox2.Controls.Add(this.btnSearchAccount);
            this.groupBox2.Controls.Add(this.dpValueDate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtAmount);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtNarrative);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboTransactionType);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.dpPostDate);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(515, 301);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtAccountId
            // 
            this.txtAccountId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAccountId.Location = new System.Drawing.Point(131, 72);
            this.txtAccountId.MaxLength = 4;
            this.txtAccountId.Name = "txtAccountId";
            this.txtAccountId.Size = new System.Drawing.Size(251, 20);
            this.txtAccountId.TabIndex = 24;
            this.txtAccountId.TextChanged += new System.EventHandler(this.txtAccountId_TextChanged);
            // 
            // btnSearchAccount
            // 
            this.btnSearchAccount.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSearchAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAccount.Location = new System.Drawing.Point(425, 69);
            this.btnSearchAccount.Name = "btnSearchAccount";
            this.btnSearchAccount.Size = new System.Drawing.Size(36, 23);
            this.btnSearchAccount.TabIndex = 25;
            this.btnSearchAccount.Text = ":::";
            this.btnSearchAccount.UseVisualStyleBackColor = false;
            this.btnSearchAccount.Click += new System.EventHandler(this.btnSearchbyAccount_Click);
            // 
            // lblaccountdetails
            // 
            this.lblaccountdetails.AutoSize = true;
            this.lblaccountdetails.Location = new System.Drawing.Point(130, 106);
            this.lblaccountdetails.Name = "lblaccountdetails";
            this.lblaccountdetails.Size = new System.Drawing.Size(82, 13);
            this.lblaccountdetails.TabIndex = 26;
            this.lblaccountdetails.Text = "Account Details";
            // 
            // PostingSingleEntryForm
            // 
            this.AcceptButton = this.btnPost;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(515, 352);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PostingSingleEntryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Single Entry";
            this.Load += new System.EventHandler(this.PostingSingleEntryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.TextBox txtNarrative;
        private System.Windows.Forms.ComboBox cboTransactionType;
        private System.Windows.Forms.DateTimePicker dpValueDate;
        private System.Windows.Forms.DateTimePicker dpPostDate;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnPost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAccountId;
        private System.Windows.Forms.Button btnSearchAccount;
        private System.Windows.Forms.Label lblaccountdetails;
    }
}