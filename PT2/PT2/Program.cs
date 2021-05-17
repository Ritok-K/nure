using System;
using System.Collections.Generic;

namespace PT2
{
    class Program
    {
        static void Main(string[] args)
        {
            // task 1
            Console.WriteLine("task 1");
            float res1 = RecursionMath.Task1(3);
            Console.WriteLine(res1);

            // task 2
            Console.WriteLine("task 2");
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

            Console.WriteLine("task 3");
            int sum = RecursionMath.Sum(list.First);
            Console.WriteLine(sum);

            // task 4
            Console.WriteLine("task 4");
            RecursionMath.PrintList(list.First);

            // task 5
            Console.WriteLine("task 5");
            RecursionMath.PrintListReverse(list.Last);

            // task 6
            var binaryTree = new BSTInteger();

            binaryTree.Add(8);
            binaryTree.Add(3);
            binaryTree.Add(10);
            binaryTree.Add(1);
            binaryTree.Add(6);
            binaryTree.Add(4);
            binaryTree.Add(7);
            binaryTree.Add(14);
            binaryTree.Add(16);

            Console.WriteLine("task 6");
            binaryTree.Print_asc();

            Console.WriteLine("task 7");
            binaryTree.Print_desc();

            Console.WriteLine("task 8");
            int treeSum = binaryTree.BST_sum();
            Console.WriteLine($"Tree sum is {treeSum}");

            Console.WriteLine("task 9");
            var secondBinaryTree = new BSTInteger();

            secondBinaryTree.Add(8);
            secondBinaryTree.Add(3);
            secondBinaryTree.Add(10);
            secondBinaryTree.Add(1);
            secondBinaryTree.Add(6);
            secondBinaryTree.Add(4);
            secondBinaryTree.Add(7);
            secondBinaryTree.Add(14);
            secondBinaryTree.Add(16);

            var isEqual = binaryTree.IsEqual(secondBinaryTree);
            Console.WriteLine($"The result of comparison is {isEqual}.");

            Console.WriteLine("task 10");
            secondBinaryTree.MakeEmpty();
            secondBinaryTree.Add(3);
            secondBinaryTree.Add(8);
            secondBinaryTree.Add(10);
            secondBinaryTree.Add(1);
            secondBinaryTree.Add(4);
            secondBinaryTree.Add(6);
            secondBinaryTree.Add(16);
            secondBinaryTree.Add(14);
            secondBinaryTree.Add(7);

            var isSameData = binaryTree.SameData(secondBinaryTree);
            Console.WriteLine($"The resul of data comparison is {isSameData}.");

            Console.WriteLine("task 11");
            var treeList = new LinkedList<int>();
            binaryTree.BST_List(treeList);
            foreach (var elem in treeList)
            {
                Console.Write($"{elem} ");
            }
            Console.WriteLine();

            Console.WriteLine("task 12 (clean tree)");
            binaryTree.MakeEmpty();

            Console.WriteLine("task 13");
            int treeSize = binaryTree.Size;
            Console.WriteLine($"Tree size is {treeSize}");
        }
    }
}
