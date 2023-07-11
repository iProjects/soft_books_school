namespace WinSBSchool.Forms
{
    partial class FeeStructureForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeStructureForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFeeStructure = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewFeeStructure = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsDefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnCopy = new System.Windows.Forms.LinkLabel();
            this.btnDelete = new System.Windows.Forms.LinkLabel();
            this.btnAdd = new System.Windows.Forms.LinkLabel();
            this.btnEdit = new System.Windows.Forms.LinkLabel();
            this.tabPageAcademicFees = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.dataGridViewFeeStructureAcademic = new System.Windows.Forms.DataGridView();
            this.ColumnAcademicId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAcademicDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTerm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboClass = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.LinkLabel();
            this.btDeleteAcademicFeeStructure = new System.Windows.Forms.LinkLabel();
            this.btnAddAcademicFeeStructure = new System.Windows.Forms.LinkLabel();
            this.btnEditAcademicFeeStructure = new System.Windows.Forms.LinkLabel();
            this.tabPageOtherfees = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.dataGridViewFeeStructureOthers = new System.Windows.Forms.DataGridView();
            this.ColumnOthersId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOthersDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOthersAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnDeleteOtherFeeStructure = new System.Windows.Forms.LinkLabel();
            this.btnAddOtherFeeStructure = new System.Windows.Forms.LinkLabel();
            this.btnEditOtherFeeStructure = new System.Windows.Forms.LinkLabel();
            this.tabPageSummary = new System.Windows.Forms.TabPage();
            this.ListViewFeeStructureSummary = new System.Windows.Forms.ListView();
            this.btnChargeFees = new System.Windows.Forms.LinkLabel();
            this.bindingSourceFeeStructure = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTimeElasped = new System.Windows.Forms.Label();
            this.progressBarProcess = new System.Windows.Forms.ProgressBar();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.bindingSourceFeeStructureAcademic = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceFeeStructureOthers = new System.Windows.Forms.BindingSource(this.components);
            this.updateStatusTimer = new System.Windows.Forms.Timer(this.components);
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPageFeeStructure.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeStructure)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.tabPageAcademicFees.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeStructureAcademic)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabPageOtherfees.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeStructureOthers)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.tabPageSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFeeStructure)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFeeStructureAcademic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFeeStructureOthers)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageFeeStructure);
            this.tabControl1.Controls.Add(this.tabPageAcademicFees);
            this.tabControl1.Controls.Add(this.tabPageOtherfees);
            this.tabControl1.Controls.Add(this.tabPageSummary);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 315);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageFeeStructure
            // 
            this.tabPageFeeStructure.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageFeeStructure.Controls.Add(this.groupBox2);
            this.tabPageFeeStructure.Location = new System.Drawing.Point(4, 22);
            this.tabPageFeeStructure.Name = "tabPageFeeStructure";
            this.tabPageFeeStructure.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFeeStructure.Size = new System.Drawing.Size(755, 289);
            this.tabPageFeeStructure.TabIndex = 0;
            this.tabPageFeeStructure.Text = "Fee Structure";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewFeeStructure);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(749, 283);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewFeeStructure
            // 
            this.dataGridViewFeeStructure.AllowUserToAddRows = false;
            this.dataGridViewFeeStructure.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFeeStructure.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewFeeStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFeeStructure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnDescription,
            this.ColumnYear,
            this.ColumnIsDefault});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFeeStructure.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewFeeStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFeeStructure.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewFeeStructure.MultiSelect = false;
            this.dataGridViewFeeStructure.Name = "dataGridViewFeeStructure";
            this.dataGridViewFeeStructure.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFeeStructure.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewFeeStructure.Size = new System.Drawing.Size(743, 227);
            this.dataGridViewFeeStructure.TabIndex = 0;
            this.dataGridViewFeeStructure.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFeeStructure_CellClick);
            this.dataGridViewFeeStructure.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFeeStructure_CellContentDoubleClick);
            this.dataGridViewFeeStructure.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewFeeStructure_DataError);
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.DataPropertyName = "Id";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            // 
            // ColumnDescription
            // 
            this.ColumnDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnDescription.DataPropertyName = "Description";
            this.ColumnDescription.HeaderText = "Description";
            this.ColumnDescription.Name = "ColumnDescription";
            this.ColumnDescription.ReadOnly = true;
            this.ColumnDescription.Width = 400;
            // 
            // ColumnYear
            // 
            this.ColumnYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnYear.DataPropertyName = "Year";
            this.ColumnYear.HeaderText = "Year";
            this.ColumnYear.Name = "ColumnYear";
            this.ColumnYear.ReadOnly = true;
            // 
            // ColumnIsDefault
            // 
            this.ColumnIsDefault.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIsDefault.DataPropertyName = "IsDefault";
            this.ColumnIsDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnIsDefault.HeaderText = "Is Default";
            this.ColumnIsDefault.Name = "ColumnIsDefault";
            this.ColumnIsDefault.ReadOnly = true;
            this.ColumnIsDefault.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsDefault.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnCopy);
            this.groupBox4.Controls.Add(this.btnDelete);
            this.groupBox4.Controls.Add(this.btnAdd);
            this.groupBox4.Controls.Add(this.btnEdit);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 243);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(743, 37);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            // 
            // btnCopy
            // 
            this.btnCopy.AutoSize = true;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnCopy.LinkColor = System.Drawing.Color.Yellow;
            this.btnCopy.Location = new System.Drawing.Point(42, 10);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(47, 18);
            this.btnCopy.TabIndex = 3;
            this.btnCopy.TabStop = true;
            this.btnCopy.Text = "Copy";
            this.btnCopy.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnCopy_LinkClicked);
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = true;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDelete.LinkColor = System.Drawing.Color.Yellow;
            this.btnDelete.Location = new System.Drawing.Point(665, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(56, 18);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.TabStop = true;
            this.btnDelete.Text = "Delete";
            this.btnDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDelete_LinkClicked);
            // 
            // btnAdd
            // 
            this.btnAdd.AutoSize = true;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAdd.LinkColor = System.Drawing.Color.Yellow;
            this.btnAdd.Location = new System.Drawing.Point(574, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(36, 18);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.TabStop = true;
            this.btnAdd.Text = "Add";
            this.btnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAdd_LinkClicked);
            // 
            // btnEdit
            // 
            this.btnEdit.AutoSize = true;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnEdit.LinkColor = System.Drawing.Color.Yellow;
            this.btnEdit.Location = new System.Drawing.Point(619, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(37, 18);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.TabStop = true;
            this.btnEdit.Text = "Edit";
            this.btnEdit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEdit_LinkClicked);
            // 
            // tabPageAcademicFees
            // 
            this.tabPageAcademicFees.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageAcademicFees.Controls.Add(this.groupBox5);
            this.tabPageAcademicFees.Location = new System.Drawing.Point(4, 22);
            this.tabPageAcademicFees.Name = "tabPageAcademicFees";
            this.tabPageAcademicFees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAcademicFees.Size = new System.Drawing.Size(755, 289);
            this.tabPageAcademicFees.TabIndex = 1;
            this.tabPageAcademicFees.Text = "Academic Fees";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox10);
            this.groupBox5.Controls.Add(this.groupBox9);
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(749, 283);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.dataGridViewFeeStructureAcademic);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(156, 16);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(590, 227);
            this.groupBox10.TabIndex = 2;
            this.groupBox10.TabStop = false;
            // 
            // dataGridViewFeeStructureAcademic
            // 
            this.dataGridViewFeeStructureAcademic.AllowUserToAddRows = false;
            this.dataGridViewFeeStructureAcademic.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFeeStructureAcademic.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewFeeStructureAcademic.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFeeStructureAcademic.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnAcademicId,
            this.ColumnAcademicDescription,
            this.ColumnAmount});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFeeStructureAcademic.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewFeeStructureAcademic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFeeStructureAcademic.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewFeeStructureAcademic.MultiSelect = false;
            this.dataGridViewFeeStructureAcademic.Name = "dataGridViewFeeStructureAcademic";
            this.dataGridViewFeeStructureAcademic.ReadOnly = true;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFeeStructureAcademic.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewFeeStructureAcademic.Size = new System.Drawing.Size(584, 208);
            this.dataGridViewFeeStructureAcademic.TabIndex = 2;
            this.dataGridViewFeeStructureAcademic.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFeeStructureAcademic_CellContentDoubleClick);
            this.dataGridViewFeeStructureAcademic.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewFeeStructureAcademic_DataError);
            // 
            // ColumnAcademicId
            // 
            this.ColumnAcademicId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnAcademicId.DataPropertyName = "Id";
            this.ColumnAcademicId.HeaderText = "Id";
            this.ColumnAcademicId.Name = "ColumnAcademicId";
            this.ColumnAcademicId.ReadOnly = true;
            this.ColumnAcademicId.Width = 40;
            // 
            // ColumnAcademicDescription
            // 
            this.ColumnAcademicDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnAcademicDescription.DataPropertyName = "Description";
            this.ColumnAcademicDescription.HeaderText = "Description";
            this.ColumnAcademicDescription.Name = "ColumnAcademicDescription";
            this.ColumnAcademicDescription.ReadOnly = true;
            // 
            // ColumnAmount
            // 
            this.ColumnAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.ColumnAmount.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnAmount.HeaderText = "Amount";
            this.ColumnAmount.Name = "ColumnAmount";
            this.ColumnAmount.ReadOnly = true;
            this.ColumnAmount.Width = 90;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label2);
            this.groupBox9.Controls.Add(this.cboTerm);
            this.groupBox9.Controls.Add(this.label1);
            this.groupBox9.Controls.Add(this.cboClass);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox9.Location = new System.Drawing.Point(3, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(153, 227);
            this.groupBox9.TabIndex = 0;
            this.groupBox9.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Term:";
            // 
            // cboTerm
            // 
            this.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTerm.FormattingEnabled = true;
            this.cboTerm.Location = new System.Drawing.Point(9, 99);
            this.cboTerm.Name = "cboTerm";
            this.cboTerm.Size = new System.Drawing.Size(121, 21);
            this.cboTerm.TabIndex = 2;
            this.cboTerm.SelectedIndexChanged += new System.EventHandler(this.cboTerm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Class:";
            // 
            // cboClass
            // 
            this.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboClass.FormattingEnabled = true;
            this.cboClass.Location = new System.Drawing.Point(9, 32);
            this.cboClass.Name = "cboClass";
            this.cboClass.Size = new System.Drawing.Size(121, 21);
            this.cboClass.TabIndex = 0;
            this.cboClass.SelectedIndexChanged += new System.EventHandler(this.cboClass_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.btnPrint);
            this.groupBox6.Controls.Add(this.btDeleteAcademicFeeStructure);
            this.groupBox6.Controls.Add(this.btnAddAcademicFeeStructure);
            this.groupBox6.Controls.Add(this.btnEditAcademicFeeStructure);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox6.Location = new System.Drawing.Point(3, 243);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(743, 37);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            // 
            // btnPrint
            // 
            this.btnPrint.AutoSize = true;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnPrint.LinkColor = System.Drawing.Color.Yellow;
            this.btnPrint.Location = new System.Drawing.Point(23, 11);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(43, 18);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.TabStop = true;
            this.btnPrint.Text = "Print";
            this.btnPrint.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnPrint_LinkClicked);
            // 
            // btDeleteAcademicFeeStructure
            // 
            this.btDeleteAcademicFeeStructure.AutoSize = true;
            this.btDeleteAcademicFeeStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btDeleteAcademicFeeStructure.LinkColor = System.Drawing.Color.Yellow;
            this.btDeleteAcademicFeeStructure.Location = new System.Drawing.Point(666, 11);
            this.btDeleteAcademicFeeStructure.Name = "btDeleteAcademicFeeStructure";
            this.btDeleteAcademicFeeStructure.Size = new System.Drawing.Size(56, 18);
            this.btDeleteAcademicFeeStructure.TabIndex = 2;
            this.btDeleteAcademicFeeStructure.TabStop = true;
            this.btDeleteAcademicFeeStructure.Text = "Delete";
            this.btDeleteAcademicFeeStructure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btDeleteAcademicFeeStructure_LinkClicked);
            // 
            // btnAddAcademicFeeStructure
            // 
            this.btnAddAcademicFeeStructure.AutoSize = true;
            this.btnAddAcademicFeeStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddAcademicFeeStructure.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddAcademicFeeStructure.Location = new System.Drawing.Point(581, 11);
            this.btnAddAcademicFeeStructure.Name = "btnAddAcademicFeeStructure";
            this.btnAddAcademicFeeStructure.Size = new System.Drawing.Size(36, 18);
            this.btnAddAcademicFeeStructure.TabIndex = 0;
            this.btnAddAcademicFeeStructure.TabStop = true;
            this.btnAddAcademicFeeStructure.Text = "Add";
            this.btnAddAcademicFeeStructure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddAcademicFeeStructure_LinkClicked);
            // 
            // btnEditAcademicFeeStructure
            // 
            this.btnEditAcademicFeeStructure.AutoSize = true;
            this.btnEditAcademicFeeStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnEditAcademicFeeStructure.LinkColor = System.Drawing.Color.Yellow;
            this.btnEditAcademicFeeStructure.Location = new System.Drawing.Point(623, 11);
            this.btnEditAcademicFeeStructure.Name = "btnEditAcademicFeeStructure";
            this.btnEditAcademicFeeStructure.Size = new System.Drawing.Size(37, 18);
            this.btnEditAcademicFeeStructure.TabIndex = 1;
            this.btnEditAcademicFeeStructure.TabStop = true;
            this.btnEditAcademicFeeStructure.Text = "Edit";
            this.btnEditAcademicFeeStructure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEditAcademicFeeStructure_LinkClicked);
            // 
            // tabPageOtherfees
            // 
            this.tabPageOtherfees.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageOtherfees.Controls.Add(this.groupBox7);
            this.tabPageOtherfees.Location = new System.Drawing.Point(4, 22);
            this.tabPageOtherfees.Name = "tabPageOtherfees";
            this.tabPageOtherfees.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOtherfees.Size = new System.Drawing.Size(755, 289);
            this.tabPageOtherfees.TabIndex = 2;
            this.tabPageOtherfees.Text = "Other Fees";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.dataGridViewFeeStructureOthers);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(3, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(749, 283);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            // 
            // dataGridViewFeeStructureOthers
            // 
            this.dataGridViewFeeStructureOthers.AllowUserToAddRows = false;
            this.dataGridViewFeeStructureOthers.AllowUserToDeleteRows = false;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFeeStructureOthers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewFeeStructureOthers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFeeStructureOthers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnOthersId,
            this.ColumnOthersDescription,
            this.ColumnOthersAmount});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewFeeStructureOthers.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewFeeStructureOthers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewFeeStructureOthers.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewFeeStructureOthers.MultiSelect = false;
            this.dataGridViewFeeStructureOthers.Name = "dataGridViewFeeStructureOthers";
            this.dataGridViewFeeStructureOthers.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFeeStructureOthers.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewFeeStructureOthers.Size = new System.Drawing.Size(743, 223);
            this.dataGridViewFeeStructureOthers.TabIndex = 5;
            this.dataGridViewFeeStructureOthers.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFeeStructureOthers_CellContentDoubleClick);
            this.dataGridViewFeeStructureOthers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewFeeStructureOthers_DataError);
            // 
            // ColumnOthersId
            // 
            this.ColumnOthersId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnOthersId.DataPropertyName = "Id";
            this.ColumnOthersId.HeaderText = "Id";
            this.ColumnOthersId.Name = "ColumnOthersId";
            this.ColumnOthersId.ReadOnly = true;
            this.ColumnOthersId.Width = 50;
            // 
            // ColumnOthersDescription
            // 
            this.ColumnOthersDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnOthersDescription.DataPropertyName = "Description";
            this.ColumnOthersDescription.HeaderText = "Description";
            this.ColumnOthersDescription.Name = "ColumnOthersDescription";
            this.ColumnOthersDescription.ReadOnly = true;
            // 
            // ColumnOthersAmount
            // 
            this.ColumnOthersAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnOthersAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.ColumnOthersAmount.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnOthersAmount.HeaderText = "Amount";
            this.ColumnOthersAmount.Name = "ColumnOthersAmount";
            this.ColumnOthersAmount.ReadOnly = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnDeleteOtherFeeStructure);
            this.groupBox8.Controls.Add(this.btnAddOtherFeeStructure);
            this.groupBox8.Controls.Add(this.btnEditOtherFeeStructure);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox8.Location = new System.Drawing.Point(3, 239);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(743, 41);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            // 
            // btnDeleteOtherFeeStructure
            // 
            this.btnDeleteOtherFeeStructure.AutoSize = true;
            this.btnDeleteOtherFeeStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnDeleteOtherFeeStructure.LinkColor = System.Drawing.Color.Yellow;
            this.btnDeleteOtherFeeStructure.Location = new System.Drawing.Point(670, 11);
            this.btnDeleteOtherFeeStructure.Name = "btnDeleteOtherFeeStructure";
            this.btnDeleteOtherFeeStructure.Size = new System.Drawing.Size(56, 18);
            this.btnDeleteOtherFeeStructure.TabIndex = 7;
            this.btnDeleteOtherFeeStructure.TabStop = true;
            this.btnDeleteOtherFeeStructure.Text = "Delete";
            this.btnDeleteOtherFeeStructure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnDeleteOtherFeeStructure_LinkClicked);
            // 
            // btnAddOtherFeeStructure
            // 
            this.btnAddOtherFeeStructure.AutoSize = true;
            this.btnAddOtherFeeStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddOtherFeeStructure.LinkColor = System.Drawing.Color.Yellow;
            this.btnAddOtherFeeStructure.Location = new System.Drawing.Point(591, 11);
            this.btnAddOtherFeeStructure.Name = "btnAddOtherFeeStructure";
            this.btnAddOtherFeeStructure.Size = new System.Drawing.Size(36, 18);
            this.btnAddOtherFeeStructure.TabIndex = 6;
            this.btnAddOtherFeeStructure.TabStop = true;
            this.btnAddOtherFeeStructure.Text = "Add";
            this.btnAddOtherFeeStructure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnAddOtherFeeStructure_LinkClicked);
            // 
            // btnEditOtherFeeStructure
            // 
            this.btnEditOtherFeeStructure.AutoSize = true;
            this.btnEditOtherFeeStructure.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnEditOtherFeeStructure.LinkColor = System.Drawing.Color.Yellow;
            this.btnEditOtherFeeStructure.Location = new System.Drawing.Point(630, 11);
            this.btnEditOtherFeeStructure.Name = "btnEditOtherFeeStructure";
            this.btnEditOtherFeeStructure.Size = new System.Drawing.Size(37, 18);
            this.btnEditOtherFeeStructure.TabIndex = 4;
            this.btnEditOtherFeeStructure.TabStop = true;
            this.btnEditOtherFeeStructure.Text = "Edit";
            this.btnEditOtherFeeStructure.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnEditOtherFeeStructure_LinkClicked);
            // 
            // tabPageSummary
            // 
            this.tabPageSummary.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tabPageSummary.Controls.Add(this.ListViewFeeStructureSummary);
            this.tabPageSummary.Location = new System.Drawing.Point(4, 22);
            this.tabPageSummary.Name = "tabPageSummary";
            this.tabPageSummary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSummary.Size = new System.Drawing.Size(755, 289);
            this.tabPageSummary.TabIndex = 3;
            this.tabPageSummary.Text = "Sumary";
            // 
            // ListViewFeeStructureSummary
            // 
            this.ListViewFeeStructureSummary.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListViewFeeStructureSummary.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListViewFeeStructureSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewFeeStructureSummary.FullRowSelect = true;
            this.ListViewFeeStructureSummary.GridLines = true;
            this.ListViewFeeStructureSummary.HideSelection = false;
            this.ListViewFeeStructureSummary.HotTracking = true;
            this.ListViewFeeStructureSummary.HoverSelection = true;
            this.ListViewFeeStructureSummary.Location = new System.Drawing.Point(3, 3);
            this.ListViewFeeStructureSummary.MultiSelect = false;
            this.ListViewFeeStructureSummary.Name = "ListViewFeeStructureSummary";
            this.ListViewFeeStructureSummary.ShowItemToolTips = true;
            this.ListViewFeeStructureSummary.Size = new System.Drawing.Size(749, 283);
            this.ListViewFeeStructureSummary.TabIndex = 6;
            this.ListViewFeeStructureSummary.UseCompatibleStateImageBehavior = false;
            this.ListViewFeeStructureSummary.View = System.Windows.Forms.View.Details;
            // 
            // btnChargeFees
            // 
            this.btnChargeFees.AutoSize = true;
            this.btnChargeFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnChargeFees.LinkColor = System.Drawing.Color.Yellow;
            this.btnChargeFees.Location = new System.Drawing.Point(12, 11);
            this.btnChargeFees.Name = "btnChargeFees";
            this.btnChargeFees.Size = new System.Drawing.Size(104, 18);
            this.btnChargeFees.TabIndex = 5;
            this.btnChargeFees.TabStop = true;
            this.btnChargeFees.Text = "Charge Fees";
            this.btnChargeFees.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnChargeFees_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTimeElasped);
            this.groupBox1.Controls.Add(this.progressBarProcess);
            this.groupBox1.Controls.Add(this.btnChargeFees);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 334);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(769, 39);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // lblTimeElasped
            // 
            this.lblTimeElasped.AutoSize = true;
            this.lblTimeElasped.Location = new System.Drawing.Point(504, 14);
            this.lblTimeElasped.Name = "lblTimeElasped";
            this.lblTimeElasped.Size = new System.Drawing.Size(26, 13);
            this.lblTimeElasped.TabIndex = 7;
            this.lblTimeElasped.Text = "time";
            // 
            // progressBarProcess
            // 
            this.progressBarProcess.BackColor = System.Drawing.SystemColors.Control;
            this.progressBarProcess.Location = new System.Drawing.Point(149, 9);
            this.progressBarProcess.Name = "progressBarProcess";
            this.progressBarProcess.Size = new System.Drawing.Size(340, 23);
            this.progressBarProcess.TabIndex = 6;
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(684, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 18);
            this.btnClose.TabIndex = 0;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(769, 334);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Validating += new System.ComponentModel.CancelEventHandler(this.groupBox3_Validating);
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.Text = "notifyIcon1";
            this.appNotifyIcon.Visible = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn2.HeaderText = "Description";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 250;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Year";
            this.dataGridViewTextBoxColumn3.HeaderText = "Year";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn4.HeaderText = "Id";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 50;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn5.HeaderText = "Description";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Amount";
            dataGridViewCellStyle12.Format = "C2";
            dataGridViewCellStyle12.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn6.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "AmountPeriod";
            dataGridViewCellStyle13.Format = "C2";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn7.HeaderText = "Amount Period";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn8.HeaderText = "Id";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 243;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Description";
            dataGridViewCellStyle14.Format = "C2";
            dataGridViewCellStyle14.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn9.HeaderText = "Description";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 200;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Amount";
            dataGridViewCellStyle15.Format = "C2";
            dataGridViewCellStyle15.NullValue = null;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle15;
            this.dataGridViewTextBoxColumn10.HeaderText = "Amount";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 250;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "AmountPeriod";
            this.dataGridViewTextBoxColumn11.HeaderText = "Amount Period";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ApplicableTo";
            this.dataGridViewTextBoxColumn12.HeaderText = "Applicable To";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // FeeStructureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(769, 373);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FeeStructureForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Structure";
            this.Load += new System.EventHandler(this.FeeStructureForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageFeeStructure.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeStructure)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.tabPageAcademicFees.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeStructureAcademic)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.tabPageOtherfees.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFeeStructureOthers)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.tabPageSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFeeStructure)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFeeStructureAcademic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceFeeStructureOthers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFeeStructure;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabPage tabPageAcademicFees;
        private System.Windows.Forms.TabPage tabPageOtherfees;
        private System.Windows.Forms.BindingSource bindingSourceFeeStructure;
        private System.Windows.Forms.TabPage tabPageSummary;
        private System.Windows.Forms.DataGridView dataGridViewFeeStructure;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.LinkLabel btnCopy;
        private System.Windows.Forms.LinkLabel btnDelete;
        private System.Windows.Forms.LinkLabel btnAdd;
        private System.Windows.Forms.LinkLabel btnEdit;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.LinkLabel btDeleteAcademicFeeStructure;
        private System.Windows.Forms.LinkLabel btnAddAcademicFeeStructure;
        private System.Windows.Forms.LinkLabel btnEditAcademicFeeStructure;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.LinkLabel btnDeleteOtherFeeStructure;
        private System.Windows.Forms.LinkLabel btnAddOtherFeeStructure;
        private System.Windows.Forms.LinkLabel btnEditOtherFeeStructure;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.BindingSource bindingSourceFeeStructureAcademic;
        private System.Windows.Forms.DataGridView dataGridViewFeeStructureOthers;
        private System.Windows.Forms.BindingSource bindingSourceFeeStructureOthers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ListView ListViewFeeStructureSummary;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.LinkLabel btnChargeFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOthersId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOthersDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOthersAmount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTerm;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.DataGridView dataGridViewFeeStructureAcademic;
        private System.Windows.Forms.LinkLabel btnPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAcademicId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAcademicDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAmount;
        private System.Windows.Forms.ProgressBar progressBarProcess;
        private System.Windows.Forms.Label lblTimeElasped;
        private System.Windows.Forms.Timer updateStatusTimer;
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnYear;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsDefault;

    }
}