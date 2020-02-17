using System.Collections.Generic;
using System.Linq;

public class SolutionVerticalOrder
{
    private Dictionary<int, List<int>> _dict;

    public IList<IList<int>> VerticalOrder(TreeNode root)
    {
        _dict = new Dictionary<int, List<int>>();
        
        IList<IList<int>> res = new List<IList<int>>();

        if (root == null) return res;

        helper(root, (nbleft: 0, nbRight: 0));

        return _dict.OrderByDescending(r=>r.Key).Select(v => v.Value).ToArray();

    }

    private void helper(TreeNode root, (int nbleft, int nbRight) valueTuple)
    {
        if (root == null) return;

        var key = valueTuple.nbleft - valueTuple.nbRight;

        if (_dict.TryGetValue(key, out var current))
        {
            current.Add(root.val);
        }
        else
        {
            _dict[key] = new List<int> {root.val};
        }

        helper(root.left, (nbleft: valueTuple.nbleft + 1, valueTuple.nbRight));
        helper(root.right, (valueTuple.nbleft, nbRight: valueTuple.nbRight + 1));
    }
}