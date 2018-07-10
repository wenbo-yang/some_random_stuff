using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimumInsertionToCreatePalindrome
{
    class Program
    {
        // dynamic programming add to 2d Array
        int GetMinimumInsertion(char[] str)
        {
            var table = new int[str.Length, str.Length];
            var n = str.Length;

            for (var i = 1; i < str.Length; i++)
            {
                for (int j = 0; j < str.Length;j++)
                {
                    table[i,j] = (str[i] == str[j]) ? table[i,j] :
                                    Math.Min(table[i,j - 1],
                                             table[i + 1,j]);
                }
            }

            return table[0, n - 1];
        }

        static void Main(string[] args)
        {
        }
    }
}
