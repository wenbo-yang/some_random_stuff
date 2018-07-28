using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdenticalBinaryTree
{
    public class Node
    {
        public int Data;
        public Node Left, Right;
    }

    class BinaryTree
    {
        Node root1, root2;
        // mirror tree is IsIdentical(a.right, b.left);
        //                IsIdentical(a.left, b.right);
        /* Given two trees, return true if they are
           structurally identical */
        public bool IdenticalTrees(Node a, Node b)
        {
            /*1. both empty */
            if (a == null && b == null)
                return true;

            /* 2. both non-empty -> compare them */
            if (a != null && b != null)
                return (a.Data == b.Data
                        && IdenticalTrees(a.Left, b.Left)
                        && IdenticalTrees(a.Right, b.Right));

            /* 3. one empty, one not -> false */
            return false;
        }

        // or use HashTable / Dictionary to store data frequency 
        // traverse the first tree store things in dictionary 
        // traverse the second tree to remove things in dictionary;

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
