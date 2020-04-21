using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace birkelimetasarim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //seçilen yönteme göre farklı formlara yönlendirilecek
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 randform = new Form2();
            randform.Show();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Form3 manuelform = new Form3();
            manuelform.Show();
        }

    }
}
