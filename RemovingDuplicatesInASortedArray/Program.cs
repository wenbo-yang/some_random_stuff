using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemovingDuplicatesInASortedArray
{

    // not really removing just replacing
    class Program
    {

        public int RemoveDuplicates(int[] nums)
        {

            if (nums.Length == 0)
            {
                return 0;
            }

            int currentHead = nums[0];
            int n = 1;
                

            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] > currentHead)
                {
                    currentHead = nums[i];
                    var temp = nums[i];
                    nums[i] = nums[n];
                    nums[n] = temp;
                    n++;
                }
            }

            return n;
        }

        static void Main(string[] args)
        {


        }
    }
}
