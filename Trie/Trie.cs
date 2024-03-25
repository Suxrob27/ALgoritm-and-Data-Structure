using System;
using System.Runtime.InteropServices;

namespace Tries
{
    class TrieNode
    {
        const int ALPHABET_SIZE = 26;

        public TrieNode[] children = new TrieNode[ALPHABET_SIZE];
        public bool isEndWord;

        public TrieNode()
        {
            this.isEndWord = false;
            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                this.children[i] = null; 
            }
        }
        //Function to unMark the currentNode as Leaf
        public void markAsLeaf()
        {
            this.isEndWord = true;
        }
        //Function to unMark the currentNode as Leaf
        public void unMarkAsLeaf()
        {
            this.isEndWord = false;
        }

    }
    class Trie
    {
        TrieNode root;
        const int ALPHABET_SIZE = 26;
        public Trie()
        {
            root = new TrieNode();
        }
        //Function to get the index of a character 't'
        public int getIndex(char t)
        {
            return t - 'a';
        }
        //Function to insert a key,value pair in the Trie
        public void insertNode(string key)
        {
            if (key == string.Empty)
            {
                return;
            }          
            
            TrieNode current = root;
            int index = 0;

            for (int i = 0; i < key.Length; i++)
            {
                index = getIndex(key[i]);
                if (current.children[i] == null)
                {
                    current.children[i] = new TrieNode();
                    Console.WriteLine("Element has been Inserted");
                }
                current = current.children[i];  
            }
            current.markAsLeaf();
        }
        //Function to search given key in Trie
        public bool searchNode(string key)
        {
            if (key == string.Empty)
            {
                return false;
            }

            TrieNode currentNode = root;    
            int index = 0;


            for (int i = 0; i < key.Length; i++)
            {
                index = getIndex(key[i]);
                if (currentNode.children[index] == null)
                {
                    return false;
                }
                currentNode = currentNode.children[index];

                if ((currentNode != null) & (currentNode.isEndWord == true))
                {
                    return true;
                }
            }
            return false;
       

        }
        //Function to delete given key from Trie
        public bool hasNoChildren(TrieNode currentNode)
        {
            for (int i = 0; i < ALPHABET_SIZE; i++)
            {
                if ((currentNode.children[i]) != null)
                    return false;
            }
            return true;
        }
        //Recursive function to delete given key
        public bool deleteHelper(string key, TrieNode currentNode, int length, int level)
        {
            bool deletedSelf = false;

            if (currentNode == null)
            {
                Console.WriteLine("Key does not exist");
                return deletedSelf;
            }

            //Base Case: If we have reached at the node which points to the alphabet at the end of the key.
            if (level == length)
            {
                //If there are no nodes ahead of this node in this path
                //Then we can delete this node
                if (hasNoChildren(currentNode))
                {

                    currentNode = null; //clear the pointer by pointing it to NULL
                    deletedSelf = true;
                }
                //If there are nodes ahead of currentNode in this path 
                //Then we cannot delete currentNode. We simply unmark this as leaf
                else
                {
                    currentNode.unMarkAsLeaf();
                    deletedSelf = false;
                }
            }
            else
            {
                TrieNode childNode = currentNode.children[getIndex(key[level])];
                bool childDeleted = deleteHelper(key, childNode, length, level + 1);
                if (childDeleted)
                {
                    //Making children pointer also null: since child is deleted
                    currentNode.children[getIndex(key[level])] = null;
                    //If currentNode is leaf node that means currntNode is part of another key
                    //and hence we can not delete this node and it's parent path nodes
                    if (currentNode.isEndWord)
                    {
                        deletedSelf = false;
                    }
                    //If childNode is deleted but if currentNode has more children then currentNode must be part of another key.
                    //So, we cannot delete currenNode
                    else if (!hasNoChildren(currentNode))
                    {
                        deletedSelf = false;
                    }
                    //Else we can delete currentNode
                    else
                    {
                        currentNode = null;
                        deletedSelf = true;
                    }
                }
                else
                {
                    deletedSelf = false;
                }
            }
            return deletedSelf;
        }

        //Function to delete given key from Trie
        public void deleteNode(string key)
        {
            if ((root == null) || (key == string.Empty))
            {
                Console.WriteLine("Null key or Empty trie error");
                return;
            }
            deleteHelper(key, root, key.Length, 0);
        }
    }
}





