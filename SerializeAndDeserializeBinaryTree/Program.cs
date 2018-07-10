using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace SerializeAndDeserializeBinaryTree
{
    class Program
    {
        public class Node
        {
            public Node(int value) { }
            public int Value { get; set; }

            public Node Left { get; set; }
            public Node Right { get; set; }
        }

        public void Serialize(Node node, StringBuilder sb)
        {
            if (node == null)
            {
                sb.Append("# ");
                return;
            }

            sb.Append(node.Value + " ");

            Serialize(node.Left, sb);
            Serialize(node.Right, sb);
        }

        public Node Deserialize(List<string> input)
        {
            if (input.First() == "#")
            {
                return null;
            }

            var node = new Node(Convert.ToInt32(input.First()));
            input.RemoveAt(0);

            node.Left = Deserialize(input);
            node.Right = Deserialize(input);

            return node;
        }

        static void Main(string[] args)
        {
        }
    }
}
