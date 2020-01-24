// ReSharper disable UseIndexFromEndExpression

using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
   
    
   
    
    
    
    
    
    
    
    
    
    /*public class Solution
    {
        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {
            _wordList = wordList;
            _root = new Trie();

            foreach (var word in wordList)
            {
                AddWord(word);
            }
            
            
            var queue = new Queue<string>();
            
            queue.Enqueue(beginWord);
            queue.Enqueue(null);


            while (queue.Count > 0)
            {

                var curr = queue.Dequeue();
                
                if (curr == null)
                {
                    depth++;
                    if (queue.Peek() != null)
                        queue.Enqueue(null);
                }

                else if (curr == endWord)
                {
                    return depth;
                }

                else
                {
                    for (int i = 0; i < beginWord.Length; i++)
                    {
                        char[] ch = curr.ToCharArray();
                        ch[i] = '.'; // index starts at 0!
                        string newstring = new string (ch);
                        Search(newstring).ForEach(e=>queue.Enqueue(e));
                    }
                }
                
            }
            
            
            
            return -1;
        }


        private Trie _root;
        private IList<string> _wordList;
        private int depth;


        /** Adds a word into the data structure. #1#
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


        /** Returns if the word is in the data structure. A word could contain the dot character '.' to represent any one letter. #1#
        public List<string> Search(string word)
        {
            var i = 0;
            var start = _root;
            var res = new List<string>();
            traverse(start, word, i, res);
            return res;
        }

        private void traverse(Trie t, string s, int i, List<string> res)
        {
            if (t == null) return;

            if (i == s.Length)
            {
                if (t.Word != null) res.Add(t.Word);
                return;
            }

            foreach (var child in t.Children)
            {
                traverse(child, s, i + 1, res);
            }
        }

        public class Trie
        {
            public Trie[] Children = new Trie[27];
            public string Word { get; set; }
        }
    }*/


    /*
    public class Solution
    {
        private int _n;
        private int _k;
        private List<int[]> _intses;

        public int KthGrammar(int N, int K)
        {
            _k = K;
            _n = N;
            _intses = new List<int[]>();

            return KthGrammarR(0, K, "0");

        }

        private int KthGrammarR(int n, int k, string previous)
        {
            if (n == _n-1)
            {
                return int.Parse(previous[k-1].ToString());
            }

            var v = new StringBuilder();
            for (int i = 0; i < previous.Length; i++)
            {
                if (previous[i] == '0') v.Append("01");
                if (previous[i] == '1') v.Append("10");
            }

            return KthGrammarR(n + 1, k, v.ToString());
        }
    }
    */

    /*public class Solution
    {
        private int _limit;
        private HashSet<TreeNode> _nodesToKeep;

        public TreeNode SufficientSubset(TreeNode root, int limit)
        {
            _limit = limit;
            _nodesToKeep = new HashSet<TreeNode>();
            SufficientSubsetR(root, 0, new LinkedList<TreeNode>());


            RemoveNodeR(root);


            return root;
        }

        private void RemoveNodeR(TreeNode root)
        {
            if (root==null) return;

            if (_nodesToKeep.Contains(root))
            {
                RemoveNodeR(root.left);
                RemoveNodeR(root.right);
            }

            else
            {
                root.left = null;
                root.right = null;
            }

        }

        private void SufficientSubsetR(TreeNode node, int sum, LinkedList<TreeNode> treeNodes)
        {
            if (node == null)
            {
                return;
            }

            sum += node.val;
            treeNodes.AddLast(node);
            /* first recur on left child #1#
            SufficientSubsetR(node.left, sum, treeNodes);

            
            /* then print the data of node #1#
            if (node.right == null && node.left == null)
            {
               
                if (sum >= _limit)
                {
                    treeNodes.ToList().ForEach(r=>_nodesToKeep.Add(r));
                }
            }
           
          

            /* now recur on right child #1#
            SufficientSubsetR(node.right, sum , treeNodes);
            
            treeNodes.RemoveLast();

           
        }
    }*/

    public class SolutionInorderTraversal
    {
        public IList<int> InorderTraversal(TreeNode root)
        {
            var treeNodes = new List<TreeNode>();
            InorderTraversalR(root, treeNodes);
            return treeNodes.Select(r => r.val).ToList();
        }

        private void InorderTraversalR(TreeNode root, List<TreeNode> treeNodes)
        {
            if (root == null) return;
            InorderTraversalR(root.left, treeNodes);
            treeNodes.Add(root);
            InorderTraversalR(root.right, treeNodes);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var treeNode = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4), 
                    right = new TreeNode(5)
                    {
                        left = new TreeNode(7), 
                        right = new TreeNode(8)
                    }
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6)
                    {
                        left = new TreeNode(9), 
                        right = new TreeNode(10)
                    }, 
                }
            };
            
            /*var res = new Solution().BoundaryOfBinaryTree(treeNode);
            Console.WriteLine(res);*/
            /* var treeNode2 = new TreeNode(4)
             {
                 left = new TreeNode(1),
                 right = new TreeNode(2)
             };*/

            /*var treeNode2 = new TreeNode(4)
            {
               left = new TreeNode(1){left = new TreeNode(1)},
               right = new TreeNode(1)
            };*/

            //var res = new SolutionIsSubtree().IsSubtree(treeNode, treeNode2);

            /*var res = new SolutionLadderLength().LadderLength("hit", "cog",
                new List<string>() {"hot", "dot", "dog", "lot", "log", "cog"});

            Console.WriteLine(res);*/
            /*
            var res = new SolutionInorderTraversalIrteration().InorderTraversalIrteration(new TreeNode(1)
            {
                left = new TreeNode(2) {left = new TreeNode(4), right = new TreeNode(5)},
                right = new TreeNode(3) {left = new TreeNode(6)}
            });
            */

/*
          Console.WriteLine(res);*/
            /*
            var res = new Solution().FloodFill(  new[]
            {
                new[] {1, 1, 1},
                new[] {1, 1, 0},
                new[] {1, 0, 1},
               
            },1,1,2);
            */

            /*var res = new Solution().KthGrammar(4, 5);
            Console.WriteLine(res);*/
            /*var res = new SolutionSufficientSubset().SufficientSubset(new TreeNode(1)
            {
                left = new TreeNode(2) {left = new TreeNode(-5)},
                right = new TreeNode(-3) {left = new TreeNode(4)}
            }, -1);


            Console.WriteLine(res);*/
            /*
            var res = new Solution().FloodFill(  new[]
            {
                new[] {1, 1, 1},
                new[] {1, 1, 0},
                new[] {1, 0, 1},
               
            },1,1,2);
            */

            /*var res = new SolutionFloodFill().FloodFill(  new[]
            {
                new[] {0,0,0},
                new[] {0,1,1},
               
            },1,1,1);
            Console.WriteLine(res);*/
            //var res = new SolutionMaxSubArray().MaxSubArray(new []{-2,1,-3,4,-1,2,1,-5,4});
            //var res = new Solution().MaxSubArray(new []{-1,0,-2});
            //var res = new Solution().MaxSubArray(new []{-2,1});
            /*var res = new SolutionHasCycle().HasCycle(new ListNode(1) {next = new ListNode(2)});
            Console.WriteLine(res);*/
            /*var res = new Solution().LengthOfLongestSubstringTwoDistinct("bacc");
            Console.WriteLine(res);
            */


            /*var head = new SolutionCopyRandomList.Node(1);
            var a = new SolutionCopyRandomList.Node(2);
            var b = new SolutionCopyRandomList.Node(3);
            var c = new SolutionCopyRandomList.Node(4);
            var d = new SolutionCopyRandomList.Node(5);

            head.next = a;
            head.random = b;

            a.next = c;
            a.random = head;

            var res = new SolutionCopyRandomList().CopyRandomList(null);

            Console.WriteLine(res);*/

            // var res = new Solution().CombinationSum(new []{2},7);
            /*var res = new SolutionCombinationSum().CombinationSum(new[] {2, 3, 6, 7, 8}, 7);*/
            //var res = new Solution().CombinationSum(new []{2,3,5},8);
            // var res = new Solution().CombinationSum(new []{1},1);


            /*var res = new SolutionIntToRoman().IntToRoman(10);
            Console.WriteLine(res);*/
            // var res = new SolutionDecodeVariations().Decode("99999999999999999999999999991262326568131354613132135199999999999999999999999999999");
            /*var res = new SolutionGenerateParentheses().generateParenthesis(3);
            Console.WriteLine(res);*/

            /*var res = new SolutionLetterCombinations().LetterCombinations("23");

            Console.WriteLine(res);*/
            /*var res = new SolutionBruteForce().MaxArea(new[] {1, 8, 6, 2, 5, 4, 8, 3, 7});
            Console.WriteLine(res);*/
            /*
            var res = new Solution().MergeStones(new []{3,2,4,1},2);
            Console.WriteLine(res);
            */


            //
            /*var res = new SolutionShortestDistance().ShortestDistance(
                new[]
                {
                    new[] {0, 0, 1, 0, 0},
                    new[] {0, 0, 0, 0, 0},
                    new[] {0, 0, 0, 1, 0},
                    new[] {1, 1, 0, 1, 1},
                    new[] {0, 0, 0, 0, 0}
                }, new[] {0, 4}, new[] {1, 2});*/
            // Console.WriteLine(res);
            /*MinStack minStack = new MinStack();
            minStack.Push(2);
            minStack.Push(0);
            minStack.Push(3);
            minStack.Push(0);
            minStack.GetMin();
            minStack.Pop();
            minStack.GetMin();
            minStack.Pop();
            minStack.GetMin();
            minStack.Pop();
            minStack.GetMin();*/

            //  var res = new Solution().GroupAnagrams(new []{"eat", "tea", "tan", "ate", "nat", "bat"});


            /*var res = new SolutionStr2Tree().Str2Tree("4(2(3)(1))(6(5))");
    
            Console.WriteLine(res);*/
            // var res = new Solution().ThreeSum(new []{-1, 0, 1, 2, -1, -4});
            //var res = new SolutionThreeSum().ThreeSum(new[] {0, 0, 0, 0});

            /*
            var res = new SolutionReverse().Reverse(123);
            Console.WriteLine(res);
    
    
            var TreeNode = new TreeNode(10)
            {
                left = new TreeNode(5),
    
                right = new TreeNode(15)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(20)
                }
            };*/

            /*var TreeNode = new TreeNode(1)
            {
                left = new TreeNode(1),
    
                
            };*/

            /*var res = new Solution().IsValidBST(TreeNode);
            Console.WriteLine(res);*/


            // var res = new Solution().RomanToInt("MCMXCIV");
            /*var res = new SolutionRomanToInt().RomanToInt("MCMXCIV");
            Console.WriteLine(res);*/


            /*var res = new Solution().ReverseList(new ListNode(1) {next = new ListNode(1) {next = new ListNode(3)}});*/

            // var res = new SolutionFirstUniqChar().FirstUniqChar("cc");
            /*var TreeNode = new TreeNode(1)
            {
                left = new TreeNode(2)
                {
                    left = new TreeNode(4),
                    right = new TreeNode(5)
                },
                right = new TreeNode(3)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(7)
                },
            };*/

            // var res = new Solution().LevelOrder(TreeNode);

            // var res = new SolutionConnectDfs().Connect(node);*/
            //Console.WriteLine(res);

            /*var res = new Solution().KClosest(new []{new []{1,3}, new []{-2,-2}},1);
            Console.WriteLine(res);*/
            //var res = new SolutionSearchTotatingArray().Search(new []{4,5,6,7,8,0,1,2},3);
            // var res = new SolutionSearchTotatingArray().Search(new int[]{5,1,3,},1);
            // Console.WriteLine(res);
            /*var res= new SolutionSqrt().MySqrt(2147395599);
            Console.WriteLine(res);*/
            /*var res = new SolutionBinarySearch().Search(new []{-1,0,3,5,9,12},9);
            Console.WriteLine(res);*/
            /*var res = new Solution().ReplaceWords(new List<string>{"cat", "bat", "rat"}, "the cattle was rattled by the battery");
            Console.WriteLine(res);*/
            /*var ms = new MapSum();
            ms.Insert("apple", 3);
            var sum = ms.Sum("apple");
            ms.Insert("app", 2);
            sum = ms.Sum("ap");
    
            Console.WriteLine(sum);*/
            /*/*Trie trie = new Trie();
    
            trie.Insert("apple");
            trie.Search("apple"); // returns true
            trie.Search("app"); // returns false
            trie.StartsWith("app"); // returns true
            trie.Insert("app");
            trie.Search("app"); // returns true
            #1#
    
            var ms = new MapSum();
            ms.Insert("apple", 3);
            var sum = ms.Sum("apple");
            ms.Insert("app", 2);
            sum = ms.Sum("ap");*/

            /*ms.Insert("a", 3);
            var sum = ms.Sum("ap");
            ms.Insert("app", 2);
            sum= ms.Sum("ap");*/


            /*var res = new Solution().minimumHours(4, 5,
                new int[,] {{0, 1, 1, 0, 1}, {0, 1, 0, 1, 0}, {0, 0, 0, 0, 1}, {0, 1, 0, 0, 0}});*/

            /*var res = new Solution().minimumHours(4, 5,
                new int[,] {{0, 1, 1, 0, 1}, {0, 1, 0, 1, 0}, {0, 0, 0, 0, 1}, {0, 1, 0, 0, 0}});
    
    
            Console.WriteLine(res);*/

            /*var res = new Solution().threeKeywordSuggestions(3, 
                 new List<string>(){"bags","baggage","banner","box","clothes","baba"}, "bags");
    
             res.ForEach(r => Console.WriteLine(string.Join(" ", r)));*/
        }
    }
}


public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int x)

    {
        val = x;
    }

    public override string ToString()
    {
        return $"{nameof(val)}: {val}";
    }
}

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int x)
    {
        val = x;
    }

    public override string ToString()
    {
        return $"{nameof(val)}: {val}";
    }
}