using System;
using System.Collections.Generic;
using System.Linq;

public class SolutionPermute2
{
    private List<IList<int>> _permute;
    private int[] _nums;

    public IList<IList<int>> Permute(int[] nums)
    {
        Array.Sort(nums);
        _nums = nums;

        _permute = new List<IList<int>>();

        helper(0, new LinkedList<int>());


        return _permute;
    }

    private void helper(int index, LinkedList<int> linkedList)
    {
        if (linkedList.Count == _nums.Length)
        {
            _permute.Add(linkedList.ToList());
        }
        else
        {
            for (int i = 0; i < _nums.Length; i++)
            {
                if (linkedList.Contains(_nums[i])) continue;
                linkedList.AddLast(_nums[i]);
                helper(i, linkedList);
                linkedList.RemoveLast();
            }
        }
    }
}