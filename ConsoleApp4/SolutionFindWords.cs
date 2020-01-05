using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    
    /*var res = new Solution().FindWords(
               new[]
               {
                   new char[] {'o', 'a', 'a', 'n'},
                   new char[] {'e', 't', 'a', 'e'},
                   new char[] {'i', 'h', 'k', 'r'},
                   new char[] {'i', 'f', 'l', 'v'}
               },
               new[] {"oath", "pea", "eat", "rain"});*/

    /*var res = new Solution().FindWords(
        new[]
        {
            new char[] {'a','a'}, 
           
        },
        new[] {"aaa"});*/

    /*var res = new SolutionFindWords().FindWords(
    new[]
    {
        new char[] {'a', 'b'},
        new char[] {'c', 'd'},
    },
    new[] {"ab", "cb", "ad", "bd", "ac", "ca", "da", "bc", "db", "adcb", "dabc", "abb", "acb"});

    res.ToList().ForEach(r => Console.WriteLine(r));*/
    
    public class SolutionFindWords
    {
        private Trie _root;
        private List<string> result = new List<string>();
        private string[] _words;

        public IList<string> FindWords(char[][] board, string[] words)
        {
            _words = words;
            _root = new Trie();


            foreach (var word in words)
            {
                AddWord(word);
            }


            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    var rootChild = _root.Children[board[i][j] - 'a'];
                    if (rootChild != null)
                    {
                        var l = new LinkedList<(int, int)>();
                        l.AddFirst((i, j));
                        visit(board, rootChild, _root, l);
                    }
                }
            }


            return result.OrderBy(r => r).ToList();
        }

        private void visit(char[][] board, Trie cur, Trie prev, LinkedList<(int, int)> visted)
        {
            var cell = visted.Last();
            if (cur.Word == board[cell.Item1][cell.Item2].ToString() && !cur.IsFound)
            {
                result.Add(cur.Word);
                cur.IsFound = true;
                return;
            }

            foreach (var (dx, dy) in new[] {(1, 0), (0, 1), (-1, 0), (0, -1)})
            {
                var newX = cell.Item1 + dx;
                var newY = cell.Item2 + dy;

                if (newX >= 0 && newX < board.Length && newY >= 0 && newY < board[0].Length &&
                    !visted.Contains((newX, newY)))
                {
                    var c = board[newX][newY];
                    if (cur.Children[c - 'a'] != null)
                    {
                        prev = cur;
                        cur = cur.Children[c - 'a'];
                        visted.AddLast((newX, newY));

                        if (cur.Word != null && !cur.IsFound)
                        {
                            result.Add(cur.Word);
                            cur.IsFound = true;
                        }

                        visit(board, cur, prev, visted);
                        if (visted.Count > 0)
                        {
                            visted.RemoveLast();
                            cur = prev;
                        }
                    }
                }
            }
        }

        public class Trie
        {
            public Trie[] Children = new Trie[26];
            public string Word { get; set; }
            public bool IsFound { get; set; }
        }

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
    }
}