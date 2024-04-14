using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
     class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree tree = new BinarySearchTree(9);
            tree.insertBST(10);
            tree.insertBST(4);
            tree.insertBST(3);
            tree.insertBST(33);
            tree.insertBST(22);
            tree.insertBST(67);
            tree.insertBST(29);
            tree.insertBST(32);


        }
    }
}
