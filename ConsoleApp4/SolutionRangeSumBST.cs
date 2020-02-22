public class SolutionRangeSumBST {
    private int _l;
    private int _r;

    public int RangeSumBST(TreeNode root, int L, int R)
    {
        _r = R;
        _l = L;

        return helper(root);
    }

    private int helper(TreeNode root)
    {
        if (root == null) return 0;

        var left = helper(root.left);
        var right = helper(root.right);
        
        if (root.val > _r || root.val < _l) return left + right;
        return root.val + left + right;

    }
}