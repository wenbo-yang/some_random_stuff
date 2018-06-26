using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntersectionOfTwoUnsortedArrays
{
    class Program
    {
        static void AddToDictionaryHelper(Dictionary<int, int> targetDictionary, int key)
        {
            if (targetDictionary.ContainsKey(key))
            {
                targetDictionary[key]++;
            }
            else
            {
                targetDictionary.Add(key, 1);
            }
        }

        static Dictionary<int, int> FindIntersectionOfTwoUnsortedArrays(Dictionary<int, int> parsedArray, int[] array2)
        {
            var intersection = new Dictionary<int, int>();

            foreach (var element in array2)
            {
                if (parsedArray.ContainsKey(element))
                {
                    if (parsedArray[element] != 0)
                    {
                        AddToDictionaryHelper(intersection, element);
                    }
                }
            }

            return intersection;
        }

        static List<int> FindIntersectionOfTwoUnsortedArraysDictionary(int[] array1, int[] array2)
        {
            var intersection = new List<int>();

            var array1Parsed = new Dictionary<int, int>(array1.Length);
            foreach (var element in array1)
            {
                AddToDictionaryHelper(array1Parsed, element);
            }

            var parsedIntersection = FindIntersectionOfTwoUnsortedArrays(array1Parsed, array2);

            foreach (var pair in parsedIntersection)
            {
                int count = pair.Value;
                while (count != 0)
                {
                    intersection.Add(pair.Key);
                    count--;
                }
            }

            return intersection;
        }

        
        static List<int> FindIntersectionOfNUnsortedArrays(int[][] listOfArrays)
        {
            // step 1: turn first one into an dictionary
            var firstArray = listOfArrays[0];
            var targetDictionary = new Dictionary<int, int>(firstArray.Length);
            foreach (var element in firstArray)
            {
                AddToDictionaryHelper(targetDictionary, element);
            }


            // step 2: find interset dictionaries one by one
            for (int i = 1; i < listOfArrays.Length; i++ )
            {
                targetDictionary = FindIntersectionOfTwoUnsortedArrays(targetDictionary, listOfArrays[i]);

                if (targetDictionary.Count == 0)
                {
                    break;
                }
            }

            // step 3: turn dictionary into array list
            var intersection = new List<int>();

            foreach (var pair in targetDictionary)
            {
                int count = pair.Value;
                while (count != 0)
                {
                    intersection.Add(pair.Key);
                    count--;
                }
            }

            return intersection;
        }
        
        static List<int> FindIntersectionOfTwoUnsortedArrays(int[] array1, int[] array2)
        {
            /*
            var arrayInListFormat = new List<int>(array1);

            return array1.Intersect(array2);
            */

            var intersection = new List<int>();

            var array1Parsed = new Dictionary<int, int>(array1.Length);
            foreach (var element in array1)
            {
                if (array1Parsed.ContainsKey(element))
                {
                    array1Parsed[element]++;
                }
                else
                {
                    array1Parsed.Add(element, 1);
                }
            }

            foreach (var element in array2)
            {
                if (array1Parsed.ContainsKey(element))
                {
                    if (array1Parsed[element] != 0)
                    {
                        intersection.Add(element);
                        array1Parsed[element]--;
                    }
                }
            }

            return intersection;
        }

        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 2, 3, 4, 4, 5 };
            int[] array2 = { 3, 2, 4, 6 };
            int[] array3 = { 3, 2, 8, 9 };

            int[][] listOfArrays = { array1, array2, array3 };

            // var testArray = FindIntersectionOfTwoUnsortedArrays(array1, array2);
            // var testArray = FindIntersectionOfTwoUnsortedArraysDictionary(array1, array2);
            var testArray = FindIntersectionOfNUnsortedArrays(listOfArrays);

            foreach (var element in testArray)
            {
                Console.Write(element + " ");
            }


            var dict1 = new Dictionary<int, int>();
            dict1.Add(1, 1); dict1.Add(2, 2); dict1.Add(3, 3); dict1.Add(4, 4);

            var dict2 = dict1;
            dict2.Add(5, 5);

            Console.WriteLine(dict1.Count.ToString());
            Console.WriteLine(dict2.Count.ToString());
        }
    }
}
