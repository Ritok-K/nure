using System;

namespace AVL_Tree
{
    class Program
    {
        static Tree BuildTree()
        {
            var tree = new Tree();
            tree.Add(17);
            tree.Add(25);
            tree.Add(30);
            tree.Add(35);
            tree.Add(40);

            return tree;
        }

        static void OutputTree(Tree tree)
        {
            Console.WriteLine("Tree (in order):");
            tree.OutputInOrder();
        }
        static void Main(string[] args)
        {
            var tree = BuildTree();
            OutputTree(tree);
        }
    }
}
