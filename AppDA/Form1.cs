using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AppDA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string datasource = @"LAPTOP-THR4ECBT\SQLEXPRESS";

        static string database = "ab";
        static string username = "sa";
        static string password = "sa123";


        string strcon = @"Data Source=" + datasource + ";Initial Catalog="
                    + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Data str1 = new Data();
            //str1 = str1.data();
            SqlConnection sqlcon = new SqlConnection(strcon);
            sqlcon.Open();
             
            String query = "select count(*) from user_pass where name=@name and pass=@pass";
            SqlCommand cmd = new SqlCommand(query, sqlcon);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@name", text1.Text);
            cmd.Parameters.AddWithValue("@pass", text2.Text);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 1)
            {
                Form2 f = new Form2();
                f.Show();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng xin vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            


              /*  if(sqlcon.State == ConnectionState.Open)
            {
                Form2 f2 = new Form2();
                f2.Show();
                this.Close();
            }*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* SqlConnection conn = Data.data1();
             conn.Open();
             SqlCommand cmd = new SqlCommand("insert into tbab values (@ID, @name,@pass)",conn);
             cmd.Parameters.AddWithValue("@ID", int.Parse(txtID.Text));
             cmd.Parameters.AddWithValue("@name", text1.Text);
             cmd.Parameters.AddWithValue("@pass", text2.Text);
             cmd.ExecuteNonQuery();
             conn.Close(); */
             dangki fdangki =  new dangki();
            fdangki.Show();
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Enter(object sender, EventArgs e)
        {

        }
    }
}
