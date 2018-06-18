using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankChallenge8
{
    class Program
    {
        static long maxPoints(int[] elements)
        {
            long aggregatPoints = 0;
            // first turn this into a list
            var distinctElementsList = (new List<int>(elements)).Distinct().ToList();

            while (distinctElementsList.Count != 0)
            {
                var max = distinctElementsList.Max();
                distinctElementsList.Remove(max);
                distinctElementsList.Remove(max - 1);

                aggregatPoints += max;
            }

            return aggregatPoints;
        }

        static int[] cutSticks(int[] lengths)
        {
            if (lengths == null && lengths.Length == 0)
            {
                throw new Exception("no input");
            }

            var lengthsList = new List<int>(lengths);
            lengthsList.RemoveAt(0);
            var lengthsListAfterRemoval = new List<int>();

            while (lengthsList.Count > 0)
            {
                lengthsListAfterRemoval.Add(lengthsList.Count);
                // generally this should be MIN_INT but since the input is always between 1 and 1000
                int min = lengthsList.Min();
                // i don't really know why we are doing the cut, this should affect the output
                while (true)
                {
                    if (!lengthsList.Remove(min))
                    {
                        break;
                    }
                }
            }

            return lengthsListAfterRemoval.ToArray();
        }

        static void Main(string[] args)
        {
            var list = new int [7];
            list[0] = 6;
            list[1] = 1;
            list[2] = 2;
            list[3] = 1;
            list[4] = 3;
            list[5] = 2;
            list[6] = 3;

            var list2 = new int[7];
            list2[0] = 6;
            list2[1] = 5;
            list2[2] = 4;
            list2[3] = 4;
            list2[4] = 2;
            list2[5] = 2;
            list2[6] = 8;

            var test10 = cutSticks(list2);


            var test = new List<int>(list);
            var test2 = test.Min();
            var test3 = new List<int>();
            test3.Add(1);
            // var test = new List<int>(list);
            var test4 = test.Distinct();
            var test6 = test4.ToList();
            var test5 = test4.Count();

            var test7 = test.Remove(3);

            var test8 = maxPoints(list);


        }
    }
}
