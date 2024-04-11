using System;

class GFG
{
   public  int maxsum(int[] arr, int n, int k)
    { 
      int max_sum = 0;   

        for (int i = 0; i < n - k +1; i++) 
        {
            int current_sum = 0;

            for (int j = 0; j < k; j++)
            {
                current_sum = current_sum + arr[i +j];
                max_sum = Math.Max(max_sum, current_sum);   

            }
        }
        return max_sum; 
    }
                  

}

class Programm
{
    // Driver code
    public static void Main()
    {
        //GFG fg = new GFG();  

        // int[] arr = { 1, 4, 2, 10, 2, 3, 1, 0, 20 };
        // int k = 1;
        // int n = arr.Length;
        // Console.WriteLine(fg.maxsum(arr, n, k));

        GFGi gi = new GFGi();   

        int[] arr = { 1, 4, 2, 10, 2, 3, 1, 0, 20 };
        int k = 4;
        int n = arr.Length;
        Console.WriteLine(gi.maxSum(arr, n, k));
    }
}