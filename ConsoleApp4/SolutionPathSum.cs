using System.Collections.Generic;
using System.Linq;

public class SolutionPathSum
{
    public IList<IList<int>> PathSum(TreeNode root, int sum)
    {
        IList<IList<int>> list = new List<IList<int>>();
        PathSumR(root, sum, list, new LinkedList<int>());
        return list;
    }

    public void PathSumR(TreeNode root, int sum, IList<IList<int>> list, LinkedList<int> cur)
    {
        if (root == null)
        {
            return;
        }

        sum -= root.val;
        cur.AddLast(root.val);

        if (root.left == null && root.right == null)
        {
            if (sum == 0)
                list.Add(cur.ToList());
        }

        PathSumR(root.left, sum, list, cur);
        PathSumR(root.right, sum, list,cur);
        
        cur.RemoveLast();
        
    }
}