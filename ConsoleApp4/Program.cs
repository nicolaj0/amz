﻿// ReSharper disable UseIndexFromEndExpression

using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp4
{
    /*public class Solution {
        private int _k;

        public int MergeStones(int[] stones, int K)
        {
            _k = K;
            return helper(stones);
        }

        private int helper(int[] stones)
        {
            var min = int.MaxValue;
            var start = 0;
            var curr = 0;
            for (int i = 0; i < stones.Length; i++)
            {
                curr = 0;
                for (int j = i; j < stones.Length -_k; j++)
                {
                    curr += stones[j];
                    
                }
                if (curr < min )
                {
                    min = curr;
                    start = i;
                }
            }
            var newArray = new List<int>();

            for (int i = 0; i < start; i++)
            {
                newArray.Add(stones[i]);
            }

            newArray.Add(min);
            for (int i = start+1; i < stones.Length; i++)
            {
                newArray.Add(stones[i]);
            }


            return min + helper(newArray.ToArray());
        }
    }*/


    public class MinStack
    {
        Stack<int> stack = new Stack<int>();
        Stack<int> minStack = new Stack<int>();

        int min = Int32.MaxValue;

        public MinStack()
        {
        }

        public void Push(int x)
        {
            if (x <= min)
            {
                minStack.Push(x);
                min = x;
            }

            stack.Push(x);
        }

        public void Pop()
        {
            var pop = stack.Pop();
            if (pop == min)
            {
                if (minStack.Count > 1)
                {
                    minStack.Pop();
                    min = minStack.Peek();
                }
            }
        }

        public int Top()
        {
            return stack.Peek();
        }

        public int GetMin()
        {
            return min;
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


    class Program
    {
        static void Main(string[] args)
        {
            /*var res = new Solution().MergeStones(new []{3,2,4,1},2);
            Console.WriteLine(res);*/


            //
            var res = new SolutionShortestDistance().ShortestDistance(
                new[]
                {
                    new[] {0, 0, 1, 0, 0},
                    new[] {0, 0, 0, 0, 0},
                    new[] {0, 0, 0, 1, 0},
                    new[] {1, 1, 0, 1, 1},
                    new[] {0, 0, 0, 0, 0}
                }, new[] {0, 4}, new[] {1, 2});
            Console.WriteLine(res);
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