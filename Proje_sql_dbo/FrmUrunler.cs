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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=r1se\SQLEXPRESS;Initial Catalog=satisVt;Integrated Security=True");

        void urunlerıgoster()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from TBL_URUNLER",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            urunlerıgoster();
        }
    }
}
