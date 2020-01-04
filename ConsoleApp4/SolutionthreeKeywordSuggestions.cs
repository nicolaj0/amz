using System;
using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionthreeKeywordSuggestions
    {
        // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
        public List<List<string>> threeKeywordSuggestions(int numreviews,
            List<string> repository,
            string customerQuery)
        {
            TrieNode root = new TrieNode();
            foreach (var product in repository)
            {
                insert(product, root);
            }

            List<List<String>> result = search(customerQuery, root);
            return result;
        }


        public class TrieNode
        {
            public List<string> words;
            public Dictionary<char, TrieNode> children;

            public TrieNode()
            {
                words = new List<string>();
                this.children = new Dictionary<char, TrieNode>();
            }
        }

        public void insert(String word, TrieNode root)
        {
            TrieNode runner = root;

            foreach (var c in word.ToCharArray())
            {
                Dictionary<char, TrieNode> map = runner.children;
                if (!map.ContainsKey(c))
                {
                    TrieNode node = new TrieNode();
                    map[c] = node;
                }

                runner = map[c];
                runner.words.Add(word);
            }

        }

        public List<List<String>> search(String searchWord, TrieNode root)
        {
            List<List<String>> res = new List<List<String>>();
            TrieNode runner = root;

            foreach (var c in searchWord.ToCharArray())
            {
                Dictionary<char, TrieNode> map = runner.children;
                if (!map.ContainsKey(c))
                {
                    int lenSearch = searchWord.Length;
                    int lenList = res.Count;
                    for (int i = 0; i < lenSearch - lenList; i++)
                    {
                        res.Add(new List<String>());
                    }

                    return res;
                }

                runner = map[c];
                List<String> curr = new List<String>();
                while (runner.words.Count > 0 && curr.Count < 3)
                {
                    //curr.Add(runner.words.Dequeue());
                }

                res.Add(curr);
            }

            return res;
        }
    }
}