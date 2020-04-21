using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace birkelimetasarim
{
    public partial class Form2 : Form
    {
        private static IEnumerable<string> Permutate(string source)
        {
            if (source.Length == 1) return new List<string> { source };

            var permutations = from c in source
                               from p in Permutate(new String(source.Where(x => x != c).ToArray()))
                               select c + p;

            return permutations;
        }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            listBox1.Items.Clear();
            string[] sesli = { "A", "E", "I", "İ", "O", "Ö", "U", "Ü" };
            string[] sessiz = { "B", "C", "Ç", "D", "F", "G", "Ğ", "H", "J", "K", "L", "M", "N", "P", "R", "S", "Ş", "T", "V", "Y", "Z" };
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                textBox1.Text += sesli[rand.Next(sesli.Length)].ToLower();
                textBox1.Text += sessiz[rand.Next(sessiz.Length)].ToLower();

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string uret = "";
            uret = textBox1.Text;
            char[] degisken = uret.ToCharArray();
            string[] miktar = new string[textBox1.Text.Count()];
            for (int i = 0; i < textBox1.Text.Count(); i++)
            {
                miktar[i] = degisken[i].ToString();
            }

            int kombinasyon = 3;
            for (int i = 0; i <= miktar.Length; i++)
            {
                var sonuc = Deneme.Combinations(miktar, kombinasyon);
                foreach (var item in sonuc)
                {
                    string s = string.Join("", item.ToArray());
                    listBox1.Items.Add(s);
                }
                kombinasyon++;
            }

            foreach (var p in Permutate(textBox1.Text))
            {
                listBox1.Items.Add($"{p}");
            }

            MessageBox.Show("Karıştırma bitmiştir");
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\bbayr\Downloads\sozluk.accdb");
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("select Alan1 from tablo", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (listBox1.Items[i].ToString() == dr[0].ToString())
                    {
                        listBox2.Items.Add(dr[0].ToString());
                    }
                    if (dr[0].ToString().Length == listBox1.Items[i].ToString().Length + 1)
                    {
                        if (dr[0].ToString().Contains(listBox1.Items[i].ToString()))
                        {
                            listBox2.Items.Add(dr[0].ToString());
                        }
                    }
                }
            }
            baglanti.Close();
            //listbox2'deki tekrarlayan kelimeleri siliyor
            string[] arr = new string[listBox2.Items.Count];
            listBox2.Items.CopyTo(arr, 0);
            var arr2 = arr.Distinct();
            listBox2.Items.Clear();
            foreach (string s in arr2)
            {
                listBox2.Items.Add(s);
            }

            MessageBox.Show("İşlem bitmiştir");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int puan = 0;
            int uzunluk = 0;
            string enUzun = "";

            //listbox2 deki değerleri diziye atıp en uzun kelimeyi textboxa yazıran kod
            string[] veriler1 = new string[listBox2.Items.Count];
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                veriler1[i] = listBox2.Items[i].ToString();
            }
            for (int i = 0; i < veriler1.Length; i++)
            {
                if (veriler1[i].Length > uzunluk)
                {
                    uzunluk = veriler1[i].Length;
                    enUzun = veriler1[i];

                }
                textBox2.Text = enUzun;

            }

            //harf sayısına göre puanlama yapıyor
            if (textBox2.Text.Length == 3)
            {
                puan += 3;
                label3.Text = puan.ToString();
            }
            else if (textBox2.Text.Length == 4)
            {
                puan += 4;
                label3.Text = puan.ToString();
            }
            else if (textBox2.Text.Length == 5)
            {
                puan += 5;
                label3.Text = puan.ToString();
            }
            else if (textBox2.Text.Length == 6)
            {
                puan += 7;
                label3.Text = puan.ToString();
            }
            else if (textBox2.Text.Length == 7)
            {
                puan += 9;
                label3.Text = puan.ToString();
            }
            else if (textBox2.Text.Length == 8)
            {
                puan += 11;
                label3.Text = puan.ToString();
            }
            else if (textBox2.Text.Length == 9)
            {
                puan += 15;
                label3.Text = puan.ToString();
            }


        }
    }
    public static class Deneme
    {
        public static IEnumerable<IEnumerable<T>> Combinations<T>(this IEnumerable<T> elements, int k)
        {
            return k == 0 ? new[] { new T[0] } : elements.SelectMany((e, i) => elements.Skip(i + 1).Combinations(k - 1).Select(c => (new[] { e }).Concat(c)));
        }
    }
}
