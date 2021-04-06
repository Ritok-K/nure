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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
