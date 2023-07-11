namespace WinSBSchool.Forms
{
    partial class ReceivedSmsMessagesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReceivedSmsMessagesForm));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.appNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.LinkLabel();
            this.chkProcessedSms = new System.Windows.Forms.CheckBox();
            this.btnSubmit = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtReadMessage = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridViewSms = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStripSms = new System.Windows.Forms.StatusStrip();
            this.lblSmsStorage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblOriginatingAddressType = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.bindingSourceSms = new System.Windows.Forms.BindingSource(this.components);
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOriginatingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProcessed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnUserDataText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSms)).BeginInit();
            this.statusStripSms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSms)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // appNotifyIcon
            // 
            this.appNotifyIcon.Text = "notifyIcon1";
            this.appNotifyIcon.Visible = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.chkProcessedSms);
            this.groupBox1.Controls.Add(this.btnSubmit);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 313);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(656, 38);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.AutoSize = true;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.LinkColor = System.Drawing.Color.Yellow;
            this.btnRefresh.Location = new System.Drawing.Point(362, 13);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(146, 15);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.TabStop = true;
            this.btnRefresh.Text = "Refresh From Modem";
            this.btnRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnRefresh_LinkClicked);
            // 
            // chkProcessedSms
            // 
            this.chkProcessedSms.AutoSize = true;
            this.chkProcessedSms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkProcessedSms.Location = new System.Drawing.Point(12, 15);
            this.chkProcessedSms.Name = "chkProcessedSms";
            this.chkProcessedSms.Size = new System.Drawing.Size(73, 17);
            this.chkProcessedSms.TabIndex = 0;
            this.chkProcessedSms.Text = "Processed";
            this.chkProcessedSms.UseVisualStyleBackColor = true;
            this.chkProcessedSms.CheckedChanged += new System.EventHandler(this.chkProcessedSms_CheckedChanged);
            // 
            // btnSubmit
            // 
            this.btnSubmit.AutoSize = true;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.LinkColor = System.Drawing.Color.Yellow;
            this.btnSubmit.Location = new System.Drawing.Point(515, 13);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(52, 15);
            this.btnSubmit.TabIndex = 2;
            this.btnSubmit.TabStop = true;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSubmit_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.AutoSize = true;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.LinkColor = System.Drawing.Color.Yellow;
            this.btnClose.Location = new System.Drawing.Point(571, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(43, 15);
            this.btnClose.TabIndex = 3;
            this.btnClose.TabStop = true;
            this.btnClose.Text = "Close";
            this.btnClose.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnClose_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtReadMessage);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(0, 212);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(656, 101);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // txtReadMessage
            // 
            this.txtReadMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReadMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtReadMessage.Location = new System.Drawing.Point(3, 16);
            this.txtReadMessage.MaxLength = 4;
            this.txtReadMessage.Multiline = true;
            this.txtReadMessage.Name = "txtReadMessage";
            this.txtReadMessage.Size = new System.Drawing.Size(650, 82);
            this.txtReadMessage.TabIndex = 0;
            this.txtReadMessage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtReadMessage_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewSms);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(656, 212);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // dataGridViewSms
            // 
            this.dataGridViewSms.AllowUserToAddRows = false;
            this.dataGridViewSms.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSms.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnOriginatingAddress,
            this.ColumnProcessed,
            this.ColumnUserDataText});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSms.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSms.Location = new System.Drawing.Point(3, 16);
            this.dataGridViewSms.MultiSelect = false;
            this.dataGridViewSms.Name = "dataGridViewSms";
            this.dataGridViewSms.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSms.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSms.Size = new System.Drawing.Size(650, 193);
            this.dataGridViewSms.TabIndex = 0;
            this.dataGridViewSms.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSms_CellClick);
            this.dataGridViewSms.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSms_CellContentDoubleClick);
            this.dataGridViewSms.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewSms_DataError);
            this.dataGridViewSms.SelectionChanged += new System.EventHandler(this.dataGridViewSms_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SchoolIndex";
            this.dataGridViewTextBoxColumn1.HeaderText = "School Index";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "SchoolName";
            this.dataGridViewTextBoxColumn2.FillWeight = 200F;
            this.dataGridViewTextBoxColumn2.HeaderText = "School Name";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Telephone";
            this.dataGridViewTextBoxColumn3.HeaderText = "Telephone";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 116;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Cellphone";
            this.dataGridViewTextBoxColumn4.HeaderText = "Cell Phone";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 277;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Email";
            this.dataGridViewTextBoxColumn5.FillWeight = 150F;
            this.dataGridViewTextBoxColumn5.HeaderText = "Email";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 150;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Address1";
            this.dataGridViewTextBoxColumn6.HeaderText = "Address";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 100;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // statusStripSms
            // 
            this.statusStripSms.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("statusStripSms.BackgroundImage")));
            this.statusStripSms.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSmsStorage,
            this.toolStripStatusLabel1,
            this.lblOriginatingAddressType,
            this.toolStripStatusLabel4,
            this.lblDate});
            this.statusStripSms.Location = new System.Drawing.Point(0, 351);
            this.statusStripSms.Name = "statusStripSms";
            this.statusStripSms.Size = new System.Drawing.Size(656, 22);
            this.statusStripSms.TabIndex = 3;
            this.statusStripSms.Text = "statusStrip1";
            // 
            // lblSmsStorage
            // 
            this.lblSmsStorage.Name = "lblSmsStorage";
            this.lblSmsStorage.Size = new System.Drawing.Size(44, 17);
            this.lblSmsStorage.Text = "storage";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(97, 17);
            this.toolStripStatusLabel1.Text = "                              ";
            // 
            // lblOriginatingAddressType
            // 
            this.lblOriginatingAddressType.Name = "lblOriginatingAddressType";
            this.lblOriginatingAddressType.Size = new System.Drawing.Size(70, 17);
            this.lblOriginatingAddressType.Text = "address type";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(97, 17);
            this.toolStripStatusLabel4.Text = "                              ";
            // 
            // lblDate
            // 
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(29, 17);
            this.lblDate.Text = "date";
            // 
            // ColumnId
            // 
            this.ColumnId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnId.DataPropertyName = "Id";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Width = 30;
            // 
            // ColumnOriginatingAddress
            // 
            this.ColumnOriginatingAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnOriginatingAddress.DataPropertyName = "OriginatingAddress";
            this.ColumnOriginatingAddress.HeaderText = "From";
            this.ColumnOriginatingAddress.Name = "ColumnOriginatingAddress";
            this.ColumnOriginatingAddress.ReadOnly = true;
            // 
            // ColumnProcessed
            // 
            this.ColumnProcessed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ColumnProcessed.DataPropertyName = "Processed";
            this.ColumnProcessed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ColumnProcessed.HeaderText = "Processed";
            this.ColumnProcessed.Name = "ColumnProcessed";
            this.ColumnProcessed.ReadOnly = true;
            this.ColumnProcessed.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnProcessed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnProcessed.Width = 60;
            // 
            // ColumnUserDataText
            // 
            this.ColumnUserDataText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnUserDataText.DataPropertyName = "UserDataText";
            this.ColumnUserDataText.HeaderText = "Message";
            this.ColumnUserDataText.Name = "ColumnUserDataText";
            this.ColumnUserDataText.ReadOnly = true;
            // 
            // ReceivedSmsMessagesForm
            // 
            this.AcceptButton = this.btnSubmit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(656, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStripSms);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReceivedSmsMessagesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS Messages";
            this.Load += new System.EventHandler(this.SmsMessagesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSms)).EndInit();
            this.statusStripSms.ResumeLayout(false);
            this.statusStripSms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceSms)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource bindingSourceSms;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.NotifyIcon appNotifyIcon;
        private System.Windows.Forms.StatusStrip statusStripSms;
        private System.Windows.Forms.ToolStripStatusLabel lblSmsStorage;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblOriginatingAddressType;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel lblDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkProcessedSms;
        private System.Windows.Forms.LinkLabel btnClose;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewSms;
        private System.Windows.Forms.TextBox txtReadMessage;
        private System.Windows.Forms.LinkLabel btnRefresh;
        private System.Windows.Forms.LinkLabel btnSubmit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOriginatingAddress;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnProcessed;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserDataText;
    }
}