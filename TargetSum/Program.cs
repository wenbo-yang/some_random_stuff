using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetSum
{
    class Program
    {
        // reduce this to knap-sack problem
        /*
         subset P is the set of nums with Positive in front
         subset N is the set with negative set;

         P U N = total set
         sum(P) = target + sum(N)
         2 * sum(P) = target + sum(N) + sum(P)
         2 * sum(P) = target + sum(a)
         sum(P) = (target + sum(a)) / 2; // sum(P) must be even
        */

        int findTargetSumWays(List<int> nums, int S)
        {
            S = Math.Abs(S);
            int n = nums.Count;
            int sum = nums.Sum();
            if (sum < S || (S + sum) % 2 != 0)
            {
                return 0;
            }

            int newTarget = (S + sum) / 2;
            var dp = new int[newTarget + 1];

            dp[0] = 1;

            foreach (var num in nums)
            {
                for (int j = newTarget; j >= num; --j)
                {
                    dp[j] += dp[j - num];
                }
            }

            return dp[newTarget];
        }

        static void Main(string[] args)
        {
        }
    }
}
