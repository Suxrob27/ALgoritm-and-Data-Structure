using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
     class MaxHeap<T> where T: IComparable<T>
    {
        void percolateUp(int i) {
            if (i <= 0)
            {
                return;
            }
            else if (h[parent(i)].CompareTo(h[i]) < 0)
            {
                T temp = h[i];
                h[i] = h[parent(i)];
                h[size() - 1] = temp;
                percolateUp(parent(i));
            }
        }
        public void printHeap()
        {
            for (int i = 0; i <= size() - 1; i++)
            {
                Console.Write(h[i] + " ");
            }
            Console.WriteLine("");
        }
        void maxHeapify(int i) 
        {
            int lc = lchild(i);
            int rc = rchild(i);
            int imax = i;

            if (lc < size() && (h[lc].CompareTo(h[imax]) > 0))
                imax = lc;
            if (rc < size() && (h[rc].CompareTo(h[imax]) > 0))
                imax = rc;
            if (i != imax)
            {
                T temp = h[i];
                h[i] = h[imax];
                h[imax] = temp;
                maxHeapify(imax);
            }
        }
        List<T> h = null;


        public MaxHeap() 
        {
          h = new List<T>();    
        }

        public int size()
        {
            return h.Count;
        }

        public T getMax()
        {
            if (size() <= 0)
            {
                return (T)Convert.ChangeType(-1, typeof(T));
            }

            else
                return h[0];    
        }
        public void insert(T key) 
        {
          h.RemoveAt(h.Count -1);
            int i = size() - 1;
            percolateUp(i);    
        }
        public void removeMax() 
        {
            if (size() == 1)
            {
                h.RemoveAt(h.Count -1);
            }
            else if(size() >1)
            {
                T temp = h[0];
                h[0] = h[size() -1];
                h[size() -1] = temp;
                h.RemoveAt(h.Count - 1);
                maxHeapify(0); 
            }
        }   
        public void buildHeap(T[] arr,int size)
        {
            h.AddRange(arr);
            for (int i = (size -1) / 2; i >= 0; i--)
            {
                maxHeapify(i);
            }
        }
        public int parent(int i)
        {
            return (i - 1) / 2;
        }
        public int lchild(int i) 
        {
            return i * 2 + 1;
        }
        public int rchild(int i)
        {
            return i * 2 + 2;
        }
    }
}
