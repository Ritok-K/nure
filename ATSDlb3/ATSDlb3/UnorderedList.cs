using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSDlb3
{
    class UnorderedList
    {
        public UnorderedList(int maxSize)
        {
            nodes = new int[maxSize];
            end = 0;
        }
        public bool IsEmpty
        {
            get
            {
                return end == 0;
            }
        }
        public int Length
        {
            get
            {
                return end;
            }
        }
        public bool IsFull
        {
            get
            {
                return end == nodes.Length;
            }
        }

        public int this[int index]
        {
            get
            {
                if(index < 0 || index >=Length)
                {
                    throw new IndexOutOfRangeException();
                }
                return nodes[index];
            }
            set
            {
                nodes[index] = value;
            }
        }

        public void Add(int value)
        {
            if (end >= nodes.Length)
            {
                throw new Exception("Out of memory.");
            }

            nodes[end] = value;
            end++;
        }

        
        public void HeapSort()
        {
            int size = end;

            // Построение кучи (перегруппируем массив)
            for (int i = size / 2 - 1; i >= 0; i--)
                Heapify(size, i);

            // Один за другим извлекаем элементы из кучи
            for (int i = size - 1; i >= 0; i--)
            {
                // Перемещаем текущий корень в конец
                int temp = nodes[0];
                nodes[0] = nodes[i];
                nodes[i] = temp;

                // вызываем процедуру heapify на уменьшенной куче
                Heapify(i, 0);
            }
        }


        public void Print()
        {
            for (int i = 0; i < end; i++)
            {
                Console.WriteLine(nodes[i]);
            }
        }

        // Процедура для преобразования в двоичную кучу поддерева с корневым узлом root; size - размер кучи
        void Heapify(int size, int root)
        {
            int largest = root;
            // Инициализируем наибольший элемент как корень
            int leftEl = 2 * root + 1; // left = 2*root + 1
            int rightEl = 2 * root + 2; // right = 2*root + 2

            // Если левый дочерний элемент больше корня
            if (leftEl < size && nodes[leftEl] > nodes[largest])
            {
                largest = leftEl;
            }

            // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
            if (rightEl < size && nodes[rightEl] > nodes[largest])
            {
                largest = rightEl;
            }

            // Если самый большой элемент не корень
            if (largest != root)
            {
                int temp = nodes[root];
                nodes[root] = nodes[largest];
                nodes[largest] = temp;

                // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
                Heapify(size, largest);
            }
        }

        int[] nodes;
        int end;
    }
}
