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
    public partial class CHUONGTRINHcs : Form
    {
        public CHUONGTRINHcs()
        {
            InitializeComponent();
        }
        void loaddata()
        {
            SqlConnection conn = Data.data1();
            conn.Open();
            string query = @"select * from chuongtrinh";
            SqlDataAdapter sda = new SqlDataAdapter(query, conn);


            DataTable tablf2 = new DataTable();
            tablf2.Clear();
            sda.Fill(tablf2);
            dataf1.DataSource = tablf2;
        }
        private void CHUONGTRINHcs_Load(object sender, EventArgs e)
        {
            loaddata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con =Data.data1();
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into chuongtrinh values (@mact,@tenct)", con);
            cmd.Parameters.AddWithValue("@mact", txt1.Text);
            cmd.Parameters.AddWithValue("@tenct", txt2.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            loaddata();
            MessageBox.Show("Thêm dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataf1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataf1.CurrentRow.Index;
            txt1.Text = dataf1.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataf1.Rows[i].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = Data.data1();
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from chuongtrinh where mact = @mact",con);
            cmd.Parameters.AddWithValue("@mact", txt1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            loaddata();
            MessageBox.Show("Xóa dữ liệu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txt1.ResetText();
            txt2.ResetText();
        }

        private void dataf1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataf1.CurrentRow.Index;
            txt1.Text = dataf1.Rows[i].Cells[0].Value.ToString();
            txt2.Text = dataf1.Rows[i].Cells[1].Value.ToString();
           
        }
    }
}
