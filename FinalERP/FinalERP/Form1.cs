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
    public partial class Form1 : Form
    {
        Form2 conn = new Form2();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Login", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (this.textBox1.Text == dr["Username"].ToString() && this.textBox2.Text == dr["Password"].ToString())
                {
                    ERP form = new ERP();
                    this.Hide();
                    form.Show();
                }
                else
                {
                    MessageBox.Show("Incorrect Username or Password!");
                }
            }
            conn.oleDbConnection1.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewAccount nc = new NewAccount();
            this.Hide();
            nc.Show();
        }
    }
}
