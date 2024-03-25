using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
  public class Node
    {
        public int value;
        public Node leftChild;
        public Node rightChild;
        public Node()
        {
            value = 0;
            leftChild = null;   
            rightChild = null;  
        }

        public Node(int val)
        {
            value = val;
            leftChild = null;   
            rightChild = null;  
        }   

    }

    public partial class BinarySearchTree
    {
        Node root;
        public BinarySearchTree(int rootValue)
        { 
          root = new Node(rootValue);   
        }

        public BinarySearchTree()
        {
            root = null;
        }
        public Node getroot()
        {
            return root; 
        }

        public Node inserthelper(Node currentNode, int val)
        {
            if (currentNode == null)
            {
                return new Node(val);
            }

            else if (currentNode.value > val)
            {
                currentNode.leftChild = inserthelper(currentNode.leftChild, val);
            }

            else
            { 
             currentNode.rightChild = inserthelper(currentNode.rightChild, val);  
            }
            return currentNode;
        }

        public void insertBST(int value)
        {
            if (getroot() == null)
            {
                root = new Node(value);
                return;
            }
            inserthelper(this.getroot(), value);
        }

        public void inorderPrint(Node currentNode)
        {
          inorderPrint(currentNode.leftChild);
          Console.WriteLine(currentNode.value);
          inorderPrint(currentNode.rightChild); 
        }
        public Node searchBSt(int value)
       {
            Node currentNode = root;
            while ((currentNode != null) &&  currentNode.value != value)
            {
                if (value < currentNode.value)
                {
                    currentNode = currentNode.leftChild;
                }
                else
                {
                    currentNode = currentNode.rightChild;
                }
            }
            return currentNode;
        }

        public Node search(Node curretnNode, int value)
        {
            if (curretnNode == null)
            {
                root = new Node(value);
                return root;
            }
            else if (curretnNode.value == value)
            { 
             return curretnNode; 
            }
            else if(curretnNode.value > value)
            {
                return search(curretnNode.leftChild, value);        
            }
            else 
            {
                return search(curretnNode.rightChild, value);
            }
     }    

        public bool deleteBST(int v)
        {
            return Delete(root, v);
        }

        public bool Delete(Node currentNode, int value)
        {
            if (root == null)
            {
                Console.WriteLine("the Root is Empty. Imposible To Delete!!");
                return false;
             }

            Node parent = root;
            while ((currentNode != null) && (currentNode.value != value))
            {
                parent = currentNode;
                if (currentNode.value > value)
                    currentNode = currentNode.leftChild;
                else
                    currentNode = currentNode.rightChild;

            }

            if (currentNode == null)
                return false;
            else if ((currentNode.leftChild == null) && (currentNode.rightChild == null))
            {
                //1. Node is Leaf Node
                //if that leaf node is the root (a tree with just root)
                if (root.value == currentNode.value)
                {

                    root = null;
                    return true;
                }
                else if (currentNode.value < parent.value)
                {

                    parent.leftChild = null;
                    return true;
                }
                else
                {

                    parent.rightChild = null;
                    return true;
                }

            }
            else if (currentNode.rightChild == null)
            {

                if (root.value == currentNode.value)
                {

                    root = currentNode.leftChild;
                    return true;
                }
                else if (currentNode.value < parent.value)
                {

                    parent.leftChild = currentNode.leftChild;
                    return true;
                }
                else
                {

                    parent.rightChild = currentNode.leftChild;
                    return true;
                }

            }
            else if (currentNode.leftChild == null)
            {
                if (root.value == currentNode.value)
                {

                    root = currentNode.rightChild;
                    return true;
                }
                else if (currentNode.value < parent.value)
                {

                    parent.leftChild = currentNode.rightChild;
                    return true;
                }
                else
                {

                    parent.rightChild = currentNode.rightChild;
                    return true;
                }

            }
            else
            {
                //Find Least Value Node in right-subtree of current Node
                Node leastNode = findLeastNode(currentNode.rightChild);
                //Set CurrentNode's Data to the least value in its right-subtree
                int tmp = leastNode.value;
                Delete(root, tmp);
                currentNode.value = leastNode.value;
                //Delete the leafNode which had the least value


                return true;
            }
        }

        public Node findLeastNode(Node currentNode)
        {
            Node temp = currentNode;

            while(temp.leftChild != null)
            {
                temp = temp.leftChild;  
            }
            return temp;    
        }
        public void preOrderPrint(Node currentNode)
        {
            Console.WriteLine(currentNode.value);
            preOrderPrint(currentNode.leftChild);
            preOrderPrint(currentNode.rightChild);  
        }


        public int findKthMax(Node rootNode, int k, int nodes)
        {
            if (k <= 0)
            {
                return -1;
            }
            //Perform In-Order Traversal to get sorted array. (ascending order)
            //Return value at index [length - k]
            ArrayList result = new ArrayList(nodes);
            inOrderTraversal(rootNode, result);
            return result.getAt(nodes - k);

        }
        public void inOrderTraversal(Node rootNode, ArrayList result)
        {

            if (rootNode != null)
            {

                inOrderTraversal(rootNode.leftChild, result);
                result.insert(rootNode.value);
                inOrderTraversal(rootNode.rightChild, result);

            }
        }
        public string findAncestors(Node rootNode, int k)
        {
            Stack<int> temp = new Stack<int>();
            string result = "";
           while((rootNode != null) && (rootNode.value != k))
           {
                if(k == rootNode.value)
                {
                    return "No Ancestor behind this number";
                }

                else if (rootNode.value > k)
                {
                    temp.Push(rootNode.value);
                    rootNode = rootNode.leftChild;
                }

                else
                {
                    temp.Push(rootNode.value);
                    rootNode = rootNode.rightChild;
                }
           }

            for (int i = 0; i < temp.Count; i++)
            {
                int value = temp.Pop(); 
              string tempstr = value.ToString();
                result += $"{tempstr} ";

            }
            Console.WriteLine(result);
            return result;  
           

        }

        public int findHeight(Node rootNode)
        {
            if (root == null)
            {
                return -1;
            }
            else 
            {
              int leftHeight = findHeight(rootNode.leftChild);
              int rightHeight = findHeight(rootNode.rightChild);

                if (leftHeight > rightHeight)
                {
                    return leftHeight + 1;
                }
                else
                {
                    return rightHeight + 1;
                }
            }
        }
    }
}
