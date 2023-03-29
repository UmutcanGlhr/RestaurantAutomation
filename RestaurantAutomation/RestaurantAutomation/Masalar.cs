using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurantAutomation
{
    public partial class Masalar : Form
    {
        public Masalar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no = "masa1";
            islem islm = new islem();
            islm.urunleriAl(no);
            islm.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string no = "masa2";
            islem islm = new islem();
            islm.urunleriAl(no);
            islm.Show();
        }
    }
}
