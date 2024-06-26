﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Binary_Tree
{

    public class Node
    {
        public int Data { get; set; }
        public List<Node> Neighbors { get; set; }

        public Node(int data)
        {
            Data = data;
            Neighbors = new List<Node>();
        }
    }

    
   public  class Node<TNode> : IComparable<TNode>  where  TNode  : IComparable<TNode> 
     {
        public TNode Value { get; set; }

        public Node(TNode value)
        {
           Value = value;   
        }

        public Node<TNode> Left { get; set; }
        public Node<TNode> Right { get; set; }


        public int CompareTo(TNode other) 
        {
            return Value.CompareTo(other);
        }

     }

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public Node<T> head;
         public int _count;

        public void Add(T value)
        {
            if(head == null)
            {
                 head = new Node<T>(value);
            }
            else
            {
                AddTo(head, value);
            }
            _count++;

        }

        public void AddTo(Node<T> node, T Value)
        {
            if(Value.CompareTo(node.Value) < 0)
            {
                if(node.Left == null)
                {
                    node.Left = new Node<T>(Value);

                }
                else
                {
                    AddTo(node.Left, Value);
                }
            }
            else
            {
                if (node.Right == null)
                {
                    node.Right = new Node<T>(Value);
                }
                else
                {
                    AddTo(node.Right, Value);
                }
            }

        }



        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int Count
        {
            get { return _count; }
        }


        public void ClearTree()
        {
            head = null;
            _count = 0;
        }

        public bool Contains(T value)
        {
            Node<T> parent;
            return FindWithParent(value, out parent) != null;   
        }
        public Node<T> FindWithParent(T Value, out Node<T> parent)
        {
            Node<T> current = head;
            parent = null;   
            while (current != null)
            {
                int result = current.CompareTo(Value);  
                if (result > 0)
                {
                    parent = current;   
                    current = current.Left; 
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Right;    
                }
                else
                {
                    break;
                }
            }
            return current;
        }
        public bool Remove(T Value)
        {
            Node<T> current;
            Node<T> parent;

            current = FindWithParent(Value, out parent);    
            if (current == null) 
            {
                return false;
            }
            _count--;
            if (current.Right == null) 
            {
              if(parent == null)
                {
                    head = current.Left;
                }
              else 
              {
                    int result = parent.CompareTo(current.Value);     
                    if (result > 0) 
                    {
                        parent.Left = current.Left;
                    }

                    else if(result < 0)
                    {
                        parent.Right = current.Left;   
                    }
              }
            }
            else if(current.Right.Left == null)
            {
                current.Right.Left = current.Left;  
                if(parent == null)
                {
                    head = current.Right;
                }
                else
                {
                    int result = parent.CompareTo(current.Value);
                    if(result > 0) 
                    {
                        parent.Left = current.Right;
                    }
                    else if (result < 0)
                    {
                        parent.Right = current.Right;   
                    }

                }
            }
            else
            {
                Node<T> leftmost = current.Right.Left;
                Node<T> leftmostParent = current.Right;
                while (leftmostParent != null) 
                {
                    leftmostParent = leftmost;
                    leftmost = leftmost.Left;
                }

                leftmostParent.Left = leftmost.Right;


            }

            return true;

        }

        public void InOrderTraversal(Node<T> node, Stack<T> value)
        {
            InOrderTraversal(node.Left, value);
            value.Push(node.Value);
            InOrderTraversal(node.Right, value);

        }

        public void preOrderTraversal(Node<T> node, Stack<T> value)
        {
            value.Push(node.Value);
            InOrderTraversal(node.Left, value);
            InOrderTraversal(node.Right, value);
        }

        public void postOrder(Node<T> node, Stack<T> value)
        {
            InOrderTraversal(node.Left, value);
            InOrderTraversal(node.Right, value);
            value.Push(node.Value);
        }
        public void BredthFirstSearch(Node root)
        {
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();

            queue.Enqueue(root);    
            visited.Add(root);      

            while (queue.Count > 0) 
            {
                var currentNode = queue.Dequeue();

                Console.WriteLine(currentNode.Data);

                foreach (var item in currentNode.Neighbors)
                {
                    if (!visited.Contains(item))
                    {
                        queue.Enqueue(item);
                        visited.Add(item);
                    }
                }
            } 

        }

    }
    
}
