using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;
using CommonLib;

namespace WinSBSchool.Infrastructure
{

    public class EditSystemsForm : System.Windows.Forms.Form
    {
        SBSystem _SBSystem;
        const string SystemsConfigFile = "Security/Systems.xml";
        const string FILE_NAME = "data.xml";
        XPathDocument doc;
        XPathNavigator nav;
        XPathExpression expr;
        XPathNodeIterator iterator;
        string oldTitle = "";

        public EditSystemsForm(SBSystem sbsystem)
        {
            InitializeComponent();
            _SBSystem = sbsystem;
        }

        private void EditForm_Load(object sender, System.EventArgs e)
        {

            ////doc = new XPathDocument(FILE_NAME);
            //doc = new XPathDocument(SystemsConfigFile);
            //nav = doc.CreateNavigator();

            //// Compile a standard XPath expression 
            //expr = nav.Compile("/catalog/cd/title");
            //iterator = nav.Select(expr);

            //// Iterate on the node set
            //comboBox1.Items.Clear();
            //try
            //{
            //    while (iterator.MoveNext())
            //    {
            //        XPathNavigator nav2 = iterator.Current.Clone();
            //        comboBox1.Items.Add(nav2.Value);	

            //    }
            //}
            //catch(Exception exm) 
            //{
            //    Console.WriteLine(exm.Message);
            //} 
            //comboBox1.SelectedIndex = 0;

            ////save old title 
            //oldTitle = comboBox1.Text;

            try
            {
                InitializeControls();

            }
            catch (Exception ex)
            {
                Utils.ShowError(ex);
            }
        }
        private void InitializeControls()
        {
            if (_SBSystem.Name != null)
            {
                txtName.Text = _SBSystem.Name;
            }
            if (_SBSystem.Application != null)
            {
                txtApplication.Text = _SBSystem.Application;
            }
            if (_SBSystem.Database != null)
            {
                txtDatabase.Text = _SBSystem.Database;
            }
            if (_SBSystem.AttachDB != null)
            {
                txtAttachDB.Text = _SBSystem.AttachDB;
            }
            if (_SBSystem.Server != null)
            {
                txtServer.Text = _SBSystem.Server;
            }
            if (_SBSystem.Metadata != null)
            {
                txtMetadata.Text = _SBSystem.Metadata;
            }
            if (_SBSystem.Version != null)
            {
                txtVersion.Text = _SBSystem.Version;
            }
            if (_SBSystem.Default != null)
            {
                chkDefault.Checked = _SBSystem.Default;
            }

        }
        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string str = this.txtDatabase.Text;
            if (str == "") return;

            oldTitle = str;
            expr = nav.Compile("/catalog/cd[title='" + str + "']");
            iterator = nav.Select(expr);

            if (iterator.MoveNext())
            {
                XPathNavigator nav2 = iterator.Current.Clone();
                //country.Text = nav2.GetAttribute("country","");
                //nav2.MoveToFirstChild();

                //nav2.MoveToNext();
                //artist.Text = nav2.Value;
                //nav2.MoveToNext();
                //price.Text = nav2.Value;
            }
        } 
        // insert new cd element
        private void button2_Click(object sender, System.EventArgs e)
        {

            try
            {
                XmlTextReader reader = new XmlTextReader(FILE_NAME);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();
                XmlNode currNode;

                XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
                //docFrag.InnerXml="<cd country=\"" + country.Text + "\">" + 
                //    "<title>" + this.comboBox1.Text + "</title>" + 
                //    "<artist>" + artist.Text + "</artist>" +
                //    "<price>" + price.Text + "</price>" +
                //    "</cd>"; 
                // insert the availability node into the document 
                currNode = doc.DocumentElement;
                currNode.InsertAfter(docFrag, currNode.LastChild);
                //save the output to a file 
                doc.Save(FILE_NAME);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
                this.DialogResult = DialogResult.Cancel;
            }
        } 
        //update cd node
        private void btnUpdate_Click(object sender, System.EventArgs e)
        {
            // basically the same as remove node
            try
            {
                XmlTextReader reader = new XmlTextReader(FILE_NAME);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();

                //Select the cd node with the matching title
                XmlNode oldCd;
                XmlElement root = doc.DocumentElement;
                oldCd = root.SelectSingleNode("/catalog/cd[title='" + oldTitle + "']");

                XmlElement newCd = doc.CreateElement("cd");
                //newCd.SetAttribute("country",country.Text);

                //newCd.InnerXml = "<title>" + this.comboBox1.Text + "</title>" + 
                //    "<artist>" + artist.Text + "</artist>" +
                //    "<price>" + price.Text + "</price>";

                root.ReplaceChild(newCd, oldCd);
                //save the output to a file 
                doc.Save(FILE_NAME);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
                this.DialogResult = DialogResult.Cancel;
            }
        } 
        // remove cd node
        private void button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                XmlTextReader reader = new XmlTextReader(FILE_NAME);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();

                //Select the cd node with the matching title
                XmlNode cd;
                XmlElement root = doc.DocumentElement;
                cd = root.SelectSingleNode("/catalog/cd[title='" + this.txtDatabase.Text + "']");

                root.RemoveChild(cd);
                //save the output to a file 
                doc.Save(FILE_NAME);
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region "Windows Form Designer generated code"
        private GroupBox groupBox2;
        private CheckBox chkDefault;
        private TextBox txtMetadata;
        private TextBox txtVersion;
        private TextBox txtAttachDB;
        private TextBox txtServer;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDatabase;
        private TextBox txtName;
        private TextBox txtApplication;
        private GroupBox groupBox1;
        private Button btnUpdate;
        private Button btnClose;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSystemsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.txtMetadata = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtAttachDB = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtApplication = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 296);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(365, 58);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(101, 19);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(72, 24);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(232, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 24);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkDefault);
            this.groupBox2.Controls.Add(this.txtMetadata);
            this.groupBox2.Controls.Add(this.txtVersion);
            this.groupBox2.Controls.Add(this.txtAttachDB);
            this.groupBox2.Controls.Add(this.txtServer);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtDatabase);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.txtApplication);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 296);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDefault.Location = new System.Drawing.Point(101, 255);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(92, 17);
            this.chkDefault.TabIndex = 20;
            this.chkDefault.Text = "ColumnDefault";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // txtMetadata
            // 
            this.txtMetadata.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMetadata.Location = new System.Drawing.Point(101, 185);
            this.txtMetadata.Name = "txtMetadata";
            this.txtMetadata.Size = new System.Drawing.Size(203, 20);
            this.txtMetadata.TabIndex = 19;
            // 
            // txtVersion
            // 
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersion.Location = new System.Drawing.Point(101, 216);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(203, 20);
            this.txtVersion.TabIndex = 18;
            // 
            // txtAttachDB
            // 
            this.txtAttachDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAttachDB.Location = new System.Drawing.Point(101, 123);
            this.txtAttachDB.Name = "txtAttachDB";
            this.txtAttachDB.Size = new System.Drawing.Size(203, 20);
            this.txtAttachDB.TabIndex = 16;
            // 
            // txtServer
            // 
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServer.Location = new System.Drawing.Point(101, 154);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(203, 20);
            this.txtServer.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(53, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Version";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Metadata";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Attach Db";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Database";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Application";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name";
            // 
            // txtDatabase
            // 
            this.txtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatabase.Location = new System.Drawing.Point(101, 92);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(203, 20);
            this.txtDatabase.TabIndex = 7;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(101, 30);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(203, 20);
            this.txtName.TabIndex = 4;
            // 
            // txtApplication
            // 
            this.txtApplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApplication.Location = new System.Drawing.Point(101, 61);
            this.txtApplication.Name = "txtApplication";
            this.txtApplication.Size = new System.Drawing.Size(203, 20);
            this.txtApplication.TabIndex = 5;
            // 
            // EditSystemsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(365, 354);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditSystemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.EditForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
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