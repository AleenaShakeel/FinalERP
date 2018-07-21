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
    public partial class ERP : Form
    {
        Form2 conn = new Form2();
        string[] pid = new string[50];
        int[] pqty = new int[50];
        int[] pprice = new int[50];
        string[] Sid = new string[50];
        int[] qty = new int[50];
        int[] Oprice = new int[50];
        int counter = 0;
        int count = 0;
        public ERP()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //INVOICE
            tabControl1.Visible = true;
            tabControl1.SelectedTab = Invoice;

            int c = 0;

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from Invoice ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }

            textBox34.Text = "0" + c.ToString(); //+ "-" + System.DateTime.Today.Year; 
            OleDbCommand cmdd = new OleDbCommand("Select GRNID from GRN where Status ='Open' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox6.Items.Add(drr["GRNID"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = InvoiceReceiveable;

            //Invoice Receiveable ID Generate
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(InvoiceID) from InvoiceR ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox87.Text = "0" + c.ToString() + "-" + System.DateTime.Today.Year;

            OleDbCommand cmdd = new OleDbCommand("Select DCID from DelChalan where Status ='Open' ", conn.oleDbConnection1);
            OleDbDataReader drr = cmdd.ExecuteReader();

            while (drr.Read())
            {
                comboBox13.Items.Add(drr["DCID"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = DeliveryChalan;

            //ID generate
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(DCID) from DelChalan ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox75.Text = "DC-0" + c.ToString() + "-" + System.DateTime.Today.Year;

            OleDbCommand cmd1 = new OleDbCommand("Select SOID from SO where Status = 'Open' ", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                comboBox12.Items.Add(dr1["SOID"]).ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = SO;

            OleDbDataAdapter da = new OleDbDataAdapter("Select * from products", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView4.DataSource = dt;
            dataGridView4.ReadOnly = true;

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select Deptname from Dept ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox10.Items.Add(dr["Deptname"]).ToString();
            }


            OleDbCommand cmd1 = new OleDbCommand("Select CID from Customer where CStatus = 'Active' ", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                comboBox11.Items.Add(dr1["CID"]).ToString();
            }


            OleDbCommand cmd2 = new OleDbCommand("Select Pid from Products ", conn.oleDbConnection1);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                comboBox9.Items.Add(dr2["Pid"]).ToString();
            }

            conn.oleDbConnection1.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.button11.Visible = false;
            this.button12.Visible = false;
            this.button17.Visible = true;
            this.button18.Visible = true;
            tabControl1.Visible = true;
            tabControl1.SelectedTab = Customer;

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select cid from customer", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox7.Items.Clear();
                comboBox7.Items.Add(dr["cid"]);
            }
            conn.oleDbConnection1.Close();

            //int c = 0;
            //conn.oleDbConnection1.Open();
            //OleDbCommand cmd1 = new OleDbCommand("select count(CID) from Customer ", conn.oleDbConnection1);
            //OleDbDataReader dr1 = cmd.ExecuteReader();
            //if (dr1.Read())
            //{
            //    c = Convert.ToInt32(dr1[0]);
            //    c++;
            //}

            //textBox62.Text = "C-0" + c.ToString(); //+ "-" + System.DateTime.Today.Year; 
            //conn.oleDbConnection1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = GRN;

            ////GRN ID
            //int c = 0;
            //conn.oleDbConnection1.Open();
            //OleDbCommand cmd = new OleDbCommand("select count(GRNID) from GRN ", conn.oleDbConnection1);
            //OleDbDataReader dr = cmd.ExecuteReader();
            //if (dr.Read())
            //{
            //    c = Convert.ToInt32(dr[0]);
            //    c++;
            //}

            //textBox24.Text = "GRN-0" + c.ToString();

            //PO ID ComboBox
            conn.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select poid from po where status = 'open'", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                this.comboBox5.Items.Add(dr1["poid"]);
            }
            conn.oleDbConnection1.Close();
        }

        private void ERP_Load(object sender, EventArgs e)
        {
            tabControl1.Visible = false;
            this.button11.Visible = false;
            this.button12.Visible = false;
            this.button17.Visible = false;
            this.button18.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.Visible = true;
            tabControl1.SelectedTab = SearchVendor;
            this.button11.Visible = true;
            this.button12.Visible = true;
            this.button17.Visible = false;
            this.button18.Visible = false;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select vid from vendor", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox1.Items.Add(dr["vid"]);
            }
            conn.oleDbConnection1.Close();

            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select count(vid) from vendor", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                c = Convert.ToInt32(dr1[0]);
                c++;
            }
            this.textBox10.Text = "V-0" + c.ToString();
            conn.oleDbConnection1.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            approval app = new approval(this);
            this.Hide();
            app.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button11.Visible = false;
            button12.Visible = false;
            tabControl1.Visible = true;
            tabControl1.SelectedTab = PurchaseOrder;

            OleDbDataAdapter da = new OleDbDataAdapter("Select * from products", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;

            //vendor id
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select vid from vendor where vstatus= 'active'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                this.comboBox2.Items.Add(dr["vid"]);
            }
            conn.oleDbConnection1.Close();

            //DEPARTMENT
            conn.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select * from dept", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            while (dr1.Read())
            {
                this.comboBox3.Items.Add(dr1["deptname"]);
            }
            conn.oleDbConnection1.Close();

            //PRODUCT ID
            conn.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("Select * from products", conn.oleDbConnection1);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                this.comboBox4.Items.Add(dr2["pid"]);
            }
            conn.oleDbConnection1.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = SearchVendor;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = AddVendor;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void PurchaseOrder_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from vendor where vid='" + this.comboBox2.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox16.Text = dr["vname"].ToString();
                this.textBox17.Text = dr["vcity"].ToString();
                this.textBox18.Text = dr["ph1"] + " , " + dr["ph2"].ToString();
                this.textBox19.Text = dr["vemail"].ToString();
                this.textBox20.Text = dr["vgroup"].ToString();
                this.textBox21.Text = dr["cpname"].ToString();
                this.textBox22.Text = dr["cpph"].ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DEPART ID GENERATE (PO ID)
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select count(vid) from PO", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            this.textBox29.Text = comboBox3.Text + "-" + c.ToString() + "-" + System.DateTime.Today.Year;
            conn.oleDbConnection1.Close();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select baseprice from products where pid='" + comboBox4.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox26.Text = dr["baseprice"].ToString();
            }
            conn.oleDbConnection1.Close();
            textBox27.Clear();
            textBox25.Clear();
        }

        private void button14_Click(object sender, EventArgs e)
        {
              //CREATE PURCHASE ORDER
            int s = 0;
            foreach (int p in pprice)
            {
                s = s + p;
            }

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into po(poid,podate,ddate,approve,vdept,vname,vid,vcontectperson,vcpph,TotalAmount,status)values(@poid,@podate,@ddate,@approve,@vdept,@vname,@vid,@vcontectperson,@vcpph,@TotalAmount,@status)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@poid", textBox29.Text);
            cmd.Parameters.AddWithValue("@podate", dateTimePicker1);
            cmd.Parameters.AddWithValue("@ddate", dateTimePicker2);
            cmd.Parameters.AddWithValue("@approve", "Approved");
            cmd.Parameters.AddWithValue("@vdept", textBox20.Text);
            cmd.Parameters.AddWithValue("@vname", textBox16.Text);
            cmd.Parameters.AddWithValue("@vid", comboBox2.Text);
            cmd.Parameters.AddWithValue("@vcontectperson", textBox21.Text);
            cmd.Parameters.AddWithValue("@vccph", textBox22.Text);
            cmd.Parameters.AddWithValue("@TotalAmount", s.ToString());
            cmd.Parameters.AddWithValue("@status", "Open");
            cmd.ExecuteNonQuery();

            for (int i = 0; i < counter; i++) 
            {
                //conn.oleDbConnection1.Open();
                OleDbCommand cmd1 = new OleDbCommand("Insert into POProducts(POID,Pid,PQty,tprice)values(@POID,@Pid,@PQty,@tprice)", conn.oleDbConnection1);
                cmd1.Parameters.AddWithValue("@POID", textBox29.Text);
                cmd1.Parameters.AddWithValue("@Pid", pid[i]);
                cmd1.Parameters.AddWithValue("@PQty", pqty[i]);
                cmd1.Parameters.AddWithValue("@tprice", pprice[i]);
                cmd1.ExecuteNonQuery();
               // conn.oleDbConnection1.Close();
            }

            conn.oleDbConnection1.Close();
            MessageBox.Show("Your Purchase Order Process Completed! Thank You", "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int ppqty = Convert.ToInt32(textBox27.Text);
            int ptprice = Convert.ToInt32(textBox26.Text);
            int ptotal = ppqty * ptprice;
            textBox25.Text = ptotal.ToString();

            //pid[counter] = comboBox4.Text;
            //pqty[counter] = Convert.ToInt32(textBox22.Text);
            //tprice[counter] = Convert.ToInt32(textBox24.Text);
            textBox23.Text += "Product id: " + comboBox4.Text + Environment.NewLine;
            textBox23.Text += "Product Quantity: " + textBox27.Text + Environment.NewLine;
            textBox23.Text += "Product Price: " + textBox26.Text + Environment.NewLine;
            textBox23.Text += "Total Price: " + textBox25.Text + Environment.NewLine;
            textBox23.Text += "***************************************" + Environment.NewLine;

            pid[counter] = comboBox4.Text;
            pqty[counter] = Convert.ToInt32(textBox27.Text);
            pprice[counter] = Convert.ToInt32(textBox25.Text);
            counter++;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into grn(grnid,poid,status,vname,ddate,grdate,vid)values(@grnid,@poid,@status,@vname,@ddate,@grdate,@vid)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("grnid", textBox24.Text);
            cmd.Parameters.AddWithValue("poid", comboBox5.Text);
            cmd.Parameters.AddWithValue("status", "Open");
            cmd.Parameters.AddWithValue("vname", textBox32.Text);
            cmd.Parameters.AddWithValue("ddate", textBox31.Text);
            cmd.Parameters.AddWithValue("grdate", dateTimePicker3.Text);
            cmd.Parameters.AddWithValue("vid", textBox33.Text);
            cmd.ExecuteNonQuery();
            OleDbCommand cmd1 = new OleDbCommand("Update PO set Status= 'Close'  where POID ='" + comboBox5.Text + "'", conn.oleDbConnection1);
            cmd1.ExecuteNonQuery();

            DialogResult dr = MessageBox.Show("Your GRN Added! Do you want to continue?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (dr == DialogResult.Yes)
            {
                this.Show();
            }
            if (dr == DialogResult.No)
            {
                Application.Exit();
            }
            conn.oleDbConnection1.Close();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from po where poid='" + comboBox5.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox33.Text = dr["vid"].ToString();
                textBox32.Text = dr["vname"].ToString();
                textBox31.Text = dr["ddate"].ToString();
            }
            conn.oleDbConnection1.Close();

            //Product ID TextBox
            conn.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select * from poproducts where poid='" + comboBox5.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox28.Text = dr1["pid"].ToString();
                textBox30.Text = dr1["pqty"].ToString();
            }
            conn.oleDbConnection1.Close();

            //GRN ID Generate
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("Select count(grnid) from grn", conn.oleDbConnection1);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            if (dr2.Read())
            {
                c = Convert.ToInt32(dr2[0]);
                c++;
            }
            //this.textBox46.Text = this.textBox48.Text + "-" + c.ToString() + "-" + System.DateTime.Today.Year;
            if (this.textBox32.Text == "RAD enterprise")
            {
                this.textBox24.Text = "RAD-0" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            else if (this.textBox32.Text == "Lifo sales")
            {
                this.textBox24.Text = "Lif-0" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            else if (this.textBox32.Text == "ROC HR")
            {
                this.textBox24.Text = "ROC-0" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            else
            {
                this.textBox24.Text = this.textBox32.Text + "-0" + c.ToString() + "-" + System.DateTime.Today.Year;
            }
            conn.oleDbConnection1.Close();

            //Data Gridview
            OleDbDataAdapter da = new OleDbDataAdapter("Select * from poproducts where poid='" + comboBox5.Text + "'", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from GRN where GRNID = '" + comboBox6.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {

                textBox35.Text = dr["GRDate"].ToString();
                textBox37.Text = dr["POID"].ToString();
                textBox38.Text = dr["VID"].ToString();
                textBox39.Text = dr["VName"].ToString();

            }
            conn.oleDbConnection1.Close();
            conn.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select * from PO where poid='" + textBox37.Text + "'", conn.oleDbConnection1);
            cmd1.Parameters.AddWithValue("VName", textBox39.Text);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox36.Text = dr1["TotalAmount"].ToString();
            }
            conn.oleDbConnection1.Close();

            OleDbDataAdapter da = new OleDbDataAdapter("Select Pid , PQty  from POProducts where POID ='" + textBox37.Text + "'", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            conn.oleDbConnection1.Close();
            
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox36.Text);
            int disc = Convert.ToInt32(textBox42.Text);
            int discount = (price * disc) / 100;
            int d = price - discount;
            textBox43.Text = d.ToString();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Invoice(InvoiceID,VendorID,VendorName,GRNDate,CDate,AmountPayable,GRNID) values(@InvoiceID,@VendorID,@VendorName,@GRNDate,@CDate,@AmountPayable,@GRNID)", conn.oleDbConnection1);

            cmd.Parameters.AddWithValue("@InvoiceID", textBox34.Text);
            cmd.Parameters.AddWithValue("@VendorID", textBox38.Text);
            cmd.Parameters.AddWithValue("@VendorName", textBox39.Text);
            cmd.Parameters.AddWithValue("@GRNDate", textBox35.Text.ToString());
            cmd.Parameters.AddWithValue("@CDate", dateTimePicker4);
            cmd.Parameters.AddWithValue("@AmountPayable", textBox43.Text);
            cmd.Parameters.AddWithValue("@GRNID", comboBox6.Text);
            cmd.ExecuteNonQuery();

            OleDbCommand cmd1 = new OleDbCommand("Update GRN set Status= 'Close'  where GRNID ='" + comboBox6.Text + "'", conn.oleDbConnection1);
            cmd1.ExecuteNonQuery();  

            conn.oleDbConnection1.Close();
            MessageBox.Show("Invoice Created Successfully!");
        }
        private object Int32(string p)
        {
            throw new NotImplementedException();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = Customer;
        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from customer where cid='" + comboBox7.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox48.Text = dr["cname"].ToString();
                this.textBox47.Text = dr["city"].ToString();
                this.textBox46.Text = dr["ph1"] + " , " + dr["ph2"].ToString();
                this.textBox45.Text = dr["contectperson"].ToString();
                this.textBox44.Text = dr["cpph"].ToString();
                this.textBox49.Text = dr["cemail"].ToString();
                this.textBox50.Text = dr["creditlimit"].ToString();
                this.textBox51.Text = dr["cstatus"].ToString();
                this.textBox52.Text = dr["cgroup"].ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = AddCustomer;
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select count(cid) from customer", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                c = Convert.ToInt32(dr1[0]);
                c++;
            }
            this.textBox62.Text = "C-" + c.ToString();
            conn.oleDbConnection1.Close();

            //Group Combo Generate
            conn.oleDbConnection1.Open();
            OleDbCommand cmd2 = new OleDbCommand("Select deptname from dept", conn.oleDbConnection1);
            OleDbDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                this.comboBox8.Items.Add(dr2["deptname"]);
            }
            conn.oleDbConnection1.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from vendor where vid='" + comboBox1.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox1.Text = dr["vname"].ToString();
                this.textBox2.Text = dr["vcity"].ToString();
                this.textBox3.Text = dr["ph1"] + " , " + dr["ph2"].ToString();
                this.textBox4.Text = dr["vstatus"].ToString();
                this.textBox5.Text = dr["vemail"].ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Customer (CID,Cname,CAddress,City,PH1,PH2,ContectPerson,CPPH,CEmail,CreditLimit,CStatus,CGroup) values(@CID,@Cname,@CAddress,@City,@PH1,@PH2,@ContectPerson,@CPPH,@CEmail,@CreditLimit,@CStatus,@CGroup)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@CID", textBox62.Text);
            cmd.Parameters.AddWithValue("@Cname", textBox61.Text);
            cmd.Parameters.AddWithValue("@CAddress", textBox63.Text);
            cmd.Parameters.AddWithValue("@City", textBox60.Text);
            cmd.Parameters.AddWithValue("@PH1", textBox59.Text);
            cmd.Parameters.AddWithValue("@PH2", textBox58.Text);
            cmd.Parameters.AddWithValue("@ContectPerson", textBox55.Text);
            cmd.Parameters.AddWithValue("@CPPH", textBox57.Text);
            cmd.Parameters.AddWithValue("@CEmail", textBox56.Text);
            cmd.Parameters.AddWithValue("@CreditLimit", textBox54.Text);
            cmd.Parameters.AddWithValue("@CStatus", "Inactive");
            cmd.Parameters.AddWithValue("@CGroup", comboBox8.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show(" Sent for Approval", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Hide();
            Capproval capprove = new Capproval(this);
            capprove.Show();
        }

        private void textBox59_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from Customer where Cid='" + this.comboBox11.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox72.Text = dr["Cname"].ToString();
                this.textBox71.Text = dr["city"].ToString();
                this.textBox70.Text = dr["ph1"] + " , " + dr["ph2"].ToString();
                this.textBox69.Text = dr["cemail"].ToString();
                this.textBox68.Text = dr["cgroup"].ToString();
                this.textBox67.Text = dr["contectperson"].ToString();
                this.textBox66.Text = dr["cpph"].ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            int c = 0;
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("select count(SOID) from SO", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                c = Convert.ToInt32(dr[0]);
                c++;
            }
            textBox65.Text = comboBox10.Text + "-" + c.ToString() + "-" + System.DateTime.Today.Year;
            conn.oleDbConnection1.Close();
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select baseprice from products where pid='" + comboBox9.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.textBox53.Text = dr["baseprice"].ToString();
            }
            conn.oleDbConnection1.Close();
            textBox64.Clear();
            textBox41.Clear();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            int tprice;
            int puprice = Convert.ToInt32(textBox53.Text);
            int pqty = Convert.ToInt32(textBox64.Text);
            tprice = pqty * puprice;
            textBox41.Text = tprice.ToString();

            textBox40.Text += "Product id: " + comboBox9.Text + Environment.NewLine;
            textBox40.Text += "Product Quantity: " + textBox64.Text + Environment.NewLine;
            textBox40.Text += "Product Price: " + textBox53.Text + Environment.NewLine;
            textBox40.Text += "Total Price: " + textBox41.Text + Environment.NewLine;
            textBox40.Text += "***************************************" + Environment.NewLine;

            Sid[count] = comboBox9.Text.ToString();
            qty[count] = Convert.ToInt32(textBox64.Text);
            Oprice[count] = Convert.ToInt32(textBox41.Text);
            count++;
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {
            //CREATE SO

            int s = 0;
            foreach (int p in Oprice)
            {
                s = p + s;
            }

            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into SO(SOID,SODate,DDate,Status,Approve,CDept,CName,CID,CCPPH,PRICE) values(@SOID,@SODate,@DDate,@Status,@Approve,@CDept,@CName,@CID,@CCPPH,@PRICE)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@SOID", textBox65.Text);
            cmd.Parameters.AddWithValue("@SODate", dateTimePicker6);
            cmd.Parameters.AddWithValue("@DDate", dateTimePicker5);
            cmd.Parameters.AddWithValue("@Status", "Open");
            cmd.Parameters.AddWithValue("@Approve", "Approved");
            cmd.Parameters.AddWithValue("@CDept", comboBox10.Text);
            cmd.Parameters.AddWithValue("@CName", textBox72.Text);
            cmd.Parameters.AddWithValue("@CID", comboBox11.Text);
            cmd.Parameters.AddWithValue("@CCPPH", textBox66.Text);
            cmd.Parameters.AddWithValue("@PRICE", s);
            cmd.ExecuteNonQuery();

            for (int i = 0; i < count; i++)
            {
                OleDbCommand cmd1 = new OleDbCommand("insert into SOProducts(SOID,Pid,PQty,TPPRICE) values(@SOID,@Pid,@PQty,@TPPRICE)", conn.oleDbConnection1);
                cmd1.Parameters.AddWithValue("@SOID", textBox65.Text);
                cmd1.Parameters.AddWithValue("@Pid", Sid[i]);
                cmd1.Parameters.AddWithValue("@PQty", qty[i]);
                cmd1.Parameters.AddWithValue("@TPPRICE", Oprice[i]);
                cmd1.ExecuteNonQuery();
            }
            conn.oleDbConnection1.Close();
            MessageBox.Show("Transaction Complete Successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from SO where SOID ='" + comboBox12.Text + "' ", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox78.Text = dr["CID"].ToString();
                textBox77.Text = dr["CName"].ToString();
                textBox79.Text = dr["SODate"].ToString();
                textBox76.Text = dr["DDate"].ToString();
            }

            OleDbDataAdapter da = new OleDbDataAdapter("Select  * from SOProducts where SOID ='" + comboBox12.Text + "' ", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView5.DataSource = dt;
            conn.oleDbConnection1.Close();

            conn.oleDbConnection1.Open();
            OleDbCommand cmd1 = new OleDbCommand("Select * from soproducts where soid='" + comboBox12.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox74.Text = dr1["pid"].ToString();
                textBox73.Text = dr1["pqty"].ToString();
            }
            conn.oleDbConnection1.Close();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Insert into DelChalan(DCID,SOID,Status,CName,DDate,DCDate,CID) values(@DCID,@SOID,@Status,@CName,@DDate,@DCDate,@CID)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@DCID", textBox75.Text);
            cmd.Parameters.AddWithValue("@SOID", comboBox12.Text);
            cmd.Parameters.AddWithValue("@Status", "Open");
            cmd.Parameters.AddWithValue("@CName", textBox77.Text);
            cmd.Parameters.AddWithValue("@DDate", textBox76.Text);
            cmd.Parameters.AddWithValue("@DCdate", dateTimePicker7);
            cmd.Parameters.AddWithValue("@CID", textBox78.Text);
            cmd.ExecuteNonQuery();
            OleDbCommand cmd1 = new OleDbCommand("Update SO set Status= 'Close'  where SOID ='" + comboBox12.Text + "'", conn.oleDbConnection1);
            cmd1.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show("Delivery Challan Created Successfully!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void groupBox9_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("Select * from DelChalan where DCID = '" + comboBox13.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox86.Text = dr["DCDate"].ToString();
                textBox84.Text = dr["SOID"].ToString();
                textBox82.Text = dr["CName"].ToString();
                textBox83.Text = dr["CID"].ToString();
            }

            OleDbCommand cmd1 = new OleDbCommand("Select  * from SO where SOID = '" + textBox84.Text + "'", conn.oleDbConnection1);
            OleDbDataReader dr1 = cmd1.ExecuteReader();
            if (dr1.Read())
            {
                textBox85.Text = dr1["PRICE"].ToString();
            }

            OleDbDataAdapter da = new OleDbDataAdapter("Select Pid , PQty  from SOProducts where SOID ='" + textBox84.Text + "'", conn.oleDbConnection1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView6.DataSource = dt;
            conn.oleDbConnection1.Close();
        }

        private void textBox81_TextChanged(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(textBox85.Text);
            int disc = Convert.ToInt32(textBox81.Text);
            int discount = (price * disc) / 100;
            int d = price - discount;
            textBox80.Text = d.ToString();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            conn.oleDbConnection1.Open();
            OleDbCommand cmd = new OleDbCommand("insert into InvoiceR(InvoiceID,CustID,CustName,DCDate,InvoiceDate,AmountReceivable,DelCID) values(@InvoiceID,@CustID,@CustName,@DCDate,@InvoiceDate,@AmountReceivable,@DelCID)", conn.oleDbConnection1);
            cmd.Parameters.AddWithValue("@InvoiceID", textBox87.Text);
            cmd.Parameters.AddWithValue("@CustID", textBox83.Text);
            cmd.Parameters.AddWithValue("@CustName", textBox82.Text);
            cmd.Parameters.AddWithValue("@DCDate", textBox86.Text);
            cmd.Parameters.AddWithValue("@InvoiceDate", dateTimePicker8);
            cmd.Parameters.AddWithValue("@AmountReceivable", textBox80.Text);
            cmd.Parameters.AddWithValue("@DelCID", comboBox13.Text);
            cmd.ExecuteNonQuery();
            conn.oleDbConnection1.Close();
            MessageBox.Show("Congrats! Invoice Payable Created.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
