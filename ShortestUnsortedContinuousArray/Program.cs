using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestUnsortedContinuousArray
{
    class Program
    {
        // using monotonic stack pop until current is smaller than stack.peek();
        public int ShortestUnsortedSubarray(int[] numbers)
        {
            if (numbers.Length < 2)
            {
                return 0;
            }

            var monoStack = new Stack<int>();

            var leftBound = numbers.Length - 1;
            var rightBound = 0;
            var index = 0;
            while(index < numbers.Length)
            {
                if (monoStack.Count == 0 || numbers[index] >= numbers[monoStack.Peek()])
                {
                    monoStack.Push(index);
                    index++;
                }
                else
                {
                    leftBound = Math.Min(leftBound, monoStack.Pop());
                }
            }

            monoStack.Clear();
            index = index - 1;
            while (index >= 0)
            {
                if (monoStack.Count == 0 || numbers[index] <= numbers[monoStack.Peek()])
                {
                    monoStack.Push(index);
                    index++;
                }
                else
                {
                    rightBound = Math.Max(rightBound, monoStack.Pop());
                }
            }

            return rightBound - leftBound > 0 ? rightBound - leftBound + 1 : 0;
        }
        

        static void Main(string[] args)
        {
        }
    }
}
