using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMPSubString
{
    class Program
    {
        /*
        
        
        */
        /**
   * Slow method of pattern matching
   */
        public bool hasSubstring(char[] text, char[] pattern)
        {
            int i = 0;
            int j = 0;
            int k = 0;
            while (i < text.Length && j < pattern.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = 0;
                    k++;
                    i = k;
                }
            }
            if (j == pattern.Length)
            {
                return true;
            }
            return false;
        }

        /**
         * Compute temporary array to maintain size of suffix which is same as prefix
         * Time/space complexity is O(size of pattern)
         */
        private int[] computeTemporaryArray(char[] pattern)
        {
            int[] lps = new int[pattern.Length];
            int index = 0;
            for (int i = 1; i < pattern.Length;)
            {
                if (pattern[i] == pattern[index])
                {
                    lps[i] = index + 1;
                    index++;
                    i++;
                }
                else
                {
                    if (index != 0)
                    {
                        index = lps[index - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }
            return lps;
        }

        /**
         * KMP algorithm of pattern matching.
         */
        public bool KMP(char[] text, char[] pattern)
        {

            var lps = computeTemporaryArray(pattern);
            int i = 0;
            int j = 0;
            while (i < text.Length && j < pattern.Length)
            {
                if (text[i] == pattern[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            if (j == pattern.Length)
            {
                return true;
            }
            return false;
        }


        static void Main(string[] args)
        {
        }
    }
}
