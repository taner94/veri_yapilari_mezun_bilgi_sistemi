using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Heap
    {
        private HeapDugumu[] heapArray;
        private int maxSize;
        private int currentSize;
        public Heap(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            currentSize = 0;
            heapArray = new HeapDugumu[maxSize];
        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }
        public bool Insert(Sirket value)
        {
            if (currentSize == maxSize)
                return false;
            HeapDugumu newHeapDugumu = new HeapDugumu(value);
            heapArray[currentSize] = newHeapDugumu;
            MoveToUp(currentSize++);
            return true;
        }
        public HeapDugumu RemoveMax() // Remove maximum value HeapDugumu
        {
            HeapDugumu root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            MoveToDown(0);
            return root;
        }
        public bool Getir(string s)
        {
            int m;
            for (m = 0; m < currentSize; m++)
            {
                if (string.Compare(heapArray[m].Deger.Ad, s) == 0)
                {
                    return true;
                }                  
            }
            return false;
        }
        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapArray[index];
            while (index > 0 && ((string.Compare(heapArray[parent].Deger.Ad, bottom.Deger.Ad)) == 1))
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }
        public void MoveToDown(int index)
        {
            int largerChild;
            HeapDugumu top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                //Find larger child
                if (rightChild < currentSize && ((string.Compare(heapArray[leftChild].Deger.Ad, heapArray[rightChild].Deger.Ad)) == 1))
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if (((string.Compare(top.Deger.Ad, heapArray[largerChild].Deger.Ad)) >= 1))
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }
        public string DisplayHeap()
        {
            string t = "";
            for (int m = 0; m < currentSize; m++)
                if (heapArray[m] != null)
                    t += heapArray[m].Deger.Ad + "\t" + heapArray[m].Deger.Tel + "\t" + heapArray[m].Deger.Adres + Environment.NewLine;

            return t;
        }
    }
}
