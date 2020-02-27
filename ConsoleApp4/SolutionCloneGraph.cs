using System.Collections.Generic;


public class SolutionCloneGraph {
    
    public class Node {
        public int val;
        public IList<Node> neighbors;
    
        public Node() {
            val = 0;
            neighbors = new List<Node>();
        }

        public Node(int _val) {
            val = _val;
            neighbors = new List<Node>();
        }
    
        public Node(int _val, List<Node> _neighbors) {
            val = _val;
            neighbors = _neighbors;
        }
    }

    public Node CloneGraph(Node node)
    {
        
        if (node == null) {
            return null;
        }
        var queue =  new Queue<Node>();
        var map = new Dictionary<Node,Node>{{node,new Node(node.val)}};
        
        queue.Enqueue(node);

        while (queue.Count > 0)
        {
            var n = queue.Dequeue();

            foreach (var neighbor in n.neighbors)
            {
                if (!map.ContainsKey(neighbor))
                {
                    map[neighbor] = new Node(neighbor.val);
                    queue.Enqueue((neighbor));
                }
               
                map[n].neighbors.Add(map[neighbor]);
            }
        }


        return map[node];
    }
}