using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Hash_Table
{
    class HashEntry
    {
        public string key;
        public int value;
        public HashEntry next;

        public HashEntry(string key, int value)
        {
            this.key = key;
            this.value = value;
        }
    }
    class HashTable
    {
        HashEntry[] bucket = null;

        int size;
        int slots;

        public HashTable(int s)
        {
            bucket = new HashEntry[s];
            for (int i = 0; i < s; i++)
            {
                bucket[i] = null;
            }
            this.size = 0;
            this.slots = s;
        }

        public int getSize()
        {
            return size;
        }
        public bool isEmpty()
        {
            return size == 0;
        }

        public int getindex(String key)
        {
            int Key = 0;
            for (int i = 0; i < key.Length; i++)
            {
                Key = 37 * Key + key[i];
            }

            if (Key < 0)
                Key *= -1;
            return Key % slots;

        }

        public void insert(string key, int value)
        {
            int hashIndex = getindex(key);
            if (bucket[hashIndex] == null)
            {
                bucket[hashIndex] = new HashEntry(key, value);
                size++;
            }
            else
            {
                HashEntry temp = bucket[hashIndex];
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = new HashEntry(key, value);
                size++;
            }
        }

        public void display()
        {
            HashEntry temp;
            for (int i = 0; i < slots; i++)
            {
                if (bucket[i] != null)
                {
                    Console.Write("HashIndex : " + i + " ");
                    temp = bucket[i];
                    while (temp != null)
                    {
                        Console.Write($"(key = {temp.key}, value = '{temp.value}')");
                        temp = temp.next;
                    }
                }
                Console.WriteLine("");
            }
        }

    }
}