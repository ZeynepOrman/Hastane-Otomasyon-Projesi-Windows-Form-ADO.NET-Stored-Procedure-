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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace hastane_projesi
{
    public partial class Doktorlar : Form
    {
        public Doktorlar()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Server=LAPTOP-1NP5U72T; Database= HastaneOtomasyonuSQL; Integrated Security=true;");

        public void Getir()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListeleDoktorlar";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Getir();
        }

        private void Error_Handle(string message = "Güncelleme başarısız!")
        {
            MessageBox.Show(message);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) ||
    string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) ||
    string.IsNullOrWhiteSpace(maskedTextBox1.Text) || string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show("Lütfen boş kutuları doldurunuz.");

                return;
            }

            try
            {
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EkleDoktorlar";
            //cmd.Parameters.AddWithValue("DoktorNo", textBox1.Text);
            cmd.Parameters.AddWithValue("DoktorAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("DoktorTCNo", textBox3.Text);
            cmd.Parameters.AddWithValue("UzmanlıkAlani", textBox4.Text);
            cmd.Parameters.AddWithValue("Unvani", textBox5.Text);
            cmd.Parameters.AddWithValue("TelefonNumarasi", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("Adres", textBox7.Text);
            cmd.Parameters.AddWithValue("DogumTarihi", textBox6.Text);
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox8.Text);
                int result = cmd.ExecuteNonQuery();




                if (result > 0)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    Getir();
                }
                else
                {
                    Error_Handle("Kayıt başarısız");

                }


            }
            catch (Exception)
            {
                Error_Handle("Kayıt başarısız");
            }
            finally
            {
                con.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "YenileDoktorlar";
            cmd.Parameters.AddWithValue("DoktorNo", textBox1.Text);
            cmd.Parameters.AddWithValue("DoktorAdSoyad", textBox2.Text);
            cmd.Parameters.AddWithValue("DoktorTCNo", textBox3.Text);
            cmd.Parameters.AddWithValue("UzmanlıkAlani", textBox4.Text);
            cmd.Parameters.AddWithValue("Unvani", textBox5.Text);
            cmd.Parameters.AddWithValue("TelefonNumarasi", maskedTextBox1.Text);
            cmd.Parameters.AddWithValue("Adres", textBox7.Text);
            cmd.Parameters.AddWithValue("DogumTarihi", textBox6.Text);
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox8.Text);
            int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Güncelleme başarılı");
                    Getir();
                }
                else
                {
                    Error_Handle();

                }

            }
            catch (Exception)
            {
                Error_Handle();
            }
            finally
            {
                con.Close();
            }
        }
    
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SilDoktorlar";
            cmd.Parameters.AddWithValue("DoktorNo", textBox1.Text);
            int result = cmd.ExecuteNonQuery();


                if (result > 0)
                {
                    MessageBox.Show("Başarıyla silindi");
                    Getir();
                }
                else
                {
                    Error_Handle("Silme başarısız");

                }


            }
            catch (Exception)
            {
                Error_Handle("Silme başarısız");
            }
            finally
            {
                con.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Aramayapdoktor";
            cmd.Parameters.AddWithValue("DoktorNo", textBox9.Text);
            cmd.Parameters.AddWithValue("DoktorAdSoyad", textBox10.Text);
            cmd.Parameters.AddWithValue("DoktorTCNo", textBox11.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
            textBox6.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            Anasayfa git = new Anasayfa();
            git.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
