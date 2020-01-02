using System;

namespace ConsoleApp4
{
    public class SolutionMaxDepth
    {
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            var maxDepth =  MaxDepth(root.left) ;
            var depth =  MaxDepth(root.right) ;
            return Math.Max(maxDepth, depth) + 1;
        }
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }
    }
}