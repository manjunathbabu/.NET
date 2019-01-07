using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ho
{
    public partial class application : Form
    {
        public application()
        {
            InitializeComponent();
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.Text = "";
            
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.Text = "Please Enter Your Name";
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Please Enter Your Name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.WindowText;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ssid, firstname,lastname, phone,address,email;
            ssid = textBox1.Text;
            firstname = textBox2.Text;
            lastname = textBox3.Text;
            phone = textBox4.Text;
            address = textBox5.Text;
            email = textBox6.Text;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=HARISH-PC\MSSQL;Initial Catalog=hostel;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "insert into hostelinfo values('" + ssid + "','" + firstname + "','" + lastname + "','" + phone + "','" + address + "','" + email + "')";
                cmd.ExecuteNonQuery();
                
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";

                SqlDataAdapter sda = new SqlDataAdapter("select * from hostelinfo",con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
             string ssid;
            ssid = textBox1.Text;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=HARISH-PC\MSSQL;Initial Catalog=hostel;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("select ssid,firstname,lastname,phone,address,email from hostelinfo where ssid='" + ssid + "'", con);
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                textBox1.Text = reader[0].ToString();
               // reader.Read();
                textBox2.Text = reader[1].ToString();
               // reader.Read();
                textBox3.Text = reader[2].ToString();
               // reader.Read();
                textBox4.Text = reader[3].ToString();
               // reader.Read();
                textBox5.Text = reader[4].ToString();
                textBox6.Text = reader[5].ToString();
               reader.Close();

               SqlDataAdapter sda = new SqlDataAdapter("select * from hostelinfo", con);
               DataTable dt = new DataTable();
               sda.Fill(dt);
               dataGridView1.DataSource = dt;
               con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ssid = textBox1.Text;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=HARISH-PC\MSSQL;Initial Catalog=hostel;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "delete from hostelinfo where ssid='" + ssid + "'";
                cmd.ExecuteNonQuery();
                
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                SqlDataAdapter sda = new SqlDataAdapter("select * from hostelinfo", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
             try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=HARISH-PC\MSSQL;Initial Catalog=hostel;Integrated Security=True"))
                {

                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from hostelinfo where name like '" + textBox7.Text + "%'", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=HARISH-PC\MSSQL;Initial Catalog=hostel;Integrated Security=True"))
                {

                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select * from hostelinfo", con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
             string ssid, firstname,lastname, phone,address,email;
            ssid = textBox1.Text;
            firstname = textBox2.Text;
            lastname = textBox3.Text;
            phone = textBox4.Text;
            address = textBox5.Text;
            email = textBox6.Text;
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=HARISH-PC\MSSQL;Initial Catalog=hostel;Integrated Security=True");
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                con.Open();
                cmd.CommandText = "update hostelinfo set firstname='" + firstname + "',lastname='" + lastname + "',phone='" + phone + "',address='" + address + "'email='" + email + "' where ssid='" + ssid + "'";
                cmd.ExecuteNonQuery();
                
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                SqlDataAdapter sda = new SqlDataAdapter("select * from hostelinfo", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
       
        
        
        
    
