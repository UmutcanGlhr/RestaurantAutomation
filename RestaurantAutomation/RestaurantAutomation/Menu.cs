using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace RestaurantAutomation
{
    public partial class Menu : Form
    {


        MySqlConnection con = new MySqlConnection("Server=localhost;Database=restaurant;Uid=root;Pwd='mysql1234';");
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            MySqlCon.baglanti();
            gridAyari();
            gridAc();

        }

        
        void gridAyari()
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToDeleteRows = false;  
        }
        void gridAc()
        {
            con.Open();
            MySqlDataAdapter sqlda = new MySqlDataAdapter("select * from menu ", con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
           
            con.Close();
        }

        void ekle()
        {
            if (textBox1.Text!=""&& textBox2.Text != "" && textBox3.Text != "" )
            {
                MySqlCon.Command("INSERT INTO menu (urunadi,urunfiyati,urunkodu) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "');");
                gridAc();
            }
            else
            {
                MessageBox.Show("Bütün alanları doldurduğunuza emin olun.");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ekle();
        }

        void guncelle()
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                MySqlCon.Command("UPDATE menu SET urunfiyati = '" + textBox2.Text + "' Where urunkodu= '" + textBox3.Text + "'");
                gridAc();
            }
            else
            {
                MessageBox.Show("Ürün kodunu ve fiyatını giriniz.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            guncelle();
        }

        void sil()
        {
            if (textBox3.Text != "")
            {
                MySqlCon.Command("DELETE FROM menu WHERE urunkodu='" + textBox3.Text + "'");
                gridAc();
            }
            else
            {
                MessageBox.Show("Ürün kodunu giriniz.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sil();
        }
    }
}
