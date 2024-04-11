using System;

public class Program
{
    static void Main()
    {
        string hello = "hhheeeeellllloooo";
        Dictionary<char, int> dict = new();
        for (int i = 0; i < hello.Length; i++)
        {
            if (dict.ContainsKey(hello[i]))
            {
                dict[hello[i]]++;  
            }
            else
            {
                dict.Add(hello[i], 1);
            }
            
        }
        foreach (var item in dict)
        {
            Console.WriteLine(item.Key + " : " +  item.Value );    
        }
    }
  }
    

    

