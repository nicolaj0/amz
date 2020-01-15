// ReSharper disable UseIndexFromEndExpression

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Xml;
using ConsoleApp5;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleApp4
{
    
    
    
    class Solution {
        private bool helper(TreeNode node, int? lower, int? upper) {
            if (node == null) return true;

            int val = node.val;
            if (lower != null && val <= lower) return false;
            if (upper != null && val >= upper) return false;

            if (! helper(node.right, val, upper)) return false;
            if (! helper(node.left, lower, val)) return false;
            return true;
        }

        public bool IsValidBST(TreeNode root) {
            return helper(root, null, null);
        }
    }
    
    
    
    
    
    
    
    
    
    public class SolutionIsValidBST
    {
        public bool IsValidBST(TreeNode root)
        {
            try
            {
                printInorder(root, new List<TreeNode>());
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        void printInorder(TreeNode node, List<TreeNode> visited)
        {
            if (node == null)
                return;

            printInorder(node.left, visited);

            TreeNode previous = null;
            if (visited.Count > 0)
            {
                previous = visited.Last();
                if (previous != null && previous.val >= node.val)
                {
                    throw new Exception();
                }
            }

            visited.Add(node);

            printInorder(node.right, visited);
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
            var TreeNode = new TreeNode(10)
            {
                left = new TreeNode(5),

                right = new TreeNode(15)
                {
                    left = new TreeNode(6),
                    right = new TreeNode(20)
                },
            };
            
            /*var TreeNode = new TreeNode(1)
            {
                left = new TreeNode(1),

                
            };*/

            var res = new Solution().IsValidBST(TreeNode);
            Console.WriteLine(res);


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