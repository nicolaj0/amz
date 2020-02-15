using System;
using System.Collections.Generic;

public class SolutionIsSubtree
{
    public bool IsSubtree(TreeNode s, TreeNode t)
    {
        return traverse(s, t);
    }

    private bool equals(TreeNode s, TreeNode t)
    {
        if (s == null && t == null) return true;
        if (s == null || t == null) return false;
        return (s.val == t.val && equals(s.left, t.left) && equals(s.right, t.right));

    }
    public bool traverse(TreeNode s,TreeNode t)
    {
        return  s!=null && ( equals(s,t) || traverse(s.left,t) || traverse(s.right,t));
    }
    
}

namespace ConsoleApp4
{
    public class SolutionIsSubtree
    {
        HashSet<String> trees = new HashSet<string>();

        public bool IsSubtree(TreeNode s, TreeNode t)
        {
            String tree1 = preorder(s, true);
            String tree2 = preorder(t, true);
            return tree1.IndexOf(tree2) >= 0;
        }

        public String preorder(TreeNode t, bool left)
        {
            if (t == null)
            {
                if (left)
                    return "lnull";
                else
                    return "rnull";
            }

            return "#" + t.val + " " + preorder(t.left, true) + " " + preorder(t.right, false);
        }
    }
}