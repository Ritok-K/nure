using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSDlb3
{
    struct PriorityItem
    {
        public PriorityItem(int value, int priority)
        {
            this.value = value;
            this.priority = priority;
        }

        public int value;
        public int priority;
    }

    class PriorityQeueue
    {
        public PriorityQeueue(int length)
        {
            items = new PriorityItem[length];
            size = 0;
        }

        public int Length
        {
            get
            {
                return size;
            }
        }


        public bool IsEmpty
        {
            get
            {
                return Length == 0;
            }
        }

        public bool IsFull
        {
            get
            {
                return size == items.Length;
            }
        }

        public void Enqueue(PriorityItem element)
        {
            if(IsFull)
            {
                throw new OutOfMemoryException();
            }

            items[size] = element;
            ShiftUp(size);

            size++;
        }

        public PriorityItem DequeueMax()
        {
            if(IsEmpty)
            {
                throw new Exception("The queue is empty.");
            }

            PriorityItem res = items[0];

            if(size == 1)
            {
                size--;

            }
            else
            {
                items[0] = items[size - 1];
                size--;
            }

            return res;
        }

        public void PrintQueue()
        {
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine($"{items[i].value}, priority: {items[i].priority}");
            }
        }

        void ShiftUp(int index)
        {
            while (index > 0 && items[Parent(index)].priority > items[index].priority)
            {
                // Swap parent and current node
                Swap(Parent(index), index);

                // Update i to parent of i
                index = Parent(index);
            }
        }

        void ShiftDown(int i)
        {
            int maxIndex = i;

            // Left Child
            int l = LeftChild(i);

            if (l < size && items[l].priority < items[maxIndex].priority)
            {
                maxIndex = l;
            }

            // Right Child
            int r = RightChild(i);

            if (r < size && items[r].priority < items[maxIndex].priority)
            {
                maxIndex = r;
            }

            // If i not same as maxIndex
            if (i != maxIndex)
            {
                Swap(i, maxIndex);
                ShiftDown(maxIndex);
            }
        }

        int Parent(int i)
        {
            return (i - 1) / 2;
        }
        int LeftChild(int i)
        {
            return ((2 * i) + 1);
        }
        int RightChild(int i)
        {
            return ((2 * i) + 2);
        }

        void Swap(int i, int j)
        {
            PriorityItem temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        PriorityItem[] items;
        int size;
    }
}
