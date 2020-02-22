using System;
using System.Linq;

public class SolutionConstructMaximumBinaryTree
{
    private int[] _nums;

    public TreeNode ConstructMaximumBinaryTree(int[] nums)
    {
        _nums = nums;

        return helper(nums);
    }

    private TreeNode helper(int[] nums)
    {
        if (nums.Length == 0) return null;
        if (nums.Length == 1) return new TreeNode(nums[0]);

        var max = nums.Max();
        var index = Array.IndexOf(nums, max);
        TreeNode trn = new TreeNode(max);
        if (index == 0)
        {
            trn.right = helper(nums.Skip(1).ToArray());
        }
        else if (index == nums.Length)
        {
            trn.left = helper(nums.Take(nums.Length - 1).ToArray());
        }
        else
        {
            trn.left = helper(nums.Take(index).ToArray());
            trn.right = helper(nums.Skip(index+1).ToArray());
        }

        return trn;
    }
}