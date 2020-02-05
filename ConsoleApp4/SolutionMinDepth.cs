using System;

class SolutionMinDepth {
    public int MinDepth(TreeNode root) {
        if (root == null) {
            return 0;
        }

        if ((root.left == null) && (root.right == null)) {
            return 1;
        }

        int min_depth = int.MaxValue;
        if (root.left != null) {
            min_depth = Math.Min(MinDepth(root.left), min_depth);
        }
        if (root.right != null) {
            min_depth = Math.Min(MinDepth(root.right), min_depth);
        }

        return min_depth + 1;
    }
}