using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //databaseconnection
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\v11.0;Initial Catalog=carisma;Integrated Security=True");
        //creation
        private void create_Click(object sender, EventArgs e)
        {
            try
            {
            string q = "insert into emp(Eid,Employee_name,Employee_Email,Employee_mobile,Employee_DOB)values(" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "'," + textBox4.Text + ",'" + dateTimePicker1.Value + "')";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            int c = cmd.ExecuteNonQuery();
            con.Close();
            if(c>0)
            {
                MessageBox.Show("record inserted");
            }
            else
            {
                MessageBox.Show("record not inserted");
            }
            }
            catch(Exception e1)
            {
                MessageBox.Show(e1.Message);
            }
        }
        //Reterive the record
        private void read_Click(object sender, EventArgs e)
        {
            string q = "select * from emp where Eid=" + textBox1.Text + "";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            if(sdr.Read())
            {
                richTextBox1.Text = "Eid:" + sdr[0] + "\nEmployeee_name:" + sdr[1] + "\nEmployee_email:" + sdr[2] + "\nEmployee_mobile:" + sdr[3] + "\nEmployee_DOB:" + sdr[4] + "\nLast_date_modified:" + sdr[5];

            }
            else
            {
                MessageBox.Show("no record found");
            }
            sdr.Close();
            con.Close();


        }
        //update the record
        private void button3_Click(object sender, EventArgs e)
        {
            string q = "update Emp set Employee_name='" + textBox2.Text + "',Employee_Email='" + textBox3.Text + "',Employee_mobile=" + textBox4.Text + ",Employee_DOB='" + dateTimePicker1.Value + "',Last_date_modified='" + DateTime.Now + "' where Eid=" + textBox1.Text + "";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            int c = cmd.ExecuteNonQuery();
            con.Close();
            if (c > 0)
            {
                MessageBox.Show("record updated");
            }
            else
            {
                MessageBox.Show("record not available");
            }
        }
        //delete the record
        private void delete_Click(object sender, EventArgs e)
        {
            string q = "delete from Emp where Eid=" + textBox1.Text + "";
            SqlCommand cmd = new SqlCommand(q, con);
            con.Open();
            int c = cmd.ExecuteNonQuery();
            con.Close();
            if (c > 0)
            {
                MessageBox.Show("record deleted");
            }
            else
            {
                MessageBox.Show("record not available");
            }
        }
     
    }
}
