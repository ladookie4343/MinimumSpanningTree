using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimumSpanningTree
{
    class Prim : IMinTree
    {
        Graph graph;
        List<Edge> edgeList;
        int[] parent;
        IndirectHeap heap = new IndirectHeap();

        public Prim(string inputFile)
        {
            edgeList = EdgeHandler.initEdges(inputFile);
            graph = new Graph(edgeList);
            parent = new int[graph.Length + 1];
        }

        public List<Edge> findMinTree()
        {
            int start = 1; // start prim's algorithm from vertex 1

            int n = graph.Length;
            int[] key = new int[n + 1];

            for (int i = 0; i < n + 1; i++)
            {
                key[i] = int.MaxValue;
            }
            key[start] = 0;
            parent[start] = 0;

            heap.init(key);
            for (int i = 0; i < n; ++i)
            {
                int v = heap.deleteMin();
                LinkedList<Edge> adjList = graph.getList(v);
                foreach (Edge e in adjList)
                {
                    int w = v == e.v1 ? e.v2 : e.v1;
                    if (heap.isIn(w) && e.weight < heap.keyVal(w))
                    {
                        parent[w] = v;
                        heap.decrease(w, e.weight);
                    }
                }
            }
            return null;
        }
    }
}
