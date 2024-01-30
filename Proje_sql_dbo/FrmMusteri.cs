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
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=r1se\SQLEXPRESS;Initial Catalog=satisVt;Integrated Security=True");

        void listele()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBL_MUSTERI",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            listele();

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select * from tbl_SEHIRLER",baglanti);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                cmMsehir.Items.Add(dr["sehir".ToUpper()]);
            }
            baglanti.Close();
        }

        void kayıtekle()
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TBL_MUSTERI (MUSTERIAD,MUSTERISOYAD,MUSTERISEHIR,MUSTERIBAKIYE) values (@ğ,@ğ1,@ğ2,@ğ3)",baglanti);
            komut2.Parameters.AddWithValue("@ğ",txtMad.Text);
            komut2.Parameters.AddWithValue("@ğ1", txtMsoyad.Text);
            komut2.Parameters.AddWithValue("@ğ2", cmMsehir.Text.ToUpper());
            komut2.Parameters.AddWithValue("@ğ3", decimal.Parse(txtMbakiye.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Eklendi");
            listele();
        }

        void kayıtsil()
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("delete from TBL_MUSTERI where MUSTERIID=@p1",baglanti);
            komut3.Parameters.AddWithValue("@p1",txtMID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Silindi");
            listele();
        }

        void kayıtguncelle()
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Update tbl_MUSTERI set MUSTERIAD=@P2,MUSTERISOYAD=@P3,MUSTERISEHIR=@P4,MUSTERIBAKIYE=@P5 Where MUSTERIID=@P0",baglanti);
            komut4.Parameters.AddWithValue("@P0",txtMID.Text);
            komut4.Parameters.AddWithValue("@P2",txtMad.Text);
            komut4.Parameters.AddWithValue("@P3",txtMsoyad.Text);
            komut4.Parameters.AddWithValue("@P4",cmMsehir.Text);
            komut4.Parameters.AddWithValue("@P5",decimal.Parse(txtMbakiye.Text));
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Müşteri Güncellendi");
            listele();
        }

        void kayıtara()
        {
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select * from TBL_MUSTERI where MUSTERIAD=@P6",baglanti);
            komut5.Parameters.AddWithValue("@P6",txtMad.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut5);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMad.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtMsoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            cmMsehir.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtMbakiye.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            kayıtekle();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            kayıtekle();
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

        private void btnAra_Click(object sender, EventArgs e)
        {
            kayıtara();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            kayıtara();
        }
    }
}
