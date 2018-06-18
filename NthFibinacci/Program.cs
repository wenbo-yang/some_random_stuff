using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NthFibinacci
{
    class Program
    {
        public class Fibonacci
        {
            private int[,] fibMat;

            public Fibonacci()
            {
                fibMat = new int[2, 2]{ { 1, 1 }, { 1, 0 } };
            }

            public int GetNthFib(int n)
            {
                if (n < 0)
                {
                    return -1;
                }

                if (n < 2)
                {
                    return 1;
                }

                int[,] baseVect = { { 1 }, { 1 } };
                var fibNMat = GetFibMatPower(n - 1);

                return Mat2By1Multiplication(fibNMat, baseVect)[1,0];
            }

            private int[,] GetFibMatPower(int exp)
            {
                var boolArray = ParseNumberIntoBitArray(exp);
                var currentMatSet = new List<int[,]>();
                var indexSet = new List<int>();
                // parse exp into power of 2s // 
                int currentValue = 0;
                int index = 0;

                currentMatSet.Add(fibMat);

                var retMat = new int[2, 2] { { 1, 0 }, { 0, 1 } }; // set to identity matrix

                while (currentValue < exp)
                {
                    currentMatSet.Add(Mat2By2Multiplication(currentMatSet[index], currentMatSet[index]));
                    if (boolArray[index])
                    {
                        currentValue += Convert.ToInt32(Math.Pow(2, index));
                        retMat = Mat2By2Multiplication(retMat, currentMatSet[index]);
                    }
                    
                    index++;
                }

                return retMat;
            }

            private bool[] ParseNumberIntoBitArray(int number)
            {
                var bitArray = new BitArray(number);
                var boolArray = new bool[bitArray.Count];
                bitArray.CopyTo(boolArray, 0);

                /*
                foreach (var element in boolArray)
                {
                    Console.Write(element + " ");
                }
                */

                return boolArray;
            }

            private int[,] Mat2By2Multiplication(int[,] mat1, int[,] mat2)
            {
                var mat = new int[2, 2] {{mat1[0,0] * mat2[0,0] + mat1[0,1] * mat2[1,0], mat1[0,0] * mat2[0,1] + mat1[0,1] * mat2[1,1]}, 
                                         {mat1[1,0] * mat2[0,1] + mat1[1,1] * mat2[1,0], mat1[1,0] * mat2[0,1] + mat1[1,1] * mat2[1,1]}};

                return mat;
            }

            private int[,] Mat2By1Multiplication(int[,] mat, int[,] vector) { return null; };
            
        }

        static void Main(string[] args)
        {
            var bitArray = new BitArray(new int[] { 10 });
            var boolArray = new bool[bitArray.Count];
            bitArray.CopyTo(boolArray, 0);

            foreach (var element in boolArray)
            {
                Console.Write(element + " ");
            }
        }
    }
}
