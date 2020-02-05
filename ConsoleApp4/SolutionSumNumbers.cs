using System.Collections.Generic;
using System.Linq;

public class SolutionSumNumbers {
    private List<string> _res;

    public int SumNumbers(TreeNode root)
    {
        _res = new List<string>();

        helper(root, new LinkedList<int>());

        return _res.Select(r=> int.Parse((string) r)).Sum();
    }

    private void helper(TreeNode root, LinkedList<int> linkedList)
    {
        if (root == null) return;

        linkedList.AddLast(root.val);
        
        if (root.left == null && root.right == null) _res.Add(string.Join("", linkedList));

        helper(root.left, linkedList);
        helper(root.right, linkedList);
        
        linkedList.RemoveLast();
    }
}