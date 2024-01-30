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
    public partial class frmislemler : Form
    {
        public frmislemler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=r1se\SQLEXPRESS;Initial Catalog=satisVt;Integrated Security=True");
        private void frmislemler_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select URUNAD,URUNMARKA,URUNALISFIYAT,URUNSATISFIYAT,URUNSTOK," +
                "TUTAR as'Satılan Ürün',TARIH, MUSTERIAD+ ' ' +MUSTERISOYAD,MUSTERISEHIR,KATEGORIAD" +
                " from TBL_HAREKET inner join TBL_URUNLER on TBL_HAREKET.URUN= TBL_URUNLER.URUNID" +
                " inner join TBL_MUSTERI on TBL_HAREKET.MUSTERI= TBL_MUSTERI.MUSTERIID inner join TBL_PERSONEL" +
                " on TBL_HAREKET.PERSONEL= TBL_PERSONEL.PERSONELID inner join TBL_Kategori on TBL_URUNLER.KATEGORI" +
                " = TBL_Kategori.KATEGORIID",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
