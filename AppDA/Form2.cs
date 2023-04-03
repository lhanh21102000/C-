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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            Form3 f3 = new Form3();
            f3.Show();
           
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CHUONGTRINHcs f1 = new CHUONGTRINHcs();
            f1.Show();
        }

        private void b2_Click(object sender, EventArgs e)
        {
            Lop f1 = new Lop();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hocvien f = new Hocvien();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PhieuThu f = new PhieuThu();
            f.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Diem f = new Diem();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Monhoc f = new Monhoc();
            f.Show();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection con = Data.data1();
            con.Open();
            try
            {
                Int32 i;
                SqlCommand cmd = new SqlCommand("select count(*) from hocvien", con);
                i = (Int32) cmd.ExecuteScalar();
                con.Close();
                lblsum.Text = Convert.ToString(i);
                MessageBox.Show("Load dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Load dữ liệu thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection con = Data.data1();
            con.Open();
            Int32 i;
            SqlCommand cmd = new SqlCommand("select count(*) from hocvien", con);
            i = (Int32)cmd.ExecuteScalar();
            con.Close();
            lblsum.Text = Convert.ToString(i);
            con.Open();

            SqlCommand cmd1 = new SqlCommand("select sum(thanhtien) from phieuthu", con);
            var j = cmd1.ExecuteScalar();
            con.Close();
            lbldoanhthu.Text = Convert.ToString(j);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlConnection con = Data.data1();
            con.Open();
            
            SqlCommand cmd = new SqlCommand("select sum(thanhtien) from phieuthu", con);
             var i = cmd.ExecuteScalar();
            con.Close();
            lbldoanhthu.Text = Convert.ToString(i);
        }

        private void buuto_Click(object sender, EventArgs e)
        {
            LoaiLop f = new LoaiLop();
            f.Show();
        }
    }
}
