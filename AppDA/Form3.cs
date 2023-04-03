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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            string query = @"select * from khoahoc";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            DataTable tablf2 = new DataTable();
            tablf2.Clear();
            sda.Fill(tablf2);
            dataf3.DataSource = tablf2;
        }
        private void dataf3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataf3.CurrentRow.Index;
            txt1.Text = dataf3.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataf3.Rows[i].Cells[1].Value.ToString();
            txt3.Text = dataf3.Rows[i].Cells[2].Value.ToString();
            txt4.Text = dataf3.Rows[i].Cells[3].Value.ToString();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            string query = @"select * from khoahoc";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            DataTable tablf2 = new DataTable();
            tablf2.Clear();
            sda.Fill(tablf2);
            dataf3.DataSource = tablf2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into khoahoc values (@MAKH,@TENKH,@NGAYBD,@NGAYKT)",conn);
            cmd.Parameters.AddWithValue("@MAKH", txt1.Text);
            cmd.Parameters.AddWithValue("@TENKH", txt2.Text);
            cmd.Parameters.AddWithValue("@NGAYBD", txt3.Text);
            cmd.Parameters.AddWithValue("@NGAYKT", txt4.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            loaddata();
            MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from khoahoc where MAKH=@MAKH",conn);
            cmd.Parameters.AddWithValue("@MAKH", txt1.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            loaddata();
            MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt1.ResetText();
            txt2.ResetText();
            txt3.ResetText();
            txt4.ResetText();

            txt1.Focus();
        }

        private void dataf3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataf3.CurrentRow.Index;
            txt1.Text = dataf3.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataf3.Rows[i].Cells[1].Value.ToString();
            txt3.Text = dataf3.Rows[i].Cells[2].Value.ToString();
            txt4.Text = dataf3.Rows[i].Cells[3].Value.ToString();
        }
    }
}
