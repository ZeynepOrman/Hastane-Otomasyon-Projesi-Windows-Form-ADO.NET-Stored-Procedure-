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
    public partial class Poliklinikler : Form
    {
        public Poliklinikler()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Server=LAPTOP-1NP5U72T; Database= HastaneOtomasyonuSQL; Integrated Security=true;");

        public void Getir2()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListelePoliklinikler";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Getir2();
        }

        private void Error_Handle(string message = "Güncelleme başarısız!")
        {
            MessageBox.Show(message);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrWhiteSpace(textBox5.Text) ||
            string.IsNullOrWhiteSpace(textBox6.Text))
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
            cmd.CommandText = "EklePoliklinikler";
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox1.Text);
            cmd.Parameters.AddWithValue("PoliklinikAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("PoliklinikUzmanSayisi", textBox3.Text);
            cmd.Parameters.AddWithValue("PoliklinikBaşHekimi", textBox4.Text);
            cmd.Parameters.AddWithValue("PoliklinikBaşHemşiresi", textBox5.Text);
            cmd.Parameters.AddWithValue("YatakSayisi", textBox6.Text);
            int result = cmd.ExecuteNonQuery();


                if (result > 0)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    Getir2();
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
            cmd.CommandText = "YenilePoliklinikler";
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox1.Text);
            cmd.Parameters.AddWithValue("PoliklinikAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("PoliklinikUzmanSayisi", textBox3.Text);
            cmd.Parameters.AddWithValue("PoliklinikBaşHekimi", textBox4.Text);
            cmd.Parameters.AddWithValue("PoliklinikBaşHemşiresi", textBox5.Text);
            cmd.Parameters.AddWithValue("YatakSayisi", textBox6.Text);
            int result = cmd.ExecuteNonQuery();


                if (result > 0)
                {
                    MessageBox.Show("Güncelleme Başarılı");
                    Getir2();
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
            cmd.CommandText = "SilPoliklinikler";
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox1.Text);
                int result = cmd.ExecuteNonQuery();


                if (result > 0)
                {
                    MessageBox.Show("Başarıyla silindi");
                    Getir2();
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Getir2();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "EklePoliklinikler";
            cmd.Parameters.AddWithValue("PoliklinikAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("PoliklinikUzmanSayisi", textBox3.Text);
            cmd.Parameters.AddWithValue("PoliklinikBasHekimi", textBox4.Text);
            cmd.Parameters.AddWithValue("PoliklinikBasHemsire", textBox5.Text);
            cmd.Parameters.AddWithValue("YatakSayisi", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Getir2();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "YenilePoliklinikler";

            cmd.Parameters.AddWithValue("PoliklinikNo", textBox1.Text);
            cmd.Parameters.AddWithValue("PoliklinikAdi", textBox2.Text);
            cmd.Parameters.AddWithValue("PoliklinikUzmanSayisi", textBox3.Text);
            cmd.Parameters.AddWithValue("PoliklinikBasHekimi", textBox4.Text);
            cmd.Parameters.AddWithValue("PoliklinikBasHemsire", textBox5.Text);
            cmd.Parameters.AddWithValue("YatakSayisi", textBox6.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Getir2();
        }


        private void button4_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SilPoliklinikler";
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Getir2();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Anasayfa git = new Anasayfa();
            git.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Aramayappoliklinik";
            cmd.Parameters.AddWithValue("PoliklinikNo", textBox7.Text);
            cmd.Parameters.AddWithValue("PoliklinikAdi", textBox8.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }


    }
}
