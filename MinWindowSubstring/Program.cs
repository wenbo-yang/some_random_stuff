using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinWindowSubstring
{
    public class MinWindowSubstring
    {
        public string FindMinWindowSubstring(string substring, string fullString)
        {
            var substringHash = new Dictionary<char, int>();
            var fullStringHash = new Dictionary<char, int>();
            var charArray = substring.ToArray();
            foreach (var character in charArray)
            {
                if (substringHash.ContainsKey(character))
                {
                    substringHash[character]++;
                }
                else
                {
                    substringHash.Add(character, 1);
                }
            }

            foreach (var pair in substringHash)
            {
                fullStringHash.Add(pair.Key, 0);
            }

            var leftIndex = FindIndexOfNextCharInHash(0, fullString, substringHash);
            if (leftIndex == -1)
            {
                return "";
            }

            var rightIndex = leftIndex;
            int matchCount = 0;

            string windowedString = "";

            while (rightIndex < fullString.Length)
            {
                var rightChar = fullString[rightIndex];
                if (substringHash.ContainsKey(rightChar))
                {
                    fullStringHash[rightChar]++;
                    matchCount++;
                }

                while (leftIndex < fullString.Length && matchCount == substring.Length)
                {
                    if (string.IsNullOrWhiteSpace(windowedString) || windowedString.Length > rightIndex - leftIndex + 1)
                    {
                        windowedString = fullString.Substring(leftIndex, rightIndex - leftIndex + 1);
                    }

                    var leftChar = fullString[leftIndex];

                    if (substringHash.ContainsKey(leftChar))
                    {
                        matchCount--;
                        fullStringHash[leftChar]--;
                    }

                    leftIndex = FindIndexOfNextCharInHash(leftIndex + 1, fullString, substringHash);

                }

                rightIndex = FindIndexOfNextCharInHash(rightIndex + 1, fullString, substringHash);
            }

            return windowedString;
        }

        private int FindIndexOfNextCharInHash(int startIndex, string fullString, Dictionary<char, int> substringHash)
        {

            for (int leftIndex = startIndex; leftIndex < fullString.Length; leftIndex++)
            {
                if (substringHash.ContainsKey(fullString[startIndex]))
                {
                    return leftIndex;
                }
            }

            return -1;
        }



    }

    class Program
    {
        static void Main(string[] args)
        {
            var subStringHash = new Dictionary<char, int>();

            if (subStringHash.ContainsKey('T'))
            {
                subStringHash['T']++;
            }
            else
            {
                subStringHash.Add('T', 1);
            }

            Console.Write(subStringHash.Count);
        }
    }
}
