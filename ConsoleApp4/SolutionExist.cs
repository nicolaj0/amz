using System.Collections.Generic;

public class SolutionExist
{
    private List<(int, int)> _helper;
    private char[][] _board;
    private string _word;
    private bool _exists;
    private Dictionary<(int, int), bool> _visited;

    public bool Exist(char[][] board, string word)
    {
        _word = word;
        _board = board;
        _helper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};
        _visited = new Dictionary<(int, int), bool>();

        if (string.IsNullOrEmpty(word)) return false;
        if (board == null) return false;

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (word[0] == board[i][j])
                {
                    var linkedList = new LinkedList<char>();
                    _visited[(i, j)] = true;
                    linkedList.AddLast(board[i][j]);
                    backtrack(i, j, linkedList, 0);
                    if (_exists) break;
                    _visited.Remove((i, j));
                }
            }
        }

        return _exists;
    }

    private void backtrack(int x, int y, LinkedList<char> linkedList, int index)
    {
        if (linkedList.Count == _word.Length)
        {
            _exists = true;
            return;
        }

        ;

        foreach (var (dx, dy) in _helper)
        {
            if (dx + x >= 0 && dx + x < _board.Length && dy + y >= 0 && dy + y < _board[0].Length)
            {
                if (_board[x + dx][y + dy] == _word[index + 1] && !_visited.ContainsKey((x + dx, y + dy)))
                {
                    _visited[(x + dx, y + dy)] = true;
                    linkedList.AddLast(_board[x + dx][y + dy]);
                    backtrack(x + dx, y + dy, linkedList, index + 1);
                    linkedList.RemoveLast();
                    _visited.Remove((x + dx, y + dy));
                }
            }
        }
    }
}