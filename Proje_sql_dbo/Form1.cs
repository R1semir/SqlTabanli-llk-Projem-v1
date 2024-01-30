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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=r1se\SQLEXPRESS;Initial Catalog=satisVt;Integrated Security=True");
        

        void islemgoster()
        {
            frmislemler fr = new frmislemler();
            fr.Show();
        }
        void istatistikgoster()
        {
            Frmistatistikler fr = new Frmistatistikler();
            fr.Show();
        }
        void kasagoster()
        {
            FrmKasa fr = new FrmKasa();
            fr.Show();
        }
        void personelgoster()
        {
            FrmPersonel fr = new FrmPersonel();
            fr.Show();
        }
        void urunlerıgoster()
        {
            FrmUrunler fr = new FrmUrunler();
            fr.Show();
        }
        public void frmkategorigöster()
        {
            FrmKategoriler fr = new FrmKategoriler();
            fr.Show();
        }
        public void frmmusterigoster()
        {
            FrmMusteri fr1 = new FrmMusteri();
            fr1.Show();
        }
        private void BtnKategori_Click(object sender, EventArgs e)
        {
            frmkategorigöster();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            frmkategorigöster();
        }
      

        private void btnMüsteriler_Click(object sender, EventArgs e)
        {
            frmmusterigoster();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
          
            frmmusterigoster();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            SqlCommand komut = new SqlCommand("execute test9",baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            urunlerıgoster();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            urunlerıgoster();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            personelgoster();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            personelgoster();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            kasagoster();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            kasagoster();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            islemgoster();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            islemgoster();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            istatistikgoster();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            istatistikgoster();
        }
    }
}
