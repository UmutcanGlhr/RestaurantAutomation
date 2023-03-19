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
    public partial class islem : Form
    {
        MySqlConnection con = new MySqlConnection("Server=localhost;Database=restaurant;Uid=root;Pwd='mysql1234';");
        object[] adet = new object[] {"1","2","3" };
        string masano;
        public islem()
        {
            InitializeComponent();
            
            
        }

        private void islem_Load(object sender, EventArgs e)
        {
            gridac();
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select urunadi from menu",con);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader["urunadi"]);
            }
            con.Close();
            comboBox2.Items.AddRange(adet);
        }



      


        void gridac()
        {
            con.Open();
            MySqlDataAdapter sqlda = new MySqlDataAdapter("select * from "+masano+"", con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = new MySqlCommand("Select urunfiyati from menu Where urunadi = '"+comboBox1.Text+"'", con);
            string urun = Convert.ToString(cmd.ExecuteScalar()); ;

            if (comboBox1.Text!=""&&comboBox2.Text!="")
            {
                MySqlCon.Command("Inset Into "+masano+" (urunadi,urunfiyati,urunadedi) values ('"+comboBox1.Text+"','"+urun+"','"+comboBox2.Text+"')");
                gridac();
            }
            else
            {
                MessageBox.Show("Boş Alan ");
            }
        }


        public void urunleriAl(string masaadi)
        {
            masano = masaadi;

        }
        public override string ToString()
        {
            return masano;

        }
    }
}
