using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionLevelOrder
    {
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            var levelOrder = new List<IList<int>>();
            int h = height(root);
            int i;
            var f = new List<TreeNode>();
            for (i = 1; i <= h; i++)
            {
                printGivenLevel(root, f,i);
                levelOrder.Add(f.Select(r=>r.val).ToList());
                f.Clear();
            }

            return levelOrder;
        }


        public virtual void printGivenLevel(TreeNode root,
            List<TreeNode> nodes,
            
            int level)
        {
            if (root == null)
            {
                return;
            }

            if (level == 1)
            {
                nodes.Add(root);
            }
            else if (level > 1)
            {
                printGivenLevel(root.left, nodes,level - 1);
                printGivenLevel(root.right, nodes,level - 1);
            }
        }


        public virtual int height(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            /* compute height of each subtree */
            int lheight = height(root.left);
            int rheight = height(root.right);

            /* use the larger one */
            if (lheight > rheight)
            {
                return (lheight + 1);
            }

            return (rheight + 1);
        }
    }
}