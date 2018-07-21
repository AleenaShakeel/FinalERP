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
    public partial class Capproval : Form
    {
        Form2 conn = new Form2();
        ERP er;
        public Capproval(ERP er1)
        {
            er = er1;
            InitializeComponent();
        }

        private void Capproval_Load(object sender, EventArgs e)
        {
            textBox1.Text = er.textBox62.Text;
            textBox2.Text = er.textBox61.Text;
            textBox3.Text = er.textBox60.Text;
            textBox4.Text = er.textBox57.Text;
            textBox5.Text = er.textBox56.Text;
            textBox6.Text = er.textBox55.Text;
            textBox7.Text = er.textBox54.Text;
            textBox8.Text = er.comboBox8.Text;
            textBox9.Text = er.textBox63.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Customer set Cname=@Cname,City=@City,PH1=@PH1,PH2=@PH2,ContectPerson=@ContectPerson,CreditLimit=@CreditLimit,CStatus=@CStatus where CID=@CID", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            cmd.Parameters.AddWithValue("@PH1", er.textBox59.Text);
            cmd.Parameters.AddWithValue("@PH2", er.textBox58.Text);
            cmd.Parameters.AddWithValue("@ContectPerson", textBox6.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox7.Text);
            cmd.Parameters.AddWithValue("@CStatus", "Active");
            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show("Congrats! Customer has been Approved", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            er.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Update Customer set Cname=@Cname,City=@City,CStatus=@CStatus where Cid=@cid", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@Cname", textBox2.Text);
            cmd.Parameters.AddWithValue("@City", textBox3.Text);
            cmd.Parameters.AddWithValue("@CStatus", "Inactive");
            cmd.Parameters.AddWithValue("@CID", textBox1.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show("Sorry! Customer Not Approved.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Hide();
            er.Show();
        }
    }
}
