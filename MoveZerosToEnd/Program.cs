

using System;

namespace HackerrankChallenge10
{
    class Program
    {
        static void MoveZerosToEnd(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != 0)
                {
                    var temp = arr[count];
                    arr[count] = arr[i];
                    arr[i] = temp;
                    count++;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] arr = { 1, 1, 9, 8, 4, 0, 0, 2, 7, 0, 5, 5, 0, 9};
            MoveZerosToEnd(arr);

            foreach (var element in arr)
            {
                Console.Write(element + " ");
            }
        }
    }
}
