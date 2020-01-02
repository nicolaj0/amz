using System.Linq;
using System.Text.RegularExpressions;

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