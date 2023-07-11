namespace WinSBSchool.Reports.Viewer
{
    partial class SelectFontsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.txtHeaderFont = new System.Windows.Forms.TextBox();
            this.txtBodyFont = new System.Windows.Forms.TextBox();
            this.txtTableHeaderFont = new System.Windows.Forms.TextBox();
            this.txtFooterFont = new System.Windows.Forms.TextBox();
            this.txtTableBodyFont = new System.Windows.Forms.TextBox();
            this.btnHeaderFont = new System.Windows.Forms.Button();
            this.btnBodyFont = new System.Windows.Forms.Button();
            this.btnFooterFont = new System.Windows.Forms.Button();
            this.btnTableBodyFont = new System.Windows.Forms.Button();
            this.btnTableHeaderFont = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Report Header Font";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Report Body Font";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(47, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Report Footer Font";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(143, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Please Select the Fonts to Use";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(47, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Table Header Font";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(59, 194);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Table Body Font";
            // 
            // txtHeaderFont
            // 
            this.txtHeaderFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHeaderFont.Location = new System.Drawing.Point(146, 55);
            this.txtHeaderFont.Name = "txtHeaderFont";
            this.txtHeaderFont.Size = new System.Drawing.Size(476, 20);
            this.txtHeaderFont.TabIndex = 6;
            // 
            // txtBodyFont
            // 
            this.txtBodyFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBodyFont.Location = new System.Drawing.Point(146, 90);
            this.txtBodyFont.Name = "txtBodyFont";
            this.txtBodyFont.Size = new System.Drawing.Size(476, 20);
            this.txtBodyFont.TabIndex = 7;
            // 
            // txtTableHeaderFont
            // 
            this.txtTableHeaderFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableHeaderFont.Location = new System.Drawing.Point(146, 157);
            this.txtTableHeaderFont.Name = "txtTableHeaderFont";
            this.txtTableHeaderFont.Size = new System.Drawing.Size(476, 20);
            this.txtTableHeaderFont.TabIndex = 9;
            // 
            // txtFooterFont
            // 
            this.txtFooterFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFooterFont.Location = new System.Drawing.Point(146, 123);
            this.txtFooterFont.Name = "txtFooterFont";
            this.txtFooterFont.Size = new System.Drawing.Size(476, 20);
            this.txtFooterFont.TabIndex = 8;
            // 
            // txtTableBodyFont
            // 
            this.txtTableBodyFont.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTableBodyFont.Location = new System.Drawing.Point(146, 190);
            this.txtTableBodyFont.Name = "txtTableBodyFont";
            this.txtTableBodyFont.Size = new System.Drawing.Size(476, 20);
            this.txtTableBodyFont.TabIndex = 10;
            // 
            // btnHeaderFont
            // 
            this.btnHeaderFont.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnHeaderFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHeaderFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHeaderFont.Location = new System.Drawing.Point(628, 52);
            this.btnHeaderFont.Name = "btnHeaderFont";
            this.btnHeaderFont.Size = new System.Drawing.Size(35, 23);
            this.btnHeaderFont.TabIndex = 11;
            this.btnHeaderFont.Text = ": :";
            this.btnHeaderFont.UseVisualStyleBackColor = false;
            this.btnHeaderFont.Click += new System.EventHandler(this.btnHeaderFont_Click);
            // 
            // btnBodyFont
            // 
            this.btnBodyFont.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBodyFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBodyFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBodyFont.Location = new System.Drawing.Point(628, 90);
            this.btnBodyFont.Name = "btnBodyFont";
            this.btnBodyFont.Size = new System.Drawing.Size(35, 23);
            this.btnBodyFont.TabIndex = 12;
            this.btnBodyFont.Text = ": :";
            this.btnBodyFont.UseVisualStyleBackColor = false;
            this.btnBodyFont.Click += new System.EventHandler(this.btnBodyFont_Click);
            // 
            // btnFooterFont
            // 
            this.btnFooterFont.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnFooterFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFooterFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFooterFont.Location = new System.Drawing.Point(628, 121);
            this.btnFooterFont.Name = "btnFooterFont";
            this.btnFooterFont.Size = new System.Drawing.Size(35, 23);
            this.btnFooterFont.TabIndex = 13;
            this.btnFooterFont.Text = ": :";
            this.btnFooterFont.UseVisualStyleBackColor = false;
            this.btnFooterFont.Click += new System.EventHandler(this.btnFooterFont_Click);
            // 
            // btnTableBodyFont
            // 
            this.btnTableBodyFont.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTableBodyFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTableBodyFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableBodyFont.Location = new System.Drawing.Point(628, 188);
            this.btnTableBodyFont.Name = "btnTableBodyFont";
            this.btnTableBodyFont.Size = new System.Drawing.Size(35, 23);
            this.btnTableBodyFont.TabIndex = 14;
            this.btnTableBodyFont.Text = ": :";
            this.btnTableBodyFont.UseVisualStyleBackColor = false;
            this.btnTableBodyFont.Click += new System.EventHandler(this.btnTableBodyFont_Click);
            // 
            // btnTableHeaderFont
            // 
            this.btnTableHeaderFont.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnTableHeaderFont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTableHeaderFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTableHeaderFont.Location = new System.Drawing.Point(628, 155);
            this.btnTableHeaderFont.Name = "btnTableHeaderFont";
            this.btnTableHeaderFont.Size = new System.Drawing.Size(35, 23);
            this.btnTableHeaderFont.TabIndex = 15;
            this.btnTableHeaderFont.Text = ": :";
            this.btnTableHeaderFont.UseVisualStyleBackColor = false;
            this.btnTableHeaderFont.Click += new System.EventHandler(this.btnTableHeaderFont_Click);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(243, 240);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(56, 23);
            this.btnOk.TabIndex = 16;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btClose
            // 
            this.btClose.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(472, 240);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(64, 23);
            this.btClose.TabIndex = 17;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = false;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // SelectFontsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(698, 284);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnTableHeaderFont);
            this.Controls.Add(this.btnTableBodyFont);
            this.Controls.Add(this.btnFooterFont);
            this.Controls.Add(this.btnBodyFont);
            this.Controls.Add(this.btnHeaderFont);
            this.Controls.Add(this.txtTableBodyFont);
            this.Controls.Add(this.txtTableHeaderFont);
            this.Controls.Add(this.txtFooterFont);
            this.Controls.Add(this.txtBodyFont);
            this.Controls.Add(this.txtHeaderFont);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SelectFontsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Fonts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.TextBox txtHeaderFont;
        private System.Windows.Forms.TextBox txtBodyFont;
        private System.Windows.Forms.TextBox txtTableHeaderFont;
        private System.Windows.Forms.TextBox txtFooterFont;
        private System.Windows.Forms.TextBox txtTableBodyFont;
        private System.Windows.Forms.Button btnHeaderFont;
        private System.Windows.Forms.Button btnBodyFont;
        private System.Windows.Forms.Button btnFooterFont;
        private System.Windows.Forms.Button btnTableBodyFont;
        private System.Windows.Forms.Button btnTableHeaderFont;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btClose;
    }
}