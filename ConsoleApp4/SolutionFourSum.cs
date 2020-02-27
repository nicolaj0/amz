using System;
using System.Collections.Generic;
using System.Linq;

public class SolutionFourSum
{
    private int[] _nums;
    private int _target;
    private IList<IList<int>> _res;
    private List<(int, int, int, int)> _set;

    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        _target = target;
        _nums = nums;
        _res = new List<IList<int>>();
        _set = new List<(int, int, int, int)>();
        Array.Sort(nums);

        backtrack(0, new LinkedList<int>());

        return _res;
    }

    private void backtrack(int index, LinkedList<int> linkedList)
    {
        if (linkedList.Sum() == _target && linkedList.Count == 4)
        {
            _res.Add(linkedList.ToList());
        }

        else if (linkedList.Count < 4)
        {
            for (var i = index; i < _nums.Length; i++)
            {
                if(i > index && _nums[i] == _nums[i-1]) continue;
                linkedList.AddLast(_nums[i]);
                backtrack(i + 1, linkedList);
                linkedList.RemoveLast();
            }
        }
    }

    private (int, int, int, int) convert(LinkedList<int> linkedList)
    {
        var list = linkedList.ToList();
        return (list[0], list[1], list[2], list[3]);
    }
}