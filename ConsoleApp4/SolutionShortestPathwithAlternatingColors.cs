using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    /*//var res = new Solution().ShortestAlternatingPaths(3, new[] {new[] {0, 1}}, new[] {new[] {2, 1}});
            //var res = new Solution().ShortestAlternatingPaths(3, new[] {new[] {1, 0}}, new[] {new[] {2, 1}});
            //var res = new Solution().ShortestAlternatingPaths(3, new[] {new[] {0, 1}}, new[] {new[] {0, 2}});
            var res = new SolutionShortestPathwithAlternatingColors().ShortestAlternatingPaths(5, new[]
            {
                new[] {0, 1},
                new[] {1, 2},
                new[] {2, 3},
                new[] {3, 4},
            }, new[]
            {
                new[] {1, 2},
                new[] {2, 3},
                new[] {3, 1},
            });
            // var res = new Solution().ShortestAlternatingPaths(3, new[] {new[] {0, 1}, new[] {1, 2}}, null);

            res.ToList().ForEach(r => Console.WriteLine(r));
            Console.WriteLine(res);*/
    
    
    public class SolutionShortestPathwithAlternatingColors
    {
        public enum Color
        {
            Red,
            Blue
        }

        public int[] ShortestAlternatingPaths(int n, int[][] red_edges, int[][] blue_edges)
        {
            var graph = new Graph(n);

            if (red_edges != null)
                foreach (var redEdge in red_edges?.ToList())
                {
                    graph.addEdge(redEdge[0], redEdge[1], Color.Red); // and add edge connecting them.
                }

            if (blue_edges != null)
                foreach (var redEdge in blue_edges.ToList())
                {
                    graph.addEdge(redEdge[0], redEdge[1], Color.Blue); // and add edge connecting them.
                }

            var shortestAlternatingPaths = new List<int>();

            var breadthFirstPaths = new BreadthFirstPaths(graph, 0);


            return breadthFirstPaths.distance.Select(r => r.Value).ToArray();
        }


        public class BreadthFirstPaths
        {
            private Dictionary<(int, Color?), bool> marked; // Is a shortest path to this vertex known?
            private Dictionary<int, (int, Color?)> edgeTo; // last vertex on known path to this vertex
            public Dictionary<int, int> distance; // last vertex on known path to this vertex
            private int s; // source

            public BreadthFirstPaths(Graph G, int s)
            {
                marked = new Dictionary<(int, Color?), bool>();
                edgeTo = new Dictionary<int, (int, Color?)>();
                distance = new Dictionary<int, int>();

                distance[0] = 0;
                for (int i = 1; i < G.V; i++)
                {
                    distance[i] = -1;
                }

                this.s = s;
                bfs(G, s);
            }

            private void bfs(Graph G, int s)
            {
                var queue = new Queue<(int, Color?, int)>();
                marked[(s, null)] = true; // Mark the source
                queue.Enqueue((s, null, 0)); //   and put it on the queue.
                while (queue.Any())
                {
                    var v = queue.Dequeue(); // Remove next vertex from the queue.

                    foreach (var w in G.GetAdj(v.Item1))
                        if (!marked.ContainsKey(w))
                            // For every unmarked adjacent vertex,
                        {
                            if (v.Item2 == null || v.Item2 != w.Item2)
                            {
                                if (distance[w.Item1] == -1) distance[w.Item1] = v.Item3 + 1;
                                marked[w] = true;
                                queue.Enqueue((w.Item1, w.Item2, v.Item3 + 1)); //   and add it to the queue.
                            }
                        }
                }
            }


            public IEnumerable<int> pathTo(int v)
            {
                Stack<int> path = new Stack<int>();
                for (var x = v; x != s; x = edgeTo[x].Item1)
                {
                    path.Push(x);
                }

                path.Push(s);
                return path;
            }
        }


        public class Graph
        {
            public int E { get; set; }
            public int V { get; set; }
            public List<(int, Color)>[] adj; // adjacency lists

            public Graph(int V)
            {
                this.V = V;
                this.E = 0;
                adj = new List<(int, Color)>[V]; // Create array of lists.
                for (int v = 0; v < V; v++) // Initialize all lists
                    adj[v] = new List<(int, Color)>(); //   to empty.
            }

            public void addEdge(int from, int to, Color c)
            {
                adj[from].Add((to, c)); // Add w to v's list.
                E++;
            }

            public List<(int, Color)> GetAdj(int v)
            {
                return adj[v];
            }
        }
    }
}