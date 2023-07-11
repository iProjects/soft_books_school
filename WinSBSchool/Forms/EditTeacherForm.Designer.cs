namespace WinSBSchool.Forms
{
    partial class EditTeacherForm
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label tSCNoLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label iDNoLabel;
            System.Windows.Forms.Label positionLabel;
            System.Windows.Forms.Label label5;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTeacherForm));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboQualification = new System.Windows.Forms.ComboBox();
            this.groupBoxLeft = new System.Windows.Forms.GroupBox();
            this.dtpDateLeft = new System.Windows.Forms.DateTimePicker();
            this.chkLeft = new System.Windows.Forms.CheckBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.dtpDateJoined = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtTSCNo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtIDNo = new System.Windows.Forms.TextBox();
            this.txtPosition = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.LinkLabel();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            tSCNoLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            iDNoLabel = new System.Windows.Forms.Label();
            positionLabel = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBoxLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(58, 25);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(51, 13);
            label4.TabIndex = 62;
            label4.Text = "Date Left";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(84, 150);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(32, 13);
            label3.TabIndex = 61;
            label3.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(52, 216);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(64, 13);
            label2.TabIndex = 60;
            label2.Text = "Date Joined";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(78, 183);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(37, 13);
            label1.TabIndex = 59;
            label1.Text = "Status";
            // 
            // tSCNoLabel
            // 
            tSCNoLabel.AutoSize = true;
            tSCNoLabel.Location = new System.Drawing.Point(74, 86);
            tSCNoLabel.Name = "tSCNoLabel";
            tSCNoLabel.Size = new System.Drawing.Size(42, 13);
            tSCNoLabel.TabIndex = 55;
            tSCNoLabel.Text = "TSCNo";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(77, 22);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(39, 13);
            nameLabel.TabIndex = 56;
            nameLabel.Text = "Name*";
            // 
            // iDNoLabel
            // 
            iDNoLabel.AutoSize = true;
            iDNoLabel.Location = new System.Drawing.Point(80, 54);
            iDNoLabel.Name = "iDNoLabel";
            iDNoLabel.Size = new System.Drawing.Size(36, 13);
            iDNoLabel.TabIndex = 57;
            iDNoLabel.Text = "IDNo*";
            // 
            // positionLabel
            // 
            positionLabel.AutoSize = true;
            positionLabel.Location = new System.Drawing.Point(72, 118);
            positionLabel.Name = "positionLabel";
            positionLabel.Size = new System.Drawing.Size(44, 13);
            positionLabel.TabIndex = 58;
            positionLabel.Text = "Position";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(11, 247);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(104, 13);
            label5.TabIndex = 65;
            label5.Text = "Highest Qualification";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboQualification);
            this.groupBox2.Controls.Add(label5);
            this.groupBox2.Controls.Add(this.groupBoxLeft);
            this.groupBox2.Controls.Add(this.chkLeft);
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(this.dtpDateJoined);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(label3);
            this.groupBox2.Controls.Add(label2);
            this.groupBox2.Controls.Add(label1);
            this.groupBox2.Controls.Add(tSCNoLabel);
            this.groupBox2.Controls.Add(this.txtTSCNo);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtIDNo);
            this.groupBox2.Controls.Add(this.txtPosition);
            this.groupBox2.Controls.Add(nameLabel);
            this.groupBox2.Controls.Add(iDNoLabel);
            this.groupBox2.Controls.Add(positionLabel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 350);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // cboQualification
            // 
            this.cboQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQualification.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboQualification.FormattingEnabled = true;
            this.cboQualification.Location = new System.Drawing.Point(118, 244);
            this.cboQualification.Name = "cboQualification";
            this.cboQualification.Size = new System.Drawing.Size(224, 21);
            this.cboQualification.TabIndex = 7;
            // 
            // groupBoxLeft
            // 
            this.groupBoxLeft.Controls.Add(this.dtpDateLeft);
            this.groupBoxLeft.Controls.Add(label4);
            this.groupBoxLeft.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBoxLeft.Location = new System.Drawing.Point(3, 295);
            this.groupBoxLeft.Name = "groupBoxLeft";
            this.groupBoxLeft.Size = new System.Drawing.Size(389, 52);
            this.groupBoxLeft.TabIndex = 9;
            this.groupBoxLeft.TabStop = false;
            // 
            // dtpDateLeft
            // 
            this.dtpDateLeft.Location = new System.Drawing.Point(115, 19);
            this.dtpDateLeft.Name = "dtpDateLeft";
            this.dtpDateLeft.ShowCheckBox = true;
            this.dtpDateLeft.Size = new System.Drawing.Size(224, 20);
            this.dtpDateLeft.TabIndex = 0;
            // 
            // chkLeft
            // 
            this.chkLeft.AutoSize = true;
            this.chkLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkLeft.Location = new System.Drawing.Point(118, 277);
            this.chkLeft.Name = "chkLeft";
            this.chkLeft.Size = new System.Drawing.Size(50, 17);
            this.chkLeft.TabIndex = 8;
            this.chkLeft.Text = "Left ?";
            this.chkLeft.UseVisualStyleBackColor = true;
            this.chkLeft.CheckedChanged += new System.EventHandler(this.chkLeft_CheckedChanged);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(118, 179);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(224, 21);
            this.cboStatus.TabIndex = 5;
            // 
            // dtpDateJoined
            // 
            this.dtpDateJoined.Location = new System.Drawing.Point(118, 212);
            this.dtpDateJoined.Name = "dtpDateJoined";
            this.dtpDateJoined.Size = new System.Drawing.Size(224, 20);
            this.dtpDateJoined.TabIndex = 6;
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEmail.Location = new System.Drawing.Point(118, 146);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(224, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtTSCNo
            // 
            this.txtTSCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTSCNo.Location = new System.Drawing.Point(118, 83);
            this.txtTSCNo.MaxLength = 50;
            this.txtTSCNo.Name = "txtTSCNo";
            this.txtTSCNo.Size = new System.Drawing.Size(224, 20);
            this.txtTSCNo.TabIndex = 2;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(118, 19);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(224, 20);
            this.txtName.TabIndex = 0;
            // 
            // txtIDNo
            // 
            this.txtIDNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIDNo.Location = new System.Drawing.Point(118, 50);
            this.txtIDNo.MaxLength = 50;
            this.txtIDNo.Name = "txtIDNo";
            this.txtIDNo.Size = new System.Drawing.Size(224, 20);
            this.txtIDNo.TabIndex = 1;
            this.txtIDNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtIDNo_KeyDown);
            this.txtIDNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIDNo_KeyPress);
            // 
            // txtPosition
            // 
            this.txtPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPosition.Location = new System.Drawing.Point(118, 115);
            this.txtPosition.MaxLength = 50;
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Size = new System.Drawing.Size(224, 20);
            this.txtPosition.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(248, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 39);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.AutoSize = true;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.LinkColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(118, 10);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(61, 18);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.TabStop = true;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnUpdate_LinkClicked);
            // 
            // EditTeacherForm
            // 
            this.AcceptButton = this.btnUpdate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(395, 389);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditTeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditTeacherForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxLeft.ResumeLayout(false);
            this.groupBoxLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.DateTimePicker dtpDateLeft;
        private System.Windows.Forms.DateTimePicker dtpDateJoined;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtTSCNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtIDNo;
        private System.Windows.Forms.TextBox txtPosition;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnUpdate;
        private System.Windows.Forms.CheckBox chkLeft;
        private System.Windows.Forms.GroupBox groupBoxLeft;
        private System.Windows.Forms.ComboBox cboQualification;

    }
}