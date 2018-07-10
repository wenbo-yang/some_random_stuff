using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylineProblem
{

    // merge two dimensional interval
    class Program
    {
        private class MaxHeap
        {
            // (key, id)
            private List<int[]> nodes;

            // idx[i] = index of building[i] in nodes
            private int[] idx;

            public MaxHeap(int size)
            {
                idx = new int[size];
                nodes = new List<int[]>();
            }

            public void add(int key, int id)
            {
                idx[id] = nodes.Count;
                nodes.Add(new int[] { key, id });
                HeapifyUp(idx[id]);
            }

            public void Remove(int id)
            {
                int idx_to_evict = idx[id];
                SwapNode(idx_to_evict, nodes.Count - 1);
                idx[id] = -1;
                nodes.RemoveAt(nodes.Count - 1);
                HeapifyUp(idx_to_evict);
                HeapifyDown(idx_to_evict);
            }

            public Boolean IsEmpty()
            {
                return nodes.Count == 0;
            }

            public int Max()
            {
                return IsEmpty() ? 0 : nodes[0][0];
            }

            private void HeapifyUp(int i)
            {
                while (i != 0)
                {
                    int p = (i - 1) / 2;
                    if (nodes[i][0] <= nodes[p][0])
                        return;

                    SwapNode(i, p);
                    i = p;
                }
            }

            private void SwapNode(int i, int j)
            {
                int tmpIdx = idx[nodes[i][1]];
                idx[nodes[i][1]] = idx[nodes[i][1]];
                idx[nodes[i][1]] = tmpIdx;

                int[] tmpNode = nodes[i];
                nodes[i] = nodes[j];
                nodes[j] =  tmpNode;
            }

            private void HeapifyDown(int i)
            {
                while (true)
                {
                    int c1 = i * 2 + 1;
                    int c2 = i * 2 + 2;

                    if (c1 >= nodes.Count) return;

                    int c = (c2 < nodes.Count
                          && nodes[c2][0] > nodes[c1][0]) ? c2 : c1;

                    if (nodes[c][0] <= nodes[i][0])
                        return;

                    SwapNode(c, i);
                    i = c;
                }
            }

        }

        private MaxHeap heap;

        // heap
        public List<int[]> GetSkyline(int[][] buildings)
        {
            int n = buildings.Length;
            // {x, h, id}
            var es = new List<int[]>();

            for (int i = 0; i < n; ++i)
            {
                es.Add(new int[] { buildings[i][0], buildings[i][2], i });
                es.Add(new int[] { buildings[i][1], -buildings[i][2], i });
            }

            es.Sort();

            List<int[]> ans = new List<int[]>();

            heap = new MaxHeap(n);

            foreach (var e in es)
            {
                int x = e[0];
                int h = e[1];
                int id = e[2];

                Boolean entering = h > 0;
                h = Math.Abs(h);

                if (entering)
                {
                    if (h > heap.Max())
                        ans.Add(new int[] { x, h });
                    heap.add(h, id);
                }
                else
                {
                    heap.Remove(id);
                    if (h > heap.Max())
                        ans.Add(new int[] { x, heap.Max() });
                }
            }

            return ans;
        }

        public List<int> GetSkylineSweepLine(int[][] buildings)
        {

            return null;
        }

        static void Main(string[] args)
        {
            var test = new int[5, 3];
            

        }
    }
}
