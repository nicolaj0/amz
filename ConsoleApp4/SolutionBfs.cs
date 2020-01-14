using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionBfs
    {
        public Node Connect(Node root)
        {
            var queue = new Queue<Node>();

            queue.Enqueue(root);
            queue.Enqueue(null);

            Node previous = null;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                if (node == null)
                {
                    previous = null;

                    if (queue.Count > 0)
                    {
                        queue.Enqueue(null);
                    }
                }

                else
                {
                    if (previous != null) previous.next = node;

                    if (node.right != null) queue.Enqueue(node.left);
                    if (node.left != null) queue.Enqueue(node.right);

                    previous = node;
                }
            }


            return root;
        }
    }
}