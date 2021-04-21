using System;

namespace AVL_Tree
{
    class Program
    {
        static Tree<int> BuildTree()
        {
            var tree = new Tree<int>((v1, v2) => v1 - v2);
            tree.Add(17);
            tree.Add(25);
            tree.Add(30);
            tree.Add(35);
            tree.Add(40);

            return tree;
        }

        static void PrintSorted(Tree<int> tree) // task 1
        {
            Console.Write("Tree (ascending order):");
            tree.OutputInOrder();
            Console.WriteLine();

            Console.Write("Tree (descending order):");
            tree.OutputReverseInOrder();
            Console.WriteLine();
        }

        static void LeftCountNodeOutput(Tree<int> tree) // task 2 (CountNode)
        {
            int number = tree.Root.LeftSubTreeCount;
            Console.WriteLine($"The number of left son nodes is: {number}");
        }

        static void Main(string[] args)
        {
            var tree = BuildTree();
            PrintSorted(tree);
            LeftCountNodeOutput(tree);
        }
    }
}
