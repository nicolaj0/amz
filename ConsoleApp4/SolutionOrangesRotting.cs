using System.Collections.Generic;

namespace ConsoleApp5
{
    public class Solution
    {
        private int[][] _grid;
        private int nbFreh;
        private int mibutes;

        public int OrangesRotting(int[][] grid)
        {
            _grid = grid;
            var nbMin = 0;
            var helper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};

            var queue = new Queue<(int, int)>();

            var map = new Dictionary<(int, int), int>();

            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[0].Length; j++)
                {
                    if (_grid[i][j] == 2)
                    {
                        queue.Enqueue((i, j));
                        map[(i, j)] = 0;
                    }
                }
            }

            while (queue.Count > 0)
            {
                var (x, y) = queue.Dequeue();

                foreach (var (dx, dy) in helper)
                {
                    if (dx + x >= 0 && dx + x < _grid.Length && dy + y >= 0 && dy + y < _grid[0].Length)
                    {
                        if (_grid[x + dx][y + dy] == 1)
                        {
                            _grid[x + dx][y + dy] = 2;
                            queue.Enqueue((x + dx, y + dy));
                            map[(x + dx, y + dy)] = map[(x, y)] + 1;
                            mibutes = map[(x + dx, y + dy)];
                        }
                    }
                }
            }

            foreach (var row in grid)
            {
                foreach (var v in row)
                {
                    if (v == 1) return -1;
                }
            }

            return mibutes;
        }
    }

    public class SolutionOrangesRotting
    {
        private int[][] _grid;
        private int nbFreh;
        private int mibutes;

        public int OrangesRotting(int[][] grid)
        {
            _grid = grid;
            var nbMin = 0;
            getFresh();
            var helper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};

            var queue = new Queue<(int, int)>();

            if (nbFreh == 0) return 0;

            while (nbFreh > 0)
            {
                var previousFresh = nbFreh;
                for (int i = 0; i < _grid.Length; i++)
                {
                    for (int j = 0; j < _grid[0].Length; j++)
                    {
                        if (grid[i][j] == 2)
                        {
                            queue.Enqueue((i, j));
                        }

                        while (queue.Count > 0)
                        {
                            var (x, y) = queue.Dequeue();

                            foreach (var (dx, dy) in helper)
                            {
                                if (dx + x >= 0 && dx + x < _grid.Length && dy + y >= 0 && dy + y < _grid[0].Length)
                                {
                                    if (_grid[x + dx][y + dy] == 1)
                                    {
                                        _grid[x + dx][y + dy] = 3;
                                        nbFreh--;
                                    }
                                }
                            }
                        }
                    }
                }

                if (previousFresh == nbFreh && nbFreh > 0)
                {
                    mibutes = -1;
                    break;
                }

                mibutes++;
                if (nbFreh == 0) break;

                update();
            }


            if (mibutes == -1) return -1;
            return mibutes;
        }

        private void getFresh()
        {
            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[0].Length; j++)
                {
                    if (_grid[i][j] == 1) nbFreh++;
                }
            }
        }

        private void update()
        {
            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[0].Length; j++)
                {
                    if (_grid[i][j] == 3) _grid[i][j] = 2;
                }
            }
        }
    }
}