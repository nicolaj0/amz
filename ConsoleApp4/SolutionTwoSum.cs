using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionTwoSum
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var dict = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (!dict.ContainsKey(nums[i])) dict[nums[i]] = i;
            }


            for (int i = 0; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]) && i != dict[target - nums[i]])
                {
                    return new int[] {i, dict[target - nums[i]]};
                }
            }


            return new int[] { };
        }
    }
}