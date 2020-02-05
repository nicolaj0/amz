using System;

public class SolutionTrap
{
    public int Trap(int[] height)
    {
        int ans = 0;

        if (height.Length <= 1) return 0;

        for (int i = 0; i < height.Length; i++)
        {
            
            int maxLeft = 0;
            int maxRight = 0;
            for (int j = i; j > 0; j--)
            {
                maxLeft = Math.Max(maxLeft, height[j]);
            }

            for (int j = i; j < height.Length; j++)
            {
                maxRight = Math.Max(maxRight, height[j]);
            }

            var min = Math.Min(maxLeft, maxRight) - height[i];
            Console.WriteLine(min);
            ans += min;
        }


        return ans;
    }
}