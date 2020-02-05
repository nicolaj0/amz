using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionGameOfLife
    {
        private int[][] _grid;
        private int nbFreh;
        private int mibutes;

        public void GameOfLife(int[][] board)
        {
            _grid = board;
            var nbMin = 0;
            var helper = new List<(int, int)>
            {
                (0, 1), (0, -1), (1, 0), (-1, 0),
                (1, 1), (1, -1), (-1, 1), (-1, -1)
            };

            var newArray = new List<List<int>>();

            foreach (var t in _grid)
            {
                newArray.AddRange(new[] {t.ToList()});
            }

            for (int i = 0; i < _grid.Length; i++)
            {
                
                for (int j = 0; j < _grid[0].Length; j++)
                {
                    int nbLiveCells = 0;
                    foreach (var (dx, dy) in helper)
                    {
                        if (dx + i < 0 || dx + i >= _grid.Length || dy + j < 0 || dy + j >= _grid[0].Length)
                            continue;
                        if (_grid[i + dx][j + dy] == 1)
                        {
                            nbLiveCells++;
                        }
                    }

                    if (nbLiveCells < 2 || nbLiveCells > 3) 
                        newArray[i][j] = 0;
                    else if (_grid[i][j] == 1 && (nbLiveCells == 2 || nbLiveCells == 3)) 
                        newArray[i][j] = 1;
                    else if (_grid[i][j] == 0 && (nbLiveCells == 3)) 
                        newArray[i][j] = 1;
                    else
                    {
                        Console.WriteLine(nbLiveCells);
                        Console.WriteLine(_grid[i][j]);
                    }
                }
            }

            for (int i = 0; i < newArray.Count; i++)
            {
                board[i] = newArray[i].ToArray();
                Console.WriteLine(string.Join("",board[i]));
            }
        }
    }
}