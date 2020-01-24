using System;

namespace ConsoleApp4
{
    class SolutionMaxSubArray {
        public int MaxSubArray(int[] nums) {
            int n = nums.Length;
            int currSum = nums[0], maxSum = nums[0];

            for(int i = 1; i < n; ++i) {
                currSum = Math.Max(nums[i], currSum + nums[i]);
                maxSum = Math.Max(maxSum, currSum);
            }
            return maxSum;
        }
    }
}