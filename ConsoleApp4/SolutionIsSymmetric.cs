public class SolutionIsSymmetric {
    public bool IsSymmetric(TreeNode root)
    {
        return IsSymmetricRec(root,root);
    }

    private bool IsSymmetricRec(TreeNode t1, TreeNode t2)
    {
        if (t1 == null && t2 == null) return true;
        if (t1 == null || t2 == null) return false;
        return (t1.val == t2.val)
               && IsSymmetricRec(t1.right, t2.left)
               && IsSymmetricRec(t1.left, t2.right);

    }
}