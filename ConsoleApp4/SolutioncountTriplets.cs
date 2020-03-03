using System;
using System.Collections.Generic;
using System.Linq;

class SolutioncountTriplets
{
    private static List<long> _arr;
    private static long res;
    private static long _r;

    // Complete the countTriplets function below.
    public static long countTriplets(List<long> arr, long r)
    {
        _r = r;
        _arr = arr;
        // var memo = new Dictionary<>>();
        var m = new Dictionary<long, List<long>>();


        for (int i = 0; i < arr.Count; ++i)
        {
            if (!m.ContainsKey(arr[i]))
            {
                m[arr[i]] = new List<long>();
            }

            m[arr[i]].Add(i);
        }
        long c=0,x;
        var n = arr.Count;
        for (int i = 1; i < n-1; i++)
        {
            if (arr[i]%r != 0) continue;


            var enumerable = arr.Take(i -1).ToList();
            Console.WriteLine(enumerable.Count);
            long less = enumerable.Where(f => f % r == 0).SelectMany(index => m[index]).Count();
            long high = arr.Skip(i+1).Where(f => f % r == 0).SelectMany(index => m[index]).Count();


            c += less * high;
            
        }

        return c;
    }

    /*private static void helper(int index, LinkedList<int> linkedList)
    {
        if (linkedList.Count == 3)
        {
            var longs = linkedList.ToList();
            var l = _arr[longs[2]] / _arr[longs[1]];
            if (l != _r) return;
            
            var d = _arr[longs[1]] / _arr[longs[0]];
            if (l == d )
            {
                res++;
                Console.WriteLine(string.Join(",", longs));
                
                
            }
        }
        else
        {
            for (int i = index; i < _arr.Count; i++)
            {

                if (linkedList.Count==0 || linkedList.Count>0 && _arr[i] / _arr[linkedList.Last.Value] == _r)
                {
                    linkedList.AddLast(i);
                    helper(i + 1, linkedList);
                    linkedList.RemoveLast();
                }
                
            }
        }
    }*/
}