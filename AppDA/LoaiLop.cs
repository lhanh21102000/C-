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
    public partial class LoaiLop : Form
    {
        public LoaiLop()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            string query = @"select * from loailop";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            DataTable tablf2 = new DataTable();
            tablf2.Clear();
            sda.Fill(tablf2);
            dataf1.DataSource = tablf2;
        }
        private void dataf1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataf1.CurrentRow.Index;
            txt1.Text = dataf1.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataf1.Rows[i].Cells[1].Value.ToString();
            txt3.Text = dataf1.Rows[i].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt1.ResetText();
            txt2.ResetText();
            txt3.ResetText();
            txt1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Data.data1();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into loailop values(@MALOAI,@MACT,@TENLOAI)", con);

                cmd.Parameters.AddWithValue("@MALOAI", txt1.Text);
                cmd.Parameters.AddWithValue("@MACT", txt2.Text);
                cmd.Parameters.AddWithValue("@TENLOAI", txt3.Text);
               

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
            try
            {
                SqlConnection conn = Data.data1();
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from loailop where MALOAI=@MALOAI", conn);
                cmd.Parameters.AddWithValue("@MALOAI", txt1.Text);
              
                cmd.ExecuteNonQuery();
                conn.Close();
                loaddata();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoaiLop_Load(object sender, EventArgs e)
        {
            loaddata();
        }
    }
}
