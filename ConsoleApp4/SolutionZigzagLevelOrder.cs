using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionZigzagLevelOrder
    {
            
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
            
        private TreeNode root;

        IList<IList<int>> output = new List<IList<int>>();
        private bool _changeOrder;

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            this.root = root;

            printLevelOrder();
            return output;
        }


        public virtual void printLevelOrder()
        {
            int h = height(root);
            int i;
            for (i = 1; i <= h; i++)
            {
                var ints = new List<int>();
                _changeOrder = i%2 != 0;
                printGivenLevel(root, i, ints);
                output.Add(ints);
            }
        }

        public virtual int height(TreeNode root)
        {
            if (root == null)
            {
                return 0;
            }

            int lheight = height(root.left);
            int rheight = height(root.right);

            /* use the larger one */
            if (lheight > rheight)
            {
                return (lheight + 1);
            }
            else
            {
                return (rheight + 1);
            }
        }

        /* Print nodes at the given level */
        public virtual void printGivenLevel(TreeNode root,
            int level, List<int> ints)
        {
            if (root == null)
            {
                return;
            }

            if (level == 1)
            {
                ints.Add(root.val);
            }
            else if (level > 1 && _changeOrder)
            {
                printGivenLevel(root.left, level - 1, ints);
                printGivenLevel(root.right, level - 1, ints);
            }
            else if (level > 1 && !_changeOrder)
            {
                printGivenLevel(root.right, level - 1, ints);
                printGivenLevel(root.left, level - 1, ints);
            }
        }
    }
}