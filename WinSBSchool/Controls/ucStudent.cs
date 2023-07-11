using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;


namespace WinSBSchool.Controls
{
    public partial class ucStudent : UserControl
    {
        Repository rep;
        string connection;

        public ucStudent(string Conn)
        {
            InitializeComponent();
            rep = new Repository(connection);
            if (string.IsNullOrEmpty(Conn))
                throw new ArgumentNullException("Conn");
            connection = Conn;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            


            rep.AddNewStudent(s);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void currentClassComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
