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

        public Prim(string inputFile)
        {
            edgeList = EdgeHandler.initEdges(inputFile);
            graph = new Graph(edgeList);
        }

        public List<Edge> findMinTree()
        {




            return null;
        }
    }
}
