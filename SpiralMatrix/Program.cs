using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiralMatrix
{
    class Program
    {
        /*
        static void spiralPrint(int m, int n, int[,] a)
        {
            int i, k = 0, l = 0;
            //k - starting row index
            //m - ending row index
            //l - starting column index
            //n - ending column index
            //i - iterator
         

            while (k < m && l < n)
            {
                // Print the first row from the remaining rows
                for (i = l; i < n; ++i)
                {
                    Console.Write(a[k, i] + " ");
                }
                k++;

                // Print the last column from the remaining columns 
                for (i = k; i < m; ++i)
                {
                    Console.Write(a[i, n - 1] + " ");
                }
                n--;

                // Print the last row from the remaining rows
                if (k < m)
                {
                    for (i = n - 1; i >= l; --i)
                    {
                        Console.Write(a[m - 1, i] + " ");
                    }
                    m--;
                }

                // Print the first column from the remaining columns
                if (l < n)
                {
                    for (i = m - 1; i >= k; --i)
                    {
                        Console.Write(a[i, l] + " ");
                    }
                    l++;
                }
            }
        }

        static void spiralPrint(int m, int n, int[][] a)
        {
            int L, T, R, B, dir = 0;
            
            while (L <= R && T <= B)
            {
                if (dir == 0)
                {
                    for (int i = L; i <= R; i++)
                    {
                        Console.Write(a[T][i]);
                    }
                    T++;
                }

                if (dir == 1)
                {
                    for (int i = L; i <= R; i++)
                    {
                        Console.Write(a[T][i]);
                    }
                    T++;
                }

                if (dir == 2)
                {
                    for (int i = L; i <= R; i++)
                    {
                        Console.Write(a[T][i]);
                    }
                    T++;
                }

                if (dir == 3)
                {
                    for (int i = L; i <= R; i++)
                    {
                        Console.Write(a[T][i]);
                    }
                    T++;
                }

                dir = (dir + 1) % 4;
            }
        }

        */



        class SpiralPrint
        {
            bool InvalidColCheck(int[][] mat, int col)
            {
                return col < 0 && col >= mat[0].Length;
            }

            bool InvalidRowCheck(int[][] mat, int row)
            {
                return row < 0 && row >= mat.Length;
            }

            void PrintCol(int[][] mat, int col, int startRow, int endRow)
            {
                if (InvalidColCheck(mat, col) || InvalidColCheck(mat, startRow) || InvalidRowCheck(mat, endRow))
                {
                    return;
                }

                if (startRow == endRow)
                {
                    Console.Write(mat[startRow][col]);
                    return;
                }

                int dir = startRow > endRow ? -1 : 1;

                int i = startRow;
                while (i != endRow)
                {
                    Console.Write(mat[i][col]);
                    i = i + dir;
                }
                
            }

            void PrintRow(int[][] mat, int row, int startCol, int endCol)
            {
                if (InvalidRowCheck(mat, row) || InvalidColCheck(mat, startCol) || InvalidColCheck(mat, endCol))
                {
                    return;
                }

                if (startCol == endCol)
                {
                    Console.Write(mat[row][startCol]);
                }

                int dir = startCol > endCol ? -1 : 1;

                int i = startCol;
                while (i != endCol)
                {
                    Console.Write(mat[row][i]);

                    i = i + dir;
                }
            }

            void SpiralPrintMat(int[][] mat)
            {
                int numRow = mat.Length;
                int numCol = mat[0].Length;

                int startRow = 0;
                int endRow = numRow - 1;

                int startCol = 0;
                int endCol = numCol - 1;
                int rotation = 0;
                while (startRow <= endRow && startCol <= endCol)
                {
                    if (rotation == 0)
                    {
                        PrintRow(mat, startRow, startCol, endCol);
                        startRow++;
                    }
                    else if (rotation == 1)
                    {
                        PrintCol(mat, endCol, startRow, endRow);
                        endCol--;
                    }
                    else if (rotation == 2)
                    {
                        PrintRow(mat, endRow, endCol, startCol);
                        endRow--;
                    }
                    else if (rotation == 3)
                    {
                        PrintCol(mat, startCol, endRow, startRow);
                        startCol++;
                    }
                    rotation = (rotation + 1) % 4;
                }
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
