using System;
using System.Collections.Generic;

public class SolutionNetworkDelayTime
{
    private Dictionary<int, int> dist;
    private Dictionary<int, List<int[]>> graph;

    public int NetworkDelayTime(int[][] times, int N, int K)
    {
        dist = new Dictionary<int, int>();
        graph = new Dictionary<int, List<int[]>>();

        foreach (var edge in times)
        {
            if (!graph.ContainsKey(edge[0]))
            {
                graph[edge[0]] = new List<int[]>();
            }

            graph[edge[0]].Add(new[] {edge[2], edge[1]});
        }

        foreach (var value in graph.Values)
        {
            value.Sort((a, b) => a[0].CompareTo(b[0]));
        }

        for (int node = 1; node <= N; ++node)
            dist[node] = int.MaxValue;

        dfs(K, 0);

        int ans = 0;
        foreach (var cand in dist.Values)
        {
            if (cand == int.MaxValue) return -1;
            ans = Math.Max(ans, cand);
        }

        return ans;
    }

    public void dfs(int node, int elapsed)
    {
        if (elapsed >= dist[node]) return;
        dist[node] = elapsed;
        if (graph.ContainsKey(node))
            foreach (int[] info in graph[node])
                dfs(info[1], elapsed + info[0]);
    }
}