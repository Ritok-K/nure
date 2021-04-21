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

        static void OutputTree(Tree<int> tree)
        {
            Console.WriteLine("Tree (Inorder):");
            tree.OutputInOrder();
        }
        static void Main(string[] args)
        {
            var tree = BuildTree();
            OutputTree(tree);
        }
    }
}
