using System.Collections.Generic;

public class SolutionIsCousinsBfs
{
    public bool IsCousins(TreeNode root, int x, int y)
    {
        var queue = new Queue<TreeNode>();

        if (root == null) return false;

        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var current = new List<int>();
            var size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                var cur = queue.Dequeue();
                current.Add(cur.val);

                if (cur.left != null) queue.Enqueue(cur.left);
                if (cur.right != null) queue.Enqueue(cur.right);

                if (cur.left != null && cur.right != null &&
                    (cur.left.val == x && cur.right.val == y || cur.left.val == y && cur.right.val == x)) return false;
            }
            ;

            if (current.Contains(x) && current.Contains(y)) return true;

        }

        return false;
    }
}