using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Performans
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void listele()
        {
            SQLiteConnection baglanti = new SQLiteConnection("Data Source=C:\\Users\\hakan\\source\\repos\\Performans\\TrenTakipVeriTabanı.db;version=3");
            baglanti.Open();
            SQLiteDataAdapter adaptor = new SQLiteDataAdapter("SELECT * FROM Yolcular", baglanti);
            DataSet dataSet = new DataSet();
            adaptor.Fill(dataSet, "Yolcular");
            dataGridView1.DataSource = dataSet.Tables["Yolcular"];
            baglanti.Close();


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=C:\\Users\\hakan\\source\\repos\\Performans\\TrenTakipVeriTabanı.db;version=3");
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand();
                komut.Connection = baglanti;
                komut.CommandText = "INSERT INTO Yolcular VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox1.Text + "')";
                komut.ExecuteNonQuery();
                listele();
                baglanti.Close();
            }
            catch 
            {
              MessageBox.Show("Hata: Bir Sorun Oluştu... \n Hata = Yolcu Eklenemedi...");
                
            }
            finally
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Text = "";
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglanti = new SQLiteConnection("Data Source=C:\\Users\\hakan\\source\\repos\\Performans\\TrenTakipVeriTabanı.db;version=3");
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand();
                komut.Connection = baglanti;
                komut.CommandText = "DELETE FROM Yolcular WHERE KoltukNo='" + textBox1.Text + "'";
                komut.ExecuteNonQuery();
                listele();
                baglanti.Close();
            }
            catch 
            {
                MessageBox.Show("Hata: Bir Sorun Oluştu... \n Hata = Yolcu Silinemedi...");
            }
            finally
            {
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SQLiteConnection baglanti = new SQLiteConnection("Data Source=C:\\Users\\hakan\\source\\repos\\Performans\\TrenTakipVeriTabanı.db;version=3");
            baglanti.Open();
            SQLiteCommand komut = new SQLiteCommand();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE Yolcular SET YolcuAdı='" +textBox2.Text+ "', YolcuSoyadı='" +textBox3.Text+ "',GidilecekYer='" +comboBox1.Text + "' WHERE KoltukNo='" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            baglanti.Close();
            listele();
        }
    }
}
