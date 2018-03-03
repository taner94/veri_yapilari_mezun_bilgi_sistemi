using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(278, 148);
            Sifirla();
            btnGRSKullanici.Visible = true;
            btnGRSSirket.Visible = true;
            AktifKisi = new Kisi();
            AktifSirket = new Sirket();
            add1(12);
            add1(10);
            SirketADD("ades");
            SirketADD("ebay");
            MessageBox.Show(Eleman.DugumleriYazdir());
            MessageBox.Show(Sirketler.DisplayHeap());
        }

        Heap Sirketler = new Heap(100);
        İkiliAramaAgaci Eleman = new İkiliAramaAgaci();
        public List<Ilan> Ilanlar = new List<Ilan>();
        Kisi AktifKisi;
        Sirket AktifSirket;

        //sirket girisi
        private void btnSgiris_Click(object sender, EventArgs e)
        {
            Sirket k = new Sirket();
            k = Sirketler.Getir(txtSRKTGRSad.Text).Deger;
            if (k != null)
            {
                if (k.Tel == Convert.ToInt32((txtSRKTGRStel.Text)) && (string.Compare(k.Ad, txtSRKTGRSad.Text) == 0))
                {
                    AktifSirket = k;
                    MessageBox.Show("Giris Basarili");
                    BilgiGoster(2);
                    tabControlSirket.Visible = true;
                    this.tabControlSirket.Location = new System.Drawing.Point(4, 2);
                    this.ClientSize = new System.Drawing.Size(606, 338);
                    txtSRKTGRStel.Text = txtSRKTGRSad.Text = "";
                    Yarat(1);
                }
                else
                {
                    MessageBox.Show("Hatali giris...");
                }
            }
        }
        //sirket kaydi yapma
        private void btnSirketKayit_Click(object sender, EventArgs e)
        {
            Sirket s = new Sirket();
            s.Ad = "1" + txtSRKTKYTAdi.Text;
            s.Adres = txtSRKTKYTadres.Text;
            s.Eposta = txtSRKTKYTePosta.Text;
            s.Fax = Convert.ToInt32(txtSRKTKYTfax.Text);
            s.Tel = Convert.ToInt32(txtSRKTKYTtel.Text);
                        AktifSirket = s;
            Sirketler.Insert(s);
            BilgiGoster(2);
            temizleClick(2);

            Yarat(1);
            MessageBox.Show(Sirketler.DisplayHeap());
        }
        //sirket bilgilerini guncelleme
        private void btnSirketGncelle_Click(object sender, EventArgs e)
        {
            Sirket s = new Sirket();
            Sirketler.RemoveMax();
            s.Ad ="1"+ txtSRKTGNCLad.Text;
            s.Adres = txtSRKTGNCLadres.Text;
            s.Eposta = txtSRKTGNCLePosta.Text;
            s.Fax = Convert.ToInt32(txtSRKTGNCLfax.Text);
            s.Tel = Convert.ToInt32(txtSRKTGNCLtel.Text);

            Sirketler.Insert(s);
            BilgiGoster(2);
            
            AktifSirket = s;
            MessageBox.Show(Sirketler.DisplayHeap());
        }
        private void btnSRKTilanver_Click(object sender, EventArgs e)
        {
            AktifSirket.Ilanlar = new Ilan();
            AktifSirket.Ilanlar.Tanımı = txtSRKTistanimi.Text;
            AktifSirket.Ilanlar.Ozellikler = txtSRKTozellikler.Text;
            listBoxIlanlar.Items.Add(AktifSirket.Ad + "\t" + AktifSirket.Ilanlar.Tanımı + "\t" + AktifSirket.Ilanlar.Ozellikler);
            MessageBox.Show("ilan verildi");
            txtSRKTistanimi.Text = txtSRKTozellikler.Text = "";
        }



















        //Kisi girisi
        private void btnKgiris_Click(object sender, EventArgs e)
        {
            Kisi k = new Kisi();
            k = Eleman.Ara(Convert.ToInt32((txtKISIGRSogrno.Text)));
            if (k != null)
            {
                if (k.egt.OgrNo == Convert.ToInt32((txtKISIGRSogrno.Text)) && (string.Compare(k.Isim, txtKISIGRSisim.Text) == 0))
                {
                    AktifKisi = k;
                    MessageBox.Show("Giris Basarili");
                    BilgiGoster(1);
                    Yarat(0);
                    txtKISIGRSogrno.Text = txtKISIGRSisim.Text = "";
                }
                else
                {
                    MessageBox.Show("Hatali giris...");
                }
            }      
        }     
        //Kisi Ekleme
        private void btnKisiKayit_Click(object sender, EventArgs e)
        {
            
            Egitim egt = new Egitim();
            Staj stj = new Staj();
            Liste lst = new Liste();
            Kisi kisi = new Kisi();

            kisi.Adres = txtKISIAdres.Text;
            kisi.DTarihi = dateTimePickerKISIDtarihi.Value.ToString();
            kisi.ePosta = txtKISIeposta.Text;
            kisi.IlgiAlanı = txtKISIilgi.Text;
            kisi.Isim = txtKISIisim.Text;
            //kisi.MDurumu = RadioKISIbekar   RadioKISIevli
            kisi.Tel = Convert.ToInt32(txtKISItel.Text);
            kisi.Uyruk = txtKISIuyruk.Text;

            egt.NotORT = Convert.ToDouble(txtKISIort.Text);
            egt.OgrNo = Convert.ToInt32(txtKISIogrno.Text);
            egt.BasTar = dateTimePickerKISIbas.Value.ToString();
            egt.BitTar = dateTimePickerKISIbit.Value.ToString();
            egt.BolumAdi = comboBoxKISIbolum.Text;
            egt.Ydil = comboBoxKISIdil.Text;
            egt.Belge = Convert.ToBoolean(comboBoxKISIbelge.Text == "Var");

            stj.Departman = txtKISISirketdepartman.Text;
            stj.SirkedAdi = txtKISISirketadi.Text;
            stj.StajTarihi = Convert.ToInt32(comboBoxKISIStajtarihi.Text);

            lst.InsertFirst(stj, egt);

            kisi.egt = egt;
            kisi.stj = stj;
            kisi.Egtim_Staj = lst;
            AktifKisi = kisi;

            temizleClick(1);
            BilgiGoster(1);
            Eleman.Ekle(AktifKisi);
            MessageBox.Show(Eleman.DugumleriYazdir());
            Yarat(0);
        }
        // Kisi Guncelleme
        private void button8_Click(object sender, EventArgs e)
        {
	        Eleman.Sil(AktifKisi);
            Egitim egt = new Egitim();
            Staj stj = new Staj();
            Liste lst = new Liste();
            Kisi kisi = new Kisi();


            kisi.Adres = txtKISIGNCLadres.Text;
            kisi.DTarihi =dateTimePickerKISIGNCLdtarihi  .Value.ToString();
            kisi.ePosta = txtKISIGNCLePosta.Text;
            kisi.IlgiAlanı = txtKISIGNCLilgi.Text;
            kisi.Isim = txtKISIGNCLisim.Text;
            //kisi.MDurumu = RadioKISIbekar   RadioKISIevli
            kisi.Tel = Convert.ToInt32(txtKISIGNCLtel.Text);
            kisi.Uyruk = txtKISIGNCLuyruk.Text;

            egt.NotORT = Convert.ToDouble(txtKISIGNCLotr.Text);
            egt.OgrNo = Convert.ToInt32(txtKISIGNCLogrNo.Text);
            egt.BasTar = dateTimePickerKISIGNCLbas.Value.ToString();
            egt.BitTar = dateTimePickerKISIGNCLbit.Value.ToString();
            egt.BolumAdi = comboBoxKISIGNCLbolum.Text;
            egt.Ydil = comboBoxKISIGNCLdil.Text;
            egt.Belge = Convert.ToBoolean(comboBoxKISIGNCLbelge.Text == "Var");

            stj.Departman = txtKISIGNCLSRKTdepartman.Text;
            stj.SirkedAdi = txtKISIGNCLSRKTadi.Text;
            stj.StajTarihi = Convert.ToInt32(comboBoxKISIGNCLSRKTtarih.Text);


            lst.InsertFirst(stj,egt);

            kisi.egt = egt;
            kisi.stj = stj;
            kisi.Egtim_Staj = lst;
            AktifKisi = kisi;
            Eleman.Ekle(kisi);
            MessageBox.Show(Eleman.DugumleriYazdir());         
        }
        //is basvurusunda bulunma//
        private void btnKISIisbasvurusu_Click(object sender, EventArgs e)
        {
            listBoxSRKTisbasvurulari.Items.Add(listBoxIlanlar.SelectedItem + "\t" + AktifKisi.Isim + "\t" + AktifKisi.egt.NotORT + "\t" + AktifKisi.egt.Ydil + "\t" + AktifKisi.Tel);
            AktifSirket.Ilanlar.Basvuranlar.Add(AktifKisi);
            MessageBox.Show("Basvuru Yapildi...Iyi Sanslar dileriz.:D");
        }



















        //aktif kisinin bilgilerini x e gore degistirme
        private void BilgiGoster(int x)
        {
            if (x == 1)
            {
                txtKISIGNCLadres.Text = AktifKisi.Adres;
                txtKISIGNCLdyeri.Text = AktifKisi.DYeri;
                txtKISIGNCLePosta.Text = AktifKisi.ePosta;
                txtKISIGNCLilgi.Text = AktifKisi.IlgiAlanı;
                txtKISIGNCLisim.Text = AktifKisi.Isim;
                txtKISIGNCLtel.Text = AktifKisi.Tel.ToString();
                txtKISIGNCLuyruk.Text = AktifKisi.Uyruk;
                //radioKISIGNCLbekar.Text = kisi.MDurumu;
                //radioKISIGNCLevli.Text = kisi.;
                dateTimePickerKISIGNCLdtarihi.Value = DateTime.Now;
                comboBoxKISIGNCLbolum.Text = AktifKisi.egt.BolumAdi;
                comboBoxKISIGNCLdil.Text = AktifKisi.egt.Ydil;
                txtKISIGNCLogrNo.Text = AktifKisi.egt.OgrNo.ToString();
                txtKISIGNCLotr.Text = AktifKisi.egt.NotORT.ToString();
                comboBoxKISIGNCLbelge.Text = AktifKisi.egt.Belge.ToString();
                //dateTimePickerKISIGNCLbas.Value = Convert.ToDateTime(AktifKisi.egt.BasTar);
                //dateTimePickerKISIGNCLbit.Value = Convert.ToDateTime(AktifKisi.egt.BitTar);
                comboBoxKISIGNCLSRKTtarih.Text = AktifKisi.stj.StajTarihi.ToString();
                txtKISIGNCLSRKTadi.Text = AktifKisi.stj.SirkedAdi;
                txtKISIGNCLSRKTdepartman.Text = AktifKisi.stj.Departman;
            }
            else
            {
                txtSRKTGNCLad.Text = AktifSirket.Ad;
                txtSRKTGNCLadres.Text = AktifSirket.Adres;
                txtSRKTGNCLePosta.Text = AktifSirket.Eposta;
                txtSRKTGNCLfax.Text = AktifSirket.Fax.ToString();
                txtSRKTGNCLtel.Text = AktifSirket.Tel.ToString();
            }    
        }
        //sirkete giris
        private void btnGRSSirket_Click(object sender, EventArgs e)
        {
            Sifirla();
            groupBoxSgirket.Visible = true;
            this.ClientSize = new System.Drawing.Size(287, 148);
            this.groupBoxSgirket.Location = new System.Drawing.Point(12, 12);
        }
        //sirket kayit
        private void btnSKayit_Click(object sender, EventArgs e)
        {
            Sifirla();
            groupBoxSkayit.Visible = true;
            this.ClientSize = new System.Drawing.Size(320, 257);
            this.groupBoxSkayit.Location = new System.Drawing.Point(12, 12);
        }
        //kulllanici kaydetme.;
        private void btnKkayit_Click(object sender, EventArgs e)
        {
            
            Sifirla();
            groupBoxKkayit.Visible = true;
            this.ClientSize = new System.Drawing.Size(626, 374);
            this.groupBoxKkayit.Location = new System.Drawing.Point(12, 9);
        }

        //kullaniciyi listeye kaydetme.
        private void btnGRSKullanici_Click_1(object sender, EventArgs e)
        {
            Sifirla();
            groupBoxKgiris.Visible = true;
            this.groupBoxKgiris.Location = new System.Drawing.Point(12, 12);
        }
        //baslangicadaki gibi formu sifirlama
        public void Sifirla()
        {
            groupBoxKgiris.Visible = false;
            groupBoxSgirket.Visible = false;
            groupBoxSkayit.Visible = false;
            groupBoxKkayit.Visible = false;
            btnGRSKullanici.Visible = false;
            btnGRSSirket.Visible = false;
            tabControlKisi.Visible = false;
            tabControlSirket.Visible = false;
        }
        //kisi baslangic deger atamasi
        public void add1(int x)
        {
            Egitim egt = new Egitim();
            Staj stj = new Staj();
            Liste lst = new Liste();
            Kisi kisi = new Kisi();

            kisi.Adres = "Izmir Bergama";
            kisi.DTarihi = "05.09.1997";
            kisi.ePosta = "";
            kisi.IlgiAlanı = "";
            kisi.Isim = "a";
            kisi.MDurumu = "Bekar";
            kisi.Tel = 0123;
            kisi.Uyruk = "Turk";
            
            egt.NotORT = 3;
            egt.OgrNo = x;
            egt.BasTar = "09.09.2015";
            egt.BitTar = "06.06.2017";
            egt.BolumAdi = "Yazilim Muhendisligi";
            egt.Ydil = "İngilizce";
            egt.Belge = false;
            
            stj.Departman = "Yazilim";
            stj.SirkedAdi = "Ades Yazilim";
            stj.StajTarihi = 2018;
            


            lst.InsertFirst(stj, egt);

            kisi.egt = egt;
            kisi.stj = stj;
            kisi.Egtim_Staj = lst;
            AktifKisi = kisi;

            Eleman.Ekle(AktifKisi);
        }
        //sirket baslangic deger atamasi
        public void SirketADD(string a)
        {
            Sirket s = new Sirket();
            s.Ad = a;
            s.Adres = "Izmir";
            s.Eposta = "sss";
            s.Fax = 123;
            s.Tel = 123;
            Sirketler.Insert(s);
        }
        //sirket veya kisiye gore formu seklillendirme fonk
        public void Yarat(int x)
        {
            if (x == 0)
            {
                Sifirla();
                tabControlKisi.Visible = true;
                this.tabControlKisi.Location = new System.Drawing.Point(4, 2);
                this.ClientSize = new System.Drawing.Size(636, 411);
            }
            else
            {
                Sifirla();
                tabControlSirket.Visible = true;
                this.tabControlSirket.Location = new System.Drawing.Point(4, 2);
                this.ClientSize = new System.Drawing.Size(606, 338);
            }
            
        }
        //textboxlari teminzleme fonksiyonu
        private void temizleClick(int x)
        {
            if (x == 1)
            {
                txtKISIGNCLadres.Text = "";
                txtKISIGNCLdyeri.Text = "";
                txtKISIGNCLePosta.Text = "";
                txtKISIGNCLilgi.Text = "";
                txtKISIGNCLisim.Text = "";
                txtKISIGNCLtel.Text = "";
                txtKISIGNCLuyruk.Text = "";
                //radioKISIGNCLbekar.Text = kisi.MDurumu;
                //radioKISIGNCLevli.Text = kisi.;
                //dateTimePickerKISIGNCLdtarihi.Text = ;
                comboBoxKISIGNCLbolum.Text = "";
                comboBoxKISIGNCLdil.Text = "";
                txtKISIGNCLogrNo.Text = "";
                txtKISIGNCLotr.Text = "";
                // comboBoxKISIGNCLbelge.Text = kisi.egt.Belge;
                // dateTimePickerKISIGNCLbas.Text = kisi.egt.BasTar;
                // dateTimePickerKISIGNCLbit.Text = kisi.egt.BitTar;
                comboBoxKISIGNCLSRKTtarih.Text = "";
                txtKISIGNCLSRKTadi.Text = "";
                txtKISIGNCLSRKTdepartman.Text = "";
            }
            else
            {
                txtSRKTKYTAdi.Text = "";
                txtSRKTKYTadres.Text = "";
                txtSRKTKYTePosta.Text = "";
                txtSRKTKYTfax.Text = "";
                txtSRKTKYTtel.Text = "";
            }
                    
        }
        //cikis isleminde basa donmek icin.
        private void btncik(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(278, 148);
            Sifirla();
            btnGRSKullanici.Visible = true;
            btnGRSSirket.Visible = true;
        }

        //kensini yok etme sirket
        private void button6_Click(object sender, EventArgs e)
        {
            Sirketler.RemoveMax();
            MessageBox.Show(Sirketler.DisplayHeap());
            this.ClientSize = new System.Drawing.Size(278, 148);
            Sifirla();
            btnGRSKullanici.Visible = true;
            btnGRSSirket.Visible = true;
        }

        //kensini yok etme kisi
        private void button7_Click(object sender, EventArgs e)
        {
            Eleman.Sil(AktifKisi);
            MessageBox.Show(Eleman.DugumleriYazdir());
            this.ClientSize = new System.Drawing.Size(278, 148);
            Sifirla();
            btnGRSKullanici.Visible = true;
            btnGRSSirket.Visible = true;
        }
        Kisi[] K = new Kisi[100];
      
        private void button17_Click(object sender, EventArgs e)
        {
            K = AktifSirket.Ilanlar.Basvuranlar.ToArray();
            listBoxSRKTisbasvurulari.Items.Clear();
            string temp = "";
            for (int i = 0; i <K.Length; i++)
            {
                if (string.Compare(K[i].Isim,TxtIsimArama.Text)==0)
                {
                    temp += K[i].Isim;
                    listBoxSRKTisbasvurulari.Items.Add("İsme göre sıralama\t" + K[i].Isim + "\t" + K[i].egt.NotORT+ "\t"+K[i].egt.Ydil); ;
                }

            }
           
        }

        private void button16_Click(object sender, EventArgs e)
        {
            K = AktifSirket.Ilanlar.Basvuranlar.ToArray();
            listBoxSRKTisbasvurulari.Items.Clear();
            string temp = "";
            for (int i = 0; i < K.Length; i++)
            {
                if ((K[i].egt.NotORT*25) >= 90)
                {
                    temp += K[i].egt.NotORT * 25;
                    listBoxSRKTisbasvurulari.Items.Add("Ortalması 90'dan büyükler\t" + K[i].Isim + "\t" + K[i].egt.NotORT); ;
                }

            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            K = AktifSirket.Ilanlar.Basvuranlar.ToArray();
            listBoxSRKTisbasvurulari.Items.Clear();
            string temp = "";
            for (int i = 0; i < K.Length; i++)
            {
                if (string.Compare(K[i].egt.Ydil,"İngilizce")==0)
                {
                    temp += K[i].Isim;
                    listBoxSRKTisbasvurulari.Items.Add("İngilizce bilenler\t" + K[i].Isim+ "\t" + K[i].egt.NotORT);

                }

            }
        }
    }
}