using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    public class Tree
    {
        public class Node
        {
            internal int value;

            internal Node left;
            internal Node right;

            public int Value { get => value; }
            public Node Left { get => left; }
            public Node Right { get => right; }
            public bool IsLeaf { get => left == null && right == null; }

            public int Height { get => 1 + Math.Max(LeftSubTreeHeight, RightSubTreeHeight); }
            public int LeftSubTreeHeight { get => (left != null) ? left.Height : 0; }
            public int RightSubTreeHeight { get => (right != null) ? right.Height : 0; }

            public int BalanceFactor { get => LeftSubTreeHeight - RightSubTreeHeight; }

            public Node(int v)
            {
                value = v;
            }
        }

        Node root;

        public Node Root { get => root; }
        public bool IsEmpty { get => root == null; }

        public void Add(int value)
        {
            var node = new Node(value);
            if (IsEmpty)
            {
                root = node;
            }
            else
            {
                root = RecursiveAdd(root, node);
            }
        }

        Node RecursiveAdd(Node current, Node node)
        {
            if (current == null)
            {
                current = node;
            }
            else
            {
                if (node.value < current.value)
                {
                    current.left = RecursiveAdd(current.left, node);
                    current = AutoBalance(current);
                }
                else if (node.value > current.value)
                {
                    current.right = RecursiveAdd(current.right, node);
                    current = AutoBalance(current);
                }
            }

            return current;
        }

        Node AutoBalance(Node top)
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

        Node RotateLeft(Node top)
        {
            Node center = top.right;
            top.right = center.left;
            center.left = top;
            return center;
        }

        Node RotateRigh(Node top)
        {
            Node center = top.left;
            top.left = center.right;
            center.right = top;
            return center;
        }
    }
}
