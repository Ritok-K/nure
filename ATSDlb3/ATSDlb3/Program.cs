using System;

namespace ATSDlb3
{
    class Program
    {
        static void Part1()
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

        static void Part2()
        {
            PriorityQeueue queue = new PriorityQeueue(7);
            queue.Enqueue(new PriorityItem(2, 1));
            queue.Enqueue(new PriorityItem(3, 2));
            queue.Enqueue(new PriorityItem(-3, 4));
            queue.Enqueue(new PriorityItem(-5, 3));
            queue.Enqueue(new PriorityItem(8, 5));

            Console.WriteLine("Queue content: ");
            queue.PrintQueue();

            Console.WriteLine();
            Console.WriteLine("Queue dequeuing by one item: ");
            while (!queue.IsEmpty)
            {
                PriorityItem res = queue.DequeueMax();
                Console.WriteLine($"{res.value}, priority: {res.priority}.");
            }

        }

        static void Main(string[] args)
        {
            //Part1();
            Part2();
        }
    }
}
