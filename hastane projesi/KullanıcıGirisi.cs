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
    public partial class KullanıcıGirisi : Form
    {

        SqlConnection con = new SqlConnection("Server=LAPTOP-1NP5U72T; Database= M03; Integrated Security=true;"); 
        public KullanıcıGirisi()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = true;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            groupBox2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KGiris";
            cmd.Parameters.AddWithValue("KullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("Sifre", textBox2.Text);

            SqlDataReader oku;
            oku = cmd.ExecuteReader();
            if (oku. Read())
            {
                MessageBox.Show("Kullanıcı Girişi Başarılı");
                Anasayfa go = new Anasayfa();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya Şifre hatalı");
                textBox1.Clear();
                textBox2.Clear();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "KKayit";
            cmd.Parameters.AddWithValue("KullaniciAdi", textBox3.Text);
            cmd.Parameters.AddWithValue("Sifre", textBox4.Text);
            cmd.Parameters.AddWithValue("Email", textBox5.Text);
            cmd.Parameters.AddWithValue("Telefon", maskedTextBox1.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kayıt Başarılı.");
            Anasayfa go = new Anasayfa();
            go.Show();
            this.Hide();
            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
