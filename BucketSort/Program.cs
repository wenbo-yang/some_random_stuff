using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BucketSort
{
    // top k frequent element in map 
    class Program
    {
        List<int> TopKFrequent(int[] nums, int k)
        {
            if (k >= nums.Length)
            {
                return null;
            }

            var countTable = new Dictionary<int, int>();
            var mostFrequent = 0;
            foreach (int num in nums)
            {
                if (!countTable.ContainsKey(num))
                {
                    countTable.Add(num, 0);
                }

                countTable[num]++;

                if (countTable[num] > mostFrequent)
                {
                    mostFrequent = countTable[num];
                }
            }

            var bucketList = new List<List<int>>(mostFrequent + 1);

            foreach (var item in countTable)
            {
                if (bucketList[item.Value] == null)
                {
                    bucketList[item.Value] = new List<int>();
                }

                bucketList[item.Value].Add(item.Key);
            }

            var tempCount = 0;
            var retVal = new List<int>();

            for (int i = mostFrequent; i >= 0; i --)
            {
                if (bucketList[i] == null)
                {
                    continue;
                }

                foreach (var num in bucketList[i])
                {
                    retVal.Add(num);
                    tempCount++;
                    if (tempCount == k)
                    {
                        return retVal;
                    }
                }
            }

            return retVal;
        }

        static void Main(string[] args)
        {
        }
    }
}
