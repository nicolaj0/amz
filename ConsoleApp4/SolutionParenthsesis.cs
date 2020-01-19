using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionParenthsesis
    {
        private int _length;

        private IList<string> res = new List<string>();
        private List<char> _par;

        public IList<string> GenerateParenthesis(int n)
        {
            _length = n;

            _par = new List<char> {'(', ')'};

            backtrack(0, new LinkedList<char>());
            return res;
        }


        private void backtrack(int level, LinkedList<char> curr)
        {
            if (curr.Count == 2 * _length)
            {
                var item = string.Join("", curr);
                res.Add(item);
                Console.WriteLine(item);
                return;
            }

            foreach (var p in _par)
            {
                var opended = curr.Count(c => c == '(');
                var closed = curr.Count(c => c == ')');
                var cc = level == _length*2 - 1 && p == '(';
                if (opended <= _length && closed <= opended && !cc)
                {
                    curr.AddLast(p);
                    backtrack(level + 1, curr);
                    curr.RemoveLast();
                }
            }
        }
    }
}