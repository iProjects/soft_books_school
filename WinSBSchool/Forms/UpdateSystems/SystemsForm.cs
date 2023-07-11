using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Xml;
using System.Xml.XPath;
using System.IO;

namespace WinSchool.Forms.UpdateSystems
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class SystemsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnCLose;
		private System.Windows.Forms.TextBox txtSourceXMLData;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnEditNode;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SystemsForm()
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
				if (components != null) 
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
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCLose = new System.Windows.Forms.Button();
            this.txtSourceXMLData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEditNode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(312, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 24);
            this.button1.TabIndex = 0;
            this.button1.Text = "/catalog/cd/price";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Location = new System.Drawing.Point(304, 152);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(184, 93);
            this.listBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(312, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 24);
            this.button2.TabIndex = 2;
            this.button2.Text = "/catalog/cd[price>10.80]";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCLose
            // 
            this.btnCLose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnCLose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCLose.Location = new System.Drawing.Point(400, 112);
            this.btnCLose.Name = "btnCLose";
            this.btnCLose.Size = new System.Drawing.Size(64, 24);
            this.btnCLose.TabIndex = 3;
            this.btnCLose.Text = "Close";
            this.btnCLose.UseVisualStyleBackColor = false;
            this.btnCLose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtSourceXMLData
            // 
            this.txtSourceXMLData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSourceXMLData.Location = new System.Drawing.Point(16, 40);
            this.txtSourceXMLData.Multiline = true;
            this.txtSourceXMLData.Name = "txtSourceXMLData";
            this.txtSourceXMLData.ReadOnly = true;
            this.txtSourceXMLData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSourceXMLData.Size = new System.Drawing.Size(264, 216);
            this.txtSourceXMLData.TabIndex = 4;
            this.txtSourceXMLData.Text = "textBox1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "source xml data:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(304, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "result:";
            // 
            // btnEditNode
            // 
            this.btnEditNode.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnEditNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditNode.Location = new System.Drawing.Point(312, 80);
            this.btnEditNode.Name = "btnEditNode";
            this.btnEditNode.Size = new System.Drawing.Size(152, 24);
            this.btnEditNode.TabIndex = 9;
            this.btnEditNode.Text = "Edit Node";
            this.btnEditNode.UseVisualStyleBackColor = false;
            this.btnEditNode.Click += new System.EventHandler(this.btnEditNode_Click);
            // 
            // SystemsForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(504, 269);
            this.Controls.Add(this.btnEditNode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSourceXMLData);
            this.Controls.Add(this.btnCLose);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Name = "SystemsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Systems";
            this.Load += new System.EventHandler(this.SystemsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new SystemsForm());
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
            GetElements("/Systems/System/Name");
		}

		private void GetElements(string expression)
		{
            string fileName = "Security/Systems.xml";
			XPathDocument doc = new XPathDocument(fileName);
			XPathNavigator nav = doc.CreateNavigator();
			
			// Compile a standard XPath expression
			XPathExpression expr; 
			expr = nav.Compile(expression);
			XPathNodeIterator iterator = nav.Select(expr);

			// Iterate on the node set
			listBox1.Items.Clear();
			try
			{
				while (iterator.MoveNext())
				{
					XPathNavigator nav2 = iterator.Current.Clone();

					listBox1.Items.Add("System: " + nav2.Value);				
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
			} 
		}
		private void button2_Click(object sender, System.EventArgs e)
		{
			listBox1.Items.Clear();

            string fileName = "Security/Systems.xml";
			XPathDocument doc = new XPathDocument(fileName);
			XPathNavigator nav = doc.CreateNavigator();
			
			// Compile a standard XPath expression
			XPathExpression expr;
            expr = nav.Compile("/Systems/System");
			XPathNodeIterator iterator = nav.Select(expr);

			// Iterate on the node set
			listBox1.Items.Clear();
			try
			{
				while (iterator.MoveNext())
				{
					XPathNavigator nav2 = iterator.Current.Clone();

					nav2.MoveToFirstChild();
                    listBox1.Items.Add("Name: " + nav2.Value);
					nav2.MoveToNext();
                    listBox1.Items.Add("Database: " + nav2.Value);
					nav2.MoveToNext();
                    listBox1.Items.Add("AttachDB: " + nav2.Value);
                    nav2.MoveToNext();
                    listBox1.Items.Add("Server: " + nav2.Value);
                    nav2.MoveToNext();
                    listBox1.Items.Add("Metadata: " + nav2.Value);
                    nav2.MoveToNext();
                    listBox1.Items.Add("Version: " + nav2.Value);
                    nav2.MoveToNext();
                    listBox1.Items.Add("Default: " + nav2.Value);	
				}
			}
			catch(Exception ex) 
			{
				Console.WriteLine(ex.Message);
			} 
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
            this.Close();
		}

        const string FILE_NAME = "Security/Systems.xml";
        private void SystemsForm_Load(object sender, System.EventArgs e)
		{
			
			LoadXml(FILE_NAME);
		}

		private void LoadXml(string FILE_NAME)
		{
			if (!File.Exists(FILE_NAME)) 
			{
				Console.WriteLine("{0} does not exist.", FILE_NAME);
				return;
			}
			StreamReader sr = File.OpenText(FILE_NAME);
			String input;
			
			input = sr.ReadToEnd();
			sr.Close();
			txtSourceXMLData.Text = input;
		}
		private void btnEditNode_Click(object sender, System.EventArgs e)
		{
			EditSystemsForm edit = new EditSystemsForm();
			DialogResult result = edit.ShowDialog();
			if(result==DialogResult.OK)
			{
				LoadXml(FILE_NAME);
			}
		}

        
	}
}
