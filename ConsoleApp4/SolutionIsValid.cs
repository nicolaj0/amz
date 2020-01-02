using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionIsValid
    {
        public bool IsValid(string s)
        {
            var stack = new Stack<char>();
            var dict = new Dictionary<char, char> {{'{', '}'}, {'[', ']'}, {'(', ')'}};
            foreach (var chr in s)
            {
                if (dict.Keys.Contains(chr))
                {
                    stack.Push(chr);
                }
                else
                {
                    if (stack.Count == 0) return false;
                    var pop = stack.Pop();
                    if (chr != dict[pop])
                    {
                        return false;
                    }
                }
            }

            return stack.Count == 0;
        }

            
    }
}