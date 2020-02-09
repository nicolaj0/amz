using System.Collections.Generic;

/*var res = new SolutionPacificAtlantic().PacificAtlantic(new[]
           {
               new[] {1, 2, 2, 3, 5},
               new[] {3, 2, 3, 4, 4},
               new[] {2, 4, 5, 3, 1},
               new[] {6, 7, 1, 4, 5},
               new[] {5, 1, 1, 2, 4},
           });

           Console.WriteLine(res);*/
public class SolutionPacificAtlantic {
    private List<(int, int)> _helper;
    private int[][] _matrix;
    private int _n;
    private int _m;

    public IList<IList<int>> PacificAtlantic(int[][] matrix)
    {
       
        var res = new List<IList<int>>();

        
        if(matrix == null || matrix.Length == 0 || matrix[0].Length == 0){
            return res;
        }
        _matrix = matrix;
        _helper = new List<(int, int)> {(0, 1), (0, -1), (1, 0), (-1, 0)};
        

        _n = matrix.Length;
        _m = matrix[0].Length;

        var  pacific = new bool[_n][];
        var  atlantic = new bool[_n][];

        for (int i = 0; i < _n; i++)
        {
            pacific[i] = new bool[_m];
            atlantic[i] = new bool[_m];
        }
        
        var pQueue = new Queue<(int,int)>();
        var aQueue = new Queue<(int,int)>();

        for (int i = 0; i < _n; i++)
        {
            pacific[i][0] = true;
            atlantic[i][_m - 1] = true;
            pQueue.Enqueue((i,0));
            aQueue.Enqueue((i,_m-1));
        }
        
        for (int i = 0; i < _m; i++)
        {
            pacific[0][i] = true;
            atlantic[_n-1][i] = true;
            pQueue.Enqueue((0,i));
            aQueue.Enqueue((_n-1,i));
        }

        bfs(pQueue, pacific);
        bfs(aQueue, atlantic);

        for (int i = 0; i < _n; i++)
        {
            for (int j = 0; j < _m; j++)
            {
                if (atlantic[i][j] && pacific[i][j])
                {
                    res.Add(new List<int>{i,j});
                }
            }
        }


        return res;




    }

    private void bfs(Queue<(int, int)> queue, bool[][] visited)
    {
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            foreach (var (dx, dy) in _helper)
            {
                int i = x + dx;
                int j = y + dy;
                
                if (i <0 || j <0 || i>=_n || j >=_m || visited[i][j] || _matrix[i][j]<_matrix[x][y]) continue;
                visited[i][j] = true;
                queue.Enqueue((i,j));
            }
        }
    }
}