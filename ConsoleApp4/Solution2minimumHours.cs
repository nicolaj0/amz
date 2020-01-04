using System.Collections.Generic;

namespace ConsoleApp4
{
    public class Solution2minimumHours
    {
        private readonly Queue<(int, int)> _queue;
        private readonly Dictionary<(int, int), int> _depth;

        public Solution2minimumHours()
        {
            _queue = new Queue<(int, int)>();
            _depth = new Dictionary<(int, int), int>();
        }

        public int minimumHours(int rows, int columns, int[,] grid)
        {
            var nbHours = 0;

            InitalizeSources(rows, columns, grid);

            if (_queue.Count == 0) return -1;

            nbHours = ExpandFileStatuses(rows, columns, grid, nbHours);

            return nbHours;
        }

        private int ExpandFileStatuses(int rows, int columns, int[,] grid, int nbHours)
        {
            var adjacentCellsHelper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};
            while (_queue.Count > 0)
            {
                int x, y;
                var currentCell = _queue.Dequeue();
                x = currentCell.Item1;
                y = currentCell.Item2;

                foreach (var direction in adjacentCellsHelper)
                {
                    var dx = direction.Item1;
                    var dy = direction.Item2;
                    var isAdjacentCell = dx + x >= 0 && dx + x < rows && dy + y >= 0 && dy + y < columns;
                    if (isAdjacentCell)
                    {
                        var adjacentCellNotVisited = grid[x + dx, y + dy] == 0;

                        if (adjacentCellNotVisited)
                        {
                            grid[x + dx, y + dy] = 1;
                            _queue.Enqueue((x + dx, y + dy));
                            _depth[(x + dx, y + dy)] = _depth[(x, y)] + 1;
                            nbHours = _depth[(x + dx, y + dy)];
                        }
                    }
                }
            }

            return nbHours;
        }

        private void InitalizeSources(int rows, int columns, int[,] grid)
        {
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < columns; j++)
                {
                    if (grid[i, j] == 1)
                    {
                        _queue.Enqueue((i, j));
                        _depth[(i, j)] = 0;
                    }
                }
            }
        }
    }
}