using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class HashEntry
    {
        private int anahtar;

        public int Anahtar
        {
            get { return anahtar; }
            set { anahtar = value; }
        }
        private object deger;

        public object Deger
        {
            get { return deger; }
            set { deger = value; }
        }

        public HashEntry(int anahtar, object deger)
        {
            this.anahtar = anahtar;
            this.deger = deger;
        }
    }
}
