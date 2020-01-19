using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionLetterCombinations
    {
        private int n;
        private List<char> _chars;
        private IList<string> _output;
        private Dictionary<char, List<char>> _refe;

        public IList<string> LetterCombinations(string digits)
        {
            _refe = new Dictionary<char, List<char>>();

            _refe['2'] = new List<char>() {'a', 'b', 'c'};
            _refe['3'] = new List<char>() {'d', 'e', 'f'};
            _refe['4'] = new List<char>() {'g', 'h', 'i'};
            _refe['5'] = new List<char>() {'j', 'k', 'l'};
            _refe['6'] = new List<char>() {'m', 'n', 'o'};
            _refe['7'] = new List<char>() {'p', 'q', 'r', 's'};
            _refe['8'] = new List<char>() {'t', 'u', 'v'};
            _refe['9'] = new List<char>() {'w', 'w', 'x', 'y', 'z'};

            _output = new List<string>();
            n = digits.Length;
            _chars = digits.ToCharArray().ToList();

            if (string.IsNullOrEmpty(digits)) return new List<string>();

            backtrack(0, new LinkedList<char>());

            return _output;
        }

        public void backtrack(int first, LinkedList<char> curr)
        {
            if (curr.Count == n)
            {
                var @join = string.Join("", curr.ToList());
                _output.Add(@join);
            }

            for (int i = first; i < n; i++)
            {
                foreach (var c in _refe[_chars[first]])
                {
                    curr.AddLast(c);
                    // use next integers to complete the combination
                    backtrack(i + 1, curr);
                    // backtrack
                    curr.RemoveLast();
                }
            }
        }
    }
}