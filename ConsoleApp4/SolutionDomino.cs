using System;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionDomino
    {
        public int NumEquivDominoPairs(int[][] dominoes)
        {
            foreach (var domino in dominoes)
            {
                Array.Sort(domino);
            }


            var keyValuePairs = dominoes.Select(r => (r[0], r[1]))
                .GroupBy(r => r)
                .ToDictionary(k => k.Key, v => v.Count())
                .Where(r => r.Value > 1)
                .Select(r => r.Value);

            return keyValuePairs.Aggregate(0, (i, n) => i + n * (n - 1) / 2);
        }
    }
}