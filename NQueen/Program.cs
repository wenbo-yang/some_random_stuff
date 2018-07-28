using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NQueen
{
    class Program
    {
        string[,] board_;
        List<bool> cols_;
        List<bool> diag1_;
        List<bool> diag2_;
        List<string[,]> sols_;

        List<string[,]> solveNQueens(int n)
        {
            sols_.Clear();
            board_ = new string[n, n];

            cols_ = new List<bool>(n);
            diag1_ = new List<bool>(2 * n - 1);
            diag2_ = new List<bool>(2 * n - 1);

            nqueens(n, 0);

            return sols_;
        }


        bool available(int x, int y, int n)
        {
            return !cols_[x]
                && !diag1_[x + y]
                && !diag2_[x - y + n - 1];
        }

        void updateBoard(int x, int y, int n, bool is_put)
        {
            cols_[x] = is_put;
            diag1_[x + y] = is_put;
            diag2_[x - y + n - 1] = is_put;
            board_[y, x] = is_put ? "Q" : ".";
        }

        // Try to put the queen on y-th row
        void nqueens(int n, int y)
        {
            if (y == n)
            {
                // found one solution, add to the ans set
                sols_.Add(board_);
                return;
            }

            // Try every column
            for (int x = 0; x < n; ++x)
            {
                if (!available(x, y, n)) continue;
                updateBoard(x, y, n, true);
                nqueens(n, y + 1);
                updateBoard(x, y, n, false);
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
