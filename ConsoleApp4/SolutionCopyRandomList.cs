using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionCopyRandomList
    {
        Dictionary<Node, Node> _map = new Dictionary<Node, Node>();

        public Node CopyRandomList(Node head)
        {
            Node current = head;

            while (current != null)
            {
                var next = current.next;
                var random = current.random;

                Node currentCopy;
                if (_map.ContainsKey(current))
                {
                    currentCopy = _map[current];
                }
                else
                {
                    currentCopy = new Node(current.val);
                    _map[current] = currentCopy;
                }

                if (next != null)
                {
                    if (_map.ContainsKey(next))
                    {
                        currentCopy.next = _map[next];
                    }
                    else
                    {
                        currentCopy.next = new Node(next.val);
                        _map[next] = currentCopy.next;
                    }
                }

                if (random != null)
                {
                    if (_map.ContainsKey(random))
                    {
                        currentCopy.random = _map[random];
                    }
                    else
                    {
                        currentCopy.random = new Node(random.val);
                        _map[random] = currentCopy.random;
                    }
                }

                current = next;
            }

            return head!= null ? _map[head] : null;
        }
        public class Node
        {
            public int val;
            public Node next;
            public Node random;

            public Node(int _val)
            {
                val = _val;
                next = null;
                random = null;
            }
        }

        
    }
}