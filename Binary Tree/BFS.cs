using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;

namespace Binary_Tree
{
    public class BFS
    {
        public IList<IList<int>> BredthFirstSearch(TreeNode<int> root)
        {
          IList<IList<int>> ints = new List<IList<int>>();

            if (root == null)
            {
                return ints;
            }
            Queue<TreeNode<int>> queue = new Queue<TreeNode<int>>();

            queue.Enqueue(root);    
            while (queue.Count > 0) 
            {
                int levelSize = queue.Count;
                IList<int> currentLevel = new List<int>();

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode<int> node = queue.Dequeue();
                    currentLevel.Add(node.Value);
                    if(node.Left != null)
                    {
                        queue.Enqueue(node.Left);
                    }
                    if (node.Right != null)
                    {
                        queue.Enqueue(node.Right);  
                    }  


                }
                ints.Add(currentLevel); 

            }
            return ints;
            
                   
        }
       }
    }
}