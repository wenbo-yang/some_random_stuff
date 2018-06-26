// this is obviously perf... so I am using a Hash Table to make sure perf is good
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    private static int MaxInputNumner = 100000;

    public class Node
    {
        public Node()
        {
            Count = 0;
        }

        public int Count { get; set; }
    }

    public class Hash
    {
        Node[] nodes;
        int max, min;

        public Hash(int maxNumber)
        {
            nodes = new Node[maxNumber];
            max = min = -1;
        }

        public void AddNumberToHash(int number)
        {

            if (nodes[number] == null)
            {
                nodes[number] = new Node();
            }

            nodes[number].Count++;

            if (min == -1 && max == -1)
            {
                min = max = number;
            }
            else
            {
                if (number < min)
                {
                    min = number;
                }
                else if (number > max)
                {
                    max = number;
                }
            }
        }

        public int[] ConvertHashIntoArray(int size)
        {
            var intArray = new int[size];

            int arrayIndex = 0;
            for (int index = min; index <= max; index++)
            {
                if (nodes[index] != null)
                {
                    for (int i = 0; i < nodes[index].Count;  i++)
                    {
                        intArray[arrayIndex++] = index;
                    }
                }
            }

            return intArray;
        }

        public double UpdateRunningMedian(int[] intArray)
        {
            var length = intArray.Length;
            if (length % 2 == 0)
            {
                return Convert.ToDouble((intArray[length / 2] + intArray[length / 2 - 1])) / 2.0;
            }
            else
            {
                return Convert.ToDouble(intArray[length / 2]);
            }
        }
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        var hash = new Hash(MaxInputNumner);

        for (int a_i = 0; a_i < n; a_i++)
        {
            hash.AddNumberToHash(Convert.ToInt32(Console.ReadLine()));
            var intArray = hash.ConvertHashIntoArray(a_i + 1);
            Console.WriteLine(string.Format("{0:0.0}", hash.UpdateRunningMedian(intArray)));
        }
    }
}
