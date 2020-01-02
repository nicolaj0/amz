namespace ConsoleApp4
{
    public class Solution2
    {
        public int LengthOfLongestSubstring(string s)
        {
            int max = 0;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; i + j < s.Length; j++)
                {
                    var substring = s.Substring(i, j + 1);
                    if (i + j + 1 < s.Length && !substring.Contains(s[j + i + 1]))
                        continue;
                    if (substring.Length > max) max = substring.Length;
                    break;
                }
            }

            return max;
        }
    }
}