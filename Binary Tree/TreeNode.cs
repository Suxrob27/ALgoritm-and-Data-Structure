using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Tree
{
    
     class TreeNode<TNode> : IComparable<TNode>  where  TNode  : IComparable<TNode> 
     {
        public TNode Value { get; set; }

        public TreeNode(TNode value)
        {
           Value = value;   
        }

        public TreeNode<TNode> Left { get; set; }
        public TreeNode<TNode> Right { get; set; }


        public int CompareTo(TNode other) 
        {
            return Value.CompareTo(other);
        }

     }

    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private TreeNode<T> head;
        private int _count;

        public void Add(T value)
        {
            if(head == null)
            {
                 head = new TreeNode<T>(value);
            }


        }

        private void AddTo(TreeNode<T> node, T Value)
        {
            if(Value.CompareTo(node.Value) < 0)
            {
                if(node.Left == null)
                {
                    node.Left = new TreeNode<T>(Value);

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
                    node.Right = new TreeNode<T>(Value);
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


        public void Clear()
        {
            head = null;
            _count = 0;
        }



    }
}
