using System;
using System.Collections.Generic;

public class SolutionRob
{
    public int Rob(TreeNode root) {
        return robSub(root, new Dictionary<TreeNode, int>());
    }

    private int robSub(TreeNode root,Dictionary<TreeNode, int> map)  {
        if (root == null) return 0;
        if (map.ContainsKey(root)) 
            return map[root];
    
        int val = 0;
    
        if (root.left != null) {
            val += robSub(root.left.left, map) + robSub(root.left.right, map);
        }
    
        if (root.right != null) {
            val += robSub(root.right.left, map) + robSub(root.right.right, map);
        }
    
        val = Math.Max(val + root.val, robSub(root.left, map) + robSub(root.right, map));
        map[root] = val;
    
        return val;
    }
}