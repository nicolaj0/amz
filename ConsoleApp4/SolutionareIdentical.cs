namespace ConsoleApp4
{
    public class SolutionareIdentical {
        
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int x)
            {
                val = x;
            }
        }
        bool areIdentical(TreeNode root1, TreeNode root2)  
        {  
  
            /* base cases */
            if (root1 == null && root2 == null)  
                return true;  
  
            if (root1 == null || root2 == null)  
                return false;  
  
            /* Check if the data of both roots is 
            same and data of left and right  
            subtrees are also same */
            return (root1.val == root2.val  
                    && areIdentical(root1.left, root2.left)  
                    && areIdentical(root1.right, root2.right));  
        }  
  
        /* This function returns true if S is  
        a subtree of T, otherwise false */
        bool isSubtree(TreeNode T, TreeNode S)  
        {  
            /* base cases */
            if (S == null)  
                return true;  
  
            if (T == null)  
                return false;  
  
            /* Check the tree with root as current node */
            if (areIdentical(T, S))  
                return true;  
  
            /* If the tree with root as current  
              node doesn't match then try left 
              and right subtrees one by one */
            return isSubtree(T.left, S)  
                   || isSubtree(T.right, S);  
        }  
        
        
        public bool IsSubtree(TreeNode s, TreeNode t)
        {

            return isSubtree(s, t);
            
        }
        
        
    }
}