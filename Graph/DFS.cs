using Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    partial class Graph
    {
        //recursive DFS
        public void recursDFS(Graph g, int node, bool[] visisted)
        {
            visisted[node] = true;
            LinkedList.Node temp = (g.getArray())[node].GetHead();
            while (temp != null)
            {
                if (visisted[temp.data] == false)
                {
                    recursDFS(g, temp.data, visisted);
                }

                temp = temp.nextElement;
            }
        }

        //Usual DFS
        public void dfs_helper(Graph g, int source, bool[] visited, ref string result)
        {
            if (g.getVertices() < 1)
            {
                return;
            }

            //Create Stack(Implemented in previous chapters) for Depth First Traversal and Push source in it
            Stack<int> stack = new Stack<int> { };

            stack.Push(source);
            visited[source] = true;
            int current_node;
            LinkedList.Node temp;
            //Traverse while stack is not empty
            while (stack.Count != 0)
            {

                //Pop a vertex/node from stack and add it to the result
                current_node = stack.Pop();
                result += current_node.ToString();

                //Get adjacent vertices to the current_node from the array,
                //and if they are not already visited then push them in the stack
                temp = (g.getArray())[current_node].GetHead();

                while (temp != null)
                {

                    if (!visited[temp.data])
                    {
                        stack.Push(temp.data);
                        //Visit the node
                        visited[temp.data] = true;
                    }
                    temp = temp.nextElement;
                }
            } //end of while

        }
        public string dfsTraversal(Graph g)
        {
            string result = "";

            //Bool Array to hold the history of visited nodes
            //Make a node visited whenever you push it into stack
            bool[] visited = new bool[g.getVertices()];
         
            for (int i = 0; i < g.getVertices(); i++)
            {
                if (!visited[i])
                    dfs_helper(g, i, visited, ref result);
            }

            //delete[] visited;
            visited = null;

            return result;
        }

    }
}
