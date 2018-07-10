using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinChange
{
    class Program
    {
        int CoinChange(List<int> coins, int amount)
        {
            // dp[i] = min coins to make up to amount i
            List<int> m = new List<int>(amount + 1);
            for(int i = 0; i < m.Count; i++)
            {
                m[i] = int.MaxValue;
            }

            m[0] = 0;
            
            foreach (int coin in coins)
            {
                for (int i = coin; i <= amount; ++i)
                {
                    if (m[i - coin] != int.MaxValue)
                    {
                        m[i] = Math.Min(m[i], m[i - coin] + 1);
                    }
                }
            }

            return m[amount] == int.MaxValue ? -1 : m[amount];
        }

        int CoinChangeGreedy(List<int> coins, int amount)
        {

            coins.Sort();
            coins.Reverse();

            int ans = Int32.MaxValue;

            CoinChangeGreedy(coins, 0, amount, 0, ref ans);

            return ans;
        }

        void CoinChangeGreedy(List<int> coins, int index, int curAmount, int count, ref int ans)
        {
            if (curAmount == 0)
            {
                ans = Math.Min(count, ans);
                return;
            }

            if (index == coins.Count)
            {
                return;
            }

            var currentCoin = coins[index];

            for (int i = curAmount / currentCoin; i >= 0 && count + i < ans; i--)
            {
                CoinChangeGreedy(coins, index + 1, curAmount - i * currentCoin, count + i, ref ans);
            }
        }


        static void Main(string[] args)
        {
        }
    }
}
