using System;

namespace ConsoleApp4
{
    public class SolutionBruteForce
    {
        public int MaxArea(int[] height)
        {
            var maxArea = 0;

            for (int i = 0; i < height.Length - 1; i++)
            {
                var currentHieght = height[i];
                var k = 0;
                bool iscontainer = false;
                while (i + k < height.Length - 1)
                {
                    k++;
                    var area = Math.Min(currentHieght, height[i + k]) * k;
                    if (area > maxArea)
                    {
                        maxArea = area;
                        Console.WriteLine(area);
                    }
                }
            }

            return maxArea;
        }
    }
}