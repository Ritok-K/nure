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
            end = 0;
        }

        public int Length
        {
            get
            {
                return end;
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
                return end == items.Length;
            }
        }



        PriorityItem[] items;
        int end;
    }
}
