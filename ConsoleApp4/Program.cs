// ReSharper disable UseIndexFromEndExpression

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Microsoft.VisualBasic;

namespace ConsoleApp4
{
    /**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
     * 
 */
    /*public class Solution
    {
        private int _target;
        private bool res = false;

        List<int> lost = new List<int>();

        public bool FindTarget(TreeNode root, int k)
        {
            _target = k;
            printInorder(root);

            return res;
        }

        void printInorder(TreeNode node)
        {
            if (node == null)
                return;

            /* first recur on left child #1#
            printInorder(node.left);

            /* then print the data of node #1#

            if (lost.Contains(_target - node.val))
            {
                res = true;
            }

            lost.Add(node.val);

            /* now recur on right child #1#
            printInorder(node.right);
        }

        /*public TreeNode search(TreeNode root, int key) 
        { 
            // Base Cases: root is null or key is present at root 
            if (root==null || root.val==key) 
                return root; 
  
            // val is greater than root's key 
            if (root.val > key) 
                return search(root.left, key); 
  
            // val is less than root's key 
            return search(root.right, key); 
        } #1#

        
    }*/
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;

        public TreeNode(int x)
        {
            val = x;
        }
    }


    /*
    public class Solution
    {
        public string GcdOfStrings(string a, string b)
        {
            /*if (!a.ToCharArray().Intersect(b.ToCharArray()).Any())
                return string.Empty;#1#

            return gcd(a, b);


        }

        private string gcd(string a, string b)
        {
            if (a.Length == 0)
                return b;
            
            if (a.Replace(b,"") == a && b.Replace(a,"") == b ) return "";

            var replace = b.Replace(a, "");

            Console.WriteLine(replace);

            return gcd(replace, a);
        }
    }
    */

    
    public class Solution {
        public int DietPlanPerformance(int[] calories, int k, int lower, int upper)
        {

            var ans = 0;


            for (int i = 0; i < calories.Length-k+1; i++)
            {
                
                int[] result = new int[k];
                Array.Copy(calories, i, result, 0, k);


                var sum = result.Sum();
                if (sum < lower) ans--;
                if (sum > upper) ans++;
                
            }

            
            
            
            return ans;
        }
    }
    
    /*public class Solution {
        
       
        bool areIdentical(TreeNode root1, TreeNode root2)  
        {  
  
            /* base cases #1#
            if (root1 == null && root2 == null)  
                return true;  
  
            if (root1 == null || root2 == null)  
                return false;  
  
            /* Check if the data of both roots is 
            same and data of left and right  
            subtrees are also same #1#
            return (root1.val == root2.val  
                    && areIdentical(root1.left, root2.left)  
                    && areIdentical(root1.right, root2.right));  
        }  
  
        /* This function returns true if S is  
        a subtree of T, otherwise false #1#
        bool isSubtree(TreeNode T, TreeNode S)  
        {  
            /* base cases #1#
            if (S == null)  
                return true;  
  
            if (T == null)  
                return false;  
  
            /* Check the tree with root as current node #1#
            if (areIdentical(T, S))  
                return true;  
  
            /* If the tree with root as current  
              node doesn't match then try left 
              and right subtrees one by one #1#
            return isSubtree(T.left, S)  
                   || isSubtree(T.right, S);  
        }  
        
        
        public bool IsSubtree(TreeNode s, TreeNode t)
        {

            return isSubtree(s, t);
            
        }
        
        
    }*/
    

    class Program
    {
        static void Main(string[] args)
        {
            
            var root = new TreeNode(3) {left = new TreeNode(4), right = new TreeNode(5)};
            root.left.left = new TreeNode(1);
           // root.left.right = new TreeNode(2);
            root.left.left.left = new TreeNode(0);
            
            
            var s = new TreeNode(4) {left = new TreeNode(1), right = new TreeNode(2)};
            
            /*var res = new Solution().IsSubtree(root,s);
            Console.WriteLine(res);*/
            
            var res = new Solution().DietPlanPerformance(new []{ 6,5,0,0},2,1,5);
            Console.WriteLine(res);
            //var res = new Solution().GcdOfStrings("ABCABC", "ABC");
            //var res = new Solution().GcdOfStrings("ABABAB", "ABAB");
            /*var res = new Solution().GcdOfStrings("LEET", "CODE");
            Console.WriteLine(res);*/


            /*var res = new Solution().NumEquivDominoPairs(new[]
                {new[] {1, 2}, new[] {2, 1}, new[] {3, 4}, new[] {5, 6}});*/

            /*var res = new SolutionDomino().NumEquivDominoPairs(new[]
                {new[] {1, 2},new[] {1, 2}, new[] {2, 1}, new[] {3, 4}, new[] {5, 6}});
            Console.WriteLine(res);*/
            /*var res = new MovingAverage(3);
            Console.WriteLine(res.Next(1));
            Console.WriteLine(res.Next(10));
            Console.WriteLine(res.Next(3));
            Console.WriteLine(res.Next(5));*/
            /*var res = new GCD().generalizedGCD(5,new []{2,4,6,8,10});
            Console.WriteLine(res);*/
            //var res = new Solution().cellCompete(new[] {1, 0, 0, 0, 0, 1, 0, 0}, 1);
            /*var res = new Solution().cellCompete(new[] {1, 0, 0, 0, 0, 1, 0, 0}, 1);
            Console.WriteLine(string.Join("", res));*/

            /*var root = new TreeNode(1) {left = new TreeNode(2), right = new TreeNode(3)};
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            var res = new SolutionZigzagLevelOrder().ZigzagLevelOrder(root);
            
            [26,21,11,20,50,34,1,18]
[21,11,26,20]
            res.ToList().ForEach(r => Console.WriteLine(string.Join(",",r)));*/
            // var res = new Solution().RelativeSortArray(new[] {2, 3, 1, 3, 2, 4, 6, 7, 9, 2, 19}, new int[] {2, 1, 4, 3, 9, 6});
            /*var res = new SolutionRelativeSortArray().RelativeSortArray(new[] {26, 21, 11, 20, 50, 34, 1, 18},
                new int[] {21, 11, 26, 20});

            res.ToList().ForEach(r => Console.WriteLine(r));*/


            // var res= new Solution().TwoSum(new[] {2, 7, 11, 15}, 9);
            /*var res= new Solution().TwoSum(new[] {3,2,4}, 6);
            Console.WriteLine(res);*/

            /*var res = new Solution().PrisonAfterNDays(new[] {0, 1, 0, 1, 1, 0, 0, 1}, 1000000000);
            Console.WriteLine(string.Join("", res));*/

            /*var eres = new Solution().MostCommonWord("a, a, a, a, b,b,b,c, c", new string[] {"a"});
            Console.WriteLine(eres);*/


            /*var res = new Solution().CutOffTree(new List<IList<int>>
                {new List<int> {1, 2, 3}, new List<int> {0, 0, 4}, new List<int> {7, 6, 5}});*/

            /*
            var res = new Solution().CutOffTree(new List<IList<int>>
                {new List<int> {1, 2, 3}, new List<int> {0, 0, 0}, new List<int> {7, 6, 5}});
                */

            /*var res = new Solution().OrangesRotting(new[]
                {new[] {2, 1, 1}, new[] {1, 0, 1}, new[] {0, 1, 1}});*/

            /*var res = new SolutionOrangesRottingNew().OrangesRotting(new[]
                {new[] {2, 1, 1}, new[] {1, 1, 0}, new[] {0, 1, 1}});

            Console.WriteLine(res);*/
            /*var res = new Solution().OrangesRotting(new[]
                {new[] {2, 1, 1}, new[] {0, 1, 1}, new[] {1, 0, 1}});*/

            /*var res = new SolutionGenerateMatrix().GenerateMatrix(4);
            res.ToList().ForEach(r => Console.WriteLine(string.Join(",", r)));*/
        }


        /*public class Solution
        {
            //METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
            public int[] cellCompete(int[] states, int days)
            {
               
                
                
                
                // INSERT YOUR CODE HERE
                return new int[] { };
            }
            // METHOD SIGNATURE ENDS
        }*/
    }
}