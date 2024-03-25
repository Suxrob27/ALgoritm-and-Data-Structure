using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
    class MinHeap<T> where T : IComparable<T>
    {
        
        List<T> h = null;
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

        void minHeapify(int i)
        {
            int lc = lchild(i);
            int rc = rchild(i);
            int imin = i;
            if (lc < size() && (h[lc].CompareTo(h[imin]) < 0))
                imin = lc;
            if (rc < size() && (h[rc].CompareTo(h[imin]) < 0))
                imin = rc;
            if (i != imin)
            {
                T temp = h[i];
                h[i] = h[imin];
                h[imin] = temp;
                minHeapify(imin);
            }
        }

        //percolateUp(): It is meant to restore the 
        //heap property going up from a node to the root.
        void percolateUp(int i)
        {
            if (i <= 0)
                return;
            else if (h[parent(i)].CompareTo(h[i]) > 0)
            {
                // Swaps the value of two variables
                T temp = h[i];
                h[i] = h[parent(i)];
                h[parent(i)] = temp;
                percolateUp(parent(i));
                
            }
        }

        public MinHeap()
        {
            h = new List<T>();
        }

        public int size()
        {
            return h.Count;
        }

        public T getMin()
        {
            if (size() <= 0)
            {
                return (T)Convert.ChangeType(-1, typeof(T));
            }
            else
            {
                return h[0];
            }
        }
        public void insert(T key)
        {
            // Push elements into vector from the back
            h.Add(key);
            // Store index of last value of vector in  variable i
            int i = size() - 1;
            // Restore heap property
            percolateUp(i);
        }
        public void removeMin()
        {
            if (size() == 1)
            {
                // Remove the last item from the list
                h.RemoveAt(h.Count - 1);
            }
            else if (size() > 1)
            {
                // Swaps the value of two variables
                T temp = h[0];
                h[0] = h[size() - 1];
                h[size() - 1] = temp;
                // Deletes the last element
                h.RemoveAt(h.Count - 1);
                // Restore heap property
                minHeapify(0);
            }

        }
        public void buildHeap(T[] arr, int size)
        {
            // Copy elements of array into the List h 
            h.AddRange(arr);
            for (int i = (size - 1) / 2; i >= 0; i--)
            {
                minHeapify(i);
            }
        }

        //Bonus function: printHeap()
        public void printHeap()
        {
            for (int i = 0; i <= size() - 1; i++)
            {
                Console.Write(h[i] + " ");
            }
            Console.WriteLine("");

        }
    }
}
