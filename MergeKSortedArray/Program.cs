using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeKSortedArray
{
    public class HeapNode
    {
        public HeapNode(int value, int arrayId, int index){}
        public int Value { get; set; }
        public int ArrayId { get; set; }
        public int Index { get; set; }
    }

    public class MinHeap
    {
        private List<HeapNode> heap { get; set; }
        public int Count { get; private set; }
        public MinHeap(int size) { }

        public void Add(HeapNode item) { }

        public HeapNode Pop() { return null; }

        public int Peek() { return 0; }
    }

    // if merge two sorted array so it will be log k without extra space
    class Program
    {
        public void MergeKSortedArray(List<int[]> sortedArrayList, int totalNumOfElements)
        {
            var numOfRows = sortedArrayList.Count ;
            var mergedArray = new List<int>(totalNumOfElements);
            var minHeap = new MinHeap(numOfRows);

            for (int i = 0; i < numOfRows; i++)
            {
                minHeap.Add(new HeapNode(sortedArrayList[i][0], i, 0));
            }


            // var count = numOfRows;
            var count = 0;

            while (count < totalNumOfElements)
            {
                var tempMinNode = minHeap.Pop();
                mergedArray.Add(tempMinNode.Value);

                if (tempMinNode.Index < sortedArrayList[tempMinNode.ArrayId].Length - 1)
                {
                    minHeap.Add(new HeapNode(sortedArrayList[tempMinNode.ArrayId][tempMinNode.Index + 1], tempMinNode.ArrayId, tempMinNode.Index + 1));
                }

                count++;
            }

            /*
            while (minHeap.Count != 0)
            {
                mergedArray.Add(minHeap.Pop().Value);
            }
            */
        }

        //array1 is ==  array2

        // sort them from end to begining 
        void MergeTwoSortedArray(int[] array1, int end1, int[] array2)
        {
            int i = end1 - 1;
            int j = array2.Length - 1;
            int k = array1.Length + array2.Length - 1;

            while (i >= 0 && j >= 0)
            {
                array1[k--] = array2[j] > array1[i] ? array2[j--] : array1[i--];
            }

            while (j >= 0)
            {
                array1[k--] = array2[j--];
            }
        }

        static void Main(string[] args)
        {

            var test = new int[4, 5];

            Console.WriteLine(test.Length.ToString());
            Console.WriteLine(test.GetLength(0).ToString());

            var test1 = new HashSet<int>();
            test1.Add(1);
        }
    }
}
