public class SolutionSortedArrayToBst
{
    private int[] _nums;

    public TreeNode SortedArrayToBST(int[] nums)
    {
        _nums = nums;
        return helper(0, nums.Length - 1);
    }

    public TreeNode helper(int left, int right)
    {
        if (left > right) return null;

        // always choose left middle node as a root
        int p = (left + right) / 2;

        // inorder traversal: left -> node -> right
        TreeNode root = new TreeNode(_nums[p]);
        root.left = helper(left, p - 1);
        root.right = helper(p + 1, right);
        return root;
    }

    public TreeNode sortedArrayToBST(int[] nums)
    {
        this._nums = nums;
        return helper(0, nums.Length - 1);
    }
}