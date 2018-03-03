using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class İkiliAramaAgaci
    {
        private İkiliAramaAgacDugumu kok;
        private string dugumler;
        public İkiliAramaAgaci() { }
        public İkiliAramaAgaci(İkiliAramaAgacDugumu kok)
        {
            this.kok = kok;
        }

        //ekeleme yapilir.
        public void Ekle(Kisi EkleKisi)
        {
            //Yeni eklenecek düğümün parent'ı
            İkiliAramaAgacDugumu tempParent = new İkiliAramaAgacDugumu();
            //Kökten başla ve ilerle
            İkiliAramaAgacDugumu tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                //Deger zaten var, çık.
                if (EkleKisi.egt.OgrNo == (int)tempSearch.veri.egt.OgrNo)
                    return;
                else if (EkleKisi.egt.OgrNo < (int)tempSearch.veri.egt.OgrNo)
                    tempSearch = tempSearch.sol;
                else
                    tempSearch = tempSearch.sag;
            }
            İkiliAramaAgacDugumu eklenecek = new İkiliAramaAgacDugumu(EkleKisi);
            //Ağaç boş, köke ekle
            if (kok == null)
                kok = eklenecek;
            else if (EkleKisi.egt.OgrNo < (int)tempParent.veri.egt.OgrNo)
                tempParent.sol = eklenecek;
            else
                tempParent.sag = eklenecek;
        }
        //silme islemi
        public bool Sil(Kisi SilKisi)
        {
            İkiliAramaAgacDugumu current = kok;
            İkiliAramaAgacDugumu parent = kok;
            bool issol = true;
            //DÜĞÜMÜ BUL
            while ((int)current.veri.egt.OgrNo != SilKisi.egt.OgrNo)
            {
                parent = current;
                if (SilKisi.egt.OgrNo < (int)current.veri.egt.OgrNo)
                {
                    issol = true;
                    current = current.sol;
                }
                else
                {
                    issol = false;
                    current = current.sag;
                }
                if (current == null)
                    return false;
            }
            //DURUM 1: YAPRAK DÜĞÜM
            if (current.sol == null && current.sag == null)
            {
                if (current == kok)
                    kok = null;
                else if (issol)
                    parent.sol = null;
                else
                    parent.sag = null;
            }
            //DURUM 2: TEK ÇOCUKLU DÜĞÜM SOL
            else if (current.sag == null)
            {
                if (current == kok)
                    kok = current.sol;
                else if (issol)
                    parent.sol = current.sol;
                else
                    parent.sag = current.sol;
            }
            //DURUM 2: TEK ÇOCUKLU DÜĞÜM SAG
            else if (current.sol == null)
            {
                if (current == kok)
                    kok = current.sag;
                else if (issol)
                    parent.sol = current.sag;
                else
                    parent.sag = current.sag;
            }
            //DURUM 3: İKİ ÇOCUKLU DÜĞÜM
            else
            {
                İkiliAramaAgacDugumu successor = Successor(current);
                if (current == kok)
                    kok = successor;
                else if (issol)
                    parent.sol = successor;
                else
                    parent.sag = successor;
                successor.sol = current.sol;
            }
            return true;
        }
        private void Ziyaret(İkiliAramaAgacDugumu dugum)
        {
            dugumler += dugum.veri.Isim + "\t" + dugum.veri.Egtim_Staj.DisplayElements() + Environment.NewLine;
        }
        //toplam eleman sayisini dondurur.        
        public string DugumleriYazdir()
        {
            InOrder();
            return dugumler;
        }
        private void InOrder()
        {
            dugumler = "";
            InOrderInt(kok);
        }

        private void InOrderInt(İkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            InOrderInt(dugum.sol);
            Ziyaret(dugum);
            InOrderInt(dugum.sag);
        }

        //arama islemi yapilir.
        public Kisi Ara(int anahtar)
        {
            return AraInt(kok, anahtar);
        }
        private Kisi AraInt(İkiliAramaAgacDugumu dugum, int anahtar)
        {
            if (dugum == null)
                return null;
            else if ((int)dugum.veri.egt.OgrNo == anahtar)
                return dugum.veri;
            else if ((int)dugum.veri.egt.OgrNo > anahtar)
                return (AraInt(dugum.sol, anahtar));
            else
                return (AraInt(dugum.sag, anahtar));
        }

        //successor u bulur (bir sonraki buyuk eleman)
        private İkiliAramaAgacDugumu Successor(İkiliAramaAgacDugumu silDugum)
        {
            İkiliAramaAgacDugumu successorParent = silDugum;
            İkiliAramaAgacDugumu successor = silDugum;
            İkiliAramaAgacDugumu current = silDugum.sag;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.sol;
            }
            if (successor != silDugum.sag)
            {
                successorParent.sol = successor.sag;
                successor.sag = silDugum.sag;
            }
            return successor;
        }
    }
}
