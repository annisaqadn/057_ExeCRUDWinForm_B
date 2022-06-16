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

namespace ExeCRUDWinForm
{
    public partial class Produk : Form
    {
        public Produk()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=FUADIN;Initial Catalog=Apolaroid;User ID=sa;Password=123");

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.produk_insert '"+int.Parse(textBox1.Text)+"','"+textBox2.Text+ "','"+ textBox3.Text + "','"+textBox4.Text + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sukses Menambahkan Data");
            LoadAllRecords();
        }

        void LoadAllRecords()
        {
            SqlCommand com = new SqlCommand("exec dbo.produk_view", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.produk_update '" + int.Parse(textBox1.Text) + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sukses Mengubah Data");
            LoadAllRecords();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand("exec dbo.produk_delete '" + int.Parse(textBox1.Text) + "'", con);
            com.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Sukses Menghapus Data");
            LoadAllRecords();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 panggil = new Form1();
            panggil.Show();
        }

        private void Produk_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'apolaroidDataSet2.produk' table. You can move, or remove it, as needed.
            this.produkTableAdapter.Fill(this.apolaroidDataSet2.produk);

        }
    }
}
