using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinimumSpanningTree
{
    class IndirectHeap
    {
        private int[] key;
        private int[] into;
        private int[] outof;
        int n;

        public IndirectHeap() { }

        public void init(int[] key)
        {
            n = key.Length;
            this.key = key;
            into = new int[key.Length];
            initArray(into);
            outof = new int[key.Length];
            initArray(outof);
            heapify();
        }

        public int deleteMin()
        {
            int result = outof[1];
            int temp = outof[1];
            outof[1] = outof[key.Length - 1];
            into[outof[1]] = 1;
            outof[n] = temp;
            into[temp] = n;
            n--;
            siftdown(1);
            return result;
        }

        public void decrease(int w, int newWeight)
        {
            key[w] = newWeight;
            int c = into[w];
            int p = c / 2;

            while (p >= 1)
            {
                if (key[outof[p]] <= newWeight)
                {
                    break;
                }
                outof[c] = outof[p];
                into[outof[c]] = c;
                c = p;
                p = c / 2;
            }
            outof[c] = w;
            into[w] = c;
        }

        public bool isIn(int w)
        {
            return into[w] <= n;
        }

        public int keyVal(int w)
        {
            return key[w];
        }

        private void initArray(int[] array)
        {
            for (int i = 0; i < array.Length; ++i) 
            {
                array[i] = i;
            }
        }

        private void heapify()
        {
            for (int i = key.Length / 2; i > 0; ++i)
            {
                siftdown(i);
            }
        }

        private void siftdown(int i)
        {
            int s = outof[i];
            int temp = key[s];

            while (2 * i <= n)
            {
                int c = 2 * i;
                if (c < n && key[outof[c + 1]] < key[outof[c]])
                {
                    c++;
                }
                if (key[outof[c]] < temp)
                {
                    outof[i] = outof[c];
                    into[outof[i]] = i;
                }
                else
                {
                    break;
                }

                i = c;
                outof[i] = s;
                into[s] = i;
            }
        }
    }
}
