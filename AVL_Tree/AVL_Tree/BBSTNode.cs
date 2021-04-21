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
    }
}
