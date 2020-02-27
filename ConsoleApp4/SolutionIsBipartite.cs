using System;
using System.Collections.Generic;

public class SolutionIsBipartite
{
    public bool IsBipartite(int[][] graph)
    {
        var color = new int[graph.Length];

        Array.Fill(color, -1);


        for (int start = 0; start < graph.Length; ++start)
        {
           
            
            {
                var stack = new Stack<int>();
                stack.Push(start);
                color[start] = 0;
                while (stack.Count > 0)
                {
                    var node = stack.Pop();
                    foreach (int nei in graph[node])
                    {
                        if (color[nei] == -1)
                        {
                            stack.Push(nei);
                            color[nei] = color[node] ^ 1;
                        }
                        else if (color[nei] == color[node])
                        {
                            return false;
                        }
                    }
                }
            }
        }


        return true;
    }
}