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
    public partial class Hocvien : Form
    {
        public Hocvien()
        {
            InitializeComponent();
        }

        void loaddata()
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            string query = @"select * from hocvien";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            DataTable tablf2 = new DataTable();
            tablf2.Clear();
            sda.Fill(tablf2);
            datahocvien.DataSource = tablf2;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int  gioitinh=1;
            SqlConnection con = Data.data1();
            con.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("insert into hocvien values(@MAHV,@TENHV,@GIOITINH,@NGAYSINH,@SDT,@DIACHI)", con);
                cmd.Parameters.AddWithValue("@MAHV", txt1.Text);
                cmd.Parameters.AddWithValue("@TENHV", txt2.Text);
                if (cbGioitinh.SelectedIndex == 0) gioitinh = 1;
                if (cbGioitinh.SelectedIndex == 1) gioitinh = 0;
                cmd.Parameters.AddWithValue("@GIOITINH", gioitinh);
                cmd.Parameters.AddWithValue("@NGAYSINH", txt3.Text);
                cmd.Parameters.AddWithValue("@SDT", txt4.Text);
                cmd.Parameters.AddWithValue("@DIACHI", txt5.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Thêm học viên thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loaddata();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Thêm học viên không thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void Hocvien_Load(object sender, EventArgs e)
        {
            loaddata();

           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from hocvien where mahv=@mahv", conn);
            cmd.Parameters.AddWithValue("@MAHV", txt1.Text);
          //  cmd.Parameters.AddWithValue("@tenhv", txt2.Text);
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
            cbGioitinh.SelectedIndex = 0;
            txt1.Focus();
        }

        private void datahocvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = datahocvien.CurrentRow.Index;
            txt1.Text = datahocvien.Rows[i].Cells[0].Value.ToString();
            txt2.Text = datahocvien.Rows[i].Cells[1].Value.ToString();
            txt3.Text = datahocvien.Rows[i].Cells[3].Value.ToString();
            txt4.Text = datahocvien.Rows[i].Cells[4].Value.ToString();
            txt5.Text = datahocvien.Rows[i].Cells[5].Value.ToString();
            int j = Convert.ToInt32(datahocvien.Rows[i].Cells[2].Value.ToString());
            if (j==1)
            {
                cbGioitinh.SelectedIndex = 0;
            }
            else
            {
                cbGioitinh.SelectedIndex = 1;
            }


        }

        private void datahocvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = datahocvien.CurrentRow.Index;
            txt1.Text = datahocvien.Rows[i].Cells[0].Value.ToString();
            txt2.Text = datahocvien.Rows[i].Cells[1].Value.ToString();
            txt3.Text = datahocvien.Rows[i].Cells[3].Value.ToString();
            txt4.Text = datahocvien.Rows[i].Cells[4].Value.ToString();
            txt5.Text = datahocvien.Rows[i].Cells[5].Value.ToString();
            int j = Convert.ToInt32(datahocvien.Rows[i].Cells[2].Value.ToString());
            if (j == 1)
            {
                cbGioitinh.SelectedIndex = 0;
            }
            else
            {
                cbGioitinh.SelectedIndex = 1;
            }
        }
    }
}
