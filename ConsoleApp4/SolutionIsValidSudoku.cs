using System.Collections.Generic;
using System.Linq;

public class SolutionIsValidSudoku
{
    public bool IsValidSudoku(char[][] board)
    {
        if (board.Length != board[0].Length) return false;

        var nums = new char[] {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
        for (int i = 0; i < board.Length; i++)
        {
            var where = board[i].Where(p => p != '.').ToList();
            if (where.Except(nums).Any()) return false;
            if (where.GroupBy(r => r).Select(r => r.Count()).Any(r => r > 1)) return false;
        }


        var centers = new List<(int, int)>();

        var rr = new List<int> {1, 4, 7};

        for (int j = 0; j < board.Length; j++)
        {
            var col = new List<char>();
            for (var i = 0; i < board.Length; i++)
            {
                var t = board[i];
                if (rr.Contains(i) && rr.Contains(j))
                {
                    centers.Add((i, j));
                }

                if (t[j] != '.')
                    col.Add(t[j]);
            }

            if (col.Except(nums).Any()) return false;
            if (col.GroupBy(r => r).Select(r => r.Count()).Any(r => r > 1)) return false;
        }


        var shifts = new List<(int, int)> {(0, 0), (-1, -1), (0, -1), (1, 1), (1, 0), (1, -1), (0, 1), (-1, 1), (-1, 0)};


        foreach (var center in centers)
        {
            var box = new List<char>();
            foreach (var shift in shifts)
            {
                var item = board[center.Item1 + shift.Item1][center.Item2 + shift.Item2];
                if (item != '.') box.Add(item);
            }

            if (box.Except(nums).Any()) return false;
            if (box.GroupBy(r => r).Select(r => r.Count()).Any(r => r > 1)) return false;
        }

        return true;
    }
}