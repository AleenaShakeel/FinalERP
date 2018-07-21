using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace FinalERP
{
    public partial class NewAccount : Form
    {
        Form2 conn = new Form2();
        public NewAccount()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into Login(username,password) values(@username,@password)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@username", textBox1.Text);
            cmd.Parameters.AddWithValue("@passowrd", textBox2.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Create Successfully!");
            conn.oleDbConnection1.Close();
            this.Hide();
            f.Show();
        }
    }
}
