using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VYTS_Proje
{
    public partial class frmOyuncu : Form
    {
        public frmOyuncu()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Proje; user ID=postgres; password=159753852");




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from hücumistatistikleri";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into hücumistatistikleri (\"Personelid\",\"Adi\",\"Soyadi\",\"Maas\",\"boy\",\"kilo\",\"yas\",\"forma\",\"pozisyon\",\"üçlük yüzdesi\",\"ikilik yüzdesi\",\"asist sayısı\") values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(txtID.Text));
            komut1.Parameters.AddWithValue("@p2", txtOyuncuAd.Text);
            komut1.Parameters.AddWithValue("@p3", txtOyuncuSoyad.Text);
            komut1.Parameters.AddWithValue("@p4", double.Parse(txtOyuncuMaas.Text));
            komut1.Parameters.AddWithValue("@p5", int.Parse(txtOyuncuBoy.Text));
            komut1.Parameters.AddWithValue("@p6", int.Parse(txtOyuncuKilo.Text));
            komut1.Parameters.AddWithValue("@p7", int.Parse(txtOyuncuYas.Text));
            komut1.Parameters.AddWithValue("@p8", int.Parse(txtOyuncuFormaNo.Text));
            komut1.Parameters.AddWithValue("@p9", int.Parse(txtOyuncuPozisyon.Text));
            komut1.Parameters.AddWithValue("@p10", int.Parse(txtOyuncuUcluk.Text));
            komut1.Parameters.AddWithValue("@p11", int.Parse(txtOyuncuIkilik.Text));
            komut1.Parameters.AddWithValue("@p12", int.Parse(txtOyuncuAsist.Text));
            



            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Oyuncu ekleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void frmOyuncu_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter("select * from takim", baglanti);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            comboBox1.DisplayMember = "takim_adi";
            comboBox1.ValueMember = "takim_id";
            comboBox1.DataSource = dt1;
            baglanti.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from hücumistatistikleri where \"Personelid\"=@p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(txtID.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün silme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        private void btnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut3 = new NpgsqlCommand("update hücumistatistikleri set \"üçlük yüzdesi\"=@p1,\"ikilik yüzdesi\"=@p2,\"asist sayısı\"=@p3 where \"Personelid\"=@p4", baglanti);
            komut3.Parameters.AddWithValue("@p1", int.Parse(txtOyuncuUcluk.Text));
            komut3.Parameters.AddWithValue("@p2", int.Parse(txtOyuncuIkilik.Text));
            komut3.Parameters.AddWithValue("@p3", int.Parse(txtOyuncuAsist.Text));
            komut3.Parameters.AddWithValue("@p4", int.Parse(txtID.Text));
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Ürün güncelleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlDataAdapter da = new NpgsqlDataAdapter("Select * from personellistesi", baglanti);
            DataSet dt = new DataSet();
            da.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            baglanti.Close();



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}