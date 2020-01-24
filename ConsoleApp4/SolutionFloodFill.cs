using System.Collections.Generic;

namespace ConsoleApp4
{
    public class SolutionFloodFill {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            var adjacentCellsHelper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};

            var queue = new Queue<(int, int)>();

            var color = image[sr][sc];
            image[sr][sc] = -newColor;
            
            queue.Enqueue((sr,sc));


            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                foreach (var (dx, dy) in adjacentCellsHelper)
                {
                    if (x + dx >= 0 && y + dy >= 0 && x + dx < image.Length && y + dy < image[0].Length &&
                        image[x + dx][y + dy] == color)
                    {
                        queue.Enqueue((x+dx,y+dy));
                        image[x + dx][y + dy] = -newColor;
                    }
                }
            }


            for (int i = 0; i < image.Length; i++)
            {
                for (int j = 0; j < image[0].Length; j++)
                {
                    if (image[i][j] == -newColor) 
                        image[i][j] = newColor;
                }
            }
            return image;
        }
    }
}