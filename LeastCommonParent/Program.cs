using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeastCommonParent
{
    class Program
    {
        public class Node
        {
            public int Data;
            public Node Left, Right;
        }

        public Node LowestCommonAncestor(Node node, int n1, int n2)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Data == n1 || node.Data == n2)
            {
                return node;
            }

            Node left = LowestCommonAncestor(node.Left, n1, n2);
            Node right = LowestCommonAncestor(node.Right, n1, n2);

            if (left != null && right != null)
            {
                return node;
            }
            return left != null ? left : right;
        }

        public Node lowestCommonAncestorBST(Node node, int p, int q)
        {
            if (node.Data > Math.Max(p, q))
            {
                return lowestCommonAncestorBST(node.Left, p, q);
            }
            else if (node.Data < Math.Min(p, q))
            {
                return lowestCommonAncestorBST(node.Right, p, q);
            }
            else
            {
                return node;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
