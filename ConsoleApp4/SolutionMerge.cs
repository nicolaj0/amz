using System;
using System.Collections.Generic;
using System.Linq;

public class SolutionMerge
{
    public int[][] Merge(int[][] intervals)
    {
        Array.Sort(intervals, (ints, ints1) => ints[0].CompareTo(ints1[0]));

        var res = new List<int[]>();

        intervals.Aggregate(res, (accumulmatedList, currentInterval) =>
        {
            if (accumulmatedList.Count > 0)
            {
                var lastInterval = accumulmatedList.Last();
                if (currentInterval[0] <= lastInterval[1] && currentInterval[1] >= lastInterval[1])
                {
                    lastInterval[1] = currentInterval[1];
                    
                }
                else if (currentInterval[0] > lastInterval[1])
                {
                    accumulmatedList.Add(currentInterval);
                }
                
            }
            else
            {
                accumulmatedList.Add(currentInterval);
            }

            return accumulmatedList;
        });

        return res.ToArray();
    }
}