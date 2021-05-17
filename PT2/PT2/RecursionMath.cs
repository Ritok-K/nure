using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PT2
{
    static class RecursionMath
    {
        static public int Prod(int a, int b)
        {
            return a == 0 ? 0 : b + Prod(a - 1, b);
        }

        static public float Task1(int n)
        {
            if(n == 0)
            {
                return 3;
            }
            else if(n > 0)
            {
                return 4 * Task1(n - 1) + 2 * Task1(n / 2) + 7;
            }

            throw new ArgumentException();
        }
    }
}
