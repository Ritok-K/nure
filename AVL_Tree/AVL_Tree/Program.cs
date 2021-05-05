using System;
using System.Collections.Generic;

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
            tree.Add(40); // attempt to insert duplicate

            return tree;
        }

        static void PrintSorted(Tree<int> tree) // task 1
        {
            Console.WriteLine($"Tree (ascending order): {tree.OutputInOrder()}");
            Console.WriteLine($"Tree (descending order): {tree.OutputReverseInOrder()}");
        }

        static void LeftCountNodeOutput(Tree<int> tree) // task 2 (CountNode)
        {
            int number = tree.Root.LeftSubTreeCount;
            Console.WriteLine($"The number of left son nodes is: {number}");
        }

        static void RightSumKeys(Tree<int> tree) // task 3 (Sum of Right Son Nodes)
        {
            int res = 0;
            tree.Traverse(tree.Root.Right, TraverseMethod.PreOrder, (n) => { res += n.Value; });

            Console.WriteLine($"Sum keys of right son nodes: {res}");
        }

        static void DeleteEvenKeys(Tree<int> tree) // task 4
        {
            var list = new List<int>();
            tree.Traverse(TraverseMethod.InOrder, (n) =>
            {
                if (n.Value % 2 == 0)
                {
                    list.Add(n.Value);
                }
            });

            foreach(var i in list)
            {
                tree.Delete(i);
            }

            Console.WriteLine($"Tree after deleting even keys: {tree.OutputInOrder()}");
        }

        static void FindMiddleKey(Tree<int> tree) // task 5
        {
            var maxNode = tree.FindMax();
            var minNode = tree.FindMin();

            if(maxNode != null && minNode!= null)
            {
                float middleValue = (maxNode.Value + minNode.Value) / 2.0f; // 2.0f - make 2 into float

                Tree<int>.Node<int> middleNode = minNode;
                tree.Traverse(TraverseMethod.InOrder, (n) =>
                {
                    float deltaN = Math.Abs(n.Value - middleValue);
                    float deltaM = Math.Abs(middleNode.Value - middleValue);

                    if(deltaN < deltaM)
                    {
                        middleNode = n;
                    }

                });

                Console.WriteLine($"The middle key is: {middleNode.Value}");
            }
        }

        static void FindSecondLargestKey(Tree<int> tree) // task 7
        {
            var node = tree.FindSecondMax();
            Console.WriteLine($"Second largest key is {node.Value}");
        }

        static void CloneTree(Tree<int> tree) // task 8
        {
            var cloneTree = tree.Clone();

            if (cloneTree.IsEmpty)
            {
               Console.WriteLine("Tree is empty.");
            }

            Console.WriteLine($"Clone tree: {cloneTree.OutputInOrder()}");
        }

        static void InsertTree(Tree<int> tree) // task 9
        {
            var newTree = new Tree<int>((v1, v2) => v1 - v2);
            newTree.Add(23);
            newTree.Add(2);
            newTree.Add(3);
            newTree.Add(56);
            newTree.Add(14);

            newTree.Insert(tree);

            Console.WriteLine($"Tree after insert: {newTree.OutputInOrder()}");
        }

        static void ContainsTree(Tree<int> tree) // task 10
        {
            var cloneTree = tree.Clone();
            cloneTree.Delete(cloneTree.FindMin().Value);
            cloneTree.Add(-2);

            bool contains = tree.Contains(cloneTree);
            Console.WriteLine($"Tree cotains modified clone: {contains}");
        }

        static void FindFather(Tree<int> tree) // task 14
        {
            var val1 = 30;
            var val2 = 50;
            var fatherNode = tree.FindParent(val1);
            Console.WriteLine($"Father of {val1} is {fatherNode?.Value.ToString() ?? "absent"}");

            fatherNode = tree.FindParent(val2);
            Console.WriteLine($"Father of {val2} is {fatherNode?.Value.ToString() ?? "absent"}");
        }

        static void FindCommonAncestor(Tree<int> tree) // task 15
        {
            var val1 = 17;
            var val2 = 40;

            var ancestor = tree.FindCommonAncestor(val1, val2);
            Console.WriteLine($"Common ancestor of {val1} and {val2} is {ancestor?.Value.ToString() ?? "none"}");

            val1 = 30;
            val2 = 40;
            ancestor = tree.FindCommonAncestor(val1, val2);
            Console.WriteLine($"Common ancestor of {val1} and {val2} is {ancestor?.Value.ToString() ?? "none"}");
        }

        static void Main(string[] args)
        {
            var tree = BuildTree();
            PrintSorted(tree);

            LeftCountNodeOutput(tree);

            RightSumKeys(tree);

            FindMiddleKey(tree);

            FindSecondLargestKey(tree);

            CloneTree(tree);

            InsertTree(tree);

            ContainsTree(tree);

            FindFather(tree);

            FindCommonAncestor(tree);

            DeleteEvenKeys(tree);
        }
    }
}
