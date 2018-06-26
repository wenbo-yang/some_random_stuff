using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreTreeInArray
{
    class Program
    {
        public class Node
        {
            public int Value;
            public Node Left, Right = null;
        }

        class Test
        {
            int size = 10;
            int[] array;
            int index = 0;
            void storeInOrder(Node node)
            {
                if (node == null)
                {
                    return;
                }

                storeInOrder(node.Left);
                array[index++] = node.Value;
                storeInOrder(node.Right);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
