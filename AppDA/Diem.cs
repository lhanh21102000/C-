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
    public partial class Diem : Form
    {
        public Diem()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            string query = @"select * from diem";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            DataTable tablf2 = new DataTable();
            tablf2.Clear();
            sda.Fill(tablf2);
            datadiem.DataSource = tablf2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = Data.data1();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into DIEM values(@MAMH,@MAHV,@MALOP,@DIEM)", con);

                cmd.Parameters.AddWithValue("@MAMH", txt1.Text);
                cmd.Parameters.AddWithValue("@MAHV", txt2.Text);
                cmd.Parameters.AddWithValue("@MALOP", txt3.Text);
                cmd.Parameters.AddWithValue("@DIEM", txt4.Text);
   
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

        private void Diem_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = Data.data1();
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from DIEM where MAMH=@MAMH AND MAHV=@MAHV", conn);
                cmd.Parameters.AddWithValue("@MAMH", txt1.Text);
                cmd.Parameters.AddWithValue("@MAHV", txt2.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                loaddata();
                MessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Xóa không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt1.ResetText();
            txt2.ResetText();
            txt3.ResetText();
            txt4.ResetText();
      
            txt1.Focus();
        }

        private void datadiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = datadiem.CurrentRow.Index;
            txt1.Text = datadiem.Rows[i].Cells[0].Value.ToString();
            txt2.Text = datadiem.Rows[i].Cells[1].Value.ToString();
            txt3.Text = datadiem.Rows[i].Cells[2].Value.ToString();
            txt4.Text = datadiem.Rows[i].Cells[3].Value.ToString();
           
        }

        private void datadiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = datadiem.CurrentRow.Index;
            txt1.Text = datadiem.Rows[i].Cells[0].Value.ToString();
            txt2.Text = datadiem.Rows[i].Cells[1].Value.ToString();
            txt3.Text = datadiem.Rows[i].Cells[2].Value.ToString();
            txt4.Text = datadiem.Rows[i].Cells[3].Value.ToString();
        }
    }
}
