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
    public partial class Frmistatistikler : Form
    {
        public Frmistatistikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=r1se\SQLEXPRESS;Initial Catalog=satisVt;Integrated Security=True");
        private void Frmistatistikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand
("select KATEGORIAD,count(*) from TBL_Kategori inner join TBL_URUNLER on TBL_Kategori.KATEGORIID=TBL_URUNLER.KATEGORI group by KATEGORIAD", baglanti);
            SqlDataReader dr = komut2.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategoriler"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("select MUSTERISEHIR,count(*) from TBL_MUSTERI group by MUSTERISEHIR", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                chart2.Series["Şehirler"].Points.AddXY(dr3[0], dr3[1]);
            }
            baglanti.Close();
        }
    }
}
