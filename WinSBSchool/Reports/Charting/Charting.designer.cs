namespace WinSBSchool.Forms.Charting
{
    partial class Charting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Charting));
            this.cboWindowsColors = new System.Windows.Forms.ComboBox();
            this.cboChartBackColor = new System.Windows.Forms.ComboBox();
            this.lblWindowColor = new System.Windows.Forms.Label();
            this.lblChartBackColor = new System.Windows.Forms.Label();
            this.lnklblFeedChartData = new System.Windows.Forms.LinkLabel();
            this.cmdSave = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lblChartType = new System.Windows.Forms.Label();
            this.cboChartTypes = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnChartContainer = new System.Windows.Forms.Panel();
            this.pnChartRelControls = new System.Windows.Forms.Panel();
            this.pnChart = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnChartContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboWindowsColors
            // 
            this.cboWindowsColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboWindowsColors.FormattingEnabled = true;
            this.cboWindowsColors.Location = new System.Drawing.Point(96, 18);
            this.cboWindowsColors.Name = "cboWindowsColors";
            this.cboWindowsColors.Size = new System.Drawing.Size(121, 21);
            this.cboWindowsColors.TabIndex = 0;
            this.cboWindowsColors.SelectedIndexChanged += new System.EventHandler(this.cboWindowsColors_SelectedIndexChanged);
            // 
            // cboChartBackColor
            // 
            this.cboChartBackColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboChartBackColor.FormattingEnabled = true;
            this.cboChartBackColor.Location = new System.Drawing.Point(640, 18);
            this.cboChartBackColor.Name = "cboChartBackColor";
            this.cboChartBackColor.Size = new System.Drawing.Size(121, 21);
            this.cboChartBackColor.TabIndex = 3;
            this.cboChartBackColor.SelectedIndexChanged += new System.EventHandler(this.cboChartBackColor_SelectedIndexChanged);
            // 
            // lblWindowColor
            // 
            this.lblWindowColor.AutoSize = true;
            this.lblWindowColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWindowColor.Location = new System.Drawing.Point(10, 21);
            this.lblWindowColor.Name = "lblWindowColor";
            this.lblWindowColor.Size = new System.Drawing.Size(83, 15);
            this.lblWindowColor.TabIndex = 8;
            this.lblWindowColor.Text = "Window Color";
            // 
            // lblChartBackColor
            // 
            this.lblChartBackColor.AutoSize = true;
            this.lblChartBackColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartBackColor.Location = new System.Drawing.Point(542, 21);
            this.lblChartBackColor.Name = "lblChartBackColor";
            this.lblChartBackColor.Size = new System.Drawing.Size(95, 15);
            this.lblChartBackColor.TabIndex = 9;
            this.lblChartBackColor.Text = "Chart BackColor";
            // 
            // lnklblFeedChartData
            // 
            this.lnklblFeedChartData.AutoSize = true;
            this.lnklblFeedChartData.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblFeedChartData.LinkColor = System.Drawing.Color.Yellow;
            this.lnklblFeedChartData.Location = new System.Drawing.Point(450, 12);
            this.lnklblFeedChartData.Name = "lnklblFeedChartData";
            this.lnklblFeedChartData.Size = new System.Drawing.Size(131, 18);
            this.lnklblFeedChartData.TabIndex = 4;
            this.lnklblFeedChartData.TabStop = true;
            this.lnklblFeedChartData.Text = "Feed Chart Data";
            this.lnklblFeedChartData.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnklblFeedChartData_LinkClicked);
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cmdSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdSave.Location = new System.Drawing.Point(602, 13);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(75, 23);
            this.cmdSave.TabIndex = 0;
            this.cmdSave.Text = "Save Chart";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox1.Location = new System.Drawing.Point(237, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(73, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Enable 3D";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // lblChartType
            // 
            this.lblChartType.AutoSize = true;
            this.lblChartType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChartType.Location = new System.Drawing.Point(335, 21);
            this.lblChartType.Name = "lblChartType";
            this.lblChartType.Size = new System.Drawing.Size(65, 15);
            this.lblChartType.TabIndex = 8;
            this.lblChartType.Text = "Chart Type";
            // 
            // cboChartTypes
            // 
            this.cboChartTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboChartTypes.FormattingEnabled = true;
            this.cboChartTypes.Location = new System.Drawing.Point(403, 18);
            this.cboChartTypes.Name = "cboChartTypes";
            this.cboChartTypes.Size = new System.Drawing.Size(121, 21);
            this.cboChartTypes.TabIndex = 2;
            this.cboChartTypes.SelectedIndexChanged += new System.EventHandler(this.cboChartTypes_SelectedIndexChanged);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Title = "Save Chart";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboChartTypes);
            this.groupBox1.Controls.Add(this.lblChartType);
            this.groupBox1.Controls.Add(this.cboWindowsColors);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.cboChartBackColor);
            this.groupBox1.Controls.Add(this.lblWindowColor);
            this.groupBox1.Controls.Add(this.lblChartBackColor);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 53);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lnklblFeedChartData);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.cmdSave);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 331);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 42);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // pnChartContainer
            // 
            this.pnChartContainer.Controls.Add(this.pnChartRelControls);
            this.pnChartContainer.Controls.Add(this.pnChart);
            this.pnChartContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChartContainer.Location = new System.Drawing.Point(0, 53);
            this.pnChartContainer.Name = "pnChartContainer";
            this.pnChartContainer.Size = new System.Drawing.Size(792, 278);
            this.pnChartContainer.TabIndex = 1;
            // 
            // pnChartRelControls
            // 
            this.pnChartRelControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnChartRelControls.Location = new System.Drawing.Point(0, 239);
            this.pnChartRelControls.Name = "pnChartRelControls";
            this.pnChartRelControls.Size = new System.Drawing.Size(792, 39);
            this.pnChartRelControls.TabIndex = 1;
            // 
            // pnChart
            // 
            this.pnChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnChart.Location = new System.Drawing.Point(0, 0);
            this.pnChart.Name = "pnChart";
            this.pnChart.Size = new System.Drawing.Size(792, 278);
            this.pnChart.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(693, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Charting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(792, 373);
            this.Controls.Add(this.pnChartContainer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Charting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart";
            this.Activated += new System.EventHandler(this.Charting_Activated);
            this.Load += new System.EventHandler(this.Charting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnChartContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboWindowsColors;
        private System.Windows.Forms.ComboBox cboChartBackColor;
        private System.Windows.Forms.Label lblWindowColor;
        private System.Windows.Forms.Label lblChartBackColor;
        private System.Windows.Forms.LinkLabel lnklblFeedChartData;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblChartType;
        private System.Windows.Forms.ComboBox cboChartTypes;
        private System.Windows.Forms.Button cmdSave;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnChartContainer;
        private System.Windows.Forms.Panel pnChartRelControls;
        private System.Windows.Forms.Panel pnChart;
        private System.Windows.Forms.Button btnClose;
    }
}