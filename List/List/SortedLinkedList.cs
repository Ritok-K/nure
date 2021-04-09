using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class SortedLinkedList<T>
    {
        public class Node<T> // node for list
        {
            internal T value; // value stored in the node
            internal Node<T> next;  // reference to the next node
        }


        public delegate bool Comparator(T t1, T t2); // return true if t1 < t2
        
        public SortedLinkedList(Comparator comp) // receives argument that is lambda to sort values in list 
        {
            comparator = comp; // keep reference on the lambda
            count = 0;
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
            if(node == null)
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

        public void Insert(T value) // insert new value to the list
        {
            Node<T> newNode = new Node<T>(); // create new node
            newNode.value = value;

            if(IsEmpty) // if list is empty assigne new node to the head
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

        public bool Contains(T value) // checks whether the list contains value
        {
            Node<T> prevNode;
            Node<T> currentNode;

            Search(value, out prevNode, out currentNode); // run Search, return true if node was found

            return currentNode != null;
        }

        public bool Delete(T value) // deletes value from the list, returns true if value was deleted
        {
            Node<T> prevNode;
            Node<T> currentNode;

            Search(value, out prevNode, out currentNode); // search node with value and its previous node

            if (currentNode == null)
            {
                return false; // return false if node was not found
            }

            if (prevNode == null) // if previous node is empty then delete "head" node
            {
                head = currentNode.next; // just moved head to the next node
            }
            else
            {
                prevNode.next = currentNode.next; // link previous node with the next node (forgot reference to founded node)
            }

            count--;
            return true;
        }

        public SortedLinkedList<T> MergeWith(SortedLinkedList<T> withList, bool skipDuplicates)
        {
            var list = new SortedLinkedList<T>(comparator); // create new list with same comparator

            for (var node = GetHead(); node != null; node = GetNext(node)) // loop on this list
            {
                T value = GetValue(node); // get current value
                bool addValue = skipDuplicates || !list.Contains(value); // add new value if either can skip duplicates or new list does not contain value
                if (addValue)
                {
                    list.Insert(value); // add value
                }
            }

            // the same algorithm for withList
            for (var node = withList.GetHead(); node != null; node = withList.GetNext(node))
            {
                T value = withList.GetValue(node);
                bool addValue = skipDuplicates || !list.Contains(value);
                if (addValue)
                {
                    list.Insert(value);
                }
            }

            return list;
        }

        void Search(T value, out Node<T> prevNode, out Node<T> currentNode) // search node value in the list and previous node value
        {
            prevNode = null;
            currentNode = head;

            // while there is current node and its value is not equal to argument value 
            while (currentNode != null && (comparator(value, currentNode.value) || comparator(currentNode.value, value)))
            {
                prevNode = currentNode; // move to the next node
                currentNode = currentNode.next;
            }
        }

        Comparator comparator;
        Node<T> head;
        int count;
    }
}
