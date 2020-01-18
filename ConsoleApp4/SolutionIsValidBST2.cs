namespace ConsoleApp4
{
    class SolutionIsValidBST2 {
        private bool helper(TreeNode node, int? lower, int? upper) {
            if (node == null) return true;

            int val = node.val;
            if (lower != null && val <= lower) return false;
            if (upper != null && val >= upper) return false;

            if (! helper(node.right, val, upper)) return false;
            if (! helper(node.left, lower, val)) return false;
            return true;
        }

        public bool IsValidBST(TreeNode root) {
            return helper(root, null, null);
        }
    }
}