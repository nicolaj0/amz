using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp4
{
    public class SolutionReplaceWords
    {

        public class TrieNode
        {
            public TrieNode[] Children = new TrieNode[26];
            public string Word { get; set; }

            public override string ToString()
            {
                return $"{nameof(Word)}: {Word}";
            }
        }

        public string ReplaceWords(IList<string> dict, string sentence)
        {
            var trie = new TrieNode();

            foreach (var root in dict)
            {
                TrieNode cur = trie;
                foreach (char letter in root)
                {
                    if (cur.Children[letter - 'a'] == null)
                        cur.Children[letter - 'a'] = new TrieNode();
                    cur = cur.Children[letter - 'a'];
                }

                cur.Word = root;
            }

            StringBuilder ans = new StringBuilder();

            foreach (var word in sentence.Split(" "))
            {
                if (ans.Length > 0)
                    ans.Append(" ");

                TrieNode cur = trie;
                foreach (var letter in word.TakeWhile(letter => cur.Children[letter - 'a'] != null && cur.Word == null))
                {
                    cur = cur.Children[letter - 'a'];
                }

                ans.Append(cur.Word ?? word);
            }

            return ans.ToString();
        }
    }
}