using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    public class ArrayList
    {
        int[] arr;
        int num_elements;
        int capacity;


        public ArrayList(int size)
        {
            arr = new int[size];
            num_elements = 0;
            capacity = size;
        }
        public void insert(int val)
        {
            if (num_elements < capacity)
            {
                arr[num_elements] = val;
                num_elements++;
            }
            else
            {
                resize();
                arr[num_elements] = val;
                num_elements++;
            }
        }

        public int getAt(int index)
        {
            return arr[index];
        }

        public void resize()
        {
            int[] tempArr = new int[capacity * 2];
            capacity *= 2;

            for (int i = 0; i < num_elements; i++)
            {
                tempArr[i] = arr[i];
            }
            arr = tempArr;
        }

        public int length()
        {
            return num_elements;
        }

        public void print()
        {
            for (int i = 0; i < num_elements; i++)
                Console.Write(arr[i] + " ");
            Console.WriteLine("");
        }

    }
}
