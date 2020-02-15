using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

public class SolutionMostCommonWord
{
    public string MostCommonWord(string paragraph, string[] banned)
    {
        /*return paragraph.Split(new [] {'\'','!', '?', ',', ';', '.', ' '},StringSplitOptions.RemoveEmptyEntries)
            .ToList()
            .Select(e =>e.ToLower())
            .Where(e => !banned.Contains(e))
            .GroupBy(k => k)
            .ToDictionary(r => r.Key, v => v.Count())
            .OrderBy(r => r.Value)
            .LastOrDefault()
            .Key;*/

        var dict = new Dictionary<string, int>();
        string ans = "";
        int ansFreq = 0;
        paragraph += ".";
        var word = new StringBuilder();
        foreach (var c in paragraph)
        {
            if (char.IsLetter(c))
            {
                word.Append(char.ToLower(c));
            }
            else if (word.Length > 0)
            {
                var finalword = word.ToString();
                if (!banned.Contains(finalword))
                {
                    if (dict.TryGetValue(finalword, out var counter))
                    {
                        dict[finalword] += 1;
                    }
                    else
                    {
                        dict[finalword] = 1;
                    }

                    if (dict[finalword] > ansFreq)
                    {
                        ansFreq = dict[finalword];
                        ans = finalword;
                    }
                }
                word.Clear();
            }
        }

        return ans;
    }
}

namespace ConsoleApp4
{
    public class SolutionMostCommonWord
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var rr = Regex.Replace(paragraph, @"\p{P}", " ").Split(' ').Select(p => p.ToLower().Trim());


            var dictionary = rr.Where(r => r.Length > 0).GroupBy(r => r).ToDictionary(r => r.Key, v => v.Count());

            var res = dictionary.Where(r => !banned.Contains(r.Key)).OrderByDescending(r => r.Value).First();

            return res.Key;
        }
    }
}