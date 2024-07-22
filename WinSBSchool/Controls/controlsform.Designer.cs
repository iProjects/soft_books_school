namespace WinSBSchool.Controls
{
    partial class controlsform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(controlsform));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnclose = new System.Windows.Forms.Button();
            this.btnstudentdetails = new System.Windows.Forms.Button();
            this.btnclass = new System.Windows.Forms.Button();
            this.btnattendance = new System.Windows.Forms.Button();
            this.panelControls = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnclose);
            this.splitContainer1.Panel1.Controls.Add(this.btnstudentdetails);
            this.splitContainer1.Panel1.Controls.Add(this.btnclass);
            this.splitContainer1.Panel1.Controls.Add(this.btnattendance);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelControls);
            this.splitContainer1.Size = new System.Drawing.Size(1157, 565);
            this.splitContainer1.SplitterDistance = 145;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnclose
            // 
            this.btnclose.Location = new System.Drawing.Point(12, 132);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(118, 23);
            this.btnclose.TabIndex = 5;
            this.btnclose.Text = "Close";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnstudentdetails
            // 
            this.btnstudentdetails.Location = new System.Drawing.Point(12, 96);
            this.btnstudentdetails.Name = "btnstudentdetails";
            this.btnstudentdetails.Size = new System.Drawing.Size(118, 23);
            this.btnstudentdetails.TabIndex = 2;
            this.btnstudentdetails.Text = "Student Details";
            this.btnstudentdetails.UseVisualStyleBackColor = true;
            this.btnstudentdetails.Click += new System.EventHandler(this.btnstudentdetails_Click);
            // 
            // btnclass
            // 
            this.btnclass.Location = new System.Drawing.Point(12, 60);
            this.btnclass.Name = "btnclass";
            this.btnclass.Size = new System.Drawing.Size(118, 23);
            this.btnclass.TabIndex = 1;
            this.btnclass.Text = "Class";
            this.btnclass.UseVisualStyleBackColor = true;
            this.btnclass.Click += new System.EventHandler(this.btnclass_Click);
            // 
            // btnattendance
            // 
            this.btnattendance.Location = new System.Drawing.Point(12, 24);
            this.btnattendance.Name = "btnattendance";
            this.btnattendance.Size = new System.Drawing.Size(118, 23);
            this.btnattendance.TabIndex = 0;
            this.btnattendance.Text = "Attendance";
            this.btnattendance.UseVisualStyleBackColor = true;
            this.btnattendance.Click += new System.EventHandler(this.btnattendance_Click);
            // 
            // panelControls
            // 
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Location = new System.Drawing.Point(0, 0);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(1008, 565);
            this.panelControls.TabIndex = 0;
            // 
            // controlsform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1157, 565);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "controlsform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controls";
            this.Load += new System.EventHandler(this.controlsform_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnstudentdetails;
        private System.Windows.Forms.Button btnclass;
        private System.Windows.Forms.Button btnattendance;
        private System.Windows.Forms.Panel panelControls;
    }
}