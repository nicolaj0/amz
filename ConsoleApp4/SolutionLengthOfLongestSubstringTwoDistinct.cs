using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionLengthOfLongestSubstringTwoDistinct
    {
        public int LengthOfLongestSubstringTwoDistinct(string s)
        {
            int right = 0;
            int left = 0;
            var map = new Dictionary<char,int>();
            int max_len = 0;

            if (s.Length < 3) return 2;
            
            while (right < s.Length)
            {
                if (map.Keys.Count <= 2)
                {
                    map[s[right]] = right++;
                }
                
                if (map.Keys.Count == 3)
                {
                    int del_idx = map.Values.Min();
                    map.Remove(s[del_idx]);
                    left = del_idx + 1;

                }

                max_len = Math.Max(max_len, right - left);
            }

            return max_len;
        }

       

        
    }
}