using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class SortedLinkedList<T>
    {
        class Node<T>
        {
            internal T value;
            internal Node<T> next;  // reference to the next node
        }


        public delegate bool Comparator(T t1, T t2); // return true if t1 < t2
        
        public SortedLinkedList(Comparator comp)
        {
            comparator = comp;
            count = 0;
        }

        public bool IsEmpty
        {
            get
            {
                return head == null;
            }
        }

        public int Length
        {
            get => count;
        }

        public void Clear()
        {
            head = null;
            count = 0;
        }

        



        Comparator comparator;
        Node<T> head;
        int count;
    }
}
