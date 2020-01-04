using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    /*var res = new AutocompleteSystem(new[] {"i love you", "island", "ironman", "i love leetcode"},
                new[] {5, 3, 2, 2});


            Console.WriteLine(String.Join(",", res.Input('i')));
            Console.WriteLine(String.Join(",", res.Input(' ')));
            Console.WriteLine(String.Join(",", res.Input('a')));
            Console.WriteLine(String.Join(",", res.Input('#')));


            Console.WriteLine("----------------------------");
            
            Console.WriteLine(String.Join(",", res.Input('i')));
            Console.WriteLine(String.Join(",", res.Input(' ')));
            Console.WriteLine(String.Join(",", res.Input('a')));
            Console.WriteLine(String.Join(",", res.Input('#')));

            Console.WriteLine("----------------------------");

            
            Console.WriteLine(String.Join(",", res.Input('i')));
            Console.WriteLine(String.Join(",", res.Input(' ')));
            Console.WriteLine(String.Join(",", res.Input('a')));
            Console.WriteLine(String.Join(",", res.Input('#')));*/
    
    public class AutocompleteSystem
    {
        public string CurrentSentence { get; set; } 

        public Trie Root { get; set; }

        public AutocompleteSystem(string[] sentences, int[] times)
        {
            Root = new Trie();
            CurrentSentence = string.Empty;
            for (int i = 0; i < times.Length; i++)
            {
                Trie cur = Root;
                var enumerable = sentences[i];
                var curTimes = times[i];
                insert(enumerable, cur, curTimes);
            }
        }

        private static void insert(string enumerable, Trie cur, int curTimes)
        {
            foreach (char letter in enumerable)
            {
                var index = Index(letter);

                if (cur.Children[index] == null)
                    cur.Children[index] = new Trie();
                cur = cur.Children[index];
            }

            cur.Times += curTimes;
        }

        private static int Index(char letter)
        {
            var index = letter == ' ' ? 26 : letter - 'a';
            return index;
        }

        public IList<string> Input(char c)
        {
            var index = Index(c);
            if (c == '#')
            {
                insert(CurrentSentence, Root, 1);
                CurrentSentence = string.Empty;
                return new List<string>();

            }

            CurrentSentence += c;
            var nodes = lookup(Root, CurrentSentence);

            return nodes.OrderByDescending(p => p.Times).ThenBy(p => p.Sentence).Select(r => r.Sentence)
                .Take(3).ToList();
        }


        public List<Node> lookup(Trie t, String s)
        {
            List<Node> list = new List<Node>();
            foreach (var t1 in s)
            {
                var index = Index(t1);
                if (t.Children[index] == null)
                    return new List<Node>();
                t = t.Children[index];
            }

            traverse(t, list, s);
            return list;
        }


        private void traverse(Trie t, List<Node> list, string s)
        {
            if (t.Times > 0) list.Add(new Node {Sentence = s, Times = t.Times});

            for (char i = 'a'; i <= 'z'; i++)
            {
                if (t.Children[i - 'a'] != null)
                {
                    traverse(t.Children[i - 'a'], list, s + i);
                }
            }

            if (t.Children[26] != null)
                traverse(t.Children[26], list, s + ' ');
        }

        public class Trie
        {
            public Trie[] Children = new Trie[27];
            public int Times { get; set; }
        }

        public class Node
        {
            public string Sentence { get; set; }
            public int Times { get; set; }
        }
    }
}