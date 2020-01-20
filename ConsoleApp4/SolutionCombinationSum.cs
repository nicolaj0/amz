using System;
using System.Collections.Generic;

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