using System.Collections.Generic;

public class SolutionSingleNumber
{
    public int SingleNumber(int[] nums)
    {
        var map = new Dictionary<int, int>();


        foreach (var t in nums)
        {
            if (map.ContainsKey(t))
                map[t]++;
            else
            {
                map[t] = 1;
            }
        }

        foreach (var i in map)
        {
            if (i.Value % 2 != 0) return i.Key;
        }

        return 0;
    }
}