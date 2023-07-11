namespace WinSBSchool.Forms
{
    partial class AddStudentDisplineForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddStudentDisplineForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboDisciplineRating = new System.Windows.Forms.ComboBox();
            this.cboSeverity = new System.Windows.Forms.ComboBox();
            this.label92 = new System.Windows.Forms.Label();
            this.txtReview = new System.Windows.Forms.TextBox();
            this.label86 = new System.Windows.Forms.Label();
            this.txtActionTaken = new System.Windows.Forms.TextBox();
            this.txtActionRecommendend = new System.Windows.Forms.TextBox();
            this.cboDisplineCategory = new System.Windows.Forms.ComboBox();
            this.txtIncident = new System.Windows.Forms.TextBox();
            this.dateTimePickeDisplinaryDate = new System.Windows.Forms.DateTimePicker();
            this.label99 = new System.Windows.Forms.Label();
            this.label98 = new System.Windows.Forms.Label();
            this.label97 = new System.Windows.Forms.Label();
            this.label96 = new System.Windows.Forms.Label();
            this.label95 = new System.Windows.Forms.Label();
            this.label94 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 271);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(511, 42);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(343, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(59, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Location = new System.Drawing.Point(186, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboDisciplineRating);
            this.groupBox2.Controls.Add(this.cboSeverity);
            this.groupBox2.Controls.Add(this.label92);
            this.groupBox2.Controls.Add(this.txtReview);
            this.groupBox2.Controls.Add(this.label86);
            this.groupBox2.Controls.Add(this.txtActionTaken);
            this.groupBox2.Controls.Add(this.txtActionRecommendend);
            this.groupBox2.Controls.Add(this.cboDisplineCategory);
            this.groupBox2.Controls.Add(this.txtIncident);
            this.groupBox2.Controls.Add(this.dateTimePickeDisplinaryDate);
            this.groupBox2.Controls.Add(this.label99);
            this.groupBox2.Controls.Add(this.label98);
            this.groupBox2.Controls.Add(this.label97);
            this.groupBox2.Controls.Add(this.label96);
            this.groupBox2.Controls.Add(this.label95);
            this.groupBox2.Controls.Add(this.label94);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(511, 271);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // cboDisciplineRating
            // 
            this.cboDisciplineRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDisciplineRating.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDisciplineRating.FormattingEnabled = true;
            this.cboDisciplineRating.Location = new System.Drawing.Point(151, 141);
            this.cboDisciplineRating.Name = "cboDisciplineRating";
            this.cboDisciplineRating.Size = new System.Drawing.Size(308, 21);
            this.cboDisciplineRating.TabIndex = 4;
            // 
            // cboSeverity
            // 
            this.cboSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeverity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboSeverity.FormattingEnabled = true;
            this.cboSeverity.Location = new System.Drawing.Point(151, 174);
            this.cboSeverity.Name = "cboSeverity";
            this.cboSeverity.Size = new System.Drawing.Size(308, 21);
            this.cboSeverity.TabIndex = 5;
            // 
            // label92
            // 
            this.label92.AutoSize = true;
            this.label92.Location = new System.Drawing.Point(62, 143);
            this.label92.Name = "label92";
            this.label92.Size = new System.Drawing.Size(86, 13);
            this.label92.TabIndex = 32;
            this.label92.Text = "Discipline Rating";
            // 
            // txtReview
            // 
            this.txtReview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReview.Location = new System.Drawing.Point(151, 239);
            this.txtReview.MaxLength = 100;
            this.txtReview.Name = "txtReview";
            this.txtReview.Size = new System.Drawing.Size(308, 20);
            this.txtReview.TabIndex = 7;
            // 
            // label86
            // 
            this.label86.AutoSize = true;
            this.label86.Location = new System.Drawing.Point(106, 242);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(43, 13);
            this.label86.TabIndex = 31;
            this.label86.Text = "Review";
            // 
            // txtActionTaken
            // 
            this.txtActionTaken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActionTaken.Location = new System.Drawing.Point(151, 110);
            this.txtActionTaken.MaxLength = 100;
            this.txtActionTaken.Name = "txtActionTaken";
            this.txtActionTaken.Size = new System.Drawing.Size(308, 20);
            this.txtActionTaken.TabIndex = 3;
            // 
            // txtActionRecommendend
            // 
            this.txtActionRecommendend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtActionRecommendend.Location = new System.Drawing.Point(151, 206);
            this.txtActionRecommendend.MaxLength = 100;
            this.txtActionRecommendend.Name = "txtActionRecommendend";
            this.txtActionRecommendend.Size = new System.Drawing.Size(308, 20);
            this.txtActionRecommendend.TabIndex = 6;
            // 
            // cboDisplineCategory
            // 
            this.cboDisplineCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDisplineCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboDisplineCategory.FormattingEnabled = true;
            this.cboDisplineCategory.Location = new System.Drawing.Point(151, 19);
            this.cboDisplineCategory.Name = "cboDisplineCategory";
            this.cboDisplineCategory.Size = new System.Drawing.Size(308, 21);
            this.cboDisplineCategory.TabIndex = 0;
            // 
            // txtIncident
            // 
            this.txtIncident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIncident.Location = new System.Drawing.Point(151, 82);
            this.txtIncident.MaxLength = 300;
            this.txtIncident.Name = "txtIncident";
            this.txtIncident.Size = new System.Drawing.Size(308, 20);
            this.txtIncident.TabIndex = 2;
            // 
            // dateTimePickeDisplinaryDate
            // 
            this.dateTimePickeDisplinaryDate.Location = new System.Drawing.Point(151, 51);
            this.dateTimePickeDisplinaryDate.Name = "dateTimePickeDisplinaryDate";
            this.dateTimePickeDisplinaryDate.Size = new System.Drawing.Size(308, 20);
            this.dateTimePickeDisplinaryDate.TabIndex = 1;
            // 
            // label99
            // 
            this.label99.AutoSize = true;
            this.label99.Location = new System.Drawing.Point(74, 113);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(75, 13);
            this.label99.TabIndex = 27;
            this.label99.Text = "Action Taken*";
            // 
            // label98
            // 
            this.label98.AutoSize = true;
            this.label98.Location = new System.Drawing.Point(31, 209);
            this.label98.Name = "label98";
            this.label98.Size = new System.Drawing.Size(118, 13);
            this.label98.TabIndex = 25;
            this.label98.Text = "Action Recommendend";
            // 
            // label97
            // 
            this.label97.AutoSize = true;
            this.label97.Location = new System.Drawing.Point(103, 176);
            this.label97.Name = "label97";
            this.label97.Size = new System.Drawing.Size(45, 13);
            this.label97.TabIndex = 23;
            this.label97.Text = "Severity";
            // 
            // label96
            // 
            this.label96.AutoSize = true;
            this.label96.Location = new System.Drawing.Point(47, 22);
            this.label96.Name = "label96";
            this.label96.Size = new System.Drawing.Size(101, 13);
            this.label96.TabIndex = 22;
            this.label96.Text = "Discipline Category*";
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.Location = new System.Drawing.Point(100, 85);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(49, 13);
            this.label95.TabIndex = 20;
            this.label95.Text = "Incident*";
            // 
            // label94
            // 
            this.label94.AutoSize = true;
            this.label94.Location = new System.Drawing.Point(59, 54);
            this.label94.Name = "label94";
            this.label94.Size = new System.Drawing.Size(90, 13);
            this.label94.TabIndex = 18;
            this.label94.Text = "Disciplinary Date*";
            // 
            // AddStudentDisplineForm
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(511, 313);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddStudentDisplineForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Student Displine";
            this.Load += new System.EventHandler(this.AddStudentDisplineForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cboDisciplineRating;
        private System.Windows.Forms.ComboBox cboSeverity;
        private System.Windows.Forms.Label label92;
        private System.Windows.Forms.TextBox txtReview;
        private System.Windows.Forms.Label label86;
        private System.Windows.Forms.TextBox txtActionTaken;
        private System.Windows.Forms.TextBox txtActionRecommendend;
        private System.Windows.Forms.ComboBox cboDisplineCategory;
        private System.Windows.Forms.TextBox txtIncident;
        private System.Windows.Forms.DateTimePicker dateTimePickeDisplinaryDate;
        private System.Windows.Forms.Label label99;
        private System.Windows.Forms.Label label98;
        private System.Windows.Forms.Label label97;
        private System.Windows.Forms.Label label96;
        private System.Windows.Forms.Label label95;
        private System.Windows.Forms.Label label94;
    }
}