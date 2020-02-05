using System;

public class SolutionIsBalanced
{
    public bool IsBalanced(TreeNode root)
    {
        if (root == null) return true;

        return Math.Abs(height(root.left) - height(root.right)) < 2 && IsBalanced(root.right) && IsBalanced(root.left);
    }

    private int height(TreeNode root)
    {
        // An empty tree has height -1
        if (root == null)
        {
            return -1;
        }

        return 1 + Math.Max(height(root.left), height(root.right));
    }
}