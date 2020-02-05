using System.Collections.Generic;
using System.Linq;

public class SolutionRightSideView {

    public IList<int> RightSideView(TreeNode root)
    {
        var queue = new Queue<(TreeNode, int)>();
        var  res = new List<int>();
        var map = new Dictionary<int, LinkedList<int>>();

        if (root == null) return new List<int>();
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

        map.Values.ToList().ForEach(v => { res.Add(v.Last.Value); });
  
        return res;
    }

   
}