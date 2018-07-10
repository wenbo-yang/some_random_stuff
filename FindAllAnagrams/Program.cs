using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindAllAnagrams
{
    class Program
    {
        // use hash table to store anagram
        // find element in the hash table
        void AddToDictionary(Dictionary<int, int> table, char item)
        {
            if (!table.ContainsKey(item))
            {
                table.Add(item, 0);
            }
            table[item]++;
        }

        void RemoveFromDictionary(Dictionary<int, int> table, char item)
        {
            if (table[item] == 0)
            {
                table.Remove(item);
            }
            else
            {
                table[item]--;
            }
        }

        bool AreTwoTablesMatching(Dictionary<int, int> table1, Dictionary<int, int> table2)
        {
            return table1 == table2;
        }

        List<int> FindAllAnagrams(string target, string key)
        {
            var retList = new List<int>();
            var keyTable = new Dictionary<int, int>();
            var targetTable = new Dictionary<int, int>();
            var ans = new List<int>();
            foreach (char ch in key)
            {
                AddToDictionary(keyTable, ch);
            }

            for (int i = 0; i < target.Length; i++)
            {
                if (i < key.Length)
                {
                    AddToDictionary(targetTable, target[i]);
                    continue;
                }

                if (AreTwoTablesMatching(targetTable, keyTable))
                {
                    retList.Add(i - key.Length + 1);
                }

                AddToDictionary(targetTable, target[i]);
                RemoveFromDictionary(targetTable, target[i]);
            }

            return retList;
        }

        static void Main(string[] args)
        {
        }
    }
}
