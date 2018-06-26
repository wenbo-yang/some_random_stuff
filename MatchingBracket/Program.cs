using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static bool IsMatched(char open, char close)
    {
        return (open == '{' && close == '}') ||
                (open == '(' && close == ')') ||
                (open == '[' && close == ']');
    }

    static bool IsOpenBracket(char open)
    {
        return open == '{' || open == '(' || open == '[';
    }

    static bool IsCloseBracket(char open)
    {
        return open == '}' || open == ')' || open == ']';
    }

    static bool ExamineExpression(string expression)
    {
        var result = true;
        var bracketsStack = new Stack<char>();
        foreach (var item in expression)
        {
            if (IsOpenBracket(item))
            {
                bracketsStack.Push(item);
            }
            else if(IsCloseBracket(item))
            {
                if (bracketsStack.Count == 0)
                {
                    result = false;
                    break;
                }

                if (IsMatched(bracketsStack.Peek(), item))
                {
                    bracketsStack.Pop();
                }
                else
                {
                    result = false;
                    break;
                }
            }
        }

        return result && bracketsStack.Count == 0;
    }

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string expression = Console.ReadLine();
            Console.WriteLine(ExamineExpression(expression) ? "YES" : "NO");
        }
    }
}