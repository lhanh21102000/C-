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
    public partial class PhieuThu : Form
    {
        public PhieuThu()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            string query = @"select * from phieuthu";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            DataTable tablf2 = new DataTable();
            tablf2.Clear();
            sda.Fill(tablf2);
            dataPhieuThu.DataSource = tablf2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                SqlConnection con = Data.data1();
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into phieuthu values(@SOPT,@MAHV,@MALOP,@NGAYLAPPHIEU,@THANHTIEN)", con);
                cmd.Parameters.AddWithValue("@SOPT", txt1.Text);
                cmd.Parameters.AddWithValue("@MAHV", txt2.Text);
                cmd.Parameters.AddWithValue("@MALOP", txt3.Text);
                cmd.Parameters.AddWithValue("@NGAYLAPPHIEU", txt4.Text);
                cmd.Parameters.AddWithValue("@THANHTIEN", txt5.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                loaddata();
                MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
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
            SqlCommand cmd = new SqlCommand("delete from phieuthu where SOPT=@SOPT", conn);
            cmd.Parameters.AddWithValue("@SOPT", txt1.Text);
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
            txt5.ResetText();
            txt1.Focus();
        }

        private void dataPhieuThu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = dataPhieuThu.CurrentRow.Index;
            txt1.Text = dataPhieuThu.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataPhieuThu.Rows[i].Cells[1].Value.ToString();
            txt3.Text = dataPhieuThu.Rows[i].Cells[2].Value.ToString();
            txt4.Text = dataPhieuThu.Rows[i].Cells[3].Value.ToString();
            txt5.Text = dataPhieuThu.Rows[i].Cells[4].Value.ToString();
        }

        private void PhieuThu_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void dataPhieuThu_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i;
            i = dataPhieuThu.CurrentRow.Index;
            txt1.Text = dataPhieuThu.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataPhieuThu.Rows[i].Cells[1].Value.ToString();
            txt3.Text = dataPhieuThu.Rows[i].Cells[2].Value.ToString();
            txt4.Text = dataPhieuThu.Rows[i].Cells[3].Value.ToString();
            txt5.Text = dataPhieuThu.Rows[i].Cells[4].Value.ToString();
        }
    }
}
