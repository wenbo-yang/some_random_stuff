using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinWindowSubstring
{
    public static class MinWindowSubstring
    {
        private static void AddToDictionary(char ch, Dictionary<char, int> substringHash)
        {
            if (!substringHash.ContainsKey(ch))
            {
                substringHash.Add(ch, 0);
            }

            substringHash[ch]++;
        }

        private static int FindIndexOfAnyCharInHash(int startIndex, string fullstring, Dictionary<char, int> substringHash)
        {

            for (int index = startIndex; index < fullstring.Length; index++)
            {
                if (substringHash.ContainsKey(fullstring[index]))
                {
                    return index;
                }
            }

            return -1;
        }

        private static bool DoesWindowContainAllChars(Dictionary<char, int> substringHash)
        {
            foreach (var pair in substringHash)
            {
                if (pair.Value > 0)
                {
                    return false;
                }
                substringHash[pair.Key]++;
            }

            return true;
        }

        public static string FindMinWindowSubstring(string substring, string fullstring)
        {
            var substringHash = new Dictionary<char, int>();
            var fullStringHash = new Dictionary<char, int>();
            var charArray = substring.ToArray();
            foreach (var ch in charArray)
            {
                AddToDictionary(ch, substringHash);
            }

            var leftIndex = FindIndexOfAnyCharInHash(0, fullstring, substringHash);
            if (leftIndex == -1)
            {
                return "";
            }

            var rightIndex = leftIndex;
            var currentWindowLeft = 0;
            var currentWindowRight = fullstring.Length;
            var matchCount = 0;

            while (rightIndex >= 0)
            {
                var rightChar = fullstring[rightIndex];
                if (--substringHash[rightChar] >= 0)
                {
                    matchCount++;
                }

                while (leftIndex >= 0 && matchCount == substring.Length)
                {
                    if (rightIndex - leftIndex < currentWindowRight - currentWindowLeft)
                    {
                        currentWindowLeft = leftIndex;
                        currentWindowRight = rightIndex;
                    }

                    var leftChar = fullstring[leftIndex];

                    if (++substringHash[leftChar] > 0)
                    {
                        matchCount--;
                    }

                    leftIndex = FindIndexOfAnyCharInHash(leftIndex + 1, fullstring, substringHash);

                }

                rightIndex = FindIndexOfAnyCharInHash(rightIndex + 1, fullstring, substringHash);
            }

            return fullstring.Substring(currentWindowLeft, currentWindowRight - currentWindowLeft + 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var substring = "AABC";
            var fullstring = "AAAAAAAAAAAAABBCCAADDAACB";

            var test = MinWindowSubstring.FindMinWindowSubstring(substring, fullstring);

            Console.Write(test);
        }
    }
}
