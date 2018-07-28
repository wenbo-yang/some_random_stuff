using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsOneEditAwayFromEachOther
{
    class Program
    {
        public bool IsOneEditDistance(string s1, string s2)
        {
            if (string.IsNullOrEmpty(s1) || string.IsNullOrEmpty(s2))
            {
                return true;
            }

            if (Math.Abs(s1.Length - s2.Length) > 1)
            {
                return false;
            }

            int i = 0;
            int j = 0;
            int diff = 0;

            while (i < s1.Length && j < s2.Length)
            {
                if(s1[i] != s2[j])
                {
                    if (diff == 1)
                    {
                        return false;
                    }

                    if (s1.Length > s2.Length)
                    {
                        i++;
                    }
                    else if (s1.Length < s2.Length)
                    {
                        j++;
                    }
                    else
                    {
                        i++; j++;
                    }

                    diff++;
                }
            }

            if (i < s1.Length || j < s2.Length)
            {
                diff++;
            }

            return diff == 1;
        }

        static void Main(string[] args)
        {
        }
    }
}
