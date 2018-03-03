using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class HeapSort
    {
        private Sirket[] dizi;
        public HeapSort(Sirket[] dizi)
        {
            this.dizi = dizi;
        }
        public Sirket[] Sort()
        {
            Heap h = new Heap(dizi.Length);
            Sirket[] sorted = new Sirket[dizi.Length];
            foreach (var item in dizi)
                h.Insert(item);
            int i = 0;
            while (!h.IsEmpty())
                sorted[i++] = h.RemoveMax().Deger;
            return sorted;
        }
    }
}
