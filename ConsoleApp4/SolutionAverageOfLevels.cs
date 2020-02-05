using System.Collections.Generic;
using System.Linq;

public class SolutionAverageOfLevels
{
    public IList<double> AverageOfLevels(TreeNode root)
    {
        if (root == null) return new List<double>();
        var q = new Queue<TreeNode>();
        var levels = new List<List<int>>();
        var level = 0;

        q.Enqueue((root));

        while (q.Count > 0)
        {
            levels.Add(new List<int>());
            var levelLength = q.Count;
            for (var i = 0; i < levelLength; ++i)
            {
                var treeNode = q.Dequeue();

                levels[level].Add(treeNode.val);

                if (treeNode.left != null) q.Enqueue((treeNode.left));
                if (treeNode.right != null) q.Enqueue((treeNode.right));
            }

            level++;
        }

        return levels.Select(r => r.Average()).ToList();
    }


   
}