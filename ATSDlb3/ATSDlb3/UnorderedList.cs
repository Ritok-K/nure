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

        int[] nodes;
        int end;
    }
}
