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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=r1se\SQLEXPRESS;Initial Catalog=satisVt;Integrated Security=True");

        void listele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBL_PERSONEL",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        void ekle()
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("insert into TBL_PERSONEL (PERSONELADSOYAD) values(@p1)",baglanti);
            komut1.Parameters.AddWithValue("@p1",txtPeradSoyad.Text);
            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Sisteme Eklendi");
            listele();
        }

        void sil()
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("delete from TBL_PERSONEL where PERSONELID=@p2",baglanti);
            komut2.Parameters.AddWithValue("@p2",txtPersoneld.Text);
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Silindi");
            listele();
        }
        
        void guncelle()
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("update TBL_PERSONEL set PERSONELADSOYAD=@P3 where PERSONELID=@P4",baglanti);
            komut3.Parameters.AddWithValue("@P3",txtPeradSoyad.Text);
            komut3.Parameters.AddWithValue("@P4",txtPersoneld.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Güncellendi");
            listele();
        }
        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ekle();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            ekle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtPersoneld.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtPeradSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            sil();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            sil();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            guncelle();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            guncelle();
        }
    }
}
