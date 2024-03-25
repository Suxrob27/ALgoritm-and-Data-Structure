using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tries
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] keys = { "the", "a", "there", "answer", "any", "by", "bye", "their", "abc" };

            Trie t = new Trie();

            Console.WriteLine("Keys to insert:");
            for (int i = 0; i < 9; i++)
            {
                Console.Write(keys[i] + ", ");
            }
            Console.WriteLine("");

            // Construct trie       
            for (int i = 0; i < 9; i++)
            {
                t.insertNode(keys[i]);
                Console.WriteLine("\"" + keys[i] + "\"" + "Inserted.");
            }


            for (int i = 0; i < 9; i++)
            {
                t.searchNode(keys[i]);
            }

            return;
        }
    }
}
