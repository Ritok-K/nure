using System;

namespace ATSDlb3
{
    class Program
    {
        static void Main(string[] args)
        {
            UnorderedList list = new UnorderedList(7);
            list.Add(2);
            list.Add(-3);
            list.Add(0);
            list.Add(-6);
            list.Add(8);
            //list.Add(20);
            list.Add(5);

            Console.WriteLine("Unordered list");
            list.Print();

            Console.WriteLine();
            Console.WriteLine("HeapSorted list");
            list.HeapSort();
            list.Print();




        }
    }
}
