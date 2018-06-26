using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSubSets
{
    class Program
    {
        // distinct set

        public class AllSubSets
        {
            private int[] set;
            public AllSubSets(int[] set) { }

            public void PrintAllSubSets()
            {

            }


            // use 
            private void PrintSubSetHelper(int[] set, int[] subset, int index)
            {
                if (index == set.Length)
                {
                    
                }
            }

            private void PrintSubSetUsingBitArray(int[] set)
            {
                if (set == null || set.Length == 0)
                {
                    Console.Write("Empty set");
                }

                if (set.Length > 31)
                {
                    throw new ArgumentOutOfRangeException("I refuse to do this question");
                }

                var totalSets = Convert.ToInt32(Math.Pow(2, set.Length -1));

                for (int i = 1; i <= totalSets; i++)
                {
                    // turn i into bit array
                    PrintSet(new BitArray(new int[] { i }), set);
                }
            }

            private void PrintSet(BitArray bitArray, int[] set)
            {
                for (int i = 0; i < bitArray.Length; i++)
                {
                    if (bitArray[i])
                    {
                        Console.Write(set[i]);
                    }
                }

                Console.Write(";");
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
