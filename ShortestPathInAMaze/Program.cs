using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathInAMaze
{

    public class MazeSolverBFS
    {
        int numRow;
        int numCol;

        struct Point
        {
            public int x;
            public int y;
        };

        // An Data Structure for queue used in BFS
        class QueueNode
        {
            public QueueNode(Point pt, int dist) { }

            public Point pt;  // The cordinates of a cell
            public int dist;  // cell's distance of from the source
        };

        // check whether given cell (row, col) is a valid
        // cell or not.
        bool IsValid(int row, int col)
        {
            // return true if row number and column number
            // is in range
            return (row >= 0) && (row < numRow) &&
                   (col >= 0) && (col < numCol);
        }

        // function to find the shortest path between
        // a given source cell to a destination cell.
        int BreathFirstSearch(int[][] mat, Point src, Point dest)
        {
            // check source and destination cell
            // of the matrix have value 1
            if (mat[src.x][src.y] == 0 || mat[dest.x][dest.y] == 0)
            {
                return -1;
            }


            bool[][] visited = new bool[numRow][];
            for(int i = 0; i < numRow; i++)
            {
                visited[i] = new bool[numCol];
            }
            
            // Mark the source cell as visited
            visited[src.x][src.y] = true;
 
            // Create a queue for BFS
            Queue<QueueNode> q = new Queue<QueueNode>();

            // distance of source cell is 0
            QueueNode s = new QueueNode(src, 0);
            q.Enqueue(s);  // Enqueue source cell
 
            // Do a BFS starting from source cell
            while (q.Count != 0)
            {
                QueueNode curr = q.First();
                Point pt = curr.pt;

                // If we have reached the destination cell,
                // we are done
                if (pt.x == dest.x && pt.y == dest.y)
                {
                    return curr.dist;
                }

                // Otherwise dequeue the front cell in the queue
                // and enqueue its adjacent cells
                q.Dequeue();
                var neighbors = GetNeighbors(curr.pt);
                foreach (var point in neighbors)
                {
                    if (CanMoveTo(point))
                    {
                        q.Enqueue(new QueueNode(point, curr.dist + 1));
                    }
                }
            }

            return -1;
        }

        private bool CanMoveTo(Point pt) { return false;  }

        private List<Point> GetNeighbors(Point currentPoint) { return null; }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
