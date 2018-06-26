using System;

class Solution
{

    public class Matrix
    {
        int[][] markedMatrix;
        int[][] originalMatrix;
        int maxRowBound;
        int maxColBound;

        public Matrix(int[][] matrix)
        {
            originalMatrix = matrix;

            markedMatrix = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                markedMatrix[i] = new int[matrix[i].Length];
            }

            maxRowBound = originalMatrix.Length;
            maxColBound = originalMatrix[0].Length;
        }

        public int GetBiggestIslandSize()
        {
            int currentLargestIslandSize = 0;

            int row = 0, col = 0;

            do
            { 
                FindIsland(out row, out col);
                var newIslandSize = GetIslandSize(row, col);
                if (currentLargestIslandSize < newIslandSize)
                {
                    currentLargestIslandSize = newIslandSize;
                }
            }
            while (row != -1 && col != -1);

            return currentLargestIslandSize;
        }

        void FindIsland(out int row, out int col)
        {
            row = col = -1;
            for (int i = 0;  i < maxRowBound; i++)
            {
                for (int j = 0; j < maxColBound; j++)
                {
                    if (originalMatrix[i][j] == 1 && markedMatrix[i][j] == 0)
                    {
                        row = i;
                        col = j;
                    }
                }
            }
        }

        // get the island size with the starting poing 
        int GetIslandSize(int row, int col)
        {
            if (row == -1 || col == -1)
            {
                return 0;
            }

            int currentSize = 1;
            markedMatrix[row][col] = 1;

            // try move left
            if (CanMoveToRowCol(row, col - 1))
            {
                currentSize = currentSize + GetIslandSize(row, col - 1);
            }

            // try move right
            if (CanMoveToRowCol(row, col + 1))
            {
                currentSize = currentSize + GetIslandSize(row, col + 1);
            }

            // try move up
            if (CanMoveToRowCol(row - 1, col))
            {
                currentSize = currentSize + GetIslandSize(row - 1, col);
            }

            // try move down
            if (CanMoveToRowCol(row + 1, col))
            {
                currentSize = currentSize + GetIslandSize(row + 1, col);
            }

            // try move up and left
            if (CanMoveToRowCol(row - 1, col - 1))
            {
                currentSize = currentSize + GetIslandSize(row - 1, col - 1);
            }

            // try move up and right
            if (CanMoveToRowCol(row - 1, col + 1))
            {
                currentSize = currentSize + GetIslandSize(row - 1, col + 1);
            }

            // try move down left
            if (CanMoveToRowCol(row + 1, col - 1))
            {
                currentSize = currentSize + GetIslandSize(row + 1, col - 1);
            }

            // try move down and right
            if (CanMoveToRowCol(row + 1, col + 1))
            {
                currentSize = currentSize + GetIslandSize(row + 1, col + 1);
            }

            return currentSize;
        }

        bool CanMoveToRowCol(int row, int col)
        {
            if (CheckRowColBounds(row, col) && 
                markedMatrix[row][col] == 0 &&
                originalMatrix[row][col] == 1)
            {
                return true;
            }

            return false;
        }

        bool CheckRowColBounds(int row, int col)
        {
            if (row < 0 || row == maxRowBound || col < 0 || col == maxColBound)
            {
                return false;
            }

            return true;
        }
    }

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        // remove unused variable m to avoid compiler warning
        Convert.ToInt32(Console.ReadLine());
        int[][] grid = new int[n][];
        for (int grid_i = 0; grid_i < n; grid_i++)
        {
            string[] grid_temp = Console.ReadLine().Split(' ');
            grid[grid_i] = Array.ConvertAll(grid_temp, Int32.Parse);
        }

        var matrix = new Matrix(grid);
        Console.WriteLine(matrix.GetBiggestIslandSize());
    }
}
