using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimumSpanningTree
{
    class Program
    {
        static void Main(string[] args)
        {
            MinSpanTree msTree = new MinSpanTree(new Kruskal(@"C:\Users\Matt\Desktop\input.txt"));
            msTree.findMinSpanTree();
            msTree.printMinSpanTree();
        }
    }
}
