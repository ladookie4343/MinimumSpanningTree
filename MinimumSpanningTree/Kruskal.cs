using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MinimumSpanningTree
{
    class Kruskal : IMinTree
    {
        private DisjointSet djset = new DisjointSet();
        private List<Edge> edge = new List<Edge>();
        private int numNodes;

        public Kruskal(string inputFile)
        {
            edge = EdgeHandler.initEdges(inputFile);
            numNodes = EdgeHandler.calculateNumNodes(edge);
        }                       

        public List<Edge> findMinTree()
        {
            edge.Sort(delegate(Edge e1, Edge e2) {
                           if (e1.weight > e2.weight) return 1;
                           if (e1.weight < e2.weight) return -1;
                           return 0;
                     });
            
            for (int i = 1; i <= numNodes; ++i)
            {
                djset.makeset(i);
            }

            List<Edge> minSpanTree = new List<Edge>();
            int count = 0;
            int idx = 0;
            while (count < numNodes - 1)
            {
                if (djset.findset(edge[idx].v1) != djset.findset(edge[idx].v2))
                {
                    minSpanTree.Add(edge[idx]);
                    count++;
                    djset.union(edge[idx].v1, edge[idx].v2);
                }
                idx++;
            }

            return minSpanTree;
        }
    }
}
