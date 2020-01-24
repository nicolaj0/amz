namespace ConsoleApp4
{
    class SolutionSufficientSubset {
        public TreeNode SufficientSubset(TreeNode root, int limit) {
            return dfs(root, limit, 0);
        }
    
        private TreeNode dfs(TreeNode root, int limit, int sum) {
            if (root == null)
                return null;
            sum += root.val;
            if (root.left == null && root.right == null)
                return sum >= limit ? root : null;
            root.left = dfs(root.left, limit, sum);
            root.right = dfs(root.right, limit, sum);

            return root.left == null && root.right == null ? null : root;
        }
    }
}