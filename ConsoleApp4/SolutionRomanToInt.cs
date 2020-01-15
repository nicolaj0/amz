using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionRomanToInt
    {
        public int RomanToInt(string s)
        {
            var order = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000},
            };

            char current, next ;
            int total = 0;
            int i = 0;
            
            while (true)
            {
                if (i == s.Length)  break;

                current = s[i];
                if (i < s.Length - 1)
                {
                    next = s[i + 1];
                    if (order[next] > order[current])
                    {
                        total -= order[current];
                        i++;
                        continue;
                    }
                }
                total += order[current];
                i++;
            }

            return total;
        }
    }
}