using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinWindowSubstring
{
    public class MinWindowSubstring
    {
        public static string FindMinWindowSubstring(string substring, string fullString)
        {
            if(string.IsNullOrEmpty(substring) && string.IsNullOrEmpty(fullString) ||
                substring.Length > fullString.Length)
            {
                return "";
            }

            var substringHash = new Dictionary<char, int>();
            var fullStringHash = new Dictionary<char, int>();
            var charArray = substring.ToArray();
            foreach (var character in charArray)
            {
                if (!substringHash.ContainsKey(character))
                {
                    substringHash.Add(character, 0);
                }
                substringHash[character]++;
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

            while (rightIndex < fullString.Length && rightIndex >= 0)
            {
                var rightChar = fullString[rightIndex];
                if (substringHash.ContainsKey(rightChar))
                {
                    fullStringHash[rightChar]++;
                    matchCount++;
                }

                // see if we can shrink the window // 
                while (leftIndex >= 0 && leftIndex < fullString.Length && matchCount >= substring.Length)
                {
                    // if a smaller window is found then assign it to that windowed substring
                    if (string.IsNullOrEmpty(windowedString) || windowedString.Length > rightIndex - leftIndex + 1)
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

                // expand the window until 
                rightIndex = FindIndexOfNextCharInHash(rightIndex + 1, fullString, substringHash);
            }

            return windowedString;
        }

        private static int FindIndexOfNextCharInHash(int startIndex, string fullString, Dictionary<char, int> substringHash)
        {

            for (int index = startIndex; index < fullString.Length; index++)
            {
                if (substringHash.ContainsKey(fullString[startIndex]))
                {
                    return index;
                }
            }

            return -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var result = MinWindowSubstring.FindMinWindowSubstring("AABC", "AAAAAAAAAAAAAAAAABC");

            Console.Write(result);
        }
    }
}
