using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimumSpanningTree
{
    class Graph
    {
        List<Edge> edgeList;
        LinkedList<Edge>[] adjList;
        
        int length;
        public int Length { get { return length; } }

        const int MAX_NODES = 256;

        public Graph(List<Edge> edgeList)
        {
            this.edgeList = edgeList;
            adjList = new LinkedList<Edge>[MAX_NODES];
            initAdjList();
            length = EdgeHandler.calculateNumNodes(edgeList);
        }

        public LinkedList<Edge> getList(int v)
        {
            return adjList[v];
        }

        private void initAdjList()
        {
            for (int i = 0; i < edgeList.Count; ++i)
            {
                adjList[edgeList[i].v1].AddLast(edgeList[i]);
                adjList[edgeList[i].v2].AddLast(edgeList[i]);
            }
        }
    }
}
