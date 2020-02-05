using System.Collections.Generic;
using System.Linq;

public class SolutionPermute {
    private int[] _nums;
    private List<IList<int>> _res;

    public IList<IList<int>> Permute(int[] nums)
    {
        _nums = nums;
        _res = new List<IList<int>>();
        backtrack(new LinkedList<int>());
        return _res;

    }

    private void backtrack(LinkedList<int> cur)
    {
        if (cur.Count == _nums.Length)
        {
            _res.Add(cur.ToList());
        }
        else
        {
            foreach (var t1 in _nums)
            {
                var t = t1;
                if (cur.Contains(t1)) continue;
                cur.AddLast(t);
                backtrack(cur);
                cur.RemoveLast();
            }
        }
       
    }
}