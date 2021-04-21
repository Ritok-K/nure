using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVL_Tree
{
    public enum TraverseMethod
    {
        PreOrder,
        InOrder,
        ReverseInOrder,
        PostOrder,
    }

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

            public int Count { get => 1 + LeftSubTreeCount + RightSubTreeCount; }
            public int LeftSubTreeCount { get => (left != null) ? left.Count : 0; }
            public int RightSubTreeCount { get => (right != null) ? right.Count : 0; }

        }

        public delegate int Comparator(T v1, T v2); // returns positive if v1 > v2, negative if v1 < v2 or 0 
        public delegate void Traverser(Node<T> node); // processes traversing node

        Comparator comp;
        Node<T> root;

        public Tree(Comparator compare)
        {
            comp = compare;
        }

        public Node<T> Root { get => root; }
        public bool IsEmpty { get => root == null; }

        public void Traverse(TraverseMethod method, Traverser traverser)
        {
            Traverse(root, method, traverser);
        }

        public void Traverse(Node<T> node, TraverseMethod method, Traverser traverser)
        {
            if (node != null)
            {
                switch (method)
                {
                    case TraverseMethod.PreOrder:
                        traverser(node);
                        Traverse(node.left, method, traverser);
                        Traverse(node.right, method, traverser);
                        break;
                    case TraverseMethod.InOrder:
                        Traverse(node.left, method, traverser);
                        traverser(node);
                        Traverse(node.right, method, traverser);
                        break;
                    case TraverseMethod.ReverseInOrder:
                        Traverse(node.right, method, traverser);
                        traverser(node);
                        Traverse(node.left, method, traverser);
                        break;
                    case TraverseMethod.PostOrder:
                        Traverse(node.left, method, traverser);
                        Traverse(node.right, method, traverser);
                        traverser(node);
                        break;
                }
            }
        }

        public string OutputInOrder()
        {
            string res = "";
            Traverse(TraverseMethod.InOrder, (n) => { res = $"{res} {n.value}"; });

            return res;
        }

        public string OutputReverseInOrder()
        {
            string res = "";
            Traverse(TraverseMethod.ReverseInOrder, (n) => { res = $"{res} {n.value}"; });

            return res;
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

        public void Delete(T value)
        {
            root = RecursionDelete(root, value);
        }

        public Node<T> FindMin()
        {
            if(IsEmpty)
            {
                return null;
            }

            var current = root;
            while(current.left != null)
            {
                current = current.left;
            }

            return current;
        }

        public Node<T> FindMax()
        {
            if(IsEmpty)
            {
                return null;
            }

            var current = root;
            while(current.right != null)
            {
                current = current.right;
            }

            return current;
        }

        public Node<T> FindSecondMax()
        {
            if (IsEmpty || root.right == null)
            {
                return null;
            }

            var current = root;
            while (current.right.right != null)
            {
                current = current.right;
            }

            return current;
        }

        public Tree<T> Clone()
        {
            var cloneTree = new Tree<T>(comp);

            Traverse(TraverseMethod.InOrder, (n) =>
            {
                cloneTree.Add(n.value);
            });

            return cloneTree;
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
                    top = RotateRightLeft(top.right);
                }
            }
            else if (balanceFactor > 1)
            {
                // left subtree is overweighted
                var leftBalanceFactor = top.left.BalanceFactor;
                if (leftBalanceFactor > 0)
                {
                    top = RotateRight(top);
                }
                else
                {
                    top = RotateLeftRight(top);
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

        Node<T> RotateRight(Node<T> top)
        {
            Node<T> center = top.left;
            top.left = center.right;
            center.right = top;
            return center;
        }

        Node<T> RotateLeftRight(Node<T> top)
        {
            Node<T> center = top.left;
            top.left = RotateLeft(center);
            return RotateRight(top);
        }

        Node<T> RotateRightLeft(Node<T> top)
        {
            Node<T> center = top.right;
            top.right = RotateRight(center);
            return RotateLeft(top);
        }

        Node<T> RecursionDelete(Node<T> current, T target)
        {
            Node<T> parent;
            if (current == null)
            { 
                return null; 
            }
            else
            {
                int compRes = comp(target, current.value);

                //left subtree
                if (compRes < 0)
                {
                    current.left = RecursionDelete(current.left, target);
                    if (current.BalanceFactor == -2)//here
                    {
                        if (current.right.BalanceFactor <= 0)
                        {
                            current = RotateLeft(current);
                        }
                        else
                        {
                            current = RotateRightLeft(current);
                        }
                    }
                }
                //right subtree
                else if (compRes > 0)
                {
                    current.right = RecursionDelete(current.right, target);
                    if (current.BalanceFactor == 2)
                    {
                        if (current.left.BalanceFactor >= 0)
                        {
                            current = RotateRight(current);
                        }
                        else
                        {
                            current = RotateLeftRight(current);
                        }
                    }
                }
                //if target is found
                else
                {
                    if (current.right != null)
                    {
                        //delete its inorder successor
                        parent = current.right;
                        while (parent.left != null)
                        {
                            parent = parent.left;
                        }

                        current.value = parent.value;
                        current.right = RecursionDelete(current.right, parent.value);

                        if (current.BalanceFactor == 2)//rebalancing
                        {
                            if (current.left.BalanceFactor >= 0)
                            {
                                current = RotateRight(current);
                            }
                            else 
                            {
                                current = RotateLeftRight(current); 
                            }
                        }
                    }
                    else
                    {   //if current.left != null
                        return current.left;
                    }
                }
            }

            return current;
        }
    }
}
