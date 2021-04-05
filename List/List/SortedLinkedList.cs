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

        public void Insert(T value)
        {
            Node<T> newNode = new Node<T>();
            newNode.value = value;

            if(IsEmpty)
            {
                head = newNode;
            }
            else
            {
                Node<T> prevNode = null;
                Node<T> currentNode = head;

                // find place where insert new node(between prev and current nodes)
                while (currentNode != null && !comparator(value, currentNode.value))
                {
                    prevNode = currentNode;
                    currentNode = currentNode.next;
                }

                if (prevNode == null) // if prev was not found (value is global mininmum) insert in begin of list 
                {
                    head = newNode; // set list head on new global minimum (new list head)
                }
                else 
                {
                    prevNode.next = newNode; // set new node as prev node
                }
                
                newNode.next = currentNode; // set current node as netx of new node
            }

            count++;
        }

        public bool Contains(T value)
        {
            Node<T> prevNode;
            Node<T> currentNode;

            Search(value, out prevNode, out currentNode);

            return currentNode != null;
        }

        void Search(T value, out Node<T> prevNode, out Node<T> currentNode)
        {
            prevNode = null;
            currentNode = head;

            while (currentNode != null && (comparator(value, currentNode.value) || comparator(currentNode.value, value)))
            {
                prevNode = currentNode;
                currentNode = currentNode.next;
            }
        }

        Comparator comparator;
        Node<T> head;
        int count;
    }
}
