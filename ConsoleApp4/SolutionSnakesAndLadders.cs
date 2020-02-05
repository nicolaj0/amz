using System;
using System.Collections.Generic;

class SolutionSnakesAndLadders {
    public int SnakesAndLadders(int[][] board) {
        int N = board.Length;

        Dictionary<int,int> dist = new Dictionary<int, int>();
        dist.Add(1, 0);

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);

        while (queue.Count>0) {
            int s = queue.Dequeue();
            if (s == N*N) return dist[s];

            for (int s2 = s+1; s2 <= Math.Min(s+6, N*N); ++s2) {
                var (r, c) = get(s2, N);
                int s2Final = board[r][c] == -1 ? s2 : board[r][c];
                if (!dist.ContainsKey(s2Final)) {
                    dist[s2Final] =  dist[s] + 1;
                    queue.Enqueue(s2Final);
                }
            }
        }
        return -1;
    }

    public (int,int) get(int s, int N) {
        // Given a square num s, return board coordinates (r, c) as r*N + c
        int quot = (s-1) / N;
        int rem = (s-1) % N;
        int row = N - 1 - quot;
        int col = row % 2 != N % 2 ? rem : N - 1 - rem;
        return (row , col);
    }
}