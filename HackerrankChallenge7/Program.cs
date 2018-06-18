using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerrankChallenge7
{

    public abstract class AbstractHeap
    {
        internal List<int> Nodes;
        #region constructors
        public AbstractHeap()
        {
            Nodes = new List<int>();
            // var nodes = new List<int>(Nodes);
           
        }
        #endregion

        public int getLeftChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 1;
        }

        public bool hasLeftChild(int parentIndex)
        {
            return getLeftChildIndex(parentIndex) < Nodes.Count;
        }

        public int leftChild(int index)
        {
            return Nodes[getLeftChildIndex(index)];
        }

        public int getRightChildIndex(int parentIndex)
        {
            return 2 * parentIndex + 2;
        }

        public bool hasRightChild(int parentIndex)
        {
            return getRightChildIndex(parentIndex) < Nodes.Count;
        }

        public int rightChild(int index)
        {
            return Nodes[getRightChildIndex(index)];
        }

        public int getParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        public bool hasParent(int childIndex)
        {
            return getParentIndex(childIndex) >= 0;
        }

        public int parent(int index)
        {
            return Nodes[getParentIndex(index)];
        }

        public void swap(int index1, int index2)
        {
            int temp = Nodes[index1];
            Nodes[index1] = Nodes[index2];
            Nodes[index2] = temp;
        }


        #region available public methods

        /// <summary>
        /// Gets the minimum element at the root of the tree
        /// </summary>
        /// <returns>Int value of minimum element</returns>
        /// <exception cref="">InvalidOperationException when heap is empty</exception>
        public int peek()
        {
            if (Nodes.Count == 0)
                throw new InvalidOperationException("Heap is empty");

            return Nodes[0];
        }

        /// <summary>
        /// Removes the minimum element at the root of the tree
        /// </summary>
        /// <returns>Int value of minimum element</returns>
        /// <exception cref="">InvalidOperationException when heap is empty</exception>
        public int pop()
        {
            if (Nodes.Count == 0)
                throw new InvalidOperationException("Heap is empty");

            int item = Nodes[0];
            Nodes[0] = Nodes[Nodes.Count - 1];
            Nodes.RemoveAt(Nodes.Count - 1);
            heapifyDown();
            return item;
        }

        /// <summary>
        /// Add a new item to heap, enlarging the array if needed
        /// </summary>
        /// <returns>void</returns>
        public void add(int item)
        {
            Nodes.Add(item);
            heapifyUp();
        }
        #endregion

        #region abstract methods
        internal abstract void heapifyUp();
        internal abstract void heapifyDown();
        #endregion
    }

    public class MaxHeap : AbstractHeap
    {
        #region constructors

        public MaxHeap() : base()
        {
        }
        #endregion

        #region internal methods
        internal override void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int largerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index) > leftChild(index))
                {
                    largerChildIndex = getRightChildIndex(index);
                }

                if (Nodes[largerChildIndex] > Nodes[index])
                    swap(index, largerChildIndex);
                else
                    break;
                index = largerChildIndex;
            }
        }
        internal override void heapifyUp()
        {
            int index = Nodes.Count - 1;

            while (hasParent(index) && parent(index) < Nodes[index])
            {
                swap(index, getParentIndex(index));
                index = getParentIndex(index);
            }
        }
        #endregion
    }

    public class MinHeap : AbstractHeap
    {
        #region constructors
        public MinHeap() : base()
        {
        }
        #endregion

        #region internal methods
        internal override void heapifyDown()
        {
            int index = 0;
            while (hasLeftChild(index))
            {
                int smallerChildIndex = getLeftChildIndex(index);
                if (hasRightChild(index) && rightChild(index) < leftChild(index))
                {
                    smallerChildIndex = getRightChildIndex(index);
                }

                if (Nodes[smallerChildIndex] < Nodes[index])
                    swap(index, smallerChildIndex);
                else
                    break;
                index = smallerChildIndex;
            }
        }
        internal override void heapifyUp()
        {
            int index = Nodes.Count - 1;

            while (hasParent(index) && parent(index) > Nodes[index])
            {
                swap(index, getParentIndex(index));
                index = getParentIndex(index);
            }
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            var test = new Dictionary<string, int>();
        }
    }
}
