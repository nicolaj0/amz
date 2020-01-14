using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionFirstUniqChar {
        public int FirstUniqChar(string s)
        {
            if (s.Length == 0) return -1;
            
            var d = new Dictionary<char, int>();
            foreach (var t in s)
            {
                if (d.ContainsKey(t)) d[t]++;
                else d[t] = 1;
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (d[s[i]] == 1) return i;
            }
            return -1;
        }
    }
}