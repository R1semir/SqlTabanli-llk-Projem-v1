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
using System.Runtime.InteropServices;

namespace Proje_sql_dbo
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=r1se\SQLEXPRESS;Initial Catalog=satisVt;Integrated Security=True");

        private void FrmKasa_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * from tbl_URUNLER",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("select URUNAD,URUNSATISFIYAT from TBL_URUNLER order by URUNSATISFIYAT desc",baglanti);
            SqlDataAdapter da1 = new SqlDataAdapter(komut1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("select Sum(Tutar) as'Toplam Tutar' from TBL_HAREKET ", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            baglanti.Close();
        }
    }
}
