using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    
    /* var res = new SolutionWordSquares().WordSquares(new[]
            {
                "wall",
                "ball",
                "area",
                "lead",
                "lady",
                "able"
            });*/
    
    public class SolutionWordSquares
    {
        private string[] _words;
        private int _length;
        private TrieNode trie;

        public IList<IList<string>> WordSquares(string[] words)
        {
            _words = words;

            var res = new List<IList<string>>();

            buildTrie(words);

            _length = words[0].Length;

            foreach (var word in words)
            {
                var list = new LinkedList<string>();
                list.AddLast(word);
                backtrack(1, list, res);
            }


            return res;
        }

        private void backtrack(int i, LinkedList<string> square, List<IList<string>> res)
        {
            if (square.Count == _length)
            {
                res.Add(square.ToList());
                return;
            }

            var prefix = new StringBuilder();
            foreach (var word in square)
            {
                prefix.Append(word[i]);
            }

            var sdfsd = getWordsWithPrefix(prefix.ToString());


            foreach (var word in sdfsd)
            {
                square.AddLast(_words[word]);
                backtrack(i + 1, square, res);
                square.RemoveLast();
            }
        }


        protected void buildTrie(String[] words)
        {
            trie = new TrieNode();

            for (int wordIndex = 0; wordIndex < words.Length; ++wordIndex)
            {
                String word = words[wordIndex];

                TrieNode node = trie;
                foreach (var letter in word.ToCharArray())
                {
                    if (node.children.ContainsKey(letter))
                    {
                        node = node.children[letter];
                    }
                    else
                    {
                        TrieNode newNode = new TrieNode();
                        node.children[letter] = newNode;
                        node = newNode;
                    }

                    node.wordList.Add(wordIndex);
                }
            }
        }

        protected List<int> getWordsWithPrefix(String prefix)
        {
            TrieNode node = trie;
            foreach (var letter in prefix.ToCharArray())
            {
                if (node.children.ContainsKey(letter))
                {
                    node = node.children[letter];
                }
                else
                {
                    // return an empty list.
                    return new List<int>();
                }
            }

            return node.wordList;
        }

        class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public List<int> wordList = new List<int>();
         
        }


    }
}