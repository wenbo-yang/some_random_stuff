using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static int Min(int a, int b)
    {
        if (a > b)
        {
            return b;
        }
        return a;
    }

    static int GetNumRecurringCharInString(string input, string target)
    {
        var temp = input.Replace(target, String.Empty);
        return input.Length - temp.Length;
    }

    static void Main(String[] args)
    {
        string a = Console.ReadLine();
        string b = Console.ReadLine();

        var arrayA = a.ToArray();
        var arrayB = b.ToArray();

        var intersectArray = arrayA.Intersect(arrayB).ToArray();
        var additionalLength = 0;
        foreach (var element in intersectArray)
        {
            var min = Min(GetNumRecurringCharInString(a, element.ToString()), GetNumRecurringCharInString(b, element.ToString()));
            additionalLength += min;
        }

        var intersectArrayLength = additionalLength;

        Console.WriteLine((arrayA.Length - intersectArrayLength) + (arrayB.Length - intersectArrayLength)) ;
    }
}
