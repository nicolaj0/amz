using System.Collections.Generic;

public class SolutionFindTarget
{
    private int _target;
    private List<int> _list = new List<int>();

    public bool FindTarget(TreeNode root, int k)
    {
        _target = k;
        return helper(root, new List<int>());
    }

    private bool helper(TreeNode root, List<int> list)
    {
        if (root == null) return false;

        if (list.Contains(_target - root.val))
            return true;

        list.Add(root.val);
        return helper(root.left, list) ||
               helper(root.right, list);
    }
}