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

        public void InsertToHead(T value) // insert new value to the list
        {
            Node<T> newNode = new Node<T>(); // create new node
            newNode.value = value;

            newNode.next = head;
            head = newNode;

            count++;
        }

        public void InsertToEnd(T value)
        {
            if (IsEmpty)
            {
                InsertToHead(value);
            }
            else
            {
                Node<T> newNode = new Node<T>(); // create new node
                newNode.value = value;

                Node<T> currNode = head;
                Node<T> lastNode = null;
                while (currNode != null)
                {
                    lastNode = currNode;
                    currNode = currNode.next;
                }

                lastNode.next = newNode;
                count++;
            }
        }

        public void InsertAfter(T value, Node<T> after)
        {
            if (after == null)
            {
                return;
            }

            Node<T> newNode = new Node<T>(); // create new node
            newNode.value = value;

            newNode.next = after.next;
            after.next = newNode;
        }

        Node<T> head;
        int count;

    }
}
