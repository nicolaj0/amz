using System;
using System.Collections.Generic;
using System.Text;

public class SolutionSpellchecker
{
    private HashSet<string> _parfect;
    private Dictionary<string, string> _wordsCap;
    private Dictionary<string, string> _wordVowels;

    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        _parfect = new HashSet<string>();
        _wordsCap = new Dictionary<string, string>();
        _wordVowels = new Dictionary<string, string>();


        foreach (var word in wordlist)
        {
            _parfect.Add(word);
            if (!_wordsCap.ContainsKey(word.ToLower()))
                _wordsCap[word.ToLower()] = word;

            if (!_wordVowels.ContainsKey(dewovel(word)))
                _wordVowels[dewovel(word)] = word;
        }

        String[] ans = new String[queries.Length];
        int t = 0;

        foreach (var s in queries)
        {
            ans[t++] = solve(s);
        }

        return ans;
    }

    private string solve(string s)
    {
        if (_parfect.Contains(s)) return s;

        if (_wordsCap.ContainsKey(s.ToLower())) return _wordsCap[s.ToLower()];

        if (_wordVowels.ContainsKey(dewovel(s))) return _wordVowels[dewovel(s)];
        return "";
    }

    private string dewovel(string word)
    {
        var sb = new StringBuilder();

        foreach (var c in word.ToCharArray())
        {
            sb.Append(isVowel(c) ? '*' : c);
        }

        return sb.ToString();
    }

    public bool isVowel(char c)
    {
        return (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u');
    }
}