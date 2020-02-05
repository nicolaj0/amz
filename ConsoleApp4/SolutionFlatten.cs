using System;

public class SolutionFlatten
{
    public void Flatten(TreeNode root)
    {
        Console.WriteLine(root);
        helper(root);
        Console.WriteLine(root);
    }

    private TreeNode helper(TreeNode root) {
        if (root == null) {
            return null;
        }
        
        TreeNode leftRes = helper(root.left);
        TreeNode rightRes = helper(root.right);

        if (leftRes != null) {
            TreeNode temp = root.right; // temporarily store right child
            root.right = root.left;
            root.left = null;
            leftRes.right = temp;
        }
		
        // because the linked list is root -> left -> right, we should try to return right first, then left, finally root.
        
        if (rightRes != null) {
            return rightRes;
        }
        
        if (leftRes != null) {
            return leftRes;
        }
        
        return root;
    }
}