using System;
using System.Collections.Generic;

public class SolutionWallsAndGates
{
    private int[][] _rooms;
    private Queue<(int, int)> _q;
    private Dictionary<(int, int), int> _map;

    public void WallsAndGates(int[][] rooms)
    {
        _rooms = rooms;

        _q = new Queue<(int, int)>();

        _map = new Dictionary<(int, int), int>();

        var adjacentCellsHelper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};


        for (int i = 0; i < _rooms.Length; i++)
        {
            for (int j = 0; j < _rooms[0].Length; j++)
            {
                if (_rooms[i][j] == 0)
                {
                    _q.Enqueue((i, j));
                    _map[(i, j)] = 0;
                }
            }
        }

        while (_q.Count > 0)
        {
            var (x, y) = _q.Dequeue();

            foreach (var (dx, dy) in adjacentCellsHelper)
            {
                if (x + dx >= 0 && x + dx < _rooms.Length && y + dy >= 0 && y + dy < _rooms[0].Length)
                {
                    var i = _rooms[x + dx][y + dy];
                    Console.WriteLine(i);
                    if (i == 2147483647)
                    {
                        _q.Enqueue((x + dx, y + dy));
                        _rooms[x + dx][y + dy]= _map[(x, y)] + 1;
                        _map[(x + dx, y + dy)] =  _rooms[x + dx][y + dy];
                    }
                }
            }
        }
    }
}