using System.Collections.Generic;
using System.Linq;

public class SolutionLowestCommonAncestor
{
    private List<TreeNode> list = new List<TreeNode>();

    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        pathFinder(root, p, new LinkedList<TreeNode>());
        var listp = list.ToList();
        pathFinder(root, q, new LinkedList<TreeNode>());
        var listq = list.ToList();

        int i = 0;
        
        while (i < listp.Count && i < listq.Count)
        {
            if (listp[i].val != listq[i].val) break;
            i++;
        }

        return listp[i- 1];
    }

    private void pathFinder(TreeNode root, TreeNode treeNode, LinkedList<TreeNode> linkedList)
    {
        if (root == null)
        {
            return;
        }
        linkedList.AddLast(root);
        if (root.val == treeNode.val)
        {
            list = linkedList.ToList();
            return;
        }

       

        if (root.left != null) pathFinder(root.left, treeNode, linkedList);
        if (root.right != null) pathFinder(root.right, treeNode, linkedList);

        linkedList.RemoveLast();
    }
}