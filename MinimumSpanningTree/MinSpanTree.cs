using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MinimumSpanningTree
{
    struct Edge
    {
        public string Vertex1_name, Vertex2_name;
        public int weight;
        public int v1, v2;
    }

    class MinSpanTree
    {
        IMinTree minTreeAlgorithm;
        List<Edge> minSpanTree;
        

        public MinSpanTree(IMinTree algorithm)
        {
            minTreeAlgorithm = algorithm;
        }               

        public void findMinSpanTree()
        {
            minSpanTree = minTreeAlgorithm.findMinTree();
        }

        public void printMinSpanTree()
        {
            foreach (Edge e in minSpanTree)
            {
                Console.WriteLine("{0} <--> {1}", e.Vertex1_name, e.Vertex2_name);
            }
        }
    }
}
