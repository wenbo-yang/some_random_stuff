using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidingWindowMaximum
{
class MonotonicQueue
{
    public void push(int e)
    {
        if (data.Count > 0 && e > data[0])
        {
            data.RemoveRange(0, data.Count);
        }
        data.Add(e);
    }

    public void pop()
    {
        data.RemoveAt(0);
    }

    public int max()
    {
        return data[0];
    }

    List<int> data;
}

class Solution
{
    List<int> maxSlidingWindow(int[] nums, int k)
    {
        var q = new MonotonicQueue();
        var ans = new List<int>();

        for (int i = 0; i < nums.Length; ++i)
        {
            q.push(nums[i]);
            if (i - k + 1 >= 0)
            {
                ans.Add(q.max());
                if (nums[i - k + 1] == q.max()) q.pop();
            }
        }
        return ans;
    }
}

class Program
    {
        // {[1 2 3] 4 5 6 7 8}
        // {1 [2 3 4] 5 6 7 8 }
        // use PriorityQueue / heap

        static void Main(string[] args)
        {
        }
    }

}
