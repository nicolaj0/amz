using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionShortestDistance
    {
        public int ShortestDistance(int[][] maze, int[] start, int[] dest)
        {
            int[][] distance =new int[maze.Length][];
            for (int i = 0; i < maze.Length; i++)
            {
                distance[i] = new int[maze[0].Length];
                for (int j = 0; j < maze[0].Length; j++)
                {
                    distance[i][j] = int.MaxValue;
                }
            }

            var dirs = new List<int[]> {new[] {0, 1}, new[] {0, -1}, new[] {1, 0}, new[] {-1, 0}};

            distance[start[0]][start[1]] = 0;
            distance[start[0]][start[1]] = 0;

            int shortest = 0;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(start);
            while (queue.Count > 0)
            {
                int[] s = queue.Dequeue();
                foreach (int[] dir in dirs)
                {
                    int x = s[0] + dir[0];
                    int y = s[1] + dir[1];
                    int count = 0;
                    while (x >= 0 && y >= 0 && x < maze.Length && y < maze[0].Length && maze[x][y] == 0)
                    {
                        x += dir[0];
                        y += dir[1];
                        count++;
                    }

                    if (distance[s[0]][s[1]] + count < distance[x - dir[0]][y - dir[1]])
                    {
                        distance[x - dir[0]][y - dir[1]] = distance[s[0]][s[1]] + count;
                        queue.Enqueue(new int[] {x - dir[0], y - dir[1]});
                    }
                }
            }

            return distance[dest[0]][dest[1]] == int.MaxValue ? -1 : distance[dest[0]][dest[1]];
        }
    }
}