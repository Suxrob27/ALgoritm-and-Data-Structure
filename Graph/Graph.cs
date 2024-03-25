using Graphs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
     partial class Graph
    {
        int vertices;
        LinkedList[] array;

        public Graph(int v) 
        {
         array = new LinkedList[v]; 
         vertices = v;
            for (int i = 0; i < v; i++)
            {
                array[i] = new LinkedList();
            }
        }


        public void addEdge(int sourse, int destination)
        {
            if (sourse < vertices && vertices > destination)
            {
                array[sourse].InsertAtHead(destination);
            }
        }

        public void printGraph()
        {
            Console.WriteLine("Adjacency List of Directed Graph");
            LinkedList.Node temp;

            for (int i = 0; i < vertices; i++)
            {
                Console.WriteLine("|" + i + "| => ");
                temp = array[i].GetHead();
                while(temp != null)
                {
                    Console.WriteLine("[" + temp.data + "] ->");
                    temp = temp.nextElement;
                }
                Console.WriteLine("NULL");
            }
        }

        public LinkedList[] getArray()
        { 
          return array; 
        }
        public int getVertices() 
        {
         return vertices;    
        }

        public  void bfsTraversal_helper(Graph g, int sourse, bool[] visited, ref string result)
        {
            if (g.getVertices() < 1)
            {
                return;
            }

            Queue<int> queue = new Queue<int> { };   
            queue.Enqueue(sourse);
            visited[sourse] = true;
            int current_node;

            while (queue.Count > 0) 
            {
              current_node  = queue.Dequeue();
                result += current_node.ToString();

                LinkedList.Node temp = g.getArray()[current_node].GetHead();
                while (temp != null)
                {
                    if (!visited[temp.data])
                    {
                        queue.Enqueue(temp.data);
                        visited[temp.data] = true; //Visit the current Node
                    }
                    temp = temp.nextElement;    
                }
            }
        }

        public  string bfsTraversal(Graph g)
        {
            bool[] visited = new bool[g.getVertices()];    

            string result = "";
            for (int i = 0; i < g.getVertices(); i++)
            {
                if (!visited[i])
                    bfsTraversal_helper(g, i, visited, ref result);
            }
            visited = null;

            return result;  
        }
        
    }
}
