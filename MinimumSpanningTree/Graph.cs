using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimumSpanningTree
{
    class Graph
    {
        bool directed;
        List<Edge> edgeList;
        

        public Graph(bool directed, string inputFile)
        {
            this.directed = directed;
            edgeList = EdgeHandler.initEdges(inputFile);
            initAdjList();
        }

        private void initAdjList()
        {
            LinkedList<Edge> edgeNode = new LinkedList<Edge>();

            for (int i = 0; i < edgeList.Count; ++i)
            {
                adjList[edgeList[i].v1] = 
            }
        }
    }
}
