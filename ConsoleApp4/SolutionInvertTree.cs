public class SolutionInvertTree
{
    public TreeNode InvertTree(TreeNode root)
    {
        return InvertTreeRec(root);
    }

    private TreeNode InvertTreeRec(TreeNode root)
    {
        if (root == null) return null;

        var res = new TreeNode(root.val) {left = root.right, right = root.left};

        res.right = InvertTreeRec(root.left);
        res.left = InvertTreeRec(root.right);

        return res;
    }
}