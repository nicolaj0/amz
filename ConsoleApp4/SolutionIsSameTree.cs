using System.Collections.Generic;

public class SolutionIsSameTree
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        var ints = new List<int?>();
        dfs(p, ints);

        var ints2 = new List<int?>();
        dfs(q, ints2);

        return string.Join(",", ints) == string.Join(",", ints2);
    }

    private void dfs(TreeNode root, List<int?> ints)
    {
        if (root == null)
        {
            ints.Add(null);
            return; 
        };
        ints.Add(root.val);

        dfs(root.left, ints);
        dfs(root.right, ints);
    }
}