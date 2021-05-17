using System;
using System.Collections.Generic;

namespace PT2
{
    class Program
    {
        static void Main(string[] args)
        {
            // task 1
            float res1 = RecursionMath.Task1(3);
            Console.WriteLine(res1);

            // task 2
            int res2 = RecursionMath.Prod(2, 3);
            Console.WriteLine(res2);

            // task 3
            LinkedList<int> list = new LinkedList<int>();
            list.AddLast(6);
            list.AddLast(-6);
            list.AddLast(0);
            list.AddLast(8);
            list.AddLast(3);
            list.AddLast(7);

            int sum = RecursionMath.Sum(list.First);
            Console.WriteLine(sum);

            // task 4
            Console.WriteLine("task 4");
            RecursionMath.PrintList(list.First);
        }
    }
}
