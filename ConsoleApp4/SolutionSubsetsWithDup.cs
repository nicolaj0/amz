using System.Collections.Generic;
using System.Linq;

public class SolutionSubsetsWithDup
{
    private HashSet<IList<int>> _res;
    private int[] _nums;

    public IList<IList<int>> SubsetsWithDup(int[] nums)
    {
        _nums = nums;
        _res = new HashSet<IList<int>>();

        backtrack(new LinkedList<int>(), 0);

        return _res.ToList();
    }

    private void backtrack(LinkedList<int> cur, int start)
    {
      
        _res.Add(cur.ToList());
        for (int i = start; i < _nums.Length; i++)
        {
            if(i > start && _nums[i] == _nums[i-1]) continue; 
            cur.AddLast(_nums[i]);
            backtrack(cur, i + 1);
            cur.RemoveLast();
        }
    }
}