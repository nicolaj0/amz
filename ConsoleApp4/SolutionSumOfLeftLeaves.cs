public class SolutionSumOfLeftLeaves
{
    private int sum;

    public int SumOfLeftLeaves(TreeNode root)
    {

        Helper(root, false);
        return sum;
    }

    private void Helper(TreeNode root, bool b)
    {
        if (root == null) return ;
        if (b && root.right == null && root.left == null) sum += root.val;

        Helper(root.left, true);
        Helper(root.right, false);
        
    }
}