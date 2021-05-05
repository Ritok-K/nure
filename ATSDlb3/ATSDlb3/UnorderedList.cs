﻿using System;
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
        

        int[] nodes;
        int end;
    }
}