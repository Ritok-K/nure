using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    public class Tree<T>
    {
        public class Node<T>
        {
            internal T value;

            internal Node<T> left;
            internal Node<T> right;

            public Node(T v)
            {
                value = v;
            }

            public T Value { get => value; }
            public Node<T> Left { get => left; }
            public Node<T> Right { get => right; }
            public bool IsLeaf { get => left == null && right == null; }

            public int Height { get => 1 + Math.Max(LeftSubTreeHeight, RightSubTreeHeight); }
            public int LeftSubTreeHeight { get => (left != null) ? left.Height : 0; }
            public int RightSubTreeHeight { get => (right != null) ? right.Height : 0; }

            public int BalanceFactor { get => LeftSubTreeHeight - RightSubTreeHeight; }
        }

        public delegate int Comparator(T v1, T v2); // returns positive if v1 > v2, negative if v1 < v2 or 0 

        Comparator comp;
        Node<T> root;

        public Tree(Comparator compare)
        {
            comp = compare;
        }

        public Node<T> Root { get => root; }
        public bool IsEmpty { get => root == null; }

        public void OutputInOrder()
        {
            OutputInOrder(root);
        }

        public void Add(T value)
        {
            var node = new Node<T>(value);
            if (IsEmpty)
            {
                root = node;
            }
            else
            {
                root = RecursiveAdd(root, node);
            }
        }

        Node<T> RecursiveAdd(Node<T> current, Node<T> node)
        {
            if (current == null)
            {
                current = node;
            }
            else
            {
                int compRes = comp(node.value, current.value);
                if (compRes < 0)
                {
                    current.left = RecursiveAdd(current.left, node);
                    current = AutoBalance(current);
                }
                else if (compRes > 0)
                {
                    current.right = RecursiveAdd(current.right, node);
                    current = AutoBalance(current);
                }
            }

            return current;
        }

        Node<T> AutoBalance(Node<T> top)
        {
            var balanceFactor = top.BalanceFactor;
            if (balanceFactor < -1)
            {
                // right subtree is overweighted
                var rightBalanceFactor = top.right.BalanceFactor;
                if (rightBalanceFactor < 0)
                {
                    top = RotateLeft(top);
                }
                else
                {
                    top = RotateRighLeft(top.right);
                }
            }
            else if (balanceFactor > 1)
            {
                // left subtree is overweighted
                var leftBalanceFactor = top.left.BalanceFactor;
                if (leftBalanceFactor > 0)
                {
                    top = RotateRigh(top);
                }
                else
                {
                    top = RotateLeftRigh(top);
                }
            }

            return top;
        }

        Node<T> RotateLeft(Node<T> top)
        {
            Node<T> center = top.right;
            top.right = center.left;
            center.left = top;
            return center;
        }

        Node<T> RotateRigh(Node<T> top)
        {
            Node<T> center = top.left;
            top.left = center.right;
            center.right = top;
            return center;
        }

        Node<T> RotateLeftRigh(Node<T> top)
        {
            Node<T> center = top.left;
            top.left = RotateLeft(center);
            return RotateRigh(top);
        }

        Node<T> RotateRighLeft(Node<T> top)
        {
            Node<T> center = top.right;
            top.right = RotateRigh(center);
            return RotateLeft(top);
        }

        void OutputInOrder(Node<T> node)
        {
            if (node != null)
            {
                OutputInOrder(node.left);
                Console.Write($"{node.value} ");
                OutputInOrder(node.right);
            }
        }
    }
}
