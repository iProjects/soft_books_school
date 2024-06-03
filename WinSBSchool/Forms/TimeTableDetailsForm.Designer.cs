namespace WinSBSchool.Forms
{
    partial class TimeTableDetailsForm
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
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtVenue = new System.Windows.Forms.TextBox();
            this.txtActivity = new System.Windows.Forms.TextBox();
            this.btnAddVenue = new System.Windows.Forms.Button();
            this.btnActivity = new System.Windows.Forms.Button();
            this._lstVenues = new System.Windows.Forms.ListBox();
            this._lstActivities = new System.Windows.Forms.ListBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.cboRecurrent = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bindingSourceActivities = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceVenues = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActivities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVenues)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Yellow;
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(209, 16);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.Yellow;
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(125, 16);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(53, 25);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 389);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtVenue);
            this.groupBox2.Controls.Add(this.txtActivity);
            this.groupBox2.Controls.Add(this.btnAddVenue);
            this.groupBox2.Controls.Add(this.btnActivity);
            this.groupBox2.Controls.Add(this._lstVenues);
            this.groupBox2.Controls.Add(this._lstActivities);
            this.groupBox2.Controls.Add(this.dtpEndDate);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.dtpStartDate);
            this.groupBox2.Controls.Add(this.cboRecurrent);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 389);
            this.groupBox2.TabIndex = 37;
            this.groupBox2.TabStop = false;
            // 
            // txtVenue
            // 
            this.txtVenue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVenue.Location = new System.Drawing.Point(311, 182);
            this.txtVenue.Name = "txtVenue";
            this.txtVenue.Size = new System.Drawing.Size(118, 20);
            this.txtVenue.TabIndex = 4;
            // 
            // txtActivity
            // 
            this.txtActivity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActivity.Location = new System.Drawing.Point(310, 22);
            this.txtActivity.Name = "txtActivity";
            this.txtActivity.Size = new System.Drawing.Size(118, 20);
            this.txtActivity.TabIndex = 1;
            // 
            // btnAddVenue
            // 
            this.btnAddVenue.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAddVenue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddVenue.Location = new System.Drawing.Point(311, 208);
            this.btnAddVenue.Name = "btnAddVenue";
            this.btnAddVenue.Size = new System.Drawing.Size(73, 24);
            this.btnAddVenue.TabIndex = 5;
            this.btnAddVenue.Text = "Add Venue";
            this.btnAddVenue.UseVisualStyleBackColor = false;
            this.btnAddVenue.Click += new System.EventHandler(this.btnAddVenue_Click);
            // 
            // btnActivity
            // 
            this.btnActivity.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnActivity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActivity.Location = new System.Drawing.Point(310, 48);
            this.btnActivity.Name = "btnActivity";
            this.btnActivity.Size = new System.Drawing.Size(74, 23);
            this.btnActivity.TabIndex = 2;
            this.btnActivity.Text = "Add Activity";
            this.btnActivity.UseVisualStyleBackColor = false;
            this.btnActivity.Click += new System.EventHandler(this.btnActivity_Click);
            // 
            // _lstVenues
            // 
            this._lstVenues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lstVenues.FormattingEnabled = true;
            this._lstVenues.Location = new System.Drawing.Point(95, 182);
            this._lstVenues.Name = "_lstVenues";
            this._lstVenues.Size = new System.Drawing.Size(210, 80);
            this._lstVenues.TabIndex = 3;
            // 
            // _lstActivities
            // 
            this._lstActivities.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._lstActivities.FormattingEnabled = true;
            this._lstActivities.Location = new System.Drawing.Point(94, 19);
            this._lstActivities.Name = "_lstActivities";
            this._lstActivities.Size = new System.Drawing.Size(210, 145);
            this._lstActivities.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEndDate.Location = new System.Drawing.Point(95, 355);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(210, 20);
            this.dtpEndDate.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 358);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "End Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpStartDate.Location = new System.Drawing.Point(95, 316);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(210, 20);
            this.dtpStartDate.TabIndex = 7;
            // 
            // cboRecurrent
            // 
            this.cboRecurrent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRecurrent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboRecurrent.FormattingEnabled = true;
            this.cboRecurrent.Location = new System.Drawing.Point(94, 281);
            this.cboRecurrent.Name = "cboRecurrent";
            this.cboRecurrent.Size = new System.Drawing.Size(210, 21);
            this.cboRecurrent.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 319);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Start Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(54, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Venue";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 284);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Recurrent";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Activities";
            // 
            // TimeTableDetailsForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(460, 444);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "TimeTableDetailsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Time Table Details";
            this.Load += new System.EventHandler(this.TimeTableDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceActivities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceVenues)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtVenue;
        private System.Windows.Forms.TextBox txtActivity;
        private System.Windows.Forms.Button btnAddVenue;
        private System.Windows.Forms.Button btnActivity;
        private System.Windows.Forms.ListBox _lstVenues;
        private System.Windows.Forms.ListBox _lstActivities;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.ComboBox cboRecurrent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.BindingSource bindingSourceActivities;
        private System.Windows.Forms.BindingSource bindingSourceVenues;
    }
}
