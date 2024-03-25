using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Heap
{
     class Program
    {
        static void Main(string[] args)
        {
            MinHeap<int> heap = new MinHeap<int>();

            int size = 6;
            int[] arr = { 2, 8, 15, 5, 1, 20 };

            heap.buildHeap(arr, size);
            heap.printHeap();


            Console.WriteLine(heap.getMin());
            heap.removeMin();
            Console.WriteLine(heap.getMin());
            heap.removeMin();

            heap.insert(-10);
            Console.WriteLine(heap.getMin());

            return;
        }
    }
}
