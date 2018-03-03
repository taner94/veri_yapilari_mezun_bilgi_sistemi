using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class İkiliAramaAgacDugumu
    {

        public Kisi veri;
        public İkiliAramaAgacDugumu sol;
        public İkiliAramaAgacDugumu sag;
        public İkiliAramaAgacDugumu()
        {
        }

        public İkiliAramaAgacDugumu(Kisi veri)
        {
            this.veri = veri;
            sol = null;
            sag = null;
        }
    }
}
