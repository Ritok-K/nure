using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATSDlb3
{
    struct PriorityItem
    {
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

        void ShiftUp(int index)
        {
            while (index > 0 && items[Parent(index)].priority < items[index].priority)
            {
                // Swap parent and current node
                Swap(Parent(index), index);

                // Update i to parent of i
                index = Parent(index);
            }
        }
        
        int Parent(int i)
        {
            return (i - 1) / 2;
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
