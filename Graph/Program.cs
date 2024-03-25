using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
     class Program
    {
        static void Main(string[] args)
        {
            Graph graph = new Graph(5);
            graph.addEdge(1,2);
            graph.addEdge(0, 1);
            graph.addEdge(1,3);
            graph.addEdge(2,4); 
            graph.addEdge(3,5); 
            graph.dfsTraversal(graph);  
            
        }
    }
}
