using System;
using System.Collections.Generic;
using System.Linq;


public class GCD
{

    // Function to return gcd of a and b 
    static int gcd(int a, int b)
    {
        if (a == 0)
            return b;
        return gcd(b % a, a);
    }

    // Function to find gcd of  
    // array of numbers 
    public int generalizedGCD(int num, int[] arr)
    {
        int result = arr[0];
        for (int i = 1; i < num; i++)
        {
            result = gcd(arr[i], result);

            if (result == 1)
            {
                return 1;
            }
        }

        return result;
    }
}


/*
public class Solution
{
    List<List<int>> output = new List<List<int>>();
    private int _n;
    private int[] _cells;

    public int[] cellCompete(int[] states, int days)
    {
        _cells = states;
        _n = days;

        var i = 0;
        var res = _cells.ToList();
        while (i < _n)
        {
            res = prisonUtil(i, res);
            i++;
        }


        return output.ElementAt(_n - 1).ToArray();
    }

    private List<int> prisonUtil(int i, List<int> previous)
    {
        var res = new List<int>();

        for (int j = 0; j < previous.Count; j++)
        {
            res.Add(previous[j]);
        }

        for (int j = 0; j < previous.Count; j++)
        {
            var pre = j > 0 ? previous[j - 1] : 0;
            var next = j < previous.Count - 1 ? previous[j + 1] : 0;

            if (pre == 1 && next == 1 || pre == 0 && next == 0)
                res[j] = 0;
            else
            {
                res[j] = 1;
            }
        }

        output.Add(res);
        return res;
    }
}
*/


/*public class Solution
   {
       public int LengthOfLongestSubstring(String s)
       {
           int n = s.Length;
           HashSet<char> set = new HashSet<char>();
           int ans = 0, i = 0, j = 0;
           while (i < n && j < n)
           {
               // try to extend the range [i, j]
               if (!set.Contains(s[j]))
               {
                   set.Add(s[j++]);
                   ans = Math.Max(ans, j - i);
               }
               else
               {
                   set.Remove(s[i++]);
               }
           }

           return ans;
       }*/