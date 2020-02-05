using System;
using System.Collections.Generic;

public class SolutionCombinationSum
{
    private List<List<int>> _combinationSum;

    public List<List<int>> CombinationSum(int[] nums, int target)
    {
        _combinationSum = new List<List<int>>();
        //  Array.Sort(nums);
        backtrack(new LinkedList<int>(), nums, target, 0);
        return _combinationSum;
    }

    private void backtrack(LinkedList<int> tempList, int[] nums, int remain, int start)
    {
        if (remain < 0) 
            return;
        if (remain == 0) 
            _combinationSum.Add(new List<int>(tempList));
        else
        {
            for (int i = start; i < nums.Length; i++)
            {
                tempList.AddLast(nums[i]);
                backtrack(tempList, nums, remain - nums[i], i); // not i + 1 because we can reuse same elements
                tempList.RemoveLast();
            }
        }
    }
}

namespace ConsoleApp4
{
    public class SolutionCombinationSum
    {
        public List<List<int>> CombinationSum(int[] candidates, int target)
        {
            List<List<int>> res = new List<List<int>>();

            if (candidates.Length == 0) return res;

            Array.Sort(candidates);

            backtrack(res, candidates, target, new LinkedList<int>(), 0);

            return res;
        }

        private void backtrack(List<List<int>> res, int[] candidates, int remain, LinkedList<int> track, int index)
        {
            if (remain < 0) return;

            if (remain == 0)
            {
                res.Add(new List<int>(track));
                return;
            }

            for (int i = index; i < candidates.Length; i++)
            {
                // Candidates list is sorted, prune the candidates larger than remaining number
                if (candidates[i] > remain) return;

                track.AddLast(candidates[i]);
                backtrack(res, candidates, remain - candidates[i], track, i);
                track.RemoveLast();
            }
        }
    }
}