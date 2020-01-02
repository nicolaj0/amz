using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionPartitionLabels
    {
        public IList<int> PartitionLabels(string s)
        {
            var dict = s.ToCharArray().GroupBy(p => p).ToDictionary(r => r.Key, v => v.Count());

            int n = s.Length;
            List<string> set = new List<string>();
            var currentSet = new HashSet<char>();
            int ans = 0, i = 0, j = 0;
            while (i < n && j < n)
            {
                // try to extend the range [i, j]
                currentSet.Add(s[j]);
                    
                dict[s[j]]--;
                var stop = currentSet.ToList().All(r=> dict[r]==0);
                    
                if (stop)
                {
                    set.Add(s.Substring(i, j - i+1));
                    i=j+1;
                    currentSet.Clear();
                }
                j++;
            }

            return set.Select(r => r.Length).ToList();
        }
    }
}