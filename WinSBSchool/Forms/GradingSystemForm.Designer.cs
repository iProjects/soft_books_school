namespace WinSBSchool.Forms
{
    partial class GradingSystemForm
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
            this.listBoxGradingSystem = new System.Windows.Forms.ListBox();
            this.txtGradingSys = new System.Windows.Forms.TextBox();
            this.btnAddGradingSystem = new System.Windows.Forms.Button();
            this.btnRemoveGradingSystem = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.bindingSourceGS = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceGSD = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridViewGradingSystem = new System.Windows.Forms.DataGridView();
            this.Lower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Upper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGSD)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGradingSystem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxGradingSystem
            // 
            this.listBoxGradingSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBoxGradingSystem.Dock = System.Windows.Forms.DockStyle.Top;
            this.listBoxGradingSystem.FormattingEnabled = true;
            this.listBoxGradingSystem.Location = new System.Drawing.Point(3, 16);
            this.listBoxGradingSystem.Name = "listBoxGradingSystem";
            this.listBoxGradingSystem.Size = new System.Drawing.Size(241, 262);
            this.listBoxGradingSystem.TabIndex = 0;
            this.listBoxGradingSystem.SelectedIndexChanged += new System.EventHandler(this.listBoxGradingSystem_SelectedIndexChanged);
            // 
            // txtGradingSys
            // 
            this.txtGradingSys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtGradingSys.Location = new System.Drawing.Point(8, 299);
            this.txtGradingSys.Name = "txtGradingSys";
            this.txtGradingSys.Size = new System.Drawing.Size(131, 20);
            this.txtGradingSys.TabIndex = 1;
            //this.txtGradingSys.TextChanged += new System.EventHandler(this.txtGradingSys_TextChanged);
            this.txtGradingSys.Validated += new System.EventHandler(this.txtGradingSys_Validated);
            // 
            // btnAddGradingSystem
            // 
            this.btnAddGradingSystem.BackColor = System.Drawing.Color.HotPink;
            this.btnAddGradingSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGradingSystem.Location = new System.Drawing.Point(172, 298);
            this.btnAddGradingSystem.Name = "btnAddGradingSystem";
            this.btnAddGradingSystem.Size = new System.Drawing.Size(25, 23);
            this.btnAddGradingSystem.TabIndex = 2;
            this.btnAddGradingSystem.Text = "+";
            this.btnAddGradingSystem.UseVisualStyleBackColor = false;
            this.btnAddGradingSystem.Click += new System.EventHandler(this.btnAddGradingSystem_Click);
            // 
            // btnRemoveGradingSystem
            // 
            this.btnRemoveGradingSystem.BackColor = System.Drawing.Color.HotPink;
            this.btnRemoveGradingSystem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveGradingSystem.Location = new System.Drawing.Point(208, 298);
            this.btnRemoveGradingSystem.Name = "btnRemoveGradingSystem";
            this.btnRemoveGradingSystem.Size = new System.Drawing.Size(25, 23);
            this.btnRemoveGradingSystem.TabIndex = 3;
            this.btnRemoveGradingSystem.Text = "-";
            this.btnRemoveGradingSystem.UseVisualStyleBackColor = false;
            this.btnRemoveGradingSystem.Click += new System.EventHandler(this.btnRemoveGradingSystem_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.HotPink;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(528, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.HotPink;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(633, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 330);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 43);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.listBoxGradingSystem);
            this.groupBox3.Controls.Add(this.btnRemoveGradingSystem);
            this.groupBox3.Controls.Add(this.txtGradingSys);
            this.groupBox3.Controls.Add(this.btnAddGradingSystem);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(247, 330);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewGradingSystem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(247, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(463, 330);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grading system ranges";
            // 
            // dataGridViewGradingSystem
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGradingSystem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewGradingSystem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGradingSystem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lower,
            this.Upper,
            this.Grade,
            this.ColumnPoint,
            this.ColumnRemarks});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewGradingSystem.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewGradingSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewGradingSystem.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewGradingSystem.MultiSelect = false;
            this.dataGridViewGradingSystem.Name = "dataGridViewGradingSystem";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewGradingSystem.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewGradingSystem.Size = new System.Drawing.Size(457, 311);
            this.dataGridViewGradingSystem.TabIndex = 0;
            this.dataGridViewGradingSystem.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewGradingSystem_DataError);
            this.dataGridViewGradingSystem.Validated += new System.EventHandler(this.dataGridViewGradingSystem_Validated);
            // 
            // Lower
            // 
            this.Lower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Lower.DataPropertyName = "LMark";
            this.Lower.HeaderText = "Lower";
            this.Lower.Name = "Lower";
            this.Lower.Width = 70;
            // 
            // Upper
            // 
            this.Upper.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Upper.DataPropertyName = "UMark";
            this.Upper.HeaderText = "Upper";
            this.Upper.Name = "Upper";
            this.Upper.Width = 70;
            // 
            // Grade
            // 
            this.Grade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Grade.DataPropertyName = "Grade";
            this.Grade.HeaderText = "Grade";
            this.Grade.Name = "Grade";
            this.Grade.Width = 50;
            // 
            // ColumnPoint
            // 
            this.ColumnPoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnPoint.DataPropertyName = "Point";
            this.ColumnPoint.HeaderText = "Point";
            this.ColumnPoint.Name = "ColumnPoint";
            this.ColumnPoint.Width = 60;
            // 
            // ColumnRemarks
            // 
            this.ColumnRemarks.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnRemarks.DataPropertyName = "Remarks";
            this.ColumnRemarks.HeaderText = "Remarks";
            this.ColumnRemarks.Name = "ColumnRemarks";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "LMark";
            this.dataGridViewTextBoxColumn1.HeaderText = "Lower";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "UMark";
            this.dataGridViewTextBoxColumn2.HeaderText = "Upper";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Grade";
            this.dataGridViewTextBoxColumn3.HeaderText = "Grade";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Point";
            this.dataGridViewTextBoxColumn4.HeaderText = "Point";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Remarks";
            this.dataGridViewTextBoxColumn5.HeaderText = "Remarks";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Description";
            // 
            // GradingSystemForm
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(710, 373);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "GradingSystemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grading System";
            this.Load += new System.EventHandler(this.GradingSystemForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceGSD)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGradingSystem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxGradingSystem;
        private System.Windows.Forms.TextBox txtGradingSys;
        private System.Windows.Forms.Button btnAddGradingSystem;
        private System.Windows.Forms.Button btnRemoveGradingSystem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindingSourceGS;
        private System.Windows.Forms.BindingSource bindingSourceGSD;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridViewGradingSystem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lower;
        private System.Windows.Forms.DataGridViewTextBoxColumn Upper;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grade;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label1;



    }
}