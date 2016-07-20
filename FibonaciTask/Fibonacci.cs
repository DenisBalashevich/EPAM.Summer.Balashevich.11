using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonaciTask
{
    public static class Fibonacci
    {
        public static IEnumerable<int> Fibonaci(int num)
        {
            if (num < 0)
                throw new ArgumentNullException();
            int prev = 0;
            int cur = 1;
            for (int i = 0; i < num; i++)
            {
                yield return cur;
                cur += prev;
                prev = cur - prev;
            }
        }
    }
}
