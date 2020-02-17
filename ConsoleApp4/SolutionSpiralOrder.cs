using System.Collections.Generic;

public class SolutionSpiralOrder
{
    public IList<int> SpiralOrder(int[][] matrix)
    {
        int[] dr = {0, 1, 0, -1};
        int[] dc = {1, 0, -1, 0};
        var ans = new List<int>();
        if (matrix.Length == 0) return ans;
        int R = matrix.Length, C = matrix[0].Length;
        var seen = new bool[R, C];
        int r = 0, c = 0, di = 0;

        for (int i = 0; i < R * C; i++)
        {
            ans.Add(matrix[r][c]);
            seen[r, c] = true;
            int cr = r + dr[di];
            int cc = c + dc[di];
            if (cr < R && cc < C && cr >= 0 && cc >= 0 && !seen[cr, cc])
            {
                r = cr;
                c = cc;
            }
            else
            {
                di = (di + 1) % 4;
                r += dr[di];
                c += dc[di];
            }
        }

        return ans;
    }
}