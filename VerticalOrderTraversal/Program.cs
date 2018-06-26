using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// the same applies for diagnoal order traversal

namespace VerticalOrderTraversal
{
    // use HashTable 
    public class Node
    {
        public int Value { get; set; }
        public Node Left;
        public Node Right;
    }

    public class VerticalOrderBinTreeTraversal
    {
        private int leftBound;
        private int rightBound;
        private Dictionary<int, List<Node>> verticalOrderHash;
        private Node root;

        public VerticalOrderBinTreeTraversal(Node root)
        {
            leftBound = rightBound = 0;
            verticalOrderHash = new Dictionary<int, List<Node>>();
            this.root = root;
        }

        public void PrintVerticalOrder()
        {
            if (root == null)
            {
                return;
            }

            TraverseTree(root, 0);

            var hashKeyLeft = leftBound;
            do
            {
                foreach (var node in verticalOrderHash[hashKeyLeft])
                {
                    Console.Write(node.Value);
                }

                hashKeyLeft++;
            }
            while (hashKeyLeft != rightBound);
        }

        private void TraverseTree(Node node, int col)
        {
            if (node == null)
            {
                return;
            }

            AddNodeToHashTable(node, col);

            // replace one of them as col for diagnal traversal
            // TraverseTree(node.Left, col);
            // TraverseTree(node.Right, col);
       
            TraverseTree(node.Left, col - 1);
            TraverseTree(node.Right, col + 1);
        }

        private void AddNodeToHashTable(Node node, int col)
        {
            if (verticalOrderHash.ContainsKey(col))
            {
                verticalOrderHash[col].Add(node);
            }
            else
            {
                if (col < leftBound)
                {
                    leftBound = col;
                }
                else if (col > rightBound)
                {
                    rightBound = col;
                }

                var listNode = new List<Node>();
                listNode.Add(node);
                verticalOrderHash.Add(col, listNode);
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
