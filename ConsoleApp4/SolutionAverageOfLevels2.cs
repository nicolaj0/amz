using System.Collections.Generic;
using System.Linq;

public class SolutionAverageOfLevels2
{
    public IList<double> AverageOfLevels(TreeNode root)
    {
        var res = new List<double>();

        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var list = new List<int>();
            var queueCount = queue.Count;
            for (int i = 0; i < queueCount; i++)
            {
                var treeNode = queue.Dequeue();
                list.Add(treeNode.val);
                if (treeNode.left != null)
                    queue.Enqueue(treeNode.left);
                if (treeNode.right != null)
                    queue.Enqueue(treeNode.right);
            }

            res.Add(list.Average());
        }

        return res;
    }
}