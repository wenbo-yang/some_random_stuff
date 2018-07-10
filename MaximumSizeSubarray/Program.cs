using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSizeSubarrayIsK
{
    class Program
    {
        // let sum [0 to i] + sum[i + 1 to j] = K
        // sum[0 to i] can be pre - calculated save to hashTable
        // sum[0 to j] = sum - k; 
        int SubArraySum(int[] numbers, int k)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return 0;
            }

            var table = new Dictionary<int, int>();
            var currentSum = 0;
            var retVal = 0;

            foreach(var num in numbers)
            {
                currentSum += num;
                if (table.ContainsKey(currentSum - k))
                {
                    retVal = table[currentSum - k] + 1;
                    table[currentSum]++;
                }
                else
                {
                    table.Add(currentSum, 1);
                }
            }

            return retVal;
        }

        static void Main(string[] args)
        {
        }
    }
}
