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
    public partial class Form3 : Form
    {
        string[] harfler = new string[8];
        int harfsayac = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                if (harfsayac < 8)
                {
                    harfler[harfsayac] = textBox1.Text;
                    harfsayac++;
                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Boş veri girişi yapılamaz !!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int i = 0; i < harfler.Length; i++)
            {
                if (harfler[i] != null)
                {
                    listBox1.Items.Add(harfler[i]);

                }
            }
        }
    }
}
