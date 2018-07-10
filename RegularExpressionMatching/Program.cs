using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegularExpressionMatching
{
    class Program
    {
        // not looking for partial match
        public static bool MatchRegex(char[] text, char[] pattern)
        {
            var T = new bool[text.Length + 1, pattern.Length + 1];
            T[0, 0] = true;

            //Deals with patterns like a* or a*b* or a*b*c*
            for (int i = 1; i < T.GetLength(1); i++)
            {
                if (pattern[i - 1] == '*')
                {
                    T[0, i] = T[0, i - 2];
                }
            }

            for (int i = 1; i < T.GetLength(0); i++)
            {
                for (int j = 1; j < T.GetLength(1); j++)
                {
                    if (pattern[j - 1] == '.' || pattern[j - 1] == text[i - 1])
                    {
                        T[i, j] = T[i - 1, j - 1];
                    }
                    else if (pattern[j - 1] == '*')
                    {
                        T[i, j] = T[i, j - 2];

                        if (pattern[j - 2] == '.' ||
                            pattern[j - 2] == text[i - 1])
                        {
                            T[i, j] = T[i, j] || T[i - 1, j];
                        }
                    }
                    else
                    {
                        T[i, j] = false;
                    }
                }
            }
            return T[text.Length, pattern.Length];
        }

        static void Main(string[] args)
        {
            var test = new int[2, 3];
            var length = test.GetLength(0);
            var res = matchRegex(new char[] { 'a', 'a', 'a', 'b' }, new char[] {'c', '*', 'a', '*', 'b' });
        }
    }
}
