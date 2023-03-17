using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sayi1 = Convert.ToDecimal(textBox1.Text);
                decimal sayi2 = Convert.ToDecimal(textBox2.Text);
                decimal sonuc = sayi1 + sayi2;
                label3.Text = "SONUÇ=" + sonuc.ToString();

            }
            catch 
            {
                textBox1.Text = "";
                textBox2.Clear();
                textBox1.Focus();
                MessageBox.Show("Girilen değerleri kontrol ediniz", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sayi1 = Convert.ToDecimal(textBox1.Text);
                decimal sayi2 = Convert.ToDecimal(textBox2.Text);
                decimal sonuc = sayi1 - sayi2;
                label3.Text = "SONUÇ=" + sonuc.ToString();

            }
            catch
            {
                textBox1.Text = "";
                textBox2.Clear();
                textBox1.Focus();
                MessageBox.Show("Girilen değerleri kontrol ediniz", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sayi1 = Convert.ToDecimal(textBox1.Text);
                decimal sayi2 = Convert.ToDecimal(textBox2.Text);
                decimal sonuc = sayi1 * sayi2;
                label3.Text = "SONUÇ=" + sonuc.ToString();

            }
            catch
            {
                textBox1.Text = "";
                textBox2.Clear();
                textBox1.Focus();
                MessageBox.Show("Girilen değerleri kontrol ediniz", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                decimal sayi1 = Convert.ToDecimal(textBox1.Text);
                decimal sayi2 = Convert.ToDecimal(textBox2.Text);
                decimal sonuc = sayi1 / sayi2;
                label3.Text = "SONUÇ=" + String.Format("{0:n2}", sonuc);

            }
            catch
            {
                textBox1.Text = "";
                textBox2.Clear();
                textBox1.Focus();
                MessageBox.Show("Girilen değerleri kontrol ediniz", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                double sayi1 = Convert.ToDouble(textBox1.Text);
                double sayi2 = Convert.ToDouble(textBox2.Text);
                double sonuc = Math.Pow(sayi1, sayi2);

                label3.Text = "SONUÇ=" + sonuc.ToString();

            }
            catch
            {
                textBox1.Text = "";
                textBox2.Clear();
                textBox1.Focus();
                MessageBox.Show("Girilen değerleri kontrol ediniz", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
