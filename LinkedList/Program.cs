using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
     class Program
     {
          static void Main(string[] args) 
        {
            LinkedList linkedList = new LinkedList();
            linkedList.InsertAtHead(5);
            linkedList.InsertAtHead(3);
            linkedList.InsertAtHead(9);
            linkedList.InsertAtHead(56);
            linkedList.InsertAtHead(3);
        }   
    }
}
