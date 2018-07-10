using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
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
            var min = Math.Min(GetNumRecurringCharInString(a, element.ToString()), GetNumRecurringCharInString(b, element.ToString()));
            additionalLength += min;
        }

        var intersectArrayLength = additionalLength;

        Console.WriteLine((arrayA.Length - intersectArrayLength) + (arrayB.Length - intersectArrayLength)) ;
    }
}
