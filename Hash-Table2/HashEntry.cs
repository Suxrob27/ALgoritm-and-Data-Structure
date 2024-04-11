using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash_Table2
{
     class HashEntry
    {
        public string key;
        public int value;
        public HashEntry next;

        public HashEntry()
        {
            key = "";
            value = -1;
            next = null;        
        }

        public HashEntry(string key, int value)
        {
            this.key = key;
            this.value = value;
            next = null;
        }
    }

    class HashTable
    {
        HashEntry[] bucket;
        int slot;
        int size;
        public HashTable(int s)
        {
            bucket = new HashEntry[s];
            for (int i = 0; i < s; i++)
            {
                bucket[i] = new HashEntry();
            }
            this.slot = 3;
            this.size = 0;
        }
        public int getSize()
        {
            return size;
        }
        public bool isEmpty()
        {
            return getSize() == 0;
        }




        public int getIndex(string key)
        {
            int Key = 0;
            for (int i = 0; i < key.Length; i++)
            {
                Key = 37 * Key + key[i];
            }
            if (Key < 0)
            {
                Key *= -1;
            }

            return Key;
        }


        public void insert(string key, int value)
        {
            int hashIndex = getIndex(key);

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

        public void dsplay()
        {
            HashEntry temp;
            for (int i = 0; i < slot; i++)
            {
                if (bucket[i] != null)
                {
                    Console.Write("HashIndex : " + i + " ");
                    temp = bucket[i];
                    while (temp != null)
                    {
                        Console.Write("(key = " + temp.key + " , value = " + temp.value + " )");

                        temp = temp.next;
                    }
                }
            }
            Console.WriteLine("");
        }
        public void resize()
        {
            Console.WriteLine("resize");
            slot *= 2;
            HashEntry[] tempBucket = new HashEntry[slot];
            int hashIndex;
            HashEntry tmp = null;
            for (int i = 0; i < slot; i++)
                tempBucket[i] = null;
            HashEntry temp = null;
            for (int i = 0; i < slot / 2; i++)
            {
                if (bucket[i] != null)
                {

                    temp = bucket[i];
                    while (temp != null)
                    {
                        hashIndex = getIndex(temp.key);
                        if (tempBucket[hashIndex] == null)
                            tempBucket[hashIndex] = new HashEntry(temp.key, temp.value);
                        else
                        { //find next free space

                            tmp = tempBucket[hashIndex]; ;
                            while (tmp.next != null)
                            {
                                tmp = tmp.next;
                            }
                            tmp.next = new HashEntry(temp.key, temp.value);
                        }
                        temp = temp.next;
                    }
                }
            }
            bucket = null;
            bucket = tempBucket;
        }

        public int seaarch(string key)
        {
            int hashIndex = getIndex(key);
            if (bucket[hashIndex] == null)
            {
                Console.WriteLine("Value Not Found");
                return -1;
            }

            if (bucket[hashIndex].key == key)
            {
                return bucket[hashIndex].value;
            }
            else
            {
                HashEntry temp = bucket[hashIndex];

                while (temp != null)
                {
                    if (temp.key == key)
                    {
                        return temp.value;
                    }

                    temp = temp.next;
                }
            }
            Console.WriteLine("Value Not Found");
            return -1;
        }
        public void Delete(string key)
        {
            int hashIndex = getIndex(key);
            if (bucket[hashIndex] == null)
            {
                Console.WriteLine("Value To Be Deleted Not Found!");
                return;
            }
            if (bucket[hashIndex].key == key)
            {
                if (bucket[hashIndex].next != null)
                {
                    bucket[hashIndex] = bucket[hashIndex].next;

                }
                else
                {
                    bucket[hashIndex] = null;
                }
            }
            else
            { //find next free space

                HashEntry temp = bucket[hashIndex];
                HashEntry prev = bucket[hashIndex];
                while (temp != null)
                {

                    if (temp.key == key)
                    {
                        if (temp.next != null)
                        {
                            prev.next = temp.next;
                            temp = temp.next;
                        }
                        else
                            prev.next = null;

                        return;
                    }
                    prev = temp;
                    temp = temp.next;
                }
                Console.WriteLine("Value to be deleted not Found!");
            }
        }
    }
}
