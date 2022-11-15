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

namespace hastane_projesi
{
    public partial class Raporlama : Form
    {
        SqlConnection con = new SqlConnection("Server=LAPTOP-1NP5U72T; Database= HastaneOtomasyonuSQL; Integrated Security=true;");
        public Raporlama()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "boyagoresirala";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        public void Sorgular(string proc)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = proc;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            if (comboBox1.Text == "Hastaların TC  Kimlik Numaralarına Göre Sırala")
            {
                Sorgular("HastaTcSiralama");

            }

            else if (comboBox1.Text == "Hastaların 23 Yaşından Büyük Olanların Rapor Durumu")
            {
                Sorgular("Hasta23Rapor");
            }
            else if (comboBox1.Text == "Hastaların Boy Ortalamasını 165 cm 'in Altında Olanların Doğum Tarihleri")
            {
                Sorgular("HastaBoyOrtalama");
            }
            else if (comboBox1.Text == "Hasta Adı, TC ve İlgili Doktorun İletişim Bilgilerini Getir")
            {
                Sorgular("HastaDoktor");
            }
            else if (comboBox1.Text == "Hastaların 65 Yaşından Büyük Olanlarının Rapor ve Reçete Durumu")
            {
                Sorgular("Hasta65Yas");
            }
            else if (comboBox1.Text == "Günlük Randevu Adet")
            {
                Sorgular("RandevuTarihi");
            }
            else if (comboBox1.Text == "Doktorların Baktığı Hastalar")
            {
                Sorgular("DoktorHasta");
            }
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Anasayfa go = new Anasayfa();
            go.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedItem==null)
            {
                MessageBox.Show("Lütfen doktor no. giriniz.");
                return;
            }
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Birlestirmegrup1Hasta";
            cmd.Parameters.AddWithValue("DoktorNo", comboBox3.SelectedItem);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Load_Doctors_Combo()
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DoktorNoSec";

            SqlDataReader dr;
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox3.Items.Add(dr["DoktorNo"]);
            }
            con.Close();

        }
        private void Load_Policlinics_Combo()
        {
            con.Open();
            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "PoliklinikNoSec";

            SqlDataReader dr;
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["PoliklinikNo"]);
            }


            con.Close();

        }

        private void Raporlama_Load(object sender, EventArgs e)
        {

            Load_Doctors_Combo();
            Load_Policlinics_Combo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Lütfen doktor no. giriniz.");
                return;
            }
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Birlestirmegrup2Poliklinik";
            cmd.Parameters.AddWithValue("PoliklinikNo", comboBox2.SelectedItem);
            con.Close();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
