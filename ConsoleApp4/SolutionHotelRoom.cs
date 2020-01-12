using System.Collections.Generic;

namespace ConsoleApp4
{
    
    /* /*var res = new Solution().CanVisitAllRooms(new List<IList<int>>
           {
               new List<int>{1},
               new List<int>{2},
               new List<int>{3},
               new List<int>{},
               
           });
           
    var res = new SolutionHotelRoom().CanVisitAllRooms(new List<IList<int>>
    {
    new List<int>{1,3},
    new List<int>{3,0,1},
    new List<int>{2},
    new List<int>{0},
               
    });


    Console.WriteLine(res);*/
    public class SolutionHotelRoom
    {
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            Digraph G = new Digraph(rooms.Count);

            for (int i = 0; i < rooms.Count; i++)
            {
                foreach (var key in rooms[i])
                {
                    G.addEdge(i,key);
                }
            }

            DirectedDFS reachable = new DirectedDFS(G, 0);

            for (int v = 0; v < G.V; v++)
                if (!reachable.marked(v))
                    return false;
            return true;
        }


        public class DirectedDFS
        {
            private bool[] Marked;

            public DirectedDFS(Digraph G, int s)
            {
                Marked = new bool[G.V];
                dfs(G, s);
            }
            
            private void dfs(Digraph G, int v)
            {
                Marked[v] = true;
                foreach (int w in G.GetAdj(v))
                    if (!Marked[w]) dfs(G, w);
            }

            public bool marked(int v)
            {
                return Marked[v];
            }
        }


        public class Digraph
        {
            public int E { get; set; }
            public int V { get; set; }
            public List<int>[] adj; // adjacency lists

            public Digraph(int V)
            {
                this.V = V;
                this.E = 0;
                adj = new List<int>[V]; // Create array of lists.
                for (int v = 0; v < V; v++) // Initialize all lists
                    adj[v] = new List<int>(); //   to empty.
            }

            public void addEdge(int from, int to)
            {
                adj[from].Add((to)); // Add w to v's list.
                E++;
            }

            public List<int> GetAdj(int v)
            {
                return adj[v];
            }
        }
    }
}