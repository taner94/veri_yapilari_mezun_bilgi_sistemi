using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public abstract class ListADT
    {
        public Node Head;
        public int Size = 0;
        public abstract void InsertFirst(Staj stj, Egitim egt);
        public abstract void InsertLast(Staj stj, Egitim egt);
        public abstract void InsertPos(int position,Staj stj, Egitim egt);
        public abstract void DeleteFirst();
        public abstract void DeleteLast();
        public abstract void DeletePos(int position);
        public abstract Node GetElement(int position);
        public abstract string DisplayElements();
    }
}
