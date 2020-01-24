using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionIsSubtree {
        HashSet < String > trees = new HashSet <string > ();
        public bool IsSubtree(TreeNode s, TreeNode t) {
            String tree1 = preorder(s, true);
            String tree2 = preorder(t, true);
            return tree1.IndexOf(tree2) >= 0;
        }
        public String preorder(TreeNode t, bool left) {
            if (t == null) {
                if (left)
                    return "lnull";
                else
                    return "rnull";
            }
            return "#"+t.val + " " +preorder(t.left, true)+" " +preorder(t.right, false);
        }
    }
}