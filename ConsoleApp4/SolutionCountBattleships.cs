namespace ConsoleApp4
{
    public class SolutionCountBattleships
    {
        private int _boardLength;
        private int _length;

        public int CountBattleships(char[][] board)
        {

            _boardLength = board.Length;
            _length = board[0].Length;

            int nbVessels = 0;

            for (var i = 0; i < _boardLength; i++)
            {
                for (var j = 0; j < _length; j++)
                {
                    if (board[i][j] == 'X')
                    {
                        dfs(board, i, j);
                        nbVessels++;
                    }
                }
            }


            return nbVessels;
        }

        public void dfs(char[][] board, int i, int j)
        {
            if (i < 0 || j < 0 || i >= _boardLength || j >= _length || board[i][j] == '.')
                return;
            board[i][j] = '.';
            dfs(board, i + 1, j);
            dfs(board, i, j + 1);
        }
    }
}