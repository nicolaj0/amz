public class SolutionMergeTrees
{

    public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
    {

        return MergrRecurse(t1, t2);
    }

    private TreeNode MergrRecurse(TreeNode t1, TreeNode t2)
    {
        if (t1 == null && t2 == null) return null;
        if (t1 == null) return t2;
        if (t2 == null) return t1;

        var res = new TreeNode(t1.val + t2.val)
        {
            left = MergrRecurse(t1.left, t2.left),
            right = MergrRecurse(t1.right, t2.right),
        };

        return res;
    }
}