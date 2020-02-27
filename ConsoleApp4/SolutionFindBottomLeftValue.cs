using System.Collections.Generic;
using System.Linq;

public class SolutionFindBottomLeftValue {
    public int FindBottomLeftValue(TreeNode root)
    {
        
        var queue = new Queue<(TreeNode,int)>();
        var map = new Dictionary<int, LinkedList<int>>();
        
        queue.Enqueue((root,0));

        while (queue.Count > 0)
        {
            var (node, level) = queue.Dequeue();
            if (!map.ContainsKey(level)) map[level] = new LinkedList<int>();
            map[level].AddLast(node.val);

            if (node.left != null)
            {
                queue.Enqueue((node.left,level+1));
            }
            if (node.right != null)
            {
                queue.Enqueue((node.right,level+1));
            }
            
        }

        return map.OrderByDescending(k=>k.Key).FirstOrDefault().Value.First.Value;


    }

   
}