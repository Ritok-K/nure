using System;

namespace List
{
    class Program
    {
        static SortedLinkedList<int> BuildList()
        {
            var list = new SortedLinkedList<int>((int i1, int i2) => i1 < i2);

            list.Insert(1);
            list.Insert(0);
            list.Insert(-2);
            list.Insert(5);
            list.Insert(1);
            list.Insert(9);

            return list;
        }

        static void Output(SortedLinkedList<int> list)
        {
            Console.WriteLine("List: ");

            //var currentNode = list.GetHead(); // currentNode is SortedLinkedList<int>.Node<int> type 
            //while (currentNode != null)
            //{
            //    Console.WriteLine(list.GetValue(currentNode));
            //    currentNode = list.GetNext(currentNode);
            //}

            for(var node = list.GetHead(); node != null; node = list.GetNext(node))
            {
                Console.WriteLine(list.GetValue(node));
            }
        }

        static void Main(string[] args)
        {
            var list = BuildList();
            Output(list);
        }
    }
}
