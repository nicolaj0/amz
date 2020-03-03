public class SolutionMaximalSquare
{
    public int MaximalSquare(char[][] matrix)
    {
        var maxsqlen = 0;
        var current = 0;

        var m = matrix.Length;
        var n = matrix[0].Length;


        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matrix[i][j] == 1)
                {
                    int sqlen = 1;
                    bool flag = true;
                    while (sqlen + i < m && sqlen + j < n && flag)
                    {
                        {
                            for (int k = j; k <= sqlen + j; k++)
                            {
                                if (matrix[i + sqlen][k] == '0')
                                {
                                    flag = false;
                                    break;
                                }
                            }

                            for (int k = i; k <= sqlen + i; k++)
                            {
                                if (matrix[k][j + sqlen] == '0')
                                {
                                    flag = false;
                                    break;
                                }
                            }

                            if (flag)
                                sqlen++;
                        }
                    }
                    if (maxsqlen < sqlen) {
                        maxsqlen = sqlen;
                    }
                }
            }
        }

        return 0;
    }
}