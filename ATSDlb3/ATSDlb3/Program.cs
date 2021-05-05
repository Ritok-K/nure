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
            list.Add(2);
            list.Add(8);

            Console.WriteLine("Unordered list");
            for (int i = 0; i < list.Length; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
    }
}
