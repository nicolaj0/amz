using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

public class SolutionLastStoneWeight
{
    public int LastStoneWeightII(int[] stones)
    {
        var res =LastStoneWeightR(stones.ToList());
        return res.OrderBy(r=>r).ToList().FirstOrDefault();
    }

    private List<int> LastStoneWeightR(List<int> stones)
    {
         //Console.WriteLine(String.Join(",",stones));
        if (stones.Count== 2)
        {
            if (stones.Last() == stones.First()) 
                return new List<int>(0);
            return stones;

        }

        if (stones.Count < 2)
        {
            return stones;
        }

        var gg = stones.OrderByDescending(t => t).Take(2).ToList();
        var rest = stones.OrderByDescending(t => t).Skip(2).ToList();

        if (gg.First() != gg.Last())
        {
            var newVal = Math.Abs(gg.First() - gg.Last());
            rest.Add(newVal);
        }

        return LastStoneWeightR(rest);
    }
}