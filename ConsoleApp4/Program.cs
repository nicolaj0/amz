// ReSharper disable UseIndexFromEndExpression

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.VisualBasic;

namespace ConsoleApp4
{
    class Program
    {
        public class Solution1_1
        {
            // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
            public List<List<string>> threeKeywordSuggestions(int numreviews,
                List<string> repository,
                string customerQuery)
            {
                var result = new List<List<string>>();

                if (customerQuery == null) return result;

                var substringLength = 2;

                repository = repository.Select(r => r.ToLowerInvariant()).ToList();

                for (int i = 0; i < customerQuery.Length - 1; i++)
                {
                    var stringToCheck = customerQuery.Substring(0, substringLength++).ToLowerInvariant();

                    var matchesInRepo = repository.Where(r => r.StartsWith(stringToCheck))
                        .OrderBy(r => r).Take(3);

                    result.Add(matchesInRepo.ToList());
                }

                return result;
            }
        }

        public class Solution2
        {
            private readonly Queue<(int, int)> _queue;
            private readonly Dictionary<(int, int), int> _depth;

            public Solution2()
            {
                _queue = new Queue<(int, int)>();
                _depth = new Dictionary<(int, int), int>();
            }

            public int minimumHours(int rows, int columns, int[,] grid)
            {
                var nbHours = 0;

                InitalizeSources(rows, columns, grid);

                if (_queue.Count == 0) return -1;

                nbHours = ExpandFileStatuses(rows, columns, grid, nbHours);

                return nbHours;
            }

            private int ExpandFileStatuses(int rows, int columns, int[,] grid, int nbHours)
            {
                var adjacentCellsHelper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};
                while (_queue.Count > 0)
                {
                    int x, y;
                    var currentCell = _queue.Dequeue();
                    x = currentCell.Item1;
                    y = currentCell.Item2;

                    foreach (var direction in adjacentCellsHelper)
                    {
                        var dx = direction.Item1;
                        var dy = direction.Item2;
                        var isAdjacentCell = dx + x >= 0 && dx + x < rows && dy + y >= 0 && dy + y < columns;
                        if (isAdjacentCell)
                        {
                            var adjacentCellNotVisited = grid[x + dx, y + dy] == 0;

                            if (adjacentCellNotVisited)
                            {
                                grid[x + dx, y + dy] = 1;
                                _queue.Enqueue((x + dx, y + dy));
                                _depth[(x + dx, y + dy)] = _depth[(x, y)] + 1;
                                nbHours = _depth[(x + dx, y + dy)];
                            }
                        }
                    }
                }

                return nbHours;
            }

            private void InitalizeSources(int rows, int columns, int[,] grid)
            {
                for (var i = 0; i < rows; i++)
                {
                    for (var j = 0; j < columns; j++)
                    {
                        if (grid[i, j] == 1)
                        {
                            _queue.Enqueue((i, j));
                            _depth[(i, j)] = 0;
                        }
                    }
                }
            }
        }


        public class Solution
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


        static void Main(string[] args)
        {
            /*var res = new Solution().minimumHours(4, 5,
                new int[,] {{0, 1, 1, 0, 1}, {0, 1, 0, 1, 0}, {0, 0, 0, 0, 1}, {0, 1, 0, 0, 0}});*/

            /*var res = new Solution().minimumHours(4, 5,
                new int[,] {{0, 1, 1, 0, 1}, {0, 1, 0, 1, 0}, {0, 0, 0, 0, 1}, {0, 1, 0, 0, 0}});


            Console.WriteLine(res);*/

           var res = new Solution().threeKeywordSuggestions(3, 
                new List<string>(){"bags","baggage","banner","box","clothes","baba"}, "bags");

            res.ForEach(r => Console.WriteLine(string.Join(" ", r)));
        }
    }
}