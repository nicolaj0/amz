using System.Collections.Generic;

namespace ConsoleApp4
{
    public class Trie
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> children = new Dictionary<char, TrieNode>();
            public bool IsTerminal { get; set; }
        }

        public TrieNode Root { get; set; }

        public Trie()
        {
            Root = new TrieNode();
        }

        /** Inserts a word into the trie. */
        public void Insert(string word)
        {
            var cur = Root;
            foreach (var c in word)
            {
                if (!cur.children.ContainsKey(c))
                {
                    cur.children[c] = new TrieNode();
                }

                cur = cur.children[c];
            }

            cur.IsTerminal = true;
        }


        /** Returns if the word is in the trie. */
        public bool Search(string word)
        {
            var cur = Root;

            foreach (var c in word)
            {
                if (!cur.children.ContainsKey(c))
                {
                    return false;
                }

                cur = cur.children[c];
            }

            return (cur.IsTerminal);
        }

        /** Returns if there is any word in the trie that starts with the given prefix. */
        public bool StartsWith(string prefix)
        {
            var cur = Root;
            foreach (var c in prefix)
            {
                if (!cur.children.ContainsKey(c))
                {
                    return false;
                }

                cur = cur.children[c];
            }

            return true;
        }
    }
}