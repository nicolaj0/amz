using System.Collections.Generic;
using System.Linq;

public class SolutionTopKFrequent {
    public IList<string> TopKFrequent(string[] words, int k)
    {
        return  words
            .GroupBy(r => r)
            .ToDictionary(r => r.Key, r => r.Count())
            .OrderByDescending(r => r.Value)
            .ThenBy(r => r.Key)
            .Take(k)
            .Select(r => r.Key)
            .ToList();

    }
}