namespace WinSBSchool.Forms
{
    partial class AddSubjectForm
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label indexLabel;
            System.Windows.Forms.Label schoolNameLabel;
            System.Windows.Forms.Label telephoneLabel;
            System.Windows.Forms.Label cellphoneLabel;
            System.Windows.Forms.Label emailLabel;
            System.Windows.Forms.Label address1Label;
            System.Windows.Forms.Label address2Label;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSubjectForm));
            this.txtFees = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNoofRequiredHours = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.txtShortCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtOutOf = new System.Windows.Forms.TextBox();
            this.txtPassMark = new System.Windows.Forms.TextBox();
            this.txtROrder = new System.Windows.Forms.TextBox();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            indexLabel = new System.Windows.Forms.Label();
            schoolNameLabel = new System.Windows.Forms.Label();
            telephoneLabel = new System.Windows.Forms.Label();
            cellphoneLabel = new System.Windows.Forms.Label();
            emailLabel = new System.Windows.Forms.Label();
            address1Label = new System.Windows.Forms.Label();
            address2Label = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(107, 213);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(30, 13);
            label2.TabIndex = 87;
            label2.Text = "Fees";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(27, 186);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(110, 13);
            label1.TabIndex = 85;
            label1.Text = "No of Required Hours";
            // 
            // indexLabel
            // 
            indexLabel.AutoSize = true;
            indexLabel.Location = new System.Drawing.Point(73, 22);
            indexLabel.Name = "indexLabel";
            indexLabel.Size = new System.Drawing.Size(64, 13);
            indexLabel.TabIndex = 77;
            indexLabel.Text = "Short Code*";
            // 
            // schoolNameLabel
            // 
            schoolNameLabel.AutoSize = true;
            schoolNameLabel.Location = new System.Drawing.Point(73, 49);
            schoolNameLabel.Name = "schoolNameLabel";
            schoolNameLabel.Size = new System.Drawing.Size(64, 13);
            schoolNameLabel.TabIndex = 78;
            schoolNameLabel.Text = "Description*";
            // 
            // telephoneLabel
            // 
            telephoneLabel.AutoSize = true;
            telephoneLabel.Location = new System.Drawing.Point(99, 76);
            telephoneLabel.Name = "telephoneLabel";
            telephoneLabel.Size = new System.Drawing.Size(38, 13);
            telephoneLabel.TabIndex = 79;
            telephoneLabel.Text = "Out Of";
            // 
            // cellphoneLabel
            // 
            cellphoneLabel.AutoSize = true;
            cellphoneLabel.Location = new System.Drawing.Point(80, 103);
            cellphoneLabel.Name = "cellphoneLabel";
            cellphoneLabel.Size = new System.Drawing.Size(57, 13);
            cellphoneLabel.TabIndex = 80;
            cellphoneLabel.Text = "Pass Mark";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new System.Drawing.Point(99, 240);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new System.Drawing.Size(37, 13);
            emailLabel.TabIndex = 81;
            emailLabel.Text = "Status";
            // 
            // address1Label
            // 
            address1Label.AutoSize = true;
            address1Label.Location = new System.Drawing.Point(93, 130);
            address1Label.Name = "address1Label";
            address1Label.Size = new System.Drawing.Size(44, 13);
            address1Label.TabIndex = 82;
            address1Label.Text = "R Order";
            // 
            // address2Label
            // 
            address2Label.AutoSize = true;
            address2Label.Location = new System.Drawing.Point(88, 159);
            address2Label.Name = "address2Label";
            address2Label.Size = new System.Drawing.Size(49, 13);
            address2Label.TabIndex = 83;
            address2Label.Text = "Remarks";
            // 
            // txtFees
            // 
            this.txtFees.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFees.Location = new System.Drawing.Point(139, 210);
            this.txtFees.MaxLength = 8;
            this.txtFees.Name = "txtFees";
            this.txtFees.Size = new System.Drawing.Size(290, 20);
            this.txtFees.TabIndex = 9;
            this.txtFees.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFees_KeyDown);
            this.txtFees.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFees_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFees);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Controls.Add(this.txtNoofRequiredHours);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(indexLabel);
            this.groupBox2.Controls.Add(this.txtShortCode);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.txtOutOf);
            this.groupBox2.Controls.Add(this.txtPassMark);
            this.groupBox2.Controls.Add(this.txtROrder);
            this.groupBox2.Controls.Add(this.txtRemarks);
            this.groupBox2.Controls.Add(schoolNameLabel);
            this.groupBox2.Controls.Add(telephoneLabel);
            this.groupBox2.Controls.Add(cellphoneLabel);
            this.groupBox2.Controls.Add(emailLabel);
            this.groupBox2.Controls.Add(address1Label);
            this.groupBox2.Controls.Add(address2Label);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(496, 270);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // txtNoofRequiredHours
            // 
            this.txtNoofRequiredHours.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNoofRequiredHours.Location = new System.Drawing.Point(139, 183);
            this.txtNoofRequiredHours.MaxLength = 4;
            this.txtNoofRequiredHours.Name = "txtNoofRequiredHours";
            this.txtNoofRequiredHours.Size = new System.Drawing.Size(290, 20);
            this.txtNoofRequiredHours.TabIndex = 8;
            this.txtNoofRequiredHours.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoofRequiredHours_KeyDown);
            this.txtNoofRequiredHours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNoofRequiredHours_KeyPress);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(139, 237);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(290, 21);
            this.cboStatus.TabIndex = 10;
            // 
            // txtShortCode
            // 
            this.txtShortCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtShortCode.Location = new System.Drawing.Point(139, 19);
            this.txtShortCode.MaxLength = 10;
            this.txtShortCode.Name = "txtShortCode";
            this.txtShortCode.Size = new System.Drawing.Size(290, 20);
            this.txtShortCode.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Location = new System.Drawing.Point(139, 46);
            this.txtDescription.MaxLength = 50;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(290, 20);
            this.txtDescription.TabIndex = 1;
            // 
            // txtOutOf
            // 
            this.txtOutOf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutOf.Location = new System.Drawing.Point(139, 73);
            this.txtOutOf.MaxLength = 4;
            this.txtOutOf.Name = "txtOutOf";
            this.txtOutOf.Size = new System.Drawing.Size(290, 20);
            this.txtOutOf.TabIndex = 2;
            this.txtOutOf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOutOf_KeyDown);
            this.txtOutOf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutOf_KeyPress);
            // 
            // txtPassMark
            // 
            this.txtPassMark.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassMark.Location = new System.Drawing.Point(139, 100);
            this.txtPassMark.MaxLength = 4;
            this.txtPassMark.Name = "txtPassMark";
            this.txtPassMark.Size = new System.Drawing.Size(290, 20);
            this.txtPassMark.TabIndex = 3;
            this.txtPassMark.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassMark_KeyDown);
            this.txtPassMark.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassMark_KeyPress);
            // 
            // txtROrder
            // 
            this.txtROrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtROrder.Location = new System.Drawing.Point(139, 127);
            this.txtROrder.MaxLength = 4;
            this.txtROrder.Name = "txtROrder";
            this.txtROrder.Size = new System.Drawing.Size(290, 20);
            this.txtROrder.TabIndex = 4;
            this.txtROrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtROrder_KeyDown);
            this.txtROrder.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtROrder_KeyPress);
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(139, 156);
            this.txtRemarks.MaxLength = 250;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(290, 20);
            this.txtRemarks.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 270);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 33);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(268, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(191, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // AddSubjectForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(496, 303);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddSubjectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Subject";
            this.Load += new System.EventHandler(this.AddSubjectForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFees;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNoofRequiredHours;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtShortCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtOutOf;
        private System.Windows.Forms.TextBox txtPassMark;
        private System.Windows.Forms.TextBox txtROrder;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider1;

    }
}