using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Liste : ListADT
    {
        public override void InsertFirst(Staj stj, Egitim egt)
        {
            Node tmpHead = new Node()
            {
                staj = stj,
                egitim=egt
            };
            if (Head == null)
                Head = tmpHead;
            else
            {
                tmpHead.Next = Head;
                Head = tmpHead;
            }
            Size++;
        }

        public override void InsertLast(Staj stj, Egitim egt)
        {
            Node oldLast = Head;

            if (Head == null)
                InsertFirst(stj,egt);
            else
            {
                Node newLast = new Node
                {
                    staj = stj,
                    egitim = egt
                };
                while (oldLast != null)
                {
                    if (oldLast.Next != null)
                        oldLast = oldLast.Next;
                    else
                        break;
                }
                oldLast.Next = newLast;
                Size++;
            }
        }
        public override void InsertPos(int position, Staj stj, Egitim egt)
        {
            Node newNode = new Node();
            newNode.staj = stj;
            newNode.egitim = egt;
            newNode.Next = null;

            if (Head == null || position == 0)
            {
                InsertFirst(stj,egt);
            }

            else
            {
                Node current = Head;
                Node previous = null;

                for (int i = 0; i < position; i++)
                {
                    previous = current;
                    current = current.Next;
                    if (current == null)
                        break;
                }
                newNode.Next = current;
                previous.Next = newNode;
                Size++;
            }
        }
        public override void DeleteFirst()
        {
            if (Head != null)
            {
                Node tempHeadNext = this.Head.Next;
                if (tempHeadNext == null)
                    Head = null;
                else
                    Head = tempHeadNext;
                Size--;
            }
        }

        public override void DeleteLast()
        {
            Node lastNode = Head;
            Node lastPrevNode = null;
            while (true)
            {
                if (lastNode.Next != null)
                {
                    lastPrevNode = lastNode;
                    lastNode = lastNode.Next;
                }
                else
                    break;
            }
            Size--;
            lastNode = null;
            if (lastPrevNode != null)
                lastPrevNode.Next = null;
            else
                Head = null;
        }
        public override void DeletePos(int position)
        {
            if (Head == null || position == 0)
            {
                DeleteFirst();
            }
            else
            {
                Node current = Head;
                Node previous = null;
                for (int i = 0; i < position; i++)
                {
                    previous = current;
                    current = current.Next;
                    if (current == null)
                        break;
                }
                previous.Next = current.Next;
                Size--;
            }
        }
        public override Node GetElement(int position)
        {
            Node retNode = null;
            Node tempNode = Head;
            int count = 0;

            while (tempNode != null)
            {
                if (count == position)
                {
                    retNode = tempNode;
                    break;
                }
                tempNode = tempNode.Next;
                count++;
            }
            return retNode;
        }
        public override string DisplayElements()
        {
            string temp = "";
            Node item = Head;
            while (item != null)
            {

                temp += "Bolum: " + item.egitim.BolumAdi + "\tOgrNo: " + item.egitim.OgrNo +
                        "\nStaj tarihi: " + item.staj.StajTarihi + "\tStaj Yeri: " + item.staj.SirkedAdi + Environment.NewLine;
                item = item.Next;
            }
            return temp;
        }
    }
}
