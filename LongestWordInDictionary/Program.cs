using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestWordInDictionary
{
    class Program
    {
        
        public string LongestWordInDictionary(string[] words)
        {
            string currentBest = "";
            var set = new HashSet<string>();

            foreach (var item in set)
            {
                if (item.Length < currentBest.Length || (
                    item.Length == currentBest.Length && string.Compare(item, currentBest) > 0))
                {
                    continue;
                }

                string prefix = "";
                var shouldUpdateCurrentBest = true;
                for (int i = 0; i < item.Length; i++)
                {
                    prefix = item.Substring(0, i + 1);
                    if (!set.Contains(prefix))
                    {
                        shouldUpdateCurrentBest = false;
                    }
                }

                if (shouldUpdateCurrentBest)
                {
                    currentBest = item;
                }
            }

            return currentBest;
        }



        static void Main(string[] args)
        {
        }
    }
}
