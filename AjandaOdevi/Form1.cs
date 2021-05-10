using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AjandaOdevi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.Columns.Add("Öğrenci No ");
            listView1.Columns.Add("Ad ");
            listView1.Columns.Add("Soyad ");
            listView1.Columns.Add("Memleket ");
            listView1.Columns.Add("e-Posta ");
            listView1.Columns.Add("Tel ");
            listView1.Columns.Add("Bölüm ");
            listView1.Columns.Add("Cinsiyet ");          //  LİSTVİEW'İN SÜTUNLARINI OLUŞTURDUK. 



            string[] bölüm = {"Bilgisayar Mühendisliği", "Makine Mühendisliği" };  // COMBOBOX'IN İÇERİĞİNİ OLUŞTURDUK.
            comboBox1.Items.AddRange(bölüm);               
            kayitSayisiHesapla();

         }

        private void kayitSayisiHesapla()                // BİR ÇOK DEFA KULLANILACAĞINDAN PRATİK OLMASI İÇİN METOD OLUŞTURDUK.
        {
            int kayitSayisi = listView1.Items.Count;     // KAYIT SAYISINI HESAPLAMAK ADINA SAYAÇ KULANDIK.
            label9.Text = Convert.ToString(kayitSayisi); // CONVERT İLE DÖNÜŞÜM YAPTIK.
            progressBar1.Value = kayitSayisi;            // KAYIT SAYISINI PROGRESSBAR İLE GÖSTERMEK İÇİN BAĞLANTI KURDUK.
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string no = "", ad = "", soyad = "", memleket = "", posta = "", tel = "", bolum = "", cinsiyet = "";  //  DEĞİŞKENLERİMİZİ TANIMLADIK STRING OLARAK.

            no = textBox1.Text; ad = textBox2.Text; soyad = textBox3.Text; memleket = textBox4.Text; posta = textBox5.Text;  // TANIMLADIĞIMIZ DEĞİŞKENLERİ YERLERİNE ATADIK.
            tel = textBox6.Text; bolum = comboBox1.Text;                                      

            if (radioButton1.Checked == true) cinsiyet = radioButton1.Text;    // CİNSİYET SEÇENEKLERİNDEN HANGİSİNİN SEÇİŞDİĞİNİ İF KULLANARAK KONTROLE TABİ TUTTUK.
            if (radioButton2.Checked == true) cinsiyet = radioButton2.Text;

            
            
            string[] bilgiler = { no, ad, soyad, memleket, posta, tel, bolum, cinsiyet };  // DİZİ OLUŞTURDUK.


            

            bool kayitArama = false;
            for (int i = 0; i < listView1.Items.Count; i++)        // DÖNGÜ İLE DİZİDEKİ TÜM KAYITLARI GÖRÜNTÜLEYEBİLDİK.
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text) // GİRDİĞİMİZ ÖĞRENCİ NUMARASI EĞER ÖNCEDEN KAYITLIYSA TEKRAR KAYDINI ENGELLEDİK.
                {
                    kayitArama = true;
                    MessageBox.Show(textBox1.Text + " Öğrenci Numarası Kayıtlarda Zaten Mevcut!");  // EKRANA UYARI MESAJI YAZDIRDIK.
                }
            }
            if (kayitArama == false) 
            {
                ListViewItem lst = new ListViewItem(bilgiler);  
                if (no != "" && ad != "" && soyad != "" && memleket != "" && posta != "" && tel != "" && bolum != "" && cinsiyet != "") 
                {
                    listView1.Items.Add(lst);  // EĞER ARAMAMIZ SONUCU FALSE İSE YANİ GİRDİĞİMİZ ÖĞRENCİ NO KAYITLI DEĞİLSE VE YNI ZAMANDA ALANLAR EKSİKSİZ DOLDURULMUŞ İSE;
                                               //ÖĞRENCİNİN SİSTEME KAYDINI EKLEME METODUYLA GERÇEKLEŞTİRDİK.
                }
                else
                    MessageBox.Show("Lütfen Tüm Alanları Doldurunuz.");  // EĞER ALANLARDAN BİRİ BOŞ BIRAKILDIYSA EKRANA UYARI YAZDIRDIK.
            }
            kayitSayisiHesapla();   // METODU ÇAĞIRARAK İŞLEMLERİN SONUCUNDA ULAŞILAN KAYIT SAYISINI GÖSTERDİK.

        }



        private void button2_Click(object sender, EventArgs e)
        {
            int secilenSayisi = listView1.CheckedItems.Count;
            foreach (ListViewItem seciliKayitBilgisi in listView1.CheckedItems)
            {
                seciliKayitBilgisi.Remove();    // LİSTVİEW'DE SEÇİLİ CHECKBOX'U İSE SİLME İŞLEMİNİ GERÇEKLEŞTİRDİK.
            }
            MessageBox.Show(secilenSayisi.ToString() + " Adet  Kayıt Silindi.");
            kayitSayisiHesapla();      // METODU ÇAĞIRARAK İŞLEMLERİN SONUCUNDA ULAŞILAN KAYIT SAYISINI GÖSTERDİK.

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int secilenSayisi = listView1.SelectedItems.Count;
            foreach (ListViewItem seciliKayitBilgisi in listView1.SelectedItems)
            {
                seciliKayitBilgisi.Remove();    // LİSTVİEW'DE SEÇİLİ SÜTUNU İSE SİLME İŞLEMİNİ GERÇEKLEŞTİRDİK.
            }
            MessageBox.Show(secilenSayisi.ToString() + " Adet  Kayıt Silindi.");
            kayitSayisiHesapla();
        }



        private void button6_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();   // CLEAR METODU İLE TÜMÜNÜ SİL İŞLEMİNİ GERÇEKLEŞTİRDİK.
            kayitSayisiHesapla();
        }



        private void button3_Click(object sender, EventArgs e)
        {
            bool arananKayit = false;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    arananKayit = true;
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    textBox3.Text = listView1.Items[i].SubItems[2].Text;
                    textBox4.Text = listView1.Items[i].SubItems[3].Text;
                    textBox5.Text = listView1.Items[i].SubItems[4].Text;
                    textBox6.Text = listView1.Items[i].SubItems[5].Text;
                    comboBox1.Text = listView1.Items[i].SubItems[6].Text;  // GİRİLEN KAYDIN DAHA ÖNCE KAYDEDİLENLER İLE AYNI OLUP OLMADIĞINI İF İLE KONTROL ETTİK.

                    if (listView1.Items[i].SubItems[7].Text == "Kadın")
                    {
                        radioButton1.Checked = true;
                    }
                    else if (listView1.Items[i].SubItems[7].Text== "Erkek")
                    {
                        radioButton2.Checked = true;
                    }

                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;
                    comboBox1.Enabled = false;
                    groupBox1.Enabled = false;  // EĞER AYNI ÖĞRENCİ NUMARASI ARAMA İŞEMİMİZ SONUCUNDA BULUNUNAN NUMARANIN DİĞER BİLGİLERİ DE FORMUMUZDA SEÇİLİ OLARAK GÖSTERİLDİ.

                }
            }
            if (arananKayit==false)            // ÖĞRENCİ NUMARASI KAYITLI OLANLAR ARASINDA BULUNAMADIYSA EKRANA MESAJ YAZDIRDIK.
            {
                MessageBox.Show(textBox1.Text + " Öğrenci Numaralı Kayıt Bulunamadı...");
            }
        }



        private void button4_Click(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            comboBox1.Enabled = true;
            groupBox1.Enabled = true;  // BULUNAN KAYIT SONUCUNDA GETİRİLEN BİLGİLERİN SEÇİŞİ OLMASINI ORTADAN KALDIRDIK VE YENİ KAYIT OLUŞTURMAYA HAZIR HALE GETİRDİK.
        }



        private void button10_Click(object sender, EventArgs e)
        {
            String myPath = @"C:\WINDOWS\system32\notepad.exe";    // NOT DEFTERİ EKLENDİ.
            System.Diagnostics.Process islem = new System.Diagnostics.Process();
            islem.StartInfo.FileName = myPath;
            islem.Start();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)   // TEXTBOXLARIN FONT AYARLARLARINI DEĞİŞTİREBİLME BUTONU OLUŞTURDUK.
            {
                textBox1.Font = fontDialog1.Font;
                textBox2.Font = fontDialog1.Font;
                textBox3.Font = fontDialog1.Font;
                textBox4.Font = fontDialog1.Font;
                textBox5.Font = fontDialog1.Font;
                textBox6.Font = fontDialog1.Font;
               
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)    // TEXTBOXLARIN YAZI RENGİNİ DEĞİŞTİREBİLME BUTONU OLUŞTURDUK.
            {
                textBox1.ForeColor = colorDialog1.Color;
                textBox2.ForeColor = colorDialog1.Color;
                textBox3.ForeColor = colorDialog1.Color;
                textBox4.ForeColor = colorDialog1.Color;
                textBox5.ForeColor = colorDialog1.Color;
                textBox6.ForeColor = colorDialog1.Color;              
            }
       }

        private void button9_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)   // FORM RENGİNİ DEĞİŞTİREBİLME BUTONU OLUŞTURDUK. 
            {
                this.BackColor = colorDialog1.Color;
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            String myPath = @"C:\WINDOWS\system32\mspaint.exe";   // PAINT EKLENDİ.
            System.Diagnostics.Process islem = new System.Diagnostics.Process();
            islem.StartInfo.FileName = myPath;
            islem.Start();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            String myPath = @"C:\WINDOWS\system32\calc.exe";     // HESAP MAKİNESİ EKLENDİ.
            System.Diagnostics.Process islem = new System.Diagnostics.Process();
            islem.StartInfo.FileName = myPath;
            islem.Start();

        }

       
    }
}
