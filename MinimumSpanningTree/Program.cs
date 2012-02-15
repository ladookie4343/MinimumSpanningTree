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
            string inputFile = @"C:\Users\Matt\Desktop\input.txt";
            MinSpanTree msTree = new MinSpanTree(new Kruskal(inputFile));
            msTree.findMinSpanTree();
            msTree.printMinSpanTree();

            Console.WriteLine();
            
            msTree = new MinSpanTree(new Prim(inputFile));
            msTree.findMinSpanTree();
            msTree.printMinSpanTree();
        }
    }
}
