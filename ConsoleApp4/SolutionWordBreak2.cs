using System;
using System.Collections.Generic;

public class SolutionWordBreak2
{
    private IList<string> _wordDict;
    private string _s;

    public bool WordBreak(String s, IList<String> wordDict)
    {
        _s = s;
        
        _wordDict = wordDict;
        return word_Break(0);
    }

    public bool word_Break(int start)
    {

        Console.WriteLine(start);
        if (start == _s.Length)
        {
            return true;
        }


        for (int i = start + 1; i <= _s.Length; i++)
        {
            var substring = _s.Substring(start, i - start);
            if (_wordDict.Contains(substring) && word_Break(i))
            {
                return true;
            }
        }

        return false;
    }
}