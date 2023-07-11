using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace WinSchool.Forms.UpdateSystems
{
	/// <summary>
	/// Summary description for EditForm.
	/// </summary>
	public class EditSystemsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox cboName;
		private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtAttachDB;
        private TextBox txtVersion;
        private TextBox txtMetaData;
        private Label label7;
        private Label label8;
        private CheckBox chkDefault;
        private TextBox txtServer;
        private Label label4;
        private Button btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EditSystemsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtAttachDB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cboName = new System.Windows.Forms.ComboBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtMetaData = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "System Name:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(26, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Database:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(20, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "AttachDB:";
            // 
            // txtDatabase
            // 
            this.txtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDatabase.Location = new System.Drawing.Point(90, 58);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(193, 20);
            this.txtDatabase.TabIndex = 4;
            // 
            // txtAttachDB
            // 
            this.txtAttachDB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAttachDB.Location = new System.Drawing.Point(90, 93);
            this.txtAttachDB.Name = "txtAttachDB";
            this.txtAttachDB.Size = new System.Drawing.Size(193, 20);
            this.txtAttachDB.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(29, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 24);
            this.button1.TabIndex = 8;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(109, 287);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 24);
            this.button2.TabIndex = 9;
            this.button2.Text = "Insert";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(180, 287);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(58, 24);
            this.button3.TabIndex = 10;
            this.button3.Text = "Remove";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // cboName
            // 
            this.cboName.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboName.Location = new System.Drawing.Point(90, 22);
            this.cboName.Name = "cboName";
            this.cboName.Size = new System.Drawing.Size(193, 21);
            this.cboName.TabIndex = 11;
            this.cboName.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // txtVersion
            // 
            this.txtVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVersion.Location = new System.Drawing.Point(90, 198);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(193, 20);
            this.txtVersion.TabIndex = 13;
            // 
            // txtMetaData
            // 
            this.txtMetaData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMetaData.Location = new System.Drawing.Point(90, 163);
            this.txtMetaData.Name = "txtMetaData";
            this.txtMetaData.Size = new System.Drawing.Size(193, 20);
            this.txtMetaData.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(20, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Metadata:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(38, 198);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Version:";
            // 
            // chkDefault
            // 
            this.chkDefault.AutoSize = true;
            this.chkDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkDefault.Location = new System.Drawing.Point(99, 244);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new System.Drawing.Size(57, 17);
            this.chkDefault.TabIndex = 18;
            this.chkDefault.Text = "Default";
            this.chkDefault.UseVisualStyleBackColor = true;
            // 
            // txtServer
            // 
            this.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServer.Location = new System.Drawing.Point(90, 128);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(193, 20);
            this.txtServer.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(38, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 21;
            this.label4.Text = "Server:";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(261, 287);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(47, 24);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close:";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // EditSystemsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(320, 323);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkDefault);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.txtMetaData);
            this.Controls.Add(this.cboName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtAttachDB);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditSystemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Xml";
            this.Load += new System.EventHandler(this.EditSystemsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        const string FILE_NAME = "Security/Systems.xml";
		XPathDocument doc;
		XPathNavigator nav;
		XPathExpression expr; 
		XPathNodeIterator iterator;

        private void EditSystemsForm_Load(object sender, System.EventArgs e)
		{
			doc = new XPathDocument(FILE_NAME);
			nav = doc.CreateNavigator();
			
			// Compile a standard XPath expression
            expr = nav.Compile("/System");

			iterator = nav.Select(expr);
			
			// Iterate on the node set
			cboName.Items.Clear();
			try
			{
				while (iterator.MoveNext())
				{
					XPathNavigator nav2 = iterator.Current.Clone();
					cboName.Items.Add(nav2.Value);	
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
			} 
            //comboBox1.SelectedIndex = 0;

			//save old title 
			oldTitle = cboName.Text;
		}

		string oldTitle="";

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string str = cboName.Text;
			if(str=="") return;

			oldTitle = str;
            expr = nav.Compile("/Systems/System/Database[Name='" + str + "']");
			iterator = nav.Select(expr);

			if(iterator.MoveNext())
			{
				XPathNavigator nav2 = iterator.Current.Clone();
                txtDatabase.Text = nav2.GetAttribute("Database", "");
				nav2.MoveToFirstChild();				
				nav2.MoveToNext();
                txtAttachDB.Text = nav2.Value;
				nav2.MoveToNext();
                txtServer.Text = nav2.Value;
                nav2.MoveToNext();
                txtMetaData.Text = nav2.Value;
                nav2.MoveToNext();
                txtVersion.Text = nav2.Value;
                nav2.MoveToNext();
                //chkDefault.Checked = nav2.Value;

			}
		}

		// insert new cd element
        private void btnInsert_Click(object sender, System.EventArgs e)
        {

            try
            {
                XmlTextReader reader = new XmlTextReader(FILE_NAME);
                XmlDocument doc = new XmlDocument();
                doc.Load(reader);
                reader.Close();
                XmlNode currNode;

                XmlDocumentFragment docFrag = doc.CreateDocumentFragment();
                docFrag.InnerXml =
                "<Name>" +  cboName.Text + "</Name>" +
                "<Database>" + txtDatabase.Text  + "</Database>" +
                "<AttachDB>" + txtAttachDB.Text + "</AttachDB>" +
                "<Server>" + txtServer.Text + "</Server>" +
                "<Metadata>" + txtMetaData.Text + "</Metadata>" +
                "<Version>" + txtVersion.Text + "</Version>" +
                "<Default>" + chkDefault.Checked.ToString() + "</Default>";

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
				newCd.SetAttribute("country",txtServer.Text);
				
				newCd.InnerXml = "<title>" + this.cboName.Text + "</title>" + 
					"<artist>" + txtDatabase.Text + "</artist>" +
					"<price>" + txtAttachDB.Text + "</price>";
					
				root.ReplaceChild(newCd, oldCd);
				//save the output to a file 
				doc.Save(FILE_NAME); 
				this.DialogResult = DialogResult.OK;
			} 
			catch (Exception ex) 
			{ 
				Console.WriteLine ("Exception: {0}", ex.ToString());
				this.DialogResult = DialogResult.Cancel;
			} 
		}

		// remove cd node
		private void btnRemove_Click(object sender, System.EventArgs e)
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
				cd = root.SelectSingleNode("/catalog/cd[title='" + this.cboName.Text + "']");

				root.RemoveChild(cd);
				//save the output to a file 
				doc.Save(FILE_NAME); 
				this.DialogResult = DialogResult.OK;
			} 
			catch (Exception ex) 
			{ 
				Console.WriteLine ("Exception: {0}", ex.ToString());
				this.DialogResult = DialogResult.Cancel;
			} 
		}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

	
	}
}
