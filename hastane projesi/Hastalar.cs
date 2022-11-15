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
    public partial class Hastalar : Form
    {
        public Hastalar()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Server=LAPTOP-1NP5U72T; Database= HastaneOtomasyonuSQL; integrated security=true;");

        public void Getir1()
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ListeleHastalar";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void Error_Handle(string message = "Güncelleme başarısız!")
        {
            MessageBox.Show(message);

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Getir1();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text) || string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox10.Text) || string.IsNullOrWhiteSpace(textBox9.Text) || comboBox1.SelectedItem ==null)
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
                cmd.CommandText = "EkleHastalar";
                cmd.Parameters.AddWithValue("HastaAdSoyad", textBox2.Text);
                cmd.Parameters.AddWithValue("HastaTCNo", textBox3.Text);
                cmd.Parameters.AddWithValue("DogumTarihi", dateTimePicker2.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("Kilo", textBox7.Text);
                cmd.Parameters.AddWithValue("Boy", textBox5.Text);
                cmd.Parameters.AddWithValue("Yas", textBox6.Text);
                cmd.Parameters.AddWithValue("Recete", textBox10.Text);
                cmd.Parameters.AddWithValue("RaporDurumu", textBox9.Text);
                cmd.Parameters.AddWithValue("RandevuTarihi", dateTimePicker1.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("DoktorNo", comboBox1.SelectedItem);
                int result = cmd.ExecuteNonQuery();
               
               


                if (result > 0)
                {
                    MessageBox.Show("Kayıt Başarılı");
                    Getir1();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "YenileHastalar";
                cmd.Parameters.AddWithValue("HastaNo", textBox1.Text);
                cmd.Parameters.AddWithValue("HastaAdSoyad", textBox2.Text);
                cmd.Parameters.AddWithValue("HastaTCNo", textBox3.Text);
                cmd.Parameters.AddWithValue("DogumTarihi", dateTimePicker2.Value);
                cmd.Parameters.AddWithValue("Kilo", textBox7.Text);
                cmd.Parameters.AddWithValue("Boy", textBox5.Text);
                cmd.Parameters.AddWithValue("Yas", textBox6.Text);
                cmd.Parameters.AddWithValue("Recete", textBox10.Text);
                cmd.Parameters.AddWithValue("RaporDurumu", textBox9.Text);
                cmd.Parameters.AddWithValue("RandevuTarihi", dateTimePicker1.Value);
                cmd.Parameters.AddWithValue("DoktorNo", comboBox1.SelectedItem);
                 int result=cmd.ExecuteNonQuery();


            if (result > 0)
            {
                MessageBox.Show("Güncelleme Başarılı");
                Getir1();
            }
            else
            {
                Error_Handle();

            }


        }
            catch(Exception)
            {
                Error_Handle();
            }

            finally
            {
                con.Close();
            }


        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SilHastalar";
                cmd.Parameters.AddWithValue("HastaNo", textBox1.Text);
                int result = cmd.ExecuteNonQuery();


                if (result > 0)
                {
                    MessageBox.Show("Başarıyla silindi");
                    Getir1();
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
            cmd.CommandText = "Aramayaphasta";
            cmd.Parameters.AddWithValue("HastaNo", textBox11.Text);
            cmd.Parameters.AddWithValue("HastaAdSoyad", textBox8.Text);
            cmd.Parameters.AddWithValue("HastaTCNo", textBox4.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void Hastalar_Load(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand();
            komut.Connection = con;
            komut.CommandType = CommandType.StoredProcedure;
            komut.CommandText = "DoktorNoSec";
            SqlDataReader dr;
            con.Open();
            dr = komut.ExecuteReader();

            while (dr.Read())
            {
                comboBox1.Items.Add(dr["DoktorNo"]);
            }



            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int sec = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[sec].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[sec].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[sec].Cells[2].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[sec].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[sec].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[sec].Cells[5].Value.ToString();
            textBox7.Text = dataGridView1.Rows[sec].Cells[6].Value.ToString();
            textBox10.Text = dataGridView1.Rows[sec].Cells[7].Value.ToString();
            textBox9.Text = dataGridView1.Rows[sec].Cells[8].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[sec].Cells[9].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[sec].Cells[10].Value.ToString();
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

    }
}

