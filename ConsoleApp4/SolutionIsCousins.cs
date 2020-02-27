using System.Collections.Generic;

class SolutionIsCousins {
    Dictionary<int, int> depth;
    Dictionary<int, TreeNode> parent;

    public bool IsCousins(TreeNode root, int x, int y) {
        depth = new Dictionary<int, int>();
        parent = new Dictionary<int, TreeNode>();
        dfs(root, null);
        return (depth[x] == depth[y] && parent[x] != parent[y]);
    }

    public void dfs(TreeNode node, TreeNode par) {
        if (node != null) {
            depth.Add(node.val, par != null ? 1 + depth[par.val] : 0);
            parent.Add(node.val, par);
            dfs(node.left, node);
            dfs(node.right, node);
           
        }
    }
}