using System.Collections.Generic;

public class SolutionBinaryTreePaths
{
    private List<string> _binaryTreePaths;

    public IList<string> BinaryTreePaths(TreeNode root)
    {
        _binaryTreePaths = new List<string>();
        helper(root, string.Empty);
        return _binaryTreePaths;
    }

    private void helper(TreeNode root, string path)
    {
        if (root == null) return;

        path += root.val.ToString();
        if (root.left == null && root.right == null)
        {
            _binaryTreePaths.Add(path);
        }
        else
        {
            path += "->";
            helper(root.left, path);
            helper(root.right, path);
        }
       
    }
}