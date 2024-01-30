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

namespace Proje_sql_dbo
{
    public partial class FrmKategoriler : Form
    {
        public FrmKategoriler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=r1se\SQLEXPRESS;Initial Catalog=satisVt;Integrated Security=True");
         void listele()
          {
            SqlCommand komut = new SqlCommand("select * from TBL_Kategori", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
          }

         void kayıtekle()
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBL_Kategori (KATEGORIAD) values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtKategoriAd.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Başarıyla Eklendi");
        }

         void kayıtsil()
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from TBL_Kategori where KATEGORIID=@p2",baglanti);
            komut3.Parameters.AddWithValue("@p2",txtKategoriId.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi");
        }
         void kayıtguncelle()
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("update tbl_kategori set KATEGORIAD=@p3 where KATEGORIID=@p4",baglanti);
            komut4.Parameters.AddWithValue("@p3",txtKategoriAd.Text);
            komut4.Parameters.AddWithValue("@p4",txtKategoriId.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Güncellendi");
        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kayıtekle();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            kayıtekle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKategoriId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKategoriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            kayıtsil();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            kayıtsil();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            kayıtguncelle();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            kayıtguncelle();
        }

        private void FrmKategoriler_Load(object sender, EventArgs e)
        {

        }
    }
}
