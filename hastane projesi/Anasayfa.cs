using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hastane_projesi
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Poliklinikler go = new Poliklinikler();
            go.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doktorlar go = new Doktorlar();
            go.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hastalar go = new Hastalar();
            go.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            KullanıcıGirisi go = new KullanıcıGirisi();
            go.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            KullanıcıGirisi go = new KullanıcıGirisi();
            go.Show();
            this.Hide();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Raporlama go = new Raporlama();
            go.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Raporlama go = new Raporlama();
            go.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Hastalar go = new Hastalar();
            go.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Doktorlar go = new Doktorlar();
            go.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Poliklinikler go = new Poliklinikler();
            go.Show();
            this.Hide();
        }
    }
}
