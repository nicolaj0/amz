using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    public class SolutionCutOffTree
    {
        public int CutOffTree(IList<IList<int>> forest)
        {
            var steps = 0;
            var nbtotalTree = 0;
            var nbForest = 0;

            if (forest[0][0] > 1) steps = -1;
            if (forest[0][0] == 0) return  -1;


            var helper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};

            var queue = new Queue<(int, int, int)>();

            for (int i = 0; i < forest.Count; i++)
            {
                for (int j = 0; j < forest[0].Count; j++)
                {
                    if (forest[i][j] > 1)
                    {
                        forest[i][j] = 1;
                        queue.Enqueue((i, j, forest[i][j]));
                        nbForest++;
                    }

                    while (queue.Count > 0)
                    {
                        var (x, y, z) = queue.Dequeue();

                        var list = new List<(int, int, int)>();
                        foreach (var (dx, dy) in helper)
                        {
                            if (dx + x >= 0 && dx + x < forest.Count && dy + y >= 0 && dy + y < forest[0].Count)
                            {
                                if (forest[x + dx][y + dy] > 1)
                                {
                                    list.Add((x + dx, y + dy, forest[x + dx][y + dy]));
                                    forest[x + dx][y + dy] = 1;
                                }
                            }
                        }

                        list.OrderBy(r => r.Item3).ToList().ForEach(r => queue.Enqueue(r));
                        steps++;
                    }
                }
            }


            if (nbForest > 1) return -1;

            return steps;
        }
    }
}