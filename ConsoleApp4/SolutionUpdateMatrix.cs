using System.Collections.Generic;

public class SolutionUpdateMatrix
{
    public int[][] UpdateMatrix(int[][] matrix)
    {
        var queue = new Queue<(int, int)>();

        var n = matrix.Length;
        var m = matrix[0].Length;

        var dist = new int[n][];
        for (int i = 0; i < n; i++)
        {
            dist[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                dist[i][j] = int.MaxValue;
            }
        }

        var helper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (matrix[i][j] == 0)
                {
                    queue.Enqueue((i, j));
                    dist[i][j] = 0;
                }
            }
        }

        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            foreach (var (dx, dy) in helper)
            {
                if (dx + x >= 0 && dx + x < n && dy + y >= 0 && dy + y < m)
                {
                    var newCell = (x + dx, y + dy);
                    if (dist[x + dx][y + dy] > dist[x][y] + 1)
                    {
                        dist[x + dx][y + dy] = dist[x][y] + 1;
                        queue.Enqueue(newCell);
                    }
                }
            }
        }

        return dist;
    }
}