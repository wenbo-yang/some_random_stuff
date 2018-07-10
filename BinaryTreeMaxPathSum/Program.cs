using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeMaxPathSum
{
    class Program
    {
        public class Node
        {
            public int Value;
            public Node Left, Right;
        }

        public int MaxPathSum(Node root)
        {
            if (root == null)
            {
                return Int32.MinValue;
            }

            int res = Int32.MinValue;

            return MaxPathSum(root, ref res);
        }

        public int MaxPathSum(Node root, ref int ans)
        {
            if (root == null)
            {
                return 0;
            }

            var left = MaxPathSum(root.Left, ref ans);
            var right = MaxPathSum(root.Right, ref ans);

            var sum = left + right + root.Value;
            if (sum > ans)
            {
                ans = sum;
            }

            return Math.Max(Math.Max(left + root.Value, right + root.Value), root.Value);
        }


        static void Main(string[] args)
        {
        }
    }
}
