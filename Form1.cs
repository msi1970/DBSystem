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
namespace DBSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=CSS\SQL2K19EXP;Initial Catalog=Sample;Integrated Security=True");
        private void btnInsert_Click(object sender, EventArgs e)
        {
            con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "insert into [tblDBSystem](Name,Surname,Address) values('" + textBox1 + "','" + textBox2 + "','" + textBox3 + "')";
            string qr= "insert into tblDBSystem(Name,Surname,Address) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            SqlDataAdapter sda = new SqlDataAdapter(qr, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("INSERTED SUCCESSFULLY");
            // MessageBox.Show("Inserted correctly")
            //cmd.ExecuteNonQuery();
            //con.Close();
            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
            //display_data();
            //MessageBox.Show("Data Inserted Successfully");

        }
        // To display data
        public void display_data()
        {
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from tblDBSystem";
            //cmd.ExecuteNonQuery();
            //DataTable dt = new DataTable();
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //sda.Fill(dt);
            //dataGridView1.DataSource = dt;
            //con.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            con.Open();
            string qry = "select * from tblDBSystem";
            SqlDataAdapter sda = new SqlDataAdapter(qry, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            string dl = "delete from tblDBSystem where Name='" + textBox1.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(dl, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Deleted Successfully");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //con.Open();
            //SqlCommand cmd = con.CreateCommand();
            //cmd.CommandType = CommandType.Text;
            //cmd.CommandText = "select * from tblDBSystem where Name='" + textBox4 + "'";
            //cmd.ExecuteNonQuery();
            //con.Close();
            //textBox1.Text = "";
            //textBox2.Text = "";
            //textBox3.Text = "";
            //textBox4.Text = "";
            //display_data();
            //MessageBox.Show("Data Updated Successfully");

            con.Open();
            string ud = "update tblDBSystem set Surname='" + textBox2.Text + "',Address='" + textBox3.Text + "' where Name='" + textBox1.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(ud, con);
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated Successfully");

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();

            

        }
    }
}
