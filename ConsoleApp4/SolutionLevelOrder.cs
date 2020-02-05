using System.Collections.Generic;
using System.Linq;

public class SolutionLevelOrder
{
    public IList<IList<int>> LevelOrder(TreeNode root)
    {
        
        
        var queue = new Queue<(TreeNode, int)>();
        IList<IList<int>> res = new List<IList<int>>();
        var map = new Dictionary<int, LinkedList<int>>();

        if (root == null) return res;
        queue.Enqueue((root, 0));

        while (queue.Count > 0)
        {
            var cur = queue.Dequeue();

            if (!map.ContainsKey(cur.Item2)) map[cur.Item2] = new LinkedList<int>();
            map[cur.Item2].AddLast(cur.Item1.val);

            if (cur.Item1.left != null)
                queue.Enqueue((cur.Item1.left, cur.Item2 + 1));
            if (cur.Item1.right != null)
                queue.Enqueue((cur.Item1.right, cur.Item2 + 1));
        }

        map.Values.ToList().ForEach(v => { res.Add(v.ToList()); });

        return res;
    }
}

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
                printGivenLevel(root, f, i);
                levelOrder.Add(f.Select(r => r.val).ToList());
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
                printGivenLevel(root.left, nodes, level - 1);
                printGivenLevel(root.right, nodes, level - 1);
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