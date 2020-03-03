using System;

public class SolutionfindDuplicate
{
    public int findDuplicate(int[] nums)
    {
        Array.Sort(nums);
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1])
            {
                return nums[i];
            }
        }

        return -1;
    }
}