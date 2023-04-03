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
    public partial class Monhoc : Form
    {
        public Monhoc()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            string query = @"select * from MONHOC";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            DataTable tablf2 = new DataTable();
            tablf2.Clear();
            sda.Fill(tablf2);
            datamonhoc.DataSource = tablf2;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void datamonhoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = datamonhoc.CurrentRow.Index;
            txt1.Text = datamonhoc.Rows[i].Cells[0].Value.ToString();
            txt2.Text = datamonhoc.Rows[i].Cells[1].Value.ToString();
        }

        private void Monhoc_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Data.data1();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into Monhoc values(@MAMH,@TENMH)", con);
               
                cmd.Parameters.AddWithValue("@MAMH", txt1.Text);
                cmd.Parameters.AddWithValue("@TENMH", txt2.Text);
               
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm dữ liệu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from monhoc where mahv=@mahv", conn);
            cmd.Parameters.AddWithValue("@mahv", txt1.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            loaddata();
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt1.ResetText();
            txt2.ResetText();
            txt1.Focus();
        }
    }
}
