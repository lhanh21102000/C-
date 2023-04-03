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
    public partial class dangki : Form
    {
        public dangki()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into user_pass values (@name,@pass)", conn);
                cmd.Parameters.AddWithValue("@name", text1.Text);
                cmd.Parameters.AddWithValue("@pass", text2.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Đăng kí thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tài khoản đã tồn tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text1.ResetText();
            text2.ResetText();
        }

        private void text2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
