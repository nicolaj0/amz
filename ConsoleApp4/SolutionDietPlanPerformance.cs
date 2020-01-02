using System;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionDietPlanPerformance {
        public int DietPlanPerformance(int[] calories, int k, int lower, int upper)
        {

            var ans = 0;


            for (int i = 0; i < calories.Length-k+1; i++)
            {
                
                int[] result = new int[k];
                Array.Copy(calories, i, result, 0, k);


                var sum = result.Sum();
                if (sum < lower) ans--;
                if (sum > upper) ans++;
                
            }

            
            
            
            return ans;
        }
    }
}