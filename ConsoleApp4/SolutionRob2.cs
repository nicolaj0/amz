using System;

public class SolutionRob2
{
    private int[] _nums;

    public int rob(int[] num)
    {
        int prevMax = 0;
        int currMax = 0;
        foreach (var x in num)
        {
            int temp = currMax;
            currMax = Math.Max(prevMax + x, currMax);
            prevMax = temp;
        }

        return currMax;
    }
}