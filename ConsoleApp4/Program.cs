// ReSharper disable UseIndexFromEndExpression

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Xml;
using ConsoleApp5;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleApp4
{
    public class Solution
    {
        public String LongestPalindrome(String s)
        {
            if (s == null || s.Length < 1) return "";
            int start = 0, end = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int len1 = expandAroundCenter(s, i, i);
                int len2 = expandAroundCenter(s, i, i + 1);
                int len = Math.Max(len1, len2);
                if (len > end - start)
                {
                    start = i - (len - 1) / 2;
                    end = i + len / 2;
                }
            }

            return s.Substring(start, end + 1);
        }

        private int expandAroundCenter(String s, int left, int right)
        {
            int L = left, R = right;
            while (L >= 0 && R < s.Length && s[L] == s[R])
            {
                L--;
                R++;
            }

            return R - L - 1;
        }
    }


    /*public class Solution
    {
        public int[][] KClosest(int[][] points, int K)
        {
            var dict = new Dictionary<(int, int), double>();


            foreach (var point in points)
            {
                var dist = Math.Sqrt(point[0] * point[0] + point[1] * point[1]);
                dict[(point[0], point[1])] = dist;
            }

            return dict.OrderBy(t => t.Value).Take(K).Select(g => g.Key).Select(r => new int[] {r.Item1, r.Item2})
                .ToArray();
        }
    }*/

    class Program
    {
       

      

        static void Main(string[] args)
        {
           
            /*var res = new Solution().KClosest(new []{new []{1,3}, new []{-2,-2}},1);
            Console.WriteLine(res);*/
            /*var res = new SolutionSearchTotatingArray().Search(new []{4,5,6,7,0,1,2},0);
           Console.WriteLine(res);*/
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