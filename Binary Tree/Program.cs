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


            instanse.BredthFirstSearch(instanse.head);

        }
    }
}
