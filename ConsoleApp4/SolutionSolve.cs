using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionSolve
    {
        public void Solve(char[][] board)
        {
            Console.WriteLine("before");
            print(board);

            algo(board);

            Console.WriteLine("before");
            print(board);


            changeBorder(board);

            Console.WriteLine("end");
            print(board);
        }

        private static void algo(char[][] board)
        {
            var queue = new Queue<(int, int)>();

            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (isBorder(board, i, j))
                    {
                        visit(board, i, j, queue);
                    }
                }
            }
        }

        private static void visit(char[][] board, int i, int j,
            Queue<(int, int)> queue)
        {
            if (board[i][j] == 'O')
            {
                board[i][j] = 'P';
                queue.Enqueue((i, j));
                while (queue.Count > 0)
                {
                    var (x, y) = queue.Dequeue();

                    foreach (var (dx, dy) in new[] {(1, 0), (0, 1), (-1, 0), (0, -1)})
                    {
                        var newX = x + dx;
                        var newY = y + dy;

                        if (newX >= 0 && newX < board.Length && newY >= 0 && newY < board[0].Length &&
                            board[newX][newY] == 'O')
                        {
                            queue.Enqueue((newX, newY));
                            board[newX][newY] = 'P';
                        }
                    }
                }
            }
        }

        private static void changeBorder(char[][] board)
        {
            for (int i = 0; i < board.Length; i++)
            {
                for (int j = 0; j < board[0].Length; j++)
                {
                    if (board[i][j] == 'O') 
                        board[i][j] = 'X';
                    else if (board[i][j] == 'P')
                        board[i][j] = 'O';
                }
            }
        }

        private static bool isBorder(char[][] board, int i, int j)
        {
            return i == 0 || j == 0 || i == board.Length - 1 || j == board[0].Length - 1;
        }

        private static void print(char[][] board)
        {
            board.ToList().ForEach(r => Console.WriteLine(string.Join("", r)));
        }
    }
}