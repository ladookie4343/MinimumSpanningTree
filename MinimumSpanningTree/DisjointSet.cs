using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimumSpanningTree
{
    class DisjointSet
    {
        int[] parents;
        int[] rank;
        const int MaxArray = 128;

        public DisjointSet() 
        { 
            parents = new int[MaxArray];
            rank = new int[MaxArray];
        }

        public void makeset(int set) 
        {
            parents[set] = set;
            rank[set] = 0;
        }

        public int findset(int node) 
        {
            int root = node;
            while (root != parents[root])
            {
                root = parents[root];
            }
            int j = parents[node]; // j == parent of 'node'
            while (j != root)
            {
                parents[node] = root;
                node = j;
                j = parents[node];
            }
            return root;
        }

        public void union(int i, int j) 
        {
            mergetrees(findset(i), findset(j));
        }

        private void mergetrees(int firstTree, int secondTree)
        {
            if (rank[firstTree] < rank[secondTree])
            {
                parents[firstTree] = secondTree;
            }
            else if (rank[firstTree] > rank[secondTree])
            {
                parents[secondTree] = firstTree;
            }
            else
            {
                parents[firstTree] = secondTree;
                rank[secondTree]++;
            }
        }

        public void printSets()
        {
            DJSets djSets = new DJSets();

            for (int i = 0; i < parents.Length; ++i)
            {
                if (parents[i] != 0)
                {
                    int root = findset(i);
                    if (!djSets.inDJSets(root))
                    {
                        djSets.addSet(root);
                        djSets.insertIntoSet(root, i);
                    }
                    else
                    {
                        djSets.insertIntoSet(root, i);
                    }
                }
            }
            djSets.printSets();
        }

        public void printArray()
        {
            for (int i = 0; i < parents.Length; i++)
            {
                Console.Write("{0} ", parents[i]);             
            }
            Console.Write("\n");
        }
    }

    class DJSet
    {
        int root;
        HashSet<int> set;

        public DJSet(int root)
        {
            set = new HashSet<int>();
            this.root = root;
        }

        public void add(int i)
        {
            set.Add(i);
        }


        public int Root
        {
            get { return root; }
            set { root = value; }
        }

        public void print()
        {
            bool firstTime = true;

            Console.Write("{");
            foreach (int i in set)
            {
                if (firstTime)
                {
                    firstTime = false;
                    Console.Write(i);
                }
                else
                {
                    Console.Write(",{0}", i);
                }
            }
            Console.Write("}");
        }
    }

    class DJSets
    {
        List<DJSet> djSets;

        public DJSets() { djSets = new List<DJSet>(); }

        public void printSets()
        {
            bool firstTime = true;
            foreach (DJSet djSet in djSets)
            {
                if (firstTime)
                {
                    firstTime = false;
                    djSet.print();
                }
                else
                {
                    Console.Write(",  ");
                    djSet.print();
                }
            }
            Console.WriteLine();
        }

        public void addSet(int root)
        {
            djSets.Add(new DJSet(root));
        }

        public bool inDJSets(int root)
        {
            foreach (DJSet djSet in djSets)
            {
                if (djSet.Root == root)
                {
                    return true;
                }
            }
            return false;
        }

        public void insertIntoSet(int root, int i)
        {
            foreach (DJSet djSet in djSets)
            {
                if (djSet.Root == root)
                {
                    djSet.add(i);
                }
            }
        }
    }
}
