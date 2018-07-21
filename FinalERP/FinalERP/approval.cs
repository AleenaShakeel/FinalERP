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
    public partial class approval : Form
    {
        Form2 conn = new Form2();
        ERP frm2;
        public approval(ERP ff2)
        {
            frm2 = ff2;
            InitializeComponent();
        }

        private void approval_Load(object sender, EventArgs e)
        {
            this.textBox10.Text = frm2.textBox10.Text;
            this.textBox9.Text = frm2.textBox9.Text;
            this.textBox8.Text = frm2.textBox8.Text;
            this.textBox7.Text = frm2.textBox7.Text;
            this.textBox6.Text = frm2.textBox6.Text;
            this.textBox11.Text = frm2.textBox11.Text;
            this.textBox12.Text = frm2.textBox12.Text;
            this.textBox13.Text = frm2.textBox13.Text;
            this.textBox14.Text = frm2.textBox14.Text;
            this.textBox15.Text = frm2.textBox15.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into vendor(vstatus,vid,vname,vcity,ph1,ph2,vaddress,cpname,vemail,vgroup,cpph)values(@vsatus,@vid,@vname,@vcity,@ph1,@ph2,@vaddress,@cpname,@vemail,@vgroup,@cpph)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@vstatus", "Active");
            cmd.Parameters.AddWithValue("@vid", this.textBox10.Text);
            cmd.Parameters.AddWithValue("@vname", this.textBox9.Text);
            cmd.Parameters.AddWithValue("@vcity", this.textBox8.Text);
            cmd.Parameters.AddWithValue("@ph1", this.textBox7.Text);
            cmd.Parameters.AddWithValue("@ph2", this.textBox6.Text);
            cmd.Parameters.AddWithValue("@vaddress", this.textBox11.Text);
            cmd.Parameters.AddWithValue("@cpname", this.textBox12.Text);
            cmd.Parameters.AddWithValue("@vgroup", this.textBox13.Text);
            cmd.Parameters.AddWithValue("@vemail", this.textBox14.Text);
            cmd.Parameters.AddWithValue("@cpph", this.textBox15.Text);
            cmd.ExecuteNonQuery();
            this.Hide();
            MessageBox.Show("Approved! Your status is Active now.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.oleDbConnection1.Close();
            frm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into vendor(vstatus,vid,vname,vcity,ph1,ph2,vaddress,cpname,vgroup,vemail,cpph)values(@vsatus,@vid,@vname,@vcity,@ph1,@ph2,@vaddress,@cpname,@vgroup,@vemail,@cpph)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@vstatus", "Inactive");
            cmd.Parameters.AddWithValue("@evid", this.textBox10.Text);
            cmd.Parameters.AddWithValue("@vname", this.textBox9.Text);
            cmd.Parameters.AddWithValue("@vcity", this.textBox8.Text);
            cmd.Parameters.AddWithValue("@ph1", this.textBox7.Text);
            cmd.Parameters.AddWithValue("@ph2", this.textBox6.Text);
            cmd.Parameters.AddWithValue("@vaddress", this.textBox11.Text);
            cmd.Parameters.AddWithValue("@cpname", this.textBox12.Text);
            cmd.Parameters.AddWithValue("@vgroup", this.textBox13.Text);
            cmd.Parameters.AddWithValue("@vemail", this.textBox14.Text);
            cmd.Parameters.AddWithValue("@cpph", this.textBox15.Text);
            cmd.ExecuteNonQuery();
            this.Hide();
            MessageBox.Show("SORRY! Not Approved.", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            conn.oleDbConnection1.Close();
            DialogResult dr = MessageBox.Show("Do you want to try again?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Form1 frm1 = new Form1();
                frm1.Show();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
