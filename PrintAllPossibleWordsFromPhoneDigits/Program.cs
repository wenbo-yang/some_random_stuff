using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintAllPossibleWordsFromPhoneDigits
{
    class Program
    {

        // depth first search 
        public class Node
        {
            public char Value;
            public Node[] children;
        }

        // construct tree 
        /*
         
        */
        private Dictionary<char, char[]> phoneNumberMap;
        private List<string> combinations;

        
        private void ConstructMapping()
        {
            var keyValuePair0 = new KeyValuePair<char, char[]>('0', new char[] {' '});
            var keyValuePair1 = new KeyValuePair<char, char[]>('1', new char[] {});
            var keyValuePair2 = new KeyValuePair<char, char[]>('0', new char[] { 'a', 'b', 'c' });
            var keyValuePair3 = new KeyValuePair<char, char[]>('0', new char[] { 'd','e', 'f' });
            var keyValuePair4 = new KeyValuePair<char, char[]>('0', new char[] { 'g','h','i' });
            var keyValuePair5 = new KeyValuePair<char, char[]>('0', new char[] { 'j', 'k','l'});

            phoneNumberMap.Add(keyValuePair0.Key, keyValuePair0.Value);
        }

        private void DepthFirstSearch(string digits, string currentString, int currentDepth, Dictionary<char, char[]> completeMap, List<string> combinations)
        {
            if (currentDepth == digits.Length)
            {
                combinations.Add(currentString);
                return;
            }

            if (digits[currentString.Length] == '1')
            {
                DepthFirstSearch(digits, currentString, currentDepth + 1, phoneNumberMap, combinations);
            }
            else
            {
                var chars = completeMap[digits[currentString.Length]];
                foreach (var value in chars)
                {
                    DepthFirstSearch(digits, currentString + value, currentDepth + 1, phoneNumberMap, combinations);
                }
            }
        }

        static void Test(string test1, int l)
        {
            if (l == 2)
            {
                Console.WriteLine(test1);
                return;
            }

            Test(test1 + "2", l + 1);
        }

        static void Main(string[] args)
        {
            var test = "Test";

            Test(test, 0);

            Console.WriteLine(test);
        }
    }
}
