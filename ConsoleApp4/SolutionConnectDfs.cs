using System.Collections.Generic;

namespace ConsoleApp4
{
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node()
        {
        }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }

        public override string ToString()
        {
            return $"{val}, {nameof(next)}: {next}";
        }
    }
    
    public class SolutionConnectDfs
    {
        public Node Connect(Node root)
        {
            int h = height(root);
            int i;
            var f = new Queue<Node>();
            for (i = 1; i <= h; i++)
            {
                printGivenLevel(root, f,i);
                f.Clear();
            }

            return root;
        }


        public virtual void printGivenLevel(Node root,
            Queue<Node> nodes,
            
            int level)
        {
            if (root == null)
            {
                return;
            }

            if (level == 1)
            {
                if (nodes.Count > 0)
                {
                    nodes.Dequeue().next =root;
                }
                nodes.Enqueue(root);


            }
            else if (level > 1)
            {
                printGivenLevel(root.left, nodes,level - 1);
                printGivenLevel(root.right, nodes,level - 1);

            }
        }


        public virtual int height(Node root)
        {
            if (root == null)
            {
                return 0;
            }
            else
            {
                /* compute height of each subtree */
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
        }
    }
}