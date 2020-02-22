using System.Collections.Generic;
using System.Linq;

public class SolutionFindMode {
    private Dictionary<int, int> _map;

    public int[] FindMode(TreeNode root)
    {
        _map = new Dictionary<int,int>();

        if (root == null) return new int[0];

        helper(root);

        var max = _map.OrderByDescending(r => r.Value).FirstOrDefault().Value;

        return _map.Where(r => r.Value == max).Select(r=>r.Key).ToArray();
    }

    private void helper(TreeNode root)
    {
        if (root == null) return;
        
        if (_map.ContainsKey(root.val))
        {
            _map[root.val]++;
            
        }
        else
        {
            _map[root.val] = 1;
            
        }

        helper(root.left);
        helper(root.right);
        
        
    }
}