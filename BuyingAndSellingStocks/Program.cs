using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuyingAndSellingStocks
{
    class Program
    {
        class Solution
        {
            int MaxProfit(List<int> prices)
            {

                if (prices.Count < 2)
                {
                    return 0;
                }

                var gains = new List<int>(prices.Count);
                for (int i = 1; i < prices.Count; ++i)
                {
                    gains[i - 1] = prices[i] - prices[i - 1];
                }

                return Math.Max(0, MaxSubArray(gains));
            }
            
            int MaxSubArray(List<int> nums)
            {
                return -1;
            }

            int MaxProfitWithCoolDown(List<int> prices)
            {
                int sold = 0;
                int rest = 0;
                int hold = int.MinValue;
                for(int i = 0; i < prices.Count; i++)
                {
                    int prevSold = sold;
                    int prevHold = hold;
                    int prevRest = rest;

                    sold = prevHold + prices[i];
                    hold = Math.Max(prevHold, prevRest - prices[i]);
                    rest = Math.Max(rest, prevSold);
                }

                return Math.Max(rest, sold);
            }
        };

        static void Main(string[] args)
        {
        }
    }
}
