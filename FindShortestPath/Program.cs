using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindShortestPath
{
/*
    public class NumberOfPathsInMxNMatrix
    {

        public int countPathsRecursive(int n, int m)
        {
            if (n == 1 || m == 1)
            {
                return 1;
            }
            return countPathsRecursive(n - 1, m) + countPathsRecursive(n, m - 1);
        }

        public int countPaths(int n, int m)
        {
            int T[][] = new int[n][m];
        for(int i=0; i<n; i++){
            T[i][0] = 1;
        }
        
        for(int i=0; i<m; i++){
            T[0][i] = 1;
        }
        for(int i=1; i<n; i++){
            for(int j=1; j<m; j++){
                T[i][j] = T[i - 1][j] + T[i][j - 1];
            }
        }
        return T[n - 1][m - 1];
    }

    class Graph
{
    private int V;
    private LinkedList<Integer> adj[];

    Graph(int v)
    {
        V = v;
        adj = new LinkedList[v];

        for (int i = 0; i < v; i++)
        {
            adj[i] = new LinkedList();
        }
    }

    void addEdge(int v, int w)
    {
        adj[v].add(w);
    }

    LinkedList shortest(int from, int to)
    {
        LinkedList<Integer> queue = new LinkedList<Integer>();
        LinkedList<Integer> res = new LinkedList<Integer>();

        int prev[] = new int[V];

        if (from == to) return res;
        queue.add(from);

        for (int i = 0; i < V; i++)
        {
            prev[i] = -1;
        }

        while (queue.size() != 0)
        {
            int curr = queue.poll();
            Iterator<Integer> i = adj[curr].listIterator();

            while (i.hasNext())
            {
                int n = i.next();

                if (prev[n] == -1)
                {                // unvisited?
                    prev[n] = curr;                 // store previous vertex

                    if (n == to)
                    {                  // we're finally there!
                        while (n != from)
                        {         // build result list ...
                            res.addFirst(n);
                            n = prev[n];
                        }

                        return res;                 // ... and return it
                    }

                    queue.add(n);
                }
            }
        }

        return res;
    }

    public BFSMAZE
    {
        public class Maze
        {

        public static int[][] arr = new int[][] {
            {0,0,0,0,0,0,0,0,0},
            {5,5,5,0,0,0,0,0,0},
            {0,0,0,5,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,9},
        };

        private static class Point
        {
            int x;
            int y;
            Point parent;

            public Point(int x, int y, Point parent)
            {
                this.x = x;
                this.y = y;
                this.parent = parent;
            }

            public Point getParent()
            {
                return this.parent;
            }

            public String toString()
            {
                return "x = " + x + " y = " + y;
            }
        }

        public static Queue<Point> q = new LinkedList<Point>();

        public static Point getPathBFS(int x, int y)
        {

            q.add(new Point(x, y, null));

            while (!q.isEmpty())
            {
                Point p = q.remove();

                if (arr[p.x][p.y] == 9)
                {
                    System.out.println("Exit is reached!");
                    return p;
                }

                if (isFree(p.x + 1, p.y))
                {
                    arr[p.x][p.y] = -1;
                    Point nextP = new Point(p.x + 1, p.y, p);
                    q.add(nextP);
                }

                if (isFree(p.x - 1, p.y))
                {
                    arr[p.x][p.y] = -1;
                    Point nextP = new Point(p.x - 1, p.y, p);
                    q.add(nextP);
                }

                if (isFree(p.x, p.y + 1))
                {
                    arr[p.x][p.y] = -1;
                    Point nextP = new Point(p.x, p.y + 1, p);
                    q.add(nextP);
                }

                if (isFree(p.x, p.y - 1))
                {
                    arr[p.x][p.y] = -1;
                    Point nextP = new Point(p.x, p.y - 1, p);
                    q.add(nextP);
                }

            }
            return null;
        }


        public static boolean isFree(int x, int y)
        {
            if ((x >= 0 && x < arr.length) && (y >= 0 && y < arr[x].length) && (arr[x][y] == 0 || arr[x][y] == 9))
            {
                return true;
            }
            return false;
        }

    }

    class BFSMazeSolver2
    {
        private List<Coordinate> backtrackPath(Coordinate cur)
        {
            List<Coordinate> path = new ArrayList<>();
            Coordinate iter = cur;

            while (iter != null)
            {
                path.add(iter);
                iter = iter.parent;
            }

            return path;
        }

        public List<Coordinate> solve(Maze maze)
        {
            LinkedList<Coordinate> nextToVisit
              = new LinkedList<>();
            Coordinate start = maze.getEntry();
            nextToVisit.add(start);

            while (!nextToVisit.isEmpty())
            {
                Coordinate cur = nextToVisit.remove();

                if (!maze.isValidLocation(cur.getX(), cur.getY())
                  || maze.isExplored(cur.getX(), cur.getY())
                )
                {
                    continue;
                }

                if (maze.isWall(cur.getX(), cur.getY()))
                {
                    maze.setVisited(cur.getX(), cur.getY(), true);
                    continue;
                }

                if (maze.isExit(cur.getX(), cur.getY()))
                {
                    return backtrackPath(cur);
                }

                for (int[] direction : DIRECTIONS)
                {
                    Coordinate coordinate
                      = new Coordinate(
                        cur.getX() + direction[0],
                        cur.getY() + direction[1],
                        cur
                      );
                    nextToVisit.add(coordinate);
                    maze.setVisited(cur.getX(), cur.getY(), true);
                }
            }
            return Collections.emptyList();
        }

    }
*/

    /*
     * // C++ program to find the shortest path between
// a given source cell to a destination cell.
#include <bits/stdc++.h>
using namespace std;
#define ROW 9
#define COL 10
 
//to store matrix cell cordinates
struct Point
{
    int x;
    int y;
};
 
// An Data Structure for queue used in BFS
struct queueNode
{
    Point pt;  // The cordinates of a cell
    int dist;  // cell's distance of from the source
};
 
// check whether given cell (row, col) is a valid
// cell or not.
bool isValid(int row, int col)
{
    // return true if row number and column number
    // is in range
    return (row >= 0) && (row < ROW) &&
           (col >= 0) && (col < COL);
}
 
// These arrays are used to get row and column
// numbers of 4 neighbours of a given cell
int rowNum[] = {-1, 0, 0, 1};
int colNum[] = {0, -1, 1, 0};
 
// function to find the shortest path between
// a given source cell to a destination cell.
int BFS(int mat[][COL], Point src, Point dest)
{
    // check source and destination cell
    // of the matrix have value 1
    if (!mat[src.x][src.y] || !mat[dest.x][dest.y])
        return INT_MAX;
 
    bool visited[ROW][COL];
    memset(visited, false, sizeof visited);
     
    // Mark the source cell as visited
    visited[src.x][src.y] = true;
 
    // Create a queue for BFS
    queue<queueNode> q;
     
    // distance of source cell is 0
    queueNode s = {src, 0};
    q.push(s);  // Enqueue source cell
 
    // Do a BFS starting from source cell
    while (!q.empty())
    {
        queueNode curr = q.front();
        Point pt = curr.pt;
 
        // If we have reached the destination cell,
        // we are done
        if (pt.x == dest.x && pt.y == dest.y)
            return curr.dist;
 
        // Otherwise dequeue the front cell in the queue
        // and enqueue its adjacent cells
        q.pop();
 
        for (int i = 0; i < 4; i++)
        {
            int row = pt.x + rowNum[i];
            int col = pt.y + colNum[i];
             
            // if adjacent cell is valid, has path and
            // not visited yet, enqueue it.
            if (isValid(row, col) && mat[row][col] && 
               !visited[row][col])
            {
                // mark cell as visited and enqueue it
                visited[row][col] = true;
                queueNode Adjcell = { {row, col},
                                      curr.dist + 1 };
                q.push(Adjcell);
            }
        }
    }
 
    //return -1 if destination cannot be reached
    return INT_MAX;
}
     * 
    */


/*
    public class DijkstraShortestPath
    {

        public Map<Vertex<Integer>, Integer> shortestPath(Graph<Integer> graph, Vertex<Integer> sourceVertex)
        {

            //heap + map data structure
            BinaryMinHeap<Vertex<Integer>> minHeap = new BinaryMinHeap<>();

            //stores shortest distance from root to every vertex
            Map<Vertex<Integer>, Integer> distance = new HashMap<>();

            //stores parent of every vertex in shortest distance
            Map<Vertex<Integer>, Vertex<Integer>> parent = new HashMap<>();

            //initialize all vertex with infinite distance from source vertex
            for (Vertex<Integer> vertex : graph.getAllVertex())
            {
                minHeap.add(Integer.MAX_VALUE, vertex);
            }

            //set distance of source vertex to 0
            minHeap.decrease(sourceVertex, 0);

            //put it in map
            distance.put(sourceVertex, 0);

            //source vertex parent is null
            parent.put(sourceVertex, null);

            //iterate till heap is not empty
            while (!minHeap.empty())
            {
                //get the min value from heap node which has vertex and distance of that vertex from source vertex.
                BinaryMinHeap<Vertex<Integer>>.Node heapNode = minHeap.extractMinNode();
                Vertex<Integer> current = heapNode.key;

                //update shortest distance of current vertex from source vertex
                distance.put(current, heapNode.weight);

                //iterate through all edges of current vertex
                for (Edge<Integer> edge : current.getEdges())
                {

                    //get the adjacent vertex
                    Vertex<Integer> adjacent = getVertexForEdge(current, edge);

                    //if heap does not contain adjacent vertex means adjacent vertex already has shortest distance from source vertex
                    if (!minHeap.containsData(adjacent))
                    {
                        continue;
                    }

                    //add distance of current vertex to edge weight to get distance of adjacent vertex from source vertex
                    //when it goes through current vertex
                    int newDistance = distance.get(current) + edge.getWeight();

                    //see if this above calculated distance is less than current distance stored for adjacent vertex from source vertex
                    if (minHeap.getWeight(adjacent) > newDistance)
                    {
                        minHeap.decrease(adjacent, newDistance);
                        parent.put(adjacent, current);
                    }
                }
            }
            return distance;
        }

        private Vertex<Integer> getVertexForEdge(Vertex<Integer> v, Edge<Integer> e)
        {
            return e.getVertex1().equals(v) ? e.getVertex2() : e.getVertex1();
        }

        public static void main(String args[])
        {
            Graph<Integer> graph = new Graph<>(false);
            graph.addEdge(0, 1, 4);
            graph.addEdge(1, 2, 8);
            graph.addEdge(2, 3, 7);
            graph.addEdge(3, 4, 9);
            graph.addEdge(4, 5, 10);
            graph.addEdge(2, 5, 4);
            graph.addEdge(1, 7, 11);
            graph.addEdge(0, 7, 8);
            graph.addEdge(2, 8, 2);
            graph.addEdge(3, 5, 14);
            graph.addEdge(5, 6, 2);
            graph.addEdge(6, 8, 6);
            graph.addEdge(6, 7, 1);
            graph.addEdge(7, 8, 7);

            graph.addEdge(1, 2, 5);
            graph.addEdge(2, 3, 2);
            graph.addEdge(1, 4, 9);
            graph.addEdge(1, 5, 3);
            graph.addEdge(5, 6, 2);
            graph.addEdge(6, 4, 2);
            graph.addEdge(3, 4, 3);

            DijkstraShortestPath dsp = new DijkstraShortestPath();
            Vertex<Integer> sourceVertex = graph.getVertex(1);
            Map<Vertex<Integer>, Integer> distance = dsp.shortestPath(graph, sourceVertex);
            System.out.print(distance);
        }
    }
    */
    class Program
    {
        public class Point
        {
            public Point() { }
            public Point(int X, int Y) { }

            public int X;
            public int Y;
        }

        static void Main(string[] args)
        {
            var cur = new Point();
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(cur.X, cur.Y));
            var point = queue.Dequeue();

            var maze = new int[3][];
            for(int i = 0; i < 3; i++ )
            {
                maze[i] = new int[3];
            }
        }
    }
}
