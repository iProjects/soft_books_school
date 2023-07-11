using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using CommonLib;
using System.Data;

namespace WinSBSchool.Infrastructure
{

    public class SystemsForm : System.Windows.Forms.Form
    {

        const string SystemsConfigFile = "Security/Systems.xml";

        /*Default values */
        const string APPLICATION = "SBSchool";
        const string VERSION = "1.0.0.0";
        const string METADATA = "SBSchoolDBEntities";

        private LinkLabel btnSetasDefault;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        DataSet ds;
        BindingSource bs;
        private DataGridViewTextBoxColumn SysApplication;
        private DataGridViewTextBoxColumn SysMetadata;
        private DataGridViewTextBoxColumn SysVersion;
        private DataGridViewTextBoxColumn AttachDB;
        private DataGridViewTextBoxColumn AppName;
        private DataGridViewTextBoxColumn Server;
        private DataGridViewTextBoxColumn Database;
        private DataGridViewCheckBoxColumn Default;
        string TableName;

        public SystemsForm()
        {
            InitializeComponent();

        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //validate

                //get data
                string xmlData = ds.GetXml();

                //save to file
                ds.WriteXml(SystemsConfigFile);
                MessageBox.Show("Successfully saved file " + SystemsConfigFile);
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void SystemsForm_Load(object sender, System.EventArgs e)
        {
            try
            {
                bs = new BindingSource(); //Private Variable class level 

                ds = new DataSet();
                ds.ReadXml(SystemsConfigFile);

                bs.DataSource = ds;
                TableName = ds.Tables[0].TableName;
                bs.DataMember = TableName;

                dataGridView1.AutoGenerateColumns = false;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.DataSource = bs;

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void btnSetasDefault_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            /*
             * set the selected record default = true. set all others default = false
             */
            if (dataGridView1.SelectedRows.Count != 0)
            {
                try
                {
                    foreach (DataRowView row in ds.Tables[0].DefaultView)
                    {
                        var dr = (DataRowView)bs.Current;

                        string i = row["Name"].ToString();
                        string b = dr["Name"].ToString();
                        if (row["Name"].ToString() == dr["Name"].ToString())
                        {
                            row["Default"] = true;
                        }
                        else
                        {
                            row["Default"] = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowError(ex);
                }
            }
        }
        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                e.Row.Cells["SysApplication"].Value = APPLICATION;
                e.Row.Cells["AttachDB"].Value = "";
                e.Row.Cells["SysMetadata"].Value = METADATA;
                e.Row.Cells["SysVersion"].Value = VERSION;
            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        #region "Windows Form Designer generated code"
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SystemsForm));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSetasDefault = new System.Windows.Forms.LinkLabel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SysApplication = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SysMetadata = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SysVersion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AttachDB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Server = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Database = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Default = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(277, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 24);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(425, 19);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(64, 24);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 278);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(894, 55);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSetasDefault);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(894, 278);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Systems Configured";
            // 
            // btnSetasDefault
            // 
            this.btnSetasDefault.AutoSize = true;
            this.btnSetasDefault.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetasDefault.LinkColor = System.Drawing.Color.Yellow;
            this.btnSetasDefault.Location = new System.Drawing.Point(736, 35);
            this.btnSetasDefault.Name = "btnSetasDefault";
            this.btnSetasDefault.Size = new System.Drawing.Size(109, 16);
            this.btnSetasDefault.TabIndex = 23;
            this.btnSetasDefault.TabStop = true;
            this.btnSetasDefault.Text = "Set as Default";
            this.btnSetasDefault.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnSetasDefault_LinkClicked);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SysApplication,
            this.SysMetadata,
            this.SysVersion,
            this.AttachDB,
            this.AppName,
            this.Server,
            this.Database,
            this.Default});
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(696, 259);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Server";
            this.dataGridViewTextBoxColumn2.HeaderText = "Server";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Database";
            this.dataGridViewTextBoxColumn3.HeaderText = "Database";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // SysApplication
            // 
            this.SysApplication.DataPropertyName = "Application";
            this.SysApplication.HeaderText = "Application";
            this.SysApplication.Name = "SysApplication";
            this.SysApplication.Visible = false;
            // 
            // SysMetadata
            // 
            this.SysMetadata.DataPropertyName = "Metadata";
            this.SysMetadata.HeaderText = "Metadata";
            this.SysMetadata.Name = "SysMetadata";
            this.SysMetadata.Visible = false;
            // 
            // SysVersion
            // 
            this.SysVersion.DataPropertyName = "Version";
            this.SysVersion.HeaderText = "Version";
            this.SysVersion.Name = "SysVersion";
            this.SysVersion.Visible = false;
            // 
            // AttachDB
            // 
            this.AttachDB.DataPropertyName = "AttachDB";
            this.AttachDB.HeaderText = "AttachDB";
            this.AttachDB.Name = "AttachDB";
            this.AttachDB.Visible = false;
            // 
            // AppName
            // 
            this.AppName.DataPropertyName = "Name";
            this.AppName.HeaderText = "Name";
            this.AppName.Name = "AppName";
            this.AppName.Width = 200;
            // 
            // Server
            // 
            this.Server.DataPropertyName = "Server";
            this.Server.HeaderText = "Server";
            this.Server.Name = "Server";
            this.Server.Width = 200;
            // 
            // Database
            // 
            this.Database.DataPropertyName = "Database";
            this.Database.HeaderText = "Database";
            this.Database.Name = "Database";
            this.Database.Width = 150;
            // 
            // Default
            // 
            this.Default.DataPropertyName = "Default";
            this.Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Default.HeaderText = "Default";
            this.Default.Name = "Default";
            this.Default.ReadOnly = true;
            // 
            // SystemsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(894, 333);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SystemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Systems";
            this.Load += new System.EventHandler(this.SystemsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private DataGridView dataGridView1;
        private System.ComponentModel.IContainer components;
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        #endregion "Windows Form Designer generated code"









    }
}