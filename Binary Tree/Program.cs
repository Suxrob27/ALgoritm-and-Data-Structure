using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
     class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> instanse = new BinaryTree<int>();
            instanse.Add(4);
            instanse.Add(2);
            instanse.Add(8);
            instanse.Add(8);
            instanse.Add(14);
            instanse.Add(23);
            instanse.Add(34);

            instanse.Remove(8);
            instanse.Remove(34);
            instanse.Remove(8);
            instanse.Remove(8);
            instanse.ClearTree();


            Console.WriteLine("Дерево содержит узел со значением 8: {0}", instanse.Contains(8));
            Console.WriteLine("Дерево содержит узел со значением 5: {0}", instanse.Contains(5));
            Console.WriteLine("Дерево содержит узел со значением 3: {0}", instanse.Contains(3));
            Console.WriteLine("Дерево содержит узел со значением 7: {0}", instanse.Contains(7));
            Console.WriteLine("Дерево содержит узел со значением 12: {0}", instanse.Contains(12));
            Console.WriteLine("Дерево содержит узел со значением 10: {0}", instanse.Contains(10));
            Console.WriteLine("Дерево содержит узел со значением 15: {0}", instanse.Contains(15));
        }
    }
}
