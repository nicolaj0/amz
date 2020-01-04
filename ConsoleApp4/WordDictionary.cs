using System.Collections.Generic;

namespace ConsoleApp4
{
    /*var res = new WordDictionary();
            res.AddWord("bad");
            res.AddWord("dad");
            res.AddWord("mad");

            Console.WriteLine(res.Search("pad"));
            Console.WriteLine(res.Search("bad"));
            Console.WriteLine(res.Search(".ad"));
            Console.WriteLine(res.Search("b.."));
            ;*/

    public class WordDictionary
    {
        private Trie _root;

        /** Initialize your data structure here. */
        public WordDictionary()
        {
            _root = new Trie();
        }

        /** Adds a word into the data structure. */
        public void AddWord(string word)
        {
            Trie cur = _root;
            foreach (char letter in word)
            {
                var index = letter - 'a';

                if (cur.Children[index] == null)
                    cur.Children[index] = new Trie();
                cur = cur.Children[index];
            }

            cur.Word = word;
        }


        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. */
        public bool Search(string word)
        {
            var i = 0;
            var start = _root;
            var res = new List<string>();
            traverse(start, word, i, res);
            return res.Count > 0;
        }

        private void traverse(Trie t, string s, int i, List<string> res)
        {
            if (t == null) return;

            if (i == s.Length)
            {
                if (t.Word != null) res.Add(t.Word);
                return;
            }


            if (s[i] != '.')
            {
                var tChild = t.Children[s[i] - 'a'];
                traverse(tChild, s, i + 1, res);
            }
            else
            {
                foreach (var child in t.Children)
                {
                    traverse(child, s, i + 1, res);
                }
            }


            // if (t.Times > 0) list.Add(new Node {Sentence = s, Times = t.Times});
        }


        public class Trie
        {
            public Trie[] Children = new Trie[27];
            public string Word { get; set; }
        }
    }
}