using System;

namespace VerifyBST
{
    class Program
    {
        public class Node
        {
            public int data;
            public Node left, right;
        }

        bool verifyBST(Node root, int min, int max)
        {
            if (root == null)
            {
                return true;
            }

            if (root.data < min || root.data > max)
            {
                return false;
            }

            return verifyBST(root.left, min, root.data - 1) && verifyBST(root.right, root.data + 1, max);
        }

        bool checkBST(Node root)
        {
            if (root == null)
            {
                return false; // not even a tree
            }

            return verifyBST(root, Int32.MinValue, Int32.MaxValue);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}