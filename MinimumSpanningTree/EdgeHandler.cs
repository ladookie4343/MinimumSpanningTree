using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace MinimumSpanningTree
{
    static class EdgeHandler
    {
        public static List<Edge> initEdges(string inputFile)
        {
            List<Edge> edge = new List<Edge>();
            using (StreamReader reader = new StreamReader(inputFile))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    edge.Add(createEdge(line.Split(',')));
                }
            }
            return edge;
        }

        public static int calculateNumNodes(List<Edge> edge)
        {
            int numNodes = 0;
            foreach (Edge e in edge)
            {
                if (e.v1 > numNodes) numNodes = e.v1;
                if (e.v2 > numNodes) numNodes = e.v2;
            }
            return numNodes;
        }

        private static Edge createEdge(string[] edgePart)
        {
            Edge e = new Edge();
            string[] numberName;

            numberName = edgePart[0].Split(':');
            e.Vertex1_name = numberName[1];
            e.v1 = int.Parse(numberName[0]);

            numberName = edgePart[1].Split(':');
            e.Vertex2_name = numberName[1];
            e.v2 = int.Parse(numberName[0]);

            e.weight = int.Parse(edgePart[2]);
            return e;
        }
    }
}
