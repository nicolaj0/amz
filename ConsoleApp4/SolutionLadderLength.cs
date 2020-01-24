using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionLadderLength
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            var queue = new Queue<(string, int)>();
            Dictionary<String, bool> visited = new Dictionary<string, bool>();

            var dict = new Dictionary<string, List<string>>();

            wordList.ToList().ForEach(w =>
            {
                for (int i = 0; i < w.Length; i++)
                {
                    char[] ch = w.ToCharArray();
                    ch[i] = '*';
                    var newWord = new string(ch);
                    List<string> value;
                    dict.TryGetValue(newWord, out value);
                    if (value == null) value = new List<string>();
                    value.Add(w);
                    dict[newWord] = value;
                }
            });

            queue.Enqueue((beginWord, 1));

            while (queue.Count > 0)
            {
                var curWord = queue.Dequeue();
                var curVar = new List<string>();

                for (int i = 0; i < curWord.Item1.Length; i++)
                {
                    char[] ch = curWord.Item1.ToCharArray();
                    ch[i] = '*';
                    string newstring = new string(ch);

                    dict.TryGetValue(newstring, out var value);

                    foreach (var s in value ?? new List<string>())
                    {
                        if (s == endWord) return curWord.Item2 + 1;
                        if (!visited.ContainsKey(s))
                        {
                            visited[s] = true;
                            queue.Enqueue((s, curWord.Item2 + 1));
                        }
                    }
                }
            }


            return -1;
        }
    }
}