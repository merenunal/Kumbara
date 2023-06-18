using Kumbara;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelalKumbara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static KumbaraNesne kumbaraNesne = new KumbaraNesne();

        public static List<EklenecekTutar> tutar = new List<EklenecekTutar>();
        public static List<EklenecekTutar> mevcutTutar = new List<EklenecekTutar>();


        public int kontrol = 0;

        public static List<Para> banknotlar = new List<Para>()
        {
            
            new Para {ParaAdi = "5 TL", Degeri = 5, Hacmi = 72*130*0.25},
            new Para {ParaAdi = "10 TL", Degeri = 10, Hacmi = 72*136*0.25},
            new Para {ParaAdi = "20 TL", Degeri = 20, Hacmi = 72*142*0.25},
            new Para {ParaAdi = "50 TL", Degeri = 50, Hacmi = 72*148*0.25},
            new Para {ParaAdi = "100 TL", Degeri = 100, Hacmi = 72*154*0.25},
            new Para {ParaAdi = "200 TL", Degeri = 200, Hacmi = 72*160*0.25},
        };

        public static List<Para> madeniler = new List<Para>()
        {
            new Para {ParaAdi = "1 Kuruş", Degeri = 0.01, Hacmi = 3.14*17*17*1.65},
            new Para {ParaAdi = "10 Kuruş", Degeri = 0.1, Hacmi = 3.14*19.25*19.25*1.7},
            new Para {ParaAdi = "25 Kuruş", Degeri = 0.25, Hacmi = 3.14*21.5*21.5*1.9},
            new Para {ParaAdi = "50 Kuruş", Degeri = 0.50, Hacmi = 3.14*23.85*23.85*1.95},
            new Para {ParaAdi = "1 TL", Degeri = 1, Hacmi = 3.14*26.15*26.15*1.95}
        };


        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Para item in madeniler)
                comboBox1.Items.Add(item);

            foreach (Para item in banknotlar)
                comboBox1.Items.Add(item);

            comboBox1.SelectedIndex = 0;
            listBox1.Visible = false;

            kumbaraNesne.hacmi = 50000;
            button3.Enabled = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            EklenecekTutar yeniTutar = new EklenecekTutar();
            yeniTutar.SeciliPara = (Para)comboBox1.SelectedItem;

            yeniTutar.Adet = Convert.ToInt32(numericUpDown1.Value);
            yeniTutar.Hesapla();

            mevcutTutar.Add(yeniTutar);
            tutar.Add(yeniTutar);

            listBox1.Items.Add(yeniTutar);

            if(HacimHesapla() > kumbaraNesne.hacmi)
            {
                MessageBox.Show("Kumbaranın hacmi dolmuştur");
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private double TutarHesapla()
        {
            double toplamTutar = 0;

            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                EklenecekTutar gelen = (EklenecekTutar)listBox1.Items[i];
                toplamTutar += gelen.ToplamTutar;
            }

            label2.Text = toplamTutar.ToString();
            kumbaraNesne.toplamDegeri = toplamTutar;
            return kumbaraNesne.toplamDegeri;
        }

        private double HacimHesapla()
        {
            double toplamHacim = 0;
            kumbaraNesne.mevcutHacmi = 0;
            
            for(int i = 0; i < listBox1.Items.Count; i++)
            {
                EklenecekTutar gelen = (EklenecekTutar)listBox1.Items[i];
                toplamHacim += gelen.SeciliPara.Hacmi * gelen.Adet;
            }
            label6.Text = toplamHacim.ToString();
            kumbaraNesne.mevcutHacmi = toplamHacim;
            return kumbaraNesne.mevcutHacmi;
        }

        private void Sıfırla()
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(kontrol < 1)
            {
                listBox1.Visible = true;
                TutarHesapla();
                HacimHesapla();
                button3.Enabled = true;
            }
            else
            {
                listBox1.Visible = true;
                TutarHesapla();
                HacimHesapla();
                button3.Enabled = false;
                MessageBox.Show("Kumbara ikinci kez kırılamaz");
            }
            kontrol++;

            button1.Enabled = false;
            button2.Enabled = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            Sıfırla();
            listBox1.Visible = false;
            kumbaraNesne.toplamDegeri = 0;
            kumbaraNesne.mevcutHacmi = 0;
            TutarHesapla();
        }
    }
}