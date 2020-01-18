using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
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
}