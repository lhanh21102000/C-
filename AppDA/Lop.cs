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

namespace AppDA
{
    public partial class Lop : Form
    {
        public Lop()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            string query = @"select * from lop";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            DataTable tablf2 = new DataTable();
            tablf2.Clear();
            sda.Fill(tablf2);
            dataf1.DataSource = tablf2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into lop values (@MALOP,@MALOAI,@TENLOP,@SISO,@MAKH)", conn);
                cmd.Parameters.AddWithValue("@MALOP", txt1.Text);
                cmd.Parameters.AddWithValue("@MALOAI", txt2.Text);
                cmd.Parameters.AddWithValue("@TENLOP", txt3.Text);
                cmd.Parameters.AddWithValue("@SISO",Convert.ToInt32(txt4.Text));
                cmd.Parameters.AddWithValue("@MAKH", txt5.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                loaddata();
                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
        }

        private void Lop_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                SqlConnection conn = Data.data1();
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from lop where MALOP=@MALOP",conn);
                cmd.Parameters.AddWithValue("@MALOP", txt1.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                loaddata();
                MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xóa dữ liệu không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataf1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataf1.CurrentRow.Index;
            txt1.Text = dataf1.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataf1.Rows[i].Cells[1].Value.ToString();
            txt3.Text = dataf1.Rows[i].Cells[2].Value.ToString();
            txt4.Text = dataf1.Rows[i].Cells[3].Value.ToString();
            txt5.Text = dataf1.Rows[i].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt1.ResetText();
            txt2.ResetText();
            txt3.ResetText();
            txt4.ResetText();
            txt5.ResetText();
        }

        private void dataf1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataf1.CurrentRow.Index;
            txt1.Text = dataf1.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataf1.Rows[i].Cells[1].Value.ToString();
            txt3.Text = dataf1.Rows[i].Cells[2].Value.ToString();
            txt4.Text = dataf1.Rows[i].Cells[3].Value.ToString();
            txt5.Text = dataf1.Rows[i].Cells[4].Value.ToString();
        }
    }
}
