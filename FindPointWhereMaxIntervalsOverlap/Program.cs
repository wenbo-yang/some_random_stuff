using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPointWhereMaxIntervalsOverlap
{
    class Program
    {
        public static void maxOverlap(int[] start, int[] end)
        {
            // Finding maximum starting time
            int maxa = start.Max();

            // Finding maximum ending time
            int maxb = end.Max();

            int maxc = Math.Max(maxa, maxb);

            int[] x = new int[maxc + 2];

            int cur = 0, idx = 0;
            // CREATING AN AUXILIARY ARRAY
            for (int i = 0; i < end.Length; i++)
            {// Lazy addition
                ++x[start[i]];
                --x[end[i] + 1];
            }

            int maxy = -1;
            //Lazily Calculating value at index i
            for (int i = 0; i <= maxc; i++)
            {
                cur += x[i]; if (maxy < cur) { maxy = cur; idx = i; }
            }
            Console.WriteLine("Maximum value is:" +
                               maxy + " at position: " + idx + "");

        }

        public static void main(String[] args)
        {// Driver function


            int[] start = new int[] { 13, 28, 29, 14, 40, 17, 3 };
            int[] end = new int[] { 107, 95, 111, 105, 70, 127, 74 };
            int n = start.Length;

            maxOverlap(start, end);
        }

        static void Main(string[] args)
        {
        }
    }
}
