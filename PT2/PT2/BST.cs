using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{

    /// <summary>
    /// Розташування вузла відносно батьківського
    /// </summary>
    public enum Side
    {
        Left,
        Right
    }

    /// <summary>
    /// Вузол бінарного дерева
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BSTNode<T> where T : IComparable
    {
        /// <summary>
        /// Конструктор класу
        /// </summary>
        /// <param name="data">Дані</param>
        public BSTNode(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Дані, що зберігаються у вузлі
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Лівий дочірний елемент
        /// </summary>
        public BSTNode<T> LeftNode { get; set; }

        /// <summary>
        /// Правий дочірній елемент
        /// </summary>
        public BSTNode<T> RightNode { get; set; }

        /// <summary>
        /// Батьківський елемент
        /// </summary>
        public BSTNode<T> ParentNode { get; set; }

        public int Size
        {
            get
            {
                return 1 + (LeftNode?.Size ?? 0) + (RightNode?.Size ?? 0);
            }
        }

        /// <summary>
        /// Розташування вузла відносно батьківського 
        /// </summary>
        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;

        /// <summary>
        /// Перетворення екземпляра класу в рядок
        /// </summary>
        /// <returns>Дані вузла дерева</returns>
        public override string ToString() => Data.ToString();
    }

    /// <summary>
    /// Бінарне дерево
    /// </summary>
    /// <typeparam name="T">Тип даних вузлів</typeparam>
    public class BST<T> where T : IComparable
    {
        /// <summary>
        /// Корінь бінарного дерева
        /// </summary>
        public BSTNode<T> RootNode { get; set; }

        public int Size 
        {
            get
            {
                return  RootNode?.Size ?? 0;
            }
        }


        /// <summary>
        /// Додавання нового вузла в бінарне дерево
        /// </summary>
        /// <param name="node">Новий вузол</param>
        /// <param name="currentNode">Поточний вузол</param>
        /// <returns>Вузол</returns>
        public BSTNode<T> Add(BSTNode<T> node, BSTNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;
                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result;
            return (result = node.Data.CompareTo(currentNode.Data)) == 0
                ? currentNode
                : result < 0
                    ? currentNode.LeftNode == null
                        ? (currentNode.LeftNode = node)
                        : Add(node, currentNode.LeftNode)
                    : currentNode.RightNode == null
                        ? (currentNode.RightNode = node)
                        : Add(node, currentNode.RightNode);
        }/// <summary>
         /// Додавання даних в бінарне дерево
         /// </summary>
         /// <param name="data">Дані</param>
         /// <returns>Вузол</returns>
        public BSTNode<T> Add(T data)
        {
            return Add(new BSTNode<T>(data));
        }
        /// <summary>
        /// Пошук вузла по значенню
        /// </summary>
        /// <param name="data">Шукане значення</param>
        /// <param name="startWithNode">Вузол з якого розпочинається пошук</param>
        /// <returns>Знайдений вузол</returns>
        public BSTNode<T> FindNode(T data, BSTNode<T> startWithNode = null)
        {
            startWithNode = startWithNode ?? RootNode;
            int result;
            return (result = data.CompareTo(startWithNode.Data)) == 0
                ? startWithNode
                : result < 0
                    ? startWithNode.LeftNode == null
                        ? null
                        : FindNode(data, startWithNode.LeftNode)
                    : startWithNode.RightNode == null
                        ? null
                        : FindNode(data, startWithNode.RightNode);
        }

        /// <summary>
        /// Видалення вузла бінарного дерева
        /// </summary>
        /// <param name="node">Вузол для видалення</param>
        public void Remove(BSTNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            //якщо у вузла немає дочірніх, то можна його видаляти
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }
            //якщо немає лівого, то правий ставимо на місце видаленого
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }

                node.RightNode.ParentNode = node.ParentNode;
            }
            //якщо немає правого, то лівий ставимо на місце видаленого
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }

                node.LeftNode.ParentNode = node.ParentNode;
            }
            //якщо наявні обидва дочірні, 
            //то правий ставимо на місце видаленого,
            //а лівий вставляємо в правий
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        node.ParentNode.LeftNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    case Side.Right:
                        node.ParentNode.RightNode = node.RightNode;
                        node.RightNode.ParentNode = node.ParentNode;
                        Add(node.LeftNode, node.RightNode);
                        break;
                    default:
                        var bufLeft = node.LeftNode;
                        var bufRightLeft = node.RightNode.LeftNode;
                        var bufRightRight = node.RightNode.RightNode;
                        node.Data = node.RightNode.Data;
                        node.RightNode = bufRightRight;
                        node.LeftNode = bufRightLeft;
                        Add(bufLeft, node);
                        break;
                }
            }
        }
        /// <summary>
        /// Видалення вузла дерева
        /// </summary>
        /// <param name="data">Дані для видалення</param>
        public void Remove(T data)
        {
            var foundNode = FindNode(data);
            Remove(foundNode);
        }

        public void Print_asc()
        {
            Print_asc(RootNode);
            Console.WriteLine();
        }

        public void Print_asc(BSTNode<T> node)
        {
            if(node == null)
            {
                return;
            }

            Print_asc(node.LeftNode);
            Console.Write($"{node.Data} ");
            Print_asc(node.RightNode);
        }

        public void Print_desc()
        {
            Print_desc(RootNode);
            Console.WriteLine();
        }

        public void Print_desc(BSTNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            Print_desc(node.RightNode);
            Console.Write($"{node.Data} ");
            Print_desc(node.LeftNode);
        }

        public void BST_List(LinkedList<T> list)
        {
            BST_List(RootNode, list);
        }

        public void BST_List(BSTNode<T> node, LinkedList<T> list)
        {
            if(node == null)
            {
                return;
            }

            BST_List(node.LeftNode, list);
            list.AddLast(node.Data);
            BST_List(node.RightNode, list);
        }

        public void MakeEmpty()
        {
            RootNode = null;
        }
    }

    public class BSTInteger : BST<int>
    {
        public int BST_sum()
        {
            return BST_sum(RootNode);
        }

        public int BST_sum(BSTNode<int> node)
        {
            if (node == null)
            {
                return 0;
            }

            int sum = BST_sum(node.LeftNode);
            sum += node.Data;
            sum += BST_sum(node.RightNode);

            return sum;
        }

    }
}
