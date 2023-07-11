namespace WinSBSchool.Forms
{
    partial class RegisterSingleExamForm
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
            System.Windows.Forms.Label label6;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterSingleExamForm));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModifiedBy = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtOutOf = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.chkContribution = new System.Windows.Forms.CheckBox();
            this.groupBoxContribution = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContr = new System.Windows.Forms.TextBox();
            this.cbExamType = new System.Windows.Forms.ComboBox();
            this.cboRooms = new System.Windows.Forms.ComboBox();
            this.dtpExamDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.bindingSourceExamType = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cboinvigilator = new System.Windows.Forms.ComboBox();
            label6 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxContribution.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExamType)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(47, 156);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(41, 13);
            label6.TabIndex = 149;
            label6.Text = "Status*";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(118, 10);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(234, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOk);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 39);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboinvigilator);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtModifiedBy);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txtOutOf);
            this.groupBox2.Controls.Add(this.cboStatus);
            this.groupBox2.Controls.Add(label6);
            this.groupBox2.Controls.Add(this.chkContribution);
            this.groupBox2.Controls.Add(this.groupBoxContribution);
            this.groupBox2.Controls.Add(this.cbExamType);
            this.groupBox2.Controls.Add(this.cboRooms);
            this.groupBox2.Controls.Add(this.dtpExamDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(401, 337);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Validating += new System.ComponentModel.CancelEventHandler(this.groupBox2_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 153;
            this.label8.Text = "Modified By";
            // 
            // txtModifiedBy
            // 
            this.txtModifiedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModifiedBy.Location = new System.Drawing.Point(91, 218);
            this.txtModifiedBy.MaxLength = 50;
            this.txtModifiedBy.Name = "txtModifiedBy";
            this.txtModifiedBy.Size = new System.Drawing.Size(243, 20);
            this.txtModifiedBy.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(51, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 151;
            this.label7.Text = "Out Of";
            // 
            // txtOutOf
            // 
            this.txtOutOf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutOf.Location = new System.Drawing.Point(91, 187);
            this.txtOutOf.MaxLength = 4;
            this.txtOutOf.Name = "txtOutOf";
            this.txtOutOf.Size = new System.Drawing.Size(243, 20);
            this.txtOutOf.TabIndex = 5;
            this.txtOutOf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOutOf_KeyDown);
            this.txtOutOf.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutOf_KeyPress);
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(91, 153);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(243, 21);
            this.cboStatus.TabIndex = 4;
            // 
            // chkContribution
            // 
            this.chkContribution.AutoSize = true;
            this.chkContribution.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkContribution.Location = new System.Drawing.Point(91, 244);
            this.chkContribution.Name = "chkContribution";
            this.chkContribution.Size = new System.Drawing.Size(149, 17);
            this.chkContribution.TabIndex = 7;
            this.chkContribution.Text = "Contributes to Main Exam?";
            this.chkContribution.UseVisualStyleBackColor = true;
            this.chkContribution.CheckedChanged += new System.EventHandler(this.chkContribution_CheckedChanged);
            // 
            // groupBoxContribution
            // 
            this.groupBoxContribution.Controls.Add(this.label5);
            this.groupBoxContribution.Controls.Add(this.txtContr);
            this.groupBoxContribution.Location = new System.Drawing.Point(91, 267);
            this.groupBoxContribution.Name = "groupBoxContribution";
            this.groupBoxContribution.Size = new System.Drawing.Size(248, 53);
            this.groupBoxContribution.TabIndex = 8;
            this.groupBoxContribution.TabStop = false;
            this.groupBoxContribution.Text = "Contribution %";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(173, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "e.g 50% = 0.5";
            // 
            // txtContr
            // 
            this.txtContr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContr.Location = new System.Drawing.Point(6, 22);
            this.txtContr.MaxLength = 4;
            this.txtContr.Name = "txtContr";
            this.txtContr.Size = new System.Drawing.Size(143, 20);
            this.txtContr.TabIndex = 0;
            this.toolTip1.SetToolTip(this.txtContr, "Exam Contribution percentage.\r\ne.g if 70% type as 0.7\r\n          90% type as 0.9\r" +
        "\n          69% type as 0.69");
            this.txtContr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtContr_KeyDown);
            this.txtContr.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContr_KeyPress);
            // 
            // cbExamType
            // 
            this.cbExamType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExamType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbExamType.FormattingEnabled = true;
            this.cbExamType.Location = new System.Drawing.Point(91, 19);
            this.cbExamType.Name = "cbExamType";
            this.cbExamType.Size = new System.Drawing.Size(243, 21);
            this.cbExamType.TabIndex = 0;
            this.toolTip1.SetToolTip(this.cbExamType, "Select the Exam Type.");
            this.cbExamType.SelectedIndexChanged += new System.EventHandler(this.cbExamType_SelectedIndexChanged);
            // 
            // cboRooms
            // 
            this.cboRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRooms.FormattingEnabled = true;
            this.cboRooms.Location = new System.Drawing.Point(91, 53);
            this.cboRooms.Name = "cboRooms";
            this.cboRooms.Size = new System.Drawing.Size(243, 21);
            this.cboRooms.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cboRooms, "Select the Room.");
            // 
            // dtpExamDate
            // 
            this.dtpExamDate.Location = new System.Drawing.Point(91, 87);
            this.dtpExamDate.Name = "dtpExamDate";
            this.dtpExamDate.Size = new System.Drawing.Size(243, 20);
            this.dtpExamDate.TabIndex = 2;
            this.toolTip1.SetToolTip(this.dtpExamDate, "Select the Exam Date.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Exam Date*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "ExamType*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Invilgilator";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Room*";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // cboinvigilator
            // 
            this.cboinvigilator.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboinvigilator.FormattingEnabled = true;
            this.cboinvigilator.Location = new System.Drawing.Point(91, 120);
            this.cboinvigilator.Name = "cboinvigilator";
            this.cboinvigilator.Size = new System.Drawing.Size(243, 21);
            this.cboinvigilator.TabIndex = 3;
            // 
            // RegisterSingleExamForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(401, 376);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterSingleExamForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register Exam";
            this.Load += new System.EventHandler(this.RegisterSingleExamForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxContribution.ResumeLayout(false);
            this.groupBoxContribution.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceExamType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboRooms;
        private System.Windows.Forms.DateTimePicker dtpExamDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chkContribution;
        private System.Windows.Forms.GroupBox groupBoxContribution;
        private System.Windows.Forms.TextBox txtContr;
        private System.Windows.Forms.ComboBox cbExamType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bindingSourceExamType;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtModifiedBy;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtOutOf;
        private System.Windows.Forms.ComboBox cboinvigilator;
    }
}