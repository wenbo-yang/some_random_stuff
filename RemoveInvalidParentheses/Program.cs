using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveInvalidParentheses
{
    class Program
    {
        class ValidParenthese
        {

            void RemoveInvalidParenthese(string input)
            {
                var numOpen = 0;
                var numClose = 0;

                foreach (var ch in input)
                {
                    numOpen += Convert.ToInt32((ch == '('));

                    if (numOpen == 0)
                    {
                        if (numOpen == 0)
                        {
                            numClose += Convert.ToInt32((ch == ')'));
                        }
                        else
                        {
                            numOpen -= Convert.ToInt32((ch == ')'));
                        }
                    }
                }

                DFS(input, 0, numOpen, numClose);
            }

            bool IsValid(string input)
            {
                int imba = 0;

                foreach (var ch in input)
                {
                    if (ch == '(')
                    {
                        imba++;
                    }
                    if (ch == ')')
                    {
                        imba--;
                    }
                    if (imba < 0)
                    {
                        return false;
                    }
                }
                return imba == 0;
            }

            void Print(string input)
            {
            }

            void DFS(string input, int startIndex, int open, int close)
            {
                if (open == 0 && close == 0)
                {
                    if (IsValid(input))
                    {
                        Print(input);
                    }
                    return;
                }

                for (int i = startIndex; i < input.Length; i++)
                {
                    if (!input.StartsWith(")") && input[i] == input[i - 1])
                    {
                        continue;
                    }

                    if (input[i] == '(' && open > 0)
                    {
                        var curr = input.Remove(i, 1);
                        DFS(curr, i, open - 1, close);
                    }
                    else if(input[i] == ')' && close > 0)
                    {
                        var curr = input.Remove(i, 1);
                        DFS(curr, i, open, close - 1);
                    }
                }
            }
        }


        static void Main(string[] args)
        {
        }
    }
}
