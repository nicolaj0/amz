using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionDuplicate {
        public int SingleNonDuplicate(int[] s)
        {
            if (s.Length == 0) return -1;
            
            var d = new Dictionary<int, int>();
            foreach (var t in s)
            {
                if (d.ContainsKey(t)) d[t]++;
                else d[t] = 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (d[s[i]] == 1) return s[i];
            }
            return -1;
        }
    }
}