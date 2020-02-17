using System.Collections.Generic;

public class SolutionFloodFill
{
    private int[][] _image;
    private int _newColor;
    private List<(int, int)> _helper;
    private int _color;


    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
    {
        _newColor = newColor;
        _image = image;
        _color = image[sr][sc];

        _helper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};
        if (_color != _newColor) helper(sr, sc);


        return _image;
    }

    private void helper(in int x, in int y)
    {
        if (_image[x][y] == _color)
        {
            _image[x][y] = _newColor;
            foreach (var (dx, dy) in _helper)
            {
                if (dx + x >= 0 && dx + x < _image.Length && dy + y >= 0 && dy + y < _image[0].Length)
                {
                    helper(x + dx, y + dy);
                }
            }
        }
    }
}

namespace ConsoleApp4
{
    public class SolutionFloodFill
    {
        public int[][] FloodFill(int[][] image, int sr, int sc, int newColor)
        {
            var adjacentCellsHelper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};

            var queue = new Queue<(int, int)>();

            var color = image[sr][sc];
            image[sr][sc] = -newColor;

            queue.Enqueue((sr, sc));


            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                foreach (var (dx, dy) in adjacentCellsHelper)
                {
                    if (x + dx >= 0 && y + dy >= 0 && x + dx < image.Length && y + dy < image[0].Length &&
                        image[x + dx][y + dy] == color)
                    {
                        queue.Enqueue((x + dx, y + dy));
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