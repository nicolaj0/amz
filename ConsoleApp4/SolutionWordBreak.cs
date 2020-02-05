using System.Collections.Generic;
using System.Linq;

public class SolutionWordBreak
{
    private IList<string> _wordDict;
    private List<string> _res;
    private string _word;
    private List<List<string>> _dddd;

    public IList<string> WordBreak(string s, IList<string> wordDict)
    {
        _word = s;
        _wordDict = wordDict;
        _res = new List<string>();
        _dddd = new List<List<string>>();

        backtrack( 0, new LinkedList<string>());
        return _dddd.Select(r=>string.Join((string?) " ",(IEnumerable<string?>) r)).ToList();
    }

    private void backtrack(int start, LinkedList<string> cesures)
    {
        if (start == _word.Length)
        {
            if (cesures.Count > 0) _dddd.Add(cesures.ToList());
        }

        else
        {
            var i = 0;
            while (start + i <= _word.Length)
            {
                var substring = _word.Substring(start, i);
                if (_wordDict.Contains(substring))
                {
                    cesures.AddLast(substring);
                    backtrack( start + i, cesures);
                    cesures.RemoveLast();
                }

                i++;
            }
        }
    }
}