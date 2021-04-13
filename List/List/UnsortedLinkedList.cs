using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class UnsortedLinkedList<T>
    {
        public class Node<T> // node for list
        {
            internal T value; // value stored in the node
            internal Node<T> next;  // reference to the next node
        }

        public bool IsEmpty // returns true when list is empty
        {
            get
            {
                return head == null;
            }
        }

        public int Length // get list length
        {
            get => count;
        }

        public T GetValue(Node<T> node) // returns value stored in node
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            return node.value;
        }
        public Node<T> GetHead() // get "head" node (start of the list)
        {
            return head;
        }

        public Node<T> GetNext(Node<T> node) // returns following node after the argument node
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            return node.next;
        }

        public void Clear() // empty list (forget "head" node)
        {
            head = null;
            count = 0;
        }

            Node<T> head;
            int count;
        
    }
}
