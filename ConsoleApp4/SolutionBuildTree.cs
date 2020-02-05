using System.Collections.Generic;

public class SolutionBuildTree
{
    private int[] _preorder;
    private int[] _inorder;
    int pre_idx = 0;
    private Dictionary<int, int> _dict;

    public TreeNode BuildTree(int[] preorder, int[] inorder)
    {
        _inorder = inorder;
        _preorder = preorder;

        _dict = new Dictionary<int, int>();

        var index = 0;

        foreach (var c in inorder)
        {
            _dict[c] = index++;
        }

        return BuildTreeR(0, inorder.Length );
    }

    private TreeNode BuildTreeR(int in_left, int in_right)
    {
        if (in_left >= in_right) return null;

        var root_val = _preorder[pre_idx];
        var root = new TreeNode(root_val);

        var idx = _dict[root_val];

        pre_idx++;

        root.left = BuildTreeR(in_left, idx);
        root.right = BuildTreeR(idx + 1, in_right);

        return root;
    }
}