using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestConsequetiveSequence
{
    class Program
    {
        public class Bound
        {
            public int Left { get; set; }
            public int Right { get; set; }

            public Bound(int left, int right)
            {
                Left = left;
                Right = right;
            }
        }

        // [2 1 4 7 6 5 8 9 10]
        static int LongestConsecutiveSequenceBoundary(int[] array)
        {
            var retLen = 0;

            var table = new Dictionary<int, Bound>();
            // if you are alone set yourself in the able and bound
            foreach (var element in array)
            {
                if (!table.ContainsKey(element))
                {
                    table.Add(element, new Bound(element, element));
                }

                var lKey = element - 1;
                var rKey = element + 1;

                // updating the current node to union with left or right

                // if I am a bridge then 
                if (table.ContainsKey(lKey) && table.ContainsKey(rKey))
                {
                    table[element].Right = table[rKey].Right;
                    table[element].Left = table[lKey].Left;
                }

                // assign left to element left
                if (table.ContainsKey(lKey))
                {
                    table[element].Left = table[lKey].Left;
                    table[table[lKey].Left].Right = table[element].Right;
                }

                // assign right to element right;
                if (table.ContainsKey(rKey))
                {
                    table[element].Right = table[rKey].Right;
                    table[table[rKey].Right].Left = table[element].Left;
                }

                var currentConsecutiveLength = table[element].Right - table[element].Left + 1;
                retLen = Math.Max(currentConsecutiveLength, retLen);
            }

            return retLen;
        }

        static int LongestConsecutiveSequenceBrute(int[] array)
        {
            var retLen = 0;

            var set = new HashSet<int>(array);

            for(int i = 0; i < array.Length; i++)
            {
                var element = array[i];

                if (!set.Contains(element - 1)) // not a low bound
                {
                    var currentSequence = 0;
                    while (set.Contains(element++))
                    {
                        currentSequence++;
                    }

                    if (currentSequence > retLen)
                    {
                        retLen = currentSequence;
                    }
                }
            }

            return retLen;
        }

        static void Main(string[] args)
        {
            var test = new int[] {4, 3, 2, 1, 6, -2, -1, 0, 7, 8, 9, 5 };

            var ret = LongestConsecutiveSequenceBoundary(test);
            ret = LongestConsecutiveSequenceBrute(test);

            Console.WriteLine(ret.ToString());
        }
    }
}
