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

        PriorityItem[] items;
        int end;
    }
}
