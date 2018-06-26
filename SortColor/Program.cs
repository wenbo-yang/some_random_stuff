using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortColor
{
    class Program
    {
        public static void SortColors(int[] colors)
        {
            if (colors == null || colors.Length <= 1)
            {
                return;
            }

            int redIndex = 0;
            int blueIndex = colors.Length - 1;

            while (redIndex < colors.Length && colors[redIndex] == 0)
            {
                redIndex++;
            }

            while (blueIndex >= 0 && colors[blueIndex] == 2)
            {
                blueIndex--;
            }

            int index = redIndex;

            while (index <= blueIndex)
            {
                if (colors[index] == 0)
                {
                    swapElement(colors, redIndex, index);
                    redIndex++;
                    index++;
                } 
                else if (colors[index] == 1) // green
                {
                    index++;
                }
                else if (colors[index] == 2)
                {
                    swapElement(colors, blueIndex, index);
                    blueIndex--;
                }
            }
        }

        public static void swapElement(int[] colors, int index1, int index2) { }

        static void Main(string[] args)
        {
        }
    }
}
